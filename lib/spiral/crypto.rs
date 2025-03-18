pub mod Crypto {
    use super::*;
    use fable_library_rust::Convert_::toInt32_radix;
    use fable_library_rust::DateTime_::DateTime;
    use fable_library_rust::Encoding_::get_UTF8;
    use fable_library_rust::Encoding_::Encoding;
    use fable_library_rust::List_::empty;
    use fable_library_rust::List_::ofArray;
    use fable_library_rust::List_::toArray as toArray_1;
    use fable_library_rust::Map_::find;
    use fable_library_rust::Map_::ofSeq;
    use fable_library_rust::NativeArray_::get_Count;
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::NativeArray_::Array;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::Native_::Any;
    use fable_library_rust::Native_::Func0;
    use fable_library_rust::Native_::Func1;
    use fable_library_rust::Native_::LrcPtr;
    use fable_library_rust::Native_::MutCell;
    use fable_library_rust::Native_::OnceInit;
    use fable_library_rust::Option_::defaultValue;
    use fable_library_rust::Option_::map as map_1;
    use fable_library_rust::Range_::rangeNumeric;
    use fable_library_rust::Seq_::delay;
    use fable_library_rust::Seq_::map;
    use fable_library_rust::Seq_::ofList;
    use fable_library_rust::Seq_::toArray;
    use fable_library_rust::String_::append;
    use fable_library_rust::String_::getCharAt;
    use fable_library_rust::String_::getSlice;
    use fable_library_rust::String_::join;
    use fable_library_rust::String_::printfn;
    use fable_library_rust::String_::sprintf;
    use fable_library_rust::String_::string;
    use fable_library_rust::String_::toLower;
    use fable_library_rust::String_::trimEndChars;
    use fable_library_rust::String_::trimStartChars;
    use fable_library_rust::System::Collections::Generic::IEnumerable_1;
    use fable_library_rust::TimeSpan_::TimeSpan;
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
    pub mod TraceState {
        use super::*;
        pub fn trace_state() -> LrcPtr<
            MutCell<
                Option<(
                    LrcPtr<Crypto::Mut1>,
                    LrcPtr<Crypto::Mut2>,
                    LrcPtr<Crypto::Mut3>,
                    LrcPtr<Crypto::Mut4>,
                    LrcPtr<Crypto::Mut5>,
                    Option<i64>,
                )>,
            >,
        > {
            static trace_state: OnceInit<
                LrcPtr<
                    MutCell<
                        Option<(
                            LrcPtr<Crypto::Mut1>,
                            LrcPtr<Crypto::Mut2>,
                            LrcPtr<Crypto::Mut3>,
                            LrcPtr<Crypto::Mut4>,
                            LrcPtr<Crypto::Mut5>,
                            Option<i64>,
                        )>,
                    >,
                >,
            > = OnceInit::new();
            trace_state
                .get_or_init(|| {
                    LrcPtr::new(MutCell::new(
                        None::<(
                            LrcPtr<Crypto::Mut1>,
                            LrcPtr<Crypto::Mut2>,
                            LrcPtr<Crypto::Mut3>,
                            LrcPtr<Crypto::Mut4>,
                            LrcPtr<Crypto::Mut5>,
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
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub struct Mut0 {
        pub l0: MutCell<i32>,
    }
    impl core::fmt::Display for Mut0 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
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
    pub struct Mut1 {
        pub l0: MutCell<i64>,
    }
    impl core::fmt::Display for Mut1 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub struct Mut2 {
        pub l0: MutCell<Func1<string, ()>>,
    }
    impl core::fmt::Display for Mut2 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub struct Mut3 {
        pub l0: MutCell<bool>,
    }
    impl core::fmt::Display for Mut3 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub struct Mut4 {
        pub l0: MutCell<string>,
    }
    impl core::fmt::Display for Mut4 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub struct Mut5 {
        pub l0: MutCell<Crypto::US0>,
    }
    impl core::fmt::Display for Mut5 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US1 {
        US1_0(Crypto::US0),
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
        US4_0(Crypto::US3),
        US4_1(Crypto::US3),
        US4_2(Crypto::US3),
        US4_3(Crypto::US3),
        US4_4(Crypto::US3),
        US4_5(Crypto::US3),
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
    pub fn method1() -> string {
        string("")
    }
    pub fn method2(v0_1: string) -> string {
        v0_1
    }
    pub fn method3(v0_1: i32, v1_1: LrcPtr<Crypto::Mut0>) -> bool {
        (v1_1.l0.get().clone()) < (v0_1)
    }
    pub fn method4() -> string {
        string("")
    }
    pub fn method0(v0_1: string) -> string {
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
                let v34: Result<usize, std::io::Error> = std::io::Read::read(&mut v15, &mut v28);
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
                            map(
                                Func1::new({
                                    let v103 = v103.clone();
                                    move |i: i32| v103[i].clone()
                                }),
                                rangeNumeric(0_i32, 1_i32, (get_Count(v103.clone())) - 1_i32),
                            )
                        }
                    }));
                    let v117: string = Crypto::method1();
                    let v124: string = join(
                        if (v117.clone()) == string("\n") {
                            Crypto::method2(v117.clone())
                        } else {
                            v117
                        },
                        toArray(_let__v108),
                    );
                    Ok::<string, std::io::Error>(v124).unwrap()
                }
            }
        }
    }
    pub fn closure0(unitVar: (), v0_1: string) -> string {
        Crypto::method0(v0_1)
    }
    pub fn method9(v0_1: string) -> string {
        v0_1
    }
    pub fn method10() -> string {
        string("")
    }
    pub fn closure4(unitVar: (), v0_1: string) -> Crypto::US5 {
        Crypto::US5::US5_0(v0_1)
    }
    pub fn method11() -> Func1<string, Crypto::US5> {
        Func1::new(move |v: string| Crypto::closure4((), v))
    }
    pub fn method8(v0_1: string) -> string {
        let v6: string = Crypto::method9(v0_1);
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
        let v19: string = Crypto::method10();
        v18.unwrap_or(v19)
    }
    pub fn method7() -> (Crypto::US1, Crypto::US2) {
        let v1_1: string = Crypto::method8(string("TRACE_LEVEL"));
        let v6: string = toLower(string("Critical"));
        let v13: string = toLower(string("Warning"));
        let v20: string = toLower(string("Info"));
        let v27: string = toLower(string("Debug"));
        let v34: string = toLower(string("Verbose"));
        let v41: Crypto::US1 = if string("Verbose") == (v1_1.clone()) {
            Crypto::US1::US1_0(Crypto::US0::US0_0)
        } else {
            Crypto::US1::US1_1
        };
        (
            match &v41 {
                Crypto::US1::US1_0(v41_0_0) => Crypto::US1::US1_0(
                    match &v41 {
                        Crypto::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                ),
                _ => {
                    let v48: Crypto::US1 = if string("Debug") == (v1_1.clone()) {
                        Crypto::US1::US1_0(Crypto::US0::US0_1)
                    } else {
                        Crypto::US1::US1_1
                    };
                    match &v48 {
                        Crypto::US1::US1_0(v48_0_0) => Crypto::US1::US1_0(
                            match &v48 {
                                Crypto::US1::US1_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v55: Crypto::US1 = if string("Info") == (v1_1.clone()) {
                                Crypto::US1::US1_0(Crypto::US0::US0_2)
                            } else {
                                Crypto::US1::US1_1
                            };
                            match &v55 {
                                Crypto::US1::US1_0(v55_0_0) => Crypto::US1::US1_0(
                                    match &v55 {
                                        Crypto::US1::US1_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v62: Crypto::US1 = if string("Warning") == (v1_1.clone()) {
                                        Crypto::US1::US1_0(Crypto::US0::US0_3)
                                    } else {
                                        Crypto::US1::US1_1
                                    };
                                    match &v62 {
                                        Crypto::US1::US1_0(v62_0_0) => Crypto::US1::US1_0(
                                            match &v62 {
                                                Crypto::US1::US1_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ),
                                        _ => {
                                            let v69: Crypto::US1 =
                                                if string("Critical") == (v1_1.clone()) {
                                                    Crypto::US1::US1_0(Crypto::US0::US0_4)
                                                } else {
                                                    Crypto::US1::US1_1
                                                };
                                            match &v69 {
                                                Crypto::US1::US1_0(v69_0_0) => Crypto::US1::US1_0(
                                                    match &v69 {
                                                        Crypto::US1::US1_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                                _ => {
                                                    let v76: Crypto::US1 =
                                                        if (v34.clone()) == (v1_1.clone()) {
                                                            Crypto::US1::US1_0(Crypto::US0::US0_0)
                                                        } else {
                                                            Crypto::US1::US1_1
                                                        };
                                                    match &v76 {
                                                        Crypto::US1::US1_0(v76_0_0) => {
                                                            Crypto::US1::US1_0(
                                                                match &v76 {
                                                                    Crypto::US1::US1_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v83: Crypto::US1 = if (v27.clone())
                                                                == (v1_1.clone())
                                                            {
                                                                Crypto::US1::US1_0(
                                                                    Crypto::US0::US0_1,
                                                                )
                                                            } else {
                                                                Crypto::US1::US1_1
                                                            };
                                                            match &v83 {
                                                                Crypto::US1::US1_0(v83_0_0) => {
                                                                    Crypto::US1::US1_0(
                                                                        match &v83 {
                                                                            Crypto::US1::US1_0(
                                                                                x,
                                                                            ) => x.clone(),
                                                                            _ => unreachable!(),
                                                                        }
                                                                        .clone(),
                                                                    )
                                                                }
                                                                _ => {
                                                                    let v90: Crypto::US1 = if (v20
                                                                        .clone())
                                                                        == (v1_1.clone())
                                                                    {
                                                                        Crypto::US1::US1_0(
                                                                            Crypto::US0::US0_2,
                                                                        )
                                                                    } else {
                                                                        Crypto::US1::US1_1
                                                                    };
                                                                    match &v90 {
                                                                     Crypto::US1::US1_0(v90_0_0)
                                                                     =>
                                                                     Crypto::US1::US1_0(match &v90
                                                                                            {
                                                                                            Crypto::US1::US1_0(x)
                                                                                            =>
                                                                                            x.clone(),
                                                                                            _
                                                                                            =>
                                                                                            unreachable!(),
                                                                                        }.clone()),
                                                                     _ => {
                                                                         let v97:
                                                                                 Crypto::US1 =
                                                                             if (v13.clone())
                                                                                    ==
                                                                                    (v1_1.clone())
                                                                                {
                                                                                 Crypto::US1::US1_0(Crypto::US0::US0_3)
                                                                             } else {
                                                                                 Crypto::US1::US1_1
                                                                             };
                                                                         match &v97
                                                                             {
                                                                             Crypto::US1::US1_0(v97_0_0)
                                                                             =>
                                                                             Crypto::US1::US1_0(match &v97
                                                                                                    {
                                                                                                    Crypto::US1::US1_0(x)
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
                                                                                         Crypto::US1 =
                                                                                     if (v6.clone())
                                                                                            ==
                                                                                            (v1_1.clone())
                                                                                        {
                                                                                         Crypto::US1::US1_0(Crypto::US0::US0_4)
                                                                                     } else {
                                                                                         Crypto::US1::US1_1
                                                                                     };
                                                                                 match &v104
                                                                                     {
                                                                                     Crypto::US1::US1_0(v104_0_0)
                                                                                     =>
                                                                                     Crypto::US1::US1_0(match &v104
                                                                                                            {
                                                                                                            Crypto::US1::US1_0(x)
                                                                                                            =>
                                                                                                            x.clone(),
                                                                                                            _
                                                                                                            =>
                                                                                                            unreachable!(),
                                                                                                        }.clone()),
                                                                                     _
                                                                                     =>
                                                                                     Crypto::US1::US1_1,
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
            if (Crypto::method8(string("AUTOMATION"))) != string("True") {
                Crypto::US2::US2_1
            } else {
                Crypto::US2::US2_0({
                    let _arg: DateTime = DateTime::now();
                    _arg.ticks()
                })
            },
        )
    }
    pub fn closure5(unitVar: (), v0_1: string) {
        ();
    }
    pub fn method6(
        v0_1: Crypto::US0,
    ) -> (
        LrcPtr<Crypto::Mut1>,
        LrcPtr<Crypto::Mut2>,
        LrcPtr<Crypto::Mut3>,
        LrcPtr<Crypto::Mut4>,
        LrcPtr<Crypto::Mut5>,
        Option<i64>,
    ) {
        let patternInput: (Crypto::US1, Crypto::US2) = Crypto::method7();
        let _run_target_args__v3: (Crypto::US1, Crypto::US2) =
            (patternInput.0.clone(), patternInput.1.clone());
        let v173: Crypto::US2 = _run_target_args__v3.1.clone();
        let v172: Crypto::US1 = _run_target_args__v3.0.clone();
        (
            LrcPtr::new(Crypto::Mut1 {
                l0: MutCell::new(1_i64),
            }),
            LrcPtr::new(Crypto::Mut2 {
                l0: MutCell::new(Func1::new(move |v: string| Crypto::closure5((), v))),
            }),
            LrcPtr::new(Crypto::Mut3 {
                l0: MutCell::new(true),
            }),
            LrcPtr::new(Crypto::Mut4 {
                l0: MutCell::new(string("")),
            }),
            LrcPtr::new(Crypto::Mut5 {
                l0: MutCell::new(match &v172 {
                    Crypto::US1::US1_0(v172_0_0) => match &v172 {
                        Crypto::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    _ => v0_1.clone(),
                }),
            }),
            match &v173 {
                Crypto::US2::US2_0(v173_0_0) => Some(match &v173 {
                    Crypto::US2::US2_0(x) => x.clone(),
                    _ => unreachable!(),
                }),
                _ => None::<i64>,
            },
        )
    }
    pub fn closure3(unitVar: (), unitVar_1: ()) {
        if Crypto::TraceState::trace_state().get().clone().is_none() {
            let patternInput: (
                LrcPtr<Crypto::Mut1>,
                LrcPtr<Crypto::Mut2>,
                LrcPtr<Crypto::Mut3>,
                LrcPtr<Crypto::Mut4>,
                LrcPtr<Crypto::Mut5>,
                Option<i64>,
            ) = Crypto::method6(Crypto::US0::US0_0);
            Crypto::TraceState::trace_state().set(Some((
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
    pub fn method5(v0_1: Crypto::US0) -> bool {
        let v3: () = {
            Crypto::closure3((), ());
            ()
        };
        let patternInput: (
            LrcPtr<Crypto::Mut1>,
            LrcPtr<Crypto::Mut2>,
            LrcPtr<Crypto::Mut3>,
            LrcPtr<Crypto::Mut4>,
            LrcPtr<Crypto::Mut5>,
            Option<i64>,
        ) = Crypto::TraceState::trace_state().get().clone().unwrap();
        let v42: Crypto::US0 = (patternInput.4.clone()).l0.get().clone();
        if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            (find(
                v0_1,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Crypto::US0::US0_0, 0_i32)),
                    LrcPtr::new((Crypto::US0::US0_1, 1_i32)),
                    LrcPtr::new((Crypto::US0::US0_2, 2_i32)),
                    LrcPtr::new((Crypto::US0::US0_3, 3_i32)),
                    LrcPtr::new((Crypto::US0::US0_4, 4_i32)),
                ])))),
            )) >= (find(
                v42,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Crypto::US0::US0_0, 0_i32)),
                    LrcPtr::new((Crypto::US0::US0_1, 1_i32)),
                    LrcPtr::new((Crypto::US0::US0_2, 2_i32)),
                    LrcPtr::new((Crypto::US0::US0_3, 3_i32)),
                    LrcPtr::new((Crypto::US0::US0_4, 4_i32)),
                ])))),
            ))
        }
    }
    pub fn closure6(unitVar: (), v0_1: i64) -> Crypto::US2 {
        Crypto::US2::US2_0(v0_1)
    }
    pub fn method13() -> Func1<i64, Crypto::US2> {
        Func1::new(move |v: i64| Crypto::closure6((), v))
    }
    pub fn method14() -> string {
        string("hh:mm:ss")
    }
    pub fn method15() -> string {
        string("HH:mm:ss")
    }
    pub fn method12(
        v0_1: LrcPtr<Crypto::Mut1>,
        v1_1: LrcPtr<Crypto::Mut2>,
        v2: LrcPtr<Crypto::Mut3>,
        v3: LrcPtr<Crypto::Mut4>,
        v4: LrcPtr<Crypto::Mut5>,
        v5: Option<i64>,
    ) -> string {
        let v198: Crypto::US2 = defaultValue(Crypto::US2::US2_1, map_1(Crypto::method13(), v5));
        let v316: DateTime = match &v198 {
            Crypto::US2::US2_0(v198_0_0) => {
                let v268: TimeSpan = TimeSpan::new_ticks(
                    ({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    }) - (match &v198 {
                        Crypto::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    }),
                );
                DateTime::new_ymdhms_milli(
                    1_i32,
                    1_i32,
                    1_i32,
                    v268.hours(),
                    v268.minutes(),
                    v268.seconds(),
                    v268.milliseconds(),
                )
            }
            _ => DateTime::now(),
        };
        let v318: string = Crypto::method14();
        let provider: string = if (v318.clone()) == string("") {
            string("M-d-y hh:mm:ss tt")
        } else {
            v318
        };
        v316.toString(provider)
    }
    pub fn method18() -> string {
        string("")
    }
    pub fn closure7(v0_1: LrcPtr<Crypto::Mut4>, v1_1: string, unitVar: ()) {
        let v3: string = append((v0_1.l0.get().clone()), (v1_1));
        v0_1.l0.set(v3);
        ()
    }
    pub fn method17(v0_1: char) -> string {
        let v2: LrcPtr<Crypto::Mut4> = LrcPtr::new(Crypto::Mut4 {
            l0: MutCell::new(Crypto::method18()),
        });
        let v9: () = {
            Crypto::closure7(v2.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method19() -> string {
        string("\u{001b}[0m")
    }
    pub fn method16() -> string {
        let v8: string = Crypto::method17(getCharAt(toLower(string("Verbose")), 0_i32));
        let v15: &str = inline_colorization::color_bright_black;
        let v22: &str = &*v8;
        let v50: &str = inline_colorization::color_reset;
        let v52: std::string::String = format!("{}{}{}", v15, v22, v50);
        fable_library_rust::String_::fromString(v52)
    }
    pub fn method21(v0_1: i32, v1_1: string, v2: u16) -> string {
        let v4: LrcPtr<Crypto::Mut4> = LrcPtr::new(Crypto::Mut4 {
            l0: MutCell::new(Crypto::method18()),
        });
        let v13: () = {
            Crypto::closure7(v4.clone(), string("{ "), ());
            ()
        };
        let v24: () = {
            Crypto::closure7(v4.clone(), string("first_letter_code"), ());
            ()
        };
        let v35: () = {
            Crypto::closure7(v4.clone(), string(" = "), ());
            ()
        };
        let v44: () = {
            Crypto::closure7(v4.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        let v55: () = {
            Crypto::closure7(v4.clone(), string("; "), ());
            ()
        };
        let v66: () = {
            Crypto::closure7(v4.clone(), string("hash_part"), ());
            ()
        };
        let v75: () = {
            Crypto::closure7(v4.clone(), string(" = "), ());
            ()
        };
        let v84: () = {
            Crypto::closure7(v4.clone(), v1_1, ());
            ()
        };
        let v93: () = {
            Crypto::closure7(v4.clone(), string("; "), ());
            ()
        };
        let v104: () = {
            Crypto::closure7(v4.clone(), string("combined_value"), ());
            ()
        };
        let v113: () = {
            Crypto::closure7(v4.clone(), string(" = "), ());
            ()
        };
        let v122: () = {
            Crypto::closure7(v4.clone(), sprintf!("{}", v2), ());
            ()
        };
        let v133: () = {
            Crypto::closure7(v4.clone(), string(" }"), ());
            ()
        };
        v4.l0.get().clone()
    }
    pub fn method22(v0_1: string) -> string {
        trimEndChars(
            trimStartChars(v0_1, toArray_1(empty::<char>())),
            toArray_1(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method20(
        v0_1: LrcPtr<Crypto::Mut1>,
        v1_1: LrcPtr<Crypto::Mut2>,
        v2: LrcPtr<Crypto::Mut3>,
        v3: LrcPtr<Crypto::Mut4>,
        v4: LrcPtr<Crypto::Mut5>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
        v9: string,
        v10: u16,
    ) -> string {
        let v11: string = Crypto::method21(v8, v9, v10);
        Crypto::method22(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("crypto.hash_to_port"),
            v11
        ))
    }
    pub fn closure8(v0_1: LrcPtr<Crypto::Mut1>, unitVar: ()) {
        let v2: i64 = (v0_1.l0.get().clone()) + 1_i64;
        v0_1.l0.set(v2);
        ()
    }
    pub fn closure10(v0_1: string, unitVar: ()) {
        printfn!("{0}", v0_1);
    }
    pub fn closure9(unitVar: (), v0_1: string) {
        let v3: () = {
            Crypto::closure10(v0_1, ());
            ()
        };
        ()
    }
    pub fn method23(v0_1: string) {
        let v3: () = {
            Crypto::closure3((), ());
            ()
        };
        let patternInput: (
            LrcPtr<Crypto::Mut1>,
            LrcPtr<Crypto::Mut2>,
            LrcPtr<Crypto::Mut3>,
            LrcPtr<Crypto::Mut4>,
            LrcPtr<Crypto::Mut5>,
            Option<i64>,
        ) = Crypto::TraceState::trace_state().get().clone().unwrap();
        let v44: () = {
            Crypto::closure8(patternInput.0.clone(), ());
            ()
        };
        println!("{}", v0_1.clone());
        ((patternInput.1.clone()).l0.get().clone())(v0_1)
    }
    pub fn closure2(v0_1: i32, v1_1: string, v2: u16, unitVar: ()) {
        if Crypto::method5(Crypto::US0::US0_0) {
            let v7: () = {
                Crypto::closure3((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Crypto::Mut1>,
                LrcPtr<Crypto::Mut2>,
                LrcPtr<Crypto::Mut3>,
                LrcPtr<Crypto::Mut4>,
                LrcPtr<Crypto::Mut5>,
                Option<i64>,
            ) = Crypto::TraceState::trace_state().get().clone().unwrap();
            let v33: Option<i64> = patternInput.5.clone();
            let v32: LrcPtr<Crypto::Mut5> = patternInput.4.clone();
            let v31: LrcPtr<Crypto::Mut4> = patternInput.3.clone();
            let v30: LrcPtr<Crypto::Mut3> = patternInput.2.clone();
            let v29: LrcPtr<Crypto::Mut2> = patternInput.1.clone();
            let v28: LrcPtr<Crypto::Mut1> = patternInput.0.clone();
            Crypto::method23(Crypto::method20(
                v28.clone(),
                v29.clone(),
                v30.clone(),
                v31.clone(),
                v32.clone(),
                v33.clone(),
                Crypto::method12(v28, v29, v30, v31, v32, v33),
                Crypto::method16(),
                v0_1,
                v1_1,
                v2,
            ))
        };
    }
    pub fn closure1(unitVar: (), v0_1: string) -> u16 {
        let v96: i32 = getCharAt(v0_1.clone(), 0_i32) as u32 as i32;
        let v114: string = getSlice(v0_1, Some(0_i32), Some(7_i32));
        let v124: u16 = ((toInt32_radix(v114.clone(), 16_i32)) + (v96)) as u16;
        let v129: () = {
            Crypto::closure2(v96, v114, v124, ());
            ()
        };
        ((v124) % 48128_u16) + 1024_u16
    }
    pub fn v0() -> Func1<string, string> {
        static v0: OnceInit<Func1<string, string>> = OnceInit::new();
        v0.get_or_init(|| Func1::new(move |v: string| Crypto::closure0((), v)))
            .clone()
    }
    pub fn hash_text(x: string) -> string {
        (Crypto::v0())(x)
    }
    pub fn v1() -> Func1<string, u16> {
        static v1: OnceInit<Func1<string, u16>> = OnceInit::new();
        v1.get_or_init(|| Func1::new(move |v: string| Crypto::closure1((), v)))
            .clone()
    }
    pub fn hash_to_port(x: string) -> u16 {
        (Crypto::v1())(x)
    }
    on_startup!(());
}
