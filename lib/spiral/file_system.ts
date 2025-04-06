import { uncurry2, defaultOf, int64ToString, compare, IComparable, IEquatable, IDisposable, createAtom } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Util.js";
import { map, defaultArg, value as value_10, Option } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Option.js";
import { compare as compare_1, op_Modulus, equals, op_Addition, op_Subtraction, fromInt64, toInt64, int64 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/BigInt.js";
import { array_type, int32_type, bool_type, lambda_type, unit_type, string_type, record_type, int64_type, union_type, class_type, TypeInfo } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Reflection.js";
import { toString as toString_2, Record, Union } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Types.js";
import { uint8, int32 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Int32.js";
import { toString, create, now, getTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Date.js";
import * as fs from "fs";
import { ofSeq, find } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Map.js";
import { toString as toString_1, milliseconds, seconds, minutes, hours, fromTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/TimeSpan.js";
import * as path from "path";
import { replace, concat, interpolate, toText, trimStart, trimEnd } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/String.js";
import { Async, singleton } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/AsyncBuilder.js";
import { ignore, catchAsync, startChild, awaitTask, sleep } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Async.js";
import { FSharpChoice$2_$union } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Choice.js";
import { newGuid, parse } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Guid.js";
import { FSharpResult$2_Ok, FSharpResult$2_$union, FSharpResult$2_Error } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Result.js";

export interface IOsEnviron {
    environ(): any
}

export let TraceState_trace_state = createAtom<Option<[Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>]>>(undefined);

export interface IFsExistsSync {
    existsSync(path: string): boolean
}

export interface IPathBasename {
    basename(path: string): string
}

export interface IPathJoin {
    join(...paths: string[]): string
}

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
    return class_type("File_system.Disposable", undefined, Disposable);
}

export function Disposable_$ctor_3A5B6456(f: (() => void)): Disposable {
    return new Disposable(f);
}

export interface IPathDirname {
    dirname(path: string): string
}

export interface IFs {
    realpathSync(path: string): string
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
    return union_type("File_system.US0", [], US0, () => [[], [], [], [], []]);
}

export class Mut0 extends Record implements IEquatable<Mut0>, IComparable<Mut0> {
    l0: int64;
    constructor(l0: int64) {
        super();
        this.l0 = l0;
    }
}

export function Mut0_$reflection(): TypeInfo {
    return record_type("File_system.Mut0", [], Mut0, () => [["l0", int64_type]]);
}

export class Mut1 extends Record {
    l0: ((arg0: string) => void);
    constructor(l0: ((arg0: string) => void)) {
        super();
        this.l0 = l0;
    }
}

export function Mut1_$reflection(): TypeInfo {
    return record_type("File_system.Mut1", [], Mut1, () => [["l0", lambda_type(string_type, unit_type)]]);
}

export class Mut2 extends Record implements IEquatable<Mut2>, IComparable<Mut2> {
    l0: boolean;
    constructor(l0: boolean) {
        super();
        this.l0 = l0;
    }
}

export function Mut2_$reflection(): TypeInfo {
    return record_type("File_system.Mut2", [], Mut2, () => [["l0", bool_type]]);
}

export class Mut3 extends Record implements IEquatable<Mut3>, IComparable<Mut3> {
    l0: string;
    constructor(l0: string) {
        super();
        this.l0 = l0;
    }
}

export function Mut3_$reflection(): TypeInfo {
    return record_type("File_system.Mut3", [], Mut3, () => [["l0", string_type]]);
}

export class Mut4 extends Record implements IEquatable<Mut4>, IComparable<Mut4> {
    l0: US0_$union;
    constructor(l0: US0_$union) {
        super();
        this.l0 = l0;
    }
}

export function Mut4_$reflection(): TypeInfo {
    return record_type("File_system.Mut4", [], Mut4, () => [["l0", US0_$reflection()]]);
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
    return union_type("File_system.US1", [], US1, () => [[["f0_0", US0_$reflection()]], []]);
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
    return union_type("File_system.US2", [], US2, () => [[["f0_0", int64_type]], []]);
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
    return union_type("File_system.US3", [], US3, () => [[], [], []]);
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
    return union_type("File_system.US4", [], US4, () => [[["f0_0", US3_$reflection()]], [["f1_0", US3_$reflection()]], [["f2_0", US3_$reflection()]], [["f3_0", US3_$reflection()]], [["f4_0", US3_$reflection()]], [["f5_0", US3_$reflection()]], [["f6_0", US3_$reflection()]]]);
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
    return union_type("File_system.US5", [], US5, () => [[["f0_0", string_type]], []]);
}

export type US7_$union = 
    | US7<0>
    | US7<1>
    | US7<2>

export type US7_$cases = {
    0: ["US7_0", []],
    1: ["US7_1", []],
    2: ["US7_2", []]
}

export function US7_US7_0() {
    return new US7<0>(0, []);
}

export function US7_US7_1() {
    return new US7<1>(1, []);
}

export function US7_US7_2() {
    return new US7<2>(2, []);
}

export class US7<Tag extends keyof US7_$cases> extends Union<Tag, US7_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US7_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US7_0", "US7_1", "US7_2"];
    }
}

export function US7_$reflection(): TypeInfo {
    return union_type("File_system.US7", [], US7, () => [[], [], []]);
}

export type US8_$union = 
    | US8<0>
    | US8<1>
    | US8<2>
    | US8<3>
    | US8<4>

export type US8_$cases = {
    0: ["US8_0", []],
    1: ["US8_1", []],
    2: ["US8_2", []],
    3: ["US8_3", []],
    4: ["US8_4", []]
}

export function US8_US8_0() {
    return new US8<0>(0, []);
}

export function US8_US8_1() {
    return new US8<1>(1, []);
}

export function US8_US8_2() {
    return new US8<2>(2, []);
}

export function US8_US8_3() {
    return new US8<3>(3, []);
}

export function US8_US8_4() {
    return new US8<4>(4, []);
}

export class US8<Tag extends keyof US8_$cases> extends Union<Tag, US8_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US8_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US8_0", "US8_1", "US8_2", "US8_3", "US8_4"];
    }
}

export function US8_$reflection(): TypeInfo {
    return union_type("File_system.US8", [], US8, () => [[], [], [], [], []]);
}

export type US6_$union = 
    | US6<0>
    | US6<1>

export type US6_$cases = {
    0: ["US6_0", [US7_$union, US8_$union]],
    1: ["US6_1", []]
}

export function US6_US6_0(f0_0: US7_$union, f0_1: US8_$union) {
    return new US6<0>(0, [f0_0, f0_1]);
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
    return union_type("File_system.US6", [], US6, () => [[["f0_0", US7_$reflection()], ["f0_1", US8_$reflection()]], []]);
}

export type US9_$union = 
    | US9<0>
    | US9<1>

export type US9_$cases = {
    0: ["US9_0", []],
    1: ["US9_1", [string]]
}

export function US9_US9_0() {
    return new US9<0>(0, []);
}

export function US9_US9_1(f1_0: string) {
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
    return union_type("File_system.US9", [], US9, () => [[], [["f1_0", string_type]]]);
}

export type US10_$union = 
    | US10<0>
    | US10<1>

export type US10_$cases = {
    0: ["US10_0", [int64]],
    1: ["US10_1", [Error]]
}

export function US10_US10_0(f0_0: int64) {
    return new US10<0>(0, [f0_0]);
}

export function US10_US10_1(f1_0: Error) {
    return new US10<1>(1, [f1_0]);
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
    return union_type("File_system.US10", [], US10, () => [[["f0_0", int64_type]], [["f1_0", class_type("System.Exception")]]]);
}

export type US11_$union = 
    | US11<0>
    | US11<1>

export type US11_$cases = {
    0: ["US11_0", [int64]],
    1: ["US11_1", [Error]]
}

export function US11_US11_0(f0_0: int64) {
    return new US11<0>(0, [f0_0]);
}

export function US11_US11_1(f1_0: Error) {
    return new US11<1>(1, [f1_0]);
}

export class US11<Tag extends keyof US11_$cases> extends Union<Tag, US11_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US11_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US11_0", "US11_1"];
    }
}

export function US11_$reflection(): TypeInfo {
    return union_type("File_system.US11", [], US11, () => [[["f0_0", int64_type]], [["f1_0", class_type("System.Exception")]]]);
}

export type US12_$union = 
    | US12<0>
    | US12<1>

export type US12_$cases = {
    0: ["US12_0", [any]],
    1: ["US12_1", []]
}

export function US12_US12_0(f0_0: any) {
    return new US12<0>(0, [f0_0]);
}

export function US12_US12_1() {
    return new US12<1>(1, []);
}

export class US12<Tag extends keyof US12_$cases> extends Union<Tag, US12_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US12_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US12_0", "US12_1"];
    }
}

export function US12_$reflection(): TypeInfo {
    return union_type("File_system.US12", [], US12, () => [[["f0_0", string_type]], []]);
}

export type US13_$union = 
    | US13<0>
    | US13<1>

export type US13_$cases = {
    0: ["US13_0", []],
    1: ["US13_1", [any]]
}

export function US13_US13_0() {
    return new US13<0>(0, []);
}

export function US13_US13_1(f1_0: any) {
    return new US13<1>(1, [f1_0]);
}

export class US13<Tag extends keyof US13_$cases> extends Union<Tag, US13_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US13_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US13_0", "US13_1"];
    }
}

export function US13_$reflection(): TypeInfo {
    return union_type("File_system.US13", [], US13, () => [[], [["f1_0", string_type]]]);
}

export type US14_$union = 
    | US14<0>
    | US14<1>

export type US14_$cases = {
    0: ["US14_0", [any]],
    1: ["US14_1", [string]]
}

export function US14_US14_0(f0_0: any) {
    return new US14<0>(0, [f0_0]);
}

export function US14_US14_1(f1_0: string) {
    return new US14<1>(1, [f1_0]);
}

export class US14<Tag extends keyof US14_$cases> extends Union<Tag, US14_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US14_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US14_0", "US14_1"];
    }
}

export function US14_$reflection(): TypeInfo {
    return union_type("File_system.US14", [], US14, () => [[["f0_0", string_type]], [["f1_0", string_type]]]);
}

export type US15_$union = 
    | US15<0>
    | US15<1>

export type US15_$cases = {
    0: ["US15_0", [any]],
    1: ["US15_1", []]
}

export function US15_US15_0(f0_0: any) {
    return new US15<0>(0, [f0_0]);
}

export function US15_US15_1() {
    return new US15<1>(1, []);
}

export class US15<Tag extends keyof US15_$cases> extends Union<Tag, US15_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US15_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US15_0", "US15_1"];
    }
}

export function US15_$reflection(): TypeInfo {
    return union_type("File_system.US15", [], US15, () => [[["f0_0", string_type]], []]);
}

export class Mut5 extends Record implements IEquatable<Mut5>, IComparable<Mut5> {
    l0: int32;
    l1: int32;
    l2: string[];
    constructor(l0: int32, l1: int32, l2: string[]) {
        super();
        this.l0 = (l0 | 0);
        this.l1 = (l1 | 0);
        this.l2 = l2;
    }
}

export function Mut5_$reflection(): TypeInfo {
    return record_type("File_system.Mut5", [], Mut5, () => [["l0", int32_type], ["l1", int32_type], ["l2", array_type(string_type)]]);
}

export class Mut6 extends Record implements IEquatable<Mut6>, IComparable<Mut6> {
    l0: int32;
    constructor(l0: int32) {
        super();
        this.l0 = (l0 | 0);
    }
}

export function Mut6_$reflection(): TypeInfo {
    return record_type("File_system.Mut6", [], Mut6, () => [["l0", int32_type]]);
}

export type US16_$union = 
    | US16<0>
    | US16<1>

export type US16_$cases = {
    0: ["US16_0", []],
    1: ["US16_1", []]
}

export function US16_US16_0() {
    return new US16<0>(0, []);
}

export function US16_US16_1() {
    return new US16<1>(1, []);
}

export class US16<Tag extends keyof US16_$cases> extends Union<Tag, US16_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US16_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US16_0", "US16_1"];
    }
}

export function US16_$reflection(): TypeInfo {
    return union_type("File_system.US16", [], US16, () => [[], []]);
}

export type US17_$union = 
    | US17<0>
    | US17<1>

export type US17_$cases = {
    0: ["US17_0", [string]],
    1: ["US17_1", [string]]
}

export function US17_US17_0(f0_0: string) {
    return new US17<0>(0, [f0_0]);
}

export function US17_US17_1(f1_0: string) {
    return new US17<1>(1, [f1_0]);
}

export class US17<Tag extends keyof US17_$cases> extends Union<Tag, US17_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US17_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US17_0", "US17_1"];
    }
}

export function US17_$reflection(): TypeInfo {
    return union_type("File_system.US17", [], US17, () => [[["f0_0", string_type]], [["f1_0", string_type]]]);
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
    let v48_1: US1_$union, v55: US1_$union, v62: US1_$union, v69: US1_$union, v76: US1_$union, v83: US1_$union, v90: US1_$union, v97: US1_$union, v104: US1_$union;
    const v1: string = method2("TRACE_LEVEL");
    const v6: string = "Critical".toLocaleLowerCase();
    const v13: string = "Warning".toLocaleLowerCase();
    const v20: string = "Info".toLocaleLowerCase();
    const v27: string = "Debug".toLocaleLowerCase();
    const v34_1: string = "Verbose".toLocaleLowerCase();
    const v41_1: US1_$union = ("Verbose" === v1) ? US1_US1_0(US0_US0_0()) : US1_US1_1();
    return [((v41_1.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v41_1.fields[0] as any) : ((v48_1 = (("Debug" === v1) ? US1_US1_0(US0_US0_1()) : US1_US1_1()), ((v48_1.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v48_1.fields[0] as any) : ((v55 = (("Info" === v1) ? US1_US1_0(US0_US0_2()) : US1_US1_1()), ((v55.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v55.fields[0] as any) : ((v62 = (("Warning" === v1) ? US1_US1_0(US0_US0_3()) : US1_US1_1()), ((v62.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v62.fields[0] as any) : ((v69 = (("Critical" === v1) ? US1_US1_0(US0_US0_4()) : US1_US1_1()), ((v69.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v69.fields[0] as any) : ((v76 = ((v34_1 === v1) ? US1_US1_0(US0_US0_0()) : US1_US1_1()), ((v76.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v76.fields[0] as any) : ((v83 = ((v27 === v1) ? US1_US1_0(US0_US0_1()) : US1_US1_1()), ((v83.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v83.fields[0] as any) : ((v90 = ((v20 === v1) ? US1_US1_0(US0_US0_2()) : US1_US1_1()), ((v90.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v90.fields[0] as any) : ((v97 = ((v13 === v1) ? US1_US1_0(US0_US0_3()) : US1_US1_1()), ((v97.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v97.fields[0] as any) : ((v104 = ((v6 === v1) ? US1_US1_0(US0_US0_4()) : US1_US1_1()), ((v104.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v104.fields[0] as any) : US1_US1_1())))))))))))))))))), (method2("AUTOMATION") !== "True") ? US2_US2_1() : US2_US2_0(toInt64(fromInt64(getTicks(now()))))] as [US1_$union, US2_$union];
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

export function method10(v0: string): boolean {
    const v128: IFsExistsSync = fs;
    return v128.existsSync(v0);
}

export function method9(v0: boolean, v1: string): void {
}

export function method11(v0: US0_$union): boolean {
    let v17: any;
    closure0(undefined, undefined);
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v56: US0_$union = patternInput[4].l0;
    if (patternInput[2].l0 === false) {
        return false;
    }
    else {
        return find<US0_$union, int32>(v0, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
            Compare: compare,
        })) >= find<US0_$union, int32>(v56, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
            Compare: compare,
        }));
    }
}

export function closure5(unitVar: void, v0: int64): US2_$union {
    return US2_US2_0(v0);
}

export function method13(): ((arg0: int64) => US2_$union) {
    return (v: int64): US2_$union => closure5(undefined, v);
}

export function method14(): string {
    return "hh:mm:ss";
}

export function method15(): string {
    return "HH:mm:ss";
}

export function method12(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>): string {
    const v641: US2_$union = defaultArg(map<int64, US2_$union>(method13(), v5), US2_US2_1());
    let v781: Date;
    if ((v641.tag as int32) === /* US2_0 */ 0) {
        const v645 = v641.fields[0] as any;
        const v724: number = fromTicks(toInt64(op_Subtraction(toInt64(fromInt64(getTicks(now()))), v645)));
        v781 = create(1, 1, 1, hours(v724), minutes(v724), seconds(v724), milliseconds(v724));
    }
    else {
        v781 = now();
    }
    const v782: string = method15();
    return toString(v781, (v782 === "") ? "M-d-y hh:mm:ss tt" : v782);
}

export function method17(): string {
    return "";
}

export function closure6(v0: Mut3, v1: string, unitVar: void): void {
    const v4: string = v0.l0 + v1;
    v0.l0 = v4;
}

export function method18(): string {
    return "\u001b[0m";
}

export function method16(): string {
    const v4: string = "Debug".toLocaleLowerCase();
    const v7: string = v4[0];
    const v9: Mut3 = new Mut3(method17());
    let v24: any;
    closure6(v9, `${v7}`, undefined);
    v24 = undefined;
    return ("\u001b[94m" + v9.l0) + method18();
}

export function method19(v0: string): string {
    const v209: IPathBasename = path;
    return v209.basename(v0);
}

export function method21(v0: string): string {
    return trimEnd(trimStart(v0, ...[]), ...[" ", "/"]);
}

export function method20(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: string): string {
    const v11: Mut3 = new Mut3(method17());
    let v25: any;
    closure6(v11, "{ ", undefined);
    v25 = undefined;
    let v44_1: any;
    closure6(v11, "ex", undefined);
    v44_1 = undefined;
    let v63: any;
    closure6(v11, " = ", undefined);
    v63 = undefined;
    let v80: any;
    closure6(v11, v8, undefined);
    v80 = undefined;
    let v99: any;
    closure6(v11, "; ", undefined);
    v99 = undefined;
    let v118: any;
    closure6(v11, "path", undefined);
    v118 = undefined;
    let v135: any;
    closure6(v11, " = ", undefined);
    v135 = undefined;
    let v152: any;
    closure6(v11, v9, undefined);
    v152 = undefined;
    let v171: any;
    closure6(v11, " }", undefined);
    v171 = undefined;
    const v177: string = v11.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.delete_directory_async") + " / ") + v177);
}

export function closure7(v0: Mut0, unitVar: void): void {
    const v2: int64 = toInt64(op_Addition(v0.l0, 1n));
    v0.l0 = v2;
}

export function closure9(v0: string, unitVar: void): void {
    console.log(v0);
}

export function closure8(unitVar: void, v0: string): void {
    let v4: any;
    closure9(v0, undefined);
    v4 = undefined;
}

export function method22(v0: string): void {
    let v17: any;
    closure0(undefined, undefined);
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    let v60: any;
    closure7(patternInput[0], undefined);
    v60 = undefined;
    closure8(undefined, v0);
    patternInput[1].l0(v0);
}

export function closure4(v0: string, v1: Error, unitVar: void): void {
    if (method11(US0_US0_1())) {
        let v20: any;
        closure0(undefined, undefined);
        v20 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v46_1: Option<int64> = patternInput[5];
        const v45_1: Mut4 = patternInput[4];
        const v44_1: Mut3 = patternInput[3];
        const v43_1: Mut2 = patternInput[2];
        const v42_1: Mut1 = patternInput[1];
        const v41_1: Mut0 = patternInput[0];
        method22(method20(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method16(), toText(interpolate("%A%P()", [v1])), method19(v0)));
    }
}

export function method8(v0: string, v1: int64): Async<int64> {
    return singleton.Delay<int64>((): Async<int64> => singleton.TryWith<int64>(singleton.Delay<int64>((): Async<int64> => {
        method9(true, v0);
        return singleton.Return<int64>(v1);
    }), (_arg: Error): Async<int64> => {
        let v9542: any;
        const v9439: boolean = equals(toInt64(op_Modulus(v1, 100n)), 0n);
        return singleton.Combine<int64>(v9439 ? ((v9542 = ((closure4(v0, _arg, undefined), undefined)), singleton.Zero())) : singleton.Zero(), singleton.Delay<int64>((): Async<int64> => {
            const v9655: Async<void> = sleep(10);
            return singleton.Bind<void, int64>(v9655, (): Async<int64> => {
                const v9669: Async<int64> = method7(v0, toInt64(op_Addition(v1, 1n)));
                return singleton.ReturnFrom<int64>(v9669);
            });
        }));
    }));
}

export function method7(v0: string, v1: int64): Async<int64> {
    return defaultOf();
}

export function method6(v0: string): Async<int64> {
    return method7(v0, 0n);
}

export function closure3(unitVar: void, v0: string): Async<int64> {
    return method6(v0);
}

export function method26(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: int64, v10: string): string {
    const v12: Mut3 = new Mut3(method17());
    let v26: any;
    closure6(v12, "{ ", undefined);
    v26 = undefined;
    let v45_1: any;
    closure6(v12, "path", undefined);
    v45_1 = undefined;
    let v64: any;
    closure6(v12, " = ", undefined);
    v64 = undefined;
    let v81: any;
    closure6(v12, v8, undefined);
    v81 = undefined;
    let v100: any;
    closure6(v12, "; ", undefined);
    v100 = undefined;
    let v119: any;
    closure6(v12, "retry", undefined);
    v119 = undefined;
    let v136: any;
    closure6(v12, " = ", undefined);
    v136 = undefined;
    let v156: any;
    closure6(v12, `${v9}`, undefined);
    v156 = undefined;
    let v173: any;
    closure6(v12, "; ", undefined);
    v173 = undefined;
    let v192: any;
    closure6(v12, "ex", undefined);
    v192 = undefined;
    let v209: any;
    closure6(v12, " = ", undefined);
    v209 = undefined;
    let v226: any;
    closure6(v12, v10, undefined);
    v226 = undefined;
    let v245: any;
    closure6(v12, " }", undefined);
    v245 = undefined;
    const v251: string = v12.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.wait_for_file_access") + " / ") + v251);
}

export function closure12(v0: string, v1: int64, v2: Error, unitVar: void): void {
    if (method11(US0_US0_1())) {
        let v21: any;
        closure0(undefined, undefined);
        v21 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v47_1: Option<int64> = patternInput[5];
        const v46_1: Mut4 = patternInput[4];
        const v45_1: Mut3 = patternInput[3];
        const v44_1: Mut2 = patternInput[2];
        const v43_1: Mut1 = patternInput[1];
        const v42_1: Mut0 = patternInput[0];
        method22(method26(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1, method12(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1), method16(), method19(v0), v1, toText(interpolate("%A%P()", [v2]))));
    }
}

export function method25(v0: US6_$union, v1: string, v2: int64, v3: US8_$union, v4: US7_$union): Async<int64> {
    return singleton.Delay<int64>((): Async<int64> => singleton.TryWith<int64>(singleton.Delay<int64>((): Async<int64> => {
        const v11541: any = defaultOf();
        return singleton.Using<any, int64>(v11541, (_arg: any): Async<int64> => singleton.Return<int64>(v2));
    }), (_arg_1: Error): Async<int64> => {
        let v11979: any;
        const v11876: boolean = (compare_1(v2, 0n) > 0) && equals(toInt64(op_Modulus(v2, 100n)), 0n);
        return singleton.Combine<int64>(v11876 ? ((v11979 = ((closure12(v1, v2, _arg_1, undefined), undefined)), singleton.Zero())) : singleton.Zero(), singleton.Delay<int64>((): Async<int64> => {
            const v12092: Async<void> = sleep(10);
            return singleton.Bind<void, int64>(v12092, (): Async<int64> => {
                const v12106: Async<int64> = method24(v0, v1, toInt64(op_Addition(v2, 1n)));
                return singleton.ReturnFrom<int64>(v12106);
            });
        }));
    }));
}

export function method24(v0: US6_$union, v1: string, v2: int64): Async<int64> {
    return defaultOf();
}

export function method23(v0: US6_$union, v1: string): Async<int64> {
    return method24(v0, v1, 0n);
}

export function closure11(v0: US6_$union, v1: string): Async<int64> {
    return method23(v0, v1);
}

export function closure10(unitVar: void, v0: US6_$union): ((arg0: string) => Async<int64>) {
    return (v: string): Async<int64> => closure11(v0, v);
}

export function method27(v0: string): Async<int64> {
    return method23(US6_US6_0(US7_US7_0(), US8_US8_1()), v0);
}

export function closure13(unitVar: void, v0: string): Async<int64> {
    return method27(v0);
}

export function method31(): string {
    const v4: string = "Verbose".toLocaleLowerCase();
    const v7: string = v4[0];
    const v9: Mut3 = new Mut3(method17());
    let v24: any;
    closure6(v9, `${v7}`, undefined);
    v24 = undefined;
    return ("\u001b[90m" + v9.l0) + method18();
}

export function method32(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int64, v9: string, v10: Error): string {
    const v12: Mut3 = new Mut3(method17());
    let v26: any;
    closure6(v12, "{ ", undefined);
    v26 = undefined;
    let v45_1: any;
    closure6(v12, "retry", undefined);
    v45_1 = undefined;
    let v64: any;
    closure6(v12, " = ", undefined);
    v64 = undefined;
    let v84: any;
    closure6(v12, `${v8}`, undefined);
    v84 = undefined;
    let v103: any;
    closure6(v12, "; ", undefined);
    v103 = undefined;
    let v122: any;
    closure6(v12, "path", undefined);
    v122 = undefined;
    let v139: any;
    closure6(v12, " = ", undefined);
    v139 = undefined;
    let v156: any;
    closure6(v12, v9, undefined);
    v156 = undefined;
    let v173: any;
    closure6(v12, "; ", undefined);
    v173 = undefined;
    let v192: any;
    closure6(v12, "ex", undefined);
    v192 = undefined;
    let v209: any;
    closure6(v12, " = ", undefined);
    v209 = undefined;
    let v268: any;
    closure6(v12, toText(interpolate("%A%P()", [v10])), undefined);
    v268 = undefined;
    let v287: any;
    closure6(v12, " }", undefined);
    v287 = undefined;
    const v293: string = v12.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.read_all_text_async") + " / ") + v293);
}

export function closure15(v0: string, v1: int64, v2: Error, unitVar: void): void {
    if (method11(US0_US0_0())) {
        let v21: any;
        closure0(undefined, undefined);
        v21 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v47_1: Option<int64> = patternInput[5];
        const v46_1: Mut4 = patternInput[4];
        const v45_1: Mut3 = patternInput[3];
        const v44_1: Mut2 = patternInput[2];
        const v43_1: Mut1 = patternInput[1];
        const v42_1: Mut0 = patternInput[0];
        method22(method32(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1, method12(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1), method31(), v1, v0, v2));
    }
}

export function method30(v0: string, v1: int64): Async<string> {
    return singleton.Delay<string>((): Async<string> => singleton.TryWith<string>(singleton.Delay<string>((): Async<string> => {
        const v9138: Async<string> = awaitTask<string>(defaultOf());
        return singleton.ReturnFrom<string>(v9138);
    }), (_arg: Error): Async<string> => {
        let v9446: any;
        closure15(v0, v1, _arg, undefined);
        v9446 = undefined;
        const v9519: Async<void> = sleep(10);
        return singleton.Bind<void, string>(v9519, (): Async<string> => {
            let v9537: Async<string>;
            if (compare_1(v1, 3n) < 0) {
                v9537 = method29(v0, toInt64(op_Addition(v1, 1n)));
            }
            else {
                throw new Error(`file_system.read_all_text_async / retry: ${v1} / path: ${v0}`);
            }
            return singleton.ReturnFrom<string>(v9537);
        });
    }));
}

export function method29(v0: string, v1: int64): Async<string> {
    return method30(v0, v1);
}

export function method28(v0: string): Async<string> {
    return method29(v0, 0n);
}

export function closure14(unitVar: void, v0: string): Async<string> {
    return method28(v0);
}

export function method34(v0: string): boolean {
    const v128: IFsExistsSync = fs;
    return v128.existsSync(v0);
}

export function method35(v0: any): any {
    return v0;
}

export function method33(v0: string, v1: string): boolean {
    return defaultOf();
}

export function closure17(v0: string, v1: string): boolean {
    return method33(v0, v1);
}

export function closure16(unitVar: void, v0: string): ((arg0: string) => boolean) {
    return (v: string): boolean => closure17(v0, v);
}

export function method36(v0: string, v1: string): Async<void> {
    return defaultOf();
}

export function closure19(v0: string, v1: string): Async<void> {
    return method36(v0, v1);
}

export function closure18(unitVar: void, v0: string): ((arg0: string) => Async<void>) {
    return (v: string): Async<void> => closure19(v0, v);
}

export function method40(v0: string, v1: string): Async<boolean> {
    return singleton.Delay<boolean>((): Async<boolean> => {
        if (method34(v0) === false) {
            return singleton.Return<boolean>(false);
        }
        else {
            const v90: Async<string> = method28(v0);
            return singleton.Bind<string, boolean>(v90, (_arg: string): Async<boolean> => {
                const v92: boolean = v1 === _arg;
                return singleton.Return<boolean>(v92);
            });
        }
    });
}

export function method39(v0: string, v1: string): Async<boolean> {
    return defaultOf();
}

export function method38(v0: string, v1: string): Async<void> {
    return singleton.Delay<void>((): Async<void> => {
        const v75: Async<boolean> = method39(v0, v1);
        return singleton.Bind<boolean, void>(v75, (_arg: boolean): Async<void> => {
            let v78: Async<void>;
            const v77: boolean = _arg === false;
            return singleton.Combine<void>(v77 ? ((v78 = method36(v0, v1), singleton.Bind<void, void>(v78, (): Async<void> => {
                return singleton.Zero();
            }))) : singleton.Zero(), singleton.Delay<void>((): Async<void> => {
                return singleton.Zero();
            }));
        });
    });
}

export function method37(v0: string, v1: string): Async<void> {
    return method38(v0, v1);
}

export function closure21(v0: string, v1: string): Async<void> {
    return method37(v0, v1);
}

export function closure20(unitVar: void, v0: string): ((arg0: string) => Async<void>) {
    return (v: string): Async<void> => closure21(v0, v);
}

export function closure23(unitVar: void, v0: any): string {
    const v2: Mut3 = new Mut3(method17());
    let v56: any;
    closure6(v2, toText(interpolate("%A%P()", [v0])), undefined);
    v56 = undefined;
    return v2.l0;
}

export function method44(): ((arg0: any) => string) {
    return (v: any): string => closure23(undefined, v);
}

export function closure24(unitVar: void, unitVar_1: void): US9_$union {
    return US9_US9_0();
}

export function method45(): (() => US9_$union) {
    return (): US9_$union => closure24(undefined, undefined);
}

export function closure25(unitVar: void, v0: string): US9_$union {
    return US9_US9_1(v0);
}

export function method46(): ((arg0: string) => US9_$union) {
    return (v: string): US9_$union => closure25(undefined, v);
}

export function method47(): string {
    const v4: string = "Critical".toLocaleLowerCase();
    const v7: string = v4[0];
    const v9: Mut3 = new Mut3(method17());
    let v24: any;
    closure6(v9, `${v7}`, undefined);
    v24 = undefined;
    return ("\u001b[91m" + v9.l0) + method18();
}

export function method48(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string): string {
    const v10: Mut3 = new Mut3(method17());
    let v24: any;
    closure6(v10, "{ ", undefined);
    v24 = undefined;
    let v43_1: any;
    closure6(v10, "error\'", undefined);
    v43_1 = undefined;
    let v62: any;
    closure6(v10, " = ", undefined);
    v62 = undefined;
    let v79: any;
    closure6(v10, v8, undefined);
    v79 = undefined;
    let v98: any;
    closure6(v10, " }", undefined);
    v98 = undefined;
    const v104: string = v10.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.file_delete") + " / ") + v104);
}

export function closure26(v0: string, unitVar: void): void {
    if (method11(US0_US0_4())) {
        let v19: any;
        closure0(undefined, undefined);
        v19 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v45_1: Option<int64> = patternInput[5];
        const v44_1: Mut4 = patternInput[4];
        const v43_1: Mut3 = patternInput[3];
        const v42_1: Mut2 = patternInput[2];
        const v41_1: Mut1 = patternInput[1];
        const v40_1: Mut0 = patternInput[0];
        method22(method48(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1, method12(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1), method47(), v0));
    }
}

export function method49(): string {
    const v4: string = "Warning".toLocaleLowerCase();
    const v7: string = v4[0];
    const v9: Mut3 = new Mut3(method17());
    let v24: any;
    closure6(v9, `${v7}`, undefined);
    v24 = undefined;
    return ("\u001b[93m" + v9.l0) + method18();
}

export function method50(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: string): string {
    const v11: Mut3 = new Mut3(method17());
    let v25: any;
    closure6(v11, "{ ", undefined);
    v25 = undefined;
    let v44_1: any;
    closure6(v11, "path", undefined);
    v44_1 = undefined;
    let v63: any;
    closure6(v11, " = ", undefined);
    v63 = undefined;
    let v80: any;
    closure6(v11, v8, undefined);
    v80 = undefined;
    let v99: any;
    closure6(v11, "; ", undefined);
    v99 = undefined;
    let v118: any;
    closure6(v11, "ex", undefined);
    v118 = undefined;
    let v135: any;
    closure6(v11, " = ", undefined);
    v135 = undefined;
    let v152: any;
    closure6(v11, v9, undefined);
    v152 = undefined;
    let v171: any;
    closure6(v11, " }", undefined);
    v171 = undefined;
    const v177: string = v11.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "delete_file_async") + " / ") + v177);
}

export function closure27(v0: string, v1: Error, unitVar: void): void {
    if (method11(US0_US0_3())) {
        let v20: any;
        closure0(undefined, undefined);
        v20 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v46_1: Option<int64> = patternInput[5];
        const v45_1: Mut4 = patternInput[4];
        const v44_1: Mut3 = patternInput[3];
        const v43_1: Mut2 = patternInput[2];
        const v42_1: Mut1 = patternInput[1];
        const v41_1: Mut0 = patternInput[0];
        method22(method50(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method49(), method19(v0), toText(interpolate("%A%P()", [v1]))));
    }
}

export function method43(v0: string, v1: int64): Async<int64> {
    return singleton.Delay<int64>((): Async<int64> => singleton.TryWith<int64>(singleton.Delay<int64>((): Async<int64> => singleton.Return<int64>(v1)), (_arg: Error): Async<int64> => {
        let v15800: any;
        const v15697: boolean = equals(toInt64(op_Modulus(v1, 100n)), 0n);
        return singleton.Combine<int64>(v15697 ? ((v15800 = ((closure27(v0, _arg, undefined), undefined)), singleton.Zero())) : singleton.Zero(), singleton.Delay<int64>((): Async<int64> => {
            const v15913: Async<void> = sleep(10);
            return singleton.Bind<void, int64>(v15913, (): Async<int64> => {
                const v15927: Async<int64> = method42(v0, toInt64(op_Addition(v1, 1n)));
                return singleton.ReturnFrom<int64>(v15927);
            });
        }));
    }));
}

export function method42(v0: string, v1: int64): Async<int64> {
    return defaultOf();
}

export function method41(v0: string): Async<int64> {
    return method42(v0, 0n);
}

export function closure22(unitVar: void, v0: string): Async<int64> {
    return method41(v0);
}

export function method54(v0: string, v1: string): void {
}

export function method55(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: string, v10: string): string {
    const v12: Mut3 = new Mut3(method17());
    let v26: any;
    closure6(v12, "{ ", undefined);
    v26 = undefined;
    let v45_1: any;
    closure6(v12, "old_path", undefined);
    v45_1 = undefined;
    let v64: any;
    closure6(v12, " = ", undefined);
    v64 = undefined;
    let v81: any;
    closure6(v12, v8, undefined);
    v81 = undefined;
    let v100: any;
    closure6(v12, "; ", undefined);
    v100 = undefined;
    let v119: any;
    closure6(v12, "new_path", undefined);
    v119 = undefined;
    let v136: any;
    closure6(v12, " = ", undefined);
    v136 = undefined;
    let v153: any;
    closure6(v12, v9, undefined);
    v153 = undefined;
    let v170: any;
    closure6(v12, "; ", undefined);
    v170 = undefined;
    let v189: any;
    closure6(v12, "ex", undefined);
    v189 = undefined;
    let v206: any;
    closure6(v12, " = ", undefined);
    v206 = undefined;
    let v223: any;
    closure6(v12, v10, undefined);
    v223 = undefined;
    let v242: any;
    closure6(v12, " }", undefined);
    v242 = undefined;
    const v248: string = v12.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "move_file_async") + " / ") + v248);
}

export function closure30(v0: string, v1: string, v2: Error, unitVar: void): void {
    if (method11(US0_US0_3())) {
        let v21: any;
        closure0(undefined, undefined);
        v21 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v47_1: Option<int64> = patternInput[5];
        const v46_1: Mut4 = patternInput[4];
        const v45_1: Mut3 = patternInput[3];
        const v44_1: Mut2 = patternInput[2];
        const v43_1: Mut1 = patternInput[1];
        const v42_1: Mut0 = patternInput[0];
        method22(method55(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1, method12(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1), method49(), method19(v1), method19(v0), toText(interpolate("%A%P()", [v2]))));
    }
}

export function method53(v0: string, v1: string, v2: int64): Async<int64> {
    return singleton.Delay<int64>((): Async<int64> => singleton.TryWith<int64>(singleton.Delay<int64>((): Async<int64> => {
        method54(v0, v1);
        return singleton.Return<int64>(v2);
    }), (_arg: Error): Async<int64> => {
        let v9530: any;
        const v9426: boolean = equals(toInt64(op_Modulus(v2, 100n)), 0n);
        return singleton.Combine<int64>(v9426 ? ((v9530 = ((closure30(v0, v1, _arg, undefined), undefined)), singleton.Zero())) : singleton.Zero(), singleton.Delay<int64>((): Async<int64> => {
            const v9644: Async<void> = sleep(10);
            return singleton.Bind<void, int64>(v9644, (): Async<int64> => {
                const v9658: Async<int64> = method52(v0, v1, toInt64(op_Addition(v2, 1n)));
                return singleton.ReturnFrom<int64>(v9658);
            });
        }));
    }));
}

export function method52(v0: string, v1: string, v2: int64): Async<int64> {
    return defaultOf();
}

export function method51(v0: string, v1: string): Async<int64> {
    return method52(v0, v1, 0n);
}

export function closure29(v0: string, v1: string): Async<int64> {
    return method51(v0, v1);
}

export function closure28(unitVar: void, v0: string): ((arg0: string) => Async<int64>) {
    return (v: string): Async<int64> => closure29(v0, v);
}

export function closure32(unitVar: void, v0: int64): US10_$union {
    return US10_US10_0(v0);
}

export function method62(): ((arg0: int64) => US10_$union) {
    return (v: int64): US10_$union => closure32(undefined, v);
}

export function closure33(unitVar: void, v0: Error): US10_$union {
    return US10_US10_1(v0);
}

export function method63(): ((arg0: Error) => US10_$union) {
    return (v: Error): US10_$union => closure33(undefined, v);
}

export function method61(v0: Async<FSharpChoice$2_$union<int64, Error>>): Async<US10_$union> {
    return singleton.Delay<US10_$union>((): Async<US10_$union> => singleton.Bind<FSharpChoice$2_$union<int64, Error>, US10_$union>(v0, (_arg: FSharpChoice$2_$union<int64, Error>): Async<US10_$union> => {
        const v574: US10_$union = defaultOf();
        return singleton.Return<US10_$union>(v574);
    }));
}

export function method64(v0: Async<US10_$union>): Async<US11_$union> {
    return singleton.Delay<US11_$union>((): Async<US11_$union> => singleton.Bind<US10_$union, US11_$union>(v0, (_arg: US10_$union): Async<US11_$union> => {
        const v113: US10_$union = _arg;
        const v119: US11_$union = ((v113.tag as int32) === /* US10_1 */ 1) ? US11_US11_1(v113.fields[0] as any) : US11_US11_0(v113.fields[0] as any);
        return singleton.Return<US11_$union>(v119);
    }));
}

export function method66(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32): string {
    const v10: Mut3 = new Mut3(method17());
    let v24: any;
    closure6(v10, "{ ", undefined);
    v24 = undefined;
    let v43_1: any;
    closure6(v10, "timeout", undefined);
    v43_1 = undefined;
    let v62: any;
    closure6(v10, " = ", undefined);
    v62 = undefined;
    let v82: any;
    closure6(v10, `${v8}`, undefined);
    v82 = undefined;
    let v101: any;
    closure6(v10, " }", undefined);
    v101 = undefined;
    const v107: string = v10.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "async.run_with_timeout_async") + " / ") + v107);
}

export function closure34(v0: int32, unitVar: void): void {
    if (method11(US0_US0_0())) {
        let v19: any;
        closure0(undefined, undefined);
        v19 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v45_1: Option<int64> = patternInput[5];
        const v44_1: Mut4 = patternInput[4];
        const v43_1: Mut3 = patternInput[3];
        const v42_1: Mut2 = patternInput[2];
        const v41_1: Mut1 = patternInput[1];
        const v40_1: Mut0 = patternInput[0];
        method22(method66(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1, method12(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1), method31(), v0));
    }
}

export function method67(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: string): string {
    const v11: Mut3 = new Mut3(method17());
    let v25: any;
    closure6(v11, "{ ", undefined);
    v25 = undefined;
    let v44_1: any;
    closure6(v11, "timeout", undefined);
    v44_1 = undefined;
    let v63: any;
    closure6(v11, " = ", undefined);
    v63 = undefined;
    let v83: any;
    closure6(v11, `${v8}`, undefined);
    v83 = undefined;
    let v102: any;
    closure6(v11, "; ", undefined);
    v102 = undefined;
    let v121: any;
    closure6(v11, "ex", undefined);
    v121 = undefined;
    let v138: any;
    closure6(v11, " = ", undefined);
    v138 = undefined;
    let v155: any;
    closure6(v11, v9, undefined);
    v155 = undefined;
    let v174: any;
    closure6(v11, " }", undefined);
    v174 = undefined;
    const v180: string = v11.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "async.run_with_timeout_async**") + " / ") + v180);
}

export function closure35(v0: int32, v1: Error, unitVar: void): void {
    if (method11(US0_US0_4())) {
        let v20: any;
        closure0(undefined, undefined);
        v20 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v46_1: Option<int64> = patternInput[5];
        const v45_1: Mut4 = patternInput[4];
        const v44_1: Mut3 = patternInput[3];
        const v43_1: Mut2 = patternInput[2];
        const v42_1: Mut1 = patternInput[1];
        const v41_1: Mut0 = patternInput[0];
        method22(method67(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method47(), v0, toText(interpolate("%A%P()", [v1]))));
    }
}

export function method65(v0: int32, v1: Async<US11_$union>): Async<US2_$union> {
    return singleton.Delay<US2_$union>((): Async<US2_$union> => singleton.Bind<US11_$union, US2_$union>(v1, (_arg: US11_$union): Async<US2_$union> => {
        const v4481: US11_$union = _arg;
        let v4823: US2_$union;
        if ((v4481.tag as int32) === /* US11_0 */ 0) {
            v4823 = US2_US2_0(v4481.fields[0] as any);
        }
        else {
            const v4484 = v4481.fields[0] as any;
            const v4486: string = toText(interpolate("%A%P()", [v4484]));
            if (v4486.indexOf("System.TimeoutException") >= 0) {
                let v4557: any;
                closure34(v0, undefined);
                v4557 = undefined;
                v4823 = US2_US2_1();
            }
            else {
                let v4720: any;
                closure35(v0, v4484, undefined);
                v4720 = undefined;
                v4823 = US2_US2_1();
            }
        }
        return singleton.Return<US2_$union>(v4823);
    }));
}

export function method60(v0: Async<int64>, v1: int32): Async<US2_$union> {
    return singleton.Delay<US2_$union>((): Async<US2_$union> => {
        const v924: Async<Async<int64>> = startChild<int64>(v0, v1);
        return singleton.Bind<Async<int64>, US2_$union>(v924, (_arg: Async<int64>): Async<US2_$union> => {
            const v974: Async<US2_$union> = method65(v1, method64(method61(catchAsync<int64>(_arg))));
            return singleton.ReturnFrom<US2_$union>(v974);
        });
    });
}

export function method59(v0: int32, v1: Async<int64>): Async<US2_$union> {
    return method60(v1, v0);
}

export function method68(v0: Async<string>): Async<Option<string>> {
    return singleton.Delay<Option<string>>((): Async<Option<string>> => singleton.Bind<string, Option<string>>(v0, (_arg: string): Async<Option<string>> => singleton.Return<Option<string>>(_arg)));
}

export function method69(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int64, v9: string): string {
    const v11: Mut3 = new Mut3(method17());
    let v25: any;
    closure6(v11, "{ ", undefined);
    v25 = undefined;
    let v44_1: any;
    closure6(v11, "retry", undefined);
    v44_1 = undefined;
    let v63: any;
    closure6(v11, " = ", undefined);
    v63 = undefined;
    let v83: any;
    closure6(v11, `${v8}`, undefined);
    v83 = undefined;
    let v102: any;
    closure6(v11, "; ", undefined);
    v102 = undefined;
    let v121: any;
    closure6(v11, "ex", undefined);
    v121 = undefined;
    let v138: any;
    closure6(v11, " = ", undefined);
    v138 = undefined;
    let v155: any;
    closure6(v11, v9, undefined);
    v155 = undefined;
    let v174: any;
    closure6(v11, " }", undefined);
    v174 = undefined;
    const v180: string = v11.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.read_all_text_retry_async") + " / ") + v180);
}

export function closure36(v0: int64, v1: Error, unitVar: void): void {
    if (method11(US0_US0_1())) {
        let v20: any;
        closure0(undefined, undefined);
        v20 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v46_1: Option<int64> = patternInput[5];
        const v45_1: Mut4 = patternInput[4];
        const v44_1: Mut3 = patternInput[3];
        const v43_1: Mut2 = patternInput[2];
        const v42_1: Mut1 = patternInput[1];
        const v41_1: Mut0 = patternInput[0];
        method22(method69(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method16(), v0, toText(interpolate("%A%P()", [v1]))));
    }
}

export function method58(v0: string, v1: int64): Async<Option<string>> {
    return singleton.Delay<Option<string>>((): Async<Option<string>> => singleton.TryWith<Option<string>>(singleton.Delay<Option<string>>((): Async<Option<string>> => {
        let v9887: Async<void>;
        const v9865: boolean = compare_1(v1, 0n) > 0;
        return singleton.Combine<Option<string>>(v9865 ? ((v9887 = ignore<US2_$union>(method59(1000, method27(v0))), singleton.Bind<void, void>(v9887, (): Async<void> => {
            return singleton.Zero();
        }))) : singleton.Zero(), singleton.Delay<Option<string>>((): Async<Option<string>> => {
            const v9904: Async<Option<string>> = method68(method28(v0));
            return singleton.ReturnFrom<Option<string>>(v9904);
        }));
    }), (_arg_1: Error): Async<Option<string>> => {
        if (equals(v1, 0n) !== true) {
            let v10259: any;
            closure36(v1, _arg_1, undefined);
            v10259 = undefined;
            return singleton.Return<Option<string>>(undefined);
        }
        else {
            const v10364: Async<Option<string>> = method57(v0, toInt64(op_Addition(v1, 1n)));
            return singleton.ReturnFrom<Option<string>>(v10364);
        }
    }));
}

export function method57(v0: string, v1: int64): Async<Option<string>> {
    return method58(v0, v1);
}

export function method56(v0: string): Async<Option<string>> {
    return method57(v0, 0n);
}

export function closure31(unitVar: void, v0: string): Async<Option<string>> {
    return method56(v0);
}

export function closure38(unitVar: void, v0: any): US12_$union {
    return US12_US12_0(v0);
}

export function method72(): ((arg0: any) => US12_$union) {
    return (v: any): US12_$union => closure38(undefined, v);
}

export function method73(): string {
    return "hh:mm";
}

export function method74(): string {
    return "yyyyMMdd-HHmm-ssff-ffff-f";
}

export function method75(): string {
    return "hhmm";
}

export function method71(v0: string, v1: Date): string {
    const v2334: string = method74();
    const v2339: string = toString(v1, (v2334 === "") ? "M-d-y hh:mm:ss tt" : v2334);
    const v2370: any = defaultOf();
    let v2591: number;
    throw new Error(`date_time.get_utc_offset / target: ${US4_US4_5(US3_US3_0())}`);
    const v2612: uint8 = (hours(v2591) > 0) ? 1 : 0;
    const v2613: string = method75();
    const v2919 = `${v2612}${toString_1(v2591, "c", {})}`;
    const v2922: string = v0;
    const v2938: int32 = (v2339.length + v2919.length) | 0;
    const v2959: int32 = (v2922.length - 1) | 0;
    return parse(concat(v2339, v2919, ...v2922.slice(v2938, v2959 + 1)));
}

export function method77(): string {
    throw new Error(`file_system.get_temp_path / target: ${US4_US4_5(US3_US3_0())}`);
}

export function method78(): string {
    return "!create_temp_path_";
}

export function method79(v0: string, v1: string): string {
    const v272: IPathJoin = path;
    return v272.join(v0, v1);
}

export function method81(): string {
    return "CARGO_PKG_NAME";
}

export function method80(): string {
    throw new Error(`env.get_entry_assembly_name / target: ${US4_US4_5(US3_US3_0())}`);
}

export function method76(v0: string): string {
    return method79(method79(method79(method77(), method78()), method80()), v0);
}

export function method70(): string {
    const v105: Date = now();
    return method76(method71(newGuid(), v105));
}

export function closure37(unitVar: void, unitVar_1: void): string {
    return method70();
}

export function closure40(unitVar: void, v0: any): any {
    return defaultOf();
}

export function method83(): ((arg0: any) => any) {
    return (v: any): any => closure40(undefined, v);
}

export function closure41(unitVar: void, unitVar_1: void): US13_$union {
    return US13_US13_0();
}

export function method84(): (() => US13_$union) {
    return (): US13_$union => closure41(undefined, undefined);
}

export function closure42(unitVar: void, v0: any): US13_$union {
    return US13_US13_1(v0);
}

export function method85(): ((arg0: any) => US13_$union) {
    return (v: any): US13_$union => closure42(undefined, v);
}

export function method86(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: any): string {
    const v11: Mut3 = new Mut3(method17());
    let v25: any;
    closure6(v11, "{ ", undefined);
    v25 = undefined;
    let v44_1: any;
    closure6(v11, "dir", undefined);
    v44_1 = undefined;
    let v63: any;
    closure6(v11, " = ", undefined);
    v63 = undefined;
    let v80: any;
    closure6(v11, v8, undefined);
    v80 = undefined;
    let v99: any;
    closure6(v11, "; ", undefined);
    v99 = undefined;
    let v118: any;
    closure6(v11, "error", undefined);
    v118 = undefined;
    let v135: any;
    closure6(v11, " = ", undefined);
    v135 = undefined;
    let v194: any;
    closure6(v11, toText(interpolate("%A%P()", [v9])), undefined);
    v194 = undefined;
    let v213: any;
    closure6(v11, " }", undefined);
    v213 = undefined;
    const v219: string = v11.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v219);
}

export function closure43(v0: string, v1: any, unitVar: void): void {
    if (method11(US0_US0_4())) {
        let v20: any;
        closure0(undefined, undefined);
        v20 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v46_1: Option<int64> = patternInput[5];
        const v45_1: Mut4 = patternInput[4];
        const v44_1: Mut3 = patternInput[3];
        const v43_1: Mut2 = patternInput[2];
        const v42_1: Mut1 = patternInput[1];
        const v41_1: Mut0 = patternInput[0];
        method22(method86(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method47(), v0, v1));
    }
}

export function method87(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string): string {
    const v10: Mut3 = new Mut3(method17());
    let v24: any;
    closure6(v10, "{ ", undefined);
    v24 = undefined;
    let v43_1: any;
    closure6(v10, "dir", undefined);
    v43_1 = undefined;
    let v62: any;
    closure6(v10, " = ", undefined);
    v62 = undefined;
    let v79: any;
    closure6(v10, v8, undefined);
    v79 = undefined;
    let v98: any;
    closure6(v10, " }", undefined);
    v98 = undefined;
    const v104: string = v10.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v104);
}

export function closure44(v0: string, unitVar: void): void {
    if (method11(US0_US0_0())) {
        let v19: any;
        closure0(undefined, undefined);
        v19 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v45_1: Option<int64> = patternInput[5];
        const v44_1: Mut4 = patternInput[4];
        const v43_1: Mut3 = patternInput[3];
        const v42_1: Mut2 = patternInput[2];
        const v41_1: Mut1 = patternInput[1];
        const v40_1: Mut0 = patternInput[0];
        method22(method87(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1, method12(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1), method31(), v0));
    }
}

export function closure45(v0: string, unitVar: void): void {
    method9(true, v0);
}

export function method88(v0: string): (() => void) {
    return (): void => {
        closure45(v0, undefined);
    };
}

export function method89(v0: string): (() => void) {
    return (): void => {
        closure45(v0, undefined);
    };
}

export function method90(v0: string): boolean {
    return defaultOf();
}

export function method91(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: string): string {
    const v11: Mut3 = new Mut3(method17());
    let v25: any;
    closure6(v11, "{ ", undefined);
    v25 = undefined;
    let v44_1: any;
    closure6(v11, "dir", undefined);
    v44_1 = undefined;
    let v63: any;
    closure6(v11, " = ", undefined);
    v63 = undefined;
    let v80: any;
    closure6(v11, v8, undefined);
    v80 = undefined;
    let v99: any;
    closure6(v11, "; ", undefined);
    v99 = undefined;
    let v118: any;
    closure6(v11, "result", undefined);
    v118 = undefined;
    let v135: any;
    closure6(v11, " = ", undefined);
    v135 = undefined;
    let v152: any;
    closure6(v11, v9, undefined);
    v152 = undefined;
    let v171: any;
    closure6(v11, " }", undefined);
    v171 = undefined;
    const v177: string = v11.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v177);
}

export function closure46(v0: string, v1: string, unitVar: void): void {
    if (method11(US0_US0_1())) {
        let v20: any;
        closure0(undefined, undefined);
        v20 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v46_1: Option<int64> = patternInput[5];
        const v45_1: Mut4 = patternInput[4];
        const v44_1: Mut3 = patternInput[3];
        const v43_1: Mut2 = patternInput[2];
        const v42_1: Mut1 = patternInput[1];
        const v41_1: Mut0 = patternInput[0];
        method22(method91(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method16(), v0, v1));
    }
}

export function closure47(v0: string, unitVar: void): void {
    const v20: Async<void> = ignore<int64>(method6(v0));
    defaultOf();
}

export function method92(v0: string): (() => void) {
    return (): void => {
        closure47(v0, undefined);
    };
}

export function method93(v0: string): (() => void) {
    return (): void => {
        closure47(v0, undefined);
    };
}

export function method82(v0: string): IDisposable {
    const v543: boolean = method90(v0);
    const v575: boolean = defaultOf();
    if (v575 === false) {
        let v692: any;
        closure46(v0, toText(interpolate("%A%P()", [{
            CreationTime: defaultOf(),
            Exists: v575,
        }])), undefined);
        v692 = undefined;
    }
    const v764: (() => void) = method93(v0);
    return {
        Dispose(): void {
            v764();
        },
    };
}

export function closure39(unitVar: void, unitVar_1: void): [string, IDisposable] {
    const v0: string = method70();
    return [v0, method82(v0)] as [string, IDisposable];
}

export function closure49(v0: int32, v1: string, v2: int32, v3: string): string {
    if (v2 >= v0) {
        return v3;
    }
    else {
        return method95(v0, v1, v2 + 1)(v3 + v1);
    }
}

export function method95(v0: int32, v1: string, v2: int32): ((arg0: string) => string) {
    return (v: string): string => closure49(v0, v1, v2, v);
}

export function method94(v0: string): string {
    const v3 = "0";
    const v13: string = method95(32 - v0.length, v3, 0)("") + v0;
    const v724 = 0;
    const v745: int32 = (8 - 1) | 0;
    const v756 = 8;
    const v777: int32 = (12 - 1) | 0;
    const v788 = 12;
    const v809: int32 = (16 - 1) | 0;
    const v820 = 16;
    const v841: int32 = (20 - 1) | 0;
    const v852 = 20;
    const v873: int32 = (32 - 1) | 0;
    return parse((((((((v13.slice(v724, v745 + 1) + "-") + v13.slice(v756, v777 + 1)) + "-") + v13.slice(v788, v809 + 1)) + "-") + v13.slice(v820, v841 + 1)) + "-") + v13.slice(v852, v873 + 1));
}

export function closure48(unitVar: void, v0: string): [string, IDisposable] {
    const v2: string = method76(method94(v0));
    return [v2, method82(v2)] as [string, IDisposable];
}

export function closure50(unitVar: void, unitVar_1: void): string {
    return "c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral";
}

export function closure52(unitVar: void, v0: any): US14_$union {
    return US14_US14_0(v0);
}

export function method99(): ((arg0: any) => US14_$union) {
    return (v: any): US14_$union => closure52(undefined, v);
}

export function closure53(unitVar: void, v0: string): US14_$union {
    return US14_US14_1(v0);
}

export function method100(): ((arg0: string) => US14_$union) {
    return (v: string): US14_$union => closure53(undefined, v);
}

export function method103(v0: string): Option<string> {
    const v207: IPathDirname = path;
    const v209: string = v207.dirname(v0);
    const v213: US5_$union = (v209 === v0) ? US5_US5_1() : US5_US5_0(v209);
    if ((v213.tag as int32) === /* US5_0 */ 0) {
        return v213.fields[0] as any;
    }
    else {
        return undefined;
    }
}

export function method102(v0: string, v1: ((arg0: uint8, arg1: string) => FSharpResult$2_$union<any, any>), v2: uint8, v3: string, v4: string): FSharpResult$2_$union<any, any> {
    const v5: string = method19(v4);
    const v6: Option<string> = method103(v4);
    const v31_1: US5_$union = defaultArg(map<string, US5_$union>(method5(), v6), US5_US5_1());
    const v36_1: Mut3 = new Mut3(method17());
    let v48_1: any;
    closure6(v36_1, v3, undefined);
    v48_1 = undefined;
    const v54: string = v36_1.l0;
    if (v2 >= 11) {
        return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`path: ${v0} / n: ${v2} / path': ${v4} / name: ${v5}`));
    }
    else if ((v31_1.tag as int32) === /* US5_0 */ 0) {
        const v110 = v31_1.fields[0] as any;
        if (v4 !== "") {
            const v119: FSharpResult$2_$union<any, any> = v1(v2 + 1, v110);
            const v120: ((arg0: any) => string) = method44();
            const v133: FSharpResult$2_$union<any, string> = ((v119.tag as int32) === /* Error */ 1) ? FSharpResult$2_Error<any, string>(v120(v119.fields[0] as any)) : FSharpResult$2_Ok<any, string>(v119.fields[0] as any);
            const v136: ((arg0: any) => US14_$union) = method99();
            const v137: ((arg0: string) => US14_$union) = method100();
            const v139: US14_$union = ((v133.tag as int32) === /* Error */ 1) ? v137(v133.fields[0] as any) : v136(v133.fields[0] as any);
            if ((v139.tag as int32) === /* US14_0 */ 0) {
                return FSharpResult$2_Ok<any, any>(method79(toString_2(v139.fields[0] as any), v5));
            }
            else {
                return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`error': ${v139.fields[0] as any} / error: ${v54} / name: ${v5}`));
            }
        }
        else {
            return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v54} / path': ${v4} / name: ${v5}`));
        }
    }
    else {
        return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v54} / path': ${v4} / name: ${v5}`));
    }
}

export function method101(v0: string, v1: uint8, v2: string): FSharpResult$2_$union<any, any> {
    return defaultOf();
}

export function closure55(v0: string, v1: uint8, v2: string): FSharpResult$2_$union<any, any> {
    return method101(v0, v1, v2);
}

export function closure54(v0: string, v1: uint8): ((arg0: string) => FSharpResult$2_$union<any, any>) {
    return (v: string): FSharpResult$2_$union<any, any> => closure55(v0, v1, v);
}

export function method104(v0: string, v1: ((arg0: uint8, arg1: string) => FSharpResult$2_$union<any, any>), v2: uint8, v3: string): FSharpResult$2_$union<any, any> {
    const v4: string = method19(v0);
    const v5: Option<string> = method103(v0);
    const v30: US5_$union = defaultArg(map<string, US5_$union>(method5(), v5), US5_US5_1());
    const v35_1: Mut3 = new Mut3(method17());
    let v47_1: any;
    closure6(v35_1, v3, undefined);
    v47_1 = undefined;
    const v53_1: string = v35_1.l0;
    if (v2 >= 11) {
        return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`path: ${v0} / n: ${v2} / path': ${v0} / name: ${v4}`));
    }
    else if ((v30.tag as int32) === /* US5_0 */ 0) {
        const v109 = v30.fields[0] as any;
        if (v0 !== "") {
            const v118: FSharpResult$2_$union<any, any> = v1(v2 + 1, v109);
            const v119: ((arg0: any) => string) = method44();
            const v132: FSharpResult$2_$union<any, string> = ((v118.tag as int32) === /* Error */ 1) ? FSharpResult$2_Error<any, string>(v119(v118.fields[0] as any)) : FSharpResult$2_Ok<any, string>(v118.fields[0] as any);
            const v135: ((arg0: any) => US14_$union) = method99();
            const v136: ((arg0: string) => US14_$union) = method100();
            const v138: US14_$union = ((v132.tag as int32) === /* Error */ 1) ? v136(v132.fields[0] as any) : v135(v132.fields[0] as any);
            if ((v138.tag as int32) === /* US14_0 */ 0) {
                return FSharpResult$2_Ok<any, any>(method79(toString_2(v138.fields[0] as any), v4));
            }
            else {
                return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`error': ${v138.fields[0] as any} / error: ${v53_1} / name: ${v4}`));
            }
        }
        else {
            return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v53_1} / path': ${v0} / name: ${v4}`));
        }
    }
    else {
        return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v53_1} / path': ${v0} / name: ${v4}`));
    }
}

export function method98(v0: string, v1: uint8): FSharpResult$2_$union<any, any> {
    return defaultOf();
}

export function method106(v0: boolean): int32 {
    return defaultOf();
}

export function method107(): int32 {
    return defaultOf();
}

export function method108(v0: int32, v1: int32): boolean {
    return defaultOf();
}

export function method110(v0: string, v1: ((arg0: uint8, arg1: string) => FSharpResult$2_$union<any, any>), v2: uint8, v3: any, v4: string): FSharpResult$2_$union<any, any> {
    const v5: string = method19(v4);
    const v6: Option<string> = method103(v4);
    const v31_1: US5_$union = defaultArg(map<string, US5_$union>(method5(), v6), US5_US5_1());
    const v36_1: Mut3 = new Mut3(method17());
    let v90: any;
    closure6(v36_1, toText(interpolate("%A%P()", [v3])), undefined);
    v90 = undefined;
    const v96: string = v36_1.l0;
    if (v2 >= 11) {
        return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`path: ${v0} / n: ${v2} / path': ${v4} / name: ${v5}`));
    }
    else if ((v31_1.tag as int32) === /* US5_0 */ 0) {
        const v152 = v31_1.fields[0] as any;
        if (v4 !== "") {
            const v161: FSharpResult$2_$union<any, any> = v1(v2 + 1, v152);
            const v162: ((arg0: any) => string) = method44();
            const v175: FSharpResult$2_$union<any, string> = ((v161.tag as int32) === /* Error */ 1) ? FSharpResult$2_Error<any, string>(v162(v161.fields[0] as any)) : FSharpResult$2_Ok<any, string>(v161.fields[0] as any);
            const v178: ((arg0: any) => US14_$union) = method99();
            const v179: ((arg0: string) => US14_$union) = method100();
            const v181: US14_$union = ((v175.tag as int32) === /* Error */ 1) ? v179(v175.fields[0] as any) : v178(v175.fields[0] as any);
            if ((v181.tag as int32) === /* US14_0 */ 0) {
                return FSharpResult$2_Ok<any, any>(method79(toString_2(v181.fields[0] as any), v5));
            }
            else {
                return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`error': ${v181.fields[0] as any} / error: ${v96} / name: ${v5}`));
            }
        }
        else {
            return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v96} / path': ${v4} / name: ${v5}`));
        }
    }
    else {
        return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v96} / path': ${v4} / name: ${v5}`));
    }
}

export function method109(v0: string, v1: uint8, v2: string): FSharpResult$2_$union<any, any> {
    const v45_1: int32 = method106(defaultOf()) | 0;
    const v47_1: boolean = method108(method107(), v45_1);
    if (v47_1) {
        const v66: boolean = defaultOf();
        return FSharpResult$2_Ok<any, any>(defaultOf());
    }
    else {
        return method110(v0, uncurry2((v: uint8): ((arg0: string) => FSharpResult$2_$union<any, any>) => closure56(v0, v)), v1, "file_system.read_link / Fsharp / The file or directory is not a reparse point. / " + (`path: ${v0} / result: ${v47_1} / path': ${v2} / n: ${v1}`), v2);
    }
}

export function closure57(v0: string, v1: uint8, v2: string): FSharpResult$2_$union<any, any> {
    return method109(v0, v1, v2);
}

export function closure56(v0: string, v1: uint8): ((arg0: string) => FSharpResult$2_$union<any, any>) {
    return (v: string): FSharpResult$2_$union<any, any> => closure57(v0, v1, v);
}

export function method111(v0: string, v1: ((arg0: uint8, arg1: string) => FSharpResult$2_$union<any, any>), v2: uint8, v3: any): FSharpResult$2_$union<any, any> {
    const v4: string = method19(v0);
    const v5: Option<string> = method103(v0);
    const v30: US5_$union = defaultArg(map<string, US5_$union>(method5(), v5), US5_US5_1());
    const v35_1: Mut3 = new Mut3(method17());
    let v89: any;
    closure6(v35_1, toText(interpolate("%A%P()", [v3])), undefined);
    v89 = undefined;
    const v95: string = v35_1.l0;
    if (v2 >= 11) {
        return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`path: ${v0} / n: ${v2} / path': ${v0} / name: ${v4}`));
    }
    else if ((v30.tag as int32) === /* US5_0 */ 0) {
        const v151 = v30.fields[0] as any;
        if (v0 !== "") {
            const v160: FSharpResult$2_$union<any, any> = v1(v2 + 1, v151);
            const v161: ((arg0: any) => string) = method44();
            const v174: FSharpResult$2_$union<any, string> = ((v160.tag as int32) === /* Error */ 1) ? FSharpResult$2_Error<any, string>(v161(v160.fields[0] as any)) : FSharpResult$2_Ok<any, string>(v160.fields[0] as any);
            const v177: ((arg0: any) => US14_$union) = method99();
            const v178: ((arg0: string) => US14_$union) = method100();
            const v180: US14_$union = ((v174.tag as int32) === /* Error */ 1) ? v178(v174.fields[0] as any) : v177(v174.fields[0] as any);
            if ((v180.tag as int32) === /* US14_0 */ 0) {
                return FSharpResult$2_Ok<any, any>(method79(toString_2(v180.fields[0] as any), v4));
            }
            else {
                return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`error': ${v180.fields[0] as any} / error: ${v95} / name: ${v4}`));
            }
        }
        else {
            return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v95} / path': ${v0} / name: ${v4}`));
        }
    }
    else {
        return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v95} / path': ${v0} / name: ${v4}`));
    }
}

export function method105(v0: string, v1: uint8): FSharpResult$2_$union<any, any> {
    const v44_1: int32 = method106(defaultOf()) | 0;
    const v46_1: boolean = method108(method107(), v44_1);
    if (v46_1) {
        const v65: boolean = defaultOf();
        return FSharpResult$2_Ok<any, any>(defaultOf());
    }
    else {
        return method111(v0, uncurry2((v: uint8): ((arg0: string) => FSharpResult$2_$union<any, any>) => closure56(v0, v)), v1, "file_system.read_link / Fsharp / The file or directory is not a reparse point. / " + (`path: ${v0} / result: ${v46_1} / path': ${v0} / n: ${v1}`));
    }
}

export function method97(v0: string): FSharpResult$2_$union<any, any> {
    return method105(v0, 0);
}

export function closure58(unitVar: void, v0: any): US15_$union {
    return US15_US15_0(v0);
}

export function method112(): ((arg0: any) => US15_$union) {
    return (v: any): US15_$union => closure58(undefined, v);
}

export function method114(v0: string): string {
    return v0;
}

export function method115(): string {
    return "";
}

export function method113(v0: string, v1: string, v2: string): string {
    return method115();
}

export function method96(v0: string): string {
    let _arg: string;
    if (v0 === "") {
        return "";
    }
    else {
        const v3: FSharpResult$2_$union<any, any> = method97(v0);
        const v12: Option<any> = ((v3.tag as int32) === /* Error */ 1) ? undefined : (v3.fields[0] as any);
        const v43_1: US15_$union = defaultArg(map<any, US15_$union>(method112(), v12), US15_US15_1());
        const v89: string = ((v43_1.tag as int32) === /* US15_0 */ 0) ? toString_2(v43_1.fields[0] as any) : v0;
        const v94: string = method113("^\\\\\\\\\\?\\\\", "", (v89 === "") ? v0 : v89);
        if (v94.length < 2) {
            return v0;
        }
        else {
            return replace(concat((_arg = v94[0], _arg.toLocaleLowerCase()), ...v94.slice(1, v94.length)), "\\", "/");
        }
    }
}

export function closure51(unitVar: void, v0: string): string {
    return method96(v0);
}

export function method117(): string {
    const v105: IFs = fs;
    return fs.realpathSync('.');
}

export function method118(v0: int32, v1: Mut5): boolean {
    return v1.l0 < v0;
}

export function method119(v0: int32, v1: Mut6): boolean {
    return v1.l0 < v0;
}

export function method120(): string {
    return "/";
}

export function method121(v0: string): string {
    return v0;
}

export function method116(v0: string): string {
    return defaultOf();
}

export function closure59(unitVar: void, v0: string): string {
    return method116(v0);
}

export function method122(v0: string): string {
    return method96(method116(v0));
}

export function closure60(unitVar: void, v0: string): string {
    return method122(v0);
}

export function closure61(unitVar: void, v0: string): string {
    return concat("file:///", ...trimStart(v0, ...["/"]));
}

export function closure63(unitVar: void, v0: string): boolean {
    return method34(v0);
}

export function closure64(unitVar: void, v0: string): boolean {
    return method10(v0);
}

export function method126(v0_mut: string, v1_mut: string, v2_mut: boolean, v3_mut: ((arg0: string) => boolean), v4_mut: string): US17_$union {
    method126:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: boolean = v2_mut, v3: ((arg0: string) => boolean) = v3_mut, v4: string = v4_mut;
        if (v3(method79(v4, v0))) {
            return US17_US17_0(v4);
        }
        else {
            const v8: Option<string> = method103(v4);
            const v33_1: US5_$union = defaultArg(map<string, US5_$union>(method5(), v8), US5_US5_1());
            if ((v33_1.tag as int32) === /* US5_0 */ 0) {
                v0_mut = v0;
                v1_mut = v1;
                v2_mut = v2;
                v3_mut = v3;
                v4_mut = (v33_1.fields[0] as any);
                continue method126;
            }
            else {
                return US17_US17_1(concat("file_system.find_parent / No parent for ", ...(v2 ? "file" : "dir")) + (` '${v0}' at '${v1}' (until '${v4}')`));
            }
        }
        break;
    }
}

export function method125(v0: string, v1: string, v2: boolean, v3: ((arg0: string) => boolean)): US17_$union {
    if (v3(method79(v1, v0))) {
        return US17_US17_0(v1);
    }
    else {
        const v7: Option<string> = method103(v1);
        const v32_1: US5_$union = defaultArg(map<string, US5_$union>(method5(), v7), US5_US5_1());
        if ((v32_1.tag as int32) === /* US5_0 */ 0) {
            return method126(v0, v1, v2, v3, v32_1.fields[0] as any);
        }
        else {
            return US17_US17_1(concat("file_system.find_parent / No parent for ", ...(v2 ? "file" : "dir")) + (` '${v0}' at '${v1}' (until '${v1}')`));
        }
    }
}

export function method124(v0: US16_$union, v1: string, v2: string): US17_$union {
    const v3: boolean = (v0.tag as int32) === /* US16_0 */ 0;
    return method125(v1, v2, v3, v3 ? ((v: string): boolean => closure63(undefined, v)) : ((v_1: string): boolean => closure64(undefined, v_1)));
}

export function method127(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: string): string {
    const v11: Mut3 = new Mut3(method17());
    let v25: any;
    closure6(v11, "{ ", undefined);
    v25 = undefined;
    let v44_1: any;
    closure6(v11, "dir", undefined);
    v44_1 = undefined;
    let v63: any;
    closure6(v11, " = ", undefined);
    v63 = undefined;
    let v80: any;
    closure6(v11, v8, undefined);
    v80 = undefined;
    let v99: any;
    closure6(v11, "; ", undefined);
    v99 = undefined;
    let v118: any;
    closure6(v11, "error", undefined);
    v118 = undefined;
    let v135: any;
    closure6(v11, " = ", undefined);
    v135 = undefined;
    let v152: any;
    closure6(v11, v9, undefined);
    v152 = undefined;
    let v171: any;
    closure6(v11, " }", undefined);
    v171 = undefined;
    const v177: string = v11.l0;
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.get_workspace_root") + " / ") + v177);
}

export function closure65(v0: string, v1: string, unitVar: void): void {
    if (method11(US0_US0_3())) {
        let v20: any;
        closure0(undefined, undefined);
        v20 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v46_1: Option<int64> = patternInput[5];
        const v45_1: Mut4 = patternInput[4];
        const v44_1: Mut3 = patternInput[3];
        const v43_1: Mut2 = patternInput[2];
        const v42_1: Mut1 = patternInput[1];
        const v41_1: Mut0 = patternInput[0];
        method22(method127(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1, method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1), method49(), v0, v1));
    }
}

export function method123(v0: string): US5_$union {
    const v5: US17_$union = method124(US16_US16_1(), method79("spiral", "workspace"), v0);
    if ((v5.tag as int32) === /* US17_0 */ 0) {
        return US5_US5_0(method96(v5.fields[0] as any));
    }
    else {
        let v72: any;
        closure65(v0, v5.fields[0] as any, undefined);
        v72 = undefined;
        return US5_US5_1();
    }
}

export function closure62(unitVar: void, unitVar_1: void): string {
    let v25: US5_$union;
    const v1: US5_$union = method123(method117());
    const v7: US5_$union = ((v1.tag as int32) === /* US5_0 */ 0) ? US5_US5_0(v1.fields[0] as any) : method123("c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral");
    const v13: US5_$union = ((v7.tag as int32) === /* US5_0 */ 0) ? US5_US5_0(v7.fields[0] as any) : method123("/workspaces");
    let v17: string;
    if ((v13.tag as int32) === /* US5_0 */ 0) {
        v17 = (v13.fields[0] as any);
    }
    else {
        throw new Error("Option does not have a value.");
    }
    return method79(("deps" === method19(v17)) ? ((v25 = method123(value_10(method103(v17))), ((v25.tag as int32) === /* US5_0 */ 0) ? (v25.fields[0] as any) : (() => {
        throw new Error("Option does not have a value.");
    })())) : v17, "polyglot");
}

export function closure67(v0: Error, unitVar: void): Error {
    return v0;
}

export function method128(v0: string): void {
}

export function closure66(unitVar: void, v0: string): void {
    method128(v0);
}

export function closure68(unitVar: void, v0: boolean): void {
    let v17: any;
    closure0(undefined, undefined);
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v58: ((arg0: string) => void) = v0 ? ((v: string): void => {
        closure66(undefined, v);
    }) : ((v_1: string): void => {
        closure2(undefined, v_1);
    });
    patternInput[1].l0 = v58;
}

export function method129(v0: string, v1: string): void {
    let v16_1: FSharpResult$2_$union<any, any>;
    if (method10(v0) === false) {
        const v4: IDisposable = method82(v0);
    }
    const v9: string = defaultArg(method103(v1), "");
    if (method10(v9) === false) {
        const v14_1: IDisposable = method82(v9);
    }
    if (method10(v1) && ((v16_1 = method97(v1), true))) {
        method9(true, v1);
    }
    if (method10(v1) === false) {
    }
}

export function closure70(v0: string, v1: string): void {
    method129(v0, v1);
}

export function closure69(unitVar: void, v0: string): ((arg0: string) => void) {
    return (v: string): void => {
        closure70(v0, v);
    };
}

export function closure72(v0: string, v1: string): string {
    return method79(v0, v1);
}

export function closure71(unitVar: void, v0: string): ((arg0: string) => string) {
    return (v: string): string => closure72(v0, v);
}

export const v14: any = undefined;

export const v15 = (): void => {
    closure0(undefined, undefined);
};

export const v16: any = (v15(), v14);

export const v31 = (v: string): Async<int64> => closure3(undefined, v);

export function delete_directory_async(x: string): Async<int64> {
    return v31(x);
}

export const v32 = (v: US6_$union): ((arg0: string) => Async<int64>) => closure10(undefined, v);

export function wait_for_file_access(x: US6_$union): ((arg0: string) => Async<int64>) {
    return v32(x);
}

export const v33 = (v: string): Async<int64> => closure13(undefined, v);

export function wait_for_file_access_read(x: string): Async<int64> {
    return v33(x);
}

export const v34 = (v: string): Async<string> => closure14(undefined, v);

export function read_all_text_async(x: string): Async<string> {
    return v34(x);
}

export const v35 = (v: string): ((arg0: string) => boolean) => closure16(undefined, v);

export function file_exists_content(x: string): ((arg0: string) => boolean) {
    return v35(x);
}

export const v36 = (v: string): ((arg0: string) => Async<void>) => closure18(undefined, v);

export function write_all_text_async(x: string): ((arg0: string) => Async<void>) {
    return v36(x);
}

export const v37 = (v: string): ((arg0: string) => Async<void>) => closure20(undefined, v);

export function write_all_text_exists(x: string): ((arg0: string) => Async<void>) {
    return v37(x);
}

export const v38 = (v: string): Async<int64> => closure22(undefined, v);

export function delete_file_async(x: string): Async<int64> {
    return v38(x);
}

export const v39 = (v: string): ((arg0: string) => Async<int64>) => closure28(undefined, v);

export function move_file_async(x: string): ((arg0: string) => Async<int64>) {
    return v39(x);
}

export const v40 = (v: string): Async<Option<string>> => closure31(undefined, v);

export function read_all_text_retry_async(x: string): Async<Option<string>> {
    return v40(x);
}

export const v41 = (): string => closure37(undefined, undefined);

export function create_temp_path(): string {
    return v41();
}

export const v42 = (): [string, IDisposable] => closure39(undefined, undefined);

export function create_temp_dir(): [string, IDisposable] {
    return v42();
}

export const v43 = (v: string): [string, IDisposable] => closure48(undefined, v);

export function create_temp_dir$0027(x: string): [string, IDisposable] {
    return v43(x);
}

export const v44 = (): string => closure50(undefined, undefined);

export function get_source_directory(): string {
    return v44();
}

export const v45 = (v: string): string => closure51(undefined, v);

export function normalize_path(x: string): string {
    return v45(x);
}

export const v46 = (v: string): string => closure59(undefined, v);

export function get_full_path(x: string): string {
    return v46(x);
}

export const v47 = (v: string): string => closure60(undefined, v);

export function standardize_path(x: string): string {
    return v47(x);
}

export const v48 = (v: string): string => closure61(undefined, v);

export function new_file_uri(x: string): string {
    return v48(x);
}

export const v49 = (): string => closure62(undefined, undefined);

export function get_workspace_root(): string {
    return v49();
}

export const v50 = (v: string): void => {
    closure66(undefined, v);
};

export function trace_file(x: string): void {
    v50(x);
}

export const v51 = (v: boolean): void => {
    closure68(undefined, v);
};

export function init_trace_file(x: boolean): void {
    v51(x);
}

export const v52 = (v: string): ((arg0: string) => void) => closure69(undefined, v);

export function link_directory(x: string): ((arg0: string) => void) {
    return v52(x);
}

export const v53 = (v: string): ((arg0: string) => string) => closure71(undefined, v);

export function op_LessDivideGreater(x: string): ((arg0: string) => string) {
    return v53(x);
}


