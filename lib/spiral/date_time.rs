pub mod Date_time {
    use super::*;
    use fable_library_rust::Convert_::toInt64;
    use fable_library_rust::DateTime_::DateTime;
    use fable_library_rust::Guid_::Guid;
    use fable_library_rust::Guid_::new_guid;
    use fable_library_rust::Guid_::parse;
    use fable_library_rust::Native_::Func1;
    use fable_library_rust::Native_::LrcPtr;
    use fable_library_rust::Native_::OnceInit;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::Option_::defaultValue;
    use fable_library_rust::Option_::map;
    use fable_library_rust::String_::append;
    use fable_library_rust::String_::concat;
    use fable_library_rust::String_::getCharAt;
    use fable_library_rust::String_::getSlice;
    use fable_library_rust::String_::length;
    use fable_library_rust::String_::ofChar;
    use fable_library_rust::String_::replace;
    use fable_library_rust::String_::sprintf;
    use fable_library_rust::String_::string;
    use fable_library_rust::String_::toString;
    use fable_library_rust::TimeSpan_::TimeSpan;
    type TimeZoneInfo = i64;
    #[derive(Clone, Debug)]
    pub enum US0 {
        US0_0(chrono::DateTime<chrono::Utc>),
        US0_1,
    }
    impl core::fmt::Display for US0 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US1 {
        US1_0(string),
        US1_1,
    }
    impl core::fmt::Display for US1 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US2 {
        US2_0,
        US2_1,
        US2_2,
    }
    impl core::fmt::Display for US2 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US3 {
        US3_0(Date_time::US2),
        US3_1(Date_time::US2),
        US3_2(Date_time::US2),
        US3_3(Date_time::US2),
        US3_4(Date_time::US2),
        US3_5(Date_time::US2),
    }
    impl core::fmt::Display for US3 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    pub fn closure2(unitVar: (), v0_1: chrono::DateTime<chrono::Utc>) -> Date_time::US0 {
        Date_time::US0::US0_0(v0_1)
    }
    pub fn method1() -> Func1<chrono::DateTime<chrono::Utc>, Date_time::US0> {
        Func1::new(move |v: chrono::DateTime<chrono::Utc>| Date_time::closure2((), v))
    }
    pub fn method2() -> string {
        string("hh:mm")
    }
    pub fn method3() -> string {
        string("yyyyMMdd-HHmm-ssff-ffff-f")
    }
    pub fn method4() -> string {
        string("hhmm")
    }
    pub fn method0(v0_1: Guid, v1_1: DateTime) -> Guid {
        let v610: DateTime = {
            let _arg: DateTime = DateTime::unixEpoch();
            _arg.toUniversalTime()
        };
        let v620: DateTime = {
            let _arg_1: DateTime = DateTime::specifyKind(v1_1, 2_i32);
            _arg_1.toUniversalTime()
        };
        let v718: i64 = ((v620.ticks()) - (v610.ticks())) / 10_i64;
        let v720: Option<chrono::DateTime<chrono::Utc>> =
            chrono::DateTime::from_timestamp_micros(v718);
        let v745: Date_time::US0 =
            defaultValue(Date_time::US0::US0_1, map(Date_time::method1(), v720));
        let v765: Date_time::US1 = match &v745 {
            Date_time::US0::US0_0(v745_0_0) => {
                let v751: chrono::NaiveDateTime = match &v745 {
                    Date_time::US0::US0_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone()
                .naive_utc();
                let v753: chrono::DateTime<chrono::Local> =
                    chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &v751);
                let v755: string = string("r#\"%Y%m%d-%H%M-%S%f\"#");
                let v756: &str = r#"%Y%m%d-%H%M-%S%f"#;
                let v758: std::string::String = v753.format(v756).to_string();
                let v760: string = fable_library_rust::String_::fromString(v758);
                Date_time::US1::US1_0(sprintf!(
                    "{}-{}-{}",
                    getSlice(v760.clone(), Some(0_i32), Some(17_i32)),
                    getSlice(v760.clone(), Some(18_i32), Some(21_i32)),
                    getCharAt(v760, 22_i32)
                ))
            }
            _ => Date_time::US1::US1_1,
        };
        let v769: string = match &v765 {
            Date_time::US1::US1_0(v765_0_0) => match &v765 {
                Date_time::US1::US1_0(x) => x.clone(),
                _ => unreachable!(),
            }
            .clone(),
            _ => string(""),
        };
        let v776: LrcPtr<TimeZoneInfo> = std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(
            chrono::Local::now().offset(),
        ) as i64);
        let v817: i64 = v620.ticks();
        let v852: string = string(
            "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))",
        );
        let v996: TimeSpan = TimeSpan::new_ticks(chrono::FixedOffset::local_minus_utc(
            &chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(
                &chrono::DateTime::from_timestamp_nanos(v817),
            )),
        ) as i64);
        let v1011: u8 = if (v996.hours()) > 0_i32 { 1_u8 } else { 0_u8 };
        let v1012: string = Date_time::method2();
        let v1199: string = v996.toString(v1012);
        let v1260: string = sprintf!(
            "{}{}{}",
            v1011,
            getSlice(v1199.clone(), Some(0_i32), Some(1_i32)),
            getSlice(v1199, Some(3_i32), Some(4_i32))
        );
        let v1263: string = toString(v0_1);
        parse(concat(new_array(&[
            v769.clone(),
            v1260.clone(),
            getSlice(
                v1263.clone(),
                Some((length(v769)) + (length(v1260))),
                Some((length(v1263)) - 1_i32),
            ),
        ])))
    }
    pub fn closure1(v0_1: Guid, v1_1: DateTime) -> Guid {
        Date_time::method0(v0_1, v1_1)
    }
    pub fn closure0(unitVar: (), v0_1: Guid) -> Func1<DateTime, Guid> {
        Func1::new({
            let v0_1 = v0_1.clone();
            move |v: DateTime| Date_time::closure1(v0_1.clone(), v)
        })
    }
    pub fn closure4(unitVar: (), v0_1: string) -> string {
        replace(v0_1, string("-"), string(""))
    }
    pub fn closure3(unitVar: (), v0_1: Guid) -> DateTime {
        DateTime::parse(Date_time::closure4(
            (),
            getSlice(toString(v0_1), None::<i32>, Some(24_i32)),
        ))
    }
    pub fn closure7(v0_1: i32, v1_1: string, v2_1: i32, v3_1: string) -> string {
        if (v2_1) >= (v0_1) {
            v3_1.clone()
        } else {
            (Date_time::method5(v0_1, v1_1.clone(), (v2_1) + 1_i32))(append((v3_1), (v1_1)))
        }
    }
    pub fn method5(v0_1: i32, v1_1: string, v2_1: i32) -> Func1<string, string> {
        Func1::new({
            let v0_1 = v0_1.clone();
            let v1_1 = v1_1.clone();
            let v2_1 = v2_1.clone();
            move |v: string| Date_time::closure7(v0_1, v1_1.clone(), v2_1, v)
        })
    }
    pub fn closure6(v0_1: Guid, v1_1: i64) -> Guid {
        let v4_1: string = toString(v0_1);
        let v9: string = toString(v1_1);
        let v14: string = ofChar('0');
        let v24: string = append(
            ((Date_time::method5(18_i32 - (length(v9.clone())), v14, 0_i32))(string(""))),
            (v9),
        );
        parse(sprintf!(
            "{}-{}-{}-{}{}",
            getSlice(v24.clone(), Some(0_i32), Some(7_i32)),
            getSlice(v24.clone(), Some(8_i32), Some(11_i32)),
            getSlice(v24.clone(), Some(12_i32), Some(15_i32)),
            getSlice(v24, Some(16_i32), Some(17_i32)),
            getSlice(v4_1, Some(21_i32), None::<i32>)
        ))
    }
    pub fn closure5(unitVar: (), v0_1: Guid) -> Func1<i64, Guid> {
        Func1::new({
            let v0_1 = v0_1.clone();
            move |v: i64| Date_time::closure6(v0_1.clone(), v)
        })
    }
    pub fn closure8(unitVar: (), v0_1: Guid) -> i64 {
        let v3_1: string = toString(v0_1);
        toInt64(concat(new_array(&[
            getSlice(v3_1.clone(), Some(0_i32), Some(7_i32)),
            getSlice(v3_1.clone(), Some(9_i32), Some(12_i32)),
            getSlice(v3_1.clone(), Some(14_i32), Some(17_i32)),
            getSlice(v3_1, Some(19_i32), Some(20_i32)),
        ])))
    }
    pub fn closure9(unitVar: (), v0_1: DateTime) -> Guid {
        Date_time::method0(new_guid(), v0_1)
    }
    pub fn closure10(unitVar: (), v0_1: i64) -> Guid {
        let v8: string = toString(new_guid());
        let v13: string = toString(v0_1);
        let v18: string = ofChar('0');
        let v28: string = append(
            ((Date_time::method5(18_i32 - (length(v13.clone())), v18, 0_i32))(string(""))),
            (v13),
        );
        parse(sprintf!(
            "{}-{}-{}-{}{}",
            getSlice(v28.clone(), Some(0_i32), Some(7_i32)),
            getSlice(v28.clone(), Some(8_i32), Some(11_i32)),
            getSlice(v28.clone(), Some(12_i32), Some(15_i32)),
            getSlice(v28, Some(16_i32), Some(17_i32)),
            getSlice(v8, Some(21_i32), None::<i32>)
        ))
    }
    pub fn closure12(v0_1: string, v1_1: DateTime) -> string {
        let provider: string = if (v0_1.clone()) == string("") {
            string("M-d-y hh:mm:ss tt")
        } else {
            v0_1
        };
        v1_1.toString(provider)
    }
    pub fn closure11(unitVar: (), v0_1: string) -> Func1<DateTime, string> {
        Func1::new({
            let v0_1 = v0_1.clone();
            move |v: DateTime| Date_time::closure12(v0_1.clone(), v)
        })
    }
    pub fn closure13(unitVar: (), v0_1: DateTime) -> string {
        v0_1.toString(string("yyyy-MM-ddTHH-mm-ss.fff"))
    }
    pub fn v0() -> Func1<Guid, Func1<DateTime, Guid>> {
        static v0: OnceInit<Func1<Guid, Func1<DateTime, Guid>>> = OnceInit::new();
        v0.get_or_init(|| Func1::new(move |v: Guid| Date_time::closure0((), v)))
            .clone()
    }
    pub fn date_time_guid_from_date_time(x: Guid) -> Func1<DateTime, Guid> {
        (Date_time::v0())(x)
    }
    pub fn v1() -> Func1<Guid, DateTime> {
        static v1: OnceInit<Func1<Guid, DateTime>> = OnceInit::new();
        v1.get_or_init(|| Func1::new(move |v: Guid| Date_time::closure3((), v)))
            .clone()
    }
    pub fn date_time_from_guid(x: Guid) -> DateTime {
        (Date_time::v1())(x)
    }
    pub fn v2() -> Func1<Guid, Func1<i64, Guid>> {
        static v2: OnceInit<Func1<Guid, Func1<i64, Guid>>> = OnceInit::new();
        v2.get_or_init(|| Func1::new(move |v: Guid| Date_time::closure5((), v)))
            .clone()
    }
    pub fn timestamp_guid_from_timestamp(x: Guid) -> Func1<i64, Guid> {
        (Date_time::v2())(x)
    }
    pub fn v3() -> Func1<Guid, i64> {
        static v3: OnceInit<Func1<Guid, i64>> = OnceInit::new();
        v3.get_or_init(|| Func1::new(move |v: Guid| Date_time::closure8((), v)))
            .clone()
    }
    pub fn timestamp_from_guid(x: Guid) -> i64 {
        (Date_time::v3())(x)
    }
    pub fn v4() -> Func1<DateTime, Guid> {
        static v4: OnceInit<Func1<DateTime, Guid>> = OnceInit::new();
        v4.get_or_init(|| Func1::new(move |v: DateTime| Date_time::closure9((), v)))
            .clone()
    }
    pub fn new_guid_from_date_time(x: DateTime) -> Guid {
        (Date_time::v4())(x)
    }
    pub fn v5() -> Func1<i64, Guid> {
        static v5: OnceInit<Func1<i64, Guid>> = OnceInit::new();
        v5.get_or_init(|| Func1::new(move |v: i64| Date_time::closure10((), v)))
            .clone()
    }
    pub fn new_guid_from_timestamp(x: i64) -> Guid {
        (Date_time::v5())(x)
    }
    pub fn v6() -> Func1<string, Func1<DateTime, string>> {
        static v6: OnceInit<Func1<string, Func1<DateTime, string>>> = OnceInit::new();
        v6.get_or_init(|| Func1::new(move |v: string| Date_time::closure11((), v)))
            .clone()
    }
    pub fn format(x: string) -> Func1<DateTime, string> {
        (Date_time::v6())(x)
    }
    pub fn v7() -> Func1<DateTime, string> {
        static v7: OnceInit<Func1<DateTime, string>> = OnceInit::new();
        v7.get_or_init(|| Func1::new(move |v: DateTime| Date_time::closure13((), v)))
            .clone()
    }
    pub fn format_iso8601(x: DateTime) -> string {
        (Date_time::v7())(x)
    }
    on_startup!(());
}
