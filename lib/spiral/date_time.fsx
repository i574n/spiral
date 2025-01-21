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
    let v315 : string = "$0.toString($1)"
    let v316 : string = Fable.Core.RustInterop.emitRustExpr struct (v299, v313) v315 
    let _run_target_args'_v314 = v316 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v317 : string = "$0.toString($1)"
    let v318 : string = Fable.Core.RustInterop.emitRustExpr struct (v299, v313) v317 
    let _run_target_args'_v314 = v318 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v319 : string = "$0.toString($1)"
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
    let v369 : string = v299.ToString v313 
    let _run_target_args'_v314 = v369 
    #endif
    let v415 : string = _run_target_args'_v314 
    let v463 : string = $"{v312}{v415.[0..1]}{v415.[3..4]}"
    let v464 : (System.Guid -> string) = _.ToString()
    let v465 : string = v464 v0
    let v468 : int32 = v131.Length
    let v469 : int32 = v463.Length
    let v470 : int32 = v468 + v469
    let v471 : (string -> int32) = String.length
    let v472 : int32 = v471 v465
    let v475 : int32 = v470 |> int32 
    let v482 : int32 = v472 |> int32 
    let v489 : int32 = v482 - 1
    let v490 : string = v465.[int v475..int v489]
    let v494 : string = $"{v131}{v463}{v490}"
    (* run_target_args'
    let v495 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v496 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v496 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v499 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v499 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v502 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v495 = v502 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v505 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v505 
    #endif
#if FABLE_COMPILER_PYTHON
    let v508 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v508 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v511 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v511 
    #endif
#else
    let v514 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v514 
    #endif
    let v517 : System.Guid = _run_target_args'_v495 
    let _run_target_args'_v2 = v517 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v522 : System.DateTime = System.DateTime.UnixEpoch
    let v525 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v526 : System.DateTime = v525 v522
    let v529 : System.DateTimeKind = System.DateTimeKind.Local
    let v530 : System.DateTime = System.DateTime.SpecifyKind (v1, v529)
    let v533 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v534 : System.DateTime = v533 v530
    (* run_target_args'
    let v537 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v538 : (System.DateTime -> int64) = _.Ticks
    let v539 : int64 = v538 v534
    let _run_target_args'_v537 = v539 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v540 : (System.DateTime -> int64) = _.Ticks
    let v541 : int64 = v540 v534
    let _run_target_args'_v537 = v541 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v542 : int64 = null |> unbox<int64>
    let _run_target_args'_v537 = v542 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v545 : (System.DateTime -> int64) = _.Ticks
    let v546 : int64 = v545 v534
    let _run_target_args'_v537 = v546 
    #endif
#if FABLE_COMPILER_PYTHON
    let v547 : (System.DateTime -> int64) = _.Ticks
    let v548 : int64 = v547 v534
    let _run_target_args'_v537 = v548 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v549 : (System.DateTime -> int64) = _.Ticks
    let v550 : int64 = v549 v534
    let _run_target_args'_v537 = v550 
    #endif
#else
    let v551 : (System.DateTime -> int64) = _.Ticks
    let v552 : int64 = v551 v534
    let _run_target_args'_v537 = v552 
    #endif
    let v553 : int64 = _run_target_args'_v537 
    (* run_target_args'
    let v570 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v571 : (System.DateTime -> int64) = _.Ticks
    let v572 : int64 = v571 v526
    let _run_target_args'_v570 = v572 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v573 : (System.DateTime -> int64) = _.Ticks
    let v574 : int64 = v573 v526
    let _run_target_args'_v570 = v574 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v575 : int64 = null |> unbox<int64>
    let _run_target_args'_v570 = v575 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v578 : (System.DateTime -> int64) = _.Ticks
    let v579 : int64 = v578 v526
    let _run_target_args'_v570 = v579 
    #endif
#if FABLE_COMPILER_PYTHON
    let v580 : (System.DateTime -> int64) = _.Ticks
    let v581 : int64 = v580 v526
    let _run_target_args'_v570 = v581 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v582 : (System.DateTime -> int64) = _.Ticks
    let v583 : int64 = v582 v526
    let _run_target_args'_v570 = v583 
    #endif
#else
    let v584 : (System.DateTime -> int64) = _.Ticks
    let v585 : int64 = v584 v526
    let _run_target_args'_v570 = v585 
    #endif
    let v586 : int64 = _run_target_args'_v570 
    let v603 : int64 = v553 |> int64 
    let v606 : int64 = v586 |> int64 
    let v609 : int64 = v603 - v606
    let v610 : int64 = v609 / 10L
    let v611 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v612 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v610 v611 
    let v613 : (chrono_DateTime<chrono_Utc> -> US0) = method1()
    let v614 : US0 option = v612 |> Option.map v613 
    let v625 : US0 = US0_1
    let v626 : US0 = v614 |> Option.defaultValue v625 
    let v646 : US1 =
        match v626 with
        | US0_1 -> (* None *)
            US1_1
        | US0_0(v630) -> (* Some *)
            let v631 : string = "$0.naive_utc()"
            let v632 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v630 v631 
            let v633 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v634 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v632 v633 
            let v635 : string = "%Y%m%d-%H%M-%S%f"
            let v636 : string = "r#\"" + v635 + "\"#"
            let v637 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v636 
            let v638 : string = "$0.format($1).to_string()"
            let v639 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v634, v637) v638 
            let v640 : string = "fable_library_rust::String_::fromString($0)"
            let v641 : string = Fable.Core.RustInterop.emitRustExpr v639 v640 
            let v642 : string = $"{v641.[0..17]}-{v641.[18..21]}-{v641.[22]}"
            US1_0(v642)
    let v650 : string =
        match v646 with
        | US1_1 -> (* None *)
            let v648 : string = ""
            v648
        | US1_0(v647) -> (* Some *)
            v647
    (* run_target_args'
    let v651 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v652 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v653 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v652 
    let _run_target_args'_v651 = v653 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v654 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v651 = v654 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v657 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v651 = v657 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v660 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v651 = v660 
    #endif
#if FABLE_COMPILER_PYTHON
    let v663 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v651 = v663 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v666 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v651 = v666 
    #endif
#else
    let v667 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v651 = v667 
    #endif
    let v668 : System.TimeZoneInfo = _run_target_args'_v651 
    (* run_target_args'
    let v673 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v674 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v675 : (System.DateTime -> int64) = _.Ticks
    let v676 : int64 = v675 v534
    let _run_target_args'_v674 = v676 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v677 : (System.DateTime -> int64) = _.Ticks
    let v678 : int64 = v677 v534
    let _run_target_args'_v674 = v678 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v679 : int64 = null |> unbox<int64>
    let _run_target_args'_v674 = v679 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v682 : (System.DateTime -> int64) = _.Ticks
    let v683 : int64 = v682 v534
    let _run_target_args'_v674 = v683 
    #endif
#if FABLE_COMPILER_PYTHON
    let v684 : (System.DateTime -> int64) = _.Ticks
    let v685 : int64 = v684 v534
    let _run_target_args'_v674 = v685 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v686 : (System.DateTime -> int64) = _.Ticks
    let v687 : int64 = v686 v534
    let _run_target_args'_v674 = v687 
    #endif
#else
    let v688 : (System.DateTime -> int64) = _.Ticks
    let v689 : int64 = v688 v534
    let _run_target_args'_v674 = v689 
    #endif
    let v690 : int64 = _run_target_args'_v674 
    let v707 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v708 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v534, v690) v707 
    let v709 : System.TimeSpan = v708 |> System.TimeSpan 
    let _run_target_args'_v673 = v709 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v712 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v713 : (System.DateTime -> int64) = _.Ticks
    let v714 : int64 = v713 v534
    let _run_target_args'_v712 = v714 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v715 : (System.DateTime -> int64) = _.Ticks
    let v716 : int64 = v715 v534
    let _run_target_args'_v712 = v716 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v717 : int64 = null |> unbox<int64>
    let _run_target_args'_v712 = v717 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v720 : (System.DateTime -> int64) = _.Ticks
    let v721 : int64 = v720 v534
    let _run_target_args'_v712 = v721 
    #endif
#if FABLE_COMPILER_PYTHON
    let v722 : (System.DateTime -> int64) = _.Ticks
    let v723 : int64 = v722 v534
    let _run_target_args'_v712 = v723 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v724 : (System.DateTime -> int64) = _.Ticks
    let v725 : int64 = v724 v534
    let _run_target_args'_v712 = v725 
    #endif
#else
    let v726 : (System.DateTime -> int64) = _.Ticks
    let v727 : int64 = v726 v534
    let _run_target_args'_v712 = v727 
    #endif
    let v728 : int64 = _run_target_args'_v712 
    let v745 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v746 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v534, v728) v745 
    let v747 : System.TimeSpan = v746 |> System.TimeSpan 
    let _run_target_args'_v673 = v747 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v750 : US2 = US2_2
    let v751 : US3 = US3_2(v750)
    let v752 : string = $"date_time.get_utc_offset / target: {v751}"
    let v753 : System.TimeSpan = failwith<System.TimeSpan> v752
    let _run_target_args'_v673 = v753 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v756 : US2 = US2_0
    let v757 : US3 = US3_3(v756)
    let v758 : string = $"date_time.get_utc_offset / target: {v757}"
    let v759 : System.TimeSpan = failwith<System.TimeSpan> v758
    let _run_target_args'_v673 = v759 
    #endif
#if FABLE_COMPILER_PYTHON
    let v762 : US2 = US2_0
    let v763 : US3 = US3_4(v762)
    let v764 : string = $"date_time.get_utc_offset / target: {v763}"
    let v765 : System.TimeSpan = failwith<System.TimeSpan> v764
    let _run_target_args'_v673 = v765 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v768 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v769 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v770 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v771 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v770 
    let _run_target_args'_v769 = v771 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v772 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v769 = v772 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v775 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v769 = v775 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v778 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v769 = v778 
    #endif
#if FABLE_COMPILER_PYTHON
    let v781 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v769 = v781 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v784 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v769 = v784 
    #endif
#else
    let v785 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v769 = v785 
    #endif
    let v786 : System.TimeZoneInfo = _run_target_args'_v769 
    let v791 : (System.DateTime -> System.TimeSpan) = v768 v786
    let v792 : System.TimeSpan = v791 v534
    let _run_target_args'_v673 = v792 
    #endif
#else
    let v793 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v794 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v795 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v796 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v795 
    let _run_target_args'_v794 = v796 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v797 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v794 = v797 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v800 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v794 = v800 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v803 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v794 = v803 
    #endif
#if FABLE_COMPILER_PYTHON
    let v806 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v794 = v806 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v809 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v794 = v809 
    #endif
#else
    let v810 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v794 = v810 
    #endif
    let v811 : System.TimeZoneInfo = _run_target_args'_v794 
    let v816 : (System.DateTime -> System.TimeSpan) = v793 v811
    let v817 : System.TimeSpan = v816 v534
    let _run_target_args'_v673 = v817 
    #endif
    let v818 : System.TimeSpan = _run_target_args'_v673 
    let v826 : (System.TimeSpan -> int32) = _.Hours
    let v827 : int32 = v826 v818
    let v830 : bool = v827 > 0
    let v831 : uint8 =
        if v830 then
            1uy
        else
            0uy
    let v832 : string = method2()
    (* run_target_args'
    let v833 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v834 : string = "$0.toString($1)"
    let v835 : string = Fable.Core.RustInterop.emitRustExpr struct (v818, v832) v834 
    let _run_target_args'_v833 = v835 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v836 : string = "$0.toString($1)"
    let v837 : string = Fable.Core.RustInterop.emitRustExpr struct (v818, v832) v836 
    let _run_target_args'_v833 = v837 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v838 : string = "$0.toString($1)"
    let v839 : string = Fable.Core.RustInterop.emitRustExpr struct (v818, v832) v838 
    let _run_target_args'_v833 = v839 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v840 : string = v818.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v833 = v840 
    #endif
#if FABLE_COMPILER_PYTHON
    let v841 : string = v818.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v833 = v841 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v842 : string = v818.ToString v832 
    let _run_target_args'_v833 = v842 
    #endif
#else
    let v888 : string = v818.ToString v832 
    let _run_target_args'_v833 = v888 
    #endif
    let v934 : string = _run_target_args'_v833 
    let v982 : string = $"{v831}{v934.[0..1]}{v934.[3..4]}"
    let v983 : (System.Guid -> string) = _.ToString()
    let v984 : string = v983 v0
    let v987 : int32 = v650.Length
    let v988 : int32 = v982.Length
    let v989 : int32 = v987 + v988
    let v990 : (string -> int32) = String.length
    let v991 : int32 = v990 v984
    let v994 : int32 = v989 |> int32 
    let v1001 : int32 = v991 |> int32 
    let v1008 : int32 = v1001 - 1
    let v1009 : string = v984.[int v994..int v1008]
    let v1013 : string = $"{v650}{v982}{v1009}"
    (* run_target_args'
    let v1014 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1015 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1015 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1018 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1018 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1021 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1014 = v1021 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1024 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1024 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1027 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1027 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1030 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1030 
    #endif
#else
    let v1033 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1033 
    #endif
    let v1036 : System.Guid = _run_target_args'_v1014 
    let _run_target_args'_v2 = v1036 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1041 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2 = v1041 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1044 : string = method3()
    let v1045 : bool = v1044 = ""
    let v1047 : string =
        if v1045 then
            let v1046 : string = "M-d-y hh:mm:ss tt"
            v1046
        else
            v1044
    let v1048 : (string -> string) = v1.ToString
    let v1049 : string = v1048 v1047
    (* run_target_args'
    let v1063 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1064 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1065 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1064 
    let _run_target_args'_v1063 = v1065 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1066 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1063 = v1066 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1069 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1063 = v1069 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1072 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1063 = v1072 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1075 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1063 = v1075 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1078 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1063 = v1078 
    #endif
#else
    let v1079 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1063 = v1079 
    #endif
    let v1080 : System.TimeZoneInfo = _run_target_args'_v1063 
    (* run_target_args'
    let v1085 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1086 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1087 : (System.DateTime -> int64) = _.Ticks
    let v1088 : int64 = v1087 v1
    let _run_target_args'_v1086 = v1088 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1089 : (System.DateTime -> int64) = _.Ticks
    let v1090 : int64 = v1089 v1
    let _run_target_args'_v1086 = v1090 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1091 : int64 = null |> unbox<int64>
    let _run_target_args'_v1086 = v1091 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1094 : (System.DateTime -> int64) = _.Ticks
    let v1095 : int64 = v1094 v1
    let _run_target_args'_v1086 = v1095 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1096 : (System.DateTime -> int64) = _.Ticks
    let v1097 : int64 = v1096 v1
    let _run_target_args'_v1086 = v1097 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1098 : (System.DateTime -> int64) = _.Ticks
    let v1099 : int64 = v1098 v1
    let _run_target_args'_v1086 = v1099 
    #endif
#else
    let v1100 : (System.DateTime -> int64) = _.Ticks
    let v1101 : int64 = v1100 v1
    let _run_target_args'_v1086 = v1101 
    #endif
    let v1102 : int64 = _run_target_args'_v1086 
    let v1119 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1120 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1102) v1119 
    let v1121 : System.TimeSpan = v1120 |> System.TimeSpan 
    let _run_target_args'_v1085 = v1121 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1124 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1125 : (System.DateTime -> int64) = _.Ticks
    let v1126 : int64 = v1125 v1
    let _run_target_args'_v1124 = v1126 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1127 : (System.DateTime -> int64) = _.Ticks
    let v1128 : int64 = v1127 v1
    let _run_target_args'_v1124 = v1128 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1129 : int64 = null |> unbox<int64>
    let _run_target_args'_v1124 = v1129 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1132 : (System.DateTime -> int64) = _.Ticks
    let v1133 : int64 = v1132 v1
    let _run_target_args'_v1124 = v1133 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1134 : (System.DateTime -> int64) = _.Ticks
    let v1135 : int64 = v1134 v1
    let _run_target_args'_v1124 = v1135 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1136 : (System.DateTime -> int64) = _.Ticks
    let v1137 : int64 = v1136 v1
    let _run_target_args'_v1124 = v1137 
    #endif
#else
    let v1138 : (System.DateTime -> int64) = _.Ticks
    let v1139 : int64 = v1138 v1
    let _run_target_args'_v1124 = v1139 
    #endif
    let v1140 : int64 = _run_target_args'_v1124 
    let v1157 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1158 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1140) v1157 
    let v1159 : System.TimeSpan = v1158 |> System.TimeSpan 
    let _run_target_args'_v1085 = v1159 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1162 : US2 = US2_2
    let v1163 : US3 = US3_2(v1162)
    let v1164 : string = $"date_time.get_utc_offset / target: {v1163}"
    let v1165 : System.TimeSpan = failwith<System.TimeSpan> v1164
    let _run_target_args'_v1085 = v1165 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1168 : US2 = US2_0
    let v1169 : US3 = US3_3(v1168)
    let v1170 : string = $"date_time.get_utc_offset / target: {v1169}"
    let v1171 : System.TimeSpan = failwith<System.TimeSpan> v1170
    let _run_target_args'_v1085 = v1171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1174 : US2 = US2_0
    let v1175 : US3 = US3_4(v1174)
    let v1176 : string = $"date_time.get_utc_offset / target: {v1175}"
    let v1177 : System.TimeSpan = failwith<System.TimeSpan> v1176
    let _run_target_args'_v1085 = v1177 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1180 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1181 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1182 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1183 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1182 
    let _run_target_args'_v1181 = v1183 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1184 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1181 = v1184 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1187 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1181 = v1187 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1190 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1181 = v1190 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1193 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1181 = v1193 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1196 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1181 = v1196 
    #endif
#else
    let v1197 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1181 = v1197 
    #endif
    let v1198 : System.TimeZoneInfo = _run_target_args'_v1181 
    let v1203 : (System.DateTime -> System.TimeSpan) = v1180 v1198
    let v1204 : System.TimeSpan = v1203 v1
    let _run_target_args'_v1085 = v1204 
    #endif
#else
    let v1205 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1206 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1207 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1208 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1207 
    let _run_target_args'_v1206 = v1208 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1209 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1206 = v1209 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1212 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1206 = v1212 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1215 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1206 = v1215 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1218 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1206 = v1218 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1221 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1206 = v1221 
    #endif
#else
    let v1222 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1206 = v1222 
    #endif
    let v1223 : System.TimeZoneInfo = _run_target_args'_v1206 
    let v1228 : (System.DateTime -> System.TimeSpan) = v1205 v1223
    let v1229 : System.TimeSpan = v1228 v1
    let _run_target_args'_v1085 = v1229 
    #endif
    let v1230 : System.TimeSpan = _run_target_args'_v1085 
    let v1238 : (System.TimeSpan -> int32) = _.Hours
    let v1239 : int32 = v1238 v1230
    let v1242 : bool = v1239 > 0
    let v1243 : uint8 =
        if v1242 then
            1uy
        else
            0uy
    let v1244 : string = method4()
    (* run_target_args'
    let v1245 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1246 : string = "$0.toString($1)"
    let v1247 : string = Fable.Core.RustInterop.emitRustExpr struct (v1230, v1244) v1246 
    let _run_target_args'_v1245 = v1247 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1248 : string = "$0.toString($1)"
    let v1249 : string = Fable.Core.RustInterop.emitRustExpr struct (v1230, v1244) v1248 
    let _run_target_args'_v1245 = v1249 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1250 : string = "$0.toString($1)"
    let v1251 : string = Fable.Core.RustInterop.emitRustExpr struct (v1230, v1244) v1250 
    let _run_target_args'_v1245 = v1251 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1252 : string = v1230.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1245 = v1252 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1253 : string = v1230.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1245 = v1253 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1254 : string = v1230.ToString v1244 
    let _run_target_args'_v1245 = v1254 
    #endif
#else
    let v1300 : string = v1230.ToString v1244 
    let _run_target_args'_v1245 = v1300 
    #endif
    let v1346 : string = _run_target_args'_v1245 
    let v1394 : string = $"{v1243}{v1346}"
    let v1395 : (System.Guid -> string) = _.ToString()
    let v1396 : string = v1395 v0
    let v1399 : int32 = v1049.Length
    let v1400 : int32 = v1394.Length
    let v1401 : int32 = v1399 + v1400
    let v1402 : (string -> int32) = String.length
    let v1403 : int32 = v1402 v1396
    let v1406 : int32 = v1401 |> int32 
    let v1413 : int32 = v1403 |> int32 
    let v1420 : int32 = v1413 - 1
    let v1421 : string = v1396.[int v1406..int v1420]
    let v1425 : string = $"{v1049}{v1394}{v1421}"
    (* run_target_args'
    let v1426 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1427 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1427 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1430 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1430 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1433 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1426 = v1433 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1436 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1436 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1439 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1439 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1442 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1442 
    #endif
#else
    let v1445 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1445 
    #endif
    let v1448 : System.Guid = _run_target_args'_v1426 
    let _run_target_args'_v2 = v1448 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1453 : string = method3()
    let v1454 : bool = v1453 = ""
    let v1456 : string =
        if v1454 then
            let v1455 : string = "M-d-y hh:mm:ss tt"
            v1455
        else
            v1453
    let v1457 : (string -> string) = v1.ToString
    let v1458 : string = v1457 v1456
    (* run_target_args'
    let v1472 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1473 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1474 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1473 
    let _run_target_args'_v1472 = v1474 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1475 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1472 = v1475 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1478 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1472 = v1478 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1481 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1472 = v1481 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1484 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1472 = v1484 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1487 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1472 = v1487 
    #endif
#else
    let v1488 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1472 = v1488 
    #endif
    let v1489 : System.TimeZoneInfo = _run_target_args'_v1472 
    (* run_target_args'
    let v1494 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1495 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1496 : (System.DateTime -> int64) = _.Ticks
    let v1497 : int64 = v1496 v1
    let _run_target_args'_v1495 = v1497 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1498 : (System.DateTime -> int64) = _.Ticks
    let v1499 : int64 = v1498 v1
    let _run_target_args'_v1495 = v1499 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1500 : int64 = null |> unbox<int64>
    let _run_target_args'_v1495 = v1500 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1503 : (System.DateTime -> int64) = _.Ticks
    let v1504 : int64 = v1503 v1
    let _run_target_args'_v1495 = v1504 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1505 : (System.DateTime -> int64) = _.Ticks
    let v1506 : int64 = v1505 v1
    let _run_target_args'_v1495 = v1506 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1507 : (System.DateTime -> int64) = _.Ticks
    let v1508 : int64 = v1507 v1
    let _run_target_args'_v1495 = v1508 
    #endif
#else
    let v1509 : (System.DateTime -> int64) = _.Ticks
    let v1510 : int64 = v1509 v1
    let _run_target_args'_v1495 = v1510 
    #endif
    let v1511 : int64 = _run_target_args'_v1495 
    let v1528 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1529 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1511) v1528 
    let v1530 : System.TimeSpan = v1529 |> System.TimeSpan 
    let _run_target_args'_v1494 = v1530 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1533 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1534 : (System.DateTime -> int64) = _.Ticks
    let v1535 : int64 = v1534 v1
    let _run_target_args'_v1533 = v1535 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1536 : (System.DateTime -> int64) = _.Ticks
    let v1537 : int64 = v1536 v1
    let _run_target_args'_v1533 = v1537 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1538 : int64 = null |> unbox<int64>
    let _run_target_args'_v1533 = v1538 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1541 : (System.DateTime -> int64) = _.Ticks
    let v1542 : int64 = v1541 v1
    let _run_target_args'_v1533 = v1542 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1543 : (System.DateTime -> int64) = _.Ticks
    let v1544 : int64 = v1543 v1
    let _run_target_args'_v1533 = v1544 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1545 : (System.DateTime -> int64) = _.Ticks
    let v1546 : int64 = v1545 v1
    let _run_target_args'_v1533 = v1546 
    #endif
#else
    let v1547 : (System.DateTime -> int64) = _.Ticks
    let v1548 : int64 = v1547 v1
    let _run_target_args'_v1533 = v1548 
    #endif
    let v1549 : int64 = _run_target_args'_v1533 
    let v1566 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1567 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1549) v1566 
    let v1568 : System.TimeSpan = v1567 |> System.TimeSpan 
    let _run_target_args'_v1494 = v1568 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1571 : US2 = US2_2
    let v1572 : US3 = US3_2(v1571)
    let v1573 : string = $"date_time.get_utc_offset / target: {v1572}"
    let v1574 : System.TimeSpan = failwith<System.TimeSpan> v1573
    let _run_target_args'_v1494 = v1574 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1577 : US2 = US2_0
    let v1578 : US3 = US3_3(v1577)
    let v1579 : string = $"date_time.get_utc_offset / target: {v1578}"
    let v1580 : System.TimeSpan = failwith<System.TimeSpan> v1579
    let _run_target_args'_v1494 = v1580 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1583 : US2 = US2_0
    let v1584 : US3 = US3_4(v1583)
    let v1585 : string = $"date_time.get_utc_offset / target: {v1584}"
    let v1586 : System.TimeSpan = failwith<System.TimeSpan> v1585
    let _run_target_args'_v1494 = v1586 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1589 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1590 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1591 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1592 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1591 
    let _run_target_args'_v1590 = v1592 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1593 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1590 = v1593 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1596 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1590 = v1596 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1599 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1590 = v1599 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1602 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1590 = v1602 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1605 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1590 = v1605 
    #endif
#else
    let v1606 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1590 = v1606 
    #endif
    let v1607 : System.TimeZoneInfo = _run_target_args'_v1590 
    let v1612 : (System.DateTime -> System.TimeSpan) = v1589 v1607
    let v1613 : System.TimeSpan = v1612 v1
    let _run_target_args'_v1494 = v1613 
    #endif
#else
    let v1614 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1615 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1616 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1617 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1616 
    let _run_target_args'_v1615 = v1617 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1618 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1618 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1621 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1621 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1624 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1624 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1627 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1627 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1630 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1615 = v1630 
    #endif
#else
    let v1631 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1615 = v1631 
    #endif
    let v1632 : System.TimeZoneInfo = _run_target_args'_v1615 
    let v1637 : (System.DateTime -> System.TimeSpan) = v1614 v1632
    let v1638 : System.TimeSpan = v1637 v1
    let _run_target_args'_v1494 = v1638 
    #endif
    let v1639 : System.TimeSpan = _run_target_args'_v1494 
    let v1647 : (System.TimeSpan -> int32) = _.Hours
    let v1648 : int32 = v1647 v1639
    let v1651 : bool = v1648 > 0
    let v1652 : uint8 =
        if v1651 then
            1uy
        else
            0uy
    let v1653 : string = method4()
    (* run_target_args'
    let v1654 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1655 : string = "$0.toString($1)"
    let v1656 : string = Fable.Core.RustInterop.emitRustExpr struct (v1639, v1653) v1655 
    let _run_target_args'_v1654 = v1656 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1657 : string = "$0.toString($1)"
    let v1658 : string = Fable.Core.RustInterop.emitRustExpr struct (v1639, v1653) v1657 
    let _run_target_args'_v1654 = v1658 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1659 : string = "$0.toString($1)"
    let v1660 : string = Fable.Core.RustInterop.emitRustExpr struct (v1639, v1653) v1659 
    let _run_target_args'_v1654 = v1660 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1661 : string = v1639.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1654 = v1661 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1662 : string = v1639.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1654 = v1662 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1663 : string = v1639.ToString v1653 
    let _run_target_args'_v1654 = v1663 
    #endif
#else
    let v1709 : string = v1639.ToString v1653 
    let _run_target_args'_v1654 = v1709 
    #endif
    let v1755 : string = _run_target_args'_v1654 
    let v1803 : string = $"{v1652}{v1755}"
    let v1804 : (System.Guid -> string) = _.ToString()
    let v1805 : string = v1804 v0
    let v1808 : int32 = v1458.Length
    let v1809 : int32 = v1803.Length
    let v1810 : int32 = v1808 + v1809
    let v1811 : (string -> int32) = String.length
    let v1812 : int32 = v1811 v1805
    let v1815 : int32 = v1810 |> int32 
    let v1822 : int32 = v1812 |> int32 
    let v1829 : int32 = v1822 - 1
    let v1830 : string = v1805.[int v1815..int v1829]
    let v1834 : string = $"{v1458}{v1803}{v1830}"
    (* run_target_args'
    let v1835 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1836 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1836 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1839 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1839 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1842 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1835 = v1842 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1845 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1845 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1848 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1848 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1851 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1851 
    #endif
#else
    let v1854 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1854 
    #endif
    let v1857 : System.Guid = _run_target_args'_v1835 
    let _run_target_args'_v2 = v1857 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1862 : string = method3()
    let v1863 : bool = v1862 = ""
    let v1865 : string =
        if v1863 then
            let v1864 : string = "M-d-y hh:mm:ss tt"
            v1864
        else
            v1862
    let v1866 : (string -> string) = v1.ToString
    let v1867 : string = v1866 v1865
    (* run_target_args'
    let v1881 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1882 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1883 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1882 
    let _run_target_args'_v1881 = v1883 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1884 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1884 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1887 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1887 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1890 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1890 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1893 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1893 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1896 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1881 = v1896 
    #endif
#else
    let v1897 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1881 = v1897 
    #endif
    let v1898 : System.TimeZoneInfo = _run_target_args'_v1881 
    (* run_target_args'
    let v1903 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1904 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1905 : (System.DateTime -> int64) = _.Ticks
    let v1906 : int64 = v1905 v1
    let _run_target_args'_v1904 = v1906 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1907 : (System.DateTime -> int64) = _.Ticks
    let v1908 : int64 = v1907 v1
    let _run_target_args'_v1904 = v1908 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1909 : int64 = null |> unbox<int64>
    let _run_target_args'_v1904 = v1909 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1912 : (System.DateTime -> int64) = _.Ticks
    let v1913 : int64 = v1912 v1
    let _run_target_args'_v1904 = v1913 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1914 : (System.DateTime -> int64) = _.Ticks
    let v1915 : int64 = v1914 v1
    let _run_target_args'_v1904 = v1915 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1916 : (System.DateTime -> int64) = _.Ticks
    let v1917 : int64 = v1916 v1
    let _run_target_args'_v1904 = v1917 
    #endif
#else
    let v1918 : (System.DateTime -> int64) = _.Ticks
    let v1919 : int64 = v1918 v1
    let _run_target_args'_v1904 = v1919 
    #endif
    let v1920 : int64 = _run_target_args'_v1904 
    let v1937 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1938 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1920) v1937 
    let v1939 : System.TimeSpan = v1938 |> System.TimeSpan 
    let _run_target_args'_v1903 = v1939 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1942 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1943 : (System.DateTime -> int64) = _.Ticks
    let v1944 : int64 = v1943 v1
    let _run_target_args'_v1942 = v1944 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1945 : (System.DateTime -> int64) = _.Ticks
    let v1946 : int64 = v1945 v1
    let _run_target_args'_v1942 = v1946 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1947 : int64 = null |> unbox<int64>
    let _run_target_args'_v1942 = v1947 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1950 : (System.DateTime -> int64) = _.Ticks
    let v1951 : int64 = v1950 v1
    let _run_target_args'_v1942 = v1951 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1952 : (System.DateTime -> int64) = _.Ticks
    let v1953 : int64 = v1952 v1
    let _run_target_args'_v1942 = v1953 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1954 : (System.DateTime -> int64) = _.Ticks
    let v1955 : int64 = v1954 v1
    let _run_target_args'_v1942 = v1955 
    #endif
#else
    let v1956 : (System.DateTime -> int64) = _.Ticks
    let v1957 : int64 = v1956 v1
    let _run_target_args'_v1942 = v1957 
    #endif
    let v1958 : int64 = _run_target_args'_v1942 
    let v1975 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1976 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1958) v1975 
    let v1977 : System.TimeSpan = v1976 |> System.TimeSpan 
    let _run_target_args'_v1903 = v1977 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1980 : US2 = US2_2
    let v1981 : US3 = US3_2(v1980)
    let v1982 : string = $"date_time.get_utc_offset / target: {v1981}"
    let v1983 : System.TimeSpan = failwith<System.TimeSpan> v1982
    let _run_target_args'_v1903 = v1983 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1986 : US2 = US2_0
    let v1987 : US3 = US3_3(v1986)
    let v1988 : string = $"date_time.get_utc_offset / target: {v1987}"
    let v1989 : System.TimeSpan = failwith<System.TimeSpan> v1988
    let _run_target_args'_v1903 = v1989 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1992 : US2 = US2_0
    let v1993 : US3 = US3_4(v1992)
    let v1994 : string = $"date_time.get_utc_offset / target: {v1993}"
    let v1995 : System.TimeSpan = failwith<System.TimeSpan> v1994
    let _run_target_args'_v1903 = v1995 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1998 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1999 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2000 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2001 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2000 
    let _run_target_args'_v1999 = v2001 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2002 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2002 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2005 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2005 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2008 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2008 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2011 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2011 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2014 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1999 = v2014 
    #endif
#else
    let v2015 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1999 = v2015 
    #endif
    let v2016 : System.TimeZoneInfo = _run_target_args'_v1999 
    let v2021 : (System.DateTime -> System.TimeSpan) = v1998 v2016
    let v2022 : System.TimeSpan = v2021 v1
    let _run_target_args'_v1903 = v2022 
    #endif
#else
    let v2023 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2024 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2025 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2026 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2025 
    let _run_target_args'_v2024 = v2026 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2027 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2024 = v2027 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2030 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2024 = v2030 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2033 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2024 = v2033 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2036 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2024 = v2036 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2039 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2024 = v2039 
    #endif
#else
    let v2040 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2024 = v2040 
    #endif
    let v2041 : System.TimeZoneInfo = _run_target_args'_v2024 
    let v2046 : (System.DateTime -> System.TimeSpan) = v2023 v2041
    let v2047 : System.TimeSpan = v2046 v1
    let _run_target_args'_v1903 = v2047 
    #endif
    let v2048 : System.TimeSpan = _run_target_args'_v1903 
    let v2056 : (System.TimeSpan -> int32) = _.Hours
    let v2057 : int32 = v2056 v2048
    let v2060 : bool = v2057 > 0
    let v2061 : uint8 =
        if v2060 then
            1uy
        else
            0uy
    let v2062 : string = method4()
    (* run_target_args'
    let v2063 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2064 : string = "$0.toString($1)"
    let v2065 : string = Fable.Core.RustInterop.emitRustExpr struct (v2048, v2062) v2064 
    let _run_target_args'_v2063 = v2065 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2066 : string = "$0.toString($1)"
    let v2067 : string = Fable.Core.RustInterop.emitRustExpr struct (v2048, v2062) v2066 
    let _run_target_args'_v2063 = v2067 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2068 : string = "$0.toString($1)"
    let v2069 : string = Fable.Core.RustInterop.emitRustExpr struct (v2048, v2062) v2068 
    let _run_target_args'_v2063 = v2069 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2070 : string = v2048.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2063 = v2070 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2071 : string = v2048.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2063 = v2071 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2072 : string = v2048.ToString v2062 
    let _run_target_args'_v2063 = v2072 
    #endif
#else
    let v2118 : string = v2048.ToString v2062 
    let _run_target_args'_v2063 = v2118 
    #endif
    let v2164 : string = _run_target_args'_v2063 
    let v2212 : string = $"{v2061}{v2164}"
    let v2213 : (System.Guid -> string) = _.ToString()
    let v2214 : string = v2213 v0
    let v2217 : int32 = v1867.Length
    let v2218 : int32 = v2212.Length
    let v2219 : int32 = v2217 + v2218
    let v2220 : (string -> int32) = String.length
    let v2221 : int32 = v2220 v2214
    let v2224 : int32 = v2219 |> int32 
    let v2231 : int32 = v2221 |> int32 
    let v2238 : int32 = v2231 - 1
    let v2239 : string = v2214.[int v2224..int v2238]
    let v2243 : string = $"{v1867}{v2212}{v2239}"
    (* run_target_args'
    let v2244 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2245 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2245 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2248 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2248 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2251 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2244 = v2251 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2254 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2254 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2257 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2257 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2260 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2260 
    #endif
#else
    let v2263 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2263 
    #endif
    let v2266 : System.Guid = _run_target_args'_v2244 
    let _run_target_args'_v2 = v2266 
    #endif
#else
    let v2271 : string = method3()
    let v2272 : bool = v2271 = ""
    let v2274 : string =
        if v2272 then
            let v2273 : string = "M-d-y hh:mm:ss tt"
            v2273
        else
            v2271
    let v2275 : (string -> string) = v1.ToString
    let v2276 : string = v2275 v2274
    (* run_target_args'
    let v2290 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2291 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2292 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2291 
    let _run_target_args'_v2290 = v2292 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2293 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2290 = v2293 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2296 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2290 = v2296 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2299 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2290 = v2299 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2302 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2290 = v2302 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2305 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2290 = v2305 
    #endif
#else
    let v2306 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2290 = v2306 
    #endif
    let v2307 : System.TimeZoneInfo = _run_target_args'_v2290 
    (* run_target_args'
    let v2312 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2313 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2314 : (System.DateTime -> int64) = _.Ticks
    let v2315 : int64 = v2314 v1
    let _run_target_args'_v2313 = v2315 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2316 : (System.DateTime -> int64) = _.Ticks
    let v2317 : int64 = v2316 v1
    let _run_target_args'_v2313 = v2317 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2318 : int64 = null |> unbox<int64>
    let _run_target_args'_v2313 = v2318 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2321 : (System.DateTime -> int64) = _.Ticks
    let v2322 : int64 = v2321 v1
    let _run_target_args'_v2313 = v2322 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2323 : (System.DateTime -> int64) = _.Ticks
    let v2324 : int64 = v2323 v1
    let _run_target_args'_v2313 = v2324 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2325 : (System.DateTime -> int64) = _.Ticks
    let v2326 : int64 = v2325 v1
    let _run_target_args'_v2313 = v2326 
    #endif
#else
    let v2327 : (System.DateTime -> int64) = _.Ticks
    let v2328 : int64 = v2327 v1
    let _run_target_args'_v2313 = v2328 
    #endif
    let v2329 : int64 = _run_target_args'_v2313 
    let v2346 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2347 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2329) v2346 
    let v2348 : System.TimeSpan = v2347 |> System.TimeSpan 
    let _run_target_args'_v2312 = v2348 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2351 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2352 : (System.DateTime -> int64) = _.Ticks
    let v2353 : int64 = v2352 v1
    let _run_target_args'_v2351 = v2353 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2354 : (System.DateTime -> int64) = _.Ticks
    let v2355 : int64 = v2354 v1
    let _run_target_args'_v2351 = v2355 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2356 : int64 = null |> unbox<int64>
    let _run_target_args'_v2351 = v2356 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2359 : (System.DateTime -> int64) = _.Ticks
    let v2360 : int64 = v2359 v1
    let _run_target_args'_v2351 = v2360 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2361 : (System.DateTime -> int64) = _.Ticks
    let v2362 : int64 = v2361 v1
    let _run_target_args'_v2351 = v2362 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2363 : (System.DateTime -> int64) = _.Ticks
    let v2364 : int64 = v2363 v1
    let _run_target_args'_v2351 = v2364 
    #endif
#else
    let v2365 : (System.DateTime -> int64) = _.Ticks
    let v2366 : int64 = v2365 v1
    let _run_target_args'_v2351 = v2366 
    #endif
    let v2367 : int64 = _run_target_args'_v2351 
    let v2384 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2385 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2367) v2384 
    let v2386 : System.TimeSpan = v2385 |> System.TimeSpan 
    let _run_target_args'_v2312 = v2386 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2389 : US2 = US2_2
    let v2390 : US3 = US3_2(v2389)
    let v2391 : string = $"date_time.get_utc_offset / target: {v2390}"
    let v2392 : System.TimeSpan = failwith<System.TimeSpan> v2391
    let _run_target_args'_v2312 = v2392 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2395 : US2 = US2_0
    let v2396 : US3 = US3_3(v2395)
    let v2397 : string = $"date_time.get_utc_offset / target: {v2396}"
    let v2398 : System.TimeSpan = failwith<System.TimeSpan> v2397
    let _run_target_args'_v2312 = v2398 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2401 : US2 = US2_0
    let v2402 : US3 = US3_4(v2401)
    let v2403 : string = $"date_time.get_utc_offset / target: {v2402}"
    let v2404 : System.TimeSpan = failwith<System.TimeSpan> v2403
    let _run_target_args'_v2312 = v2404 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2407 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2408 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2409 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2410 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2409 
    let _run_target_args'_v2408 = v2410 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2411 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2408 = v2411 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2414 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2408 = v2414 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2417 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2408 = v2417 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2420 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2408 = v2420 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2423 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2408 = v2423 
    #endif
#else
    let v2424 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2408 = v2424 
    #endif
    let v2425 : System.TimeZoneInfo = _run_target_args'_v2408 
    let v2430 : (System.DateTime -> System.TimeSpan) = v2407 v2425
    let v2431 : System.TimeSpan = v2430 v1
    let _run_target_args'_v2312 = v2431 
    #endif
#else
    let v2432 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2433 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2434 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2435 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2434 
    let _run_target_args'_v2433 = v2435 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2436 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2433 = v2436 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2439 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2433 = v2439 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2442 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2433 = v2442 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2445 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2433 = v2445 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2448 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2433 = v2448 
    #endif
#else
    let v2449 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2433 = v2449 
    #endif
    let v2450 : System.TimeZoneInfo = _run_target_args'_v2433 
    let v2455 : (System.DateTime -> System.TimeSpan) = v2432 v2450
    let v2456 : System.TimeSpan = v2455 v1
    let _run_target_args'_v2312 = v2456 
    #endif
    let v2457 : System.TimeSpan = _run_target_args'_v2312 
    let v2465 : (System.TimeSpan -> int32) = _.Hours
    let v2466 : int32 = v2465 v2457
    let v2469 : bool = v2466 > 0
    let v2470 : uint8 =
        if v2469 then
            1uy
        else
            0uy
    let v2471 : string = method4()
    (* run_target_args'
    let v2472 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2473 : string = "$0.toString($1)"
    let v2474 : string = Fable.Core.RustInterop.emitRustExpr struct (v2457, v2471) v2473 
    let _run_target_args'_v2472 = v2474 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2475 : string = "$0.toString($1)"
    let v2476 : string = Fable.Core.RustInterop.emitRustExpr struct (v2457, v2471) v2475 
    let _run_target_args'_v2472 = v2476 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2477 : string = "$0.toString($1)"
    let v2478 : string = Fable.Core.RustInterop.emitRustExpr struct (v2457, v2471) v2477 
    let _run_target_args'_v2472 = v2478 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2479 : string = v2457.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2472 = v2479 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2480 : string = v2457.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2472 = v2480 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2481 : string = v2457.ToString v2471 
    let _run_target_args'_v2472 = v2481 
    #endif
#else
    let v2527 : string = v2457.ToString v2471 
    let _run_target_args'_v2472 = v2527 
    #endif
    let v2573 : string = _run_target_args'_v2472 
    let v2621 : string = $"{v2470}{v2573}"
    let v2622 : (System.Guid -> string) = _.ToString()
    let v2623 : string = v2622 v0
    let v2626 : int32 = v2276.Length
    let v2627 : int32 = v2621.Length
    let v2628 : int32 = v2626 + v2627
    let v2629 : (string -> int32) = String.length
    let v2630 : int32 = v2629 v2623
    let v2633 : int32 = v2628 |> int32 
    let v2640 : int32 = v2630 |> int32 
    let v2647 : int32 = v2640 - 1
    let v2648 : string = v2623.[int v2633..int v2647]
    let v2652 : string = $"{v2276}{v2621}{v2648}"
    (* run_target_args'
    let v2653 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2654 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2654 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2657 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2657 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2660 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2653 = v2660 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2663 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2663 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2666 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2666 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2669 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2669 
    #endif
#else
    let v2672 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2672 
    #endif
    let v2675 : System.Guid = _run_target_args'_v2653 
    let _run_target_args'_v2 = v2675 
    #endif
    let v2680 : System.Guid = _run_target_args'_v2 
    v2680
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
