import { compare, IComparable, IEquatable, createAtom } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Util.js";
import { map, defaultArg, value as value_2, Option } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Option.js";
import { op_Addition, op_Subtraction, fromInt64, toInt64, int64 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/BigInt.js";
import { Union, Record } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Types.js";
import { parse, uint16, int32 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Int32.js";
import { bool_type, lambda_type, unit_type, string_type, int64_type, union_type, record_type, int32_type, TypeInfo } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Reflection.js";
import * as crypto from "crypto";
import { toString, create, now, getTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Date.js";
import { ofSeq, find } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Map.js";
import { milliseconds, seconds, minutes, hours, fromTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/TimeSpan.js";
import { trimStart, trimEnd } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/String.js";

export interface ICryptoCreateHash {
    createHash(x: string): any
}

export interface IHashlibSha256 {
    sha256(): any
}

export let TraceState_trace_state = createAtom<Option<[Mut1, Mut2, Mut3, Mut4, Mut5, Option<int64>]>>(undefined);

export interface IOsEnviron {
    environ(): any
}

export class Mut0 extends Record implements IEquatable<Mut0>, IComparable<Mut0> {
    l0: int32;
    constructor(l0: int32) {
        super();
        this.l0 = (l0 | 0);
    }
}

export function Mut0_$reflection(): TypeInfo {
    return record_type("Crypto.Mut0", [], Mut0, () => [["l0", int32_type]]);
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
    return union_type("Crypto.US0", [], US0, () => [[], [], [], [], []]);
}

export class Mut1 extends Record implements IEquatable<Mut1>, IComparable<Mut1> {
    l0: int64;
    constructor(l0: int64) {
        super();
        this.l0 = l0;
    }
}

export function Mut1_$reflection(): TypeInfo {
    return record_type("Crypto.Mut1", [], Mut1, () => [["l0", int64_type]]);
}

export class Mut2 extends Record {
    l0: ((arg0: string) => void);
    constructor(l0: ((arg0: string) => void)) {
        super();
        this.l0 = l0;
    }
}

export function Mut2_$reflection(): TypeInfo {
    return record_type("Crypto.Mut2", [], Mut2, () => [["l0", lambda_type(string_type, unit_type)]]);
}

export class Mut3 extends Record implements IEquatable<Mut3>, IComparable<Mut3> {
    l0: boolean;
    constructor(l0: boolean) {
        super();
        this.l0 = l0;
    }
}

export function Mut3_$reflection(): TypeInfo {
    return record_type("Crypto.Mut3", [], Mut3, () => [["l0", bool_type]]);
}

export class Mut4 extends Record implements IEquatable<Mut4>, IComparable<Mut4> {
    l0: string;
    constructor(l0: string) {
        super();
        this.l0 = l0;
    }
}

export function Mut4_$reflection(): TypeInfo {
    return record_type("Crypto.Mut4", [], Mut4, () => [["l0", string_type]]);
}

export class Mut5 extends Record implements IEquatable<Mut5>, IComparable<Mut5> {
    l0: US0_$union;
    constructor(l0: US0_$union) {
        super();
        this.l0 = l0;
    }
}

export function Mut5_$reflection(): TypeInfo {
    return record_type("Crypto.Mut5", [], Mut5, () => [["l0", US0_$reflection()]]);
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
    return union_type("Crypto.US1", [], US1, () => [[["f0_0", US0_$reflection()]], []]);
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
    return union_type("Crypto.US2", [], US2, () => [[["f0_0", int64_type]], []]);
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
    return union_type("Crypto.US3", [], US3, () => [[], [], []]);
}

export type US4_$union = 
    | US4<0>
    | US4<1>
    | US4<2>
    | US4<3>
    | US4<4>
    | US4<5>

export type US4_$cases = {
    0: ["US4_0", [US3_$union]],
    1: ["US4_1", [US3_$union]],
    2: ["US4_2", [US3_$union]],
    3: ["US4_3", [US3_$union]],
    4: ["US4_4", [US3_$union]],
    5: ["US4_5", [US3_$union]]
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

export class US4<Tag extends keyof US4_$cases> extends Union<Tag, US4_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US4_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US4_0", "US4_1", "US4_2", "US4_3", "US4_4", "US4_5"];
    }
}

export function US4_$reflection(): TypeInfo {
    return union_type("Crypto.US4", [], US4, () => [[["f0_0", US3_$reflection()]], [["f1_0", US3_$reflection()]], [["f2_0", US3_$reflection()]], [["f3_0", US3_$reflection()]], [["f4_0", US3_$reflection()]], [["f5_0", US3_$reflection()]]]);
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
    return union_type("Crypto.US5", [], US5, () => [[["f0_0", string_type]], []]);
}

export function method1(): string {
    return "";
}

export function method2(v0_1: string): string {
    return v0_1;
}

export function method3(v0_1: int32, v1_1: Mut0): boolean {
    return v1_1.l0 < v0_1;
}

export function method4(): string {
    return "";
}

export function method0(v0_1: string): string {
    const v154: ICryptoCreateHash = crypto;
    const v157: any = v154.createHash("sha256");
    const v159: any = v157.update(v0_1, 'utf8');
    return v159.digest("hex");
}

export function closure0(unitVar: void, v0_1: string): string {
    return method0(v0_1);
}

export function method9(v0_1: string): string {
    return v0_1;
}

export function method10(): string {
    return "";
}

export function closure4(unitVar: void, v0_1: string): US5_$union {
    return US5_US5_0(v0_1);
}

export function method11(): ((arg0: string) => US5_$union) {
    return (v: string): US5_$union => closure4(undefined, v);
}

export function method8(v0_1: string): string {
    return process.env[v0_1] ?? "";
}

export function method7(): [US1_$union, US2_$union] {
    let v13: US1_$union, v20: US1_$union, v27: US1_$union, v34: US1_$union;
    const v1_1: string = method8("TRACE_LEVEL");
    const v6: US1_$union = ("Verbose" === v1_1) ? US1_US1_0(US0_US0_0()) : US1_US1_1();
    return [((v6.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v6.fields[0] as any) : ((v13 = (("Debug" === v1_1) ? US1_US1_0(US0_US0_1()) : US1_US1_1()), ((v13.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v13.fields[0] as any) : ((v20 = (("Info" === v1_1) ? US1_US1_0(US0_US0_2()) : US1_US1_1()), ((v20.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v20.fields[0] as any) : ((v27 = (("Warning" === v1_1) ? US1_US1_0(US0_US0_3()) : US1_US1_1()), ((v27.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v27.fields[0] as any) : ((v34 = (("Critical" === v1_1) ? US1_US1_0(US0_US0_4()) : US1_US1_1()), ((v34.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v34.fields[0] as any) : US1_US1_1())))))))), (method8("AUTOMATION") !== "True") ? US2_US2_1() : US2_US2_0(toInt64(fromInt64(getTicks(now()))))] as [US1_$union, US2_$union];
}

export function closure5(unitVar: void, v0_1: string): void {
}

export function method6(v0_1: US0_$union): [Mut1, Mut2, Mut3, Mut4, Mut5, Option<int64>] {
    const patternInput: [US1_$union, US2_$union] = method7();
    const _run_target_args$0027_v3 = [patternInput[0], patternInput[1]] as [US1_$union, US2_$union];
    const v173: US2_$union = _run_target_args$0027_v3[1];
    const v172: US1_$union = _run_target_args$0027_v3[0];
    return [new Mut1(1n), new Mut2((v: string): void => {
        closure5(undefined, v);
    }), new Mut3(true), new Mut4(""), new Mut5(((v172.tag as int32) === /* US1_0 */ 0) ? (v172.fields[0] as any) : v0_1), ((v173.tag as int32) === /* US2_0 */ 0) ? (v173.fields[0] as any) : undefined] as [Mut1, Mut2, Mut3, Mut4, Mut5, Option<int64>];
}

export function closure3(unitVar: void, unitVar_1: void): void {
    if (TraceState_trace_state() == null) {
        const patternInput: [Mut1, Mut2, Mut3, Mut4, Mut5, Option<int64>] = method6(US0_US0_0());
        TraceState_trace_state([patternInput[0], patternInput[1], patternInput[2], patternInput[3], patternInput[4], patternInput[5]] as [Mut1, Mut2, Mut3, Mut4, Mut5, Option<int64>]);
    }
}

export function method5(v0_1: US0_$union): boolean {
    let v3: any;
    closure3(undefined, undefined);
    v3 = undefined;
    const patternInput: [Mut1, Mut2, Mut3, Mut4, Mut5, Option<int64>] = value_2(TraceState_trace_state());
    const v42: US0_$union = patternInput[4].l0;
    if (patternInput[2].l0 === false) {
        return false;
    }
    else {
        return find<US0_$union, int32>(v0_1, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
            Compare: compare,
        })) >= find<US0_$union, int32>(v42, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
            Compare: compare,
        }));
    }
}

export function closure6(unitVar: void, v0_1: int64): US2_$union {
    return US2_US2_0(v0_1);
}

export function method13(): ((arg0: int64) => US2_$union) {
    return (v: int64): US2_$union => closure6(undefined, v);
}

export function method14(): string {
    return "hh:mm:ss";
}

export function method15(): string {
    return "HH:mm:ss";
}

export function method12(v0_1: Mut1, v1_1: Mut2, v2: Mut3, v3: Mut4, v4: Mut5, v5: Option<int64>): string {
    const v551: US2_$union = defaultArg(map<int64, US2_$union>(method13(), v5), US2_US2_1());
    let v669: Date;
    if ((v551.tag as int32) === /* US2_0 */ 0) {
        const v555 = v551.fields[0] as any;
        const v621: number = fromTicks(toInt64(op_Subtraction(toInt64(fromInt64(getTicks(now()))), v555)));
        v669 = create(1, 1, 1, hours(v621), minutes(v621), seconds(v621), milliseconds(v621));
    }
    else {
        v669 = now();
    }
    const v671: string = method15();
    return toString(v669, (v671 === "") ? "M-d-y hh:mm:ss tt" : v671);
}

export function method18(): string {
    return "";
}

export function closure7(v0_1: Mut4, v1_1: string, unitVar: void): void {
    const v3: string = v0_1.l0 + v1_1;
    v0_1.l0 = v3;
}

export function method17(v0_1: string): string {
    const v2: Mut4 = new Mut4(method18());
    let v9: any;
    closure7(v2, `${v0_1}`, undefined);
    v9 = undefined;
    return v2.l0;
}

export function method19(): string {
    return "\u001b[0m";
}

export function method16(): string {
    const v3: string = "Verbose".toLocaleLowerCase();
    return ("\u001b[90m" + method17(v3[0])) + method19();
}

export function method21(v0_1: int32, v1_1: string, v2: uint16): string {
    const v4: Mut4 = new Mut4(method18());
    let v12: any;
    closure7(v4, "{ ", undefined);
    v12 = undefined;
    let v22: any;
    closure7(v4, "first_letter_code", undefined);
    v22 = undefined;
    let v32: any;
    closure7(v4, " = ", undefined);
    v32 = undefined;
    let v41: any;
    closure7(v4, `${v0_1}`, undefined);
    v41 = undefined;
    let v51: any;
    closure7(v4, "; ", undefined);
    v51 = undefined;
    let v61: any;
    closure7(v4, "hash_part", undefined);
    v61 = undefined;
    let v70: any;
    closure7(v4, " = ", undefined);
    v70 = undefined;
    let v79: any;
    closure7(v4, v1_1, undefined);
    v79 = undefined;
    let v88: any;
    closure7(v4, "; ", undefined);
    v88 = undefined;
    let v98: any;
    closure7(v4, "combined_value", undefined);
    v98 = undefined;
    let v107: any;
    closure7(v4, " = ", undefined);
    v107 = undefined;
    let v116: any;
    closure7(v4, `${v2}`, undefined);
    v116 = undefined;
    let v126: any;
    closure7(v4, " }", undefined);
    v126 = undefined;
    return v4.l0;
}

export function method22(v0_1: string): string {
    return trimEnd(trimStart(v0_1, ...[]), ...[" ", "/"]);
}

export function method20(v0_1: Mut1, v1_1: Mut2, v2: Mut3, v3: Mut4, v4: Mut5, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: string, v10: uint16): string {
    const v11: string = method21(v8, v9, v10);
    return method22(`${v6} ${v7} #${v0_1.l0} ${"crypto.hash_to_port"} / ${v11}`);
}

export function closure8(v0_1: Mut1, unitVar: void): void {
    const v2: int64 = toInt64(op_Addition(v0_1.l0, 1n));
    v0_1.l0 = v2;
}

export function closure10(v0_1: string, unitVar: void): void {
    console.log(v0_1);
}

export function closure9(unitVar: void, v0_1: string): void {
    let v3: any;
    closure10(v0_1, undefined);
    v3 = undefined;
}

export function method23(v0_1: string): void {
    let v3: any;
    closure3(undefined, undefined);
    v3 = undefined;
    const patternInput: [Mut1, Mut2, Mut3, Mut4, Mut5, Option<int64>] = value_2(TraceState_trace_state());
    let v44: any;
    closure8(patternInput[0], undefined);
    v44 = undefined;
    closure9(undefined, v0_1);
    patternInput[1].l0(v0_1);
}

export function closure2(v0_1: int32, v1_1: string, v2: uint16, unitVar: void): void {
    if (method5(US0_US0_0())) {
        let v7: any;
        closure3(undefined, undefined);
        v7 = undefined;
        const patternInput: [Mut1, Mut2, Mut3, Mut4, Mut5, Option<int64>] = value_2(TraceState_trace_state());
        const v33: Option<int64> = patternInput[5];
        const v32: Mut5 = patternInput[4];
        const v31: Mut4 = patternInput[3];
        const v30: Mut3 = patternInput[2];
        const v29: Mut2 = patternInput[1];
        const v28: Mut1 = patternInput[0];
        method23(method20(v28, v29, v30, v31, v32, v33, method12(v28, v29, v30, v31, v32, v33), method16(), v0_1, v1_1, v2));
    }
}

export function closure1(unitVar: void, v0_1: string): uint16 {
    let v96: int32;
    const value: string = v0_1[0];
    v96 = ~~value.charCodeAt(0);
    const v114: string = v0_1.slice(0, 7 + 1);
    let v124: uint16;
    const value_1: int32 = (parse(v114, 511, false, 32, 16) + v96) | 0;
    v124 = (value_1 & 0xFFFF);
    let v129: any;
    closure2(v96, v114, v124, undefined);
    v129 = undefined;
    return (v124 % 48128) + 1024;
}

export const v0 = (v: string): string => closure0(undefined, v);

export function hash_text(x: string): string {
    return v0(x);
}

export const v1 = (v: string): uint16 => closure1(undefined, v);

export function hash_to_port(x: string): uint16 {
    return v1(x);
}


