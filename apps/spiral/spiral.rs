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
            US12_0(string),
            US12_1(string),
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
        #[derive(Clone, Debug)]
        pub enum US33 {
            US33_0(std::path::PathBuf),
            US33_1(string),
        }
        impl core::fmt::Display for US33 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US34 {
            US34_0(std::path::PathBuf),
            US34_1,
        }
        impl core::fmt::Display for US34 {
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
        pub enum US36 {
            US36_0(string),
            US36_1(string),
        }
        impl core::fmt::Display for US36 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US35 {
            US35_0(Spiral::US36),
            US35_1,
        }
        impl core::fmt::Display for US35 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US37 {
            US37_0,
            US37_1,
            US37_2,
        }
        impl core::fmt::Display for US37 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US38 {
            US38_0(Spiral::US37),
            US38_1,
        }
        impl core::fmt::Display for US38 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US39 {
            US39_0(chrono::DateTime<chrono::Utc>),
            US39_1,
        }
        impl core::fmt::Display for US39 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US40 {
            US40_0(i32, string),
            US40_1(i32, string),
        }
        impl core::fmt::Display for US40 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US41 {
            US41_0(std::collections::HashMap<string, string>),
            US41_1,
        }
        impl core::fmt::Display for US41 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US42 {
            US42_0(Spiral::US5),
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
            UH4_1(string, bool, LrcPtr<Spiral::UH4>),
        }
        impl core::fmt::Display for UH4 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US43 {
            US43_0,
            US43_1(string),
        }
        impl core::fmt::Display for US43 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US44 {
            US44_0(std::fs::FileType),
            US44_1(std::string::String),
        }
        impl core::fmt::Display for US44 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US45 {
            US45_0,
            US45_1,
            US45_2,
        }
        impl core::fmt::Display for US45 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US46 {
            US46_0(async_walkdir::DirEntry),
            US46_1(std::string::String),
        }
        impl core::fmt::Display for US46 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US47 {
            US47_0(string, string),
            US47_1,
        }
        impl core::fmt::Display for US47 {
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
        pub fn method28(v0_1: string, v1_1: string) -> string {
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
        pub fn method30(v0_1: string) -> bool {
            let v4: &str = &*v0_1;
            let v28: std::string::String = String::from(v4);
            let v69: std::path::PathBuf = std::path::PathBuf::from(v28);
            if v69.clone().exists() {
                v69.is_dir()
            } else {
                false
            }
        }
        pub fn method31(v0_1: string) -> Option<string> {
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
        pub fn method32(v0_1: string, v1_1: string, v2: string) -> Spiral::US12 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<string> = MutCell::new(v2.clone());
            '_method32: loop {
                break '_method32 (if Spiral::method30(Spiral::method28(
                    v2.get().clone(),
                    v0_1.get().clone(),
                )) {
                    Spiral::US12::US12_0(v2.get().clone())
                } else {
                    let v6: Option<string> = Spiral::method31(v2.get().clone());
                    let v20: Spiral::US5 =
                        defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
                    match &v20 {
                        Spiral::US5::US5_0(v20_0_0) => {
                            let v0_1_temp: string = v0_1.get().clone();
                            let v1_1_temp: string = v1_1.get().clone();
                            let v2_temp: string = match &v20 {
                                Spiral::US5::US5_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            continue '_method32;
                        }
                        _ => Spiral::US12::US12_1(sprintf!(
                            "No parent for {} \'{}\' at \'{}\' (until \'{}\')",
                            string("dir"),
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            v2.get().clone()
                        )),
                    }
                });
            }
        }
        pub fn method29(v0_1: string, v1_1: string) -> Spiral::US12 {
            if Spiral::method30(Spiral::method28(v1_1.clone(), v0_1.clone())) {
                Spiral::US12::US12_0(v1_1.clone())
            } else {
                let v5: Option<string> = Spiral::method31(v1_1.clone());
                let v19: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
                match &v19 {
                    Spiral::US5::US5_0(v19_0_0) => Spiral::method32(
                        v0_1.clone(),
                        v1_1.clone(),
                        match &v19 {
                            Spiral::US5::US5_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => Spiral::US12::US12_1(sprintf!(
                        "No parent for {} \'{}\' at \'{}\' (until \'{}\')",
                        string("dir"),
                        v0_1.clone(),
                        v1_1.clone(),
                        v1_1.clone()
                    )),
                }
            }
        }
        pub fn method33() -> string {
            let v6: string = Spiral::method13(getCharAt(toLower(string("Warning")), 0_i32));
            let v9: &str = inline_colorization::color_yellow;
            let v12: &str = &*v6;
            let v35: &str = inline_colorization::color_reset;
            let v37: std::string::String = format!("{}{}{}", v9, v12, v35);
            fable_library_rust::String_::fromString(v37)
        }
        pub fn method35(v0_1: string) -> string {
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
        pub fn method34(
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
            let v9: string = Spiral::method35(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.get_workspace_root"),
                v9
            ))
        }
        pub fn closure15(v0_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method34(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method33(),
                    v0_1,
                ))
            };
        }
        pub fn method36() -> string {
            let v2: Result<std::path::PathBuf, std::io::Error> = std::env::current_dir();
            let v5: std::path::PathBuf = v2.unwrap();
            let v19: std::path::Display = v5.display();
            let v43: std::string::String = format!("{}", v19);
            fable_library_rust::String_::fromString(v43)
        }
        pub fn method37() -> string {
            string("\n")
        }
        pub fn method40(v0_1: string) -> bool {
            let v4: &str = &*v0_1;
            let v28: std::string::String = String::from(v4);
            let v69: std::path::PathBuf = std::path::PathBuf::from(v28);
            if v69.clone().exists() {
                v69.is_file()
            } else {
                false
            }
        }
        pub fn method39(v0_1: string, v1_1: string) -> bool {
            if (Spiral::method40(v0_1.clone())) == false {
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
        pub fn closure16(unitVar: (), v0_1: std::io::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method42() -> Func1<std::io::Error, std::string::String> {
            Func1::new(move |v: std::io::Error| Spiral::closure16((), v))
        }
        pub fn closure17(unitVar: (), unitVar_1: ()) -> Spiral::US13 {
            Spiral::US13::US13_0
        }
        pub fn method43() -> Func0<Spiral::US13> {
            Func0::new(move || Spiral::closure17((), ()))
        }
        pub fn closure18(unitVar: (), v0_1: std::string::String) -> Spiral::US13 {
            Spiral::US13::US13_1(v0_1)
        }
        pub fn method44() -> Func1<std::string::String, Spiral::US13> {
            Func1::new(move |v: std::string::String| Spiral::closure18((), v))
        }
        pub fn method45() -> string {
            let v6: string = Spiral::method13(getCharAt(toLower(string("Critical")), 0_i32));
            let v9: &str = inline_colorization::color_bright_red;
            let v12: &str = &*v6;
            let v35: &str = inline_colorization::color_reset;
            let v37: std::string::String = format!("{}{}{}", v9, v12, v35);
            fable_library_rust::String_::fromString(v37)
        }
        pub fn method47(v0_1: string, v1_1: std::string::String) -> string {
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
        pub fn method46(
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
            let v10: string = Spiral::method47(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.create_dir"),
                v10
            ))
        }
        pub fn closure19(v0_1: string, v1_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method46(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method45(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method48() -> string {
            let v6: string = Spiral::method13(getCharAt(toLower(string("Verbose")), 0_i32));
            let v9: &str = inline_colorization::color_bright_black;
            let v12: &str = &*v6;
            let v35: &str = inline_colorization::color_reset;
            let v37: std::string::String = format!("{}{}{}", v9, v12, v35);
            fable_library_rust::String_::fromString(v37)
        }
        pub fn method50(v0_1: string) -> string {
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
        pub fn method49(
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
            let v9: string = Spiral::method50(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.create_dir"),
                v9
            ))
        }
        pub fn closure20(v0_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method49(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method48(),
                    v0_1,
                ))
            };
        }
        pub fn method52(v0_1: bool, v1_1: string) {
            if Spiral::method30(v1_1.clone()) {
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
        pub fn closure21(v0_1: string, unitVar: ()) {
            Spiral::method52(true, v0_1);
        }
        pub fn method51(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure21(v0_1.clone(), ())
            })
        }
        pub fn method53(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure21(v0_1.clone(), ())
            })
        }
        pub fn method54(v0_1: string) -> bool {
            unbox::<bool>(&getZero())
        }
        pub fn method56(v0_1: string, v1_1: string) -> string {
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
        pub fn method55(
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
            let v10: string = Spiral::method56(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.create_dir"),
                v10
            ))
        }
        pub fn closure22(v0_1: string, v1_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method55(
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
        pub fn method61(v0_1: string) -> string {
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
        pub fn method63(v0_1: string, v1_1: string) -> string {
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
        pub fn method62(
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
            let v10: string = Spiral::method63(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.delete_directory_async"),
                v10
            ))
        }
        pub fn closure24(v0_1: string, v1_1: LrcPtr<Exception>, unitVar: ()) {
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
                Spiral::method19(Spiral::method62(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method12(),
                    sprintf!("{:?}", v1_1),
                    Spiral::method61(v0_1),
                ))
            };
        }
        pub fn method60(v0_1: string, v1_1: i64) -> Arc<Async<i64>> {
            getZero()
        }
        pub fn method59(v0_1: string, v1_1: i64) -> Arc<Async<i64>> {
            getZero()
        }
        pub fn method58(v0_1: string) -> Arc<Async<i64>> {
            Spiral::method59(v0_1, 0_i64)
        }
        pub fn closure23(v0_1: string, unitVar: ()) {
            let v1_1: Arc<Async<i64>> = Spiral::method58(v0_1);
            let v3: Arc<Async<()>> = getZero();
            getZero::<()>();
            ()
        }
        pub fn method57(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure23(v0_1.clone(), ())
            })
        }
        pub fn method64(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure23(v0_1.clone(), ())
            })
        }
        pub fn method41(v0_1: string) -> LrcPtr<dyn IDisposable> {
            let v3: Result<(), std::io::Error> = std::fs::create_dir_all(&*v0_1.clone());
            let v4 = Spiral::method42();
            let v16: Result<(), std::string::String> = v3.map_err(|x| v4(x));
            let v19 = Spiral::method43();
            let v20 = Spiral::method44();
            let v21: Spiral::US13 = match &v16 {
                Err(v16_1_0) => v20(v16_1_0.clone()),
                _ => v19(),
            };
            match &v21 {
                Spiral::US13::US13_0 => {
                    let v24: () = {
                        Spiral::closure20(v0_1.clone(), ());
                        ()
                    };
                    ()
                }
                Spiral::US13::US13_1(v21_1_0) => {
                    let v67: () = {
                        Spiral::closure19(
                            v0_1.clone(),
                            match &v21 {
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
                let v108 = Spiral::method51(v0_1.clone());
                interface_cast!(
                    Spiral::Disposable::_ctor__3A5B6456(Func0::new({
                        let v108 = v108.clone();
                        move || v108.clone()()
                    })),
                    Lrc<dyn IDisposable>,
                )
            }
        }
        pub fn method38(v0_1: string, v1_1: string) {
            if (Spiral::method39(v0_1.clone(), v1_1.clone())) == false {
                let v6: string = defaultValue(string(""), Spiral::method31(v0_1.clone()));
                if (Spiral::method30(v6.clone())) == false {
                    let v11: LrcPtr<dyn IDisposable> = Spiral::method41(v6);
                    ()
                }
                std::fs::write(&*v0_1, &*v1_1).unwrap();
                ()
            };
        }
        pub fn method66(
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
        pub fn method68() -> string {
            string("")
        }
        pub fn method69(v0_1: i32, v1_1: LrcPtr<Spiral::Mut5>) -> bool {
            (v1_1.l0.get().clone()) < (v0_1)
        }
        pub fn closure27(v0_1: char, v1_1: LrcPtr<Spiral::UH0>) -> LrcPtr<Spiral::UH0> {
            LrcPtr::new(Spiral::UH0::UH0_1(v0_1, v1_1))
        }
        pub fn closure26(
            unitVar: (),
            v0_1: char,
        ) -> Func1<LrcPtr<Spiral::UH0>, LrcPtr<Spiral::UH0>> {
            Func1::new({
                let v0_1 = v0_1.clone();
                move |v: LrcPtr<Spiral::UH0>| Spiral::closure27(v0_1, v)
            })
        }
        pub fn method70() -> Func1<char, Func1<LrcPtr<Spiral::UH0>, LrcPtr<Spiral::UH0>>> {
            Func1::new(move |v: char| Spiral::closure26((), v))
        }
        pub fn method71(
            v0_1: LrcPtr<Spiral::UH0>,
            v1_1: LrcPtr<StringBuilder>,
            v2: i32,
            v3: i32,
        ) -> (LrcPtr<StringBuilder>, i32, i32) {
            let v0_1: MutCell<LrcPtr<Spiral::UH0>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<i32> = MutCell::new(v2);
            let v3: MutCell<i32> = MutCell::new(v3);
            '_method71: loop {
                break '_method71 (match v0_1.get().clone().as_ref() {
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
                            continue '_method71;
                        }
                    }
                });
            }
        }
        pub fn closure28(v0_1: i32, v1_1: i32, v2: string) -> string {
            if (v1_1) >= (v0_1) {
                v2.clone()
            } else {
                (Spiral::method72(v0_1, (v1_1) + 1_i32))(append((v2), string(" ")))
            }
        }
        pub fn method72(v0_1: i32, v1_1: i32) -> Func1<string, string> {
            Func1::new({
                let v0_1 = v0_1.clone();
                let v1_1 = v1_1.clone();
                move |v: string| Spiral::closure28(v0_1, v1_1, v)
            })
        }
        pub fn closure25(
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
                    while Spiral::method69(v38, v40.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method71(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method70())(b0)(b1)
                                }),
                                v45,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v9,
                            v30,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v83: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                            ((Spiral::method72((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            }
        }
        pub fn closure29(
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
                    while Spiral::method69(v38, v40.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method71(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method70())(b0)(b1)
                                }),
                                v45,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v9,
                            v30,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v83: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                            ((Spiral::method72((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            }
        }
        pub fn method73(
            v0_1: string,
            v1_1: LrcPtr<StringBuilder>,
            v2: LrcPtr<Spiral::UH1>,
        ) -> Spiral::US15 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<Spiral::UH1>> = MutCell::new(v2.clone());
            '_method73: loop {
                break '_method73 (match v2.get().clone().as_ref() {
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
                                continue '_method73;
                            }
                        }
                    }
                });
            }
        }
        pub fn method74(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method74: loop {
                break '_method74 (if (v1_1.get().clone()) >= 2_i64 {
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
                        continue '_method74;
                    }
                });
            }
        }
        pub fn method75(
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
            '_method75: loop {
                break '_method75 ({
                    let v109: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v21: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method74(v21, 0_i64)) == false {
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
                            while Spiral::method69(v52, v54.clone()) {
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
                                    Spiral::method71(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method70())(b0)(b1)
                                            }),
                                            v59,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v21,
                                    v44,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v21,
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v121: Spiral::US15 = match &v109 {
                        Spiral::US15::US15_0(v109_0_0, v109_0_1, v109_0_2, v109_0_3, v109_0_4) => {
                            let v110: char = v109_0_0.clone();
                            Spiral::US15::US15_0(
                                if '\\' == (v110) { '/' } else { v110 },
                                v109_0_1.clone(),
                                v109_0_2.clone(),
                                v109_0_3.clone(),
                                v109_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v109_1_0) => Spiral::US15::US15_1(v109_1_0.clone()),
                    };
                    match &v121 {
                        Spiral::US15::US15_0(v121_0_0, v121_0_1, v121_0_2, v121_0_3, v121_0_4) => {
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
                            continue '_method75;
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
        pub fn method76(
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
            '_method76: loop {
                break '_method76 (match v4.get().clone().as_ref() {
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
                                continue '_method76;
                            }
                        }
                    }
                });
            }
        }
        pub fn method77(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method77: loop {
                break '_method77 (if (v1_1.get().clone()) >= 3_i64 {
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
                        continue '_method77;
                    }
                });
            }
        }
        pub fn method78(
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
            '_method78: loop {
                break '_method78 ({
                    let v115: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v24: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method77(v24, 0_i64)) == false {
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
                            while Spiral::method69(v55, v57.clone()) {
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
                                    Spiral::method71(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method70())(b0)(b1)
                                            }),
                                            v62,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v24,
                                    v47,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v24,
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v127: Spiral::US15 = match &v115 {
                        Spiral::US15::US15_0(v115_0_0, v115_0_1, v115_0_2, v115_0_3, v115_0_4) => {
                            let v116: char = v115_0_0.clone();
                            Spiral::US15::US15_0(
                                if '\\' == (v116) { '/' } else { v116 },
                                v115_0_1.clone(),
                                v115_0_2.clone(),
                                v115_0_3.clone(),
                                v115_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v115_1_0) => Spiral::US15::US15_1(v115_1_0.clone()),
                    };
                    match &v127 {
                        Spiral::US15::US15_0(v127_0_0, v127_0_1, v127_0_2, v127_0_3, v127_0_4) => {
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
                            continue '_method78;
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
        pub fn method79(v0_1: string, v1_1: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<i32> = MutCell::new(v1_1);
            '_method79: loop {
                break '_method79 (if (v1_1.get().clone()) >= (length(v0_1.get().clone())) {
                    v1_1.get().clone()
                } else {
                    if ' ' == (getCharAt(v0_1.get().clone(), v1_1.get().clone())) {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_1_temp: i32 = (v1_1.get().clone()) + 1_i32;
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        continue '_method79;
                    } else {
                        v1_1.get().clone()
                    }
                });
            }
        }
        pub fn method80(
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
            '_method80: loop {
                break '_method80 ({
                    let v79: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
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
                        while Spiral::method69(v38, v40.clone()) {
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
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method71(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                        (Spiral::method70())(b0)(b1)
                                    }),
                                    v45,
                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                ),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Spiral::US15::US15_0(
                                v10,
                                v30,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        }
                    };
                    match &v79 {
                        Spiral::US15::US15_0(v79_0_0, v79_0_1, v79_0_2, v79_0_3, v79_0_4) => {
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
                            continue '_method80;
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
        pub fn method67(v0_1: string) -> Spiral::US14 {
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
                    StringBuilder::_ctor__Z721C83C5(Spiral::method68());
                fn v15(arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)) -> Spiral::US15 {
                    Spiral::closure25((), arg10_0040)
                }
                fn v16(arg10_0040_1: (string, LrcPtr<StringBuilder>, i32, i32)) -> Spiral::US15 {
                    Spiral::closure29((), arg10_0040_1)
                }
                let v20: Spiral::US15 = Spiral::method73(
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
                let v202: Spiral::US16 = match &v20 {
                    Spiral::US15::US15_0(v20_0_0, v20_0_1, v20_0_2, v20_0_3, v20_0_4) => {
                        let v25: i32 = v20_0_4.clone();
                        let v24: i32 = v20_0_3.clone();
                        let v23: LrcPtr<StringBuilder> = v20_0_2.clone();
                        let v22: string = v20_0_1.clone();
                        let v130: Spiral::US15 = if string("") == (v22.clone()) {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v23.clone(), v24, v25)
                            ))
                        } else {
                            let v42: char = getCharAt(v22.clone(), 0_i32);
                            if (Spiral::method74(v42, 0_i64)) == false {
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
                                while Spiral::method69(v73, v75.clone()) {
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
                                        Spiral::method71(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method70())(b0)(b1)
                                                    },
                                                ),
                                                v80,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v23.clone(),
                                            v24,
                                            v25,
                                        );
                                    Spiral::US15::US15_0(
                                        v42,
                                        v65,
                                        patternInput.0.clone(),
                                        patternInput.1.clone(),
                                        patternInput.2.clone(),
                                    )
                                }
                            } else {
                                Spiral::US15::US15_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v42,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'']))),
                                                                      (v23.clone(),
                                                                       v24,
                                                                       v25)))
                            }
                        };
                        let v142: Spiral::US15 = match &v130 {
                            Spiral::US15::US15_0(
                                v130_0_0,
                                v130_0_1,
                                v130_0_2,
                                v130_0_3,
                                v130_0_4,
                            ) => {
                                let v131: char = v130_0_0.clone();
                                Spiral::US15::US15_0(
                                    if '\\' == (v131) { '/' } else { v131 },
                                    v130_0_1.clone(),
                                    v130_0_2.clone(),
                                    v130_0_3.clone(),
                                    v130_0_4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v130_1_0) => {
                                Spiral::US15::US15_1(v130_1_0.clone())
                            }
                        };
                        let v161: Spiral::US16 = match &v142 {
                            Spiral::US15::US15_0(
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
                                ) = Spiral::method75(
                                    ofChar(v142_0_0.clone()),
                                    v142_0_1.clone(),
                                    v142_0_2.clone(),
                                    v142_0_3.clone(),
                                    v142_0_4.clone(),
                                );
                                Spiral::US16::US16_0(
                                    patternInput_1.0.clone(),
                                    patternInput_1.1.clone(),
                                    patternInput_1.2.clone(),
                                    patternInput_1.3.clone(),
                                    patternInput_1.4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v142_1_0) => {
                                Spiral::US16::US16_1(v142_1_0.clone())
                            }
                        };
                        let v171: Spiral::US16 = match &v161 {
                            Spiral::US16::US16_0(
                                v161_0_0,
                                v161_0_1,
                                v161_0_2,
                                v161_0_3,
                                v161_0_4,
                            ) => Spiral::US16::US16_0(
                                v161_0_0.clone(),
                                v161_0_1.clone(),
                                v161_0_2.clone(),
                                v161_0_3.clone(),
                                v161_0_4.clone(),
                            ),
                            _ => {
                                Spiral::US16::US16_0(string(""), v22.clone(), v23.clone(), v24, v25)
                            }
                        };
                        match &v171 {
                            Spiral::US16::US16_0(
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
                                let v180: Spiral::US15 = Spiral::method76(
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
                                        Spiral::US15::US15_0(v180_0_0,
                                                             v180_0_1,
                                                             v180_0_2,
                                                             v180_0_3,
                                                             v180_0_4) =>
                                        Spiral::US16::US16_0(v171_0_0.clone(),
                                                             v180_0_1.clone(),
                                                             v180_0_2.clone(),
                                                             v180_0_3.clone(),
                                                             v180_0_4.clone()),
                                        Spiral::US15::US15_1(v180_1_0) =>
                                        Spiral::US16::US16_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
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
                            _ => Spiral::US16::US16_1(string("parsing.between / expected content")),
                        }
                    }
                    Spiral::US15::US15_1(v20_1_0) => Spiral::US16::US16_1(v20_1_0.clone()),
                };
                let v414: Spiral::US16 = match &v202 {
                    Spiral::US16::US16_0(v202_0_0, v202_0_1, v202_0_2, v202_0_3, v202_0_4) => {
                        v202.clone()
                    }
                    _ => {
                        let v321: Spiral::US15 = if string("") == (v7.clone()) {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v12.clone(), 1_i32, 1_i32)
                            ))
                        } else {
                            let v228: char = getCharAt(v7.clone(), 0_i32);
                            if (Spiral::method77(v228, 0_i64)) == false {
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
                                while Spiral::method69(v259, v261.clone()) {
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
                                        Spiral::method71(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method70())(b0)(b1)
                                                    },
                                                ),
                                                v266,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v12.clone(),
                                            1_i32,
                                            1_i32,
                                        );
                                    Spiral::US15::US15_0(
                                        v228,
                                        v251,
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                        patternInput_2.2.clone(),
                                    )
                                }
                            } else {
                                Spiral::US15::US15_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v228,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'',
                                                                                                  ' ']))),
                                                                      (v12.clone(),
                                                                       1_i32,
                                                                       1_i32)))
                            }
                        };
                        let v333: Spiral::US15 = match &v321 {
                            Spiral::US15::US15_0(
                                v321_0_0,
                                v321_0_1,
                                v321_0_2,
                                v321_0_3,
                                v321_0_4,
                            ) => {
                                let v322: char = v321_0_0.clone();
                                Spiral::US15::US15_0(
                                    if '\\' == (v322) { '/' } else { v322 },
                                    v321_0_1.clone(),
                                    v321_0_2.clone(),
                                    v321_0_3.clone(),
                                    v321_0_4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v321_1_0) => {
                                Spiral::US15::US15_1(v321_1_0.clone())
                            }
                        };
                        let v352: Spiral::US16 = match &v333 {
                            Spiral::US15::US15_0(
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
                                ) = Spiral::method78(
                                    ofChar(v333_0_0.clone()),
                                    v333_0_1.clone(),
                                    v333_0_2.clone(),
                                    v333_0_3.clone(),
                                    v333_0_4.clone(),
                                );
                                Spiral::US16::US16_0(
                                    patternInput_3.0.clone(),
                                    patternInput_3.1.clone(),
                                    patternInput_3.2.clone(),
                                    patternInput_3.3.clone(),
                                    patternInput_3.4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v333_1_0) => {
                                Spiral::US16::US16_1(v333_1_0.clone())
                            }
                        };
                        match &v352 {
                            Spiral::US16::US16_0(
                                v352_0_0,
                                v352_0_1,
                                v352_0_2,
                                v352_0_3,
                                v352_0_4,
                            ) => v352.clone(),
                            _ => {
                                let v366: Spiral::US18 = if (length(v7.clone())) == 0_i32 {
                                    Spiral::US18::US18_0(v7.clone(), v12.clone(), 1_i32, 1_i32)
                                } else {
                                    Spiral::US18::US18_1(sprintf!(
                                        "parsing.eof / expected end of input / input: {:?}",
                                        v7.clone()
                                    ))
                                };
                                let v375: Spiral::US16 = match &v366 {
                                    Spiral::US18::US18_0(
                                        v366_0_0,
                                        v366_0_1,
                                        v366_0_2,
                                        v366_0_3,
                                    ) => Spiral::US16::US16_0(
                                        string(""),
                                        v366_0_0.clone(),
                                        v366_0_1.clone(),
                                        v366_0_2.clone(),
                                        v366_0_3.clone(),
                                    ),
                                    Spiral::US18::US18_1(v366_1_0) => {
                                        Spiral::US16::US16_1(v366_1_0.clone())
                                    }
                                };
                                match &v375 {
                                    Spiral::US16::US16_0(
                                        v375_0_0,
                                        v375_0_1,
                                        v375_0_2,
                                        v375_0_3,
                                        v375_0_4,
                                    ) => {
                                        let v377: string = v375_0_1.clone();
                                        Spiral::US16::US16_0(
                                            v375_0_0.clone(),
                                            getSlice(
                                                v377.clone(),
                                                Some(Spiral::method79(v377.clone(), 0_i32)),
                                                Some((length(v377)) - 1_i32),
                                            ),
                                            v375_0_2.clone(),
                                            v375_0_3.clone(),
                                            v375_0_4.clone(),
                                        )
                                    }
                                    Spiral::US16::US16_1(v375_1_0) => {
                                        Spiral::US16::US16_1(v375_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                let v682: Spiral::US19 = match &v414 {
                    Spiral::US16::US16_0(v414_0_0, v414_0_1, v414_0_2, v414_0_3, v414_0_4) => {
                        let v419: i32 = v414_0_4.clone();
                        let v418: i32 = v414_0_3.clone();
                        let v417: LrcPtr<StringBuilder> = v414_0_2.clone();
                        let v416: string = v414_0_1.clone();
                        let v541: Spiral::US15 = if string("") == (v416.clone()) {
                            Spiral::US15::US15_1(sprintf!(
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
                                while Spiral::method69(v454, v456.clone()) {
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
                                        Spiral::method71(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method70())(b0)(b1)
                                                    },
                                                ),
                                                v461,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v417.clone(),
                                            v418,
                                            v419,
                                        );
                                    Spiral::US15::US15_0(
                                        v425,
                                        v446,
                                        patternInput_4.0.clone(),
                                        patternInput_4.1.clone(),
                                        patternInput_4.2.clone(),
                                    )
                                }
                            } else {
                                let v499: i32 = (indexOf(v416.clone(), string("\n"))) - 1_i32;
                                Spiral::US15::US15_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
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
                                                                                append(((Spiral::method72((v419)
                                                                                                              -
                                                                                                              1_i32,
                                                                                                          0_i32))(string(""))),
                                                                                       string("^")),
                                                                                string("\n")])))
                            }
                        };
                        let v553: Spiral::US20 = match &v541 {
                            Spiral::US15::US15_0(
                                v541_0_0,
                                v541_0_1,
                                v541_0_2,
                                v541_0_3,
                                v541_0_4,
                            ) => Spiral::US20::US20_0(
                                Spiral::US17::US17_0(v541_0_0.clone()),
                                v541_0_1.clone(),
                                v541_0_2.clone(),
                                v541_0_3.clone(),
                                v541_0_4.clone(),
                            ),
                            _ => Spiral::US20::US20_0(
                                Spiral::US17::US17_1,
                                v416.clone(),
                                v417.clone(),
                                v418,
                                v419,
                            ),
                        };
                        let v656: Spiral::US16 = match &v553 {
                            Spiral::US20::US20_0(
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
                                let v633: Spiral::US15 = if string("") == (v555.clone()) {
                                    Spiral::US15::US15_1(sprintf!(
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
                                    while Spiral::method69(v592, v594.clone()) {
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
                                            Spiral::method71(
                                                foldBack(
                                                    Func2::new(
                                                        move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                            (Spiral::method70())(b0)(b1)
                                                        },
                                                    ),
                                                    v599,
                                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                                ),
                                                v556,
                                                v557,
                                                v558,
                                            );
                                        Spiral::US15::US15_0(
                                            v564,
                                            v584,
                                            patternInput_5.0.clone(),
                                            patternInput_5.1.clone(),
                                            patternInput_5.2.clone(),
                                        )
                                    }
                                };
                                match &v633 {
                                    Spiral::US15::US15_0(
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
                                        ) = Spiral::method80(
                                            ofChar(v633_0_0.clone()),
                                            v633_0_1.clone(),
                                            v633_0_2.clone(),
                                            v633_0_3.clone(),
                                            v633_0_4.clone(),
                                        );
                                        Spiral::US16::US16_0(
                                            patternInput_6.0.clone(),
                                            patternInput_6.1.clone(),
                                            patternInput_6.2.clone(),
                                            patternInput_6.3.clone(),
                                            patternInput_6.4.clone(),
                                        )
                                    }
                                    Spiral::US15::US15_1(v633_1_0) => {
                                        Spiral::US16::US16_1(v633_1_0.clone())
                                    }
                                }
                            }
                            Spiral::US20::US20_1(v553_1_0) => {
                                Spiral::US16::US16_1(v553_1_0.clone())
                            }
                        };
                        let v668: Spiral::US21 = match &v656 {
                            Spiral::US16::US16_0(
                                v656_0_0,
                                v656_0_1,
                                v656_0_2,
                                v656_0_3,
                                v656_0_4,
                            ) => Spiral::US21::US21_0(
                                Spiral::US5::US5_0(v656_0_0.clone()),
                                v656_0_1.clone(),
                                v656_0_2.clone(),
                                v656_0_3.clone(),
                                v656_0_4.clone(),
                            ),
                            _ => Spiral::US21::US21_0(
                                Spiral::US5::US5_1,
                                v416.clone(),
                                v417.clone(),
                                v418,
                                v419,
                            ),
                        };
                        match &v668 {
                            Spiral::US21::US21_0(
                                v668_0_0,
                                v668_0_1,
                                v668_0_2,
                                v668_0_3,
                                v668_0_4,
                            ) => Spiral::US19::US19_0(
                                v414_0_0.clone(),
                                v668_0_0.clone(),
                                v668_0_1.clone(),
                                v668_0_2.clone(),
                                v668_0_3.clone(),
                                v668_0_4.clone(),
                            ),
                            Spiral::US21::US21_1(v668_1_0) => {
                                Spiral::US19::US19_1(v668_1_0.clone())
                            }
                        }
                    }
                    Spiral::US16::US16_1(v414_1_0) => Spiral::US19::US19_1(v414_1_0.clone()),
                };
                match &v682 {
                    Spiral::US19::US19_0(
                        v682_0_0,
                        v682_0_1,
                        v682_0_2,
                        v682_0_3,
                        v682_0_4,
                        v682_0_5,
                    ) => Spiral::US14::US14_0(v682_0_0.clone(), v682_0_1.clone()),
                    Spiral::US19::US19_1(v682_1_0) => Spiral::US14::US14_1(v682_1_0.clone()),
                }
            }
        }
        pub fn method83(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method83: loop {
                break '_method83 (if (v1_1.get().clone()) >= 4_i64 {
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
                        continue '_method83;
                    }
                });
            }
        }
        pub fn method84(
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
            '_method84: loop {
                break '_method84 ({
                    let v121: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v27: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method83(v27, 0_i64)) == false {
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
                            while Spiral::method69(v58, v60.clone()) {
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
                                    Spiral::method71(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method70())(b0)(b1)
                                            }),
                                            v65,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v27,
                                    v50,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v27,
                                toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    match &v121 {
                        Spiral::US15::US15_0(v121_0_0, v121_0_1, v121_0_2, v121_0_3, v121_0_4) => {
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
                            continue '_method84;
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
        pub fn method86(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method86: loop {
                break '_method86 (if (v1_1.get().clone()) >= 3_i64 {
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
                        continue '_method86;
                    }
                });
            }
        }
        pub fn closure30(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US16 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            let v126: Spiral::US15 = if string("") == (v0_1.clone()) {
                Spiral::US15::US15_1(sprintf!(
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
                    while Spiral::method69(v38, v40.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method71(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method70())(b0)(b1)
                                }),
                                v45,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v9,
                            v30,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v83: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                            ((Spiral::method72((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            };
            let v210: Spiral::US15 = match &v126 {
                Spiral::US15::US15_0(v126_0_0, v126_0_1, v126_0_2, v126_0_3, v126_0_4) => {
                    let v131: i32 = v126_0_4.clone();
                    let v130: i32 = v126_0_3.clone();
                    let v129: LrcPtr<StringBuilder> = v126_0_2.clone();
                    let v128: string = v126_0_1.clone();
                    if string("") == (v128.clone()) {
                        Spiral::US15::US15_1(sprintf!(
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
                        while Spiral::method69(v165, v167.clone()) {
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
                                Spiral::method71(
                                    foldBack(
                                        Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                            (Spiral::method70())(b0)(b1)
                                        }),
                                        v172,
                                        LrcPtr::new(Spiral::UH0::UH0_0),
                                    ),
                                    v129,
                                    v130,
                                    v131,
                                );
                            Spiral::US15::US15_0(
                                v137,
                                v157,
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                            )
                        }
                    }
                }
                Spiral::US15::US15_1(v126_1_0) => Spiral::US15::US15_1(v126_1_0.clone()),
            };
            match &v210 {
                Spiral::US15::US15_0(v210_0_0, v210_0_1, v210_0_2, v210_0_3, v210_0_4) => {
                    Spiral::US16::US16_0(
                        append((ofChar('\\')), (ofChar(v210_0_0.clone()))),
                        v210_0_1.clone(),
                        v210_0_2.clone(),
                        v210_0_3.clone(),
                        v210_0_4.clone(),
                    )
                }
                Spiral::US15::US15_1(v210_1_0) => Spiral::US16::US16_1(v210_1_0.clone()),
            }
        }
        pub fn closure31(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US16 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            let v126: Spiral::US15 = if string("") == (v0_1.clone()) {
                Spiral::US15::US15_1(sprintf!(
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
                    while Spiral::method69(v38, v40.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method71(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method70())(b0)(b1)
                                }),
                                v45,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v9,
                            v30,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v83: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                            ((Spiral::method72((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            };
            let v210: Spiral::US15 = match &v126 {
                Spiral::US15::US15_0(v126_0_0, v126_0_1, v126_0_2, v126_0_3, v126_0_4) => {
                    let v131: i32 = v126_0_4.clone();
                    let v130: i32 = v126_0_3.clone();
                    let v129: LrcPtr<StringBuilder> = v126_0_2.clone();
                    let v128: string = v126_0_1.clone();
                    if string("") == (v128.clone()) {
                        Spiral::US15::US15_1(sprintf!(
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
                        while Spiral::method69(v165, v167.clone()) {
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
                                Spiral::method71(
                                    foldBack(
                                        Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                            (Spiral::method70())(b0)(b1)
                                        }),
                                        v172,
                                        LrcPtr::new(Spiral::UH0::UH0_0),
                                    ),
                                    v129,
                                    v130,
                                    v131,
                                );
                            Spiral::US15::US15_0(
                                v137,
                                v157,
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                            )
                        }
                    }
                }
                Spiral::US15::US15_1(v126_1_0) => Spiral::US15::US15_1(v126_1_0.clone()),
            };
            match &v210 {
                Spiral::US15::US15_0(v210_0_0, v210_0_1, v210_0_2, v210_0_3, v210_0_4) => {
                    Spiral::US16::US16_0(
                        append((ofChar('`')), (ofChar(v210_0_0.clone()))),
                        v210_0_1.clone(),
                        v210_0_2.clone(),
                        v210_0_3.clone(),
                        v210_0_4.clone(),
                    )
                }
                Spiral::US15::US15_1(v210_1_0) => Spiral::US16::US16_1(v210_1_0.clone()),
            }
        }
        pub fn method87(
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
            '_method87: loop {
                break '_method87 (match v4.get().clone().as_ref() {
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
                                continue '_method87;
                            }
                        }
                    }
                });
            }
        }
        pub fn method88(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            let v0_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v1_1.clone());
            '_method88: loop {
                break '_method88 (match v0_1.get().clone().as_ref() {
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
                        continue '_method88;
                    }
                });
            }
        }
        pub fn method85(
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
            '_method85: loop {
                break '_method85 ({
                    let v115: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v24: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method86(v24, 0_i64)) == false {
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
                            while Spiral::method69(v55, v57.clone()) {
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
                                    Spiral::method71(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method70())(b0)(b1)
                                            }),
                                            v62,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v24,
                                    v47,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v24,
                                toArray(ofArray(new_array(&['\\', '`', '\"']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v129: Spiral::US16 = match &v115 {
                        Spiral::US15::US15_0(v115_0_0, v115_0_1, v115_0_2, v115_0_3, v115_0_4) => {
                            Spiral::US16::US16_0(
                                ofChar(v115_0_0.clone()),
                                v115_0_1.clone(),
                                v115_0_2.clone(),
                                v115_0_3.clone(),
                                v115_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v115_1_0) => Spiral::US16::US16_1(v115_1_0.clone()),
                    };
                    let v143: Spiral::US16 = match &v129 {
                        Spiral::US16::US16_0(v129_0_0, v129_0_1, v129_0_2, v129_0_3, v129_0_4) => {
                            v129.clone()
                        }
                        _ => Spiral::method87(
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                            LrcPtr::new(Spiral::UH3::UH3_1(
                                Func1::new(
                                    move |arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)| {
                                        Spiral::closure30((), arg10_0040)
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
                                            Spiral::closure31((), arg10_0040_1)
                                        },
                                    ),
                                    LrcPtr::new(Spiral::UH3::UH3_0),
                                )),
                            )),
                        ),
                    };
                    match &v143 {
                        Spiral::US16::US16_0(v143_0_0, v143_0_1, v143_0_2, v143_0_3, v143_0_4) => {
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
                            continue '_method85;
                        }
                        _ => Spiral::US23::US23_0(
                            Spiral::method88(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method89(v0_1: LrcPtr<Spiral::UH2>, v1_1: List<string>) -> List<string> {
            match v0_1.as_ref() {
                Spiral::UH2::UH2_0 => v1_1.clone(),
                Spiral::UH2::UH2_1(v0_1_1_0, v0_1_1_1) => cons(
                    match v0_1.as_ref() {
                        Spiral::UH2::UH2_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    Spiral::method89(
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
        pub fn method90(
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
            '_method90: loop {
                break '_method90 ({
                    let v115: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v24: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method86(v24, 0_i64)) == false {
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
                            while Spiral::method69(v55, v57.clone()) {
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
                                    Spiral::method71(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method70())(b0)(b1)
                                            }),
                                            v62,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v24,
                                    v47,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v24,
                                toArray(ofArray(new_array(&['\\', '`', '\"']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v129: Spiral::US16 = match &v115 {
                        Spiral::US15::US15_0(v115_0_0, v115_0_1, v115_0_2, v115_0_3, v115_0_4) => {
                            Spiral::US16::US16_0(
                                ofChar(v115_0_0.clone()),
                                v115_0_1.clone(),
                                v115_0_2.clone(),
                                v115_0_3.clone(),
                                v115_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v115_1_0) => Spiral::US16::US16_1(v115_1_0.clone()),
                    };
                    match &v129 {
                        Spiral::US16::US16_0(v129_0_0, v129_0_1, v129_0_2, v129_0_3, v129_0_4) => {
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
                            continue '_method90;
                        }
                        _ => Spiral::US23::US23_0(
                            Spiral::method88(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method82(
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
            '_method82: loop {
                break '_method82 ({
                    let v5: bool = string("") == (v1_1.get().clone());
                    let v121: Spiral::US15 = if v5 {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v27: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method83(v27, 0_i64)) == false {
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
                            while Spiral::method69(v58, v60.clone()) {
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
                                    Spiral::method71(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method70())(b0)(b1)
                                            }),
                                            v65,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v27,
                                    v50,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v27,
                                toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v140: Spiral::US16 = match &v121 {
                        Spiral::US15::US15_0(v121_0_0, v121_0_1, v121_0_2, v121_0_3, v121_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method84(
                                    ofChar(v121_0_0.clone()),
                                    v121_0_1.clone(),
                                    v121_0_2.clone(),
                                    v121_0_3.clone(),
                                    v121_0_4.clone(),
                                );
                            Spiral::US16::US16_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v121_1_0) => Spiral::US16::US16_1(v121_1_0.clone()),
                    };
                    let v517: Spiral::US16 = match &v140 {
                        Spiral::US16::US16_0(v140_0_0, v140_0_1, v140_0_2, v140_0_3, v140_0_4) => {
                            v140.clone()
                        }
                        _ => {
                            let v268: Spiral::US15 = if v5 {
                                Spiral::US15::US15_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
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
                                    while Spiral::method69(v180, v182.clone()) {
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
                                            Spiral::method71(
                                                foldBack(
                                                    Func2::new(
                                                        move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                            (Spiral::method70())(b0)(b1)
                                                        },
                                                    ),
                                                    v187,
                                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                                ),
                                                v2.get().clone(),
                                                v3.get().clone(),
                                                v4.get().clone(),
                                            );
                                        Spiral::US15::US15_0(
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
                                    Spiral::US15::US15_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
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
                                                                                             append(((Spiral::method72((v4.get().clone())
                                                                                                                           -
                                                                                                                           1_i32,
                                                                                                                       0_i32))(string(""))),
                                                                                                    string("^")),
                                                                                             string("\n")])))
                                }
                            };
                            let v452: Spiral::US16 = match &v268 {
                                Spiral::US15::US15_0(
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
                                    let v275: Spiral::US23 = Spiral::method85(
                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                        v270.clone(),
                                        v271.clone(),
                                        v272,
                                        v273,
                                    );
                                    let v302: Spiral::US16 = match &v275 {
                                        Spiral::US23::US23_0(
                                            v275_0_0,
                                            v275_0_1,
                                            v275_0_2,
                                            v275_0_3,
                                            v275_0_4,
                                        ) => {
                                            let v282: List<string> = Spiral::method89(
                                                v275_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US16::US16_0(
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
                                        Spiral::US23::US23_1(v275_1_0) => {
                                            Spiral::US16::US16_1(v275_1_0.clone())
                                        }
                                    };
                                    match &v302 {
                                        Spiral::US16::US16_0(
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
                                            let v430: Spiral::US15 = if string("") == (v304.clone())
                                            {
                                                Spiral::US15::US15_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
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
                                                    while Spiral::method69(v342, v344.clone()) {
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
                                                                                 Spiral::method71(foldBack(Func2::new(move
                                                                                                                          |b0:
                                                                                                                               char,
                                                                                                                           b1:
                                                                                                                               LrcPtr<Spiral::UH0>|
                                                                                                                          (Spiral::method70())(b0)(b1)),
                                                                                                           v349,
                                                                                                           LrcPtr::new(Spiral::UH0::UH0_0)),
                                                                                                  v305.clone(),
                                                                                                  v306,
                                                                                                  v307);
                                                        Spiral::US15::US15_0(
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
                                                    Spiral::US15::US15_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
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
                                                                                                                 append(((Spiral::method72((v307)
                                                                                                                                               -
                                                                                                                                               1_i32,
                                                                                                                                           0_i32))(string(""))),
                                                                                                                        string("^")),
                                                                                                                 string("\n")])))
                                                }
                                            };
                                            match &v430 {
                                                                 Spiral::US15::US15_0(v430_0_0,
                                                                                      v430_0_1,
                                                                                      v430_0_2,
                                                                                      v430_0_3,
                                                                                      v430_0_4)
                                                                 =>
                                                                 Spiral::US16::US16_0(v302_0_0.clone(),
                                                                                      v430_0_1.clone(),
                                                                                      v430_0_2.clone(),
                                                                                      v430_0_3.clone(),
                                                                                      v430_0_4.clone()),
                                                                 Spiral::US15::US15_1(v430_1_0)
                                                                 =>
                                                                 Spiral::US16::US16_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
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
                                        _ => Spiral::US16::US16_1(string(
                                            "parsing.between / expected content",
                                        )),
                                    }
                                }
                                Spiral::US15::US15_1(v268_1_0) => {
                                    Spiral::US16::US16_1(v268_1_0.clone())
                                }
                            };
                            match &v452 {
                                Spiral::US16::US16_0(
                                    v452_0_0,
                                    v452_0_1,
                                    v452_0_2,
                                    v452_0_3,
                                    v452_0_4,
                                ) => v452.clone(),
                                _ => {
                                    let v464: Spiral::US16 =
                                                     Spiral::method87(v1_1.get().clone(),
                                                                      v2.get().clone(),
                                                                      v3.get().clone(),
                                                                      v4.get().clone(),
                                                                      LrcPtr::new(Spiral::UH3::UH3_1(Func1::new(move
                                                                                                                    |arg10_0040:
                                                                                                                         (string,
                                                                                                                          LrcPtr<StringBuilder>,
                                                                                                                          i32,
                                                                                                                          i32)|
                                                                                                                    Spiral::closure30((),
                                                                                                                                      arg10_0040)),
                                                                                                     LrcPtr::new(Spiral::UH3::UH3_1(Func1::new(move
                                                                                                                                                   |arg10_0040_1:
                                                                                                                                                        (string,
                                                                                                                                                         LrcPtr<StringBuilder>,
                                                                                                                                                         i32,
                                                                                                                                                         i32)|
                                                                                                                                                   Spiral::closure31((),
                                                                                                                                                                     arg10_0040_1)),
                                                                                                                                    LrcPtr::new(Spiral::UH3::UH3_0))))));
                                    let v475: Spiral::US16 = match &v464 {
                                        Spiral::US16::US16_0(
                                            v464_0_0,
                                            v464_0_1,
                                            v464_0_2,
                                            v464_0_3,
                                            v464_0_4,
                                        ) => Spiral::US16::US16_0(
                                            string(""),
                                            v464_0_1.clone(),
                                            v464_0_2.clone(),
                                            v464_0_3.clone(),
                                            v464_0_4.clone(),
                                        ),
                                        Spiral::US16::US16_1(v464_1_0) => {
                                            Spiral::US16::US16_1(v464_1_0.clone())
                                        }
                                    };
                                    let v486: Spiral::US23 = match &v475 {
                                        Spiral::US16::US16_0(
                                            v475_0_0,
                                            v475_0_1,
                                            v475_0_2,
                                            v475_0_3,
                                            v475_0_4,
                                        ) => Spiral::method90(
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                            v475_0_1.clone(),
                                            v475_0_2.clone(),
                                            v475_0_3.clone(),
                                            v475_0_4.clone(),
                                        ),
                                        Spiral::US16::US16_1(v475_1_0) => {
                                            Spiral::US23::US23_1(v475_1_0.clone())
                                        }
                                    };
                                    match &v486 {
                                        Spiral::US23::US23_0(
                                            v486_0_0,
                                            v486_0_1,
                                            v486_0_2,
                                            v486_0_3,
                                            v486_0_4,
                                        ) => {
                                            let v493: List<string> = Spiral::method89(
                                                v486_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US16::US16_0(
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
                                        Spiral::US23::US23_1(v486_1_0) => {
                                            Spiral::US16::US16_1(v486_1_0.clone())
                                        }
                                    }
                                }
                            }
                        }
                    };
                    match &v517 {
                        Spiral::US16::US16_0(v517_0_0, v517_0_1, v517_0_2, v517_0_3, v517_0_4) => {
                            let v522: i32 = v517_0_4.clone();
                            let v521: i32 = v517_0_3.clone();
                            let v520: LrcPtr<StringBuilder> = v517_0_2.clone();
                            let v519: string = v517_0_1.clone();
                            let v518: string = v517_0_0.clone();
                            let v524: i32 = Spiral::method79(v519.clone(), 0_i32);
                            let v552: Spiral::US18 = if 0_i32 == (v524) {
                                Spiral::US18::US18_1(string(
                                    "parsing.spaces1 / expected at least one space",
                                ))
                            } else {
                                Spiral::US18::US18_0(
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
                                Spiral::US18::US18_0(v552_0_0, v552_0_1, v552_0_2, v552_0_3) => {
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
                                    continue '_method82;
                                }
                                _ => Spiral::US23::US23_0(
                                    Spiral::method88(
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
                        _ => Spiral::US23::US23_0(
                            Spiral::method88(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method81(v0_1: string) -> Spiral::US22 {
            let _v0: MutCell<Option<Option<string>>> = MutCell::new(None::<Option<string>>);
            _v0.set(Some(Some(v0_1)));
            {
                let v18: Spiral::US23 = Spiral::method82(
                    LrcPtr::new(Spiral::UH2::UH2_0),
                    defaultValue(
                        string(""),
                        match &_v0.get().clone() {
                            None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                            Some(_v0_0_0) => _v0_0_0.clone(),
                        },
                    ),
                    StringBuilder::_ctor__Z721C83C5(Spiral::method68()),
                    1_i32,
                    1_i32,
                );
                match &v18 {
                    Spiral::US23::US23_0(v18_0_0, v18_0_1, v18_0_2, v18_0_3, v18_0_4) => {
                        Spiral::US22::US22_0(toArray(Spiral::method89(
                            v18_0_0.clone(),
                            empty::<string>(),
                        )))
                    }
                    Spiral::US23::US23_1(v18_1_0) => Spiral::US22::US22_1(v18_1_0.clone()),
                }
            }
        }
        pub fn method92(
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
        pub fn method91(
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
            let v17: string = Spiral::method92(v8, v9, v10, v11, v12, v13, v14, v15, v16);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options"),
                v17
            ))
        }
        pub fn closure32(
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
                Spiral::method19(Spiral::method91(
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
        pub fn closure33(
            unitVar: (),
            v0_1: Option<std::process::Child>,
        ) -> Option<std::process::Child> {
            v0_1
        }
        pub fn method93() -> Func1<Option<std::process::Child>, Option<std::process::Child>> {
            Func1::new(move |v: Option<std::process::Child>| Spiral::closure33((), v))
        }
        pub fn closure34(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>,
        ) -> Spiral::US24 {
            Spiral::US24::US24_0(v0_1)
        }
        pub fn method94(
        ) -> Func1<std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>, Spiral::US24>
        {
            Func1::new(
                move |v: std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>| {
                    Spiral::closure34((), v)
                },
            )
        }
        pub fn closure35(unitVar: (), v0_1: std::string::String) -> Spiral::US24 {
            Spiral::US24::US24_1(v0_1)
        }
        pub fn method95() -> Func1<std::string::String, Spiral::US24> {
            Func1::new(move |v: std::string::String| Spiral::closure35((), v))
        }
        pub fn method97(v0_1: std::string::String) -> string {
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
        pub fn method96(
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
            let v9: string = Spiral::method97(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options / child error"),
                v9
            ))
        }
        pub fn closure36(v0_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method96(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method45(),
                    v0_1,
                ))
            };
        }
        pub fn method98(
            v0_1: std::sync::MutexGuard<Option<std::process::Child>>,
        ) -> std::sync::MutexGuard<Option<std::process::Child>> {
            v0_1
        }
        pub fn closure37(
            unitVar: (),
            v0_1: Option<std::process::ChildStdin>,
        ) -> Option<std::process::ChildStdin> {
            v0_1
        }
        pub fn method99(
        ) -> Func1<Option<std::process::ChildStdin>, Option<std::process::ChildStdin>> {
            Func1::new(move |v: Option<std::process::ChildStdin>| Spiral::closure37((), v))
        }
        pub fn closure38(
            unitVar: (),
            v0_1: std::sync::mpsc::Sender<std::string::String>,
        ) -> std::sync::mpsc::Sender<std::string::String> {
            v0_1
        }
        pub fn method100() -> Func1<
            std::sync::mpsc::Sender<std::string::String>,
            std::sync::mpsc::Sender<std::string::String>,
        > {
            Func1::new(move |v: std::sync::mpsc::Sender<std::string::String>| {
                Spiral::closure38((), v)
            })
        }
        pub fn method101() -> Func1<
            std::sync::mpsc::Sender<std::string::String>,
            std::sync::mpsc::Sender<std::string::String>,
        > {
            Func1::new(move |v: std::sync::mpsc::Sender<std::string::String>| {
                Spiral::closure38((), v)
            })
        }
        pub fn closure39(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
        ) -> std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>> {
            v0_1
        }
        pub fn method102() -> Func1<
            std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
            std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
        > {
            Func1::new(
                move |v: std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>| {
                    Spiral::closure39((), v)
                },
            )
        }
        pub fn closure40(unitVar: (), v0_1: std::string::String) -> Spiral::US26 {
            Spiral::US26::US26_0(v0_1)
        }
        pub fn method103() -> Func1<std::string::String, Spiral::US26> {
            Func1::new(move |v: std::string::String| Spiral::closure40((), v))
        }
        pub fn closure41(unitVar: (), v0_1: std::string::String) -> Spiral::US26 {
            Spiral::US26::US26_1(v0_1)
        }
        pub fn method104() -> Func1<std::string::String, Spiral::US26> {
            Func1::new(move |v: std::string::String| Spiral::closure41((), v))
        }
        pub fn method106(v0_1: bool, v1_1: std::string::String) -> string {
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
        pub fn method105(
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
            let v10: string = Spiral::method106(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.stdio_line"),
                v10
            ))
        }
        pub fn closure42(v0_1: bool, v1_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method105(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method45(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method108() -> string {
            let v1_1: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            v1_1.l0.get().clone()
        }
        pub fn method107(
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
            let v9: string = Spiral::method108();
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                v8,
                v9
            ))
        }
        pub fn closure43(v0_1: string, unitVar: ()) {
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
                    Spiral::method107(
                        v19.clone(),
                        v20.clone(),
                        v21.clone(),
                        v22.clone(),
                        v23.clone(),
                        v24.clone(),
                        Spiral::method8(v19, v20, v21, v22, v23, v24),
                        Spiral::method48(),
                        v0_1,
                    )
                })
            };
        }
        pub fn closure44(
            unitVar: (),
            v0_1: std::sync::mpsc::SendError<std::string::String>,
        ) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method109(
        ) -> Func1<std::sync::mpsc::SendError<std::string::String>, std::string::String> {
            Func1::new(move |v: std::sync::mpsc::SendError<std::string::String>| {
                Spiral::closure44((), v)
            })
        }
        pub fn method110(v0_1: Result<(), string>) -> Result<(), string> {
            v0_1
        }
        pub fn closure45(
            unitVar: (),
            v0_1: Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>,
        ) -> Spiral::US27 {
            Spiral::US27::US27_0(v0_1)
        }
        pub fn method111() -> Func1<
            Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>,
            Spiral::US27,
        > {
            Func1::new(
                move |v: Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>| {
                    Spiral::closure45((), v)
                },
            )
        }
        pub fn method112(
            v0_1: std::sync::MutexGuard<Option<std::process::ChildStdin>>,
        ) -> std::sync::MutexGuard<Option<std::process::ChildStdin>> {
            v0_1
        }
        pub fn closure46(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
        ) -> Spiral::US28 {
            Spiral::US28::US28_0(v0_1)
        }
        pub fn method113(
        ) -> Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, Spiral::US28>
        {
            Func1::new(
                move |v: std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>| {
                    Spiral::closure46((), v)
                },
            )
        }
        pub fn method114(
            v0_1: std::sync::MutexGuard<std::process::ChildStdin>,
        ) -> std::sync::MutexGuard<std::process::ChildStdin> {
            v0_1
        }
        pub fn closure47(unitVar: (), v0_1: std::process::Output) -> Spiral::US29 {
            Spiral::US29::US29_0(v0_1)
        }
        pub fn method115() -> Func1<std::process::Output, Spiral::US29> {
            Func1::new(move |v: std::process::Output| Spiral::closure47((), v))
        }
        pub fn closure48(unitVar: (), v0_1: std::string::String) -> Spiral::US29 {
            Spiral::US29::US29_1(v0_1)
        }
        pub fn method116() -> Func1<std::string::String, Spiral::US29> {
            Func1::new(move |v: std::string::String| Spiral::closure48((), v))
        }
        pub fn method117(
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
            let v9: string = Spiral::method97(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options / output error"),
                v9
            ))
        }
        pub fn closure49(v0_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method117(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method45(),
                    v0_1,
                ))
            };
        }
        pub fn closure50(unitVar: (), v0_1: i32) -> Spiral::US30 {
            Spiral::US30::US30_0(v0_1)
        }
        pub fn method118() -> Func1<i32, Spiral::US30> {
            Func1::new(move |v: i32| Spiral::closure50((), v))
        }
        pub fn method120(v0_1: i32, v1_1: i32) -> string {
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
        pub fn method119(
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
            let v10: string = Spiral::method120(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options / result"),
                v10
            ))
        }
        pub fn closure51(v0_1: i32, v1_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method119(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method48(),
                    v0_1,
                    length(v1_1),
                ))
            };
        }
        pub fn method124(
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
        pub fn method123(
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
            let v17: string = Spiral::method124(v8, v9, v10, v11, v12, v13, v14, v15, v16);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options_async"),
                v17
            ))
        }
        pub fn closure52(
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
                Spiral::method19(Spiral::method123(
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
        pub fn method125(
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
        pub fn method128(v0_1: bool) -> string {
            unbox::<string>(&getZero())
        }
        pub fn closure54(
            unitVar: (),
            v0_1: Func1<(i32, string, bool), Arc<Async<()>>>,
        ) -> Spiral::US31 {
            Spiral::US31::US31_0(v0_1)
        }
        pub fn method129() -> Func1<Func1<(i32, string, bool), Arc<Async<()>>>, Spiral::US31> {
            Func1::new(move |v: Func1<(i32, string, bool), Arc<Async<()>>>| {
                Spiral::closure54((), v)
            })
        }
        pub fn method130(v0_1: bool) -> i32 {
            unbox::<i32>(&getZero())
        }
        pub fn closure55(v0_1: string, unitVar: ()) {
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
                    Spiral::method107(
                        v19.clone(),
                        v20.clone(),
                        v21.clone(),
                        v22.clone(),
                        v23.clone(),
                        v24.clone(),
                        Spiral::method8(v19, v20, v21, v22, v23, v24),
                        Spiral::method48(),
                        v0_1,
                    )
                })
            };
        }
        pub fn method127(
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
        pub fn method126(
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
            Spiral::method127(v0_1, v1_1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
        }
        pub fn closure53(
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
                Spiral::method126(v0_1, v1_1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
            getZero::<()>();
            ()
        }
        pub fn closure56(unitVar: (), v0_1: CancellationToken) -> Spiral::US32 {
            Spiral::US32::US32_0(v0_1)
        }
        pub fn method131() -> Func1<CancellationToken, Spiral::US32> {
            Func1::new(move |v: CancellationToken| Spiral::closure56((), v))
        }
        pub fn method132(v0_1: CancellationToken) -> Arc<Async<CancellationToken>> {
            getZero()
        }
        pub fn method133(v0_1: bool) -> bool {
            unbox::<bool>(&getZero())
        }
        pub fn method134(v0_1: bool) {
            ();
        }
        pub fn closure57(v0_1: bool, unitVar: ()) {
            if (Spiral::method133(v0_1)) == false {
                Spiral::method134(v0_1);
            };
        }
        pub fn method137(v0_1: LrcPtr<TaskCanceledException>) -> string {
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
        pub fn method136(
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
            let v9: string = Spiral::method137(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options_async / WaitForExitAsync"),
                v9
            ))
        }
        pub fn closure58(v0_1: LrcPtr<TaskCanceledException>, unitVar: ()) {
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
                Spiral::method19(Spiral::method136(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method33(),
                    v0_1,
                ))
            };
        }
        pub fn method135(
            v0_1: bool,
            v1_1: LrcPtr<ConcurrentStack_1<string>>,
            v2: CancellationToken,
        ) -> Arc<Async<i32>> {
            getZero()
        }
        pub fn method139(v0_1: i32, v1_1: i32) -> string {
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
        pub fn method138(
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
            let v10: string = Spiral::method139(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options_async"),
                v10
            ))
        }
        pub fn closure59(v0_1: i32, v1_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method138(
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
        pub fn method122(
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
        pub fn method121(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> Arc<Async<(i32, string)>> {
            Spiral::method122(v0_1, v1_1, v2, v3, v4, v5, v6)
        }
        pub fn method65(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> (i32, string) {
            let v9: Spiral::US14 = Spiral::method67(Spiral::method66(
                v0_1.clone(),
                v1_1.clone(),
                v2.clone(),
                v3.clone(),
                v4.clone(),
                v5,
                v6.clone(),
            ));
            let patternInput: (string, Spiral::US5) = match &v9 {
                Spiral::US14::US14_0(v9_0_0, v9_0_1) => (v9_0_0.clone(), v9_0_1.clone()),
                Spiral::US14::US14_1(v9_1_0) => panic!(
                    "{}",
                    concat(new_array(&[
                        string("resultm.get / Result value was Error: "),
                        v9_1_0.clone()
                    ])),
                ),
            };
            let v21: Spiral::US5 = patternInput.1.clone();
            let v20: string = patternInput.0.clone();
            let v26: Spiral::US22 = Spiral::method81(match &v21 {
                Spiral::US5::US5_0(v21_0_0) => match &v21 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            });
            let v34: Array<string> = match &v26 {
                Spiral::US22::US22_0(v26_0_0) => v26_0_0.clone(),
                Spiral::US22::US22_1(v26_1_0) => panic!(
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
                Spiral::closure32(
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
                        let v225 = Spiral::method42();
                        let v228: Result<std::process::Child, std::string::String> =
                            v224.map_err(|x| v225(x));
                        let v240 = Spiral::method93();
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
                        let v257 = Spiral::method94();
                        let v258 = Spiral::method95();
                        let v260: Spiral::US24 = match v256 {
                            Ok(x) => v257(x),
                            Err(e) => v258(e),
                        };
                        let patternInput_3: (i32, Spiral::US7, Spiral::US25) = match &v260 {
                            Spiral::US24::US24_0(v260_0_0) => {
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
                                        Spiral::method98(v267.unwrap());
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
                                        Spiral::method98(v306.unwrap());
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
                                        Spiral::method98(v345.unwrap());
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
                                        (Spiral::method99())(Some(v374));
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
                                    (Spiral::method100())(v389.clone());
                                let v394: std::sync::Mutex<
                                    std::sync::mpsc::Sender<std::string::String>,
                                > = std::sync::Mutex::new(v392);
                                let v396: std::sync::Arc<
                                    std::sync::Mutex<std::sync::mpsc::Sender<std::string::String>>,
                                > = std::sync::Arc::new(v394);
                                let v398: std::sync::mpsc::Sender<std::string::String> =
                                    (Spiral::method101())(v389);
                                let v400: std::sync::Mutex<
                                    std::sync::mpsc::Sender<std::string::String>,
                                > = std::sync::Mutex::new(v398);
                                let v402: std::sync::Arc<
                                    std::sync::Mutex<std::sync::mpsc::Sender<std::string::String>>,
                                > = std::sync::Arc::new(v400);
                                let v404: std::sync::Arc<
                                    std::sync::mpsc::Receiver<std::string::String>,
                                > = (Spiral::method102())(patternInput_2.1.clone());
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
                                        let v423 = Spiral::method42();
                                        let v426: Result<std::string::String, std::string::String> =
                                            v420.map_err(|x| v423(x));
                                        let v438 = Spiral::method103();
                                        let v439 = Spiral::method104();
                                        let v441: Spiral::US26 = match v426 {
                                            Ok(x) => v438(x),
                                            Err(e) => v439(e),
                                        };
                                        let v636: std::string::String = match &v441 {
                                            Spiral::US26::US26_0(v441_0_0) => {
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
                                                        Spiral::closure43(v493.clone(), ());
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
                                            Spiral::US26::US26_1(v441_1_0) => {
                                                let v543: std::string::String = v441_1_0.clone();
                                                let v546: () = {
                                                    Spiral::closure42(v5, v543.clone(), ());
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
                                        let v659 = Spiral::method109();
                                        let v662: Result<(), std::string::String> =
                                            v658.map_err(|x| v659(x));
                                        let v675: _ = v662;
                                        let v677: bool = true;
                                        v675
                                    }); //;
                                    let v680: Result<(), string> =
                                        Spiral::method110(_iter_try_for_each.map_err(|x| x.into()));
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
                                        let v713 = Spiral::method42();
                                        let v716: Result<std::string::String, std::string::String> =
                                            v710.map_err(|x| v713(x));
                                        let v728 = Spiral::method103();
                                        let v729 = Spiral::method104();
                                        let v731: Spiral::US26 = match v716 {
                                            Ok(x) => v728(x),
                                            Err(e) => v729(e),
                                        };
                                        let v974: std::string::String = match &v731 {
                                            Spiral::US26::US26_0(v731_0_0) => {
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
                                                        Spiral::closure43(v783.clone(), ());
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
                                            Spiral::US26::US26_1(v731_1_0) => {
                                                let v881: std::string::String = v731_1_0.clone();
                                                let v884: () = {
                                                    Spiral::closure42(v5, v881.clone(), ());
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
                                        let v997 = Spiral::method109();
                                        let v1000: Result<(), std::string::String> =
                                            v996.map_err(|x| v997(x));
                                        let v1013: _ = v1000;
                                        let v1015: bool = true;
                                        v1013
                                    }); //;
                                    let v1018: Result<(), string> =
                                        Spiral::method110(_iter_try_for_each.map_err(|x| x.into()));
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
                                let v1048: Spiral::US27 = defaultValue(
                                    Spiral::US27::US27_1,
                                    map(Spiral::method111(), v4.clone()),
                                );
                                match &v1048 {
                                    Spiral::US27::US27_0(v1048_0_0) => {
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
                                        > = Spiral::method112(v1056.unwrap());
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
                                        let v1103: Spiral::US28 = defaultValue(
                                            Spiral::US28::US28_1,
                                            map(Spiral::method113(), v1089),
                                        );
                                        match &v1103 {
                                            Spiral::US28::US28_0(v1103_0_0) => {
                                                let v1107: std::sync::Arc<
                                                    std::sync::Mutex<std::process::ChildStdin>,
                                                > = match &v1103 {
                                                    Spiral::US28::US28_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone();
                                                (match &v1048 {
                                                    Spiral::US27::US27_0(x) => x.clone(),
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
                                                    > = Spiral::method114(v1111.unwrap());
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
                                        Spiral::method98(v1134.unwrap());
                                    let v1151: bool = true;
                                    let mut v1149 = v1149;
                                    let v1153: &mut Option<std::process::Child> = &mut v1149;
                                    let v1155: Option<std::process::Child> = Option::take(v1153);
                                    let v1157: std::process::Child = v1155.unwrap();
                                    let v1159: Result<std::process::Output, std::io::Error> =
                                        v1157.wait_with_output();
                                    let v1160 = Spiral::method42();
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
                                        let v1212 = Spiral::method115();
                                        let v1213 = Spiral::method116();
                                        let v1214: Spiral::US29 = match &v1172 {
                                            Err(v1172_1_0) => v1213(v1172_1_0.clone()),
                                            Ok(v1172_0_0) => v1212(v1172_0_0.clone()),
                                        };
                                        match &v1214 {
                                            Spiral::US29::US29_0(v1214_0_0) => {
                                                let v1217: std::process::ExitStatus =
                                                    v1214_0_0.clone().status;
                                                let v1219: Option<i32> = v1217.code();
                                                let v1233: Spiral::US30 = defaultValue(
                                                    Spiral::US30::US30_1,
                                                    map(Spiral::method118(), v1219),
                                                );
                                                match &v1233 {
                                                    Spiral::US30::US30_0(v1233_0_0) => (
                                                        match &v1233 {
                                                            Spiral::US30::US30_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        },
                                                        Spiral::US7::US7_1,
                                                        Spiral::US25::US25_0(v408.clone()),
                                                    ),
                                                    _ => {
                                                        let v1243:
                                                                                        &str =
                                                                                    &*string("runtime.execute_with_options / exit_code=None");
                                                        (
                                                            -1_i32,
                                                            Spiral::US7::US7_0(String::from(v1243)),
                                                            Spiral::US25::US25_0(v408.clone()),
                                                        )
                                                    }
                                                }
                                            }
                                            Spiral::US29::US29_1(v1214_1_0) => {
                                                let v1297: std::string::String = v1214_1_0.clone();
                                                let v1300: () = {
                                                    Spiral::closure49(v1297.clone(), ());
                                                    ()
                                                };
                                                (
                                                    -2_i32,
                                                    Spiral::US7::US7_0(v1297),
                                                    Spiral::US25::US25_1,
                                                )
                                            }
                                        }
                                    }
                                }
                            }
                            Spiral::US24::US24_1(v260_1_0) => {
                                let v1348: std::string::String = v260_1_0.clone();
                                let v1351: () = {
                                    Spiral::closure36(v1348.clone(), ());
                                    ()
                                };
                                (-1_i32, Spiral::US7::US7_0(v1348), Spiral::US25::US25_1)
                            }
                        };
                        let v1398: Spiral::US25 = patternInput_3.2.clone();
                        let v1397: Spiral::US7 = patternInput_3.1.clone();
                        let v1396: i32 = patternInput_3.0.clone();
                        let v1405: Option<
                            std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            >,
                        > = match &v1398 {
                            Spiral::US25::US25_0(v1398_0_0) => Some(
                                match &v1398 {
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
                            let v1450: string = join(Spiral::method37(), toArray_1(v1444));
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
                            Spiral::closure51(v1396, v1469.clone(), ());
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
        pub fn method141(v0_1: Spiral::US10, v1_1: i32, v2: string, v3: string) -> string {
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
        pub fn method140(
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
            let v12: string = Spiral::method141(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / env install error"),
                v12
            ))
        }
        pub fn closure60(v0_1: Spiral::US10, v1_1: string, v2: string, v3: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method140(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method45(),
                    v0_1,
                    v3,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure61(unitVar: (), v0_1: string) -> Spiral::US5 {
            Spiral::US5::US5_0(v0_1)
        }
        pub fn closure62(v0_1: string, unitVar: ()) -> string {
            let v5: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method37(), toArray_1(v5))
        }
        pub fn method143(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
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
        pub fn method142(
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
            let v12: string = Spiral::method143(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / Exception"),
                v12
            ))
        }
        pub fn closure64(
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
                Spiral::method19(Spiral::method142(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method45(),
                    v3,
                    v1_1,
                    v0_1,
                    v2,
                ))
            };
        }
        pub fn closure63(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure64(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method145(v0_1: i32, v1_1: string, v2: string, v3: string) -> string {
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
        pub fn method144(
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
            let v12: string = Spiral::method145(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / error"),
                v12
            ))
        }
        pub fn closure65(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method144(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method45(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method146(
            v0_1: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>>,
        ) -> Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>> {
            v0_1
        }
        pub fn closure66(
            v0_1: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>>,
            _arg: (string, string),
        ) -> LrcPtr<(std::string::String, std::string::String)> {
            let v3: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>> =
                Spiral::method146(v0_1);
            (move |x| v3(x))((_arg.0.clone(), _arg.1.clone()))
        }
        pub fn method147() -> string {
            string("fs-path")
        }
        pub fn method148() -> string {
            string("command")
        }
        pub fn method149() -> string {
            string("path")
        }
        pub fn method158(v0_1: std::io::Error) -> string {
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
        pub fn closure68(unitVar: (), v0_1: std::io::Error) -> string {
            Spiral::method158(v0_1)
        }
        pub fn method157() -> Func1<std::io::Error, string> {
            Func1::new(move |v: std::io::Error| Spiral::closure68((), v))
        }
        pub fn closure69(unitVar: (), v0_1: std::path::PathBuf) -> Spiral::US33 {
            Spiral::US33::US33_0(v0_1)
        }
        pub fn method159() -> Func1<std::path::PathBuf, Spiral::US33> {
            Func1::new(move |v: std::path::PathBuf| Spiral::closure69((), v))
        }
        pub fn closure70(unitVar: (), v0_1: string) -> Spiral::US33 {
            Spiral::US33::US33_1(v0_1)
        }
        pub fn method160() -> Func1<string, Spiral::US33> {
            Func1::new(move |v: string| Spiral::closure70((), v))
        }
        pub fn method163(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v8: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method162(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: string,
            v4: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v5: string = Spiral::method61(v4.clone());
            let v6: Option<string> = Spiral::method31(v4.clone());
            let v20: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
            let v24: string = Spiral::method163(v3);
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
                        let v75 = Spiral::method157();
                        let v87: Result<std::path::PathBuf, string> = v74.map_err(|x| v75(x));
                        let v90 = Spiral::method159();
                        let v91 = Spiral::method160();
                        let v92: Spiral::US33 = match &v87 {
                            Err(v87_1_0) => v91(v87_1_0.clone()),
                            Ok(v87_0_0) => v90(v87_0_0.clone()),
                        };
                        match &v92 {
                            Spiral::US33::US33_0(v92_0_0) => {
                                let v121: string = Spiral::method28(
                                    toString(v92_0_0.clone().display()),
                                    v5.clone(),
                                );
                                let v124: &str = &*v121;
                                let v148: std::string::String = String::from(v124);
                                let v172: std::path::PathBuf = std::path::PathBuf::from(v148);
                                Ok(v172)
                            }
                            Spiral::US33::US33_1(v92_1_0) => {
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
        pub fn method161(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v5: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v2.clone());
            let v6 = Spiral::method157();
            let v18: Result<std::path::PathBuf, string> = v5.map_err(|x| v6(x));
            let v21 = Spiral::method159();
            let v22 = Spiral::method160();
            let v23: Spiral::US33 = match &v18 {
                Err(v18_1_0) => v22(v18_1_0.clone()),
                Ok(v18_0_0) => v21(v18_0_0.clone()),
            };
            match &v23 {
                Spiral::US33::US33_0(v23_0_0) => Ok(v23_0_0.clone()),
                Spiral::US33::US33_1(v23_1_0) => Spiral::method162(
                    v0_1.clone(),
                    Func2::new({
                        let v0_1 = v0_1.clone();
                        move |b0: u8, b1: string| {
                            (Func1::new({
                                let v0_1 = v0_1.clone();
                                move |v: u8| Spiral::closure71(v0_1.clone(), v)
                            }))(b0)(b1)
                        }
                    }),
                    v1_1,
                    v23_1_0.clone(),
                    v2.clone(),
                ),
            }
        }
        pub fn closure72(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            Spiral::method161(v0_1, v1_1, v2)
        }
        pub fn closure71(
            v0_1: string,
            v1_1: u8,
        ) -> Func1<string, Result<std::path::PathBuf, std::io::Error>> {
            Func1::new({
                let v0_1 = v0_1.clone();
                let v1_1 = v1_1.clone();
                move |v: string| Spiral::closure72(v0_1.clone(), v1_1, v)
            })
        }
        pub fn method164(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v4: string = Spiral::method61(v0_1.clone());
            let v5: Option<string> = Spiral::method31(v0_1.clone());
            let v19: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
            let v23: string = Spiral::method163(v3);
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
                        let v74 = Spiral::method157();
                        let v86: Result<std::path::PathBuf, string> = v73.map_err(|x| v74(x));
                        let v89 = Spiral::method159();
                        let v90 = Spiral::method160();
                        let v91: Spiral::US33 = match &v86 {
                            Err(v86_1_0) => v90(v86_1_0.clone()),
                            Ok(v86_0_0) => v89(v86_0_0.clone()),
                        };
                        match &v91 {
                            Spiral::US33::US33_0(v91_0_0) => {
                                let v120: string = Spiral::method28(
                                    toString(v91_0_0.clone().display()),
                                    v4.clone(),
                                );
                                let v123: &str = &*v120;
                                let v147: std::string::String = String::from(v123);
                                let v171: std::path::PathBuf = std::path::PathBuf::from(v147);
                                Ok(v171)
                            }
                            Spiral::US33::US33_1(v91_1_0) => {
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
        pub fn method156(v0_1: string, v1_1: u8) -> Result<std::path::PathBuf, std::io::Error> {
            let v4: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v0_1.clone());
            let v5 = Spiral::method157();
            let v17: Result<std::path::PathBuf, string> = v4.map_err(|x| v5(x));
            let v20 = Spiral::method159();
            let v21 = Spiral::method160();
            let v22: Spiral::US33 = match &v17 {
                Err(v17_1_0) => v21(v17_1_0.clone()),
                Ok(v17_0_0) => v20(v17_0_0.clone()),
            };
            match &v22 {
                Spiral::US33::US33_0(v22_0_0) => Ok(v22_0_0.clone()),
                Spiral::US33::US33_1(v22_1_0) => Spiral::method164(
                    v0_1.clone(),
                    Func2::new({
                        let v0_1 = v0_1.clone();
                        move |b0: u8, b1: string| {
                            (Func1::new({
                                let v0_1 = v0_1.clone();
                                move |v: u8| Spiral::closure71(v0_1.clone(), v)
                            }))(b0)(b1)
                        }
                    }),
                    v1_1,
                    v22_1_0.clone(),
                ),
            }
        }
        pub fn method166(v0_1: bool) -> i32 {
            unbox::<i32>(&getZero())
        }
        pub fn method167() -> i32 {
            unbox::<i32>(&getZero())
        }
        pub fn method168(v0_1: i32, v1_1: i32) -> bool {
            unbox::<bool>(&getZero())
        }
        pub fn method170(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: std::io::Error,
            v4: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v5: string = Spiral::method61(v4.clone());
            let v6: Option<string> = Spiral::method31(v4.clone());
            let v20: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
            let v24: string = Spiral::method158(v3);
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
                        let v75 = Spiral::method157();
                        let v87: Result<std::path::PathBuf, string> = v74.map_err(|x| v75(x));
                        let v90 = Spiral::method159();
                        let v91 = Spiral::method160();
                        let v92: Spiral::US33 = match &v87 {
                            Err(v87_1_0) => v91(v87_1_0.clone()),
                            Ok(v87_0_0) => v90(v87_0_0.clone()),
                        };
                        match &v92 {
                            Spiral::US33::US33_0(v92_0_0) => {
                                let v121: string = Spiral::method28(
                                    toString(v92_0_0.clone().display()),
                                    v5.clone(),
                                );
                                let v124: &str = &*v121;
                                let v148: std::string::String = String::from(v124);
                                let v172: std::path::PathBuf = std::path::PathBuf::from(v148);
                                Ok(v172)
                            }
                            Spiral::US33::US33_1(v92_1_0) => {
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
        pub fn method169(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v30: i32 = Spiral::method166(unbox::<bool>(&getZero()));
            let v32: bool = Spiral::method168(Spiral::method167(), v30);
            if v32 {
                let v34: bool = unbox::<bool>(&getZero());
                let v86: std::path::PathBuf = getZero();
                Ok(v86)
            } else {
                let v107: string =
                    append(string("file_system.read_link / Fsharp / The file or directory is not a reparse point. / "),
                           sprintf!("path: {} / result: {} / path\': {} / n: {}",
                                    v0_1.clone(), v32, v2.clone(), v1_1));
                Spiral::method170(
                    v0_1.clone(),
                    Func2::new({
                        let v0_1 = v0_1.clone();
                        move |b0: u8, b1: string| {
                            (Func1::new({
                                let v0_1 = v0_1.clone();
                                move |v: u8| Spiral::closure73(v0_1.clone(), v)
                            }))(b0)(b1)
                        }
                    }),
                    v1_1,
                    std::io::Error::new(std::io::ErrorKind::Other, &*v107),
                    v2,
                )
            }
        }
        pub fn closure74(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            Spiral::method169(v0_1, v1_1, v2)
        }
        pub fn closure73(
            v0_1: string,
            v1_1: u8,
        ) -> Func1<string, Result<std::path::PathBuf, std::io::Error>> {
            Func1::new({
                let v0_1 = v0_1.clone();
                let v1_1 = v1_1.clone();
                move |v: string| Spiral::closure74(v0_1.clone(), v1_1, v)
            })
        }
        pub fn method171(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: std::io::Error,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v4: string = Spiral::method61(v0_1.clone());
            let v5: Option<string> = Spiral::method31(v0_1.clone());
            let v19: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
            let v23: string = Spiral::method158(v3);
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
                        let v74 = Spiral::method157();
                        let v86: Result<std::path::PathBuf, string> = v73.map_err(|x| v74(x));
                        let v89 = Spiral::method159();
                        let v90 = Spiral::method160();
                        let v91: Spiral::US33 = match &v86 {
                            Err(v86_1_0) => v90(v86_1_0.clone()),
                            Ok(v86_0_0) => v89(v86_0_0.clone()),
                        };
                        match &v91 {
                            Spiral::US33::US33_0(v91_0_0) => {
                                let v120: string = Spiral::method28(
                                    toString(v91_0_0.clone().display()),
                                    v4.clone(),
                                );
                                let v123: &str = &*v120;
                                let v147: std::string::String = String::from(v123);
                                let v171: std::path::PathBuf = std::path::PathBuf::from(v147);
                                Ok(v171)
                            }
                            Spiral::US33::US33_1(v91_1_0) => {
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
        pub fn method165(v0_1: string, v1_1: u8) -> Result<std::path::PathBuf, std::io::Error> {
            let v29: i32 = Spiral::method166(unbox::<bool>(&getZero()));
            let v31: bool = Spiral::method168(Spiral::method167(), v29);
            if v31 {
                let v33: bool = unbox::<bool>(&getZero());
                let v85: std::path::PathBuf = getZero();
                Ok(v85)
            } else {
                let v106: string =
                    append(string("file_system.read_link / Fsharp / The file or directory is not a reparse point. / "),
                           sprintf!("path: {} / result: {} / path\': {} / n: {}",
                                    v0_1.clone(), v31, v0_1.clone(), v1_1));
                Spiral::method171(
                    v0_1.clone(),
                    Func2::new({
                        let v0_1 = v0_1.clone();
                        move |b0: u8, b1: string| {
                            (Func1::new({
                                let v0_1 = v0_1.clone();
                                move |v: u8| Spiral::closure73(v0_1.clone(), v)
                            }))(b0)(b1)
                        }
                    }),
                    v1_1,
                    std::io::Error::new(std::io::ErrorKind::Other, &*v106),
                )
            }
        }
        pub fn method155(v0_1: string) -> Result<std::path::PathBuf, std::io::Error> {
            if Spiral::method30(v0_1.clone()) {
                std::fs::read_link(&*v0_1.clone())
            } else {
                Spiral::method156(v0_1, 0_u8)
            }
        }
        pub fn closure75(unitVar: (), v0_1: std::path::PathBuf) -> Spiral::US34 {
            Spiral::US34::US34_0(v0_1)
        }
        pub fn method172() -> Func1<std::path::PathBuf, Spiral::US34> {
            Func1::new(move |v: std::path::PathBuf| Spiral::closure75((), v))
        }
        pub fn method174(v0_1: string) -> string {
            v0_1
        }
        pub fn method173(v0_1: string, v1_1: string, v2: string) -> string {
            let v5: Result<regex::Regex, regex::Error> = regex::Regex::new(&v0_1);
            let v8: regex::Regex = v5.unwrap();
            let v20: string = Spiral::method174(v2);
            let v22: std::borrow::Cow<str> = v8.replace_all(&*v20, &*v1_1);
            let v24: std::string::String = String::from(v22);
            fable_library_rust::String_::fromString(v24)
        }
        pub fn method154(v0_1: string) -> string {
            if (v0_1.clone()) == string("") {
                string("")
            } else {
                let v3: Result<std::path::PathBuf, std::io::Error> =
                    Spiral::method155(v0_1.clone());
                let v6: Option<std::path::PathBuf> = v3.ok();
                let v31: Spiral::US34 =
                    defaultValue(Spiral::US34::US34_1, map(Spiral::method172(), v6));
                let v66: string = match &v31 {
                    Spiral::US34::US34_0(v31_0_0) => {
                        let v60: string = toString(
                            match &v31 {
                                Spiral::US34::US34_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone()
                            .display(),
                        );
                        if (v60.clone()) == string("") {
                            v0_1.clone()
                        } else {
                            v60
                        }
                    }
                    _ => v0_1.clone(),
                };
                if (v66.clone()) == string("") {
                    string("")
                } else {
                    let v71: string =
                        Spiral::method173(string("^\\\\\\\\\\?\\\\"), string(""), v66);
                    replace(
                        concat(new_array(&[
                            toLower(ofChar(getCharAt(v71.clone(), 0_i32))),
                            getSlice(v71, Some(1_i32), None::<i32>),
                        ])),
                        string("\\"),
                        string("/"),
                    )
                }
            }
        }
        pub fn method175(v0_1: i32, v1_1: LrcPtr<Spiral::Mut6>) -> bool {
            (v1_1.l0.get().clone()) < (v0_1)
        }
        pub fn method176() -> char {
            std::path::MAIN_SEPARATOR
        }
        pub fn method177(v0_1: string) -> string {
            v0_1
        }
        pub fn method153(v0_1: string) -> string {
            let v4: &str = &*v0_1.clone();
            let v28: std::string::String = String::from(v4);
            let v52: std::path::PathBuf = std::path::PathBuf::from(v28);
            if (v52.exists()) == false {
                let v77: string = Spiral::method36();
                let v81: Array<string> = split(
                    Spiral::method154(Spiral::method28(v77.clone(), v0_1.clone())),
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
                while Spiral::method175(v85, v86.clone()) {
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
                                    while Spiral::method69(v107, v109.clone()) {
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
                                    while Spiral::method69(v121, v123.clone()) {
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
                    let v155: string = ofChar(Spiral::method176());
                    join(
                        if (v155.clone()) == string("\n") {
                            Spiral::method177(v155.clone())
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
        pub fn method152(v0_1: string) -> string {
            Spiral::method154(Spiral::method153(v0_1))
        }
        pub fn method151(v0_1: string) -> string {
            Spiral::method152(Spiral::method28(Spiral::method36(), v0_1))
        }
        pub fn closure67(unitVar: (), v0_1: std::string::String) -> string {
            Spiral::method151(fable_library_rust::String_::fromString(v0_1))
        }
        pub fn method150() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral::closure67((), v))
        }
        pub fn method178() -> string {
            string("retries")
        }
        pub fn method179() -> string {
            string("working-directory")
        }
        pub fn method182(v0_1: i32, v1_1: string, v2: string) -> string {
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
        pub fn method181(
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
            let v11: string = Spiral::method182(v8, v9, v10);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / repl error"),
                v11
            ))
        }
        pub fn closure76(v0_1: u8, v1_1: u8, v2: string, v3: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method181(
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
        pub fn method180(v0_1: Spiral::US5, v1_1: u8, v2: string, v3: u8) -> (i32, string) {
            let v0_1: MutCell<Spiral::US5> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<u8> = MutCell::new(v1_1);
            let v2: MutCell<string> = MutCell::new(v2.clone());
            let v3: MutCell<u8> = MutCell::new(v3);
            '_method180: loop {
                break '_method180 ({
                    let patternInput: (i32, string) = Spiral::method65(
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
                            Spiral::closure76(v1_1.get().clone(), v3.get().clone(), v24, v23, ());
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
                            continue '_method180;
                        }
                    }
                });
            }
        }
        pub fn method184(v0_1: i32, v1_1: i32) -> string {
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
        pub fn method183(
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
            let v10: string = Spiral::method184(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / dib / jupyter nbconvert"),
                v10
            ))
        }
        pub fn closure77(v0_1: string, v1_1: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method183(
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
        pub fn method186(v0_1: i32, v1_1: i32) -> string {
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
        pub fn method185(
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
            let v10: string = Spiral::method186(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / dib / html cell ids"),
                v10
            ))
        }
        pub fn closure78(v0_1: string, v1_1: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method185(
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
        pub fn method188(v0_1: i32, v1_1: i32) -> string {
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
        pub fn method187(
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
            let v10: string = Spiral::method188(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / dib"),
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
                Spiral::method19(Spiral::method187(
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
        pub fn method189() -> string {
            string("cleanup")
        }
        pub fn method190() -> string {
            string("wasm")
        }
        pub fn method191() -> string {
            string("contract")
        }
        pub fn method192(v0_1: string, v1_1: string, v2: Spiral::US35) -> string {
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
        pub fn method194() -> string {
            string("")
        }
        pub fn method195() -> string {
            string("")
        }
        pub fn method193(v0_1: string) -> string {
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
                        let v103: string = Spiral::method194();
                        let v109: string = join(
                            if (v103.clone()) == string("\n") {
                                Spiral::method177(v103.clone())
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
        pub fn method196(v0_1: Spiral::US5, v1_1: string, v2: Spiral::US38, v3: string) -> string {
            let v6: string = Spiral::method28(Spiral::method28(v3, string("target/spiral")), v1_1);
            if let Spiral::US5::US5_0(v0_1_0_0) = &v0_1 {
                if let Spiral::US38::US38_0(v2_0_0) = &v2 {
                    let v8: Spiral::US37 = v2_0_0.clone();
                    let v10: string = Spiral::method28(v6.clone(), string("packages"));
                    let v15: Spiral::US5 = if if let Spiral::US37::US37_0 = &v8 {
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
                            let v22: Spiral::US5 = if if let Spiral::US37::US37_1 = &v8 {
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
                                    let v29: Spiral::US5 = if if let Spiral::US37::US37_2 = &v8 {
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
                    Spiral::method28(
                        Spiral::method28(
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
        pub fn method198(
            v0_1: string,
            v1_1: LrcPtr<Spiral::UH2>,
            v2: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            match v1_1.as_ref() {
                Spiral::UH2::UH2_0 => v2.clone(),
                Spiral::UH2::UH2_1(v1_1_1_0, v1_1_1_1) => {
                    let v5: LrcPtr<Spiral::UH2> = Spiral::method198(
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
                            Spiral::method28(
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
        pub fn method199(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            match v0_1.as_ref() {
                Spiral::UH2::UH2_0 => v1_1.clone(),
                Spiral::UH2::UH2_1(v0_1_1_0, v0_1_1_1) => {
                    let v4: LrcPtr<Spiral::UH2> = Spiral::method199(
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
        pub fn method197(
            v0_1: string,
            v1_1: string,
            v2: LrcPtr<Spiral::UH2>,
            v3: LrcPtr<Spiral::UH2>,
            v4: string,
            v5: string,
        ) -> string {
            let v6: LrcPtr<dyn IDisposable> = Spiral::method41(v4.clone());
            let v9: string = Spiral::method154(Spiral::method28(
                v4.clone(),
                concat(new_array(&[v1_1.clone(), string(".fs")])),
            ));
            Spiral::method38(v9.clone(), v0_1);
            {
                let v13: List<string> = Spiral::method89(
                    Spiral::method198(v5, v2, LrcPtr::new(Spiral::UH2::UH2_0)),
                    empty::<string>(),
                );
                let v26: string = join(
                    string("\\n        "),
                    toArray_1(delay(Func0::new({
                        let v13 = v13.clone();
                        move || ofList(v13.clone()).clone()
                    }))),
                );
                let v32: List<string> = Spiral::method89(
                    Spiral::method199(v3, LrcPtr::new(Spiral::UH2::UH2_0)),
                    empty::<string>(),
                );
                let v44: string = join(
                    string("\\n        "),
                    toArray_1(delay(Func0::new({
                        let v32 = v32.clone();
                        move || ofList(v32.clone()).clone()
                    }))),
                );
                let v49: string = Spiral::method154(Spiral::method28(
                    v4,
                    concat(new_array(&[v1_1, string(".fsproj")])),
                ));
                Spiral::method38(v49.clone(),
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
        pub fn closure80(unitVar: (), v0_1: chrono::DateTime<chrono::Utc>) -> Spiral::US39 {
            Spiral::US39::US39_0(v0_1)
        }
        pub fn method201() -> Func1<chrono::DateTime<chrono::Utc>, Spiral::US39> {
            Func1::new(move |v: chrono::DateTime<chrono::Utc>| Spiral::closure80((), v))
        }
        pub fn method202() -> string {
            string("hh:mm")
        }
        pub fn method203() -> string {
            string("yyyyMMdd-HHmm-ssff-ffff-f")
        }
        pub fn method204() -> string {
            string("hhmm")
        }
        pub fn method200(v0_1: Guid, v1_1: DateTime) -> Guid {
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
            let v107: Spiral::US39 =
                defaultValue(Spiral::US39::US39_1, map(Spiral::method201(), v93));
            let v127: Spiral::US5 = match &v107 {
                Spiral::US39::US39_0(v107_0_0) => {
                    let v113: chrono::NaiveDateTime = match &v107 {
                        Spiral::US39::US39_0(x) => x.clone(),
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
            let v313: string = Spiral::method202();
            let v332: string = v299.to_string(v313);
            let v337: string = sprintf!(
                "{}{}{}",
                v312,
                getSlice(v332.clone(), Some(0_i32), Some(1_i32)),
                getSlice(v332, Some(3_i32), Some(4_i32))
            );
            let v339: string = toString(v0_1);
            parse(concat(new_array(&[
                v131.clone(),
                v337.clone(),
                getSlice(
                    v339.clone(),
                    Some((length(v131)) + (length(v337))),
                    Some((length(v339)) - 1_i32),
                ),
            ])))
        }
        pub fn method205(v0_1: string, v1_1: string) {
            if (Spiral::method30(v0_1.clone())) == false {
                let v4: LrcPtr<dyn IDisposable> = Spiral::method41(v0_1.clone());
                ()
            }
            {
                let v7: string = defaultValue(string(""), Spiral::method31(v1_1.clone()));
                if (Spiral::method30(v7.clone())) == false {
                    let v12: LrcPtr<dyn IDisposable> = Spiral::method41(v7);
                    ()
                }
                if if Spiral::method30(v1_1.clone()) {
                    let v14: Result<std::path::PathBuf, std::io::Error> =
                        Spiral::method155(v1_1.clone());
                    v14.is_err()
                } else {
                    false
                } {
                    Spiral::method52(true, v1_1.clone());
                }
                if (Spiral::method30(v1_1.clone())) == false {
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
        pub fn method207() -> string {
            string("(")
        }
        pub fn method208() -> string {
            string(" ")
        }
        pub fn method209(v0_1: Spiral::US36) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method213(v0_1: bool, v1_1: string, v2: i32, v3: string) -> string {
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
        pub fn method212(
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
            let v12: string = Spiral::method213(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("common.retry_fn\' / loop"),
                v12
            ))
        }
        pub fn closure81(v0_1: u8, v1_1: u8, v2: i32, v3: string, v4: bool, unitVar: ()) {
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
                Spiral::method19(Spiral::method212(
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
        pub fn method211(
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
            '_method211: loop {
                break '_method211 ({
                    let patternInput: (i32, string) = Spiral::method65(
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
                    let v14: Spiral::US40 = if (v9) == 0_i32 {
                        Spiral::US40::US40_0(v9, v10.clone())
                    } else {
                        Spiral::US40::US40_1(v9, v10)
                    };
                    let patternInput_1: (bool, i32, string) = match &v14 {
                        Spiral::US40::US40_0(v14_0_0, v14_0_1) => {
                            (false, v14_0_0.clone(), v14_0_1.clone())
                        }
                        Spiral::US40::US40_1(v14_1_0, v14_1_1) => {
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
                            Spiral::closure81(
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
                            continue '_method211;
                        }
                    }
                });
            }
        }
        pub fn method210(
            v0_1: u8,
            v1_1: string,
            v2: Option<CancellationToken>,
            v3: Array<(string, string)>,
            v4: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v5: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v6: bool,
            v7: Option<string>,
        ) -> (i32, string) {
            Spiral::method211(v0_1, v1_1, v2, v3, v4, v5, v6, v7, 1_u8)
        }
        pub fn method206(
            v0_1: Spiral::US35,
            v1_1: string,
            v2: string,
            v3: string,
            v4: Spiral::US12,
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
                    Spiral::US35::US35_0(v0_1_0_0) => {
                        let v41: Spiral::US36 = match &v0_1 {
                            Spiral::US35::US35_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone();
                        let v82: Spiral::US5 = if if let Spiral::US36::US36_0(v41_0_0) = &v41 {
                            string("") == (v41_0_0.clone())
                        } else {
                            false
                        } {
                            Spiral::US5::US5_0(string("Wasm"))
                        } else {
                            let v54: string = Spiral::method207();
                            let v68: Array<string> = split(
                                Spiral::method209(Spiral::US36::US36_0(string(""))),
                                v54,
                                -1_i32,
                                0_i32,
                            );
                            let v71: string = v68[0_i32].clone();
                            if startsWith3(Spiral::method209(v41.clone()), v71, false) {
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
                                let v119: Spiral::US5 = if if let Spiral::US36::US36_1(v41_1_0) =
                                    &v41
                                {
                                    string("") == (v41_1_0.clone())
                                } else {
                                    false
                                } {
                                    Spiral::US5::US5_0(string("Contract"))
                                } else {
                                    let v91: string = Spiral::method207();
                                    let v105: Array<string> = split(
                                        Spiral::method209(Spiral::US36::US36_1(string(""))),
                                        v91,
                                        -1_i32,
                                        0_i32,
                                    );
                                    let v108: string = v105[0_i32].clone();
                                    if startsWith3(Spiral::method209(v41.clone()), v108, false) {
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
                Spiral::US12::US12_0(v4_0_0) => Ok::<string, string>(v4_0_0.clone()),
                Spiral::US12::US12_1(v4_1_0) => Err::<string, string>(v4_1_0.clone()),
            };
            Spiral::method210(
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
        pub fn method215(v0_1: i32, v1_1: string) -> string {
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
        pub fn method214(
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
            let v10: string = Spiral::method215(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / dotnet fable error"),
                v10
            ))
        }
        pub fn closure82(v0_1: string, v1_1: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method214(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method45(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn closure83(unitVar: (), v0_1: std::string::String) -> bool {
            contains(
                fable_library_rust::String_::fromString(v0_1),
                string("near-sdk"),
            )
        }
        pub fn method216() -> Func1<std::string::String, bool> {
            Func1::new(move |v: std::string::String| Spiral::closure83((), v))
        }
        pub fn method217(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method218(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method219(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method220() -> string {
            string("(")
        }
        pub fn method221() -> string {
            string("(")
        }
        pub fn method223(
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
        pub fn closure84(
            unitVar: (),
            v0_1: std::collections::HashMap<string, string>,
        ) -> Spiral::US41 {
            Spiral::US41::US41_0(v0_1)
        }
        pub fn method224() -> Func1<std::collections::HashMap<string, string>, Spiral::US41> {
            Func1::new(move |v: std::collections::HashMap<string, string>| Spiral::closure84((), v))
        }
        pub fn method225() -> string {
            string("a")
        }
        pub fn closure85(v0_1: u8, v1_1: i32, v2: string, v3: bool, unitVar: ()) {
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
                Spiral::method19(Spiral::method212(
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
        pub fn method222(v0_1: Spiral::US12, v1_1: string, v2: u8) -> (i32, string) {
            let v0_1: MutCell<Spiral::US12> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<u8> = MutCell::new(v2);
            '_method222: loop {
                break '_method222 ({
                    let v8: string = concat(new_array(&[
                        string("cargo fmt --manifest-path \""),
                        v1_1.get().clone(),
                        string("\" --"),
                    ]));
                    let v14: Result<string, string> = match &v0_1.get().clone() {
                        Spiral::US12::US12_0(v0_1_0_0) => Ok::<string, string>(v0_1_0_0.clone()),
                        Spiral::US12::US12_1(v0_1_1_0) => Err::<string, string>(v0_1_1_0.clone()),
                    };
                    let patternInput: (i32, string) = Spiral::method65(
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
                    let v176: Spiral::US40 = if (contains(
                        v31.clone(),
                        string("failed to load manifest for workspace member"),
                    )) == false
                    {
                        if (v30) == 0_i32 {
                            Spiral::US40::US40_0(v30, v31.clone())
                        } else {
                            Spiral::US40::US40_1(v30, v31.clone())
                        }
                    } else {
                        let v43: Result<regex::Regex, regex::Error> =
                            regex::Regex::new(&string("failed to read `(?<a>.*?Cargo.toml)`"));
                        let v58: Vec<std::collections::HashMap<string, string>> =
                            Spiral::method223(v31.clone(), v43.unwrap());
                        let v61: Option<std::collections::HashMap<string, string>> = tryItem(
                            0_i32,
                            fable_library_rust::NativeArray_::array_from(v58.clone()),
                        );
                        let v75: Spiral::US41 =
                            defaultValue(Spiral::US41::US41_1, map(Spiral::method224(), v61));
                        let v103: Spiral::US42 = match &v75 {
                            Spiral::US41::US41_0(v75_0_0) => {
                                let v80: string = Spiral::method225();
                                let v82: Option<string> = std::collections::HashMap::get(
                                    &match &v75 {
                                        Spiral::US41::US41_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    &v80,
                                )
                                .map(|x| x)
                                .cloned();
                                Spiral::US42::US42_0(defaultValue(
                                    Spiral::US5::US5_1,
                                    map(Spiral::method6(), v82),
                                ))
                            }
                            _ => Spiral::US42::US42_1,
                        };
                        let v110: Spiral::US5 = if let Spiral::US42::US42_0(v103_0_0) = &v103 {
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
                                if (Spiral::method40(v112.clone())) == false {
                                    let v120: LrcPtr<dyn IDisposable> = Spiral::method41(
                                        defaultValue(string(""), Spiral::method31(v112.clone())),
                                    );
                                    let v122: DateTime = DateTime::now();
                                    let v142: string =
                                        toString(Spiral::method200(new_guid(), v122));
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
                                    Spiral::US40::US40_0(v30, v31.clone())
                                } else {
                                    Spiral::US40::US40_1(v30, v31.clone())
                                }
                            }
                            _ => Spiral::US40::US40_1(v30, v31.clone()),
                        }
                    };
                    let patternInput_1: (bool, i32, string) = match &v176 {
                        Spiral::US40::US40_0(v176_0_0, v176_0_1) => {
                            (false, v176_0_0.clone(), v176_0_1.clone())
                        }
                        Spiral::US40::US40_1(v176_1_0, v176_1_1) => {
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
                            Spiral::closure85(v2.get().clone(), v185, v186, v184, ());
                            ()
                        };
                        {
                            let v0_1_temp: Spiral::US12 = v0_1.get().clone();
                            let v1_1_temp: string = v1_1.get().clone();
                            let v2_temp: u8 = (v2.get().clone()) + 1_u8;
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            continue '_method222;
                        }
                    }
                });
            }
        }
        pub fn method227(v0_1: i32, v1_1: string) -> string {
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
        pub fn method226(
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
            let v10: string = Spiral::method227(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / cargo fmt error"),
                v10
            ))
        }
        pub fn closure86(v0_1: string, v1_1: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method226(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method45(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn method228() -> string {
            string("{")
        }
        pub fn closure87(unitVar: (), v0_1: string) -> string {
            v0_1
        }
        pub fn closure88(v0_1: string, v1_1: string, v2: string) -> string {
            replace(v2, v0_1, v1_1)
        }
        pub fn closure89(v0_1: string, v1_1: string) -> string {
            replace(v1_1, v0_1, string("type DateTime = ();"))
        }
        pub fn method230(v0_1: i32, v1_1: string, v2: string, v3: bool, v4: string) -> string {
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
            v10: string,
            v11: bool,
            v12: string,
        ) -> string {
            let v13: string = Spiral::method230(v8, v9, v10, v11, v12);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / error"),
                v13
            ))
        }
        pub fn closure90(v0_1: bool, v1_1: string, v2: string, v3: i32, v4: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method229(
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    Spiral::method8(v23, v24, v25, v26, v27, v28),
                    Spiral::method45(),
                    v3,
                    v1_1,
                    v4,
                    v0_1,
                    v2,
                ))
            };
        }
        pub fn closure92(unitVar: (), v0_1: string) -> bool {
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
        pub fn closure91(v0_1: string, unitVar: ()) -> string {
            let v8: LrcPtr<dyn IEnumerable_1<string>> = ofArray_1(skip(
                2_i32,
                skipWhile(
                    Func1::new(move |v: string| Spiral::closure92((), v)),
                    split(v0_1, string("\n"), -1_i32, 0_i32),
                ),
            ));
            join(Spiral::method37(), toArray_1(v8))
        }
        pub fn method232(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
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
        pub fn method231(
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
            let v12: string = Spiral::method232(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / Exception"),
                v12
            ))
        }
        pub fn closure94(
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
                Spiral::method19(Spiral::method231(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method45(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure93(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure94(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method234(v0_1: i32, v1_1: string, v2: string, v3: bool, v4: string) -> string {
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
        pub fn method233(
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
            let v13: string = Spiral::method234(v8, v9, v10, v11, v12);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / wasm error"),
                v13
            ))
        }
        pub fn closure95(v0_1: bool, v1_1: string, v2: string, v3: string, v4: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method233(
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    Spiral::method8(v23, v24, v25, v26, v27, v28),
                    Spiral::method45(),
                    v4,
                    v1_1,
                    v2,
                    v0_1,
                    concat(new_array(&[string("\n"), v3])),
                ))
            };
        }
        pub fn method236(
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
            v10: string,
            v11: string,
            v12: bool,
            v13: string,
        ) -> string {
            let v14: string = Spiral::method236(v8, v9, v10, v11, v12, v13);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / cargo error"),
                v14
            ))
        }
        pub fn closure96(
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
                Spiral::method19(Spiral::method235(
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    Spiral::method8(v24, v25, v26, v27, v28, v29),
                    Spiral::method45(),
                    v3,
                    v1_1,
                    v4,
                    v5,
                    v0_1,
                    concat(new_array(&[string("\n"), v2])),
                ))
            };
        }
        pub fn method238(v0_1: string, v1_1: LrcPtr<Spiral::UH4>) -> string {
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
        pub fn method237(
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
            let v25: string = Spiral::method238(
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
        pub fn closure97(
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
                Spiral::method19(Spiral::method237(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method48(),
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
        pub fn closure98(unitVar: (), unitVar_1: ()) -> Spiral::US43 {
            Spiral::US43::US43_0
        }
        pub fn method240() -> Func0<Spiral::US43> {
            Func0::new(move || Spiral::closure98((), ()))
        }
        pub fn closure99(unitVar: (), v0_1: string) -> Spiral::US43 {
            Spiral::US43::US43_1(v0_1)
        }
        pub fn method241() -> Func1<string, Spiral::US43> {
            Func1::new(move |v: string| Spiral::closure99((), v))
        }
        pub fn method243(v0_1: string) -> string {
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
        pub fn method242(
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
            let v9: string = Spiral::method243(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.file_delete"),
                v9
            ))
        }
        pub fn closure100(v0_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method242(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method45(),
                    v0_1,
                ))
            };
        }
        pub fn method239(v0_1: LrcPtr<Spiral::UH4>) {
            let v0_1: MutCell<LrcPtr<Spiral::UH4>> = MutCell::new(v0_1.clone());
            '_method239: loop {
                break '_method239 (match v0_1.get().clone().as_ref() {
                    Spiral::UH4::UH4_0 => (),
                    Spiral::UH4::UH4_1(v0_1_1_0, v0_1_1_1, v0_1_1_2) => {
                        let v6: Result<(), std::io::Error> = std::fs::remove_file(
                            &*match v0_1.get().clone().as_ref() {
                                Spiral::UH4::UH4_1(x, _, _) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        );
                        let v7 = Spiral::method157();
                        let v19: Result<(), string> = v6.map_err(|x| v7(x));
                        let v22 = Spiral::method240();
                        let v23 = Spiral::method241();
                        let v24: Spiral::US43 = match &v19 {
                            Err(v19_1_0) => v23(v19_1_0.clone()),
                            _ => v22(),
                        };
                        match &v24 {
                            Spiral::US43::US43_0 => (),
                            Spiral::US43::US43_1(v24_1_0) => {
                                let v28: () = {
                                    Spiral::closure100(
                                        match &v24 {
                                            Spiral::US43::US43_1(x) => x.clone(),
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
                            continue '_method239;
                        }
                    }
                });
            }
        }
        pub fn method244(v0_1: string) -> string {
            v0_1
        }
        pub fn closure102(unitVar: (), v0_1: std::fs::FileType) -> Spiral::US44 {
            Spiral::US44::US44_0(v0_1)
        }
        pub fn method245() -> Func1<std::fs::FileType, Spiral::US44> {
            Func1::new(move |v: std::fs::FileType| Spiral::closure102((), v))
        }
        pub fn closure103(unitVar: (), v0_1: std::string::String) -> Spiral::US44 {
            Spiral::US44::US44_1(v0_1)
        }
        pub fn method246() -> Func1<std::string::String, Spiral::US44> {
            Func1::new(move |v: std::string::String| Spiral::closure103((), v))
        }
        pub fn method247(v0_1: string) -> string {
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
        pub fn closure101(
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
 //;
                    let v9: bool = true;
                    let __future_init = Box::pin(
                        /*;
                        let v11: bool = */
                        async move {
                            /*;
                            let v13: bool = */
 //;
                            let v15: async_walkdir::DirEntry = v1_1.clone();
                            let v17: std::pin::Pin<
                                Box<
                                    dyn std::future::Future<
                                            Output = Result<std::fs::FileType, std::io::Error>,
                                        > + Send,
                                >,
                            > = Box::pin(async_walkdir::DirEntry::file_type(&v15));
                            let v19: Result<std::fs::FileType, std::io::Error> = v17.await;
                            let v20 = Spiral::method42();
                            let v32: Result<std::fs::FileType, std::string::String> =
                                v19.map_err(|x| v20(x));
                            let v35 = Spiral::method245();
                            let v36 = Spiral::method246();
                            let v37: Spiral::US44 = match &v32 {
                                Err(v32_1_0) => v36(v32_1_0.clone()),
                                Ok(v32_0_0) => v35(v32_0_0.clone()),
                            };
                            let v218: Spiral::US45 = if let Spiral::US44::US44_0(v37_0_0) = &v37 {
                                if (std::fs::FileType::is_dir(&v37_0_0.clone())) == false {
                                    Spiral::US45::US45_0
                                } else {
                                    let v44: std::path::PathBuf =
                                        async_walkdir::DirEntry::path(&v1_1.clone());
                                    let v47: std::path::Display = v44.display();
                                    let v71: std::string::String = format!("{}", v47);
                                    let v94: string = fable_library_rust::String_::fromString(v71);
                                    if (startsWith3(
                                        Spiral::method247(v94.clone()),
                                        v0_1.clone(),
                                        false,
                                    )) == false
                                    {
                                        Spiral::US45::US45_1
                                    } else {
                                        let v101: Option<string> = Spiral::method31(v94);
                                        let v115: Spiral::US5 = defaultValue(
                                            Spiral::US5::US5_1,
                                            map(Spiral::method6(), v101),
                                        );
                                        if let Spiral::US5::US5_0(v115_0_0) = &v115 {
                                            if (contains(v115_0_0.clone(), v0_1.clone())) == false {
                                                Spiral::US45::US45_2
                                            } else {
                                                Spiral::US45::US45_1
                                            }
                                        } else {
                                            Spiral::US45::US45_1
                                        }
                                    }
                                }
                            } else {
                                let v132: std::path::PathBuf = async_walkdir::DirEntry::path(&v1_1);
                                let v135: std::path::Display = v132.display();
                                let v159: std::string::String = format!("{}", v135);
                                let v182: string = fable_library_rust::String_::fromString(v159);
                                if (startsWith3(
                                    Spiral::method247(v182.clone()),
                                    v0_1.clone(),
                                    false,
                                )) == false
                                {
                                    Spiral::US45::US45_1
                                } else {
                                    let v189: Option<string> = Spiral::method31(v182);
                                    let v203: Spiral::US5 = defaultValue(
                                        Spiral::US5::US5_1,
                                        map(Spiral::method6(), v189),
                                    );
                                    if let Spiral::US5::US5_0(v203_0_0) = &v203 {
                                        if (contains(v203_0_0.clone(), v0_1)) == false {
                                            Spiral::US45::US45_2
                                        } else {
                                            Spiral::US45::US45_1
                                        }
                                    } else {
                                        Spiral::US45::US45_1
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
                        Box<dyn std::future::Future<Output = Spiral::US45> + Send>,
                    > = v236;
                    let v240: Spiral::US45 = v238.await;
                    let v249: async_walkdir::Filtering = match &v240 {
                        Spiral::US45::US45_0 => async_walkdir::Filtering::Ignore,
                        Spiral::US45::US45_1 => async_walkdir::Filtering::IgnoreDir,
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
        pub fn closure105(unitVar: (), v0_1: async_walkdir::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method249() -> Func1<async_walkdir::Error, std::string::String> {
            Func1::new(move |v: async_walkdir::Error| Spiral::closure105((), v))
        }
        pub fn closure106(unitVar: (), v0_1: async_walkdir::DirEntry) -> Spiral::US46 {
            Spiral::US46::US46_0(v0_1)
        }
        pub fn method250() -> Func1<async_walkdir::DirEntry, Spiral::US46> {
            Func1::new(move |v: async_walkdir::DirEntry| Spiral::closure106((), v))
        }
        pub fn closure107(unitVar: (), v0_1: std::string::String) -> Spiral::US46 {
            Spiral::US46::US46_1(v0_1)
        }
        pub fn method251() -> Func1<std::string::String, Spiral::US46> {
            Func1::new(move |v: std::string::String| Spiral::closure107((), v))
        }
        pub fn method252(
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
            let v9: string = Spiral::method97(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / stream_filter_map"),
                v9
            ))
        }
        pub fn closure108(v0_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method252(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method45(),
                    v0_1,
                ))
            };
        }
        pub fn closure104(
            v0_1: string,
            v1_1: Result<async_walkdir::DirEntry, async_walkdir::Error>,
        ) -> Option<(string, string)> {
            let v2 = Spiral::method249();
            let v14: Result<async_walkdir::DirEntry, std::string::String> = v1_1.map_err(|x| v2(x));
            let v17 = Spiral::method250();
            let v18 = Spiral::method251();
            let v19: Spiral::US46 = match &v14 {
                Err(v14_1_0) => v18(v14_1_0.clone()),
                Ok(v14_0_0) => v17(v14_0_0.clone()),
            };
            let v193: Spiral::US47 = match &v19 {
                Spiral::US46::US46_0(v19_0_0) => {
                    let v22: std::path::PathBuf = async_walkdir::DirEntry::path(&v19_0_0.clone());
                    let v25: std::path::Display = v22.display();
                    let v49: std::string::String = format!("{}", v25);
                    let v72: string = fable_library_rust::String_::fromString(v49);
                    let v73: string =
                        concat(new_array(&[v0_1.clone(), string("\\.(?<a>[-\\d\\w.]+)$")]));
                    let v75: Result<regex::Regex, regex::Error> = regex::Regex::new(&v73);
                    let v90: Vec<std::collections::HashMap<string, string>> =
                        Spiral::method223(v72.clone(), v75.unwrap());
                    let v93: Option<std::collections::HashMap<string, string>> = tryItem(
                        0_i32,
                        fable_library_rust::NativeArray_::array_from(v90.clone()),
                    );
                    let v107: Spiral::US41 =
                        defaultValue(Spiral::US41::US41_1, map(Spiral::method224(), v93));
                    let v135: Spiral::US42 = match &v107 {
                        Spiral::US41::US41_0(v107_0_0) => {
                            let v112: string = Spiral::method225();
                            let v114: Option<string> = std::collections::HashMap::get(
                                &match &v107 {
                                    Spiral::US41::US41_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                &v112,
                            )
                            .map(|x| x)
                            .cloned();
                            Spiral::US42::US42_0(defaultValue(
                                Spiral::US5::US5_1,
                                map(Spiral::method6(), v114),
                            ))
                        }
                        _ => Spiral::US42::US42_1,
                    };
                    let v142: Spiral::US5 = if let Spiral::US42::US42_0(v135_0_0) = &v135 {
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
                        Spiral::US5::US5_0(v142_0_0) => Spiral::US47::US47_0(
                            v72.clone(),
                            match &v142 {
                                Spiral::US5::US5_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => Spiral::US47::US47_1,
                    }
                }
                Spiral::US46::US46_1(v19_1_0) => {
                    let v151: () = {
                        Spiral::closure108(v19_1_0.clone(), ());
                        ()
                    };
                    Spiral::US47::US47_1
                }
            };
            match &v193 {
                Spiral::US47::US47_0(v193_0_0, v193_0_1) => Some((
                    match &v193 {
                        Spiral::US47::US47_0(x, _) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    match &v193 {
                        Spiral::US47::US47_0(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                )),
                _ => None::<(string, string)>,
            }
        }
        pub fn method248(
            v0_1: string,
        ) -> Func1<Result<async_walkdir::DirEntry, async_walkdir::Error>, Option<(string, string)>>
        {
            Func1::new({
                let v0_1 = v0_1.clone();
                move |v: Result<async_walkdir::DirEntry, async_walkdir::Error>| {
                    Spiral::closure104(v0_1.clone(), v)
                }
            })
        }
        pub fn closure109(unitVar: (), _arg: (string, string)) -> (string, string) {
            (_arg.0.clone(), _arg.1.clone())
        }
        pub fn closure110(unitVar: (), _arg: (string, string)) -> Spiral::US47 {
            Spiral::US47::US47_0(_arg.0.clone(), _arg.1.clone())
        }
        pub fn method253() -> Func1<(string, string), Spiral::US47> {
            Func1::new(move |arg10_0040: (string, string)| Spiral::closure110((), arg10_0040))
        }
        pub fn method255(v0_1: Spiral::US47) -> string {
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
        pub fn method254(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Spiral::US47,
        ) -> string {
            let v9: string = Spiral::method255(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v9
            ))
        }
        pub fn closure111(v0_1: Spiral::US47, unitVar: ()) {
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
                Spiral::method19(Spiral::method254(
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
        pub fn method256(v0_1: string, v1_1: string, v2: Spiral::US47) {
            match &v2 {
                Spiral::US47::US47_0(v2_0_0, v2_0_1) => {
                    let v4: string = match &v2 {
                        Spiral::US47::US47_0(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone();
                    Spiral::method205(
                        Spiral::method28(
                            v1_1.clone(),
                            concat(new_array(&[
                                string("fable-library-"),
                                string("ts"),
                                string("."),
                                v4.clone(),
                            ])),
                        ),
                        Spiral::method28(
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
        pub fn method257(
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
            let v10: string = Spiral::method215(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v10
            ))
        }
        pub fn closure112(v0_1: string, v1_1: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method257(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method45(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn method259(v0_1: string) -> string {
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
        pub fn method258(
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
            let v9: string = Spiral::method259(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v9
            ))
        }
        pub fn closure113(v0_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method258(
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
        pub fn method260(
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
                        Spiral::method260(
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
        pub fn method261(
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
                    Spiral::method261(
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
        pub fn closure114(v0_1: string, unitVar: ()) -> string {
            let v5: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method37(), toArray_1(v5))
        }
        pub fn method263(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
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
        pub fn method262(
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
            let v12: string = Spiral::method263(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / Exception"),
                v12
            ))
        }
        pub fn closure116(
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
                Spiral::method19(Spiral::method262(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method45(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure115(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure116(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method264(
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
            let v12: string = Spiral::method145(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / error"),
                v12
            ))
        }
        pub fn closure117(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method264(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method45(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
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
            v8: i32,
            v9: string,
        ) -> string {
            let v10: string = Spiral::method215(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python"),
                v10
            ))
        }
        pub fn closure118(v0_1: string, v1_1: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method265(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method45(),
                    v1_1,
                    v0_1,
                ))
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
            v8: string,
        ) -> string {
            let v9: string = Spiral::method259(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python"),
                v9
            ))
        }
        pub fn closure119(v0_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method266(
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
        pub fn closure120(v0_1: string, unitVar: ()) -> string {
            let v5: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method37(), toArray_1(v5))
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
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method263(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python / Exception"),
                v12
            ))
        }
        pub fn closure122(
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
                Spiral::method19(Spiral::method267(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method45(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure121(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure122(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
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
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method145(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python / error"),
                v12
            ))
        }
        pub fn closure123(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method268(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method45(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method270(v0_1: std::string::String, v1_1: clap::ArgMatches) -> string {
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
        pub fn method269(
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
            let v10: string = Spiral::method270(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / invalid subcommand"),
                v10
            ))
        }
        pub fn closure124(v0_1: clap::ArgMatches, v1_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method269(
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
        pub fn closure125(unitVar: (), v0_1: serde_json::Error) -> string {
            let v3: std::string::String = format!("{}", v0_1);
            fable_library_rust::String_::fromString(v3)
        }
        pub fn method271() -> Func1<serde_json::Error, string> {
            Func1::new(move |v: serde_json::Error| Spiral::closure125((), v))
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
 //;
                    let v10: Option<(std::string::String, clap::ArgMatches)> =
                        clap::ArgMatches::subcommand(Box::leak(Box::new(v1_1))).map(|(a, b)| {
                            (
                                Func1::new(move |v: &str| Spiral::closure11((), v))(a),
                                b.clone(),
                            )
                        });
                    let v25: Spiral::US6 =
                        defaultValue(Spiral::US6::US6_1, map(Spiral::method21(), v10));
                    let v4910: Array<(string, string)> = if let Spiral::US6::US6_0(
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
                            let v300: Spiral::US12 = Spiral::method29(
                                Spiral::method28(string("polyglot"), string("workspace")),
                                string("C:\\home\\git\\polyglot\\target\\Builder\\spiral"),
                            );
                            let v348: Spiral::US5 = match &v300 {
                                Spiral::US12::US12_0(v300_0_0) => {
                                    Spiral::US5::US5_0(v300_0_0.clone())
                                }
                                Spiral::US12::US12_1(v300_1_0) => {
                                    let v306: () = {
                                        Spiral::closure15(v300_1_0.clone(), ());
                                        ()
                                    };
                                    Spiral::US5::US5_1
                                }
                            };
                            let v403: Spiral::US5 = match &v348 {
                                Spiral::US5::US5_0(v348_0_0) => Spiral::US5::US5_0(
                                    match &v348 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v351: string = Spiral::method36();
                                    let v353: Spiral::US12 = Spiral::method29(
                                        Spiral::method28(string("polyglot"), string("workspace")),
                                        v351,
                                    );
                                    match &v353 {
                                        Spiral::US12::US12_0(v353_0_0) => {
                                            Spiral::US5::US5_0(v353_0_0.clone())
                                        }
                                        Spiral::US12::US12_1(v353_1_0) => {
                                            let v359: () = {
                                                Spiral::closure15(v353_1_0.clone(), ());
                                                ()
                                            };
                                            Spiral::US5::US5_1
                                        }
                                    }
                                }
                            };
                            let v408: string = Spiral::method28(
                                match &v403 {
                                    Spiral::US5::US5_0(v403_0_0) => match &v403 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                },
                                string("polyglot"),
                            );
                            let v411: string = toLower(Spiral::method36());
                            let v415: string = toLower(v408);
                            let v423: Spiral::US12 = if startsWith3(v411, v415.clone(), false) {
                                Spiral::US12::US12_1(v415.clone())
                            } else {
                                Spiral::US12::US12_0(v415)
                            };
                            let v429: Result<string, string> = match &v423 {
                                Spiral::US12::US12_0(v423_0_0) => {
                                    Ok::<string, string>(v423_0_0.clone())
                                }
                                Spiral::US12::US12_1(v423_1_0) => {
                                    Err::<string, string>(v423_1_0.clone())
                                }
                            };
                            let v431: bool = true;
                            let _result_unwrap_or_else = v429.unwrap_or_else(|x| {
                                //;
                                let v433: string = x;
                                let v435: bool = true;
                                v433
                            });
                            let v437: string = _result_unwrap_or_else;
                            let v440: string =
                                defaultValue(string(""), Spiral::method31(v83.clone()));
                            let v448: string = match &v164 {
                                Spiral::US10::US10_1 => {
                                    Spiral::method28(v440.clone(), string("pyproject.toml"))
                                }
                                _ => Spiral::method28(v440.clone(), string("requirements.txt")),
                            };
                            let v450: bool = true;
                            let _vec_map: Vec<_> = v214
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v452: std::string::String = x;
                                    let v454: string =
                                        fable_library_rust::String_::fromString(v452);
                                    let v469: string = if contains(v454.clone(), string("=")) {
                                        v454.clone()
                                    } else {
                                        if endsWith3(v454.clone(), string("]"), false) {
                                            concat(new_array(&[
                                                replace(
                                                    v454.clone(),
                                                    string("["),
                                                    string("={version=\'*\',features=["),
                                                ),
                                                string("}"),
                                            ]))
                                        } else {
                                            concat(new_array(&[v454, string("=\'*\'")]))
                                        }
                                    };
                                    let v471: bool = true;
                                    v469
                                })
                                .collect::<Vec<_>>();
                            let v473: Vec<string> = _vec_map;
                            let v475: Array<string> =
                                fable_library_rust::NativeArray_::array_from(v473.clone());
                            let _let__v476: LrcPtr<dyn IEnumerable_1<string>> =
                                delay(Func0::new({
                                    let v475 = v475.clone();
                                    move || {
                                        map_1(
                                            Func1::new({
                                                let v475 = v475.clone();
                                                move |i: i32| v475[i].clone()
                                            }),
                                            rangeNumeric(
                                                0_i32,
                                                1_i32,
                                                (get_Count(v475.clone())) - 1_i32,
                                            ),
                                        )
                                    }
                                }));
                            let v488: string = join(Spiral::method37(), toArray_1(_let__v476));
                            let patternInput: (i32, string) = if (v488.clone()) == string("") {
                                (0_i32, string(""))
                            } else {
                                Spiral::method38(v448,
                                                 match &v164 {
                                                     Spiral::US10::US10_1 =>
                                                     append((append((append((append((append((append((append((append((append(string("[tool.poetry]\nname = \"test\"\nversion = \"0.0.1\"\ndescription = \"\"\nauthors = []\n\n[tool.poetry.dependencies]\npython=\"~3.12\"\n"),
                                                                                                                            (v488.clone()))),
                                                                                                                    string("\n"))),
                                                                                                            string(""))),
                                                                                                    string("\n"))),
                                                                                            string("[build-system]"))),
                                                                                    string("\n"))),
                                                                            string("requires = [\"poetry-core\"]"))),
                                                                    string("\n"))),
                                                            string("build-backend = \"poetry.core.masonry.api\"")),
                                                     _ => v488.clone(),
                                                 });
                                Spiral::method65(
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
                                    Some(v440.clone()),
                                )
                            };
                            let v548: i32 = patternInput.0.clone();
                            let patternInput_4: (
                                Spiral::US5,
                                Spiral::US5,
                                Spiral::US5,
                                Spiral::US5,
                            ) = if (v548) != 0_i32 {
                                let v555: () = {
                                    Spiral::closure60(
                                        v164.clone(),
                                        v83.clone(),
                                        patternInput.1.clone(),
                                        v548,
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
                                let v603: string = match &v164 {
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
                                let v606: Array<(string, string)> =
                                    new_array(&[(string("TRACE_LEVEL"), string("Verbose"))]);
                                let patternInput_1: (i32, string) = Spiral::method65(
                                    v603.clone(),
                                    None::<CancellationToken>,
                                    v606.clone(),
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
                                    Some(v440.clone()),
                                );
                                let v617: string = patternInput_1.1.clone();
                                let v616: i32 = patternInput_1.0.clone();
                                let v618: i32 = get_Count(v606.clone());
                                let v619: Array<string> = new_init(&string(""), v618);
                                let v620: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method69(v618, v620.clone()) {
                                    let v622: i32 = v620.l0.get().clone();
                                    let patternInput_2: (string, string) = v606[v622].clone();
                                    let v625: string = sprintf!(
                                        "$env:{}=\'\'{}\'\'",
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone()
                                    );
                                    v619.get_mut()[v622 as usize] = v625;
                                    {
                                        let v626: i32 = (v622) + 1_i32;
                                        v620.l0.set(v626);
                                        ()
                                    }
                                }
                                {
                                    let v636: string = sprintf!(
                                        "pwsh -c \'{}; {}\'",
                                        join(string(";"), toArray_1(ofArray_1(v619.clone()))),
                                        v603
                                    );
                                    let patternInput_3: (
                                        Spiral::US5,
                                        Spiral::US5,
                                        Spiral::US5,
                                        Spiral::US5,
                                    ) = if if (v616) == 0_i32 {
                                        true
                                    } else {
                                        contains(v617.clone(),
                                                        string("cupy_backends.cuda.api.runtime.CUDARuntimeError: cudaErrorInsufficientDriver"))
                                    } {
                                        let result: LrcPtr<MutCell<Spiral::US5>> =
                                            refCell(Spiral::US5::US5_1);
                                        try_catch(
                                            || {
                                                result.set(Spiral::closure61(
                                                    (),
                                                    Spiral::closure62(v617.clone(), ()),
                                                ))
                                            },
                                            |ex: LrcPtr<Exception>| {
                                                result.set(Spiral::closure63(
                                                    v83.clone(),
                                                    v617.clone(),
                                                    v636.clone(),
                                                    ex.clone(),
                                                ))
                                            },
                                        );
                                        {
                                            let v647: Spiral::US5 = result.get().clone();
                                            let v657: Option<string> = match &v647 {
                                                Spiral::US5::US5_0(v647_0_0) => Some(
                                                    match &v647 {
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
                                                Spiral::US5::US5_0(v657.unwrap()),
                                            )
                                        }
                                    } else {
                                        let v667: () = {
                                            Spiral::closure65(v83.clone(), v617, v616, v636, ());
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
                            let v719: Spiral::US5 = patternInput_4.3.clone();
                            let v717: Spiral::US5 = patternInput_4.1.clone();
                            let v716: Spiral::US5 = patternInput_4.0.clone();
                            let v732: Array<(string, string)> = new_array(&[
                                (
                                    string("extension"),
                                    match &v716 {
                                        Spiral::US5::US5_0(v716_0_0) => match &v716 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => string(""),
                                    },
                                ),
                                (
                                    string("code"),
                                    match &v717 {
                                        Spiral::US5::US5_0(v717_0_0) => match &v717 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => string(""),
                                    },
                                ),
                                (
                                    string("output"),
                                    match &v719 {
                                        Spiral::US5::US5_0(v719_0_0) => match &v719 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => string(""),
                                    },
                                ),
                            ]);
                            let v734: Vec<(string, string)> = v732.to_vec();
                            let v737: bool = true;
                            let _func1_from_v735 = Func1::from(move |value| {
                                //;
                                let patternInput_5: (string, string) = value;
                                let v743: &str = &*patternInput_5.0.clone();
                                let v767: std::string::String = String::from(v743);
                                let v791: &str = &*patternInput_5.1.clone();
                                let v815: std::string::String = String::from(v791);
                                let v840: bool = true;
                                LrcPtr::new((v767, v815)) /*;
                                                          let v842: bool = */
                            }); //;
                            let v844: Func1<
                                (string, string),
                                LrcPtr<(std::string::String, std::string::String)>,
                            > = _func1_from_v735;
                            let v847: Vec<LrcPtr<(std::string::String, std::string::String)>> =
                                v734.into_iter()
                                    .map(|x| {
                                        Func1::new({
                                            let v844 = v844.clone();
                                            move |arg10_0040_5: (string, string)| {
                                                Spiral::closure66(v844.clone(), arg10_0040_5)
                                            }
                                        })(x.clone())
                                    })
                                    .collect::<Vec<_>>();
                            let v848: string =
                            string("std::collections::BTreeMap::from_iter(v847.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                            let v849: std::collections::BTreeMap<
                                std::string::String,
                                std::string::String,
                            > = std::collections::BTreeMap::from_iter(
                                v847.iter()
                                    .map(|x| x.as_ref())
                                    .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                            );
                            let v851: Result<std::string::String, serde_json::Error> =
                                serde_json::to_string(&v849);
                            let v854: std::string::String = v851.unwrap();
                            new_array(&[(
                                string("command_result"),
                                fable_library_rust::String_::fromString(v854),
                            )])
                        } else {
                            if (fable_library_rust::String_::fromString(v29.clone()))
                                == string("fable")
                            {
                                let v873: string = Spiral::method147();
                                let v876: &str = &*v873;
                                let v899: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v30.clone(), v876).cloned();
                                let v913: Spiral::US7 =
                                    defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v899));
                                let v920: std::string::String = match &v913 {
                                    Spiral::US7::US7_0(v913_0_0) => match &v913 {
                                        Spiral::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                };
                                let v922: string = fable_library_rust::String_::fromString(v920);
                                let v923: string = Spiral::method148();
                                let v926: &str = &*v923;
                                let v949: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v30.clone(), v926).cloned();
                                let v963: Spiral::US7 =
                                    defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v949));
                                let v973: Spiral::US5 = match &v963 {
                                    Spiral::US7::US7_0(v963_0_0) => {
                                        Spiral::US5::US5_0(fable_library_rust::String_::fromString(
                                            match &v963 {
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
                                    match &v973 {
                                        Spiral::US5::US5_0(v973_0_0) => {
                                            let v975: clap::Command = Spiral::method0();
                                            let v977: Spiral::US22 = Spiral::method81(sprintf!(
                                                "_ {} --fs-path \"{}\"",
                                                match &v973 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                v922.clone()
                                            ));
                                            let v985: Array<string> =
                                                     match &v977 {
                                                         Spiral::US22::US22_0(v977_0_0)
                                                         => v977_0_0.clone(),
                                                         Spiral::US22::US22_1(v977_1_0)
                                                         =>
                                                         panic!("{}",
                                                                concat(new_array(&[string("resultm.get / Result value was Error: "),
                   v977_1_0.clone()])),),
                                                     };
                                            let v987: Vec<string> = v985.to_vec();
                                            let v989: bool = true;
                                            let _vec_map: Vec<_> = v987
                                                .into_iter()
                                                .map(|x| {
                                                    //;
                                                    let v991: string = x;
                                                    let v994: &str = &*v991;
                                                    let v1018: std::string::String =
                                                        String::from(v994);
                                                    let v1041: bool = true;
                                                    v1018
                                                })
                                                .collect::<Vec<_>>();
                                            let v1043: Vec<std::string::String> = _vec_map;
                                            let v1046: std::pin::Pin<
                                                Box<
                                                    dyn std::future::Future<
                                                        Output = Result<string, string>,
                                                    >,
                                                >,
                                            > = Spiral::method20(
                                                v0_1.clone(),
                                                clap::Command::get_matches_from(v975, v1043),
                                            );
                                            let v1048: Result<string, string> = v1046.await;
                                            v1048.unwrap()
                                        }
                                        _ => string("{}"),
                                    },
                                )])
                            } else {
                                if (fable_library_rust::String_::fromString(v29.clone()))
                                    == string("dib")
                                {
                                    let v1071: string = Spiral::method149();
                                    let v1074: &str = &*v1071;
                                    let v1097: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v30.clone(), v1074).cloned();
                                    let v1099: Option<string> = map(Spiral::method150(), v1097);
                                    let v1113: string = v1099.unwrap();
                                    let v1114: string = Spiral::method178();
                                    let v1117: &str = &*v1114;
                                    let v1141: u8 = defaultValue(
                                        1_u8,
                                        clap::ArgMatches::get_one(&v30.clone(), v1117).cloned(),
                                    );
                                    let v1144: string = Spiral::method179();
                                    let v1147: &str = &*v1144;
                                    let v1170: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v30.clone(), v1147).cloned();
                                    let v1184: Spiral::US7 = defaultValue(
                                        Spiral::US7::US7_1,
                                        map(Spiral::method23(), v1170),
                                    );
                                    let patternInput_6: (i32, string) = Spiral::method180(
                                        match &v1184 {
                                            Spiral::US7::US7_0(v1184_0_0) => Spiral::US5::US5_0(
                                                fable_library_rust::String_::fromString(
                                                    match &v1184 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                            ),
                                            _ => Spiral::US5::US5_1,
                                        },
                                        v1141,
                                        v1113.clone(),
                                        1_u8,
                                    );
                                    let v1197: string = patternInput_6.1.clone();
                                    let v1196: i32 = patternInput_6.0.clone();
                                    let patternInput_9: (i32, string) = if (v1196) != 0_i32 {
                                        (v1196, v1197.clone())
                                    } else {
                                        let patternInput_7: (i32, string) = Spiral::method65(
                                            concat(new_array(&[
                                                string("jupyter nbconvert \""),
                                                v1113.clone(),
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
                                        let v1209: string = patternInput_7.1.clone();
                                        let v1208: i32 = patternInput_7.0.clone();
                                        let v1212: () = {
                                            Spiral::closure77(v1209.clone(), v1208, ());
                                            ()
                                        };
                                        if (v1208) != 0_i32 {
                                            (
                                                v1208,
                                                concat(new_array(&[
                                                    string("repl_result: "),
                                                    v1197.clone(),
                                                    string("\n\njupyter_result: "),
                                                    v1209.clone(),
                                                ])),
                                            )
                                        } else {
                                            let patternInput_8:
                                                    (i32, string) =
                                                Spiral::method65(concat(new_array(&[string("pwsh -c \"$counter = 1; $path = \'"),
                                                                                    replace(v1113.clone(),
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
                                            let v1268: string = patternInput_8.1.clone();
                                            let v1267: i32 = patternInput_8.0.clone();
                                            let v1271: () = {
                                                Spiral::closure78(v1268.clone(), v1267, ());
                                                ()
                                            };
                                            let v1312: string = concat(new_array(&[
                                                v1113.clone(),
                                                string(".html"),
                                            ]));
                                            let v1316: Result<Vec<u8>, std::io::Error> =
                                                std::fs::read(&*v1312);
                                            let v1354: Vec<u8> = Spiral::method27(v1316.unwrap());
                                            let v1356: Result<
                                                std::string::String,
                                                std::string::FromUtf8Error,
                                            > = std::string::String::from_utf8(v1354);
                                            let v1359: std::string::String = v1356.unwrap();
                                            let v1396: string = replace(
                                                fable_library_rust::String_::fromString(v1359),
                                                string("\r\n"),
                                                string("\n"),
                                            );
                                            let v1397: string = concat(new_array(&[
                                                v1113.clone(),
                                                string(".html"),
                                            ]));
                                            std::fs::write(&*v1397, &*v1396).unwrap();
                                            {
                                                let v1400: string = concat(new_array(&[
                                                    v1113.clone(),
                                                    string(".ipynb"),
                                                ]));
                                                let v1404: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v1400);
                                                let v1442: Vec<u8> =
                                                    Spiral::method27(v1404.unwrap());
                                                let v1444: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v1442);
                                                let v1447: std::string::String = v1444.unwrap();
                                                let v1485: string = replace(
                                                    replace(
                                                        fable_library_rust::String_::fromString(
                                                            v1447,
                                                        ),
                                                        string("\r\n"),
                                                        string("\n"),
                                                    ),
                                                    string("\\r\\n"),
                                                    string("\\n"),
                                                );
                                                let v1486: string =
                                                    concat(new_array(&[v1113, string(".ipynb")]));
                                                std::fs::write(&*v1486, &*v1485).unwrap();
                                                (v1267,
                                                 sprintf!("repl_result: {}\n\njupyter_result: {}\n\npwsh_replace_html_result: {}",
                                                          v1197, v1209,
                                                          v1268))
                                            }
                                        }
                                    };
                                    let v1493: string = patternInput_9.1.clone();
                                    let v1492: i32 = patternInput_9.0.clone();
                                    let v1496: () = {
                                        Spiral::closure79(v1493.clone(), v1492, ());
                                        ()
                                    };
                                    if (v1492) != 0_i32 {
                                        panic!(
                                            "{}",
                                            sprintf!(
                                                "spiral.run / dib / exit_code: {} / result: {}",
                                                v1492,
                                                v1493.clone()
                                            )
                                        );
                                    }
                                    new_array(&[(string("stdio"), v1493)])
                                } else {
                                    let patternInput_32: (
                                        Spiral::US5,
                                        Spiral::US5,
                                        Spiral::US5,
                                        Spiral::US5,
                                    ) = if (fable_library_rust::String_::fromString(v29.clone()))
                                        == string("rust")
                                    {
                                        let v1546: string = Spiral::method147();
                                        let v1549: &str = &*v1546;
                                        let v1572: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v30.clone(), v1549).cloned();
                                        let v1586: Spiral::US7 = defaultValue(
                                            Spiral::US7::US7_1,
                                            map(Spiral::method23(), v1572),
                                        );
                                        let v1593: std::string::String = match &v1586 {
                                            Spiral::US7::US7_0(v1586_0_0) => match &v1586 {
                                                Spiral::US7::US7_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => panic!(
                                                "{}",
                                                string("Option does not have a value."),
                                            ),
                                        };
                                        let v1595: string =
                                            fable_library_rust::String_::fromString(v1593);
                                        let v1596: string = Spiral::method25();
                                        let v1599: &str = &*v1596;
                                        let v1622: Option<Vec<std::string::String>> =
                                            clap::ArgMatches::get_many(&v30.clone(), v1599)
                                                .map(|x| x.cloned().into_iter().collect());
                                        let v1636: Spiral::US11 = defaultValue(
                                            Spiral::US11::US11_1,
                                            map(Spiral::method26(), v1622),
                                        );
                                        let v1642: Vec<std::string::String> =
                                            new_empty::<std::string::String>().to_vec();
                                        let v1645: Vec<std::string::String> = match &v1636 {
                                            Spiral::US11::US11_0(v1636_0_0) => match &v1636 {
                                                Spiral::US11::US11_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => v1642.clone(),
                                        };
                                        let v1646: string = Spiral::method189();
                                        let v1649: &str = &*v1646;
                                        let v1672: bool =
                                            clap::ArgMatches::get_flag(&v30.clone(), v1649);
                                        let v1673: string = Spiral::method190();
                                        let v1676: &str = &*v1673;
                                        let v1699: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v30.clone(), v1676).cloned();
                                        let v1713: Spiral::US7 = defaultValue(
                                            Spiral::US7::US7_1,
                                            map(Spiral::method23(), v1699),
                                        );
                                        let v1723: Spiral::US5 = match &v1713 {
                                            Spiral::US7::US7_0(v1713_0_0) => Spiral::US5::US5_0(
                                                fable_library_rust::String_::fromString(
                                                    match &v1713 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                            ),
                                            _ => Spiral::US5::US5_1,
                                        };
                                        let v1724: string = Spiral::method191();
                                        let v1727: &str = &*v1724;
                                        let v1750: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v30.clone(), v1727).cloned();
                                        let v1764: Spiral::US7 = defaultValue(
                                            Spiral::US7::US7_1,
                                            map(Spiral::method23(), v1750),
                                        );
                                        let v1774: Spiral::US5 = match &v1764 {
                                            Spiral::US7::US7_0(v1764_0_0) => Spiral::US5::US5_0(
                                                fable_library_rust::String_::fromString(
                                                    match &v1764 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                            ),
                                            _ => Spiral::US5::US5_1,
                                        };
                                        let v1783: Spiral::US35 =
                                            if let Spiral::US5::US5_0(v1723_0_0) = &v1723 {
                                                Spiral::US35::US35_0(Spiral::US36::US36_0(
                                                    v1723_0_0.clone(),
                                                ))
                                            } else {
                                                if let Spiral::US5::US5_0(v1774_0_0) = &v1774 {
                                                    Spiral::US35::US35_0(Spiral::US36::US36_1(
                                                        v1774_0_0.clone(),
                                                    ))
                                                } else {
                                                    Spiral::US35::US35_1
                                                }
                                            };
                                        let v1787: Result<Vec<u8>, std::io::Error> =
                                            std::fs::read(&*v1595);
                                        let v1825: Vec<u8> = Spiral::method27(v1787.unwrap());
                                        let v1827: Result<
                                            std::string::String,
                                            std::string::FromUtf8Error,
                                        > = std::string::String::from_utf8(v1825);
                                        let v1830: std::string::String = v1827.unwrap();
                                        let v1860: string =
                                            fable_library_rust::String_::fromString(v1830);
                                        let v1867: string = Spiral::method193(Spiral::method192(
                                            string("rs"),
                                            v1860.clone(),
                                            v1783.clone(),
                                        ));
                                        let v1872: Spiral::US12 = Spiral::method29(
                                            Spiral::method28(
                                                string("polyglot"),
                                                string("workspace"),
                                            ),
                                            string(
                                                "C:\\home\\git\\polyglot\\target\\Builder\\spiral",
                                            ),
                                        );
                                        let v1920: Spiral::US5 = match &v1872 {
                                            Spiral::US12::US12_0(v1872_0_0) => {
                                                Spiral::US5::US5_0(v1872_0_0.clone())
                                            }
                                            Spiral::US12::US12_1(v1872_1_0) => {
                                                let v1878: () = {
                                                    Spiral::closure15(v1872_1_0.clone(), ());
                                                    ()
                                                };
                                                Spiral::US5::US5_1
                                            }
                                        };
                                        let v1975: Spiral::US5 = match &v1920 {
                                            Spiral::US5::US5_0(v1920_0_0) => Spiral::US5::US5_0(
                                                match &v1920 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            ),
                                            _ => {
                                                let v1923: string = Spiral::method36();
                                                let v1925: Spiral::US12 = Spiral::method29(
                                                    Spiral::method28(
                                                        string("polyglot"),
                                                        string("workspace"),
                                                    ),
                                                    v1923,
                                                );
                                                match &v1925 {
                                                    Spiral::US12::US12_0(v1925_0_0) => {
                                                        Spiral::US5::US5_0(v1925_0_0.clone())
                                                    }
                                                    Spiral::US12::US12_1(v1925_1_0) => {
                                                        let v1931: () = {
                                                            Spiral::closure15(
                                                                v1925_1_0.clone(),
                                                                (),
                                                            );
                                                            ()
                                                        };
                                                        Spiral::US5::US5_1
                                                    }
                                                }
                                            }
                                        };
                                        let v1980: string = Spiral::method28(
                                            match &v1975 {
                                                Spiral::US5::US5_0(v1975_0_0) => match &v1975 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            },
                                            string("polyglot"),
                                        );
                                        let v1983: string = toLower(Spiral::method36());
                                        let v1987: string = toLower(v1980);
                                        let v1995: Spiral::US12 =
                                            if startsWith3(v1983, v1987.clone(), false) {
                                                Spiral::US12::US12_1(v1987.clone())
                                            } else {
                                                Spiral::US12::US12_0(v1987)
                                            };
                                        let v2001: Result<string, string> = match &v1995 {
                                            Spiral::US12::US12_0(v1995_0_0) => {
                                                Ok::<string, string>(v1995_0_0.clone())
                                            }
                                            Spiral::US12::US12_1(v1995_1_0) => {
                                                Err::<string, string>(v1995_1_0.clone())
                                            }
                                        };
                                        let v2003: bool = true;
                                        let _result_unwrap_or_else = v2001.unwrap_or_else(|x| {
                                            //;
                                            let v2005: string = x;
                                            let v2007: bool = true;
                                            v2005
                                        });
                                        let v2009: string = _result_unwrap_or_else;
                                        let v2014: string = Spiral::method196(
                                            Spiral::US5::US5_0(v1867.clone()),
                                            string("spiral"),
                                            Spiral::US38::US38_0(Spiral::US37::US37_0),
                                            v2009.clone(),
                                        );
                                        let v2019: string = Spiral::method197(
                                            v1860,
                                            string("spiral"),
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                            LrcPtr::new(Spiral::UH2::UH2_1(
                                                string("Fable.Core"),
                                                LrcPtr::new(Spiral::UH2::UH2_0),
                                            )),
                                            v2014.clone(),
                                            v2009.clone(),
                                        );
                                        let v2021: string =
                                            Spiral::method28(v2014.clone(), string("../../.."));
                                        let v2023: string =
                                            Spiral::method28(v2021.clone(), string("Cargo.toml"));
                                        if (Spiral::method40(v2023.clone())) == false {
                                            let v2027: DateTime = DateTime::now();
                                            let v2047: string =
                                                toString(Spiral::method200(new_guid(), v2027));
                                            let v2072: string =
                                                append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                       (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                           v2047.clone(),
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
                                                                                           v2047,
                                                                                           string("\"")]))))),
                                                               string("\n"))),
                                                       string("path = \"spiral.rs\""));
                                            std::fs::write(&*v2023.clone(), &*v2072).unwrap();
                                            ()
                                        }
                                        {
                                            let v2075: string = Spiral::method28(
                                                v2014.clone(),
                                                string("Cargo.toml"),
                                            );
                                            if (Spiral::method40(v2075.clone())) == false {
                                                let v2079: DateTime = DateTime::now();
                                                let v2099: string =
                                                    toString(Spiral::method200(new_guid(), v2079));
                                                let v2124: string =
                                                    append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                               v2099.clone(),
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
                                                                                               v2099,
                                                                                               string("\"")]))))),
                                                                   string("\n"))),
                                                           string("path = \"spiral.rs\""));
                                                std::fs::write(&*v2075.clone(), &*v2124).unwrap();
                                                ()
                                            }
                                            {
                                                let v2128: string =
                                                    Spiral::method28(v2009.clone(),
                                                                     string("lib/rust/fable/fable_modules/fable-library-rust"));
                                                let v2130: string = Spiral::method28(
                                                    v2014.clone(),
                                                    string("fable_modules/fable-library-rust"),
                                                );
                                                Spiral::method205(v2128, v2130.clone());
                                                {
                                                    let patternInput_10: (i32, string) =
                                                        Spiral::method206(
                                                            v1783.clone(),
                                                            v2014.clone(),
                                                            string("rs"),
                                                            v2019,
                                                            v1995.clone(),
                                                        );
                                                    let v2132: string = patternInput_10.1.clone();
                                                    let v2131: i32 = patternInput_10.0.clone();
                                                    let patternInput_19: (
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                    ) = if (v2131) != 0_i32 {
                                                        let v2138: () = {
                                                            Spiral::closure82(
                                                                v2132.clone(),
                                                                v2131,
                                                                (),
                                                            );
                                                            ()
                                                        };
                                                        (
                                                            Spiral::US5::US5_0(string("rs")),
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_0(v2132),
                                                        )
                                                    } else {
                                                        let v2258: Vec<std::string::String> =
                                                            if if let Spiral::US35::US35_1 = &v1783
                                                            {
                                                                true
                                                            } else {
                                                                false
                                                            } {
                                                                v1645.clone()
                                                            } else {
                                                                let v2183 = Spiral::method216();
                                                                let v2184: Vec<
                                                                    std::string::String,
                                                                > = Spiral::method217(
                                                                    v1645.clone(),
                                                                );
                                                                let v2186: Vec<
                                                                    std::string::String,
                                                                > = v2184
                                                                    .into_iter()
                                                                    .filter(|x| {
                                                                        v2183(x.clone().clone())
                                                                    })
                                                                    .collect::<Vec<_>>();
                                                                if (v2186.len() as i32) > 0_i32 {
                                                                    v1645.clone()
                                                                } else {
                                                                    let v2200: &str =
                                                                        &*string("near-sdk");
                                                                    let v2246: Array<
                                                                        std::string::String,
                                                                    > = new_array(&[String::from(
                                                                        v2200,
                                                                    )]);
                                                                    let v2249: Vec<
                                                                        std::string::String,
                                                                    > = Spiral::method218(
                                                                        v2246.to_vec(),
                                                                    );
                                                                    let v2250: Vec<
                                                                        std::string::String,
                                                                    > = Spiral::method219(v1645);
                                                                    let v2252: bool = true;
                                                                    let mut v2250 = v2250;
                                                                    let v2254: bool = true;
                                                                    v2250.extend(v2249);
                                                                    v2250
                                                                }
                                                            };
                                                        let v2260: bool = true;
                                                        let _vec_map : Vec<_> = v2258.into_iter().map(|x| { //;
                                                            let v2262:
                                                                    std::string::String =
                                                                x;
                                                            let v2264:
                                                                    string =
                                                                fable_library_rust::String_::fromString(v2262);
                                                            let v2279:
                                                                    string =
                                                                if contains(v2264.clone(),
                                                                            string("="))
                                                                   {
                                                                    v2264.clone()
                                                                } else {
                                                                    if endsWith3(v2264.clone(),
                                                                                 string("]"),
                                                                                 false)
                                                                       {
                                                                        concat(new_array(&[replace(v2264.clone(),
                                                                                                   string("["),
                                                                                                   string("={version=\'*\',features=[")),
                                                                                           string("}")]))
                                                                    } else {
                                                                        concat(new_array(&[v2264,
                                                                                           string("=\'*\'")]))
                                                                    }
                                                                };
                                                            let v2281: bool =
                                                                true; v2279 }).collect::<Vec<_>>();
                                                        let v2283: Vec<string> = _vec_map;
                                                        let v2285:
                                                                    Array<string> =
                                                                fable_library_rust::NativeArray_::array_from(v2283.clone());
                                                        let _let__v2286: LrcPtr<
                                                            dyn IEnumerable_1<string>,
                                                        > = delay(Func0::new({
                                                            let v2285 = v2285.clone();
                                                            move || {
                                                                map_1(
                                                                    Func1::new({
                                                                        let v2285 = v2285.clone();
                                                                        move |i_1: i32| {
                                                                            v2285[i_1].clone()
                                                                        }
                                                                    }),
                                                                    rangeNumeric(
                                                                        0_i32,
                                                                        1_i32,
                                                                        (get_Count(v2285.clone()))
                                                                            - 1_i32,
                                                                    ),
                                                                )
                                                            }
                                                        }));
                                                        let v2298: string = join(
                                                            Spiral::method37(),
                                                            toArray_1(_let__v2286),
                                                        );
                                                        let v2303: string = Spiral::method28(
                                                            v2014,
                                                            concat(new_array(&[
                                                                string("spiral"),
                                                                string("."),
                                                                string("rs"),
                                                            ])),
                                                        );
                                                        let v2307: Result<Vec<u8>, std::io::Error> =
                                                            std::fs::read(&*v2303.clone());
                                                        let v2345: Vec<u8> =
                                                            Spiral::method27(v2307.unwrap());
                                                        let v2347: Result<
                                                            std::string::String,
                                                            std::string::FromUtf8Error,
                                                        > = std::string::String::from_utf8(v2345);
                                                        let v2350: std::string::String =
                                                            v2347.unwrap();
                                                        let v2380: string =
                                                            fable_library_rust::String_::fromString(
                                                                v2350,
                                                            );
                                                        let v2387: string = append(
                                                            string("on_startup!"),
                                                            (Spiral::method220()),
                                                        );
                                                        let v2390: string = append(
                                                            string(" method0"),
                                                            (Spiral::method221()),
                                                        );
                                                        let v2398: bool = if contains(
                                                            v2380.clone(),
                                                            v2387.clone(),
                                                        ) {
                                                            (contains(v2380, v2390)) == false
                                                        } else {
                                                            false
                                                        };
                                                        let v2461:
                                                                    string =
                                                                append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                                                                                                       (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                                                                                           v1867.clone(),
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
                                                                                                                                                       (if !((v1783.clone())
                                                                                                                                                                 ==
                                                                                                                                                                 Spiral::US35::US35_1)
                                                                                                                                                           {
                                                                                                                                                            string("fable_library_rust = { workspace = true }")
                                                                                                                                                        } else {
                                                                                                                                                            append((append((append(string("fable_library_rust = { workspace = true, features = ["),
                                                                                                                                                                                   (if v2398
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
                                                                                                                       (v2298))),
                                                                                                               string("\n"))),
                                                                                                       string(""))),
                                                                                               string("\n"))),
                                                                                       (if if let Spiral::US35::US35_1
                                                                                                  =
                                                                                                  &v1783
                                                                                              {
                                                                                               true
                                                                                           } else {
                                                                                               false
                                                                                           }
                                                                                           {
                                                                                            append(string("[[bin]]\n"),
                                                                                                   (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                       v1867.clone(),
                                                                                                                       string("\"")]))))
                                                                                        } else {
                                                                                            string("[lib]\ncrate-type = [\"cdylib\"]")
                                                                                        }))),
                                                                               string("\n"))),
                                                                       string("path = \"spiral.rs\""));
                                                        let v2526:
                                                                    string =
                                                                append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("cargo-features = [\"profile-rustflags\"]\n\n[workspace]\nresolver = \"2\"\nmembers = [\"packages/Rust/*\"]\n\n[workspace.dependencies.fable_library_rust]\n"),
                                                                                                                                                                                                                                                                                                       (concat(new_array(&[string("path = \""),
                                                                                                                                                                                                                                                                                                                           Spiral::method154(v2009.clone()),
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
                                                        Spiral::method38(v2075.clone(), v2461);
                                                        Spiral::method38(v2023, v2526);
                                                        {
                                                            let v2528: string = Spiral::method28(
                                                                v2130,
                                                                string("src/Range.rs"),
                                                            );
                                                            if Spiral::method40(v2528.clone()) {
                                                                let v2533: Result<
                                                                    Vec<u8>,
                                                                    std::io::Error,
                                                                > = std::fs::read(&*v2528.clone());
                                                                let v2571: Vec<u8> =
                                                                    Spiral::method27(
                                                                        v2533.unwrap(),
                                                                    );
                                                                let v2573: Result<
                                                                    std::string::String,
                                                                    std::string::FromUtf8Error,
                                                                > = std::string::String::from_utf8(
                                                                    v2571,
                                                                );
                                                                let v2576: std::string::String =
                                                                    v2573.unwrap();
                                                                Spiral::method38(v2528,
                                                                                     replace(replace(fable_library_rust::String_::fromString(v2576),
                                                                                                     string("use crate::String_::fromCharCode;"),
                                                                                                     string("use crate::String_::fromChar;")),
                                                                                             string("fromCharCode(c)"),
                                                                                             string("std::char::from_u32(c).unwrap()")))
                                                            }
                                                            {
                                                                let patternInput_11: (i32, string) =
                                                                    Spiral::method222(
                                                                        v1995.clone(),
                                                                        v2075.clone(),
                                                                        1_u8,
                                                                    );
                                                                let v2618: i32 =
                                                                    patternInput_11.0.clone();
                                                                if (v2618) != 0_i32 {
                                                                    let v2625: () = {
                                                                        Spiral::closure86(
                                                                            patternInput_11
                                                                                .1
                                                                                .clone(),
                                                                            v2618,
                                                                            (),
                                                                        );
                                                                        ()
                                                                    };
                                                                    ()
                                                                }
                                                                {
                                                                    let v2668: Result<
                                                                        Vec<u8>,
                                                                        std::io::Error,
                                                                    > = std::fs::read(
                                                                        &*v2303.clone(),
                                                                    );
                                                                    let v2706: Vec<u8> =
                                                                        Spiral::method27(
                                                                            v2668.unwrap(),
                                                                        );
                                                                    let v2708:
                                                                                Result<std::string::String,
                                                                                       std::string::FromUtf8Error> =
                                                                            std::string::String::from_utf8(v2706);
                                                                    let v2711: std::string::String =
                                                                        v2708.unwrap();
                                                                    let v2741:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v2711);
                                                                    let v2748:
                                                                                string =
                                                                            append(string("pub fn main() -> Result<(), String> "),
                                                                                   (Spiral::method228()));
                                                                    let v2794:
                                                                                string =
                                                                            append((append((if if let Spiral::US35::US35_1
                                                                                                      =
                                                                                                      &v1783
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
                                                                                   (if if if let Spiral::US35::US35_1
                                                                                                 =
                                                                                                 &v1783
                                                                                             {
                                                                                              true
                                                                                          } else {
                                                                                              false
                                                                                          }
                                                                                          {
                                                                                           contains(v2741.clone(),
                                                                                                    append((v2387.clone()),
                                                                                                           string("Spiral::method0()")))
                                                                                       } else {
                                                                                           false
                                                                                       }
                                                                                       {
                                                                                        concat(new_array(&[v2748.clone(),
                                                                                                           string(" Ok(Spiral::method0()) }")]))
                                                                                    } else {
                                                                                        concat(new_array(&[v2748.clone(),
                                                                                                           string(" Ok(()) }")]))
                                                                                    }));
                                                                    let v2795: bool = contains(
                                                                        v2741.clone(),
                                                                        v2748,
                                                                    );
                                                                    let v2882: string = if v2795 {
                                                                        v2741.clone()
                                                                    } else {
                                                                        (if (if let Spiral::US35::US35_0(v1783_0_0)
                                                                                            =
                                                                                            &v1783
                                                                                        {
                                                                                         if let Spiral::US36::US36_1(v1783_1_0)
                                                                                                =
                                                                                                &v1783_0_0
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
                                                                                                    Spiral::closure87((),
                                                                                                                      v_5))
                                                                                 } else {
                                                                                     let v2878:
                                                                                             string =
                                                                                         string("use fable_library_rust::DateTime_::DateTime;");
                                                                                     Func1::new({
                                                                                                    let v2878
                                                                                                        =
                                                                                                        v2878.clone();
                                                                                                    move
                                                                                                        |v_6:
                                                                                                             string|
                                                                                                        Spiral::closure89(v2878.clone(),
                                                                                                                          v_6)
                                                                                                })
                                                                                 })((if v2398
                                                                                        {
                                                                                         Func1::new(move
                                                                                                        |v_3:
                                                                                                             string|
                                                                                                        Spiral::closure87((),
                                                                                                                          v_3))
                                                                                     } else {
                                                                                         let v2870:
                                                                                                 string =
                                                                                             append(string("// "),
                                                                                                    (v2387.clone()));
                                                                                         Func1::new({
                                                                                                        let v2387
                                                                                                            =
                                                                                                            v2387.clone();
                                                                                                        let v2870
                                                                                                            =
                                                                                                            v2870.clone();
                                                                                                        move
                                                                                                            |v_4:
                                                                                                                 string|
                                                                                                            Spiral::closure88(v2387.clone(),
                                                                                                                              v2870.clone(),
                                                                                                                              v_4)
                                                                                                    })
                                                                                     })(replace(replace(replace(replace(replace(replace(replace(replace(replace(Spiral::method173(string("\\s\\sgetZero\\(\\);"),
                                                                                                                                                                                  string(" getZero::<()>();"),
                                                                                                                                                                                  Spiral::method173(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                                                                                                                    string(" defaultOf::<()>();"),
                                                                                                                                                                                                    replace(replace(concat(new_array(&[v2741,
                                                                                                                                                                                                                                       string("\n\n"),
                                                                                                                                                                                                                                       v2794,
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
                                                                    if (v2795) == false {
                                                                        Spiral::method38(
                                                                            v2303.clone(),
                                                                            v2882.clone(),
                                                                        );
                                                                    }
                                                                    {
                                                                        let v2888:
                                                                                    string =
                                                                                if (if let Spiral::US35::US35_1
                                                                                           =
                                                                                           &v1783
                                                                                       {
                                                                                        true
                                                                                    } else {
                                                                                        false
                                                                                    })
                                                                                       !=
                                                                                       true
                                                                                   {
                                                                                    concat(new_array(&[string("cargo +nightly-2024-07-14 build --release --target wasm32-unknown-unknown --manifest-path \""),
                                                                                                       v2075.clone(),
                                                                                                       string("\"")]))
                                                                                } else {
                                                                                    concat(new_array(&[string("cargo run --manifest-path \""),
                                                                                                       v2075,
                                                                                                       string("\"")]))
                                                                                };
                                                                        let v2901:
                                                                                    Array<(string,
                                                                                           string)> =
                                                                                if (if let Spiral::US35::US35_1
                                                                                           =
                                                                                           &v1783
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
                                                                        let v2912:
                                                                                    Result<string,
                                                                                           string> =
                                                                                match &v1995
                                                                                    {
                                                                                    Spiral::US12::US12_0(v1995_0_0)
                                                                                    =>
                                                                                    Ok::<string,
                                                                                         string>(v1995_0_0.clone()),
                                                                                    Spiral::US12::US12_1(v1995_1_0)
                                                                                    =>
                                                                                    Err::<string,
                                                                                          string>(v1995_1_0.clone()),
                                                                                };
                                                                        let patternInput_12:
                                                                                    (i32,
                                                                                     string) =
                                                                                Spiral::method65(v2888.clone(),
                                                                                                 None::<CancellationToken>,
                                                                                                 v2901.clone(),
                                                                                                 None::<Func1<(i32,
                                                                                                               string,
                                                                                                               bool),
                                                                                                              Arc<Async<()>>>>,
                                                                                                 None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                              ()>>,
                                                                                                 true,
                                                                                                 v2912.ok());
                                                                        let v2929: string =
                                                                            patternInput_12
                                                                                .1
                                                                                .clone();
                                                                        let v2928: i32 =
                                                                            patternInput_12
                                                                                .0
                                                                                .clone();
                                                                        let patternInput_18:
                                                                                    (Spiral::US5,
                                                                                     Spiral::US5,
                                                                                     Spiral::US5,
                                                                                     Spiral::US5) =
                                                                                if if let Spiral::US35::US35_1
                                                                                          =
                                                                                          &v1783
                                                                                      {
                                                                                       true
                                                                                   } else {
                                                                                       false
                                                                                   }
                                                                                   {
                                                                                    let v2931:
                                                                                            i32 =
                                                                                        get_Count(v2901.clone());
                                                                                    let v2932:
                                                                                            Array<string> =
                                                                                        new_init(&string(""),
                                                                                                 v2931);
                                                                                    let v2933:
                                                                                            LrcPtr<Spiral::Mut5> =
                                                                                        LrcPtr::new(Spiral::Mut5{l0:
                                                                                                                     MutCell::new(0_i32),});
                                                                                    while Spiral::method69(v2931,
                                                                                                           v2933.clone())
                                                                                          {
                                                                                        let v2935:
                                                                                                i32 =
                                                                                            v2933.l0.get().clone();
                                                                                        let patternInput_13:
                                                                                                (string,
                                                                                                 string) =
                                                                                            v2901[v2935].clone();
                                                                                        let v2938:
                                                                                                string =
                                                                                            sprintf!("$env:{}=\'\'{}\'\'",
                                                                                                     patternInput_13.0.clone(),
                                                                                                     patternInput_13.1.clone());
                                                                                        v2932.get_mut()[v2935
                                                                                                            as
                                                                                                            usize]
                                                                                            =
                                                                                            v2938;
                                                                                        {
                                                                                            let v2939:
                                                                                                    i32 =
                                                                                                (v2935)
                                                                                                    +
                                                                                                    1_i32;
                                                                                            v2933.l0.set(v2939);
                                                                                            ()
                                                                                        }
                                                                                    }
                                                                                    {
                                                                                        let v2958:
                                                                                                string =
                                                                                            concat(new_array(&[string("pwsh -c \'"),
                                                                                                               join(string(";"),
                                                                                                                    toArray_1(ofArray_1(new_array(&[join(string(";"),
                                                                                                                                                         toArray_1(ofArray_1(v2932.clone()))),
                                                                                                                                                    v2888])))),
                                                                                                               string("\'")]));
                                                                                        let patternInput_14:
                                                                                                (Spiral::US5,
                                                                                                 Spiral::US5,
                                                                                                 Spiral::US5,
                                                                                                 Spiral::US5) =
                                                                                            if (v2928)
                                                                                                   !=
                                                                                                   0_i32
                                                                                               {
                                                                                                let v2964:
                                                                                                        () =
                                                                                                    {
                                                                                                        Spiral::closure90(v1672,
                                                                                                                          v2303.clone(),
                                                                                                                          v2929.clone(),
                                                                                                                          v2928,
                                                                                                                          v2958.clone(),
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
                                                                                                              result_1.set(Spiral::closure61((),
                                                                                                                                             Spiral::closure91(v2929.clone(),
                                                                                                                                                               ()))),
                                                                                                          |ex_1:
                                                                                                               LrcPtr<Exception>|
                                                                                                              result_1.set(Spiral::closure93(v2303.clone(),
                                                                                                                                             v2929.clone(),
                                                                                                                                             v2958,
                                                                                                                                             ex_1.clone())));
                                                                                                {
                                                                                                    let v3012:
                                                                                                            Spiral::US5 =
                                                                                                        result_1.get().clone();
                                                                                                    let v3022:
                                                                                                            Option<string> =
                                                                                                        match &v3012
                                                                                                            {
                                                                                                            Spiral::US5::US5_0(v3012_0_0)
                                                                                                            =>
                                                                                                            Some(match &v3012
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
                                                                                                     Spiral::US5::US5_0(v2882.clone()),
                                                                                                     Spiral::US5::US5_0(v2303.clone()),
                                                                                                     Spiral::US5::US5_0(v3022.unwrap()))
                                                                                                }
                                                                                            };
                                                                                        (patternInput_14.0.clone(),
                                                                                         patternInput_14.1.clone(),
                                                                                         patternInput_14.2.clone(),
                                                                                         patternInput_14.3.clone())
                                                                                    }
                                                                                } else {
                                                                                    let v3033:
                                                                                            string =
                                                                                        sprintf!("target/spiral/{}/target/wasm32-unknown-unknown/release/spiral_{}.wasm",
                                                                                                 string("spiral"),
                                                                                                 v1867.clone());
                                                                                    let v3045:
                                                                                            string =
                                                                                        sprintf!("pwsh -c \"pwsh {} {} -Linux -EnvironmentVariables AUTOMATION={}`nNEAR_RPC_TIMEOUT_SECS=100\"",
                                                                                                 string("scripts/invoke-block.ps1"),
                                                                                                 sprintf!("\'deps/spiral/workspace/target/release/spiral_wasm -w {} -t Debug {}\'",
                                                                                                          v3033.clone(),
                                                                                                          if let Spiral::US35::US35_0(v1783_0_0)
                                                                                                                 =
                                                                                                                 &v1783
                                                                                                             {
                                                                                                              let v3034:
                                                                                                                      Spiral::US36 =
                                                                                                                  v1783_0_0.clone();
                                                                                                              match &v3034
                                                                                                                  {
                                                                                                                  Spiral::US36::US36_0(v3034_0_0)
                                                                                                                  =>
                                                                                                                  v3034_0_0.clone(),
                                                                                                                  Spiral::US36::US36_1(v3034_1_0)
                                                                                                                  =>
                                                                                                                  v3034_1_0.clone(),
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
                                                                                        if (v2928)
                                                                                               ==
                                                                                               0_i32
                                                                                           {
                                                                                            let patternInput_15:
                                                                                                    (i32,
                                                                                                     string) =
                                                                                                Spiral::method65(v3045.clone(),
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
                                                                                                                 Some(v2009));
                                                                                            let v3057:
                                                                                                    string =
                                                                                                patternInput_15.1.clone();
                                                                                            let v3056:
                                                                                                    i32 =
                                                                                                patternInput_15.0.clone();
                                                                                            let patternInput_16:
                                                                                                    (Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5) =
                                                                                                if (v3056)
                                                                                                       ==
                                                                                                       0_i32
                                                                                                   {
                                                                                                    (Spiral::US5::US5_0(string("rs")),
                                                                                                     Spiral::US5::US5_0(v2882),
                                                                                                     Spiral::US5::US5_0(v2303.clone()),
                                                                                                     Spiral::US5::US5_0(v3057.clone()))
                                                                                                } else {
                                                                                                    let v3065:
                                                                                                            () =
                                                                                                        {
                                                                                                            Spiral::closure95(v1672,
                                                                                                                              v2303.clone(),
                                                                                                                              v2929.clone(),
                                                                                                                              v3057,
                                                                                                                              v3056,
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
                                                                                            let v3116:
                                                                                                    () =
                                                                                                {
                                                                                                    Spiral::closure96(v1672,
                                                                                                                      v2303.clone(),
                                                                                                                      v2929,
                                                                                                                      v2928,
                                                                                                                      v3033,
                                                                                                                      v3045,
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
                                                                        if v1672 {
                                                                            let v3173:
                                                                                        string =
                                                                                    if (if let Spiral::US35::US35_1
                                                                                               =
                                                                                               &v1783
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
                                                                            let v3176:
                                                                                        string =
                                                                                    Spiral::method28(v2021.clone(),
                                                                                                     sprintf!("target/{}/spiral_{}{}",
                                                                                                              v3173.clone(),
                                                                                                              v1867.clone(),
                                                                                                              string("")));
                                                                            let v3179:
                                                                                        string =
                                                                                    Spiral::method28(v2021.clone(),
                                                                                                     sprintf!("target/{}/spiral_{}{}",
                                                                                                              v3173.clone(),
                                                                                                              v1867.clone(),
                                                                                                              string(".wasm")));
                                                                            let v3182:
                                                                                        string =
                                                                                    Spiral::method28(v2021.clone(),
                                                                                                     sprintf!("target/{}/spiral_{}{}",
                                                                                                              v3173.clone(),
                                                                                                              v1867.clone(),
                                                                                                              string(".pdb")));
                                                                            let v3185:
                                                                                        string =
                                                                                    Spiral::method28(v2021.clone(),
                                                                                                     sprintf!("target/{}/spiral_{}{}",
                                                                                                              v3173.clone(),
                                                                                                              v1867.clone(),
                                                                                                              string(".exe")));
                                                                            let v3188:
                                                                                        string =
                                                                                    Spiral::method28(v2021,
                                                                                                     sprintf!("target/{}/spiral_{}{}",
                                                                                                              v3173,
                                                                                                              v1867,
                                                                                                              string(".d")));
                                                                            let v3189: bool =
                                                                                Spiral::method40(
                                                                                    v3176.clone(),
                                                                                );
                                                                            let v3190: bool =
                                                                                Spiral::method40(
                                                                                    v3179.clone(),
                                                                                );
                                                                            let v3191: bool =
                                                                                Spiral::method40(
                                                                                    v3182.clone(),
                                                                                );
                                                                            let v3192: bool =
                                                                                Spiral::method40(
                                                                                    v3185.clone(),
                                                                                );
                                                                            let v3193: bool =
                                                                                Spiral::method40(
                                                                                    v3188.clone(),
                                                                                );
                                                                            let v3196: () = {
                                                                                Spiral::closure97(
                                                                                    v2303,
                                                                                    v3188.clone(),
                                                                                    v3193,
                                                                                    v3185.clone(),
                                                                                    v3192,
                                                                                    v3182.clone(),
                                                                                    v3191,
                                                                                    v3179.clone(),
                                                                                    v3190,
                                                                                    v3176.clone(),
                                                                                    v3189,
                                                                                    (),
                                                                                );
                                                                                ()
                                                                            };
                                                                            let v3239: LrcPtr<
                                                                                Spiral::UH4,
                                                                            > = if v3189 {
                                                                                LrcPtr::new(Spiral::UH4::UH4_1(v3176,
                                                                                                                       v3189,
                                                                                                                       LrcPtr::new(Spiral::UH4::UH4_0)))
                                                                            } else {
                                                                                LrcPtr::new(Spiral::UH4::UH4_0)
                                                                            };
                                                                            let v3241: LrcPtr<
                                                                                Spiral::UH4,
                                                                            > = if v3190 {
                                                                                LrcPtr::new(Spiral::UH4::UH4_1(v3179,
                                                                                                                       v3190,
                                                                                                                       v3239.clone()))
                                                                            } else {
                                                                                v3239
                                                                            };
                                                                            let v3243: LrcPtr<
                                                                                Spiral::UH4,
                                                                            > = if v3191 {
                                                                                LrcPtr::new(Spiral::UH4::UH4_1(v3182,
                                                                                                                       v3191,
                                                                                                                       v3241.clone()))
                                                                            } else {
                                                                                v3241
                                                                            };
                                                                            let v3245: LrcPtr<
                                                                                Spiral::UH4,
                                                                            > = if v3192 {
                                                                                LrcPtr::new(Spiral::UH4::UH4_1(v3185,
                                                                                                                       v3192,
                                                                                                                       v3243.clone()))
                                                                            } else {
                                                                                v3243
                                                                            };
                                                                            Spiral::method239(
                                                                                if v3193 {
                                                                                    LrcPtr::new(Spiral::UH4::UH4_1(v3188,
                                                                                                                                     v3193,
                                                                                                                                     v3245.clone()))
                                                                                } else {
                                                                                    v3245
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
                                            let v3255: string = Spiral::method147();
                                            let v3258: &str = &*v3255;
                                            let v3281: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v30.clone(), v3258)
                                                    .cloned();
                                            let v3295: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v3281),
                                            );
                                            let v3302: std::string::String = match &v3295 {
                                                Spiral::US7::US7_0(v3295_0_0) => match &v3295 {
                                                    Spiral::US7::US7_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v3304: string =
                                                fable_library_rust::String_::fromString(v3302);
                                            let v3305: string = Spiral::method25();
                                            let v3308: &str = &*v3305;
                                            let v3331: Option<Vec<std::string::String>> =
                                                clap::ArgMatches::get_many(&v30.clone(), v3308)
                                                    .map(|x| x.cloned().into_iter().collect());
                                            let v3345: Spiral::US11 = defaultValue(
                                                Spiral::US11::US11_1,
                                                map(Spiral::method26(), v3331),
                                            );
                                            let v3351: Vec<std::string::String> =
                                                new_empty::<std::string::String>().to_vec();
                                            let v3354: Vec<std::string::String> = match &v3345 {
                                                Spiral::US11::US11_0(v3345_0_0) => match &v3345 {
                                                    Spiral::US11::US11_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => v3351.clone(),
                                            };
                                            let v3358: Result<Vec<u8>, std::io::Error> =
                                                std::fs::read(&*v3304);
                                            let v3396: Vec<u8> = Spiral::method27(v3358.unwrap());
                                            let v3398: Result<
                                                std::string::String,
                                                std::string::FromUtf8Error,
                                            > = std::string::String::from_utf8(v3396);
                                            let v3401: std::string::String = v3398.unwrap();
                                            let v3431: string =
                                                fable_library_rust::String_::fromString(v3401);
                                            let v3440: string = Spiral::method193(sprintf!(
                                                "{:?}",
                                                (string("ts"), v3431.clone())
                                            ));
                                            let v3445: Spiral::US12 =
                                                    Spiral::method29(Spiral::method28(string("polyglot"),
                                                                                      string("workspace")),
                                                                     string("C:\\home\\git\\polyglot\\target\\Builder\\spiral"));
                                            let v3493: Spiral::US5 = match &v3445 {
                                                Spiral::US12::US12_0(v3445_0_0) => {
                                                    Spiral::US5::US5_0(v3445_0_0.clone())
                                                }
                                                Spiral::US12::US12_1(v3445_1_0) => {
                                                    let v3451: () = {
                                                        Spiral::closure15(v3445_1_0.clone(), ());
                                                        ()
                                                    };
                                                    Spiral::US5::US5_1
                                                }
                                            };
                                            let v3548: Spiral::US5 = match &v3493 {
                                                Spiral::US5::US5_0(v3493_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        match &v3493 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v3496: string = Spiral::method36();
                                                    let v3498: Spiral::US12 = Spiral::method29(
                                                        Spiral::method28(
                                                            string("polyglot"),
                                                            string("workspace"),
                                                        ),
                                                        v3496,
                                                    );
                                                    match &v3498 {
                                                        Spiral::US12::US12_0(v3498_0_0) => {
                                                            Spiral::US5::US5_0(v3498_0_0.clone())
                                                        }
                                                        Spiral::US12::US12_1(v3498_1_0) => {
                                                            let v3504: () = {
                                                                Spiral::closure15(
                                                                    v3498_1_0.clone(),
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            Spiral::US5::US5_1
                                                        }
                                                    }
                                                }
                                            };
                                            let v3553: string = Spiral::method28(
                                                match &v3548 {
                                                    Spiral::US5::US5_0(v3548_0_0) => match &v3548 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                },
                                                string("polyglot"),
                                            );
                                            let v3556: string = toLower(Spiral::method36());
                                            let v3560: string = toLower(v3553);
                                            let v3568: Spiral::US12 =
                                                if startsWith3(v3556, v3560.clone(), false) {
                                                    Spiral::US12::US12_1(v3560.clone())
                                                } else {
                                                    Spiral::US12::US12_0(v3560)
                                                };
                                            let v3574: Result<string, string> = match &v3568 {
                                                Spiral::US12::US12_0(v3568_0_0) => {
                                                    Ok::<string, string>(v3568_0_0.clone())
                                                }
                                                Spiral::US12::US12_1(v3568_1_0) => {
                                                    Err::<string, string>(v3568_1_0.clone())
                                                }
                                            };
                                            let v3576: bool = true;
                                            let _result_unwrap_or_else =
                                                v3574.unwrap_or_else(|x| {
                                                    //;
                                                    let v3578: string = x;
                                                    let v3580: bool = true;
                                                    v3578
                                                });
                                            let v3582: string = _result_unwrap_or_else;
                                            let v3587: string = Spiral::method196(
                                                Spiral::US5::US5_0(v3440.clone()),
                                                string("spiral"),
                                                Spiral::US38::US38_0(Spiral::US37::US37_1),
                                                v3582.clone(),
                                            );
                                            let v3592: string = Spiral::method197(
                                                v3431,
                                                string("spiral"),
                                                LrcPtr::new(Spiral::UH2::UH2_0),
                                                LrcPtr::new(Spiral::UH2::UH2_1(
                                                    string("Fable.Core"),
                                                    LrcPtr::new(Spiral::UH2::UH2_0),
                                                )),
                                                v3587.clone(),
                                                v3582.clone(),
                                            );
                                            let v3594: string = Spiral::method28(
                                                v3582.clone(),
                                                string("lib/typescript/fable/fable_modules"),
                                            );
                                            let v3595: string = concat(new_array(&[
                                                string("fable-library-"),
                                                string("ts"),
                                            ]));
                                            let v3596: string = Spiral::method244(v3595.clone());
                                            let v3598: async_walkdir::WalkDir =
                                                async_walkdir::WalkDir::new(&*v3594.clone());
                                            let v3601: async_walkdir::WalkDir =
                                                async_walkdir::WalkDir::filter(v3598, move |x| {
                                                    Func1::new({
                                                        let v3595 = v3595.clone();
                                                        move |v_9: async_walkdir::DirEntry| {
                                                            Spiral::closure101(v3595.clone(), v_9)
                                                        }
                                                    })(
                                                        x
                                                    )
                                                });
                                            let v3602 = Spiral::method248(v3596);
                                            let v3604 = futures::stream::StreamExt::filter_map(
                                                v3601,
                                                |x| async { v3602(x) },
                                            );
                                            let v3606: std::pin::Pin<
                                                Box<
                                                    dyn std::future::Future<
                                                        Output = Vec<(string, string)>,
                                                    >,
                                                >,
                                            > = Box::pin(futures::stream::StreamExt::collect(
                                                v3604,
                                            ));
                                            let v3608: Vec<(string, string)> = v3606.await;
                                            let v3610: rayon::vec::IntoIter<(string, string)> =
                                                rayon::iter::IntoParallelIterator::into_par_iter(
                                                    v3608,
                                                );
                                            let v3613: rayon::iter::Map<
                                                rayon::vec::IntoIter<(string, string)>,
                                                _,
                                            > = rayon::iter::ParallelIterator::map(v3610, |x| {
                                                Func1::new(
                                                    move |arg10_0040_20: (string, string)| {
                                                        Spiral::closure109((), arg10_0040_20)
                                                    },
                                                )(x)
                                            });
                                            let v3615: Vec<(string, string)> =
                                                rayon::iter::ParallelIterator::collect(v3613);
                                            let v3618: Option<(string, string)> = tryItem(
                                                0_i32,
                                                fable_library_rust::NativeArray_::array_from(
                                                    v3615.clone(),
                                                ),
                                            );
                                            let v3633: Spiral::US47 = defaultValue(
                                                Spiral::US47::US47_1,
                                                map(Spiral::method253(), v3618),
                                            );
                                            let v3639: () = {
                                                Spiral::closure111(v3633.clone(), ());
                                                ()
                                            };
                                            Spiral::method256(
                                                v3587.clone(),
                                                v3594.clone(),
                                                v3633.clone(),
                                            );
                                            {
                                                let patternInput_20: (i32, string) =
                                                    Spiral::method206(
                                                        Spiral::US35::US35_1,
                                                        v3587.clone(),
                                                        string("ts"),
                                                        v3592,
                                                        v3568.clone(),
                                                    );
                                                let v3681: string = patternInput_20.1.clone();
                                                let v3680: i32 = patternInput_20.0.clone();
                                                Spiral::method256(
                                                    v3587.clone(),
                                                    v3594,
                                                    v3633.clone(),
                                                );
                                                {
                                                    let patternInput_24: (
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                    ) = if (v3680) != 0_i32 {
                                                        let v3687: () = {
                                                            Spiral::closure112(
                                                                v3681.clone(),
                                                                v3680,
                                                                (),
                                                            );
                                                            ()
                                                        };
                                                        (
                                                            Spiral::US5::US5_0(string("ts")),
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_0(v3681),
                                                        )
                                                    } else {
                                                        let v3732: bool = true;
                                                        let _vec_map : Vec<_> = v3354.into_iter().map(|x| { //;
                                                                let v3734:
                                                                        std::string::String =
                                                                    x;
                                                                let v3736:
                                                                        string =
                                                                    fable_library_rust::String_::fromString(v3734);
                                                                let v3742:
                                                                        string =
                                                                    if contains(v3736.clone(),
                                                                                string("="))
                                                                       {
                                                                        v3736.clone()
                                                                    } else {
                                                                        concat(new_array(&[string("\""),
                                                                                           v3736,
                                                                                           string("\":\"*\"")]))
                                                                    };
                                                                let v3744:
                                                                        bool =
                                                                    true; v3742 }).collect::<Vec<_>>();
                                                        let v3746: Vec<string> = _vec_map;
                                                        let v3748:
                                                                        Array<string> =
                                                                    fable_library_rust::NativeArray_::array_from(v3746.clone());
                                                        let v3761: string = join(
                                                            string(",\n"),
                                                            toArray_1(delay(Func0::new({
                                                                let v3748 = v3748.clone();
                                                                move || {
                                                                    map_1(
                                                                        Func1::new({
                                                                            let v3748 =
                                                                                v3748.clone();
                                                                            move |i_2: i32| {
                                                                                v3748[i_2].clone()
                                                                            }
                                                                        }),
                                                                        rangeNumeric(
                                                                            0_i32,
                                                                            1_i32,
                                                                            (get_Count(
                                                                                v3748.clone(),
                                                                            )) - 1_i32,
                                                                        ),
                                                                    )
                                                                }
                                                            }))),
                                                        );
                                                        let v3777:
                                                                        string =
                                                                    append((append((append((append((append((append((append(string("{"),
                                                                                                                           (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                               v3440,
                                                                                                                                               string("\",")]))))),
                                                                                                                   string("  \"dependencies\": {"))),
                                                                                                           (v3761))),
                                                                                                   string("  },"))),
                                                                                           string("    \"devDependencies\": {"))),
                                                                                   string("  },"))),
                                                                           string("}"));
                                                        let v3779: string = Spiral::method28(
                                                            v3587.clone(),
                                                            string("package.json"),
                                                        );
                                                        let v3782: string = Spiral::method28(
                                                            Spiral::method28(
                                                                v3587.clone(),
                                                                string("../.."),
                                                            ),
                                                            string("package.json"),
                                                        );
                                                        Spiral::method38(v3779, v3777);
                                                        Spiral::method38(v3782, string(""));
                                                        {
                                                            let v3785: string = Spiral::method28(
                                                                v3587,
                                                                concat(new_array(&[
                                                                    string("spiral"),
                                                                    string("."),
                                                                    string("ts"),
                                                                ])),
                                                            );
                                                            let v3788: () = {
                                                                Spiral::closure113(
                                                                    v3785.clone(),
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            let v3831: Result<
                                                                Vec<u8>,
                                                                std::io::Error,
                                                            > = std::fs::read(&*v3785.clone());
                                                            let v3869: Vec<u8> =
                                                                Spiral::method27(v3831.unwrap());
                                                            let v3871: Result<
                                                                std::string::String,
                                                                std::string::FromUtf8Error,
                                                            > = std::string::String::from_utf8(
                                                                v3869,
                                                            );
                                                            let v3874: std::string::String =
                                                                v3871.unwrap();
                                                            let v3904:
                                                                            string =
                                                                        fable_library_rust::String_::fromString(v3874);
                                                            let v3910: bool = contains(
                                                                v3904.clone(),
                                                                string(
                                                                    "// spiral.process_typescript",
                                                                ),
                                                            );
                                                            let v3919: string = if v3910 {
                                                                v3904.clone()
                                                            } else {
                                                                Spiral::method173(string("\\s\\sdefaultOf\\(\\);"),
                                                                                              string(" defaultOf::<()>();"),
                                                                                              replace(v3904,
                                                                                                      sprintf!("\"./fable_modules/fable-library-ts.{}/",
                                                                                                               v3633.clone()),
                                                                                                      sprintf!("\"{}/lib/typescript/fable/fable_modules/fable-library-ts.{}/",
                                                                                                               v3582,
                                                                                                               v3633)))
                                                            };
                                                            if (v3910) == false {
                                                                Spiral::method38(v3785.clone(),
                                                                                         concat(new_array(&[v3919.clone(),
                                                                                                            string("\n\n"),
                                                                                                            string("// spiral.process_typescript"),
                                                                                                            string("\n")])));
                                                            }
                                                            {
                                                                let v3922: string =
                                                                    concat(new_array(&[
                                                                        string("bun run \""),
                                                                        v3785.clone(),
                                                                        string("\""),
                                                                    ]));
                                                                let v3924: string =
                                                                    Spiral::method3(string("PATH"));
                                                                let v3960: Spiral::US5 = if (v3924
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
                                                                            v3924,
                                                                        ]),
                                                                    ))
                                                                };
                                                                let v3975:
                                                                                Array<(string,
                                                                                       string)> =
                                                                            toArray(Spiral::method261(Spiral::method260(match &v3960
                                                                                                                            {
                                                                                                                            Spiral::US5::US5_0(v3960_0_0)
                                                                                                                            =>
                                                                                                                            LrcPtr::new(Spiral::UH5::UH5_1(string("PATH"),
                                                                                                                                                           match &v3960
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
                                                                let v3988: Result<string, string> =
                                                                    match &v3568 {
                                                                        Spiral::US12::US12_0(
                                                                            v3568_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v3568_0_0.clone(),
                                                                        ),
                                                                        Spiral::US12::US12_1(
                                                                            v3568_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v3568_1_0.clone(),
                                                                        ),
                                                                    };
                                                                let patternInput_21:
                                                                                (i32,
                                                                                 string) =
                                                                            Spiral::method65(v3922.clone(),
                                                                                             None::<CancellationToken>,
                                                                                             v3975.clone(),
                                                                                             None::<Func1<(i32,
                                                                                                           string,
                                                                                                           bool),
                                                                                                          Arc<Async<()>>>>,
                                                                                             None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                          ()>>,
                                                                                             true,
                                                                                             v3988.ok());
                                                                let v4005: string =
                                                                    patternInput_21.1.clone();
                                                                let v4004: i32 =
                                                                    patternInput_21.0.clone();
                                                                let v4006: i32 =
                                                                    get_Count(v3975.clone());
                                                                let v4007: Array<string> =
                                                                    new_init(&string(""), v4006);
                                                                let v4008: LrcPtr<Spiral::Mut5> =
                                                                    LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                while Spiral::method69(
                                                                    v4006,
                                                                    v4008.clone(),
                                                                ) {
                                                                    let v4010: i32 =
                                                                        v4008.l0.get().clone();
                                                                    let patternInput_22: (
                                                                        string,
                                                                        string,
                                                                    ) = v3975[v4010].clone();
                                                                    let v4013: string = sprintf!(
                                                                        "$env:{}=\'\'{}\'\'",
                                                                        patternInput_22.0.clone(),
                                                                        patternInput_22.1.clone()
                                                                    );
                                                                    v4007.get_mut()
                                                                        [v4010 as usize] = v4013;
                                                                    {
                                                                        let v4014: i32 =
                                                                            (v4010) + 1_i32;
                                                                        v4008.l0.set(v4014);
                                                                        ()
                                                                    }
                                                                }
                                                                {
                                                                    let v4024: string = sprintf!(
                                                                        "pwsh -c \'{}; {}\'",
                                                                        join(
                                                                            string(";"),
                                                                            toArray_1(ofArray_1(
                                                                                v4007.clone()
                                                                            ))
                                                                        ),
                                                                        v3922
                                                                    );
                                                                    let patternInput_23: (
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                    ) = if (v4004) == 0_i32 {
                                                                        let result_2: LrcPtr<
                                                                            MutCell<Spiral::US5>,
                                                                        > = refCell(
                                                                            Spiral::US5::US5_1,
                                                                        );
                                                                        try_catch(||
                                                                                                  result_2.set(Spiral::closure61((),
                                                                                                                                 Spiral::closure114(v4005.clone(),
                                                                                                                                                    ()))),
                                                                                              |ex_2:
                                                                                                   LrcPtr<Exception>|
                                                                                                  result_2.set(Spiral::closure115(v3785.clone(),
                                                                                                                                  v4005.clone(),
                                                                                                                                  v4024.clone(),
                                                                                                                                  ex_2.clone())));
                                                                        {
                                                                            let v4030: Spiral::US5 =
                                                                                result_2
                                                                                    .get()
                                                                                    .clone();
                                                                            let v4040:
                                                                                                Option<string> =
                                                                                            match &v4030
                                                                                                {
                                                                                                Spiral::US5::US5_0(v4030_0_0)
                                                                                                =>
                                                                                                Some(match &v4030
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
                                                                                    v3919,
                                                                                ),
                                                                                Spiral::US5::US5_0(
                                                                                    v3785.clone(),
                                                                                ),
                                                                                Spiral::US5::US5_0(
                                                                                    v4040.unwrap(),
                                                                                ),
                                                                            )
                                                                        }
                                                                    } else {
                                                                        let v4049: () = {
                                                                            Spiral::closure117(
                                                                                v3785,
                                                                                v4005,
                                                                                v4004,
                                                                                v4024,
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
                                                let v4104: string = Spiral::method147();
                                                let v4107: &str = &*v4104;
                                                let v4130: Option<std::string::String> =
                                                    clap::ArgMatches::get_one(&v30.clone(), v4107)
                                                        .cloned();
                                                let v4144: Spiral::US7 = defaultValue(
                                                    Spiral::US7::US7_1,
                                                    map(Spiral::method23(), v4130),
                                                );
                                                let v4151: std::string::String = match &v4144 {
                                                    Spiral::US7::US7_0(v4144_0_0) => match &v4144 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v4153: string =
                                                    fable_library_rust::String_::fromString(v4151);
                                                let v4154: string = Spiral::method25();
                                                let v4157: &str = &*v4154;
                                                let v4180: Option<Vec<std::string::String>> =
                                                    clap::ArgMatches::get_many(&v30.clone(), v4157)
                                                        .map(|x| x.cloned().into_iter().collect());
                                                let v4194: Spiral::US11 = defaultValue(
                                                    Spiral::US11::US11_1,
                                                    map(Spiral::method26(), v4180),
                                                );
                                                let v4200: Vec<std::string::String> =
                                                    new_empty::<std::string::String>().to_vec();
                                                let v4203: Vec<std::string::String> = match &v4194 {
                                                    Spiral::US11::US11_0(v4194_0_0) => match &v4194
                                                    {
                                                        Spiral::US11::US11_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => v4200.clone(),
                                                };
                                                let v4204: bool = if let Spiral::US0::US0_0 = &v0_1
                                                {
                                                    true
                                                } else {
                                                    false
                                                };
                                                let v4208: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v4153);
                                                let v4246: Vec<u8> =
                                                    Spiral::method27(v4208.unwrap());
                                                let v4248: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v4246);
                                                let v4251: std::string::String = v4248.unwrap();
                                                let v4281: string =
                                                    fable_library_rust::String_::fromString(v4251);
                                                let v4290: string = Spiral::method193(sprintf!(
                                                    "{:?}",
                                                    (string("py"), v4281.clone())
                                                ));
                                                let v4295:
                                                                Spiral::US12 =
                                                            Spiral::method29(Spiral::method28(string("polyglot"),
                                                                                              string("workspace")),
                                                                             string("C:\\home\\git\\polyglot\\target\\Builder\\spiral"));
                                                let v4343: Spiral::US5 = match &v4295 {
                                                    Spiral::US12::US12_0(v4295_0_0) => {
                                                        Spiral::US5::US5_0(v4295_0_0.clone())
                                                    }
                                                    Spiral::US12::US12_1(v4295_1_0) => {
                                                        let v4301: () = {
                                                            Spiral::closure15(
                                                                v4295_1_0.clone(),
                                                                (),
                                                            );
                                                            ()
                                                        };
                                                        Spiral::US5::US5_1
                                                    }
                                                };
                                                let v4398: Spiral::US5 = match &v4343 {
                                                    Spiral::US5::US5_0(v4343_0_0) => {
                                                        Spiral::US5::US5_0(
                                                            match &v4343 {
                                                                Spiral::US5::US5_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => {
                                                        let v4346: string = Spiral::method36();
                                                        let v4348: Spiral::US12 = Spiral::method29(
                                                            Spiral::method28(
                                                                string("polyglot"),
                                                                string("workspace"),
                                                            ),
                                                            v4346,
                                                        );
                                                        match &v4348 {
                                                            Spiral::US12::US12_0(v4348_0_0) => {
                                                                Spiral::US5::US5_0(
                                                                    v4348_0_0.clone(),
                                                                )
                                                            }
                                                            Spiral::US12::US12_1(v4348_1_0) => {
                                                                let v4354: () = {
                                                                    Spiral::closure15(
                                                                        v4348_1_0.clone(),
                                                                        (),
                                                                    );
                                                                    ()
                                                                };
                                                                Spiral::US5::US5_1
                                                            }
                                                        }
                                                    }
                                                };
                                                let v4403: string = Spiral::method28(
                                                    match &v4398 {
                                                        Spiral::US5::US5_0(v4398_0_0) => {
                                                            match &v4398 {
                                                                Spiral::US5::US5_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone()
                                                        }
                                                        _ => panic!(
                                                            "{}",
                                                            string("Option does not have a value."),
                                                        ),
                                                    },
                                                    string("polyglot"),
                                                );
                                                let v4406: string = toLower(Spiral::method36());
                                                let v4410: string = toLower(v4403);
                                                let v4418: Spiral::US12 =
                                                    if startsWith3(v4406, v4410.clone(), false) {
                                                        Spiral::US12::US12_1(v4410.clone())
                                                    } else {
                                                        Spiral::US12::US12_0(v4410)
                                                    };
                                                let v4424: Result<string, string> = match &v4418 {
                                                    Spiral::US12::US12_0(v4418_0_0) => {
                                                        Ok::<string, string>(v4418_0_0.clone())
                                                    }
                                                    Spiral::US12::US12_1(v4418_1_0) => {
                                                        Err::<string, string>(v4418_1_0.clone())
                                                    }
                                                };
                                                let v4426: bool = true;
                                                let _result_unwrap_or_else =
                                                    v4424.unwrap_or_else(|x| {
                                                        //;
                                                        let v4428: string = x;
                                                        let v4430: bool = true;
                                                        v4428
                                                    });
                                                let v4432: string = _result_unwrap_or_else;
                                                let v4437: string = Spiral::method196(
                                                    Spiral::US5::US5_0(v4290.clone()),
                                                    string("spiral"),
                                                    Spiral::US38::US38_0(Spiral::US37::US37_2),
                                                    v4432.clone(),
                                                );
                                                let v4442: string = Spiral::method197(
                                                    v4281,
                                                    string("spiral"),
                                                    LrcPtr::new(Spiral::UH2::UH2_0),
                                                    LrcPtr::new(Spiral::UH2::UH2_1(
                                                        string("Fable.Core"),
                                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                                    )),
                                                    v4437.clone(),
                                                    v4432.clone(),
                                                );
                                                Spiral::method205(
                                                    Spiral::method28(
                                                        Spiral::method28(
                                                            v4432,
                                                            string(
                                                                "lib/python/fable/fable_modules",
                                                            ),
                                                        ),
                                                        string("fable_library"),
                                                    ),
                                                    Spiral::method28(
                                                        v4437.clone(),
                                                        string("fable_modules/fable_library"),
                                                    ),
                                                );
                                                {
                                                    let patternInput_25: (i32, string) =
                                                        Spiral::method206(
                                                            Spiral::US35::US35_1,
                                                            v4437.clone(),
                                                            string("py"),
                                                            v4442,
                                                            v4418.clone(),
                                                        );
                                                    let v4451: string = patternInput_25.1.clone();
                                                    let v4450: i32 = patternInput_25.0.clone();
                                                    let patternInput_29: (
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                    ) = if (v4450) != 0_i32 {
                                                        let v4457: () = {
                                                            Spiral::closure118(
                                                                v4451.clone(),
                                                                v4450,
                                                                (),
                                                            );
                                                            ()
                                                        };
                                                        (
                                                            Spiral::US5::US5_0(string("py")),
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_0(v4451),
                                                        )
                                                    } else {
                                                        let v4502: bool = true;
                                                        let _vec_map : Vec<_> = v4203.into_iter().map(|x| { //;
                                                                    let v4504:
                                                                            std::string::String =
                                                                        x;
                                                                    let v4506:
                                                                            string =
                                                                        fable_library_rust::String_::fromString(v4504);
                                                                    let v4512:
                                                                            string =
                                                                        if contains(v4506.clone(),
                                                                                    string("="))
                                                                           {
                                                                            v4506.clone()
                                                                        } else {
                                                                            concat(new_array(&[string("\""),
                                                                                               v4506,
                                                                                               string("\":\"*\"")]))
                                                                        };
                                                                    let v4514:
                                                                            bool =
                                                                        true; v4512 }).collect::<Vec<_>>();
                                                        let v4516: Vec<string> = _vec_map;
                                                        let v4518:
                                                                            Array<string> =
                                                                        fable_library_rust::NativeArray_::array_from(v4516.clone());
                                                        let v4531: string = join(
                                                            string(",\n"),
                                                            toArray_1(delay(Func0::new({
                                                                let v4518 = v4518.clone();
                                                                move || {
                                                                    map_1(
                                                                        Func1::new({
                                                                            let v4518 =
                                                                                v4518.clone();
                                                                            move |i_3: i32| {
                                                                                v4518[i_3].clone()
                                                                            }
                                                                        }),
                                                                        rangeNumeric(
                                                                            0_i32,
                                                                            1_i32,
                                                                            (get_Count(
                                                                                v4518.clone(),
                                                                            )) - 1_i32,
                                                                        ),
                                                                    )
                                                                }
                                                            }))),
                                                        );
                                                        let v4547:
                                                                            string =
                                                                        append((append((append((append((append((append((append(string("{"),
                                                                                                                               (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                                   v4290,
                                                                                                                                                   string("\",")]))))),
                                                                                                                       string("  \"dependencies\": {"))),
                                                                                                               (v4531))),
                                                                                                       string("  },"))),
                                                                                               string("    \"devDependencies\": {"))),
                                                                                       string("  },"))),
                                                                               string("}"));
                                                        let v4549: string = Spiral::method28(
                                                            v4437.clone(),
                                                            string("package.json"),
                                                        );
                                                        let v4552: string = Spiral::method28(
                                                            Spiral::method28(
                                                                v4437.clone(),
                                                                string("../.."),
                                                            ),
                                                            string("package.json"),
                                                        );
                                                        Spiral::method38(v4549, v4547);
                                                        Spiral::method38(v4552, string(""));
                                                        {
                                                            let v4555: string = Spiral::method28(
                                                                v4437,
                                                                concat(new_array(&[
                                                                    string("spiral"),
                                                                    string("."),
                                                                    string("py"),
                                                                ])),
                                                            );
                                                            let v4558: () = {
                                                                Spiral::closure119(
                                                                    v4555.clone(),
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            let v4601: Result<
                                                                Vec<u8>,
                                                                std::io::Error,
                                                            > = std::fs::read(&*v4555.clone());
                                                            let v4639: Vec<u8> =
                                                                Spiral::method27(v4601.unwrap());
                                                            let v4641: Result<
                                                                std::string::String,
                                                                std::string::FromUtf8Error,
                                                            > = std::string::String::from_utf8(
                                                                v4639,
                                                            );
                                                            let v4644: std::string::String =
                                                                v4641.unwrap();
                                                            let v4674:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v4644);
                                                            let v4680: bool = contains(
                                                                v4674.clone(),
                                                                string("# spiral.process_python"),
                                                            );
                                                            let v4692: string = if v4680 {
                                                                v4674.clone()
                                                            } else {
                                                                Spiral::method173(
                                                                    string(
                                                                        "\\s\\sdefaultOf\\(\\);",
                                                                    ),
                                                                    string(" defaultOf::<()>();"),
                                                                    replace(
                                                                        v4674,
                                                                        append(
                                                                            string("),)"),
                                                                            (";".into()),
                                                                        ),
                                                                        string("));"),
                                                                    ),
                                                                )
                                                            };
                                                            if (v4680) == false {
                                                                Spiral::method38(v4555.clone(),
                                                                                             concat(new_array(&[v4692.clone(),
                                                                                                                string("\n\n"),
                                                                                                                string("# spiral.process_python"),
                                                                                                                string("\n")])));
                                                            }
                                                            {
                                                                let v4695: string =
                                                                    concat(new_array(&[
                                                                        string("python \""),
                                                                        v4555.clone(),
                                                                        string("\""),
                                                                    ]));
                                                                let v4698: Array<(string, string)> =
                                                                    new_array(&[(
                                                                        string("TRACE_LEVEL"),
                                                                        string("Verbose"),
                                                                    )]);
                                                                let v4709: Result<string, string> =
                                                                    match &v4418 {
                                                                        Spiral::US12::US12_0(
                                                                            v4418_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v4418_0_0.clone(),
                                                                        ),
                                                                        Spiral::US12::US12_1(
                                                                            v4418_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v4418_1_0.clone(),
                                                                        ),
                                                                    };
                                                                let patternInput_26:
                                                                                    (i32,
                                                                                     string) =
                                                                                Spiral::method65(v4695.clone(),
                                                                                                 None::<CancellationToken>,
                                                                                                 v4698.clone(),
                                                                                                 None::<Func1<(i32,
                                                                                                               string,
                                                                                                               bool),
                                                                                                              Arc<Async<()>>>>,
                                                                                                 None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                              ()>>,
                                                                                                 true,
                                                                                                 v4709.ok());
                                                                let v4726: string =
                                                                    patternInput_26.1.clone();
                                                                let v4725: i32 =
                                                                    patternInput_26.0.clone();
                                                                let v4727: i32 =
                                                                    get_Count(v4698.clone());
                                                                let v4728: Array<string> =
                                                                    new_init(&string(""), v4727);
                                                                let v4729: LrcPtr<Spiral::Mut5> =
                                                                    LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                while Spiral::method69(
                                                                    v4727,
                                                                    v4729.clone(),
                                                                ) {
                                                                    let v4731: i32 =
                                                                        v4729.l0.get().clone();
                                                                    let patternInput_27: (
                                                                        string,
                                                                        string,
                                                                    ) = v4698[v4731].clone();
                                                                    let v4734: string = sprintf!(
                                                                        "$env:{}=\'\'{}\'\'",
                                                                        patternInput_27.0.clone(),
                                                                        patternInput_27.1.clone()
                                                                    );
                                                                    v4728.get_mut()
                                                                        [v4731 as usize] = v4734;
                                                                    {
                                                                        let v4735: i32 =
                                                                            (v4731) + 1_i32;
                                                                        v4729.l0.set(v4735);
                                                                        ()
                                                                    }
                                                                }
                                                                {
                                                                    let v4745: string = sprintf!(
                                                                        "pwsh -c \'{}; {}\'",
                                                                        join(
                                                                            string(";"),
                                                                            toArray_1(ofArray_1(
                                                                                v4728.clone()
                                                                            ))
                                                                        ),
                                                                        v4695
                                                                    );
                                                                    let patternInput_28: (
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                    ) = if (v4725) == 0_i32 {
                                                                        let result_3: LrcPtr<
                                                                            MutCell<Spiral::US5>,
                                                                        > = refCell(
                                                                            Spiral::US5::US5_1,
                                                                        );
                                                                        try_catch(||
                                                                                                      result_3.set(Spiral::closure61((),
                                                                                                                                     Spiral::closure120(v4726.clone(),
                                                                                                                                                        ()))),
                                                                                                  |ex_3:
                                                                                                       LrcPtr<Exception>|
                                                                                                      result_3.set(Spiral::closure121(v4555.clone(),
                                                                                                                                      v4726.clone(),
                                                                                                                                      v4745.clone(),
                                                                                                                                      ex_3.clone())));
                                                                        {
                                                                            let v4751: Spiral::US5 =
                                                                                result_3
                                                                                    .get()
                                                                                    .clone();
                                                                            let v4761:
                                                                                                    Option<string> =
                                                                                                match &v4751
                                                                                                    {
                                                                                                    Spiral::US5::US5_0(v4751_0_0)
                                                                                                    =>
                                                                                                    Some(match &v4751
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
                                                                                    v4692,
                                                                                ),
                                                                                Spiral::US5::US5_0(
                                                                                    v4555.clone(),
                                                                                ),
                                                                                Spiral::US5::US5_0(
                                                                                    v4761.unwrap(),
                                                                                ),
                                                                            )
                                                                        }
                                                                    } else {
                                                                        let v4770: () = {
                                                                            Spiral::closure123(
                                                                                v4555,
                                                                                v4726,
                                                                                v4725,
                                                                                v4745,
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
                                                let v4824: () = {
                                                    Spiral::closure124(v30, v29, ());
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
                                    let v4879: Spiral::US5 = patternInput_32.3.clone();
                                    let v4878: Spiral::US5 = patternInput_32.2.clone();
                                    let v4877: Spiral::US5 = patternInput_32.1.clone();
                                    let v4876: Spiral::US5 = patternInput_32.0.clone();
                                    new_array(&[
                                        (
                                            string("extension"),
                                            match &v4876 {
                                                Spiral::US5::US5_0(v4876_0_0) => match &v4876 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => string(""),
                                            },
                                        ),
                                        (
                                            string("code"),
                                            match &v4877 {
                                                Spiral::US5::US5_0(v4877_0_0) => match &v4877 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => string(""),
                                            },
                                        ),
                                        (
                                            string("code_path"),
                                            match &v4878 {
                                                Spiral::US5::US5_0(v4878_0_0) => match &v4878 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => string(""),
                                            },
                                        ),
                                        (
                                            string("output"),
                                            match &v4879 {
                                                Spiral::US5::US5_0(v4879_0_0) => match &v4879 {
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
                    let v4912: Vec<(string, string)> = v4910.to_vec();
                    let v4915: bool = true;
                    let _func1_from_v4913 = Func1::from(move |value| {
                        //;
                        let patternInput_33: (string, string) = value;
                        let v4921: &str = &*patternInput_33.0.clone();
                        let v4945: std::string::String = String::from(v4921);
                        let v4969: &str = &*patternInput_33.1.clone();
                        let v4993: std::string::String = String::from(v4969);
                        let v5018: bool = true;
                        LrcPtr::new((v4945, v4993)) /*;
                                                    let v5020: bool = */
                    }); //;
                    let v5022: Func1<
                        (string, string),
                        LrcPtr<(std::string::String, std::string::String)>,
                    > = _func1_from_v4913;
                    let v5025: Vec<LrcPtr<(std::string::String, std::string::String)>> = v4912
                        .into_iter()
                        .map(|x| {
                            Func1::new({
                                let v5022 = v5022.clone();
                                move |arg10_0040_33: (string, string)| {
                                    Spiral::closure66(v5022.clone(), arg10_0040_33)
                                }
                            })(x.clone())
                        })
                        .collect::<Vec<_>>();
                    let v5026: string =
                string("std::collections::BTreeMap::from_iter(v5025.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                    let v5027: std::collections::BTreeMap<
                        std::string::String,
                        std::string::String,
                    > = std::collections::BTreeMap::from_iter(
                        v5025
                            .iter()
                            .map(|x| x.as_ref())
                            .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                    );
                    let v5029: Result<std::string::String, serde_json::Error> =
                        serde_json::to_string(&v5027);
                    let v5030 = Spiral::method271();
                    let v5033: Result<std::string::String, string> = v5029.map_err(|x| v5030(x));
                    let v5046: bool = true;
                    let _result_map_ = v5033.map(|x| {
                        //;
                        let v5048: std::string::String = x;
                        let v5050: string = fable_library_rust::String_::fromString(v5048);
                        let v5052: bool = true;
                        v5050
                    });
                    let v5054: Result<string, string> = _result_map_;
                    let v5057: string = string("}");
                    let v5062: bool = true;
                    let _fix_closure_v5059 = v5054;
                    let v5069: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v5059 "), (v5057))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v5070: bool = true;
                    _fix_closure_v5059
                },
            ); // rust.fix_closure';
            let v5072 = __future_init;
            v5072
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
