import { uncurry2, defaultOf, compare, int64ToString, IComparable, IEquatable, IDisposable, createAtom } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Util.js";
import { value as value_10, map, defaultArg, Option } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Option.js";
import { compare as compare_1, op_Modulus, equals, op_Addition, op_Subtraction, fromInt64, toInt64, int64 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/BigInt.js";
import { array_type, int32_type, option_type, bool_type, lambda_type, unit_type, string_type, record_type, int64_type, union_type, class_type, TypeInfo } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Reflection.js";
import { toString as toString_2, Record, Union } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Types.js";
import { uint8, int32 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Int32.js";
import { toString, create, now, getTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Date.js";
import * as fs from "fs";
import { toString as toString_1, milliseconds, seconds, minutes, hours, fromTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/TimeSpan.js";
import * as path from "path";
import { replace, concat, interpolate, toText, trimStart, trimEnd } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/String.js";
import { ofSeq, find } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Map.js";
import { Async, singleton } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/AsyncBuilder.js";
import { ignore, catchAsync, startChild, awaitPromise as awaitTask, sleep } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Async.js";
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
    return union_type("File_system.US6", [], US6, () => [[["f0_0", Mut0_$reflection()], ["f0_1", Mut1_$reflection()], ["f0_2", Mut2_$reflection()], ["f0_3", Mut3_$reflection()], ["f0_4", Mut4_$reflection()], ["f0_5", option_type(int64_type)]], []]);
}

export type US8_$union = 
    | US8<0>
    | US8<1>
    | US8<2>

export type US8_$cases = {
    0: ["US8_0", []],
    1: ["US8_1", []],
    2: ["US8_2", []]
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

export class US8<Tag extends keyof US8_$cases> extends Union<Tag, US8_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US8_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US8_0", "US8_1", "US8_2"];
    }
}

export function US8_$reflection(): TypeInfo {
    return union_type("File_system.US8", [], US8, () => [[], [], []]);
}

export type US9_$union = 
    | US9<0>
    | US9<1>
    | US9<2>
    | US9<3>
    | US9<4>

export type US9_$cases = {
    0: ["US9_0", []],
    1: ["US9_1", []],
    2: ["US9_2", []],
    3: ["US9_3", []],
    4: ["US9_4", []]
}

export function US9_US9_0() {
    return new US9<0>(0, []);
}

export function US9_US9_1() {
    return new US9<1>(1, []);
}

export function US9_US9_2() {
    return new US9<2>(2, []);
}

export function US9_US9_3() {
    return new US9<3>(3, []);
}

export function US9_US9_4() {
    return new US9<4>(4, []);
}

export class US9<Tag extends keyof US9_$cases> extends Union<Tag, US9_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US9_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US9_0", "US9_1", "US9_2", "US9_3", "US9_4"];
    }
}

export function US9_$reflection(): TypeInfo {
    return union_type("File_system.US9", [], US9, () => [[], [], [], [], []]);
}

export type US7_$union = 
    | US7<0>
    | US7<1>

export type US7_$cases = {
    0: ["US7_0", [US8_$union, US9_$union]],
    1: ["US7_1", []]
}

export function US7_US7_0(f0_0: US8_$union, f0_1: US9_$union) {
    return new US7<0>(0, [f0_0, f0_1]);
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
    return union_type("File_system.US7", [], US7, () => [[["f0_0", US8_$reflection()], ["f0_1", US9_$reflection()]], []]);
}

export type US10_$union = 
    | US10<0>
    | US10<1>

export type US10_$cases = {
    0: ["US10_0", []],
    1: ["US10_1", [string]]
}

export function US10_US10_0() {
    return new US10<0>(0, []);
}

export function US10_US10_1(f1_0: string) {
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
    return union_type("File_system.US10", [], US10, () => [[], [["f1_0", string_type]]]);
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
    0: ["US12_0", [int64]],
    1: ["US12_1", [Error]]
}

export function US12_US12_0(f0_0: int64) {
    return new US12<0>(0, [f0_0]);
}

export function US12_US12_1(f1_0: Error) {
    return new US12<1>(1, [f1_0]);
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
    return union_type("File_system.US12", [], US12, () => [[["f0_0", int64_type]], [["f1_0", class_type("System.Exception")]]]);
}

export type US13_$union = 
    | US13<0>
    | US13<1>

export type US13_$cases = {
    0: ["US13_0", [any]],
    1: ["US13_1", []]
}

export function US13_US13_0(f0_0: any) {
    return new US13<0>(0, [f0_0]);
}

export function US13_US13_1() {
    return new US13<1>(1, []);
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
    return union_type("File_system.US13", [], US13, () => [[["f0_0", string_type]], []]);
}

export type US14_$union = 
    | US14<0>
    | US14<1>

export type US14_$cases = {
    0: ["US14_0", []],
    1: ["US14_1", [any]]
}

export function US14_US14_0() {
    return new US14<0>(0, []);
}

export function US14_US14_1(f1_0: any) {
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
    return union_type("File_system.US14", [], US14, () => [[], [["f1_0", string_type]]]);
}

export type US15_$union = 
    | US15<0>
    | US15<1>

export type US15_$cases = {
    0: ["US15_0", [any]],
    1: ["US15_1", [string]]
}

export function US15_US15_0(f0_0: any) {
    return new US15<0>(0, [f0_0]);
}

export function US15_US15_1(f1_0: string) {
    return new US15<1>(1, [f1_0]);
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
    return union_type("File_system.US15", [], US15, () => [[["f0_0", string_type]], [["f1_0", string_type]]]);
}

export type US16_$union = 
    | US16<0>
    | US16<1>

export type US16_$cases = {
    0: ["US16_0", [any]],
    1: ["US16_1", []]
}

export function US16_US16_0(f0_0: any) {
    return new US16<0>(0, [f0_0]);
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
    return union_type("File_system.US16", [], US16, () => [[["f0_0", string_type]], []]);
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

export type US17_$union = 
    | US17<0>
    | US17<1>

export type US17_$cases = {
    0: ["US17_0", []],
    1: ["US17_1", []]
}

export function US17_US17_0() {
    return new US17<0>(0, []);
}

export function US17_US17_1() {
    return new US17<1>(1, []);
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
    return union_type("File_system.US17", [], US17, () => [[], []]);
}

export type US18_$union = 
    | US18<0>
    | US18<1>

export type US18_$cases = {
    0: ["US18_0", [string]],
    1: ["US18_1", [string]]
}

export function US18_US18_0(f0_0: string) {
    return new US18<0>(0, [f0_0]);
}

export function US18_US18_1(f1_0: string) {
    return new US18<1>(1, [f1_0]);
}

export class US18<Tag extends keyof US18_$cases> extends Union<Tag, US18_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: US18_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["US18_0", "US18_1"];
    }
}

export function US18_$reflection(): TypeInfo {
    return union_type("File_system.US18", [], US18, () => [[["f0_0", string_type]], [["f1_0", string_type]]]);
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

export function closure5(unitVar: void, v0: int64): US2_$union {
    return US2_US2_0(v0);
}

export function method12(): ((arg0: int64) => US2_$union) {
    return (v: int64): US2_$union => closure5(undefined, v);
}

export function method13(): string {
    return "hh:mm:ss";
}

export function method14(): string {
    return "HH:mm:ss";
}

export function method11(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>): string {
    const v710: US2_$union = defaultArg(map<int64, US2_$union>(method12(), v5), US2_US2_1());
    let v864: Date;
    if ((v710.tag as int32) === /* US2_0 */ 0) {
        const v714 = v710.fields[0] as any;
        const v793: number = fromTicks(toInt64(op_Subtraction(toInt64(fromInt64(getTicks(now()))), v714)));
        v864 = create(1, 1, 1, hours(v793), minutes(v793), seconds(v793), milliseconds(v793));
    }
    else {
        v864 = now();
    }
    const v865: string = method14();
    return toString(v864, (v865 === "") ? "M-d-y hh:mm:ss tt" : v865);
}

export function method17(): string {
    return "";
}

export function closure6(v0: Mut3, v1: string, unitVar: void): void {
    const v4: string = v0.l0 + v1;
    v0.l0 = v4;
}

export function method16(v0: string): string {
    const v2: Mut3 = new Mut3(method17());
    let v17: any;
    closure6(v2, `${v0}`, undefined);
    v17 = undefined;
    return v2.l0;
}

export function method15(): string {
    const v133: string = "Debug".toLocaleLowerCase();
    return ("\u001b[94m" + method16(v133[0])) + "\u001b[0m";
}

export function method18(v0: string): string {
    const v209: IPathBasename = path;
    return v209.basename(v0);
}

export function method20(v0: string, v1: string): string {
    const v3: Mut3 = new Mut3(method17());
    let v17: any;
    closure6(v3, "{ ", undefined);
    v17 = undefined;
    let v36_1: any;
    closure6(v3, "ex", undefined);
    v36_1 = undefined;
    let v55: any;
    closure6(v3, " = ", undefined);
    v55 = undefined;
    let v72: any;
    closure6(v3, v0, undefined);
    v72 = undefined;
    let v91: any;
    closure6(v3, "; ", undefined);
    v91 = undefined;
    let v110: any;
    closure6(v3, "path", undefined);
    v110 = undefined;
    let v127: any;
    closure6(v3, " = ", undefined);
    v127 = undefined;
    let v144: any;
    closure6(v3, v1, undefined);
    v144 = undefined;
    let v163: any;
    closure6(v3, " }", undefined);
    v163 = undefined;
    return v3.l0;
}

export function method21(v0: string): string {
    return trimEnd(trimStart(v0, ...[]), ...[" ", "/"]);
}

export function method19(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: string): string {
    const v10: string = method20(v8, v9);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.delete_directory_async") + " / ") + v10);
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

export function closure4(v0: string, v1: Error, unitVar: void): void {
    const v17 = (): void => {
        closure0(undefined, undefined);
    };
    let v18: any;
    v17();
    v18 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v59: US0_$union = patternInput[4].l0;
    let v339: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (1 >= find<US0_$union, int32>(v59, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v339 = US6_US6_1();
    }
    else {
        let v82: any;
        v17();
        v82 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v110: Option<int64> = patternInput_1[5];
        const v109: Mut4 = patternInput_1[4];
        const v108: Mut3 = patternInput_1[3];
        const v107: Mut2 = patternInput_1[2];
        const v106: Mut1 = patternInput_1[1];
        const v105: Mut0 = patternInput_1[0];
        const v165: string = method19(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method15(), toText(interpolate("%A%P()", [v1])), method18(v0));
        let v181: any;
        v17();
        v181 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v205: Mut1 = patternInput_2[1];
        const v204: Mut0 = patternInput_2[0];
        let v226: any;
        closure7(v204, undefined);
        v226 = undefined;
        closure8(undefined, v165);
        v205.l0(v165);
        v339 = US6_US6_0(v204, v205, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method8(v0: string, v1: int64): Async<int64> {
    return singleton.Delay<int64>((): Async<int64> => singleton.TryWith<int64>(singleton.Delay<int64>((): Async<int64> => {
        method9(true, v0);
        return singleton.Return<int64>(v1);
    }), (_arg: Error): Async<int64> => {
        let v29909: any;
        const v29555: boolean = equals(toInt64(op_Modulus(v1, 100n)), 0n);
        return singleton.Combine<int64>(v29555 ? ((v29909 = ((closure4(v0, _arg, undefined), undefined)), singleton.Zero())) : singleton.Zero(), singleton.Delay<int64>((): Async<int64> => {
            const v30276: Async<void> = sleep(10);
            return singleton.Bind<void, int64>(v30276, (): Async<int64> => {
                const v30290: Async<int64> = method7(v0, toInt64(op_Addition(v1, 1n)));
                return singleton.ReturnFrom<int64>(v30290);
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

export function method26(v0: string, v1: int64, v2: string): string {
    const v4: Mut3 = new Mut3(method17());
    let v18: any;
    closure6(v4, "{ ", undefined);
    v18 = undefined;
    let v37_1: any;
    closure6(v4, "path", undefined);
    v37_1 = undefined;
    let v56: any;
    closure6(v4, " = ", undefined);
    v56 = undefined;
    let v73: any;
    closure6(v4, v0, undefined);
    v73 = undefined;
    let v92: any;
    closure6(v4, "; ", undefined);
    v92 = undefined;
    let v111: any;
    closure6(v4, "retry", undefined);
    v111 = undefined;
    let v128: any;
    closure6(v4, " = ", undefined);
    v128 = undefined;
    let v148: any;
    closure6(v4, `${v1}`, undefined);
    v148 = undefined;
    let v165: any;
    closure6(v4, "; ", undefined);
    v165 = undefined;
    let v184: any;
    closure6(v4, "ex", undefined);
    v184 = undefined;
    let v201: any;
    closure6(v4, " = ", undefined);
    v201 = undefined;
    let v218: any;
    closure6(v4, v2, undefined);
    v218 = undefined;
    let v237: any;
    closure6(v4, " }", undefined);
    v237 = undefined;
    return v4.l0;
}

export function method25(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: int64, v10: string): string {
    const v11: string = method26(v8, v9, v10);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.wait_for_file_access") + " / ") + v11);
}

export function closure12(v0: string, v1: int64, v2: Error, unitVar: void): void {
    const v18 = (): void => {
        closure0(undefined, undefined);
    };
    let v19: any;
    v18();
    v19 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v60: US0_$union = patternInput[4].l0;
    let v340: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (1 >= find<US0_$union, int32>(v60, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v340 = US6_US6_1();
    }
    else {
        let v83: any;
        v18();
        v83 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v111: Option<int64> = patternInput_1[5];
        const v110: Mut4 = patternInput_1[4];
        const v109: Mut3 = patternInput_1[3];
        const v108: Mut2 = patternInput_1[2];
        const v107: Mut1 = patternInput_1[1];
        const v106: Mut0 = patternInput_1[0];
        const v166: string = method25(v106, v107, v108, v109, v110, v111, method11(v106, v107, v108, v109, v110, v111), method15(), method18(v0), v1, toText(interpolate("%A%P()", [v2])));
        let v182: any;
        v18();
        v182 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v206: Mut1 = patternInput_2[1];
        const v205: Mut0 = patternInput_2[0];
        let v227: any;
        closure7(v205, undefined);
        v227 = undefined;
        closure8(undefined, v166);
        v206.l0(v166);
        v340 = US6_US6_0(v205, v206, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method24(v0: US7_$union, v1: string, v2: int64, v3: US9_$union, v4: US8_$union): Async<int64> {
    return singleton.Delay<int64>((): Async<int64> => singleton.TryWith<int64>(singleton.Delay<int64>((): Async<int64> => {
        const v31158: any = defaultOf();
        return singleton.Using<any, int64>(v31158, (_arg: any): Async<int64> => singleton.Return<int64>(v2));
    }), (_arg_1: Error): Async<int64> => {
        let v32346: any;
        const v31992: boolean = (compare_1(v2, 0n) > 0) && equals(toInt64(op_Modulus(v2, 100n)), 0n);
        return singleton.Combine<int64>(v31992 ? ((v32346 = ((closure12(v1, v2, _arg_1, undefined), undefined)), singleton.Zero())) : singleton.Zero(), singleton.Delay<int64>((): Async<int64> => {
            const v32713: Async<void> = sleep(10);
            return singleton.Bind<void, int64>(v32713, (): Async<int64> => {
                const v32727: Async<int64> = method23(v0, v1, toInt64(op_Addition(v2, 1n)));
                return singleton.ReturnFrom<int64>(v32727);
            });
        }));
    }));
}

export function method23(v0: US7_$union, v1: string, v2: int64): Async<int64> {
    return defaultOf();
}

export function method22(v0: US7_$union, v1: string): Async<int64> {
    return method23(v0, v1, 0n);
}

export function closure11(v0: US7_$union, v1: string): Async<int64> {
    return method22(v0, v1);
}

export function closure10(unitVar: void, v0: US7_$union): ((arg0: string) => Async<int64>) {
    return (v: string): Async<int64> => closure11(v0, v);
}

export function method27(v0: string): Async<int64> {
    return method22(US7_US7_0(US8_US8_0(), US9_US9_1()), v0);
}

export function closure13(unitVar: void, v0: string): Async<int64> {
    return method27(v0);
}

export function method31(): string {
    const v133: string = "Verbose".toLocaleLowerCase();
    return ("\u001b[90m" + method16(v133[0])) + "\u001b[0m";
}

export function method33(v0: int64, v1: string, v2: Error): string {
    const v4: Mut3 = new Mut3(method17());
    let v18: any;
    closure6(v4, "{ ", undefined);
    v18 = undefined;
    let v37_1: any;
    closure6(v4, "retry", undefined);
    v37_1 = undefined;
    let v56: any;
    closure6(v4, " = ", undefined);
    v56 = undefined;
    let v76: any;
    closure6(v4, `${v0}`, undefined);
    v76 = undefined;
    let v95: any;
    closure6(v4, "; ", undefined);
    v95 = undefined;
    let v114: any;
    closure6(v4, "path", undefined);
    v114 = undefined;
    let v131: any;
    closure6(v4, " = ", undefined);
    v131 = undefined;
    let v148: any;
    closure6(v4, v1, undefined);
    v148 = undefined;
    let v165: any;
    closure6(v4, "; ", undefined);
    v165 = undefined;
    let v184: any;
    closure6(v4, "ex", undefined);
    v184 = undefined;
    let v201: any;
    closure6(v4, " = ", undefined);
    v201 = undefined;
    let v260: any;
    closure6(v4, toText(interpolate("%A%P()", [v2])), undefined);
    v260 = undefined;
    let v279: any;
    closure6(v4, " }", undefined);
    v279 = undefined;
    return v4.l0;
}

export function method32(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int64, v9: string, v10: Error): string {
    const v11: string = method33(v8, v9, v10);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.read_all_text_async") + " / ") + v11);
}

export function closure15(v0: string, v1: int64, v2: Error, unitVar: void): void {
    const v18 = (): void => {
        closure0(undefined, undefined);
    };
    let v19: any;
    v18();
    v19 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v60: US0_$union = patternInput[4].l0;
    let v300: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (0 >= find<US0_$union, int32>(v60, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v300 = US6_US6_1();
    }
    else {
        let v83: any;
        v18();
        v83 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v111: Option<int64> = patternInput_1[5];
        const v110: Mut4 = patternInput_1[4];
        const v109: Mut3 = patternInput_1[3];
        const v108: Mut2 = patternInput_1[2];
        const v107: Mut1 = patternInput_1[1];
        const v106: Mut0 = patternInput_1[0];
        const v126: string = method32(v106, v107, v108, v109, v110, v111, method11(v106, v107, v108, v109, v110, v111), method31(), v1, v0, v2);
        let v142: any;
        v18();
        v142 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v166: Mut1 = patternInput_2[1];
        const v165: Mut0 = patternInput_2[0];
        let v187: any;
        closure7(v165, undefined);
        v187 = undefined;
        closure8(undefined, v126);
        v166.l0(v126);
        v300 = US6_US6_0(v165, v166, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method30(v0: string, v1: int64): Async<string> {
    return singleton.Delay<string>((): Async<string> => singleton.TryWith<string>(singleton.Delay<string>((): Async<string> => {
        const v28755: Async<string> = awaitTask<string>(defaultOf());
        return singleton.ReturnFrom<string>(v28755);
    }), (_arg: Error): Async<string> => {
        let v29813: any;
        closure15(v0, v1, _arg, undefined);
        v29813 = undefined;
        const v30140: Async<void> = sleep(10);
        return singleton.Bind<void, string>(v30140, (): Async<string> => {
            let v30158: Async<string>;
            if (compare_1(v1, 3n) < 0) {
                v30158 = method29(v0, toInt64(op_Addition(v1, 1n)));
            }
            else {
                throw new Error(`file_system.read_all_text_async / retry: ${v1} / path: ${v0}`);
            }
            return singleton.ReturnFrom<string>(v30158);
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

export function method35(v0: string): boolean {
    const v128: IFsExistsSync = fs;
    return v128.existsSync(v0);
}

export function method36(v0: any): any {
    return v0;
}

export function method34(v0: string, v1: string): boolean {
    return defaultOf();
}

export function closure17(v0: string, v1: string): boolean {
    return method34(v0, v1);
}

export function closure16(unitVar: void, v0: string): ((arg0: string) => boolean) {
    return (v: string): boolean => closure17(v0, v);
}

export function method37(v0: string, v1: string): Async<void> {
    return defaultOf();
}

export function closure19(v0: string, v1: string): Async<void> {
    return method37(v0, v1);
}

export function closure18(unitVar: void, v0: string): ((arg0: string) => Async<void>) {
    return (v: string): Async<void> => closure19(v0, v);
}

export function method41(v0: string, v1: string): Async<boolean> {
    return singleton.Delay<boolean>((): Async<boolean> => {
        if (method35(v0) === false) {
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

export function method40(v0: string, v1: string): Async<boolean> {
    return defaultOf();
}

export function method39(v0: string, v1: string): Async<void> {
    return singleton.Delay<void>((): Async<void> => {
        const v75: Async<boolean> = method40(v0, v1);
        return singleton.Bind<boolean, void>(v75, (_arg: boolean): Async<void> => {
            let v78: Async<void>;
            const v77: boolean = _arg === false;
            return singleton.Combine<void>(v77 ? ((v78 = method37(v0, v1), singleton.Bind<void, void>(v78, (): Async<void> => {
                return singleton.Zero();
            }))) : singleton.Zero(), singleton.Delay<void>((): Async<void> => {
                return singleton.Zero();
            }));
        });
    });
}

export function method38(v0: string, v1: string): Async<void> {
    return method39(v0, v1);
}

export function closure21(v0: string, v1: string): Async<void> {
    return method38(v0, v1);
}

export function closure20(unitVar: void, v0: string): ((arg0: string) => Async<void>) {
    return (v: string): Async<void> => closure21(v0, v);
}

export function method46(v0: any): string {
    const v2: Mut3 = new Mut3(method17());
    let v56: any;
    closure6(v2, toText(interpolate("%A%P()", [v0])), undefined);
    v56 = undefined;
    return v2.l0;
}

export function closure23(unitVar: void, v0: any): string {
    return method46(v0);
}

export function method45(): ((arg0: any) => string) {
    return (v: any): string => closure23(undefined, v);
}

export function closure24(unitVar: void, unitVar_1: void): US10_$union {
    return US10_US10_0();
}

export function method47(): (() => US10_$union) {
    return (): US10_$union => closure24(undefined, undefined);
}

export function closure25(unitVar: void, v0: string): US10_$union {
    return US10_US10_1(v0);
}

export function method48(): ((arg0: string) => US10_$union) {
    return (v: string): US10_$union => closure25(undefined, v);
}

export function method49(): string {
    const v133: string = "Critical".toLocaleLowerCase();
    return ("\u001b[91m" + method16(v133[0])) + "\u001b[0m";
}

export function method51(v0: string): string {
    const v2: Mut3 = new Mut3(method17());
    let v16_1: any;
    closure6(v2, "{ ", undefined);
    v16_1 = undefined;
    let v35_1: any;
    closure6(v2, "error\'", undefined);
    v35_1 = undefined;
    let v54: any;
    closure6(v2, " = ", undefined);
    v54 = undefined;
    let v71: any;
    closure6(v2, v0, undefined);
    v71 = undefined;
    let v90: any;
    closure6(v2, " }", undefined);
    v90 = undefined;
    return v2.l0;
}

export function method50(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string): string {
    const v9: string = method51(v8);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.file_delete") + " / ") + v9);
}

export function closure26(v0: string, unitVar: void): void {
    const v16_1 = (): void => {
        closure0(undefined, undefined);
    };
    let v17: any;
    v16_1();
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v58: US0_$union = patternInput[4].l0;
    let v298: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (4 >= find<US0_$union, int32>(v58, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v298 = US6_US6_1();
    }
    else {
        let v81: any;
        v16_1();
        v81 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v109: Option<int64> = patternInput_1[5];
        const v108: Mut4 = patternInput_1[4];
        const v107: Mut3 = patternInput_1[3];
        const v106: Mut2 = patternInput_1[2];
        const v105: Mut1 = patternInput_1[1];
        const v104: Mut0 = patternInput_1[0];
        const v124: string = method50(v104, v105, v106, v107, v108, v109, method11(v104, v105, v106, v107, v108, v109), method49(), v0);
        let v140: any;
        v16_1();
        v140 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v164: Mut1 = patternInput_2[1];
        const v163: Mut0 = patternInput_2[0];
        let v185: any;
        closure7(v163, undefined);
        v185 = undefined;
        closure8(undefined, v124);
        v164.l0(v124);
        v298 = US6_US6_0(v163, v164, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method52(): string {
    const v133: string = "Warning".toLocaleLowerCase();
    return ("\u001b[93m" + method16(v133[0])) + "\u001b[0m";
}

export function method54(v0: string, v1: string): string {
    const v3: Mut3 = new Mut3(method17());
    let v17: any;
    closure6(v3, "{ ", undefined);
    v17 = undefined;
    let v36_1: any;
    closure6(v3, "path", undefined);
    v36_1 = undefined;
    let v55: any;
    closure6(v3, " = ", undefined);
    v55 = undefined;
    let v72: any;
    closure6(v3, v0, undefined);
    v72 = undefined;
    let v91: any;
    closure6(v3, "; ", undefined);
    v91 = undefined;
    let v110: any;
    closure6(v3, "ex", undefined);
    v110 = undefined;
    let v127: any;
    closure6(v3, " = ", undefined);
    v127 = undefined;
    let v144: any;
    closure6(v3, v1, undefined);
    v144 = undefined;
    let v163: any;
    closure6(v3, " }", undefined);
    v163 = undefined;
    return v3.l0;
}

export function method53(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: string): string {
    const v10: string = method54(v8, v9);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "delete_file_async") + " / ") + v10);
}

export function closure27(v0: string, v1: Error, unitVar: void): void {
    const v17 = (): void => {
        closure0(undefined, undefined);
    };
    let v18: any;
    v17();
    v18 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v59: US0_$union = patternInput[4].l0;
    let v339: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (3 >= find<US0_$union, int32>(v59, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v339 = US6_US6_1();
    }
    else {
        let v82: any;
        v17();
        v82 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v110: Option<int64> = patternInput_1[5];
        const v109: Mut4 = patternInput_1[4];
        const v108: Mut3 = patternInput_1[3];
        const v107: Mut2 = patternInput_1[2];
        const v106: Mut1 = patternInput_1[1];
        const v105: Mut0 = patternInput_1[0];
        const v165: string = method53(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method52(), method18(v0), toText(interpolate("%A%P()", [v1])));
        let v181: any;
        v17();
        v181 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v205: Mut1 = patternInput_2[1];
        const v204: Mut0 = patternInput_2[0];
        let v226: any;
        closure7(v204, undefined);
        v226 = undefined;
        closure8(undefined, v165);
        v205.l0(v165);
        v339 = US6_US6_0(v204, v205, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method44(v0: string, v1: int64): Async<int64> {
    return singleton.Delay<int64>((): Async<int64> => singleton.TryWith<int64>(singleton.Delay<int64>((): Async<int64> => singleton.Return<int64>(v1)), (_arg: Error): Async<int64> => {
        let v57377: any;
        const v57023: boolean = equals(toInt64(op_Modulus(v1, 100n)), 0n);
        return singleton.Combine<int64>(v57023 ? ((v57377 = ((closure27(v0, _arg, undefined), undefined)), singleton.Zero())) : singleton.Zero(), singleton.Delay<int64>((): Async<int64> => {
            const v57744: Async<void> = sleep(10);
            return singleton.Bind<void, int64>(v57744, (): Async<int64> => {
                const v57758: Async<int64> = method43(v0, toInt64(op_Addition(v1, 1n)));
                return singleton.ReturnFrom<int64>(v57758);
            });
        }));
    }));
}

export function method43(v0: string, v1: int64): Async<int64> {
    return defaultOf();
}

export function method42(v0: string): Async<int64> {
    return method43(v0, 0n);
}

export function closure22(unitVar: void, v0: string): Async<int64> {
    return method42(v0);
}

export function method58(v0: string, v1: string): void {
}

export function method60(v0: string, v1: string, v2: string): string {
    const v4: Mut3 = new Mut3(method17());
    let v18: any;
    closure6(v4, "{ ", undefined);
    v18 = undefined;
    let v37_1: any;
    closure6(v4, "old_path", undefined);
    v37_1 = undefined;
    let v56: any;
    closure6(v4, " = ", undefined);
    v56 = undefined;
    let v73: any;
    closure6(v4, v0, undefined);
    v73 = undefined;
    let v92: any;
    closure6(v4, "; ", undefined);
    v92 = undefined;
    let v111: any;
    closure6(v4, "new_path", undefined);
    v111 = undefined;
    let v128: any;
    closure6(v4, " = ", undefined);
    v128 = undefined;
    let v145: any;
    closure6(v4, v1, undefined);
    v145 = undefined;
    let v162: any;
    closure6(v4, "; ", undefined);
    v162 = undefined;
    let v181: any;
    closure6(v4, "ex", undefined);
    v181 = undefined;
    let v198: any;
    closure6(v4, " = ", undefined);
    v198 = undefined;
    let v215: any;
    closure6(v4, v2, undefined);
    v215 = undefined;
    let v234: any;
    closure6(v4, " }", undefined);
    v234 = undefined;
    return v4.l0;
}

export function method59(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: string, v10: string): string {
    const v11: string = method60(v8, v9, v10);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "move_file_async") + " / ") + v11);
}

export function closure30(v0: string, v1: string, v2: Error, unitVar: void): void {
    const v18 = (): void => {
        closure0(undefined, undefined);
    };
    let v19: any;
    v18();
    v19 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v60: US0_$union = patternInput[4].l0;
    let v341: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (3 >= find<US0_$union, int32>(v60, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v341 = US6_US6_1();
    }
    else {
        let v83: any;
        v18();
        v83 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v111: Option<int64> = patternInput_1[5];
        const v110: Mut4 = patternInput_1[4];
        const v109: Mut3 = patternInput_1[3];
        const v108: Mut2 = patternInput_1[2];
        const v107: Mut1 = patternInput_1[1];
        const v106: Mut0 = patternInput_1[0];
        const v167: string = method59(v106, v107, v108, v109, v110, v111, method11(v106, v107, v108, v109, v110, v111), method52(), method18(v1), method18(v0), toText(interpolate("%A%P()", [v2])));
        let v183: any;
        v18();
        v183 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v207: Mut1 = patternInput_2[1];
        const v206: Mut0 = patternInput_2[0];
        let v228: any;
        closure7(v206, undefined);
        v228 = undefined;
        closure8(undefined, v167);
        v207.l0(v167);
        v341 = US6_US6_0(v206, v207, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method57(v0: string, v1: string, v2: int64): Async<int64> {
    return singleton.Delay<int64>((): Async<int64> => singleton.TryWith<int64>(singleton.Delay<int64>((): Async<int64> => {
        method58(v0, v1);
        return singleton.Return<int64>(v2);
    }), (_arg: Error): Async<int64> => {
        let v29897: any;
        const v29542: boolean = equals(toInt64(op_Modulus(v2, 100n)), 0n);
        return singleton.Combine<int64>(v29542 ? ((v29897 = ((closure30(v0, v1, _arg, undefined), undefined)), singleton.Zero())) : singleton.Zero(), singleton.Delay<int64>((): Async<int64> => {
            const v30265: Async<void> = sleep(10);
            return singleton.Bind<void, int64>(v30265, (): Async<int64> => {
                const v30279: Async<int64> = method56(v0, v1, toInt64(op_Addition(v2, 1n)));
                return singleton.ReturnFrom<int64>(v30279);
            });
        }));
    }));
}

export function method56(v0: string, v1: string, v2: int64): Async<int64> {
    return defaultOf();
}

export function method55(v0: string, v1: string): Async<int64> {
    return method56(v0, v1, 0n);
}

export function closure29(v0: string, v1: string): Async<int64> {
    return method55(v0, v1);
}

export function closure28(unitVar: void, v0: string): ((arg0: string) => Async<int64>) {
    return (v: string): Async<int64> => closure29(v0, v);
}

export function closure33(unitVar: void, v0: int64): US11_$union {
    return US11_US11_0(v0);
}

export function method66(): ((arg0: int64) => US11_$union) {
    return (v: int64): US11_$union => closure33(undefined, v);
}

export function closure34(unitVar: void, v0: Error): US11_$union {
    return US11_US11_1(v0);
}

export function method67(): ((arg0: Error) => US11_$union) {
    return (v: Error): US11_$union => closure34(undefined, v);
}

export function closure32(unitVar: void, v0: FSharpChoice$2_$union<int64, Error>): US11_$union {
    return defaultOf();
}

export function method69(v0: ((arg0: FSharpChoice$2_$union<int64, Error>) => US11_$union), v1: Async<FSharpChoice$2_$union<int64, Error>>): Async<US11_$union> {
    return singleton.Delay<US11_$union>((): Async<US11_$union> => singleton.Bind<FSharpChoice$2_$union<int64, Error>, US11_$union>(v1, (_arg: FSharpChoice$2_$union<int64, Error>): Async<US11_$union> => {
        const v50_1: US11_$union = v0(_arg);
        return singleton.Return<US11_$union>(v50_1);
    }));
}

export function method68(v0: ((arg0: FSharpChoice$2_$union<int64, Error>) => US11_$union), v1: Async<FSharpChoice$2_$union<int64, Error>>): Async<US11_$union> {
    return method69(v0, v1);
}

export function closure35(unitVar: void, v0: US11_$union): US12_$union {
    if ((v0.tag as int32) === /* US11_1 */ 1) {
        return US12_US12_1(v0.fields[0] as any);
    }
    else {
        return US12_US12_0(v0.fields[0] as any);
    }
}

export function method71(v0: ((arg0: US11_$union) => US12_$union), v1: Async<US11_$union>): Async<US12_$union> {
    return singleton.Delay<US12_$union>((): Async<US12_$union> => singleton.Bind<US11_$union, US12_$union>(v1, (_arg: US11_$union): Async<US12_$union> => {
        const v50_1: US12_$union = v0(_arg);
        return singleton.Return<US12_$union>(v50_1);
    }));
}

export function method70(v0: ((arg0: US11_$union) => US12_$union), v1: Async<US11_$union>): Async<US12_$union> {
    return method71(v0, v1);
}

export function method73(v0: int32): string {
    const v2: Mut3 = new Mut3(method17());
    let v16_1: any;
    closure6(v2, "{ ", undefined);
    v16_1 = undefined;
    let v35_1: any;
    closure6(v2, "timeout", undefined);
    v35_1 = undefined;
    let v54: any;
    closure6(v2, " = ", undefined);
    v54 = undefined;
    let v74: any;
    closure6(v2, `${v0}`, undefined);
    v74 = undefined;
    let v93: any;
    closure6(v2, " }", undefined);
    v93 = undefined;
    return v2.l0;
}

export function method72(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32): string {
    const v9: string = method73(v8);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "async.run_with_timeout_async") + " / ") + v9);
}

export function closure37(v0: int32, unitVar: void): void {
    const v16_1 = (): void => {
        closure0(undefined, undefined);
    };
    let v17: any;
    v16_1();
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
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
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v109: Option<int64> = patternInput_1[5];
        const v108: Mut4 = patternInput_1[4];
        const v107: Mut3 = patternInput_1[3];
        const v106: Mut2 = patternInput_1[2];
        const v105: Mut1 = patternInput_1[1];
        const v104: Mut0 = patternInput_1[0];
        const v124: string = method72(v104, v105, v106, v107, v108, v109, method11(v104, v105, v106, v107, v108, v109), method31(), v0);
        let v140: any;
        v16_1();
        v140 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v164: Mut1 = patternInput_2[1];
        const v163: Mut0 = patternInput_2[0];
        let v185: any;
        closure7(v163, undefined);
        v185 = undefined;
        closure8(undefined, v124);
        v164.l0(v124);
        v298 = US6_US6_0(v163, v164, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method75(v0: int32, v1: string): string {
    const v3: Mut3 = new Mut3(method17());
    let v17: any;
    closure6(v3, "{ ", undefined);
    v17 = undefined;
    let v36_1: any;
    closure6(v3, "timeout", undefined);
    v36_1 = undefined;
    let v55: any;
    closure6(v3, " = ", undefined);
    v55 = undefined;
    let v75: any;
    closure6(v3, `${v0}`, undefined);
    v75 = undefined;
    let v94: any;
    closure6(v3, "; ", undefined);
    v94 = undefined;
    let v113: any;
    closure6(v3, "ex", undefined);
    v113 = undefined;
    let v130: any;
    closure6(v3, " = ", undefined);
    v130 = undefined;
    let v147: any;
    closure6(v3, v1, undefined);
    v147 = undefined;
    let v166: any;
    closure6(v3, " }", undefined);
    v166 = undefined;
    return v3.l0;
}

export function method74(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: string): string {
    const v10: string = method75(v8, v9);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "async.run_with_timeout_async**") + " / ") + v10);
}

export function closure38(v0: int32, v1: Error, unitVar: void): void {
    const v17 = (): void => {
        closure0(undefined, undefined);
    };
    let v18: any;
    v17();
    v18 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
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
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v110: Option<int64> = patternInput_1[5];
        const v109: Mut4 = patternInput_1[4];
        const v108: Mut3 = patternInput_1[3];
        const v107: Mut2 = patternInput_1[2];
        const v106: Mut1 = patternInput_1[1];
        const v105: Mut0 = patternInput_1[0];
        const v164: string = method74(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method49(), v0, toText(interpolate("%A%P()", [v1])));
        let v180: any;
        v17();
        v180 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v204: Mut1 = patternInput_2[1];
        const v203: Mut0 = patternInput_2[0];
        let v225: any;
        closure7(v203, undefined);
        v225 = undefined;
        closure8(undefined, v164);
        v204.l0(v164);
        v338 = US6_US6_0(v203, v204, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function closure36(v0: int32, v1: US12_$union): US2_$union {
    if ((v1.tag as int32) === /* US12_0 */ 0) {
        return US2_US2_0(v1.fields[0] as any);
    }
    else {
        const v4 = v1.fields[0] as any;
        const v6: string = toText(interpolate("%A%P()", [v4]));
        if (v6.indexOf("System.TimeoutException") >= 0) {
            let v328: any;
            closure37(v0, undefined);
            v328 = undefined;
            return US2_US2_1();
        }
        else {
            let v996: any;
            closure38(v0, v4, undefined);
            v996 = undefined;
            return US2_US2_1();
        }
    }
}

export function method77(v0: ((arg0: US12_$union) => US2_$union), v1: Async<US12_$union>): Async<US2_$union> {
    return singleton.Delay<US2_$union>((): Async<US2_$union> => singleton.Bind<US12_$union, US2_$union>(v1, (_arg: US12_$union): Async<US2_$union> => {
        const v50_1: US2_$union = v0(_arg);
        return singleton.Return<US2_$union>(v50_1);
    }));
}

export function method76(v0: ((arg0: US12_$union) => US2_$union), v1: Async<US12_$union>): Async<US2_$union> {
    return method77(v0, v1);
}

export function method65(v0: Async<int64>, v1: int32): Async<US2_$union> {
    return singleton.Delay<US2_$union>((): Async<US2_$union> => {
        const v963: Async<Async<int64>> = startChild<int64>(v0, v1);
        return singleton.Bind<Async<int64>, US2_$union>(v963, (_arg: Async<int64>): Async<US2_$union> => {
            const v1016: Async<US2_$union> = method76((v_2: US12_$union): US2_$union => closure36(v1, v_2), method70((v_1: US11_$union): US12_$union => closure35(undefined, v_1), method68((v: FSharpChoice$2_$union<int64, Error>): US11_$union => closure32(undefined, v), catchAsync<int64>(_arg))));
            return singleton.ReturnFrom<US2_$union>(v1016);
        });
    });
}

export function method64(v0: int32, v1: Async<int64>): Async<US2_$union> {
    return method65(v1, v0);
}

export function closure39(unitVar: void, v0: string): Option<string> {
    return v0;
}

export function method79(v0: ((arg0: string) => Option<string>), v1: Async<string>): Async<Option<string>> {
    return singleton.Delay<Option<string>>((): Async<Option<string>> => singleton.Bind<string, Option<string>>(v1, (_arg: string): Async<Option<string>> => {
        const v50_1: Option<string> = v0(_arg);
        return singleton.Return<Option<string>>(v50_1);
    }));
}

export function method78(v0: ((arg0: string) => Option<string>), v1: Async<string>): Async<Option<string>> {
    return method79(v0, v1);
}

export function method81(v0: int64, v1: string): string {
    const v3: Mut3 = new Mut3(method17());
    let v17: any;
    closure6(v3, "{ ", undefined);
    v17 = undefined;
    let v36_1: any;
    closure6(v3, "retry", undefined);
    v36_1 = undefined;
    let v55: any;
    closure6(v3, " = ", undefined);
    v55 = undefined;
    let v75: any;
    closure6(v3, `${v0}`, undefined);
    v75 = undefined;
    let v94: any;
    closure6(v3, "; ", undefined);
    v94 = undefined;
    let v113: any;
    closure6(v3, "ex", undefined);
    v113 = undefined;
    let v130: any;
    closure6(v3, " = ", undefined);
    v130 = undefined;
    let v147: any;
    closure6(v3, v1, undefined);
    v147 = undefined;
    let v166: any;
    closure6(v3, " }", undefined);
    v166 = undefined;
    return v3.l0;
}

export function method80(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int64, v9: string): string {
    const v10: string = method81(v8, v9);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.read_all_text_retry_async") + " / ") + v10);
}

export function closure40(v0: int64, v1: Error, unitVar: void): void {
    const v17 = (): void => {
        closure0(undefined, undefined);
    };
    let v18: any;
    v17();
    v18 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v59: US0_$union = patternInput[4].l0;
    let v338: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (1 >= find<US0_$union, int32>(v59, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v338 = US6_US6_1();
    }
    else {
        let v82: any;
        v17();
        v82 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v110: Option<int64> = patternInput_1[5];
        const v109: Mut4 = patternInput_1[4];
        const v108: Mut3 = patternInput_1[3];
        const v107: Mut2 = patternInput_1[2];
        const v106: Mut1 = patternInput_1[1];
        const v105: Mut0 = patternInput_1[0];
        const v164: string = method80(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method15(), v0, toText(interpolate("%A%P()", [v1])));
        let v180: any;
        v17();
        v180 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v204: Mut1 = patternInput_2[1];
        const v203: Mut0 = patternInput_2[0];
        let v225: any;
        closure7(v203, undefined);
        v225 = undefined;
        closure8(undefined, v164);
        v204.l0(v164);
        v338 = US6_US6_0(v203, v204, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method63(v0: string, v1: int64): Async<Option<string>> {
    return singleton.Delay<Option<string>>((): Async<Option<string>> => singleton.TryWith<Option<string>>(singleton.Delay<Option<string>>((): Async<Option<string>> => {
        let v29544: Async<void>;
        const v29522: boolean = compare_1(v1, 0n) > 0;
        return singleton.Combine<Option<string>>(v29522 ? ((v29544 = ignore<US2_$union>(method64(1000, method27(v0))), singleton.Bind<void, void>(v29544, (): Async<void> => {
            return singleton.Zero();
        }))) : singleton.Zero(), singleton.Delay<Option<string>>((): Async<Option<string>> => {
            const v29562: Async<Option<string>> = method78((v: string): Option<string> => closure39(undefined, v), method28(v0));
            return singleton.ReturnFrom<Option<string>>(v29562);
        }));
    }), (_arg_1: Error): Async<Option<string>> => {
        if (equals(v1, 0n) !== true) {
            let v30668: any;
            closure40(v1, _arg_1, undefined);
            v30668 = undefined;
            return singleton.Return<Option<string>>(undefined);
        }
        else {
            const v31027: Async<Option<string>> = method62(v0, toInt64(op_Addition(v1, 1n)));
            return singleton.ReturnFrom<Option<string>>(v31027);
        }
    }));
}

export function method62(v0: string, v1: int64): Async<Option<string>> {
    return method63(v0, v1);
}

export function method61(v0: string): Async<Option<string>> {
    return method62(v0, 0n);
}

export function closure31(unitVar: void, v0: string): Async<Option<string>> {
    return method61(v0);
}

export function closure42(unitVar: void, v0: any): US13_$union {
    return US13_US13_0(v0);
}

export function method84(): ((arg0: any) => US13_$union) {
    return (v: any): US13_$union => closure42(undefined, v);
}

export function method85(): string {
    return "hh:mm";
}

export function method86(): string {
    return "yyyyMMdd-HHmm-ssff-ffff-f";
}

export function method87(): string {
    return "hhmm";
}

export function method83(v0: string, v1: Date): string {
    const v2512: string = method86();
    const v2527: string = toString(v1, (v2512 === "") ? "M-d-y hh:mm:ss tt" : v2512);
    const v2558: any = defaultOf();
    let v2779: number;
    throw new Error(`date_time.get_utc_offset / target: ${US4_US4_5(US3_US3_0())}`);
    const v2800: uint8 = (hours(v2779) > 0) ? 1 : 0;
    const v2801: string = method87();
    const v3162 = `${v2800}${toString_1(v2779, "c", {})}`;
    const v3165: string = v0;
    const v3183: int32 = (v2527.length + v3162.length) | 0;
    const v3204: int32 = (v3165.length - 1) | 0;
    return parse(concat(v2527, v3162, ...v3165.slice(v3183, v3204 + 1)));
}

export function method89(): string {
    throw new Error(`file_system.get_temp_path / target: ${US4_US4_5(US3_US3_0())}`);
}

export function method90(): string {
    return "!create_temp_path_";
}

export function method91(v0: string, v1: string): string {
    const v272: IPathJoin = path;
    return v272.join(v0, v1);
}

export function method93(): string {
    return "CARGO_PKG_NAME";
}

export function method92(): string {
    throw new Error(`env.get_entry_assembly_name / target: ${US4_US4_5(US3_US3_0())}`);
}

export function method88(v0: string): string {
    return method91(method91(method91(method89(), method90()), method92()), v0);
}

export function method82(): string {
    const v105: Date = now();
    return method88(method83(newGuid(), v105));
}

export function closure41(unitVar: void, unitVar_1: void): string {
    return method82();
}

export function closure44(unitVar: void, v0: any): any {
    return defaultOf();
}

export function method95(): ((arg0: any) => any) {
    return (v: any): any => closure44(undefined, v);
}

export function closure45(unitVar: void, unitVar_1: void): US14_$union {
    return US14_US14_0();
}

export function method96(): (() => US14_$union) {
    return (): US14_$union => closure45(undefined, undefined);
}

export function closure46(unitVar: void, v0: any): US14_$union {
    return US14_US14_1(v0);
}

export function method97(): ((arg0: any) => US14_$union) {
    return (v: any): US14_$union => closure46(undefined, v);
}

export function method99(v0: string, v1: any): string {
    const v3: Mut3 = new Mut3(method17());
    let v17: any;
    closure6(v3, "{ ", undefined);
    v17 = undefined;
    let v36_1: any;
    closure6(v3, "dir", undefined);
    v36_1 = undefined;
    let v55: any;
    closure6(v3, " = ", undefined);
    v55 = undefined;
    let v72: any;
    closure6(v3, v0, undefined);
    v72 = undefined;
    let v91: any;
    closure6(v3, "; ", undefined);
    v91 = undefined;
    let v110: any;
    closure6(v3, "error", undefined);
    v110 = undefined;
    let v127: any;
    closure6(v3, " = ", undefined);
    v127 = undefined;
    let v186: any;
    closure6(v3, toText(interpolate("%A%P()", [v1])), undefined);
    v186 = undefined;
    let v205: any;
    closure6(v3, " }", undefined);
    v205 = undefined;
    return v3.l0;
}

export function method98(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: any): string {
    const v10: string = method99(v8, v9);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v10);
}

export function closure47(v0: string, v1: any, unitVar: void): void {
    const v17 = (): void => {
        closure0(undefined, undefined);
    };
    let v18: any;
    v17();
    v18 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v59: US0_$union = patternInput[4].l0;
    let v299: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (4 >= find<US0_$union, int32>(v59, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v299 = US6_US6_1();
    }
    else {
        let v82: any;
        v17();
        v82 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v110: Option<int64> = patternInput_1[5];
        const v109: Mut4 = patternInput_1[4];
        const v108: Mut3 = patternInput_1[3];
        const v107: Mut2 = patternInput_1[2];
        const v106: Mut1 = patternInput_1[1];
        const v105: Mut0 = patternInput_1[0];
        const v125: string = method98(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method49(), v0, v1);
        let v141: any;
        v17();
        v141 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v165: Mut1 = patternInput_2[1];
        const v164: Mut0 = patternInput_2[0];
        let v186: any;
        closure7(v164, undefined);
        v186 = undefined;
        closure8(undefined, v125);
        v165.l0(v125);
        v299 = US6_US6_0(v164, v165, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method101(v0: string): string {
    const v2: Mut3 = new Mut3(method17());
    let v16_1: any;
    closure6(v2, "{ ", undefined);
    v16_1 = undefined;
    let v35_1: any;
    closure6(v2, "dir", undefined);
    v35_1 = undefined;
    let v54: any;
    closure6(v2, " = ", undefined);
    v54 = undefined;
    let v71: any;
    closure6(v2, v0, undefined);
    v71 = undefined;
    let v90: any;
    closure6(v2, " }", undefined);
    v90 = undefined;
    return v2.l0;
}

export function method100(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string): string {
    const v9: string = method101(v8);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v9);
}

export function closure48(v0: string, unitVar: void): void {
    const v16_1 = (): void => {
        closure0(undefined, undefined);
    };
    let v17: any;
    v16_1();
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
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
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v109: Option<int64> = patternInput_1[5];
        const v108: Mut4 = patternInput_1[4];
        const v107: Mut3 = patternInput_1[3];
        const v106: Mut2 = patternInput_1[2];
        const v105: Mut1 = patternInput_1[1];
        const v104: Mut0 = patternInput_1[0];
        const v124: string = method100(v104, v105, v106, v107, v108, v109, method11(v104, v105, v106, v107, v108, v109), method31(), v0);
        let v140: any;
        v16_1();
        v140 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v164: Mut1 = patternInput_2[1];
        const v163: Mut0 = patternInput_2[0];
        let v185: any;
        closure7(v163, undefined);
        v185 = undefined;
        closure8(undefined, v124);
        v164.l0(v124);
        v298 = US6_US6_0(v163, v164, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function closure49(v0: string, unitVar: void): void {
    method9(true, v0);
}

export function method102(v0: string): (() => void) {
    return (): void => {
        closure49(v0, undefined);
    };
}

export function method103(v0: string): (() => void) {
    return (): void => {
        closure49(v0, undefined);
    };
}

export function method104(v0: string): boolean {
    return defaultOf();
}

export function method106(v0: string, v1: string): string {
    const v3: Mut3 = new Mut3(method17());
    let v17: any;
    closure6(v3, "{ ", undefined);
    v17 = undefined;
    let v36_1: any;
    closure6(v3, "dir", undefined);
    v36_1 = undefined;
    let v55: any;
    closure6(v3, " = ", undefined);
    v55 = undefined;
    let v72: any;
    closure6(v3, v0, undefined);
    v72 = undefined;
    let v91: any;
    closure6(v3, "; ", undefined);
    v91 = undefined;
    let v110: any;
    closure6(v3, "result", undefined);
    v110 = undefined;
    let v127: any;
    closure6(v3, " = ", undefined);
    v127 = undefined;
    let v144: any;
    closure6(v3, v1, undefined);
    v144 = undefined;
    let v163: any;
    closure6(v3, " }", undefined);
    v163 = undefined;
    return v3.l0;
}

export function method105(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: string): string {
    const v10: string = method106(v8, v9);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.create_dir") + " / ") + v10);
}

export function closure50(v0: string, v1: string, unitVar: void): void {
    const v17 = (): void => {
        closure0(undefined, undefined);
    };
    let v18: any;
    v17();
    v18 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v59: US0_$union = patternInput[4].l0;
    let v299: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (1 >= find<US0_$union, int32>(v59, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v299 = US6_US6_1();
    }
    else {
        let v82: any;
        v17();
        v82 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v110: Option<int64> = patternInput_1[5];
        const v109: Mut4 = patternInput_1[4];
        const v108: Mut3 = patternInput_1[3];
        const v107: Mut2 = patternInput_1[2];
        const v106: Mut1 = patternInput_1[1];
        const v105: Mut0 = patternInput_1[0];
        const v125: string = method105(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method15(), v0, v1);
        let v141: any;
        v17();
        v141 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v165: Mut1 = patternInput_2[1];
        const v164: Mut0 = patternInput_2[0];
        let v186: any;
        closure7(v164, undefined);
        v186 = undefined;
        closure8(undefined, v125);
        v165.l0(v125);
        v299 = US6_US6_0(v164, v165, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function closure51(v0: string, unitVar: void): void {
    const v20: Async<void> = ignore<int64>(method6(v0));
    defaultOf();
}

export function method107(v0: string): (() => void) {
    return (): void => {
        closure51(v0, undefined);
    };
}

export function method108(v0: string): (() => void) {
    return (): void => {
        closure51(v0, undefined);
    };
}

export function method94(v0: string): IDisposable {
    const v2052: boolean = method104(v0);
    const v2084: boolean = defaultOf();
    if (v2084 === false) {
        let v2452: any;
        closure50(v0, toText(interpolate("%A%P()", [{
            CreationTime: defaultOf(),
            Exists: v2084,
        }])), undefined);
        v2452 = undefined;
    }
    const v2778: (() => void) = method108(v0);
    return {
        Dispose(): void {
            v2778();
        },
    };
}

export function closure43(unitVar: void, unitVar_1: void): [string, IDisposable] {
    const v0: string = method82();
    return [v0, method94(v0)] as [string, IDisposable];
}

export function closure53(v0: int32, v1: string, v2: int32, v3: string): string {
    if (v2 >= v0) {
        return v3;
    }
    else {
        return method110(v0, v1, v2 + 1)(v3 + v1);
    }
}

export function method110(v0: int32, v1: string, v2: int32): ((arg0: string) => string) {
    return (v: string): string => closure53(v0, v1, v2, v);
}

export function method109(v0: string): string {
    const v3 = "0";
    const v13: string = method110(32 - v0.length, v3, 0)("") + v0;
    const v756 = 0;
    const v777: int32 = (8 - 1) | 0;
    const v790 = 8;
    const v811: int32 = (12 - 1) | 0;
    const v824 = 12;
    const v845: int32 = (16 - 1) | 0;
    const v858 = 16;
    const v879: int32 = (20 - 1) | 0;
    const v892 = 20;
    const v913: int32 = (32 - 1) | 0;
    return parse((((((((v13.slice(v756, v777 + 1) + "-") + v13.slice(v790, v811 + 1)) + "-") + v13.slice(v824, v845 + 1)) + "-") + v13.slice(v858, v879 + 1)) + "-") + v13.slice(v892, v913 + 1));
}

export function closure52(unitVar: void, v0: string): [string, IDisposable] {
    const v2: string = method88(method109(v0));
    return [v2, method94(v2)] as [string, IDisposable];
}

export function closure54(unitVar: void, unitVar_1: void): string {
    return "c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral";
}

export function closure56(unitVar: void, v0: any): US15_$union {
    return US15_US15_0(v0);
}

export function method114(): ((arg0: any) => US15_$union) {
    return (v: any): US15_$union => closure56(undefined, v);
}

export function closure57(unitVar: void, v0: string): US15_$union {
    return US15_US15_1(v0);
}

export function method115(): ((arg0: string) => US15_$union) {
    return (v: string): US15_$union => closure57(undefined, v);
}

export function method118(v0: string): Option<string> {
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

export function method119(v0: string): string {
    const v2: Mut3 = new Mut3(method17());
    let v14_1: any;
    closure6(v2, v0, undefined);
    v14_1 = undefined;
    return v2.l0;
}

export function method117(v0: string, v1: ((arg0: uint8, arg1: string) => FSharpResult$2_$union<any, any>), v2: uint8, v3: string, v4: string): FSharpResult$2_$union<any, any> {
    const v5: string = method18(v4);
    const v6: Option<string> = method118(v4);
    const v31_1: US5_$union = defaultArg(map<string, US5_$union>(method5(), v6), US5_US5_1());
    const v35_1: string = method119(v3);
    if (v2 >= 11) {
        return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`path: ${v0} / n: ${v2} / path': ${v4} / name: ${v5}`));
    }
    else if ((v31_1.tag as int32) === /* US5_0 */ 0) {
        const v91 = v31_1.fields[0] as any;
        if (v4 !== "") {
            const v100: FSharpResult$2_$union<any, any> = v1(v2 + 1, v91);
            const v101: ((arg0: any) => string) = method45();
            const v114: FSharpResult$2_$union<any, string> = ((v100.tag as int32) === /* Error */ 1) ? FSharpResult$2_Error<any, string>(v101(v100.fields[0] as any)) : FSharpResult$2_Ok<any, string>(v100.fields[0] as any);
            const v117: ((arg0: any) => US15_$union) = method114();
            const v118: ((arg0: string) => US15_$union) = method115();
            const v120: US15_$union = ((v114.tag as int32) === /* Error */ 1) ? v118(v114.fields[0] as any) : v117(v114.fields[0] as any);
            if ((v120.tag as int32) === /* US15_0 */ 0) {
                return FSharpResult$2_Ok<any, any>(method91(toString_2(v120.fields[0] as any), v5));
            }
            else {
                return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`error': ${v120.fields[0] as any} / error: ${v35_1} / name: ${v5}`));
            }
        }
        else {
            return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v35_1} / path': ${v4} / name: ${v5}`));
        }
    }
    else {
        return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v35_1} / path': ${v4} / name: ${v5}`));
    }
}

export function method116(v0: string, v1: uint8, v2: string): FSharpResult$2_$union<any, any> {
    return defaultOf();
}

export function closure59(v0: string, v1: uint8, v2: string): FSharpResult$2_$union<any, any> {
    return method116(v0, v1, v2);
}

export function closure58(v0: string, v1: uint8): ((arg0: string) => FSharpResult$2_$union<any, any>) {
    return (v: string): FSharpResult$2_$union<any, any> => closure59(v0, v1, v);
}

export function method120(v0: string, v1: ((arg0: uint8, arg1: string) => FSharpResult$2_$union<any, any>), v2: uint8, v3: string): FSharpResult$2_$union<any, any> {
    const v4: string = method18(v0);
    const v5: Option<string> = method118(v0);
    const v30: US5_$union = defaultArg(map<string, US5_$union>(method5(), v5), US5_US5_1());
    const v34_1: string = method119(v3);
    if (v2 >= 11) {
        return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`path: ${v0} / n: ${v2} / path': ${v0} / name: ${v4}`));
    }
    else if ((v30.tag as int32) === /* US5_0 */ 0) {
        const v90 = v30.fields[0] as any;
        if (v0 !== "") {
            const v99: FSharpResult$2_$union<any, any> = v1(v2 + 1, v90);
            const v100: ((arg0: any) => string) = method45();
            const v113: FSharpResult$2_$union<any, string> = ((v99.tag as int32) === /* Error */ 1) ? FSharpResult$2_Error<any, string>(v100(v99.fields[0] as any)) : FSharpResult$2_Ok<any, string>(v99.fields[0] as any);
            const v116: ((arg0: any) => US15_$union) = method114();
            const v117: ((arg0: string) => US15_$union) = method115();
            const v119: US15_$union = ((v113.tag as int32) === /* Error */ 1) ? v117(v113.fields[0] as any) : v116(v113.fields[0] as any);
            if ((v119.tag as int32) === /* US15_0 */ 0) {
                return FSharpResult$2_Ok<any, any>(method91(toString_2(v119.fields[0] as any), v4));
            }
            else {
                return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`error': ${v119.fields[0] as any} / error: ${v34_1} / name: ${v4}`));
            }
        }
        else {
            return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v34_1} / path': ${v0} / name: ${v4}`));
        }
    }
    else {
        return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v34_1} / path': ${v0} / name: ${v4}`));
    }
}

export function method113(v0: string, v1: uint8): FSharpResult$2_$union<any, any> {
    return defaultOf();
}

export function method122(v0: boolean): int32 {
    return defaultOf();
}

export function method123(): int32 {
    return defaultOf();
}

export function method124(v0: int32, v1: int32): boolean {
    return defaultOf();
}

export function method126(v0: string, v1: ((arg0: uint8, arg1: string) => FSharpResult$2_$union<any, any>), v2: uint8, v3: any, v4: string): FSharpResult$2_$union<any, any> {
    const v5: string = method18(v4);
    const v6: Option<string> = method118(v4);
    const v31_1: US5_$union = defaultArg(map<string, US5_$union>(method5(), v6), US5_US5_1());
    const v35_1: string = method46(v3);
    if (v2 >= 11) {
        return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`path: ${v0} / n: ${v2} / path': ${v4} / name: ${v5}`));
    }
    else if ((v31_1.tag as int32) === /* US5_0 */ 0) {
        const v91 = v31_1.fields[0] as any;
        if (v4 !== "") {
            const v100: FSharpResult$2_$union<any, any> = v1(v2 + 1, v91);
            const v101: ((arg0: any) => string) = method45();
            const v114: FSharpResult$2_$union<any, string> = ((v100.tag as int32) === /* Error */ 1) ? FSharpResult$2_Error<any, string>(v101(v100.fields[0] as any)) : FSharpResult$2_Ok<any, string>(v100.fields[0] as any);
            const v117: ((arg0: any) => US15_$union) = method114();
            const v118: ((arg0: string) => US15_$union) = method115();
            const v120: US15_$union = ((v114.tag as int32) === /* Error */ 1) ? v118(v114.fields[0] as any) : v117(v114.fields[0] as any);
            if ((v120.tag as int32) === /* US15_0 */ 0) {
                return FSharpResult$2_Ok<any, any>(method91(toString_2(v120.fields[0] as any), v5));
            }
            else {
                return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`error': ${v120.fields[0] as any} / error: ${v35_1} / name: ${v5}`));
            }
        }
        else {
            return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v35_1} / path': ${v4} / name: ${v5}`));
        }
    }
    else {
        return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v35_1} / path': ${v4} / name: ${v5}`));
    }
}

export function method125(v0: string, v1: uint8, v2: string): FSharpResult$2_$union<any, any> {
    const v45_1: int32 = method122(defaultOf()) | 0;
    const v47_1: boolean = method124(method123(), v45_1);
    if (v47_1) {
        const v66: boolean = defaultOf();
        return FSharpResult$2_Ok<any, any>(defaultOf());
    }
    else {
        return method126(v0, uncurry2((v: uint8): ((arg0: string) => FSharpResult$2_$union<any, any>) => closure60(v0, v)), v1, "file_system.read_link / Fsharp / The file or directory is not a reparse point. / " + (`path: ${v0} / result: ${v47_1} / path': ${v2} / n: ${v1}`), v2);
    }
}

export function closure61(v0: string, v1: uint8, v2: string): FSharpResult$2_$union<any, any> {
    return method125(v0, v1, v2);
}

export function closure60(v0: string, v1: uint8): ((arg0: string) => FSharpResult$2_$union<any, any>) {
    return (v: string): FSharpResult$2_$union<any, any> => closure61(v0, v1, v);
}

export function method127(v0: string, v1: ((arg0: uint8, arg1: string) => FSharpResult$2_$union<any, any>), v2: uint8, v3: any): FSharpResult$2_$union<any, any> {
    const v4: string = method18(v0);
    const v5: Option<string> = method118(v0);
    const v30: US5_$union = defaultArg(map<string, US5_$union>(method5(), v5), US5_US5_1());
    const v34_1: string = method46(v3);
    if (v2 >= 11) {
        return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`path: ${v0} / n: ${v2} / path': ${v0} / name: ${v4}`));
    }
    else if ((v30.tag as int32) === /* US5_0 */ 0) {
        const v90 = v30.fields[0] as any;
        if (v0 !== "") {
            const v99: FSharpResult$2_$union<any, any> = v1(v2 + 1, v90);
            const v100: ((arg0: any) => string) = method45();
            const v113: FSharpResult$2_$union<any, string> = ((v99.tag as int32) === /* Error */ 1) ? FSharpResult$2_Error<any, string>(v100(v99.fields[0] as any)) : FSharpResult$2_Ok<any, string>(v99.fields[0] as any);
            const v116: ((arg0: any) => US15_$union) = method114();
            const v117: ((arg0: string) => US15_$union) = method115();
            const v119: US15_$union = ((v113.tag as int32) === /* Error */ 1) ? v117(v113.fields[0] as any) : v116(v113.fields[0] as any);
            if ((v119.tag as int32) === /* US15_0 */ 0) {
                return FSharpResult$2_Ok<any, any>(method91(toString_2(v119.fields[0] as any), v4));
            }
            else {
                return FSharpResult$2_Error<any, any>("file_system.read_link / " + (`error': ${v119.fields[0] as any} / error: ${v34_1} / name: ${v4}`));
            }
        }
        else {
            return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v34_1} / path': ${v0} / name: ${v4}`));
        }
    }
    else {
        return FSharpResult$2_Error<any, any>("file_system.read_link / run / The file or directory is not a reparse point. / " + (`path: ${v0} / error: ${v34_1} / path': ${v0} / name: ${v4}`));
    }
}

export function method121(v0: string, v1: uint8): FSharpResult$2_$union<any, any> {
    const v44_1: int32 = method122(defaultOf()) | 0;
    const v46_1: boolean = method124(method123(), v44_1);
    if (v46_1) {
        const v65: boolean = defaultOf();
        return FSharpResult$2_Ok<any, any>(defaultOf());
    }
    else {
        return method127(v0, uncurry2((v: uint8): ((arg0: string) => FSharpResult$2_$union<any, any>) => closure60(v0, v)), v1, "file_system.read_link / Fsharp / The file or directory is not a reparse point. / " + (`path: ${v0} / result: ${v46_1} / path': ${v0} / n: ${v1}`));
    }
}

export function method112(v0: string): FSharpResult$2_$union<any, any> {
    return method121(v0, 0);
}

export function closure62(unitVar: void, v0: any): US16_$union {
    return US16_US16_0(v0);
}

export function method128(): ((arg0: any) => US16_$union) {
    return (v: any): US16_$union => closure62(undefined, v);
}

export function method130(v0: string): string {
    return v0;
}

export function method131(): string {
    return "";
}

export function method129(v0: string, v1: string, v2: string): string {
    return method131();
}

export function method111(v0: string): string {
    let _arg: string;
    if (v0 === "") {
        return "";
    }
    else {
        const v3: FSharpResult$2_$union<any, any> = method112(v0);
        const v12: Option<any> = ((v3.tag as int32) === /* Error */ 1) ? undefined : (v3.fields[0] as any);
        const v43_1: US16_$union = defaultArg(map<any, US16_$union>(method128(), v12), US16_US16_1());
        const v89: string = ((v43_1.tag as int32) === /* US16_0 */ 0) ? toString_2(v43_1.fields[0] as any) : v0;
        const v94: string = method129("^\\\\\\\\\\?\\\\", "", (v89 === "") ? v0 : v89);
        if (v94.length < 2) {
            return v0;
        }
        else {
            return replace(concat((_arg = v94[0], _arg.toLocaleLowerCase()), ...v94.slice(1, v94.length)), "\\", "/");
        }
    }
}

export function closure55(unitVar: void, v0: string): string {
    return method111(v0);
}

export function method133(): string {
    const v105: IFs = fs;
    return fs.realpathSync('.');
}

export function method134(v0: int32, v1: Mut5): boolean {
    return v1.l0 < v0;
}

export function method135(v0: int32, v1: Mut6): boolean {
    return v1.l0 < v0;
}

export function method136(): string {
    return "/";
}

export function method137(v0: string): string {
    return v0;
}

export function method132(v0: string): string {
    return defaultOf();
}

export function closure63(unitVar: void, v0: string): string {
    return method132(v0);
}

export function method138(v0: string): string {
    return method111(method132(v0));
}

export function closure64(unitVar: void, v0: string): string {
    return method138(v0);
}

export function closure65(unitVar: void, v0: string): string {
    return concat("file:///", ...trimStart(v0, ...["/"]));
}

export function closure67(unitVar: void, v0: string): boolean {
    return method35(v0);
}

export function closure68(unitVar: void, v0: string): boolean {
    return method10(v0);
}

export function method142(v0_mut: string, v1_mut: string, v2_mut: boolean, v3_mut: ((arg0: string) => boolean), v4_mut: string): US18_$union {
    method142:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: boolean = v2_mut, v3: ((arg0: string) => boolean) = v3_mut, v4: string = v4_mut;
        if (v3(method91(v4, v0))) {
            return US18_US18_0(v4);
        }
        else {
            const v8: Option<string> = method118(v4);
            const v33_1: US5_$union = defaultArg(map<string, US5_$union>(method5(), v8), US5_US5_1());
            if ((v33_1.tag as int32) === /* US5_0 */ 0) {
                v0_mut = v0;
                v1_mut = v1;
                v2_mut = v2;
                v3_mut = v3;
                v4_mut = (v33_1.fields[0] as any);
                continue method142;
            }
            else {
                return US18_US18_1(concat("file_system.find_parent / No parent for ", ...(v2 ? "file" : "dir")) + (` '${v0}' at '${v1}' (until '${v4}')`));
            }
        }
        break;
    }
}

export function method141(v0: string, v1: string, v2: boolean, v3: ((arg0: string) => boolean)): US18_$union {
    if (v3(method91(v1, v0))) {
        return US18_US18_0(v1);
    }
    else {
        const v7: Option<string> = method118(v1);
        const v32_1: US5_$union = defaultArg(map<string, US5_$union>(method5(), v7), US5_US5_1());
        if ((v32_1.tag as int32) === /* US5_0 */ 0) {
            return method142(v0, v1, v2, v3, v32_1.fields[0] as any);
        }
        else {
            return US18_US18_1(concat("file_system.find_parent / No parent for ", ...(v2 ? "file" : "dir")) + (` '${v0}' at '${v1}' (until '${v1}')`));
        }
    }
}

export function method140(v0: US17_$union, v1: string, v2: string): US18_$union {
    const v3: boolean = (v0.tag as int32) === /* US17_0 */ 0;
    return method141(v1, v2, v3, v3 ? ((v: string): boolean => closure67(undefined, v)) : ((v_1: string): boolean => closure68(undefined, v_1)));
}

export function method144(v0: string, v1: string): string {
    const v3: Mut3 = new Mut3(method17());
    let v17: any;
    closure6(v3, "{ ", undefined);
    v17 = undefined;
    let v36_1: any;
    closure6(v3, "dir", undefined);
    v36_1 = undefined;
    let v55: any;
    closure6(v3, " = ", undefined);
    v55 = undefined;
    let v72: any;
    closure6(v3, v0, undefined);
    v72 = undefined;
    let v91: any;
    closure6(v3, "; ", undefined);
    v91 = undefined;
    let v110: any;
    closure6(v3, "error", undefined);
    v110 = undefined;
    let v127: any;
    closure6(v3, " = ", undefined);
    v127 = undefined;
    let v144: any;
    closure6(v3, v1, undefined);
    v144 = undefined;
    let v163: any;
    closure6(v3, " }", undefined);
    v163 = undefined;
    return v3.l0;
}

export function method143(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: string): string {
    const v10: string = method144(v8, v9);
    return method21((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "file_system.get_workspace_root") + " / ") + v10);
}

export function closure69(v0: string, v1: string, unitVar: void): void {
    const v17 = (): void => {
        closure0(undefined, undefined);
    };
    let v18: any;
    v17();
    v18 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v59: US0_$union = patternInput[4].l0;
    let v299: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (3 >= find<US0_$union, int32>(v59, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v299 = US6_US6_1();
    }
    else {
        let v82: any;
        v17();
        v82 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v110: Option<int64> = patternInput_1[5];
        const v109: Mut4 = patternInput_1[4];
        const v108: Mut3 = patternInput_1[3];
        const v107: Mut2 = patternInput_1[2];
        const v106: Mut1 = patternInput_1[1];
        const v105: Mut0 = patternInput_1[0];
        const v125: string = method143(v105, v106, v107, v108, v109, v110, method11(v105, v106, v107, v108, v109, v110), method52(), v0, v1);
        let v141: any;
        v17();
        v141 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
        const v165: Mut1 = patternInput_2[1];
        const v164: Mut0 = patternInput_2[0];
        let v186: any;
        closure7(v164, undefined);
        v186 = undefined;
        closure8(undefined, v125);
        v165.l0(v125);
        v299 = US6_US6_0(v164, v165, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method139(v0: string): US5_$union {
    const v5: US18_$union = method140(US17_US17_1(), method91("spiral", "workspace"), v0);
    if ((v5.tag as int32) === /* US18_0 */ 0) {
        return US5_US5_0(method111(v5.fields[0] as any));
    }
    else {
        let v323: any;
        closure69(v0, v5.fields[0] as any, undefined);
        v323 = undefined;
        return US5_US5_1();
    }
}

export function closure66(unitVar: void, unitVar_1: void): string {
    let v25: US5_$union;
    const v1: US5_$union = method139(method133());
    const v7: US5_$union = ((v1.tag as int32) === /* US5_0 */ 0) ? US5_US5_0(v1.fields[0] as any) : method139("c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral");
    const v13: US5_$union = ((v7.tag as int32) === /* US5_0 */ 0) ? US5_US5_0(v7.fields[0] as any) : method139("/workspaces");
    let v17: string;
    if ((v13.tag as int32) === /* US5_0 */ 0) {
        v17 = (v13.fields[0] as any);
    }
    else {
        throw new Error("Option does not have a value.");
    }
    return method91(("deps" === method18(v17)) ? ((v25 = method139(value_10(method118(v17))), ((v25.tag as int32) === /* US5_0 */ 0) ? (v25.fields[0] as any) : (() => {
        throw new Error("Option does not have a value.");
    })())) : v17, "polyglot");
}

export function closure71(v0: Error, unitVar: void): Error {
    return v0;
}

export function method145(v0: string): void {
}

export function closure70(unitVar: void, v0: string): void {
    method145(v0);
}

export function closure72(unitVar: void, v0: boolean): void {
    let v17: any;
    closure0(undefined, undefined);
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_10(TraceState_trace_state());
    const v60: ((arg0: string) => void) = v0 ? ((v: string): void => {
        closure70(undefined, v);
    }) : ((v_1: string): void => {
        closure2(undefined, v_1);
    });
    patternInput[1].l0 = v60;
}

export function method146(v0: string, v1: string): void {
    let v16_1: FSharpResult$2_$union<any, any>;
    if (method10(v0) === false) {
        const v4: IDisposable = method94(v0);
    }
    const v9: string = defaultArg(method118(v1), "");
    if (method10(v9) === false) {
        const v14_1: IDisposable = method94(v9);
    }
    if (method10(v1) && ((v16_1 = method112(v1), true))) {
        method9(true, v1);
    }
    if (method10(v1) === false) {
    }
}

export function closure74(v0: string, v1: string): void {
    method146(v0, v1);
}

export function closure73(unitVar: void, v0: string): ((arg0: string) => void) {
    return (v: string): void => {
        closure74(v0, v);
    };
}

export function closure76(v0: string, v1: string): string {
    return method91(v0, v1);
}

export function closure75(unitVar: void, v0: string): ((arg0: string) => string) {
    return (v: string): string => closure76(v0, v);
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

export const v32 = (v: US7_$union): ((arg0: string) => Async<int64>) => closure10(undefined, v);

export function wait_for_file_access(x: US7_$union): ((arg0: string) => Async<int64>) {
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

export const v41 = (): string => closure41(undefined, undefined);

export function create_temp_path(): string {
    return v41();
}

export const v42 = (): [string, IDisposable] => closure43(undefined, undefined);

export function create_temp_dir(): [string, IDisposable] {
    return v42();
}

export const v43 = (v: string): [string, IDisposable] => closure52(undefined, v);

export function create_temp_dir$0027(x: string): [string, IDisposable] {
    return v43(x);
}

export const v44 = (): string => closure54(undefined, undefined);

export function get_source_directory(): string {
    return v44();
}

export const v45 = (v: string): string => closure55(undefined, v);

export function normalize_path(x: string): string {
    return v45(x);
}

export const v46 = (v: string): string => closure63(undefined, v);

export function get_full_path(x: string): string {
    return v46(x);
}

export const v47 = (v: string): string => closure64(undefined, v);

export function standardize_path(x: string): string {
    return v47(x);
}

export const v48 = (v: string): string => closure65(undefined, v);

export function new_file_uri(x: string): string {
    return v48(x);
}

export const v49 = (): string => closure66(undefined, undefined);

export function get_workspace_root(): string {
    return v49();
}

export const v50 = (v: string): void => {
    closure70(undefined, v);
};

export function trace_file(x: string): void {
    v50(x);
}

export const v51 = (v: boolean): void => {
    closure72(undefined, v);
};

export function init_trace_file(x: boolean): void {
    v51(x);
}

export const v52 = (v: string): ((arg0: string) => void) => closure73(undefined, v);

export function link_directory(x: string): ((arg0: string) => void) {
    return v52(x);
}

export const v53 = (v: string): ((arg0: string) => string) => closure75(undefined, v);

export function op_LessDivideGreater(x: string): ((arg0: string) => string) {
    return v53(x);
}


