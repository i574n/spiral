import { IDisposable, defaultOf, compare, int64ToString, IComparable, IEquatable, createAtom } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Util.js";
import { value as value_3, map, defaultArg, Option } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Option.js";
import { op_Modulus, equals, op_Addition, op_Subtraction, fromInt64, toInt64, int64 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/BigInt.js";
import { Record, Union } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Types.js";
import { int32_type, class_type, option_type, bool_type, lambda_type, unit_type, string_type, record_type, int64_type, union_type, TypeInfo } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Reflection.js";
import { int32 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Int32.js";
import { toString, create, now, getTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Date.js";
import { milliseconds, seconds, minutes, hours, fromTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/TimeSpan.js";
import { interpolate, toText, trimStart, trimEnd } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/String.js";
import { ofSeq, find } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Map.js";
import { Async, singleton } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/AsyncBuilder.js";
import { sleep, catchAsync, startChild, awaitTask, cancellationToken } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Async.js";
import { FSharpChoice$2_$union } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Choice.js";

export interface IOsEnviron {
    environ(): any
}

export let TraceState_trace_state = createAtom<Option<[Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>]>>(undefined);

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
    return union_type("Networking.US0", [], US0, () => [[], [], [], [], []]);
}

export class Mut0 extends Record implements IEquatable<Mut0>, IComparable<Mut0> {
    l0: int64;
    constructor(l0: int64) {
        super();
        this.l0 = l0;
    }
}

export function Mut0_$reflection(): TypeInfo {
    return record_type("Networking.Mut0", [], Mut0, () => [["l0", int64_type]]);
}

export class Mut1 extends Record {
    l0: ((arg0: string) => void);
    constructor(l0: ((arg0: string) => void)) {
        super();
        this.l0 = l0;
    }
}

export function Mut1_$reflection(): TypeInfo {
    return record_type("Networking.Mut1", [], Mut1, () => [["l0", lambda_type(string_type, unit_type)]]);
}

export class Mut2 extends Record implements IEquatable<Mut2>, IComparable<Mut2> {
    l0: boolean;
    constructor(l0: boolean) {
        super();
        this.l0 = l0;
    }
}

export function Mut2_$reflection(): TypeInfo {
    return record_type("Networking.Mut2", [], Mut2, () => [["l0", bool_type]]);
}

export class Mut3 extends Record implements IEquatable<Mut3>, IComparable<Mut3> {
    l0: string;
    constructor(l0: string) {
        super();
        this.l0 = l0;
    }
}

export function Mut3_$reflection(): TypeInfo {
    return record_type("Networking.Mut3", [], Mut3, () => [["l0", string_type]]);
}

export class Mut4 extends Record implements IEquatable<Mut4>, IComparable<Mut4> {
    l0: US0_$union;
    constructor(l0: US0_$union) {
        super();
        this.l0 = l0;
    }
}

export function Mut4_$reflection(): TypeInfo {
    return record_type("Networking.Mut4", [], Mut4, () => [["l0", US0_$reflection()]]);
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
    return union_type("Networking.US1", [], US1, () => [[["f0_0", US0_$reflection()]], []]);
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
    return union_type("Networking.US2", [], US2, () => [[["f0_0", int64_type]], []]);
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
    return union_type("Networking.US3", [], US3, () => [[], [], []]);
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
    return union_type("Networking.US4", [], US4, () => [[["f0_0", US3_$reflection()]], [["f1_0", US3_$reflection()]], [["f2_0", US3_$reflection()]], [["f3_0", US3_$reflection()]], [["f4_0", US3_$reflection()]], [["f5_0", US3_$reflection()]], [["f6_0", US3_$reflection()]]]);
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
    return union_type("Networking.US5", [], US5, () => [[["f0_0", string_type]], []]);
}

export type US6_$union = 
    | US6<0>
    | US6<1>

export type US6_$cases = {
    0: ["US6_0", [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>]],
    1: ["US6_1", []]
}

export function US6_US6_0(f0_0: Mut0, f0_1: Mut1, f0_2: Mut2, f0_3: Mut3, f0_4: Mut4, f0_5: Option<int64>) {
    return new US6<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4, f0_5]);
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
    return union_type("Networking.US6", [], US6, () => [[["f0_0", Mut0_$reflection()], ["f0_1", Mut1_$reflection()], ["f0_2", Mut2_$reflection()], ["f0_3", Mut3_$reflection()], ["f0_4", Mut4_$reflection()], ["f0_5", option_type(int64_type)]], []]);
}

export type US7_$union = 
    | US7<0>
    | US7<1>

export type US7_$cases = {
    0: ["US7_0", [boolean]],
    1: ["US7_1", []]
}

export function US7_US7_0(f0_0: boolean) {
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
    return union_type("Networking.US7", [], US7, () => [[["f0_0", bool_type]], []]);
}

export type US8_$union = 
    | US8<0>
    | US8<1>

export type US8_$cases = {
    0: ["US8_0", [boolean]],
    1: ["US8_1", [Error]]
}

export function US8_US8_0(f0_0: boolean) {
    return new US8<0>(0, [f0_0]);
}

export function US8_US8_1(f1_0: Error) {
    return new US8<1>(1, [f1_0]);
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
    return union_type("Networking.US8", [], US8, () => [[["f0_0", bool_type]], [["f1_0", class_type("System.Exception")]]]);
}

export type US9_$union = 
    | US9<0>
    | US9<1>

export type US9_$cases = {
    0: ["US9_0", [boolean]],
    1: ["US9_1", [Error]]
}

export function US9_US9_0(f0_0: boolean) {
    return new US9<0>(0, [f0_0]);
}

export function US9_US9_1(f1_0: Error) {
    return new US9<1>(1, [f1_0]);
}

export class US9<Tag extends keyof US9_$cases> extends Union<Tag, US9_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US9_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US9_0", "US9_1"];
    }
}

export function US9_$reflection(): TypeInfo {
    return union_type("Networking.US9", [], US9, () => [[["f0_0", bool_type]], [["f1_0", class_type("System.Exception")]]]);
}

export type US10_$union = 
    | US10<0>
    | US10<1>

export type US10_$cases = {
    0: ["US10_0", [int32]],
    1: ["US10_1", []]
}

export function US10_US10_0(f0_0: int32) {
    return new US10<0>(0, [f0_0]);
}

export function US10_US10_1() {
    return new US10<1>(1, []);
}

export class US10<Tag extends keyof US10_$cases> extends Union<Tag, US10_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US10_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US10_0", "US10_1"];
    }
}

export function US10_$reflection(): TypeInfo {
    return union_type("Networking.US10", [], US10, () => [[["f0_0", int32_type]], []]);
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
    const v34_1: string = "Verbose".toLocaleLowerCase();
    const v41: US1_$union = ("Verbose" === v1) ? US1_US1_0(US0_US0_0()) : US1_US1_1();
    return [((v41.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v41.fields[0] as any) : ((v48 = (("Debug" === v1) ? US1_US1_0(US0_US0_1()) : US1_US1_1()), ((v48.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v48.fields[0] as any) : ((v55 = (("Info" === v1) ? US1_US1_0(US0_US0_2()) : US1_US1_1()), ((v55.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v55.fields[0] as any) : ((v62 = (("Warning" === v1) ? US1_US1_0(US0_US0_3()) : US1_US1_1()), ((v62.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v62.fields[0] as any) : ((v69 = (("Critical" === v1) ? US1_US1_0(US0_US0_4()) : US1_US1_1()), ((v69.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v69.fields[0] as any) : ((v76 = ((v34_1 === v1) ? US1_US1_0(US0_US0_0()) : US1_US1_1()), ((v76.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v76.fields[0] as any) : ((v83 = ((v27 === v1) ? US1_US1_0(US0_US0_1()) : US1_US1_1()), ((v83.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v83.fields[0] as any) : ((v90 = ((v20 === v1) ? US1_US1_0(US0_US0_2()) : US1_US1_1()), ((v90.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v90.fields[0] as any) : ((v97 = ((v13 === v1) ? US1_US1_0(US0_US0_3()) : US1_US1_1()), ((v97.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v97.fields[0] as any) : ((v104 = ((v6 === v1) ? US1_US1_0(US0_US0_4()) : US1_US1_1()), ((v104.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v104.fields[0] as any) : US1_US1_1())))))))))))))))))), (method2("AUTOMATION") !== "True") ? US2_US2_1() : US2_US2_0(toInt64(fromInt64(getTicks(now()))))] as [US1_$union, US2_$union];
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

export function closure6(unitVar: void, v0: int64): US2_$union {
    return US2_US2_0(v0);
}

export function method9(): ((arg0: int64) => US2_$union) {
    return (v: int64): US2_$union => closure6(undefined, v);
}

export function method10(): string {
    return "hh:mm:ss";
}

export function method11(): string {
    return "HH:mm:ss";
}

export function method8(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>): string {
    const v710: US2_$union = defaultArg(map<int64, US2_$union>(method9(), v5), US2_US2_1());
    let v864: Date;
    if ((v710.tag as int32) === /* US2_0 */ 0) {
        const v714 = v710.fields[0] as any;
        const v793: number = fromTicks(toInt64(op_Subtraction(toInt64(fromInt64(getTicks(now()))), v714)));
        v864 = create(1, 1, 1, hours(v793), minutes(v793), seconds(v793), milliseconds(v793));
    }
    else {
        v864 = now();
    }
    const v865: string = method11();
    return toString(v864, (v865 === "") ? "M-d-y hh:mm:ss tt" : v865);
}

export function method14(): string {
    return "";
}

export function closure7(v0: Mut3, v1: string, unitVar: void): void {
    const v4: string = v0.l0 + v1;
    v0.l0 = v4;
}

export function method13(v0: string): string {
    const v2: Mut3 = new Mut3(method14());
    let v17: any;
    closure7(v2, `${v0}`, undefined);
    v17 = undefined;
    return v2.l0;
}

export function method12(): string {
    const v133: string = "Verbose".toLocaleLowerCase();
    return ("\u001b[90m" + method13(v133[0])) + "\u001b[0m";
}

export function method16(v0: int32, v1: string): string {
    const v3: Mut3 = new Mut3(method14());
    let v17: any;
    closure7(v3, "{ ", undefined);
    v17 = undefined;
    let v36: any;
    closure7(v3, "port", undefined);
    v36 = undefined;
    let v55: any;
    closure7(v3, " = ", undefined);
    v55 = undefined;
    let v75: any;
    closure7(v3, `${v0}`, undefined);
    v75 = undefined;
    let v94: any;
    closure7(v3, "; ", undefined);
    v94 = undefined;
    let v113: any;
    closure7(v3, "ex", undefined);
    v113 = undefined;
    let v130: any;
    closure7(v3, " = ", undefined);
    v130 = undefined;
    let v147: any;
    closure7(v3, v1, undefined);
    v147 = undefined;
    let v166: any;
    closure7(v3, " }", undefined);
    v166 = undefined;
    return v3.l0;
}

export function method17(v0: string): string {
    return trimEnd(trimStart(v0, ...[]), ...[" ", "/"]);
}

export function method15(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: string): string {
    const v10: string = method16(v8, v9);
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "networking.test_port_open") + " / ") + v10);
}

export function closure8(v0: Mut0, unitVar: void): void {
    const v2: int64 = toInt64(op_Addition(v0.l0, 1n));
    v0.l0 = v2;
}

export function closure10(v0: string, unitVar: void): void {
    console.log(v0);
}

export function closure9(unitVar: void, v0: string): void {
    let v4: any;
    closure10(v0, undefined);
    v4 = undefined;
}

export function closure5(v0: int32, v1: Error, unitVar: void): void {
    const v17 = (): void => {
        closure0(undefined, undefined);
    };
    let v18: any;
    v17();
    v18 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
    const v59: US0_$union = patternInput[4].l0;
    let v338: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (0 >= find<US0_$union, int32>(v59, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v338 = US6_US6_1();
    }
    else {
        let v82: any;
        v17();
        v82 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
        const v110: Option<int64> = patternInput_1[5];
        const v109: Mut4 = patternInput_1[4];
        const v108: Mut3 = patternInput_1[3];
        const v107: Mut2 = patternInput_1[2];
        const v106: Mut1 = patternInput_1[1];
        const v105: Mut0 = patternInput_1[0];
        const v164: string = method15(v105, v106, v107, v108, v109, v110, method8(v105, v106, v107, v108, v109, v110), method12(), v0, toText(interpolate("%A%P()", [v1])));
        let v180: any;
        v17();
        v180 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
        const v204: Mut1 = patternInput_2[1];
        const v203: Mut0 = patternInput_2[0];
        let v225: any;
        closure8(v203, undefined);
        v225 = undefined;
        closure9(undefined, v164);
        v204.l0(v164);
        v338 = US6_US6_0(v203, v204, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method7(v0: string, v1: int32): Async<boolean> {
    return singleton.Delay<boolean>((): Async<boolean> => {
        const v32523: Async<any> = cancellationToken();
        return singleton.Bind<any, boolean>(v32523, (_arg: any): Async<boolean> => {
            const v32543: IDisposable = defaultOf();
            return singleton.Using<IDisposable, boolean>(v32543, (_arg_1: IDisposable): Async<boolean> => singleton.TryWith<boolean>(singleton.Delay<boolean>((): Async<boolean> => {
                const v32696: any = defaultOf();
                const v32775: Async<void> = awaitTask(defaultOf());
                return singleton.Bind<void, boolean>(v32775, (): Async<boolean> => singleton.Return<boolean>(true));
            }), (_arg_3: Error): Async<boolean> => {
                let v33958: any;
                closure5(v1, _arg_3, undefined);
                v33958 = undefined;
                return singleton.Return<boolean>(false);
            }));
        });
    });
}

export function method6(v0: string, v1: int32): Async<boolean> {
    return method7(v0, v1);
}

export function closure4(v0: string, v1: int32): Async<boolean> {
    return method6(v0, v1);
}

export function closure3(unitVar: void, v0: string): ((arg0: int32) => Async<boolean>) {
    return (v: int32): Async<boolean> => closure4(v0, v);
}

export function closure15(unitVar: void, v0: boolean): US8_$union {
    return US8_US8_0(v0);
}

export function method22(): ((arg0: boolean) => US8_$union) {
    return (v: boolean): US8_$union => closure15(undefined, v);
}

export function closure16(unitVar: void, v0: Error): US8_$union {
    return US8_US8_1(v0);
}

export function method23(): ((arg0: Error) => US8_$union) {
    return (v: Error): US8_$union => closure16(undefined, v);
}

export function closure14(unitVar: void, v0: FSharpChoice$2_$union<boolean, Error>): US8_$union {
    return defaultOf();
}

export function method25(v0: ((arg0: FSharpChoice$2_$union<boolean, Error>) => US8_$union), v1: Async<FSharpChoice$2_$union<boolean, Error>>): Async<US8_$union> {
    return singleton.Delay<US8_$union>((): Async<US8_$union> => singleton.Bind<FSharpChoice$2_$union<boolean, Error>, US8_$union>(v1, (_arg: FSharpChoice$2_$union<boolean, Error>): Async<US8_$union> => {
        const v50: US8_$union = v0(_arg);
        return singleton.Return<US8_$union>(v50);
    }));
}

export function method24(v0: ((arg0: FSharpChoice$2_$union<boolean, Error>) => US8_$union), v1: Async<FSharpChoice$2_$union<boolean, Error>>): Async<US8_$union> {
    return method25(v0, v1);
}

export function closure17(unitVar: void, v0: US8_$union): US9_$union {
    if ((v0.tag as int32) === /* US8_1 */ 1) {
        return US9_US9_1(v0.fields[0] as any);
    }
    else {
        return US9_US9_0(v0.fields[0] as any);
    }
}

export function method27(v0: ((arg0: US8_$union) => US9_$union), v1: Async<US8_$union>): Async<US9_$union> {
    return singleton.Delay<US9_$union>((): Async<US9_$union> => singleton.Bind<US8_$union, US9_$union>(v1, (_arg: US8_$union): Async<US9_$union> => {
        const v50: US9_$union = v0(_arg);
        return singleton.Return<US9_$union>(v50);
    }));
}

export function method26(v0: ((arg0: US8_$union) => US9_$union), v1: Async<US8_$union>): Async<US9_$union> {
    return method27(v0, v1);
}

export function method29(v0: int32): string {
    const v2: Mut3 = new Mut3(method14());
    let v16_1: any;
    closure7(v2, "{ ", undefined);
    v16_1 = undefined;
    let v35: any;
    closure7(v2, "timeout", undefined);
    v35 = undefined;
    let v54: any;
    closure7(v2, " = ", undefined);
    v54 = undefined;
    let v74: any;
    closure7(v2, `${v0}`, undefined);
    v74 = undefined;
    let v93: any;
    closure7(v2, " }", undefined);
    v93 = undefined;
    return v2.l0;
}

export function method28(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32): string {
    const v9: string = method29(v8);
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "async.run_with_timeout_async") + " / ") + v9);
}

export function closure19(v0: int32, unitVar: void): void {
    const v16_1 = (): void => {
        closure0(undefined, undefined);
    };
    let v17: any;
    v16_1();
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
    const v58: US0_$union = patternInput[4].l0;
    let v298: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (0 >= find<US0_$union, int32>(v58, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v298 = US6_US6_1();
    }
    else {
        let v81: any;
        v16_1();
        v81 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
        const v109: Option<int64> = patternInput_1[5];
        const v108: Mut4 = patternInput_1[4];
        const v107: Mut3 = patternInput_1[3];
        const v106: Mut2 = patternInput_1[2];
        const v105: Mut1 = patternInput_1[1];
        const v104: Mut0 = patternInput_1[0];
        const v124: string = method28(v104, v105, v106, v107, v108, v109, method8(v104, v105, v106, v107, v108, v109), method12(), v0);
        let v140: any;
        v16_1();
        v140 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
        const v164: Mut1 = patternInput_2[1];
        const v163: Mut0 = patternInput_2[0];
        let v185: any;
        closure8(v163, undefined);
        v185 = undefined;
        closure9(undefined, v124);
        v164.l0(v124);
        v298 = US6_US6_0(v163, v164, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method30(): string {
    const v133: string = "Critical".toLocaleLowerCase();
    return ("\u001b[91m" + method13(v133[0])) + "\u001b[0m";
}

export function method32(v0: int32, v1: string): string {
    const v3: Mut3 = new Mut3(method14());
    let v17: any;
    closure7(v3, "{ ", undefined);
    v17 = undefined;
    let v36: any;
    closure7(v3, "timeout", undefined);
    v36 = undefined;
    let v55: any;
    closure7(v3, " = ", undefined);
    v55 = undefined;
    let v75: any;
    closure7(v3, `${v0}`, undefined);
    v75 = undefined;
    let v94: any;
    closure7(v3, "; ", undefined);
    v94 = undefined;
    let v113: any;
    closure7(v3, "ex", undefined);
    v113 = undefined;
    let v130: any;
    closure7(v3, " = ", undefined);
    v130 = undefined;
    let v147: any;
    closure7(v3, v1, undefined);
    v147 = undefined;
    let v166: any;
    closure7(v3, " }", undefined);
    v166 = undefined;
    return v3.l0;
}

export function method31(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: string): string {
    const v10: string = method32(v8, v9);
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "async.run_with_timeout_async**") + " / ") + v10);
}

export function closure20(v0: int32, v1: Error, unitVar: void): void {
    const v17 = (): void => {
        closure0(undefined, undefined);
    };
    let v18: any;
    v17();
    v18 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
    const v59: US0_$union = patternInput[4].l0;
    let v338: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (4 >= find<US0_$union, int32>(v59, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v338 = US6_US6_1();
    }
    else {
        let v82: any;
        v17();
        v82 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
        const v110: Option<int64> = patternInput_1[5];
        const v109: Mut4 = patternInput_1[4];
        const v108: Mut3 = patternInput_1[3];
        const v107: Mut2 = patternInput_1[2];
        const v106: Mut1 = patternInput_1[1];
        const v105: Mut0 = patternInput_1[0];
        const v164: string = method31(v105, v106, v107, v108, v109, v110, method8(v105, v106, v107, v108, v109, v110), method30(), v0, toText(interpolate("%A%P()", [v1])));
        let v180: any;
        v17();
        v180 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
        const v204: Mut1 = patternInput_2[1];
        const v203: Mut0 = patternInput_2[0];
        let v225: any;
        closure8(v203, undefined);
        v225 = undefined;
        closure9(undefined, v164);
        v204.l0(v164);
        v338 = US6_US6_0(v203, v204, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function closure18(v0: int32, v1: US9_$union): US7_$union {
    if ((v1.tag as int32) === /* US9_0 */ 0) {
        return US7_US7_0(v1.fields[0] as any);
    }
    else {
        const v4 = v1.fields[0] as any;
        const v6: string = toText(interpolate("%A%P()", [v4]));
        if (v6.indexOf("System.TimeoutException") >= 0) {
            let v328: any;
            closure19(v0, undefined);
            v328 = undefined;
            return US7_US7_1();
        }
        else {
            let v996: any;
            closure20(v0, v4, undefined);
            v996 = undefined;
            return US7_US7_1();
        }
    }
}

export function method34(v0: ((arg0: US9_$union) => US7_$union), v1: Async<US9_$union>): Async<US7_$union> {
    return singleton.Delay<US7_$union>((): Async<US7_$union> => singleton.Bind<US9_$union, US7_$union>(v1, (_arg: US9_$union): Async<US7_$union> => {
        const v50: US7_$union = v0(_arg);
        return singleton.Return<US7_$union>(v50);
    }));
}

export function method33(v0: ((arg0: US9_$union) => US7_$union), v1: Async<US9_$union>): Async<US7_$union> {
    return method34(v0, v1);
}

export function method21(v0: Async<boolean>, v1: int32): Async<US7_$union> {
    return singleton.Delay<US7_$union>((): Async<US7_$union> => {
        const v963: Async<Async<boolean>> = startChild<boolean>(v0, v1);
        return singleton.Bind<Async<boolean>, US7_$union>(v963, (_arg: Async<boolean>): Async<US7_$union> => {
            const v1016: Async<US7_$union> = method33((v_2: US9_$union): US7_$union => closure18(v1, v_2), method26((v_1: US8_$union): US9_$union => closure17(undefined, v_1), method24((v: FSharpChoice$2_$union<boolean, Error>): US8_$union => closure14(undefined, v), catchAsync<boolean>(_arg))));
            return singleton.ReturnFrom<US7_$union>(v1016);
        });
    });
}

export function method20(v0: int32, v1: Async<boolean>): Async<US7_$union> {
    return method21(v1, v0);
}

export function method19(v0: int32, v1: string, v2: int32): Async<boolean> {
    return singleton.Delay<boolean>((): Async<boolean> => {
        const v103: Async<US7_$union> = method20(v0, method6(v1, v2));
        return singleton.Bind<US7_$union, boolean>(v103, (_arg: US7_$union): Async<boolean> => {
            const v104: US7_$union = _arg;
            const v107: boolean = ((v104.tag as int32) === /* US7_0 */ 0) && (v104.fields[0] as any);
            return singleton.Return<boolean>(v107);
        });
    });
}

export function method18(v0: int32, v1: string, v2: int32): Async<boolean> {
    return method19(v0, v1, v2);
}

export function closure13(v0: int32, v1: string, v2: int32): Async<boolean> {
    return method18(v0, v1, v2);
}

export function closure12(v0: int32, v1: string): ((arg0: int32) => Async<boolean>) {
    return (v: int32): Async<boolean> => closure13(v0, v1, v);
}

export function closure11(unitVar: void, v0: int32): ((arg0: string) => ((arg0: int32) => Async<boolean>)) {
    return (v: string): ((arg0: int32) => Async<boolean>) => closure12(v0, v);
}

export function closure25(unitVar: void, v0: int32): US10_$union {
    return US10_US10_0(v0);
}

export function method38(): ((arg0: int32) => US10_$union) {
    return (v: int32): US10_$union => closure25(undefined, v);
}

export function method40(v0: int32, v1: int64, v2: Option<int32>, v3: boolean): string {
    const v5: Mut3 = new Mut3(method14());
    let v19: any;
    closure7(v5, "{ ", undefined);
    v19 = undefined;
    let v38: any;
    closure7(v5, "port", undefined);
    v38 = undefined;
    let v57: any;
    closure7(v5, " = ", undefined);
    v57 = undefined;
    let v77: any;
    closure7(v5, `${v0}`, undefined);
    v77 = undefined;
    let v96: any;
    closure7(v5, "; ", undefined);
    v96 = undefined;
    let v115: any;
    closure7(v5, "retry", undefined);
    v115 = undefined;
    let v132: any;
    closure7(v5, " = ", undefined);
    v132 = undefined;
    let v152: any;
    closure7(v5, `${v1}`, undefined);
    v152 = undefined;
    let v169: any;
    closure7(v5, "; ", undefined);
    v169 = undefined;
    let v188: any;
    closure7(v5, "timeout", undefined);
    v188 = undefined;
    let v205: any;
    closure7(v5, " = ", undefined);
    v205 = undefined;
    let v264: any;
    closure7(v5, toText(interpolate("%A%P()", [v2])), undefined);
    v264 = undefined;
    let v281: any;
    closure7(v5, "; ", undefined);
    v281 = undefined;
    let v300: any;
    closure7(v5, "status", undefined);
    v300 = undefined;
    let v317: any;
    closure7(v5, " = ", undefined);
    v317 = undefined;
    let v337: any;
    closure7(v5, v3 ? "true" : "false", undefined);
    v337 = undefined;
    let v356: any;
    closure7(v5, " }", undefined);
    v356 = undefined;
    return v5.l0;
}

export function method39(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: int64, v10: Option<int32>, v11: boolean): string {
    const v12: string = method40(v8, v9, v10, v11);
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "networking.wait_for_port_access") + " / ") + v12);
}

export function closure26(v0: Option<int32>, v1: boolean, v2: int32, v3: int64, unitVar: void): void {
    const v19 = (): void => {
        closure0(undefined, undefined);
    };
    let v20: any;
    v19();
    v20 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
    const v61: US0_$union = patternInput[4].l0;
    let v301: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (0 >= find<US0_$union, int32>(v61, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v301 = US6_US6_1();
    }
    else {
        let v84: any;
        v19();
        v84 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
        const v112: Option<int64> = patternInput_1[5];
        const v111: Mut4 = patternInput_1[4];
        const v110: Mut3 = patternInput_1[3];
        const v109: Mut2 = patternInput_1[2];
        const v108: Mut1 = patternInput_1[1];
        const v107: Mut0 = patternInput_1[0];
        const v127: string = method39(v107, v108, v109, v110, v111, v112, method8(v107, v108, v109, v110, v111, v112), method12(), v2, v3, v0, v1);
        let v143: any;
        v19();
        v143 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_3(TraceState_trace_state());
        const v167: Mut1 = patternInput_2[1];
        const v166: Mut0 = patternInput_2[0];
        let v188: any;
        closure8(v166, undefined);
        v188 = undefined;
        closure9(undefined, v127);
        v167.l0(v127);
        v301 = US6_US6_0(v166, v167, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method37(v0: Option<int32>, v1: boolean, v2: string, v3: int32, v4: int64): Async<int64> {
    return singleton.Delay<int64>((): Async<int64> => {
        const v9016: US10_$union = defaultArg(map<int32, US10_$union>(method38(), v0), US10_US10_1());
        const v9024: Async<boolean> = ((v9016.tag as int32) === /* US10_0 */ 0) ? method18(v9016.fields[0] as any, v2, v3) : method6(v2, v3);
        return singleton.Bind<boolean, int64>(v9024, (_arg: boolean): Async<int64> => {
            let v9342: any;
            if (_arg === v1) {
                return singleton.Return<int64>(v4);
            }
            else {
                const v9028: boolean = equals(toInt64(op_Modulus(v4, 100n)), 0n);
                return singleton.Combine<int64>(v9028 ? ((v9342 = ((closure26(v0, v1, v3, v4, undefined), undefined)), singleton.Zero())) : singleton.Zero(), singleton.Delay<int64>((): Async<int64> => {
                    const v9669: Async<void> = sleep(10);
                    return singleton.Bind<void, int64>(v9669, (): Async<int64> => {
                        const v9683: Async<int64> = method36(v0, v1, v2, v3, toInt64(op_Addition(v4, 1n)));
                        return singleton.ReturnFrom<int64>(v9683);
                    });
                }));
            }
        });
    });
}

export function method36(v0: Option<int32>, v1: boolean, v2: string, v3: int32, v4: int64): Async<int64> {
    return method37(v0, v1, v2, v3, v4);
}

export function method35(v0: Option<int32>, v1: boolean, v2: string, v3: int32): Async<int64> {
    return method36(v0, v1, v2, v3, 1n);
}

export function closure24(v0: Option<int32>, v1: boolean, v2: string, v3: int32): Async<int64> {
    return method35(v0, v1, v2, v3);
}

export function closure23(v0: Option<int32>, v1: boolean, v2: string): ((arg0: int32) => Async<int64>) {
    return (v: int32): Async<int64> => closure24(v0, v1, v2, v);
}

export function closure22(v0: Option<int32>, v1: boolean): ((arg0: string) => ((arg0: int32) => Async<int64>)) {
    return (v: string): ((arg0: int32) => Async<int64>) => closure23(v0, v1, v);
}

export function closure21(unitVar: void, v0: Option<int32>): ((arg0: boolean) => ((arg0: string) => ((arg0: int32) => Async<int64>))) {
    return (v: boolean): ((arg0: string) => ((arg0: int32) => Async<int64>)) => closure22(v0, v);
}

export function method43(v0: Option<int32>, v1: string, v2: int32): Async<int32> {
    return singleton.Delay<int32>((): Async<int32> => {
        const v529: US10_$union = defaultArg(map<int32, US10_$union>(method38(), v0), US10_US10_1());
        const v537: Async<boolean> = ((v529.tag as int32) === /* US10_0 */ 0) ? method18(v529.fields[0] as any, v1, v2) : method6(v1, v2);
        return singleton.Bind<boolean, int32>(v537, (_arg: boolean): Async<int32> => {
            if (_arg === false) {
                return singleton.Return<int32>(v2);
            }
            else {
                const v541: Async<int32> = method42(v0, v1, v2 + 1);
                return singleton.ReturnFrom<int32>(v541);
            }
        });
    });
}

export function method42(v0: Option<int32>, v1: string, v2: int32): Async<int32> {
    return method43(v0, v1, v2);
}

export function method41(v0: Option<int32>, v1: string, v2: int32): Async<int32> {
    return method42(v0, v1, v2);
}

export function closure29(v0: Option<int32>, v1: string, v2: int32): Async<int32> {
    return method41(v0, v1, v2);
}

export function closure28(v0: Option<int32>, v1: string): ((arg0: int32) => Async<int32>) {
    return (v: int32): Async<int32> => closure29(v0, v1, v);
}

export function closure27(unitVar: void, v0: Option<int32>): ((arg0: string) => ((arg0: int32) => Async<int32>)) {
    return (v: string): ((arg0: int32) => Async<int32>) => closure28(v0, v);
}

export const v14: any = undefined;

export const v15 = (): void => {
    closure0(undefined, undefined);
};

export const v16: any = (v15(), v14);

export const v31 = (v: string): ((arg0: int32) => Async<boolean>) => closure3(undefined, v);

export function test_port_open(x: string): ((arg0: int32) => Async<boolean>) {
    return v31(x);
}

export const v32 = (v: int32): ((arg0: string) => ((arg0: int32) => Async<boolean>)) => closure11(undefined, v);

export function test_port_open_timeout(x: int32): ((arg0: string) => ((arg0: int32) => Async<boolean>)) {
    return v32(x);
}

export const v33 = (v: Option<int32>): ((arg0: boolean) => ((arg0: string) => ((arg0: int32) => Async<int64>))) => closure21(undefined, v);

export function wait_for_port_access(x: Option<int32>): ((arg0: boolean) => ((arg0: string) => ((arg0: int32) => Async<int64>))) {
    return v33(x);
}

export const v34 = (v: Option<int32>): ((arg0: string) => ((arg0: int32) => Async<int32>)) => closure27(undefined, v);

export function get_available_port(x: Option<int32>): ((arg0: string) => ((arg0: int32) => Async<int32>)) {
    return v34(x);
}


