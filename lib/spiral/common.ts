import { Lazy, compare, int64ToString, IComparable, IEquatable, IDisposable, createAtom } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Util.js";
import { some, value as value_1, map, defaultArg, Option } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Option.js";
import { op_Addition, op_Subtraction, fromInt64, toInt64, int64 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/BigInt.js";
import { option_type, bool_type, lambda_type, unit_type, string_type, record_type, int64_type, union_type, class_type, TypeInfo } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Reflection.js";
import { FSharpRef, Record, Union } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Types.js";
import { int32 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Int32.js";
import { toString, create, now, getTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Date.js";
import { milliseconds, seconds, minutes, hours, fromTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/TimeSpan.js";
import { trimStart, trimEnd, interpolate, toText } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/String.js";
import { ofSeq, find } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Map.js";

export interface IOsEnviron {
    environ(): any
}

export let TraceState_trace_state = createAtom<Option<[Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>]>>(undefined);

export class Disposable implements IDisposable {
    readonly f: (() => void);
    constructor(f: (() => void)) {
        this.f = f;
    }
    Dispose(): void {
        const _: Disposable = this;
        _.f();
    }
}

export function Disposable_$reflection(): TypeInfo {
    return class_type("Common.Disposable", undefined, Disposable);
}

export function Disposable_$ctor_3A5B6456(f: (() => void)): Disposable {
    return new Disposable(f);
}

export type US0_$union = 
    | US0<0>
    | US0<1>
    | US0<2>
    | US0<3>
    | US0<4>

export type US0_$cases = {
    0: ["US0_0", []],
    1: ["US0_1", []],
    2: ["US0_2", []],
    3: ["US0_3", []],
    4: ["US0_4", []]
}

export function US0_US0_0() {
    return new US0<0>(0, []);
}

export function US0_US0_1() {
    return new US0<1>(1, []);
}

export function US0_US0_2() {
    return new US0<2>(2, []);
}

export function US0_US0_3() {
    return new US0<3>(3, []);
}

export function US0_US0_4() {
    return new US0<4>(4, []);
}

export class US0<Tag extends keyof US0_$cases> extends Union<Tag, US0_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US0_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US0_0", "US0_1", "US0_2", "US0_3", "US0_4"];
    }
}

export function US0_$reflection(): TypeInfo {
    return union_type("Common.US0", [], US0, () => [[], [], [], [], []]);
}

export class Mut0 extends Record implements IEquatable<Mut0>, IComparable<Mut0> {
    l0: int64;
    constructor(l0: int64) {
        super();
        this.l0 = l0;
    }
}

export function Mut0_$reflection(): TypeInfo {
    return record_type("Common.Mut0", [], Mut0, () => [["l0", int64_type]]);
}

export class Mut1 extends Record {
    l0: ((arg0: string) => void);
    constructor(l0: ((arg0: string) => void)) {
        super();
        this.l0 = l0;
    }
}

export function Mut1_$reflection(): TypeInfo {
    return record_type("Common.Mut1", [], Mut1, () => [["l0", lambda_type(string_type, unit_type)]]);
}

export class Mut2 extends Record implements IEquatable<Mut2>, IComparable<Mut2> {
    l0: boolean;
    constructor(l0: boolean) {
        super();
        this.l0 = l0;
    }
}

export function Mut2_$reflection(): TypeInfo {
    return record_type("Common.Mut2", [], Mut2, () => [["l0", bool_type]]);
}

export class Mut3 extends Record implements IEquatable<Mut3>, IComparable<Mut3> {
    l0: string;
    constructor(l0: string) {
        super();
        this.l0 = l0;
    }
}

export function Mut3_$reflection(): TypeInfo {
    return record_type("Common.Mut3", [], Mut3, () => [["l0", string_type]]);
}

export class Mut4 extends Record implements IEquatable<Mut4>, IComparable<Mut4> {
    l0: US0_$union;
    constructor(l0: US0_$union) {
        super();
        this.l0 = l0;
    }
}

export function Mut4_$reflection(): TypeInfo {
    return record_type("Common.Mut4", [], Mut4, () => [["l0", US0_$reflection()]]);
}

export type US1_$union = 
    | US1<0>
    | US1<1>

export type US1_$cases = {
    0: ["US1_0", [US0_$union]],
    1: ["US1_1", []]
}

export function US1_US1_0(f0_0: US0_$union) {
    return new US1<0>(0, [f0_0]);
}

export function US1_US1_1() {
    return new US1<1>(1, []);
}

export class US1<Tag extends keyof US1_$cases> extends Union<Tag, US1_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US1_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US1_0", "US1_1"];
    }
}

export function US1_$reflection(): TypeInfo {
    return union_type("Common.US1", [], US1, () => [[["f0_0", US0_$reflection()]], []]);
}

export type US2_$union = 
    | US2<0>
    | US2<1>

export type US2_$cases = {
    0: ["US2_0", [int64]],
    1: ["US2_1", []]
}

export function US2_US2_0(f0_0: int64) {
    return new US2<0>(0, [f0_0]);
}

export function US2_US2_1() {
    return new US2<1>(1, []);
}

export class US2<Tag extends keyof US2_$cases> extends Union<Tag, US2_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US2_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US2_0", "US2_1"];
    }
}

export function US2_$reflection(): TypeInfo {
    return union_type("Common.US2", [], US2, () => [[["f0_0", int64_type]], []]);
}

export type US3_$union = 
    | US3<0>
    | US3<1>
    | US3<2>

export type US3_$cases = {
    0: ["US3_0", []],
    1: ["US3_1", []],
    2: ["US3_2", []]
}

export function US3_US3_0() {
    return new US3<0>(0, []);
}

export function US3_US3_1() {
    return new US3<1>(1, []);
}

export function US3_US3_2() {
    return new US3<2>(2, []);
}

export class US3<Tag extends keyof US3_$cases> extends Union<Tag, US3_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US3_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US3_0", "US3_1", "US3_2"];
    }
}

export function US3_$reflection(): TypeInfo {
    return union_type("Common.US3", [], US3, () => [[], [], []]);
}

export type US4_$union = 
    | US4<0>
    | US4<1>
    | US4<2>
    | US4<3>
    | US4<4>
    | US4<5>
    | US4<6>

export type US4_$cases = {
    0: ["US4_0", [US3_$union]],
    1: ["US4_1", [US3_$union]],
    2: ["US4_2", [US3_$union]],
    3: ["US4_3", [US3_$union]],
    4: ["US4_4", [US3_$union]],
    5: ["US4_5", [US3_$union]],
    6: ["US4_6", [US3_$union]]
}

export function US4_US4_0(f0_0: US3_$union) {
    return new US4<0>(0, [f0_0]);
}

export function US4_US4_1(f1_0: US3_$union) {
    return new US4<1>(1, [f1_0]);
}

export function US4_US4_2(f2_0: US3_$union) {
    return new US4<2>(2, [f2_0]);
}

export function US4_US4_3(f3_0: US3_$union) {
    return new US4<3>(3, [f3_0]);
}

export function US4_US4_4(f4_0: US3_$union) {
    return new US4<4>(4, [f4_0]);
}

export function US4_US4_5(f5_0: US3_$union) {
    return new US4<5>(5, [f5_0]);
}

export function US4_US4_6(f6_0: US3_$union) {
    return new US4<6>(6, [f6_0]);
}

export class US4<Tag extends keyof US4_$cases> extends Union<Tag, US4_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US4_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5", "US4_6"];
    }
}

export function US4_$reflection(): TypeInfo {
    return union_type("Common.US4", [], US4, () => [[["f0_0", US3_$reflection()]], [["f1_0", US3_$reflection()]], [["f2_0", US3_$reflection()]], [["f3_0", US3_$reflection()]], [["f4_0", US3_$reflection()]], [["f5_0", US3_$reflection()]], [["f6_0", US3_$reflection()]]]);
}

export type US5_$union = 
    | US5<0>
    | US5<1>

export type US5_$cases = {
    0: ["US5_0", [string]],
    1: ["US5_1", []]
}

export function US5_US5_0(f0_0: string) {
    return new US5<0>(0, [f0_0]);
}

export function US5_US5_1() {
    return new US5<1>(1, []);
}

export class US5<Tag extends keyof US5_$cases> extends Union<Tag, US5_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US5_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US5_0", "US5_1"];
    }
}

export function US5_$reflection(): TypeInfo {
    return union_type("Common.US5", [], US5, () => [[["f0_0", string_type]], []]);
}

export type US6_$union = 
    | US6<0>
    | US6<1>

export type US6_$cases = {
    0: ["US6_0", []],
    1: ["US6_1", []]
}

export function US6_US6_0() {
    return new US6<0>(0, []);
}

export function US6_US6_1() {
    return new US6<1>(1, []);
}

export class US6<Tag extends keyof US6_$cases> extends Union<Tag, US6_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US6_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US6_0", "US6_1"];
    }
}

export function US6_$reflection(): TypeInfo {
    return union_type("Common.US6", [], US6, () => [[], []]);
}

export type US7_$union = 
    | US7<0>
    | US7<1>

export type US7_$cases = {
    0: ["US7_0", [US6_$union]],
    1: ["US7_1", []]
}

export function US7_US7_0(f0_0: US6_$union) {
    return new US7<0>(0, [f0_0]);
}

export function US7_US7_1() {
    return new US7<1>(1, []);
}

export class US7<Tag extends keyof US7_$cases> extends Union<Tag, US7_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US7_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US7_0", "US7_1"];
    }
}

export function US7_$reflection(): TypeInfo {
    return union_type("Common.US7", [], US7, () => [[["f0_0", US6_$reflection()]], []]);
}

export type US8_$union = 
    | US8<0>
    | US8<1>

export type US8_$cases = {
    0: ["US8_0", [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>]],
    1: ["US8_1", []]
}

export function US8_US8_0(f0_0: Mut0, f0_1: Mut1, f0_2: Mut2, f0_3: Mut3, f0_4: Mut4, f0_5: Option<int64>) {
    return new US8<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4, f0_5]);
}

export function US8_US8_1() {
    return new US8<1>(1, []);
}

export class US8<Tag extends keyof US8_$cases> extends Union<Tag, US8_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US8_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US8_0", "US8_1"];
    }
}

export function US8_$reflection(): TypeInfo {
    return union_type("Common.US8", [], US8, () => [[["f0_0", Mut0_$reflection()], ["f0_1", Mut1_$reflection()], ["f0_2", Mut2_$reflection()], ["f0_3", Mut3_$reflection()], ["f0_4", Mut4_$reflection()], ["f0_5", option_type(int64_type)]], []]);
}

export function method3(v0: string): string {
    return v0;
}

export function method4(): string {
    return "";
}

export function closure1(unitVar: void, v0: string): US5_$union {
    return US5_US5_0(v0);
}

export function method5(): ((arg0: string) => US5_$union) {
    return (v: string): US5_$union => closure1(undefined, v);
}

export function method2(v0: string): string {
    return process.env[v0] ?? "";
}

export function method1(): [US1_$union, US2_$union] {
    let v48: US1_$union, v55: US1_$union, v62: US1_$union, v69: US1_$union, v76: US1_$union, v83: US1_$union, v90: US1_$union, v97: US1_$union, v104: US1_$union;
    const v1: string = method2("TRACE_LEVEL");
    const v6: string = "Critical".toLocaleLowerCase();
    const v13: string = "Warning".toLocaleLowerCase();
    const v20: string = "Info".toLocaleLowerCase();
    const v27: string = "Debug".toLocaleLowerCase();
    const v34: string = "Verbose".toLocaleLowerCase();
    const v41: US1_$union = ("Verbose" === v1) ? US1_US1_0(US0_US0_0()) : US1_US1_1();
    return [((v41.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v41.fields[0] as any) : ((v48 = (("Debug" === v1) ? US1_US1_0(US0_US0_1()) : US1_US1_1()), ((v48.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v48.fields[0] as any) : ((v55 = (("Info" === v1) ? US1_US1_0(US0_US0_2()) : US1_US1_1()), ((v55.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v55.fields[0] as any) : ((v62 = (("Warning" === v1) ? US1_US1_0(US0_US0_3()) : US1_US1_1()), ((v62.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v62.fields[0] as any) : ((v69 = (("Critical" === v1) ? US1_US1_0(US0_US0_4()) : US1_US1_1()), ((v69.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v69.fields[0] as any) : ((v76 = ((v34 === v1) ? US1_US1_0(US0_US0_0()) : US1_US1_1()), ((v76.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v76.fields[0] as any) : ((v83 = ((v27 === v1) ? US1_US1_0(US0_US0_1()) : US1_US1_1()), ((v83.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v83.fields[0] as any) : ((v90 = ((v20 === v1) ? US1_US1_0(US0_US0_2()) : US1_US1_1()), ((v90.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v90.fields[0] as any) : ((v97 = ((v13 === v1) ? US1_US1_0(US0_US0_3()) : US1_US1_1()), ((v97.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v97.fields[0] as any) : ((v104 = ((v6 === v1) ? US1_US1_0(US0_US0_4()) : US1_US1_1()), ((v104.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v104.fields[0] as any) : US1_US1_1())))))))))))))))))), (method2("AUTOMATION") !== "True") ? US2_US2_1() : US2_US2_0(toInt64(fromInt64(getTicks(now()))))] as [US1_$union, US2_$union];
}

export function closure2(unitVar: void, v0: string): void {
}

export function method0(v0: US0_$union): [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] {
    const patternInput: [US1_$union, US2_$union] = method1();
    const _run_target_args$0027_v3 = [patternInput[0], patternInput[1]] as [US1_$union, US2_$union];
    const v185: US2_$union = _run_target_args$0027_v3[1];
    const v184: US1_$union = _run_target_args$0027_v3[0];
    return [new Mut0(1n), new Mut1((v: string): void => {
        closure2(undefined, v);
    }), new Mut2(true), new Mut3(""), new Mut4(((v184.tag as int32) === /* US1_0 */ 0) ? (v184.fields[0] as any) : v0), ((v185.tag as int32) === /* US2_0 */ 0) ? (v185.fields[0] as any) : undefined] as [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>];
}

export function closure0(unitVar: void, unitVar_1: void): void {
    if (TraceState_trace_state() == null) {
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = method0(US0_US0_0());
        TraceState_trace_state([patternInput[0], patternInput[1], patternInput[2], patternInput[3], patternInput[4], patternInput[5]] as [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>]);
    }
}

export function method6(v0: (() => void)): (() => void) {
    return v0;
}

export function method7(v0: (() => void)): (() => void) {
    return v0;
}

export function closure3(unitVar: void, v0: (() => void)): IDisposable {
    const v12: (() => void) = method7(v0);
    return {
        Dispose(): void {
            v12();
        },
    };
}

export function closure6(unitVar: void, v0: US6_$union): US7_$union {
    return US7_US7_0(v0);
}

export function closure7(v0: int32, v1: (() => void), v2: int32, unitVar: void): US6_$union {
    if (v2 < v0) {
        v1();
        return US6_US6_0();
    }
    else {
        return US6_US6_1();
    }
}

export function closure10(unitVar: void, v0: int64): US2_$union {
    return US2_US2_0(v0);
}

export function method10(): ((arg0: int64) => US2_$union) {
    return (v: int64): US2_$union => closure10(undefined, v);
}

export function method11(): string {
    return "hh:mm:ss";
}

export function method12(): string {
    return "HH:mm:ss";
}

export function method9(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>): string {
    const v710: US2_$union = defaultArg(map<int64, US2_$union>(method10(), v5), US2_US2_1());
    let v864: Date;
    if ((v710.tag as int32) === /* US2_0 */ 0) {
        const v714 = v710.fields[0] as any;
        const v793: number = fromTicks(toInt64(op_Subtraction(toInt64(fromInt64(getTicks(now()))), v714)));
        v864 = create(1, 1, 1, hours(v793), minutes(v793), seconds(v793), milliseconds(v793));
    }
    else {
        v864 = now();
    }
    const v865: string = method12();
    return toString(v864, (v865 === "") ? "M-d-y hh:mm:ss tt" : v865);
}

export function method15(): string {
    return "";
}

export function closure11(v0: Mut3, v1: string, unitVar: void): void {
    const v4: string = v0.l0 + v1;
    v0.l0 = v4;
}

export function method14(v0: string): string {
    const v2: Mut3 = new Mut3(method15());
    let v17: any;
    closure11(v2, `${v0}`, undefined);
    v17 = undefined;
    return v2.l0;
}

export function method13(): string {
    const v133: string = "Warning".toLocaleLowerCase();
    return ("\u001b[93m" + method14(v133[0])) + "\u001b[0m";
}

export function method17(v0: int32, v1: Error): string {
    const v3: Mut3 = new Mut3(method15());
    let v17: any;
    closure11(v3, "{ ", undefined);
    v17 = undefined;
    let v36: any;
    closure11(v3, "retry", undefined);
    v36 = undefined;
    let v55: any;
    closure11(v3, " = ", undefined);
    v55 = undefined;
    let v75: any;
    closure11(v3, `${v0}`, undefined);
    v75 = undefined;
    let v94: any;
    closure11(v3, "; ", undefined);
    v94 = undefined;
    let v113: any;
    closure11(v3, "ex", undefined);
    v113 = undefined;
    let v130: any;
    closure11(v3, " = ", undefined);
    v130 = undefined;
    let v189: any;
    closure11(v3, toText(interpolate("%A%P()", [v1])), undefined);
    v189 = undefined;
    let v208: any;
    closure11(v3, " }", undefined);
    v208 = undefined;
    return v3.l0;
}

export function method18(v0: string): string {
    return trimEnd(trimStart(v0, ...[]), ...[" ", "/"]);
}

export function method16(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: Error): string {
    const v10: string = method17(v8, v9);
    return method18((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "common.retry_fn") + " / ") + v10);
}

export function closure12(v0: Mut0, unitVar: void): void {
    const v2: int64 = toInt64(op_Addition(v0.l0, 1n));
    v0.l0 = v2;
}

export function closure14(v0: string, unitVar: void): void {
    console.log(v0);
}

export function closure13(unitVar: void, v0: string): void {
    let v4: any;
    closure14(v0, undefined);
    v4 = undefined;
}

export function closure9(v0: int32, v1: Error, unitVar: void): void {
    const v17 = (): void => {
        closure0(undefined, undefined);
    };
    let v18: any;
    v17();
    v18 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_1(TraceState_trace_state());
    const v59: US0_$union = patternInput[4].l0;
    let v299: US8_$union;
    if (((patternInput[2].l0 === false) ? false : (3 >= find<US0_$union, int32>(v59, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v299 = US8_US8_1();
    }
    else {
        let v82: any;
        v17();
        v82 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_1(TraceState_trace_state());
        const v110: Option<int64> = patternInput_1[5];
        const v109: Mut4 = patternInput_1[4];
        const v108: Mut3 = patternInput_1[3];
        const v107: Mut2 = patternInput_1[2];
        const v106: Mut1 = patternInput_1[1];
        const v105: Mut0 = patternInput_1[0];
        const v125: string = method16(v105, v106, v107, v108, v109, v110, method9(v105, v106, v107, v108, v109, v110), method13(), v0, v1);
        let v141: any;
        v17();
        v141 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_1(TraceState_trace_state());
        const v165: Mut1 = patternInput_2[1];
        const v164: Mut0 = patternInput_2[0];
        let v186: any;
        closure12(v164, undefined);
        v186 = undefined;
        closure13(undefined, v125);
        v165.l0(v125);
        v299 = US8_US8_0(v164, v165, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function closure8(v0: int32, v1: Error): US7_$union {
    let v315: any;
    closure9(v0, v1, undefined);
    v315 = undefined;
    return US7_US7_1();
}

export function method8(v0_mut: int32, v1_mut: (() => void), v2_mut: int32): US6_$union {
    method8:
    while (true) {
        const v0: int32 = v0_mut, v1: (() => void) = v1_mut, v2: int32 = v2_mut;
        const result: FSharpRef<US7_$union> = new FSharpRef<US7_$union>(US7_US7_1());
        try {
            result.contents = closure6(undefined, closure7(v0, v1, v2, undefined));
        }
        catch (ex: any) {
            result.contents = closure8(v2, ex);
        }
        const v9: US7_$union = result.contents;
        if ((v9.tag as int32) === /* US7_0 */ 0) {
            return v9.fields[0] as any;
        }
        else {
            v0_mut = v0;
            v1_mut = v1;
            v2_mut = (v2 + 1);
            continue method8;
        }
        break;
    }
}

export function closure5(v0: int32, v1: (() => void)): Option<void> {
    const v3: US6_$union = method8(v0, v1, 0);
    if ((v3.tag as int32) === /* US6_0 */ 0) {
        return some(undefined);
    }
    else {
        return undefined;
    }
}

export function closure4(unitVar: void, v0: int32): ((arg0: (() => void)) => Option<void>) {
    return (v: (() => void)): Option<void> => closure5(v0, v);
}

export function closure16(v0: any, unitVar: void): void {
    v0.Value;
}

export function closure15(unitVar: void, v0: (() => void)): (() => void) {
    const v4: any = new Lazy<void>((): void => {
        v0();
    });
    return (): void => {
        closure16(v4, undefined);
    };
}

export const v14: any = undefined;

export const v15 = (): void => {
    closure0(undefined, undefined);
};

export const v16: any = (v15(), v14);

export const v31 = (v: (() => void)): IDisposable => closure3(undefined, v);

export function new_disposable(x: (() => void)): IDisposable {
    return v31(x);
}

export const v32 = (v: int32): ((arg0: (() => void)) => Option<void>) => closure4(undefined, v);

export function retry_fn(x: int32): ((arg0: (() => void)) => Option<void>) {
    return v32(x);
}

export const v33 = (v: (() => void)): (() => void) => closure15(undefined, v);

export function memoize(x: (() => void)): (() => void) {
    return v33(x);
}


