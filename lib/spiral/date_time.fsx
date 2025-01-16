#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::DateTime<$0>")>]
#endif
type chrono_DateTime<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::NaiveDateTime")>]
#endif
type chrono_NaiveDateTime = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("&$0")>]
type Ref<'T> = class end
#else
type Ref<'T> = 'T
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::string::String")>]
type std_string_String = class end
#else
type std_string_String = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::Utc")>]
#endif
type chrono_Utc = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::Local")>]
#endif
type chrono_Local = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("str")>]
type Str = class end
#else
type Str = string
#endif

type [<Struct>] US0 =
    | US0_0 of f0_0 : chrono_DateTime<chrono_Utc>
    | US0_1
and [<Struct>] US1 =
    | US1_0 of f0_0 : string
    | US1_1
and [<Struct>] US2 =
    | US2_0
    | US2_1
    | US2_2
and [<Struct>] US3 =
    | US3_0 of f0_0 : US2
    | US3_1 of f1_0 : US2
    | US3_2 of f2_0 : US2
    | US3_3 of f3_0 : US2
    | US3_4 of f4_0 : US2
let rec closure2 () (v0 : chrono_DateTime<chrono_Utc>) : US0 =
    US0_0(v0)
and method1 () : (chrono_DateTime<chrono_Utc> -> US0) =
    closure2()
and method2 () : string =
    let v0 : string = "hh:mm"
    v0
and method3 () : string =
    let v0 : string = "yyyyMMdd-HHmm-ssff-ffff-f"
    v0
and method4 () : string =
    let v0 : string = "hhmm"
    v0
and method0 (v0 : System.Guid, v1 : System.DateTime) : System.Guid =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : System.DateTime = System.DateTime.UnixEpoch
    let v6 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v7 : System.DateTime = v6 v3
    let v10 : System.DateTimeKind = System.DateTimeKind.Local
    let v11 : System.DateTime = System.DateTime.SpecifyKind (v1, v10)
    let v14 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v15 : System.DateTime = v14 v11
    (* run_target_args'
    let v18 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v19 : (System.DateTime -> int64) = _.Ticks
    let v20 : int64 = v19 v15
    let _run_target_args'_v18 = v20 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v21 : (System.DateTime -> int64) = _.Ticks
    let v22 : int64 = v21 v15
    let _run_target_args'_v18 = v22 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v23 : int64 = null |> unbox<int64>
    let _run_target_args'_v18 = v23 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v26 : (System.DateTime -> int64) = _.Ticks
    let v27 : int64 = v26 v15
    let _run_target_args'_v18 = v27 
    #endif
#if FABLE_COMPILER_PYTHON
    let v28 : (System.DateTime -> int64) = _.Ticks
    let v29 : int64 = v28 v15
    let _run_target_args'_v18 = v29 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v30 : (System.DateTime -> int64) = _.Ticks
    let v31 : int64 = v30 v15
    let _run_target_args'_v18 = v31 
    #endif
#else
    let v32 : (System.DateTime -> int64) = _.Ticks
    let v33 : int64 = v32 v15
    let _run_target_args'_v18 = v33 
    #endif
    let v34 : int64 = _run_target_args'_v18 
    (* run_target_args'
    let v51 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v52 : (System.DateTime -> int64) = _.Ticks
    let v53 : int64 = v52 v7
    let _run_target_args'_v51 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : (System.DateTime -> int64) = _.Ticks
    let v55 : int64 = v54 v7
    let _run_target_args'_v51 = v55 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v56 : int64 = null |> unbox<int64>
    let _run_target_args'_v51 = v56 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v59 : (System.DateTime -> int64) = _.Ticks
    let v60 : int64 = v59 v7
    let _run_target_args'_v51 = v60 
    #endif
#if FABLE_COMPILER_PYTHON
    let v61 : (System.DateTime -> int64) = _.Ticks
    let v62 : int64 = v61 v7
    let _run_target_args'_v51 = v62 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : (System.DateTime -> int64) = _.Ticks
    let v64 : int64 = v63 v7
    let _run_target_args'_v51 = v64 
    #endif
#else
    let v65 : (System.DateTime -> int64) = _.Ticks
    let v66 : int64 = v65 v7
    let _run_target_args'_v51 = v66 
    #endif
    let v67 : int64 = _run_target_args'_v51 
    let v84 : int64 = v34 |> int64 
    let v87 : int64 = v67 |> int64 
    let v90 : int64 = v84 - v87
    let v91 : int64 = v90 / 10L
    let v92 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v93 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v91 v92 
    let v94 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v95 : US0 option = v93 |> Option.map v94 
    let v106 : US0 = US0_1
    let v107 : US0 = v95 |> Option.defaultValue v106 
    let v127 : US1 =
        match v107 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v111) -> (* Some *)
            let v112 : string = "$0.naive_utc()"
            let v113 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v111 v112 
            let v114 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v115 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v113 v114 
            let v116 : string = "%Y%m%d-%H%M-%S%f"
            let v117 : string = "r#\"" + v116 + "\"#"
            let v118 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v117 
            let v119 : string = "$0.format($1).to_string()"
            let v120 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v115, v118) v119 
            let v121 : string = "fable_library_rust::String_::fromString($0)"
            let v122 : string = Fable.Core.RustInterop.emitRustExpr v120 v121 
            let v123 : string = $"{v122.[0..17]}-{v122.[18..21]}-{v122.[22]}"
            US1_0(v123)
    let v131 : string =
        match v127 with
        | US1_1 -> (* None *)
            let v129 : string = ""
            v129
        | US1_0(v128) -> (* Some *)
            v128
    (* run_target_args'
    let v132 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v133 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v134 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v133 
    let _run_target_args'_v132 = v134 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v135 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v132 = v135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v138 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v132 = v138 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v141 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v132 = v141 
    #endif
#if FABLE_COMPILER_PYTHON
    let v144 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v132 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v147 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v132 = v147 
    #endif
#else
    let v148 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v132 = v148 
    #endif
    let v149 : System.TimeZoneInfo = _run_target_args'_v132 
    (* run_target_args'
    let v154 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v155 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v156 : (System.DateTime -> int64) = _.Ticks
    let v157 : int64 = v156 v15
    let _run_target_args'_v155 = v157 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v158 : (System.DateTime -> int64) = _.Ticks
    let v159 : int64 = v158 v15
    let _run_target_args'_v155 = v159 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v160 : int64 = null |> unbox<int64>
    let _run_target_args'_v155 = v160 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v163 : (System.DateTime -> int64) = _.Ticks
    let v164 : int64 = v163 v15
    let _run_target_args'_v155 = v164 
    #endif
#if FABLE_COMPILER_PYTHON
    let v165 : (System.DateTime -> int64) = _.Ticks
    let v166 : int64 = v165 v15
    let _run_target_args'_v155 = v166 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v167 : (System.DateTime -> int64) = _.Ticks
    let v168 : int64 = v167 v15
    let _run_target_args'_v155 = v168 
    #endif
#else
    let v169 : (System.DateTime -> int64) = _.Ticks
    let v170 : int64 = v169 v15
    let _run_target_args'_v155 = v170 
    #endif
    let v171 : int64 = _run_target_args'_v155 
    let v188 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v189 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v15, v171) v188 
    let v190 : System.TimeSpan = v189 |> System.TimeSpan 
    let _run_target_args'_v154 = v190 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v193 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v194 : (System.DateTime -> int64) = _.Ticks
    let v195 : int64 = v194 v15
    let _run_target_args'_v193 = v195 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v196 : (System.DateTime -> int64) = _.Ticks
    let v197 : int64 = v196 v15
    let _run_target_args'_v193 = v197 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v198 : int64 = null |> unbox<int64>
    let _run_target_args'_v193 = v198 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v201 : (System.DateTime -> int64) = _.Ticks
    let v202 : int64 = v201 v15
    let _run_target_args'_v193 = v202 
    #endif
#if FABLE_COMPILER_PYTHON
    let v203 : (System.DateTime -> int64) = _.Ticks
    let v204 : int64 = v203 v15
    let _run_target_args'_v193 = v204 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v205 : (System.DateTime -> int64) = _.Ticks
    let v206 : int64 = v205 v15
    let _run_target_args'_v193 = v206 
    #endif
#else
    let v207 : (System.DateTime -> int64) = _.Ticks
    let v208 : int64 = v207 v15
    let _run_target_args'_v193 = v208 
    #endif
    let v209 : int64 = _run_target_args'_v193 
    let v226 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v227 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v15, v209) v226 
    let v228 : System.TimeSpan = v227 |> System.TimeSpan 
    let _run_target_args'_v154 = v228 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v231 : US2 = US2_2
    let v232 : US3 = US3_2(v231)
    let v233 : string = $"date_time.get_utc_offset / target: {v232}"
    let v234 : System.TimeSpan = failwith<System.TimeSpan> v233
    let _run_target_args'_v154 = v234 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v237 : US2 = US2_0
    let v238 : US3 = US3_3(v237)
    let v239 : string = $"date_time.get_utc_offset / target: {v238}"
    let v240 : System.TimeSpan = failwith<System.TimeSpan> v239
    let _run_target_args'_v154 = v240 
    #endif
#if FABLE_COMPILER_PYTHON
    let v243 : US2 = US2_0
    let v244 : US3 = US3_4(v243)
    let v245 : string = $"date_time.get_utc_offset / target: {v244}"
    let v246 : System.TimeSpan = failwith<System.TimeSpan> v245
    let _run_target_args'_v154 = v246 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v249 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v250 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v251 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v252 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v251 
    let _run_target_args'_v250 = v252 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v253 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v250 = v253 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v256 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v250 = v256 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v259 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v250 = v259 
    #endif
#if FABLE_COMPILER_PYTHON
    let v262 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v250 = v262 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v265 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v250 = v265 
    #endif
#else
    let v266 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v250 = v266 
    #endif
    let v267 : System.TimeZoneInfo = _run_target_args'_v250 
    let v272 : (System.DateTime -> System.TimeSpan) = v249 v267
    let v273 : System.TimeSpan = v272 v15
    let _run_target_args'_v154 = v273 
    #endif
#else
    let v274 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v275 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v276 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v277 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v276 
    let _run_target_args'_v275 = v277 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v278 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v275 = v278 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v281 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v275 = v281 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v284 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v275 = v284 
    #endif
#if FABLE_COMPILER_PYTHON
    let v287 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v275 = v287 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v290 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v275 = v290 
    #endif
#else
    let v291 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v275 = v291 
    #endif
    let v292 : System.TimeZoneInfo = _run_target_args'_v275 
    let v297 : (System.DateTime -> System.TimeSpan) = v274 v292
    let v298 : System.TimeSpan = v297 v15
    let _run_target_args'_v154 = v298 
    #endif
    let v299 : System.TimeSpan = _run_target_args'_v154 
    let v307 : (System.TimeSpan -> int32) = _.Hours
    let v308 : int32 = v307 v299
    let v311 : bool = v308 > 0
    let v312 : uint8 =
        if v311 then
            1uy
        else
            0uy
    let v313 : string = method2()
    (* run_target_args'
    let v314 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v315 : string = "$0.to_string($1)"
    let v316 : string = Fable.Core.RustInterop.emitRustExpr struct (v299, v313) v315 
    let _run_target_args'_v314 = v316 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v317 : string = "$0.to_string($1)"
    let v318 : string = Fable.Core.RustInterop.emitRustExpr struct (v299, v313) v317 
    let _run_target_args'_v314 = v318 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v319 : string = "$0.to_string($1)"
    let v320 : string = Fable.Core.RustInterop.emitRustExpr struct (v299, v313) v319 
    let _run_target_args'_v314 = v320 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v321 : string = v299.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v314 = v321 
    #endif
#if FABLE_COMPILER_PYTHON
    let v322 : string = v299.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v314 = v322 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v323 : string = v299.ToString v313 
    let _run_target_args'_v314 = v323 
    #endif
#else
    let v326 : string = v299.ToString v313 
    let _run_target_args'_v314 = v326 
    #endif
    let v329 : string = _run_target_args'_v314 
    let v334 : string = $"{v312}{v329.[0..1]}{v329.[3..4]}"
    let v335 : (System.Guid -> string) = _.ToString()
    let v336 : string = v335 v0
    let v339 : int32 = v131.Length
    let v340 : int32 = v334.Length
    let v341 : int32 = v339 + v340
    let v342 : (string -> int32) = String.length
    let v343 : int32 = v342 v336
    let v346 : int32 = v341 |> int32 
    let v353 : int32 = v343 |> int32 
    let v360 : int32 = v353 - 1
    let v361 : string = v336.[int v346..int v360]
    let v365 : string = $"{v131}{v334}{v361}"
    (* run_target_args'
    let v366 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v367 : System.Guid = v365 |> System.Guid 
    let _run_target_args'_v366 = v367 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v370 : System.Guid = v365 |> System.Guid 
    let _run_target_args'_v366 = v370 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v373 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v366 = v373 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v376 : System.Guid = v365 |> System.Guid 
    let _run_target_args'_v366 = v376 
    #endif
#if FABLE_COMPILER_PYTHON
    let v379 : System.Guid = v365 |> System.Guid 
    let _run_target_args'_v366 = v379 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v382 : System.Guid = v365 |> System.Guid 
    let _run_target_args'_v366 = v382 
    #endif
#else
    let v385 : System.Guid = v365 |> System.Guid 
    let _run_target_args'_v366 = v385 
    #endif
    let v388 : System.Guid = _run_target_args'_v366 
    let _run_target_args'_v2 = v388 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v393 : System.DateTime = System.DateTime.UnixEpoch
    let v396 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v397 : System.DateTime = v396 v393
    let v400 : System.DateTimeKind = System.DateTimeKind.Local
    let v401 : System.DateTime = System.DateTime.SpecifyKind (v1, v400)
    let v404 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v405 : System.DateTime = v404 v401
    (* run_target_args'
    let v408 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v409 : (System.DateTime -> int64) = _.Ticks
    let v410 : int64 = v409 v405
    let _run_target_args'_v408 = v410 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v411 : (System.DateTime -> int64) = _.Ticks
    let v412 : int64 = v411 v405
    let _run_target_args'_v408 = v412 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v413 : int64 = null |> unbox<int64>
    let _run_target_args'_v408 = v413 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v416 : (System.DateTime -> int64) = _.Ticks
    let v417 : int64 = v416 v405
    let _run_target_args'_v408 = v417 
    #endif
#if FABLE_COMPILER_PYTHON
    let v418 : (System.DateTime -> int64) = _.Ticks
    let v419 : int64 = v418 v405
    let _run_target_args'_v408 = v419 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v420 : (System.DateTime -> int64) = _.Ticks
    let v421 : int64 = v420 v405
    let _run_target_args'_v408 = v421 
    #endif
#else
    let v422 : (System.DateTime -> int64) = _.Ticks
    let v423 : int64 = v422 v405
    let _run_target_args'_v408 = v423 
    #endif
    let v424 : int64 = _run_target_args'_v408 
    (* run_target_args'
    let v441 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v442 : (System.DateTime -> int64) = _.Ticks
    let v443 : int64 = v442 v397
    let _run_target_args'_v441 = v443 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v444 : (System.DateTime -> int64) = _.Ticks
    let v445 : int64 = v444 v397
    let _run_target_args'_v441 = v445 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v446 : int64 = null |> unbox<int64>
    let _run_target_args'_v441 = v446 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v449 : (System.DateTime -> int64) = _.Ticks
    let v450 : int64 = v449 v397
    let _run_target_args'_v441 = v450 
    #endif
#if FABLE_COMPILER_PYTHON
    let v451 : (System.DateTime -> int64) = _.Ticks
    let v452 : int64 = v451 v397
    let _run_target_args'_v441 = v452 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v453 : (System.DateTime -> int64) = _.Ticks
    let v454 : int64 = v453 v397
    let _run_target_args'_v441 = v454 
    #endif
#else
    let v455 : (System.DateTime -> int64) = _.Ticks
    let v456 : int64 = v455 v397
    let _run_target_args'_v441 = v456 
    #endif
    let v457 : int64 = _run_target_args'_v441 
    let v474 : int64 = v424 |> int64 
    let v477 : int64 = v457 |> int64 
    let v480 : int64 = v474 - v477
    let v481 : int64 = v480 / 10L
    let v482 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v483 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v481 v482 
    let v484 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v485 : US0 option = v483 |> Option.map v484 
    let v496 : US0 = US0_1
    let v497 : US0 = v485 |> Option.defaultValue v496 
    let v517 : US1 =
        match v497 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v501) -> (* Some *)
            let v502 : string = "$0.naive_utc()"
            let v503 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v501 v502 
            let v504 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v505 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v503 v504 
            let v506 : string = "%Y%m%d-%H%M-%S%f"
            let v507 : string = "r#\"" + v506 + "\"#"
            let v508 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v507 
            let v509 : string = "$0.format($1).to_string()"
            let v510 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v505, v508) v509 
            let v511 : string = "fable_library_rust::String_::fromString($0)"
            let v512 : string = Fable.Core.RustInterop.emitRustExpr v510 v511 
            let v513 : string = $"{v512.[0..17]}-{v512.[18..21]}-{v512.[22]}"
            US1_0(v513)
    let v521 : string =
        match v517 with
        | US1_1 -> (* None *)
            let v519 : string = ""
            v519
        | US1_0(v518) -> (* Some *)
            v518
    (* run_target_args'
    let v522 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v523 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v524 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v523 
    let _run_target_args'_v522 = v524 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v525 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v522 = v525 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v528 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v522 = v528 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v531 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v522 = v531 
    #endif
#if FABLE_COMPILER_PYTHON
    let v534 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v522 = v534 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v537 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v522 = v537 
    #endif
#else
    let v538 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v522 = v538 
    #endif
    let v539 : System.TimeZoneInfo = _run_target_args'_v522 
    (* run_target_args'
    let v544 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v545 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v546 : (System.DateTime -> int64) = _.Ticks
    let v547 : int64 = v546 v405
    let _run_target_args'_v545 = v547 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v548 : (System.DateTime -> int64) = _.Ticks
    let v549 : int64 = v548 v405
    let _run_target_args'_v545 = v549 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v550 : int64 = null |> unbox<int64>
    let _run_target_args'_v545 = v550 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v553 : (System.DateTime -> int64) = _.Ticks
    let v554 : int64 = v553 v405
    let _run_target_args'_v545 = v554 
    #endif
#if FABLE_COMPILER_PYTHON
    let v555 : (System.DateTime -> int64) = _.Ticks
    let v556 : int64 = v555 v405
    let _run_target_args'_v545 = v556 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v557 : (System.DateTime -> int64) = _.Ticks
    let v558 : int64 = v557 v405
    let _run_target_args'_v545 = v558 
    #endif
#else
    let v559 : (System.DateTime -> int64) = _.Ticks
    let v560 : int64 = v559 v405
    let _run_target_args'_v545 = v560 
    #endif
    let v561 : int64 = _run_target_args'_v545 
    let v578 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v579 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v405, v561) v578 
    let v580 : System.TimeSpan = v579 |> System.TimeSpan 
    let _run_target_args'_v544 = v580 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v583 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v584 : (System.DateTime -> int64) = _.Ticks
    let v585 : int64 = v584 v405
    let _run_target_args'_v583 = v585 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v586 : (System.DateTime -> int64) = _.Ticks
    let v587 : int64 = v586 v405
    let _run_target_args'_v583 = v587 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v588 : int64 = null |> unbox<int64>
    let _run_target_args'_v583 = v588 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v591 : (System.DateTime -> int64) = _.Ticks
    let v592 : int64 = v591 v405
    let _run_target_args'_v583 = v592 
    #endif
#if FABLE_COMPILER_PYTHON
    let v593 : (System.DateTime -> int64) = _.Ticks
    let v594 : int64 = v593 v405
    let _run_target_args'_v583 = v594 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v595 : (System.DateTime -> int64) = _.Ticks
    let v596 : int64 = v595 v405
    let _run_target_args'_v583 = v596 
    #endif
#else
    let v597 : (System.DateTime -> int64) = _.Ticks
    let v598 : int64 = v597 v405
    let _run_target_args'_v583 = v598 
    #endif
    let v599 : int64 = _run_target_args'_v583 
    let v616 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v617 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v405, v599) v616 
    let v618 : System.TimeSpan = v617 |> System.TimeSpan 
    let _run_target_args'_v544 = v618 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v621 : US2 = US2_2
    let v622 : US3 = US3_2(v621)
    let v623 : string = $"date_time.get_utc_offset / target: {v622}"
    let v624 : System.TimeSpan = failwith<System.TimeSpan> v623
    let _run_target_args'_v544 = v624 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v627 : US2 = US2_0
    let v628 : US3 = US3_3(v627)
    let v629 : string = $"date_time.get_utc_offset / target: {v628}"
    let v630 : System.TimeSpan = failwith<System.TimeSpan> v629
    let _run_target_args'_v544 = v630 
    #endif
#if FABLE_COMPILER_PYTHON
    let v633 : US2 = US2_0
    let v634 : US3 = US3_4(v633)
    let v635 : string = $"date_time.get_utc_offset / target: {v634}"
    let v636 : System.TimeSpan = failwith<System.TimeSpan> v635
    let _run_target_args'_v544 = v636 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v639 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v640 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v641 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v642 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v641 
    let _run_target_args'_v640 = v642 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v643 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v640 = v643 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v646 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v640 = v646 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v649 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v640 = v649 
    #endif
#if FABLE_COMPILER_PYTHON
    let v652 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v640 = v652 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v655 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v640 = v655 
    #endif
#else
    let v656 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v640 = v656 
    #endif
    let v657 : System.TimeZoneInfo = _run_target_args'_v640 
    let v662 : (System.DateTime -> System.TimeSpan) = v639 v657
    let v663 : System.TimeSpan = v662 v405
    let _run_target_args'_v544 = v663 
    #endif
#else
    let v664 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v665 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v666 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v667 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v666 
    let _run_target_args'_v665 = v667 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v668 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v665 = v668 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v671 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v665 = v671 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v674 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v665 = v674 
    #endif
#if FABLE_COMPILER_PYTHON
    let v677 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v665 = v677 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v680 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v665 = v680 
    #endif
#else
    let v681 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v665 = v681 
    #endif
    let v682 : System.TimeZoneInfo = _run_target_args'_v665 
    let v687 : (System.DateTime -> System.TimeSpan) = v664 v682
    let v688 : System.TimeSpan = v687 v405
    let _run_target_args'_v544 = v688 
    #endif
    let v689 : System.TimeSpan = _run_target_args'_v544 
    let v697 : (System.TimeSpan -> int32) = _.Hours
    let v698 : int32 = v697 v689
    let v701 : bool = v698 > 0
    let v702 : uint8 =
        if v701 then
            1uy
        else
            0uy
    let v703 : string = method2()
    (* run_target_args'
    let v704 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v705 : string = "$0.to_string($1)"
    let v706 : string = Fable.Core.RustInterop.emitRustExpr struct (v689, v703) v705 
    let _run_target_args'_v704 = v706 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v707 : string = "$0.to_string($1)"
    let v708 : string = Fable.Core.RustInterop.emitRustExpr struct (v689, v703) v707 
    let _run_target_args'_v704 = v708 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v709 : string = "$0.to_string($1)"
    let v710 : string = Fable.Core.RustInterop.emitRustExpr struct (v689, v703) v709 
    let _run_target_args'_v704 = v710 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v711 : string = v689.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v704 = v711 
    #endif
#if FABLE_COMPILER_PYTHON
    let v712 : string = v689.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v704 = v712 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v713 : string = v689.ToString v703 
    let _run_target_args'_v704 = v713 
    #endif
#else
    let v716 : string = v689.ToString v703 
    let _run_target_args'_v704 = v716 
    #endif
    let v719 : string = _run_target_args'_v704 
    let v724 : string = $"{v702}{v719.[0..1]}{v719.[3..4]}"
    let v725 : (System.Guid -> string) = _.ToString()
    let v726 : string = v725 v0
    let v729 : int32 = v521.Length
    let v730 : int32 = v724.Length
    let v731 : int32 = v729 + v730
    let v732 : (string -> int32) = String.length
    let v733 : int32 = v732 v726
    let v736 : int32 = v731 |> int32 
    let v743 : int32 = v733 |> int32 
    let v750 : int32 = v743 - 1
    let v751 : string = v726.[int v736..int v750]
    let v755 : string = $"{v521}{v724}{v751}"
    (* run_target_args'
    let v756 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v757 : System.Guid = v755 |> System.Guid 
    let _run_target_args'_v756 = v757 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v760 : System.Guid = v755 |> System.Guid 
    let _run_target_args'_v756 = v760 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v763 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v756 = v763 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v766 : System.Guid = v755 |> System.Guid 
    let _run_target_args'_v756 = v766 
    #endif
#if FABLE_COMPILER_PYTHON
    let v769 : System.Guid = v755 |> System.Guid 
    let _run_target_args'_v756 = v769 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v772 : System.Guid = v755 |> System.Guid 
    let _run_target_args'_v756 = v772 
    #endif
#else
    let v775 : System.Guid = v755 |> System.Guid 
    let _run_target_args'_v756 = v775 
    #endif
    let v778 : System.Guid = _run_target_args'_v756 
    let _run_target_args'_v2 = v778 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v783 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2 = v783 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v786 : string = method3()
    let v787 : bool = v786 = ""
    let v789 : string =
        if v787 then
            let v788 : string = "M-d-y hh:mm:ss tt"
            v788
        else
            v786
    let v790 : (string -> string) = v1.ToString
    let v791 : string = v790 v789
    (* run_target_args'
    let v805 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v806 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v807 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v806 
    let _run_target_args'_v805 = v807 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v808 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v805 = v808 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v811 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v805 = v811 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v814 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v805 = v814 
    #endif
#if FABLE_COMPILER_PYTHON
    let v817 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v805 = v817 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v820 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v805 = v820 
    #endif
#else
    let v821 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v805 = v821 
    #endif
    let v822 : System.TimeZoneInfo = _run_target_args'_v805 
    (* run_target_args'
    let v827 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v828 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v829 : (System.DateTime -> int64) = _.Ticks
    let v830 : int64 = v829 v1
    let _run_target_args'_v828 = v830 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v831 : (System.DateTime -> int64) = _.Ticks
    let v832 : int64 = v831 v1
    let _run_target_args'_v828 = v832 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v833 : int64 = null |> unbox<int64>
    let _run_target_args'_v828 = v833 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v836 : (System.DateTime -> int64) = _.Ticks
    let v837 : int64 = v836 v1
    let _run_target_args'_v828 = v837 
    #endif
#if FABLE_COMPILER_PYTHON
    let v838 : (System.DateTime -> int64) = _.Ticks
    let v839 : int64 = v838 v1
    let _run_target_args'_v828 = v839 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v840 : (System.DateTime -> int64) = _.Ticks
    let v841 : int64 = v840 v1
    let _run_target_args'_v828 = v841 
    #endif
#else
    let v842 : (System.DateTime -> int64) = _.Ticks
    let v843 : int64 = v842 v1
    let _run_target_args'_v828 = v843 
    #endif
    let v844 : int64 = _run_target_args'_v828 
    let v861 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v862 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v844) v861 
    let v863 : System.TimeSpan = v862 |> System.TimeSpan 
    let _run_target_args'_v827 = v863 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v866 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v867 : (System.DateTime -> int64) = _.Ticks
    let v868 : int64 = v867 v1
    let _run_target_args'_v866 = v868 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v869 : (System.DateTime -> int64) = _.Ticks
    let v870 : int64 = v869 v1
    let _run_target_args'_v866 = v870 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v871 : int64 = null |> unbox<int64>
    let _run_target_args'_v866 = v871 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v874 : (System.DateTime -> int64) = _.Ticks
    let v875 : int64 = v874 v1
    let _run_target_args'_v866 = v875 
    #endif
#if FABLE_COMPILER_PYTHON
    let v876 : (System.DateTime -> int64) = _.Ticks
    let v877 : int64 = v876 v1
    let _run_target_args'_v866 = v877 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v878 : (System.DateTime -> int64) = _.Ticks
    let v879 : int64 = v878 v1
    let _run_target_args'_v866 = v879 
    #endif
#else
    let v880 : (System.DateTime -> int64) = _.Ticks
    let v881 : int64 = v880 v1
    let _run_target_args'_v866 = v881 
    #endif
    let v882 : int64 = _run_target_args'_v866 
    let v899 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v900 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v882) v899 
    let v901 : System.TimeSpan = v900 |> System.TimeSpan 
    let _run_target_args'_v827 = v901 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v904 : US2 = US2_2
    let v905 : US3 = US3_2(v904)
    let v906 : string = $"date_time.get_utc_offset / target: {v905}"
    let v907 : System.TimeSpan = failwith<System.TimeSpan> v906
    let _run_target_args'_v827 = v907 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v910 : US2 = US2_0
    let v911 : US3 = US3_3(v910)
    let v912 : string = $"date_time.get_utc_offset / target: {v911}"
    let v913 : System.TimeSpan = failwith<System.TimeSpan> v912
    let _run_target_args'_v827 = v913 
    #endif
#if FABLE_COMPILER_PYTHON
    let v916 : US2 = US2_0
    let v917 : US3 = US3_4(v916)
    let v918 : string = $"date_time.get_utc_offset / target: {v917}"
    let v919 : System.TimeSpan = failwith<System.TimeSpan> v918
    let _run_target_args'_v827 = v919 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v922 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v923 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v924 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v925 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v924 
    let _run_target_args'_v923 = v925 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v926 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v923 = v926 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v929 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v923 = v929 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v932 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v923 = v932 
    #endif
#if FABLE_COMPILER_PYTHON
    let v935 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v923 = v935 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v938 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v923 = v938 
    #endif
#else
    let v939 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v923 = v939 
    #endif
    let v940 : System.TimeZoneInfo = _run_target_args'_v923 
    let v945 : (System.DateTime -> System.TimeSpan) = v922 v940
    let v946 : System.TimeSpan = v945 v1
    let _run_target_args'_v827 = v946 
    #endif
#else
    let v947 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v948 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v949 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v950 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v949 
    let _run_target_args'_v948 = v950 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v951 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v948 = v951 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v954 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v948 = v954 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v957 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v948 = v957 
    #endif
#if FABLE_COMPILER_PYTHON
    let v960 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v948 = v960 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v963 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v948 = v963 
    #endif
#else
    let v964 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v948 = v964 
    #endif
    let v965 : System.TimeZoneInfo = _run_target_args'_v948 
    let v970 : (System.DateTime -> System.TimeSpan) = v947 v965
    let v971 : System.TimeSpan = v970 v1
    let _run_target_args'_v827 = v971 
    #endif
    let v972 : System.TimeSpan = _run_target_args'_v827 
    let v980 : (System.TimeSpan -> int32) = _.Hours
    let v981 : int32 = v980 v972
    let v984 : bool = v981 > 0
    let v985 : uint8 =
        if v984 then
            1uy
        else
            0uy
    let v986 : string = method4()
    (* run_target_args'
    let v987 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v988 : string = "$0.to_string($1)"
    let v989 : string = Fable.Core.RustInterop.emitRustExpr struct (v972, v986) v988 
    let _run_target_args'_v987 = v989 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v990 : string = "$0.to_string($1)"
    let v991 : string = Fable.Core.RustInterop.emitRustExpr struct (v972, v986) v990 
    let _run_target_args'_v987 = v991 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v992 : string = "$0.to_string($1)"
    let v993 : string = Fable.Core.RustInterop.emitRustExpr struct (v972, v986) v992 
    let _run_target_args'_v987 = v993 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v994 : string = v972.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v987 = v994 
    #endif
#if FABLE_COMPILER_PYTHON
    let v995 : string = v972.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v987 = v995 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v996 : string = v972.ToString v986 
    let _run_target_args'_v987 = v996 
    #endif
#else
    let v999 : string = v972.ToString v986 
    let _run_target_args'_v987 = v999 
    #endif
    let v1002 : string = _run_target_args'_v987 
    let v1007 : string = $"{v985}{v1002}"
    let v1008 : (System.Guid -> string) = _.ToString()
    let v1009 : string = v1008 v0
    let v1012 : int32 = v791.Length
    let v1013 : int32 = v1007.Length
    let v1014 : int32 = v1012 + v1013
    let v1015 : (string -> int32) = String.length
    let v1016 : int32 = v1015 v1009
    let v1019 : int32 = v1014 |> int32 
    let v1026 : int32 = v1016 |> int32 
    let v1033 : int32 = v1026 - 1
    let v1034 : string = v1009.[int v1019..int v1033]
    let v1038 : string = $"{v791}{v1007}{v1034}"
    (* run_target_args'
    let v1039 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1040 : System.Guid = v1038 |> System.Guid 
    let _run_target_args'_v1039 = v1040 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1043 : System.Guid = v1038 |> System.Guid 
    let _run_target_args'_v1039 = v1043 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1046 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1039 = v1046 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1049 : System.Guid = v1038 |> System.Guid 
    let _run_target_args'_v1039 = v1049 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1052 : System.Guid = v1038 |> System.Guid 
    let _run_target_args'_v1039 = v1052 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1055 : System.Guid = v1038 |> System.Guid 
    let _run_target_args'_v1039 = v1055 
    #endif
#else
    let v1058 : System.Guid = v1038 |> System.Guid 
    let _run_target_args'_v1039 = v1058 
    #endif
    let v1061 : System.Guid = _run_target_args'_v1039 
    let _run_target_args'_v2 = v1061 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1066 : string = method3()
    let v1067 : bool = v1066 = ""
    let v1069 : string =
        if v1067 then
            let v1068 : string = "M-d-y hh:mm:ss tt"
            v1068
        else
            v1066
    let v1070 : (string -> string) = v1.ToString
    let v1071 : string = v1070 v1069
    (* run_target_args'
    let v1085 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1086 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1087 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1086 
    let _run_target_args'_v1085 = v1087 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1088 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1085 = v1088 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1091 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1085 = v1091 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1094 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1085 = v1094 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1097 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1085 = v1097 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1100 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1085 = v1100 
    #endif
#else
    let v1101 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1085 = v1101 
    #endif
    let v1102 : System.TimeZoneInfo = _run_target_args'_v1085 
    (* run_target_args'
    let v1107 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1108 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1109 : (System.DateTime -> int64) = _.Ticks
    let v1110 : int64 = v1109 v1
    let _run_target_args'_v1108 = v1110 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1111 : (System.DateTime -> int64) = _.Ticks
    let v1112 : int64 = v1111 v1
    let _run_target_args'_v1108 = v1112 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1113 : int64 = null |> unbox<int64>
    let _run_target_args'_v1108 = v1113 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1116 : (System.DateTime -> int64) = _.Ticks
    let v1117 : int64 = v1116 v1
    let _run_target_args'_v1108 = v1117 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1118 : (System.DateTime -> int64) = _.Ticks
    let v1119 : int64 = v1118 v1
    let _run_target_args'_v1108 = v1119 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1120 : (System.DateTime -> int64) = _.Ticks
    let v1121 : int64 = v1120 v1
    let _run_target_args'_v1108 = v1121 
    #endif
#else
    let v1122 : (System.DateTime -> int64) = _.Ticks
    let v1123 : int64 = v1122 v1
    let _run_target_args'_v1108 = v1123 
    #endif
    let v1124 : int64 = _run_target_args'_v1108 
    let v1141 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1142 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1124) v1141 
    let v1143 : System.TimeSpan = v1142 |> System.TimeSpan 
    let _run_target_args'_v1107 = v1143 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1146 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1147 : (System.DateTime -> int64) = _.Ticks
    let v1148 : int64 = v1147 v1
    let _run_target_args'_v1146 = v1148 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1149 : (System.DateTime -> int64) = _.Ticks
    let v1150 : int64 = v1149 v1
    let _run_target_args'_v1146 = v1150 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1151 : int64 = null |> unbox<int64>
    let _run_target_args'_v1146 = v1151 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1154 : (System.DateTime -> int64) = _.Ticks
    let v1155 : int64 = v1154 v1
    let _run_target_args'_v1146 = v1155 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1156 : (System.DateTime -> int64) = _.Ticks
    let v1157 : int64 = v1156 v1
    let _run_target_args'_v1146 = v1157 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1158 : (System.DateTime -> int64) = _.Ticks
    let v1159 : int64 = v1158 v1
    let _run_target_args'_v1146 = v1159 
    #endif
#else
    let v1160 : (System.DateTime -> int64) = _.Ticks
    let v1161 : int64 = v1160 v1
    let _run_target_args'_v1146 = v1161 
    #endif
    let v1162 : int64 = _run_target_args'_v1146 
    let v1179 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1180 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1162) v1179 
    let v1181 : System.TimeSpan = v1180 |> System.TimeSpan 
    let _run_target_args'_v1107 = v1181 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1184 : US2 = US2_2
    let v1185 : US3 = US3_2(v1184)
    let v1186 : string = $"date_time.get_utc_offset / target: {v1185}"
    let v1187 : System.TimeSpan = failwith<System.TimeSpan> v1186
    let _run_target_args'_v1107 = v1187 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1190 : US2 = US2_0
    let v1191 : US3 = US3_3(v1190)
    let v1192 : string = $"date_time.get_utc_offset / target: {v1191}"
    let v1193 : System.TimeSpan = failwith<System.TimeSpan> v1192
    let _run_target_args'_v1107 = v1193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1196 : US2 = US2_0
    let v1197 : US3 = US3_4(v1196)
    let v1198 : string = $"date_time.get_utc_offset / target: {v1197}"
    let v1199 : System.TimeSpan = failwith<System.TimeSpan> v1198
    let _run_target_args'_v1107 = v1199 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1202 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1203 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1204 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1205 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1204 
    let _run_target_args'_v1203 = v1205 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1206 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1203 = v1206 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1209 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1203 = v1209 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1212 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1203 = v1212 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1215 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1203 = v1215 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1218 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1203 = v1218 
    #endif
#else
    let v1219 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1203 = v1219 
    #endif
    let v1220 : System.TimeZoneInfo = _run_target_args'_v1203 
    let v1225 : (System.DateTime -> System.TimeSpan) = v1202 v1220
    let v1226 : System.TimeSpan = v1225 v1
    let _run_target_args'_v1107 = v1226 
    #endif
#else
    let v1227 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1228 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1229 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1230 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1229 
    let _run_target_args'_v1228 = v1230 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1231 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1228 = v1231 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1234 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1228 = v1234 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1237 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1228 = v1237 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1240 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1228 = v1240 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1243 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1228 = v1243 
    #endif
#else
    let v1244 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1228 = v1244 
    #endif
    let v1245 : System.TimeZoneInfo = _run_target_args'_v1228 
    let v1250 : (System.DateTime -> System.TimeSpan) = v1227 v1245
    let v1251 : System.TimeSpan = v1250 v1
    let _run_target_args'_v1107 = v1251 
    #endif
    let v1252 : System.TimeSpan = _run_target_args'_v1107 
    let v1260 : (System.TimeSpan -> int32) = _.Hours
    let v1261 : int32 = v1260 v1252
    let v1264 : bool = v1261 > 0
    let v1265 : uint8 =
        if v1264 then
            1uy
        else
            0uy
    let v1266 : string = method4()
    (* run_target_args'
    let v1267 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1268 : string = "$0.to_string($1)"
    let v1269 : string = Fable.Core.RustInterop.emitRustExpr struct (v1252, v1266) v1268 
    let _run_target_args'_v1267 = v1269 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1270 : string = "$0.to_string($1)"
    let v1271 : string = Fable.Core.RustInterop.emitRustExpr struct (v1252, v1266) v1270 
    let _run_target_args'_v1267 = v1271 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1272 : string = "$0.to_string($1)"
    let v1273 : string = Fable.Core.RustInterop.emitRustExpr struct (v1252, v1266) v1272 
    let _run_target_args'_v1267 = v1273 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1274 : string = v1252.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1267 = v1274 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1275 : string = v1252.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1267 = v1275 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1276 : string = v1252.ToString v1266 
    let _run_target_args'_v1267 = v1276 
    #endif
#else
    let v1279 : string = v1252.ToString v1266 
    let _run_target_args'_v1267 = v1279 
    #endif
    let v1282 : string = _run_target_args'_v1267 
    let v1287 : string = $"{v1265}{v1282}"
    let v1288 : (System.Guid -> string) = _.ToString()
    let v1289 : string = v1288 v0
    let v1292 : int32 = v1071.Length
    let v1293 : int32 = v1287.Length
    let v1294 : int32 = v1292 + v1293
    let v1295 : (string -> int32) = String.length
    let v1296 : int32 = v1295 v1289
    let v1299 : int32 = v1294 |> int32 
    let v1306 : int32 = v1296 |> int32 
    let v1313 : int32 = v1306 - 1
    let v1314 : string = v1289.[int v1299..int v1313]
    let v1318 : string = $"{v1071}{v1287}{v1314}"
    (* run_target_args'
    let v1319 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1320 : System.Guid = v1318 |> System.Guid 
    let _run_target_args'_v1319 = v1320 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1323 : System.Guid = v1318 |> System.Guid 
    let _run_target_args'_v1319 = v1323 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1326 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1319 = v1326 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1329 : System.Guid = v1318 |> System.Guid 
    let _run_target_args'_v1319 = v1329 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1332 : System.Guid = v1318 |> System.Guid 
    let _run_target_args'_v1319 = v1332 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1335 : System.Guid = v1318 |> System.Guid 
    let _run_target_args'_v1319 = v1335 
    #endif
#else
    let v1338 : System.Guid = v1318 |> System.Guid 
    let _run_target_args'_v1319 = v1338 
    #endif
    let v1341 : System.Guid = _run_target_args'_v1319 
    let _run_target_args'_v2 = v1341 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1346 : string = method3()
    let v1347 : bool = v1346 = ""
    let v1349 : string =
        if v1347 then
            let v1348 : string = "M-d-y hh:mm:ss tt"
            v1348
        else
            v1346
    let v1350 : (string -> string) = v1.ToString
    let v1351 : string = v1350 v1349
    (* run_target_args'
    let v1365 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1366 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1367 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1366 
    let _run_target_args'_v1365 = v1367 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1368 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1365 = v1368 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1371 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1365 = v1371 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1374 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1365 = v1374 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1377 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1365 = v1377 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1380 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1365 = v1380 
    #endif
#else
    let v1381 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1365 = v1381 
    #endif
    let v1382 : System.TimeZoneInfo = _run_target_args'_v1365 
    (* run_target_args'
    let v1387 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1388 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1389 : (System.DateTime -> int64) = _.Ticks
    let v1390 : int64 = v1389 v1
    let _run_target_args'_v1388 = v1390 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1391 : (System.DateTime -> int64) = _.Ticks
    let v1392 : int64 = v1391 v1
    let _run_target_args'_v1388 = v1392 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1393 : int64 = null |> unbox<int64>
    let _run_target_args'_v1388 = v1393 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1396 : (System.DateTime -> int64) = _.Ticks
    let v1397 : int64 = v1396 v1
    let _run_target_args'_v1388 = v1397 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1398 : (System.DateTime -> int64) = _.Ticks
    let v1399 : int64 = v1398 v1
    let _run_target_args'_v1388 = v1399 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1400 : (System.DateTime -> int64) = _.Ticks
    let v1401 : int64 = v1400 v1
    let _run_target_args'_v1388 = v1401 
    #endif
#else
    let v1402 : (System.DateTime -> int64) = _.Ticks
    let v1403 : int64 = v1402 v1
    let _run_target_args'_v1388 = v1403 
    #endif
    let v1404 : int64 = _run_target_args'_v1388 
    let v1421 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1422 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1404) v1421 
    let v1423 : System.TimeSpan = v1422 |> System.TimeSpan 
    let _run_target_args'_v1387 = v1423 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1426 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1427 : (System.DateTime -> int64) = _.Ticks
    let v1428 : int64 = v1427 v1
    let _run_target_args'_v1426 = v1428 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1429 : (System.DateTime -> int64) = _.Ticks
    let v1430 : int64 = v1429 v1
    let _run_target_args'_v1426 = v1430 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1431 : int64 = null |> unbox<int64>
    let _run_target_args'_v1426 = v1431 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1434 : (System.DateTime -> int64) = _.Ticks
    let v1435 : int64 = v1434 v1
    let _run_target_args'_v1426 = v1435 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1436 : (System.DateTime -> int64) = _.Ticks
    let v1437 : int64 = v1436 v1
    let _run_target_args'_v1426 = v1437 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1438 : (System.DateTime -> int64) = _.Ticks
    let v1439 : int64 = v1438 v1
    let _run_target_args'_v1426 = v1439 
    #endif
#else
    let v1440 : (System.DateTime -> int64) = _.Ticks
    let v1441 : int64 = v1440 v1
    let _run_target_args'_v1426 = v1441 
    #endif
    let v1442 : int64 = _run_target_args'_v1426 
    let v1459 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1460 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1442) v1459 
    let v1461 : System.TimeSpan = v1460 |> System.TimeSpan 
    let _run_target_args'_v1387 = v1461 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1464 : US2 = US2_2
    let v1465 : US3 = US3_2(v1464)
    let v1466 : string = $"date_time.get_utc_offset / target: {v1465}"
    let v1467 : System.TimeSpan = failwith<System.TimeSpan> v1466
    let _run_target_args'_v1387 = v1467 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1470 : US2 = US2_0
    let v1471 : US3 = US3_3(v1470)
    let v1472 : string = $"date_time.get_utc_offset / target: {v1471}"
    let v1473 : System.TimeSpan = failwith<System.TimeSpan> v1472
    let _run_target_args'_v1387 = v1473 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1476 : US2 = US2_0
    let v1477 : US3 = US3_4(v1476)
    let v1478 : string = $"date_time.get_utc_offset / target: {v1477}"
    let v1479 : System.TimeSpan = failwith<System.TimeSpan> v1478
    let _run_target_args'_v1387 = v1479 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1482 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1483 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1484 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1485 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1484 
    let _run_target_args'_v1483 = v1485 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1486 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1483 = v1486 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1489 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1483 = v1489 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1492 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1483 = v1492 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1495 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1483 = v1495 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1498 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1483 = v1498 
    #endif
#else
    let v1499 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1483 = v1499 
    #endif
    let v1500 : System.TimeZoneInfo = _run_target_args'_v1483 
    let v1505 : (System.DateTime -> System.TimeSpan) = v1482 v1500
    let v1506 : System.TimeSpan = v1505 v1
    let _run_target_args'_v1387 = v1506 
    #endif
#else
    let v1507 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1508 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1509 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1510 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1509 
    let _run_target_args'_v1508 = v1510 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1511 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1508 = v1511 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1514 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1508 = v1514 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1517 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1508 = v1517 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1520 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1508 = v1520 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1523 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1508 = v1523 
    #endif
#else
    let v1524 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1508 = v1524 
    #endif
    let v1525 : System.TimeZoneInfo = _run_target_args'_v1508 
    let v1530 : (System.DateTime -> System.TimeSpan) = v1507 v1525
    let v1531 : System.TimeSpan = v1530 v1
    let _run_target_args'_v1387 = v1531 
    #endif
    let v1532 : System.TimeSpan = _run_target_args'_v1387 
    let v1540 : (System.TimeSpan -> int32) = _.Hours
    let v1541 : int32 = v1540 v1532
    let v1544 : bool = v1541 > 0
    let v1545 : uint8 =
        if v1544 then
            1uy
        else
            0uy
    let v1546 : string = method4()
    (* run_target_args'
    let v1547 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1548 : string = "$0.to_string($1)"
    let v1549 : string = Fable.Core.RustInterop.emitRustExpr struct (v1532, v1546) v1548 
    let _run_target_args'_v1547 = v1549 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1550 : string = "$0.to_string($1)"
    let v1551 : string = Fable.Core.RustInterop.emitRustExpr struct (v1532, v1546) v1550 
    let _run_target_args'_v1547 = v1551 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1552 : string = "$0.to_string($1)"
    let v1553 : string = Fable.Core.RustInterop.emitRustExpr struct (v1532, v1546) v1552 
    let _run_target_args'_v1547 = v1553 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1554 : string = v1532.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1547 = v1554 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1555 : string = v1532.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1547 = v1555 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1556 : string = v1532.ToString v1546 
    let _run_target_args'_v1547 = v1556 
    #endif
#else
    let v1559 : string = v1532.ToString v1546 
    let _run_target_args'_v1547 = v1559 
    #endif
    let v1562 : string = _run_target_args'_v1547 
    let v1567 : string = $"{v1545}{v1562}"
    let v1568 : (System.Guid -> string) = _.ToString()
    let v1569 : string = v1568 v0
    let v1572 : int32 = v1351.Length
    let v1573 : int32 = v1567.Length
    let v1574 : int32 = v1572 + v1573
    let v1575 : (string -> int32) = String.length
    let v1576 : int32 = v1575 v1569
    let v1579 : int32 = v1574 |> int32 
    let v1586 : int32 = v1576 |> int32 
    let v1593 : int32 = v1586 - 1
    let v1594 : string = v1569.[int v1579..int v1593]
    let v1598 : string = $"{v1351}{v1567}{v1594}"
    (* run_target_args'
    let v1599 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1600 : System.Guid = v1598 |> System.Guid 
    let _run_target_args'_v1599 = v1600 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1603 : System.Guid = v1598 |> System.Guid 
    let _run_target_args'_v1599 = v1603 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1606 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1599 = v1606 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1609 : System.Guid = v1598 |> System.Guid 
    let _run_target_args'_v1599 = v1609 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1612 : System.Guid = v1598 |> System.Guid 
    let _run_target_args'_v1599 = v1612 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1615 : System.Guid = v1598 |> System.Guid 
    let _run_target_args'_v1599 = v1615 
    #endif
#else
    let v1618 : System.Guid = v1598 |> System.Guid 
    let _run_target_args'_v1599 = v1618 
    #endif
    let v1621 : System.Guid = _run_target_args'_v1599 
    let _run_target_args'_v2 = v1621 
    #endif
#else
    let v1626 : string = method3()
    let v1627 : bool = v1626 = ""
    let v1629 : string =
        if v1627 then
            let v1628 : string = "M-d-y hh:mm:ss tt"
            v1628
        else
            v1626
    let v1630 : (string -> string) = v1.ToString
    let v1631 : string = v1630 v1629
    (* run_target_args'
    let v1645 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1646 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1647 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1646 
    let _run_target_args'_v1645 = v1647 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1648 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1645 = v1648 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1651 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1645 = v1651 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1654 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1645 = v1654 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1657 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1645 = v1657 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1660 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1645 = v1660 
    #endif
#else
    let v1661 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1645 = v1661 
    #endif
    let v1662 : System.TimeZoneInfo = _run_target_args'_v1645 
    (* run_target_args'
    let v1667 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1668 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1669 : (System.DateTime -> int64) = _.Ticks
    let v1670 : int64 = v1669 v1
    let _run_target_args'_v1668 = v1670 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1671 : (System.DateTime -> int64) = _.Ticks
    let v1672 : int64 = v1671 v1
    let _run_target_args'_v1668 = v1672 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1673 : int64 = null |> unbox<int64>
    let _run_target_args'_v1668 = v1673 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1676 : (System.DateTime -> int64) = _.Ticks
    let v1677 : int64 = v1676 v1
    let _run_target_args'_v1668 = v1677 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1678 : (System.DateTime -> int64) = _.Ticks
    let v1679 : int64 = v1678 v1
    let _run_target_args'_v1668 = v1679 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1680 : (System.DateTime -> int64) = _.Ticks
    let v1681 : int64 = v1680 v1
    let _run_target_args'_v1668 = v1681 
    #endif
#else
    let v1682 : (System.DateTime -> int64) = _.Ticks
    let v1683 : int64 = v1682 v1
    let _run_target_args'_v1668 = v1683 
    #endif
    let v1684 : int64 = _run_target_args'_v1668 
    let v1701 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1702 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1684) v1701 
    let v1703 : System.TimeSpan = v1702 |> System.TimeSpan 
    let _run_target_args'_v1667 = v1703 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1706 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1707 : (System.DateTime -> int64) = _.Ticks
    let v1708 : int64 = v1707 v1
    let _run_target_args'_v1706 = v1708 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1709 : (System.DateTime -> int64) = _.Ticks
    let v1710 : int64 = v1709 v1
    let _run_target_args'_v1706 = v1710 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1711 : int64 = null |> unbox<int64>
    let _run_target_args'_v1706 = v1711 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1714 : (System.DateTime -> int64) = _.Ticks
    let v1715 : int64 = v1714 v1
    let _run_target_args'_v1706 = v1715 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1716 : (System.DateTime -> int64) = _.Ticks
    let v1717 : int64 = v1716 v1
    let _run_target_args'_v1706 = v1717 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1718 : (System.DateTime -> int64) = _.Ticks
    let v1719 : int64 = v1718 v1
    let _run_target_args'_v1706 = v1719 
    #endif
#else
    let v1720 : (System.DateTime -> int64) = _.Ticks
    let v1721 : int64 = v1720 v1
    let _run_target_args'_v1706 = v1721 
    #endif
    let v1722 : int64 = _run_target_args'_v1706 
    let v1739 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1740 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1722) v1739 
    let v1741 : System.TimeSpan = v1740 |> System.TimeSpan 
    let _run_target_args'_v1667 = v1741 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1744 : US2 = US2_2
    let v1745 : US3 = US3_2(v1744)
    let v1746 : string = $"date_time.get_utc_offset / target: {v1745}"
    let v1747 : System.TimeSpan = failwith<System.TimeSpan> v1746
    let _run_target_args'_v1667 = v1747 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1750 : US2 = US2_0
    let v1751 : US3 = US3_3(v1750)
    let v1752 : string = $"date_time.get_utc_offset / target: {v1751}"
    let v1753 : System.TimeSpan = failwith<System.TimeSpan> v1752
    let _run_target_args'_v1667 = v1753 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1756 : US2 = US2_0
    let v1757 : US3 = US3_4(v1756)
    let v1758 : string = $"date_time.get_utc_offset / target: {v1757}"
    let v1759 : System.TimeSpan = failwith<System.TimeSpan> v1758
    let _run_target_args'_v1667 = v1759 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1762 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1763 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1764 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1765 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1764 
    let _run_target_args'_v1763 = v1765 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1766 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1763 = v1766 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1769 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1763 = v1769 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1772 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1763 = v1772 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1775 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1763 = v1775 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1778 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1763 = v1778 
    #endif
#else
    let v1779 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1763 = v1779 
    #endif
    let v1780 : System.TimeZoneInfo = _run_target_args'_v1763 
    let v1785 : (System.DateTime -> System.TimeSpan) = v1762 v1780
    let v1786 : System.TimeSpan = v1785 v1
    let _run_target_args'_v1667 = v1786 
    #endif
#else
    let v1787 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1788 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1789 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1790 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1789 
    let _run_target_args'_v1788 = v1790 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1791 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1788 = v1791 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1794 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1788 = v1794 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1797 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1788 = v1797 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1800 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1788 = v1800 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1803 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1788 = v1803 
    #endif
#else
    let v1804 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1788 = v1804 
    #endif
    let v1805 : System.TimeZoneInfo = _run_target_args'_v1788 
    let v1810 : (System.DateTime -> System.TimeSpan) = v1787 v1805
    let v1811 : System.TimeSpan = v1810 v1
    let _run_target_args'_v1667 = v1811 
    #endif
    let v1812 : System.TimeSpan = _run_target_args'_v1667 
    let v1820 : (System.TimeSpan -> int32) = _.Hours
    let v1821 : int32 = v1820 v1812
    let v1824 : bool = v1821 > 0
    let v1825 : uint8 =
        if v1824 then
            1uy
        else
            0uy
    let v1826 : string = method4()
    (* run_target_args'
    let v1827 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1828 : string = "$0.to_string($1)"
    let v1829 : string = Fable.Core.RustInterop.emitRustExpr struct (v1812, v1826) v1828 
    let _run_target_args'_v1827 = v1829 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1830 : string = "$0.to_string($1)"
    let v1831 : string = Fable.Core.RustInterop.emitRustExpr struct (v1812, v1826) v1830 
    let _run_target_args'_v1827 = v1831 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1832 : string = "$0.to_string($1)"
    let v1833 : string = Fable.Core.RustInterop.emitRustExpr struct (v1812, v1826) v1832 
    let _run_target_args'_v1827 = v1833 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1834 : string = v1812.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1827 = v1834 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1835 : string = v1812.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1827 = v1835 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1836 : string = v1812.ToString v1826 
    let _run_target_args'_v1827 = v1836 
    #endif
#else
    let v1839 : string = v1812.ToString v1826 
    let _run_target_args'_v1827 = v1839 
    #endif
    let v1842 : string = _run_target_args'_v1827 
    let v1847 : string = $"{v1825}{v1842}"
    let v1848 : (System.Guid -> string) = _.ToString()
    let v1849 : string = v1848 v0
    let v1852 : int32 = v1631.Length
    let v1853 : int32 = v1847.Length
    let v1854 : int32 = v1852 + v1853
    let v1855 : (string -> int32) = String.length
    let v1856 : int32 = v1855 v1849
    let v1859 : int32 = v1854 |> int32 
    let v1866 : int32 = v1856 |> int32 
    let v1873 : int32 = v1866 - 1
    let v1874 : string = v1849.[int v1859..int v1873]
    let v1878 : string = $"{v1631}{v1847}{v1874}"
    (* run_target_args'
    let v1879 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1880 : System.Guid = v1878 |> System.Guid 
    let _run_target_args'_v1879 = v1880 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1883 : System.Guid = v1878 |> System.Guid 
    let _run_target_args'_v1879 = v1883 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1886 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1879 = v1886 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1889 : System.Guid = v1878 |> System.Guid 
    let _run_target_args'_v1879 = v1889 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1892 : System.Guid = v1878 |> System.Guid 
    let _run_target_args'_v1879 = v1892 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1895 : System.Guid = v1878 |> System.Guid 
    let _run_target_args'_v1879 = v1895 
    #endif
#else
    let v1898 : System.Guid = v1878 |> System.Guid 
    let _run_target_args'_v1879 = v1898 
    #endif
    let v1901 : System.Guid = _run_target_args'_v1879 
    let _run_target_args'_v2 = v1901 
    #endif
    let v1906 : System.Guid = _run_target_args'_v2 
    v1906
and closure1 (v0 : System.Guid) (v1 : System.DateTime) : System.Guid =
    method0(v0, v1)
and closure0 () (v0 : System.Guid) : (System.DateTime -> System.Guid) =
    closure1(v0)
and closure4 () (v0 : string) : string =
    let v1 : string = "-"
    let v2 : string = ""
    let v3 : string = v0.Replace (v1, v2)
    v3
and closure3 () (v0 : System.Guid) : System.DateTime =
    let v1 : (System.Guid -> string) = _.ToString()
    let v2 : string = v1 v0
    let v5 : (string -> string) = closure4()
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : System.DateTime = System.DateTime.Parse (v2.[..24] |> v5)
    let _run_target_args'_v6 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : System.DateTime = System.DateTime.Parse (v2.[..24] |> v5)
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : System.DateTime = System.DateTime.Parse (v2.[..24] |> v5)
    let _run_target_args'_v6 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : System.DateTime = System.DateTime.Parse (v2.[..24] |> v5)
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : System.DateTime = System.DateTime.ParseExact (v2.[..24] |> v5, "yyyyMMddHHmmssfffffff", null)
    let _run_target_args'_v6 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v12 : System.DateTime = System.DateTime.ParseExact (v2.[..24] |> v5, "yyyyMMddHHmmssfffffff", null)
    let _run_target_args'_v6 = v12 
    #endif
#else
    let v13 : System.DateTime = System.DateTime.ParseExact (v2.[..24] |> v5, "yyyyMMddHHmmssfffffff", null)
    let _run_target_args'_v6 = v13 
    #endif
    let v14 : System.DateTime = _run_target_args'_v6 
    v14
and closure7 (v0 : int32, v1 : string, v2 : int32) (v3 : string) : string =
    let v4 : bool = v2 >= v0
    if v4 then
        v3
    else
        let v5 : int32 = v2 + 1
        let v6 : (string -> string) = method5(v0, v1, v5)
        let v7 : string = v3 + v1 
        v6 v7
and method5 (v0 : int32, v1 : string, v2 : int32) : (string -> string) =
    closure7(v0, v1, v2)
and closure6 (v0 : System.Guid) (v1 : int64) : System.Guid =
    let v2 : (System.Guid -> string) = _.ToString()
    let v3 : string = v2 v0
    let v6 : (int64 -> string) = _.ToString()
    let v7 : string = v6 v1
    let v10 : (char -> string) = _.ToString()
    let v11 : string = v10 '0'
    let v14 : int32 = v7.Length
    let v15 : int32 = 18 - v14
    let v16 : int32 = 0
    let v17 : (string -> string) = method5(v15, v11, v16)
    let v18 : string = ""
    let v19 : string = v17 v18
    let v20 : string = v19 + v7 
    let v21 : System.Guid = System.Guid $"{v20.[0..7]}-{v20.[8..11]}-{v20.[12..15]}-{v20.[16..17]}{v3.[21..]}"
    v21
and closure5 () (v0 : System.Guid) : (int64 -> System.Guid) =
    closure6(v0)
and closure8 () (v0 : System.Guid) : int64 =
    let v1 : (System.Guid -> string) = _.ToString()
    let v2 : string = v1 v0
    let v5 : int64 = int64 $"{v2.[0..7]}{v2.[9..12]}{v2.[14..17]}{v2.[19..20]}"
    v5
and closure9 () (v0 : System.DateTime) : System.Guid =
    let v1 : (unit -> System.Guid) = System.Guid.NewGuid
    let v2 : System.Guid = v1 ()
    method0(v2, v0)
and closure10 () (v0 : int64) : System.Guid =
    let v1 : (unit -> System.Guid) = System.Guid.NewGuid
    let v2 : System.Guid = v1 ()
    let v5 : (System.Guid -> string) = _.ToString()
    let v6 : string = v5 v2
    let v9 : (int64 -> string) = _.ToString()
    let v10 : string = v9 v0
    let v13 : (char -> string) = _.ToString()
    let v14 : string = v13 '0'
    let v17 : int32 = v10.Length
    let v18 : int32 = 18 - v17
    let v19 : int32 = 0
    let v20 : (string -> string) = method5(v18, v14, v19)
    let v21 : string = ""
    let v22 : string = v20 v21
    let v23 : string = v22 + v10 
    let v24 : System.Guid = System.Guid $"{v23.[0..7]}-{v23.[8..11]}-{v23.[12..15]}-{v23.[16..17]}{v6.[21..]}"
    v24
and closure12 (v0 : string) (v1 : System.DateTime) : string =
    let v2 : bool = v0 = ""
    let v4 : string =
        if v2 then
            let v3 : string = "M-d-y hh:mm:ss tt"
            v3
        else
            v0
    let v5 : (string -> string) = v1.ToString
    v5 v4
and closure11 () (v0 : string) : (System.DateTime -> string) =
    closure12(v0)
and closure13 () (v0 : System.DateTime) : string =
    let v1 : (string -> string) = v0.ToString
    let v2 : string = "yyyy-MM-ddTHH-mm-ss.fff"
    v1 v2
let v0 : (System.Guid -> (System.DateTime -> System.Guid)) = closure0()
let date_time_guid_from_date_time x = v0 x
let v1 : (System.Guid -> System.DateTime) = closure3()
let date_time_from_guid x = v1 x
let v2 : (System.Guid -> (int64 -> System.Guid)) = closure5()
let timestamp_guid_from_timestamp x = v2 x
let v3 : (System.Guid -> int64) = closure8()
let timestamp_from_guid x = v3 x
let v4 : (System.DateTime -> System.Guid) = closure9()
let new_guid_from_date_time x = v4 x
let v5 : (int64 -> System.Guid) = closure10()
let new_guid_from_timestamp x = v5 x
let v6 : (string -> (System.DateTime -> string)) = closure11()
let format x = v6 x
let v7 : (System.DateTime -> string) = closure13()
let format_iso8601 x = v7 x
()
