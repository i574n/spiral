import { defaultOf, int64ToString, compare, IComparable, IEquatable, createAtom } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Util.js";
import { some, map, defaultArg, value as value_12, Option } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Option.js";
import { equals, fromInt32, toInt32, compare as compare_1, op_Addition, op_Subtraction, fromInt64, toInt64, int64 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/BigInt.js";
import { Record, Union } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Types.js";
import { array_type, option_type, tuple_type, int32_type, class_type, char_type, bool_type, lambda_type, unit_type, string_type, record_type, int64_type, union_type, TypeInfo } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Reflection.js";
import { int32 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Int32.js";
import { singleton, Async } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/AsyncBuilder.js";
import { toString, create, now, getTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Date.js";
import { ofSeq, find } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Map.js";
import { milliseconds, seconds, minutes, hours, fromTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/TimeSpan.js";
import { join, concat, interpolate, toText, trimStart, trimEnd } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/String.js";
import { StringBuilder_$ctor_Z721C83C5, StringBuilder__Append_Z721C83C5, StringBuilder__Clear } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/System.Text.js";
import { awaitTask, startImmediate } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Async.js";
import { toArray, empty, FSharpList, cons } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/List.js";
import { delay } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Seq.js";
import { FSharpResult$2_$union, FSharpResult$2_Error, FSharpResult$2_Ok } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Result.js";

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
    return union_type("Runtime.US0", [], US0, () => [[], [], [], [], []]);
}

export class Mut0 extends Record implements IEquatable<Mut0>, IComparable<Mut0> {
    l0: int64;
    constructor(l0: int64) {
        super();
        this.l0 = l0;
    }
}

export function Mut0_$reflection(): TypeInfo {
    return record_type("Runtime.Mut0", [], Mut0, () => [["l0", int64_type]]);
}

export class Mut1 extends Record {
    l0: ((arg0: string) => void);
    constructor(l0: ((arg0: string) => void)) {
        super();
        this.l0 = l0;
    }
}

export function Mut1_$reflection(): TypeInfo {
    return record_type("Runtime.Mut1", [], Mut1, () => [["l0", lambda_type(string_type, unit_type)]]);
}

export class Mut2 extends Record implements IEquatable<Mut2>, IComparable<Mut2> {
    l0: boolean;
    constructor(l0: boolean) {
        super();
        this.l0 = l0;
    }
}

export function Mut2_$reflection(): TypeInfo {
    return record_type("Runtime.Mut2", [], Mut2, () => [["l0", bool_type]]);
}

export class Mut3 extends Record implements IEquatable<Mut3>, IComparable<Mut3> {
    l0: string;
    constructor(l0: string) {
        super();
        this.l0 = l0;
    }
}

export function Mut3_$reflection(): TypeInfo {
    return record_type("Runtime.Mut3", [], Mut3, () => [["l0", string_type]]);
}

export class Mut4 extends Record implements IEquatable<Mut4>, IComparable<Mut4> {
    l0: US0_$union;
    constructor(l0: US0_$union) {
        super();
        this.l0 = l0;
    }
}

export function Mut4_$reflection(): TypeInfo {
    return record_type("Runtime.Mut4", [], Mut4, () => [["l0", US0_$reflection()]]);
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
    return union_type("Runtime.US1", [], US1, () => [[["f0_0", US0_$reflection()]], []]);
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
    return union_type("Runtime.US2", [], US2, () => [[["f0_0", int64_type]], []]);
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
    return union_type("Runtime.US3", [], US3, () => [[], [], []]);
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
    return union_type("Runtime.US4", [], US4, () => [[["f0_0", US3_$reflection()]], [["f1_0", US3_$reflection()]], [["f2_0", US3_$reflection()]], [["f3_0", US3_$reflection()]], [["f4_0", US3_$reflection()]], [["f5_0", US3_$reflection()]], [["f6_0", US3_$reflection()]]]);
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
    return union_type("Runtime.US5", [], US5, () => [[["f0_0", string_type]], []]);
}

export type US6_$union = 
    | US6<0>
    | US6<1>

export type US6_$cases = {
    0: ["US6_0", [string, US5_$union]],
    1: ["US6_1", [string]]
}

export function US6_US6_0(f0_0: string, f0_1: US5_$union) {
    return new US6<0>(0, [f0_0, f0_1]);
}

export function US6_US6_1(f1_0: string) {
    return new US6<1>(1, [f1_0]);
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
    return union_type("Runtime.US6", [], US6, () => [[["f0_0", string_type], ["f0_1", US5_$reflection()]], [["f1_0", string_type]]]);
}

export type US7_$union = 
    | US7<0>
    | US7<1>

export type US7_$cases = {
    0: ["US7_0", [string, string, any, int32, int32]],
    1: ["US7_1", [string]]
}

export function US7_US7_0(f0_0: string, f0_1: string, f0_2: any, f0_3: int32, f0_4: int32) {
    return new US7<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4]);
}

export function US7_US7_1(f1_0: string) {
    return new US7<1>(1, [f1_0]);
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
    return union_type("Runtime.US7", [], US7, () => [[["f0_0", char_type], ["f0_1", string_type], ["f0_2", class_type("System.Text.StringBuilder")], ["f0_3", int32_type], ["f0_4", int32_type]], [["f1_0", string_type]]]);
}

export type UH0_$union = 
    | UH0<0>
    | UH0<1>

export type UH0_$cases = {
    0: ["UH0_0", []],
    1: ["UH0_1", [string, UH0_$union]]
}

export function UH0_UH0_0() {
    return new UH0<0>(0, []);
}

export function UH0_UH0_1(Item1: string, Item2: UH0_$union) {
    return new UH0<1>(1, [Item1, Item2]);
}

export class UH0<Tag extends keyof UH0_$cases> extends Union<Tag, UH0_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: UH0_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["UH0_0", "UH0_1"];
    }
}

export function UH0_$reflection(): TypeInfo {
    return union_type("Runtime.UH0", [], UH0, () => [[], [["Item1", char_type], ["Item2", UH0_$reflection()]]]);
}

export type UH1_$union = 
    | UH1<0>
    | UH1<1>

export type UH1_$cases = {
    0: ["UH1_0", []],
    1: ["UH1_1", [((arg0: [string, any, int32, int32]) => US7_$union), UH1_$union]]
}

export function UH1_UH1_0() {
    return new UH1<0>(0, []);
}

export function UH1_UH1_1(Item1: ((arg0: [string, any, int32, int32]) => US7_$union), Item2: UH1_$union) {
    return new UH1<1>(1, [Item1, Item2]);
}

export class UH1<Tag extends keyof UH1_$cases> extends Union<Tag, UH1_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: UH1_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["UH1_0", "UH1_1"];
    }
}

export function UH1_$reflection(): TypeInfo {
    return union_type("Runtime.UH1", [], UH1, () => [[], [["Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US7_$reflection())], ["Item2", UH1_$reflection()]]]);
}

export type US8_$union = 
    | US8<0>
    | US8<1>

export type US8_$cases = {
    0: ["US8_0", [string, string, any, int32, int32]],
    1: ["US8_1", [string]]
}

export function US8_US8_0(f0_0: string, f0_1: string, f0_2: any, f0_3: int32, f0_4: int32) {
    return new US8<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4]);
}

export function US8_US8_1(f1_0: string) {
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
    return union_type("Runtime.US8", [], US8, () => [[["f0_0", string_type], ["f0_1", string_type], ["f0_2", class_type("System.Text.StringBuilder")], ["f0_3", int32_type], ["f0_4", int32_type]], [["f1_0", string_type]]]);
}

export type US9_$union = 
    | US9<0>
    | US9<1>

export type US9_$cases = {
    0: ["US9_0", [string]],
    1: ["US9_1", []]
}

export function US9_US9_0(f0_0: string) {
    return new US9<0>(0, [f0_0]);
}

export function US9_US9_1() {
    return new US9<1>(1, []);
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
    return union_type("Runtime.US9", [], US9, () => [[["f0_0", char_type]], []]);
}

export type US10_$union = 
    | US10<0>
    | US10<1>

export type US10_$cases = {
    0: ["US10_0", [string, any, int32, int32]],
    1: ["US10_1", [string]]
}

export function US10_US10_0(f0_0: string, f0_1: any, f0_2: int32, f0_3: int32) {
    return new US10<0>(0, [f0_0, f0_1, f0_2, f0_3]);
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
    return union_type("Runtime.US10", [], US10, () => [[["f0_0", string_type], ["f0_1", class_type("System.Text.StringBuilder")], ["f0_2", int32_type], ["f0_3", int32_type]], [["f1_0", string_type]]]);
}

export type US11_$union = 
    | US11<0>
    | US11<1>

export type US11_$cases = {
    0: ["US11_0", [string, US5_$union, string, any, int32, int32]],
    1: ["US11_1", [string]]
}

export function US11_US11_0(f0_0: string, f0_1: US5_$union, f0_2: string, f0_3: any, f0_4: int32, f0_5: int32) {
    return new US11<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4, f0_5]);
}

export function US11_US11_1(f1_0: string) {
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
    return union_type("Runtime.US11", [], US11, () => [[["f0_0", string_type], ["f0_1", US5_$reflection()], ["f0_2", string_type], ["f0_3", class_type("System.Text.StringBuilder")], ["f0_4", int32_type], ["f0_5", int32_type]], [["f1_0", string_type]]]);
}

export type US12_$union = 
    | US12<0>
    | US12<1>

export type US12_$cases = {
    0: ["US12_0", [US9_$union, string, any, int32, int32]],
    1: ["US12_1", [string]]
}

export function US12_US12_0(f0_0: US9_$union, f0_1: string, f0_2: any, f0_3: int32, f0_4: int32) {
    return new US12<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4]);
}

export function US12_US12_1(f1_0: string) {
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
    return union_type("Runtime.US12", [], US12, () => [[["f0_0", US9_$reflection()], ["f0_1", string_type], ["f0_2", class_type("System.Text.StringBuilder")], ["f0_3", int32_type], ["f0_4", int32_type]], [["f1_0", string_type]]]);
}

export type US13_$union = 
    | US13<0>
    | US13<1>

export type US13_$cases = {
    0: ["US13_0", [US5_$union, string, any, int32, int32]],
    1: ["US13_1", [string]]
}

export function US13_US13_0(f0_0: US5_$union, f0_1: string, f0_2: any, f0_3: int32, f0_4: int32) {
    return new US13<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4]);
}

export function US13_US13_1(f1_0: string) {
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
    return union_type("Runtime.US13", [], US13, () => [[["f0_0", US5_$reflection()], ["f0_1", string_type], ["f0_2", class_type("System.Text.StringBuilder")], ["f0_3", int32_type], ["f0_4", int32_type]], [["f1_0", string_type]]]);
}

export class Mut5 extends Record implements IEquatable<Mut5>, IComparable<Mut5> {
    l0: int32;
    constructor(l0: int32) {
        super();
        this.l0 = (l0 | 0);
    }
}

export function Mut5_$reflection(): TypeInfo {
    return record_type("Runtime.Mut5", [], Mut5, () => [["l0", int32_type]]);
}

export type US14_$union = 
    | US14<0>
    | US14<1>

export type US14_$cases = {
    0: ["US14_0", [((arg0: [int32, string, boolean]) => Async<void>)]],
    1: ["US14_1", []]
}

export function US14_US14_0(f0_0: ((arg0: [int32, string, boolean]) => Async<void>)) {
    return new US14<0>(0, [f0_0]);
}

export function US14_US14_1() {
    return new US14<1>(1, []);
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
    return union_type("Runtime.US14", [], US14, () => [[["f0_0", lambda_type(tuple_type(int32_type, string_type, bool_type), class_type("Microsoft.FSharp.Control.FSharpAsync`1", [unit_type]))]], []]);
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
    return union_type("Runtime.US15", [], US15, () => [[["f0_0", class_type("System.Threading.CancellationToken")]], []]);
}

export class Heap0 extends Record {
    readonly l0: string;
    readonly l1: Option<any>;
    readonly l2: [string, string][];
    readonly l3: Option<((arg0: [int32, string, boolean]) => Async<void>)>;
    readonly l4: Option<((arg0: any) => void)>;
    readonly l5: boolean;
    readonly l6: Option<string>;
    constructor(l0: string, l1: Option<any>, l2: [string, string][], l3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, l4: Option<((arg0: any) => void)>, l5: boolean, l6: Option<string>) {
        super();
        this.l0 = l0;
        this.l1 = l1;
        this.l2 = l2;
        this.l3 = l3;
        this.l4 = l4;
        this.l5 = l5;
        this.l6 = l6;
    }
}

export function Heap0_$reflection(): TypeInfo {
    return record_type("Runtime.Heap0", [], Heap0, () => [["l0", string_type], ["l1", option_type(class_type("System.Threading.CancellationToken"))], ["l2", array_type(tuple_type(string_type, string_type))], ["l3", option_type(lambda_type(tuple_type(int32_type, string_type, bool_type), class_type("Microsoft.FSharp.Control.FSharpAsync`1", [unit_type])))], ["l4", option_type(lambda_type(string_type, unit_type))], ["l5", bool_type], ["l6", option_type(string_type)]]);
}

export type US16_$union = 
    | US16<0>
    | US16<1>

export type US16_$cases = {
    0: ["US16_0", [string[]]],
    1: ["US16_1", [string]]
}

export function US16_US16_0(f0_0: string[]) {
    return new US16<0>(0, [f0_0]);
}

export function US16_US16_1(f1_0: string) {
    return new US16<1>(1, [f1_0]);
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
    return union_type("Runtime.US16", [], US16, () => [[["f0_0", array_type(string_type)]], [["f1_0", string_type]]]);
}

export type UH2_$union = 
    | UH2<0>
    | UH2<1>

export type UH2_$cases = {
    0: ["UH2_0", []],
    1: ["UH2_1", [string, UH2_$union]]
}

export function UH2_UH2_0() {
    return new UH2<0>(0, []);
}

export function UH2_UH2_1(Item1: string, Item2: UH2_$union) {
    return new UH2<1>(1, [Item1, Item2]);
}

export class UH2<Tag extends keyof UH2_$cases> extends Union<Tag, UH2_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: UH2_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["UH2_0", "UH2_1"];
    }
}

export function UH2_$reflection(): TypeInfo {
    return union_type("Runtime.UH2", [], UH2, () => [[], [["Item1", string_type], ["Item2", UH2_$reflection()]]]);
}

export type US17_$union = 
    | US17<0>
    | US17<1>

export type US17_$cases = {
    0: ["US17_0", [UH2_$union, string, any, int32, int32]],
    1: ["US17_1", [string]]
}

export function US17_US17_0(f0_0: UH2_$union, f0_1: string, f0_2: any, f0_3: int32, f0_4: int32) {
    return new US17<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4]);
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
    return union_type("Runtime.US17", [], US17, () => [[["f0_0", UH2_$reflection()], ["f0_1", string_type], ["f0_2", class_type("System.Text.StringBuilder")], ["f0_3", int32_type], ["f0_4", int32_type]], [["f1_0", string_type]]]);
}

export type UH3_$union = 
    | UH3<0>
    | UH3<1>

export type UH3_$cases = {
    0: ["UH3_0", []],
    1: ["UH3_1", [((arg0: [string, any, int32, int32]) => US8_$union), UH3_$union]]
}

export function UH3_UH3_0() {
    return new UH3<0>(0, []);
}

export function UH3_UH3_1(Item1: ((arg0: [string, any, int32, int32]) => US8_$union), Item2: UH3_$union) {
    return new UH3<1>(1, [Item1, Item2]);
}

export class UH3<Tag extends keyof UH3_$cases> extends Union<Tag, UH3_$cases[Tag][0]> {
    constructor(readonly tag: Tag, readonly fields: UH3_$cases[Tag][1]) {
        super();
    }
    cases() {
        return ["UH3_0", "UH3_1"];
    }
}

export function UH3_$reflection(): TypeInfo {
    return union_type("Runtime.UH3", [], UH3, () => [[], [["Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US8_$reflection())], ["Item2", UH3_$reflection()]]]);
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

export function method7(v0: US0_$union): boolean {
    let v17: any;
    closure0(undefined, undefined);
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
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
    const v641: US2_$union = defaultArg(map<int64, US2_$union>(method9(), v5), US2_US2_1());
    let v781: Date;
    if ((v641.tag as int32) === /* US2_0 */ 0) {
        const v645 = v641.fields[0] as any;
        const v724: number = fromTicks(toInt64(op_Subtraction(toInt64(fromInt64(getTicks(now()))), v645)));
        v781 = create(1, 1, 1, hours(v724), minutes(v724), seconds(v724), milliseconds(v724));
    }
    else {
        v781 = now();
    }
    const v782: string = method11();
    return toString(v781, (v782 === "") ? "M-d-y hh:mm:ss tt" : v782);
}

export function method13(): string {
    return "";
}

export function closure7(v0: Mut3, v1: string, unitVar: void): void {
    const v4: string = v0.l0 + v1;
    v0.l0 = v4;
}

export function method14(): string {
    return "\u001b[0m";
}

export function method12(): string {
    const v4: string = "Warning".toLocaleLowerCase();
    const v7: string = v4[0];
    const v9: Mut3 = new Mut3(method13());
    let v24: any;
    closure7(v9, `${v7}`, undefined);
    v24 = undefined;
    return ("\u001b[93m" + v9.l0) + method14();
}

export function method16(v0: string): string {
    return trimEnd(trimStart(v0, ...[]), ...[" ", "/"]);
}

export function method15(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v9: Mut3 = new Mut3(method13());
    const v10: string = v9.l0;
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 3") + " / ") + v10);
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

export function method17(v0: string): void {
    let v17: any;
    closure0(undefined, undefined);
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    let v60: any;
    closure8(patternInput[0], undefined);
    v60 = undefined;
    closure9(undefined, v0);
    patternInput[1].l0(v0);
}

export function closure5(unitVar: void, unitVar_1: void): void {
    if (method7(US0_US0_3())) {
        let v18: any;
        closure0(undefined, undefined);
        v18 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v44: Option<int64> = patternInput[5];
        const v43: Mut4 = patternInput[4];
        const v42: Mut3 = patternInput[3];
        const v41: Mut2 = patternInput[2];
        const v40: Mut1 = patternInput[1];
        const v39: Mut0 = patternInput[0];
        method17(method15(v39, v40, v41, v42, v43, v44, method8(v39, v40, v41, v42, v43, v44), method12()));
    }
}

export function method18(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v9: Mut3 = new Mut3(method13());
    const v10: string = v9.l0;
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 2") + " / ") + v10);
}

export function closure11(unitVar: void, unitVar_1: void): void {
    if (method7(US0_US0_3())) {
        let v18: any;
        closure0(undefined, undefined);
        v18 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v44: Option<int64> = patternInput[5];
        const v43: Mut4 = patternInput[4];
        const v42: Mut3 = patternInput[3];
        const v41: Mut2 = patternInput[2];
        const v40: Mut1 = patternInput[1];
        const v39: Mut0 = patternInput[0];
        method17(method18(v39, v40, v41, v42, v43, v44, method8(v39, v40, v41, v42, v43, v44), method12()));
    }
}

export function method19(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v9: Mut3 = new Mut3(method13());
    const v10: string = v9.l0;
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 1") + " / ") + v10);
}

export function closure12(unitVar: void, unitVar_1: void): void {
    if (method7(US0_US0_3())) {
        let v18: any;
        closure0(undefined, undefined);
        v18 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v44: Option<int64> = patternInput[5];
        const v43: Mut4 = patternInput[4];
        const v42: Mut3 = patternInput[3];
        const v41: Mut2 = patternInput[2];
        const v40: Mut1 = patternInput[1];
        const v39: Mut0 = patternInput[0];
        method17(method19(v39, v40, v41, v42, v43, v44, method8(v39, v40, v41, v42, v43, v44), method12()));
    }
}

export function closure4(unitVar: void, unitVar_1: void): void {
}

export function method6(): void {
}

export function closure3(unitVar: void, unitVar_1: void): void {
    method6();
}

export function method24(): string {
    return "";
}

export function method25(v0: int64, v1: string, v2: int64): UH0_$union {
    if (compare_1(v2, v0) < 0) {
        return UH0_UH0_1(v1[~~toInt32(v2)], method25(v0, v1, toInt64(op_Addition(v2, 1n))));
    }
    else {
        return UH0_UH0_0();
    }
}

export function method26(v0_mut: UH0_$union, v1_mut: any, v2_mut: int32, v3_mut: int32): [any, int32, int32] {
    let v13: any, v24: any;
    method26:
    while (true) {
        const v0: UH0_$union = v0_mut, v1: any = v1_mut, v2: int32 = v2_mut, v3: int32 = v3_mut;
        if ((v0.tag as int32) === /* UH0_0 */ 0) {
            return [v1, v2, v3] as [any, int32, int32];
        }
        else {
            const v4 = v0.fields[0] as any;
            const v6: boolean = "\n" === v4;
            const patternInput: [int32, int32] = v6 ? ([v2 + 1, 1] as [int32, int32]) : ([v2, v3 + 1] as [int32, int32]);
            v0_mut = (v0.fields[1] as any);
            v1_mut = (v6 ? ((v13 = StringBuilder__Clear(v1), v1)) : ((v24 = StringBuilder__Append_Z721C83C5(v1, v4), v1)));
            v2_mut = patternInput[0];
            v3_mut = patternInput[1];
            continue method26;
        }
        break;
    }
}

export function closure15(v0: int32, v1: int32, v2: string): string {
    if (v1 >= v0) {
        return v2;
    }
    else {
        return method27(v0, v1 + 1)(v2 + " ");
    }
}

export function method27(v0: int32, v1: int32): ((arg0: string) => string) {
    return (v: string): string => closure15(v0, v1, v);
}

export function closure14(unitVar: void, _arg: [string, any, int32, int32]): US7_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    if ("" === v0) {
        return US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", [v1, v2, v3] as [any, int32, int32]])));
    }
    else {
        const v10: string = v0[0];
        if (v10 === "\"") {
            const v22 = 1;
            const v43: int32 = (v0.length - 1) | 0;
            const v45: string = v0.slice(v22, v43 + 1);
            const v51: string = v10;
            const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v51.length)), v51, 0n), v1, v2, v3);
            return US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v66: int32 = (v0.indexOf("\n") - 1) | 0;
            const v81 = 0;
            const v102: int32 = (((-2 === v66) ? (v0.length + 1) : (v66 + 1)) - 1) | 0;
            return US7_US7_1(concat(`parsing.p_char / expected: '${"\""}' / line: ${v2} / col: ${v3}
${v1}${v0.slice(v81, v102 + 1)}`, "\n", method27(v3 - 1, 0)("") + "^", ..."\n"));
        }
    }
}

export function closure16(unitVar: void, _arg: [string, any, int32, int32]): US7_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    if ("" === v0) {
        return US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\'", [v1, v2, v3] as [any, int32, int32]])));
    }
    else {
        const v10: string = v0[0];
        if (v10 === "\'") {
            const v22 = 1;
            const v43: int32 = (v0.length - 1) | 0;
            const v45: string = v0.slice(v22, v43 + 1);
            const v51: string = v10;
            const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v51.length)), v51, 0n), v1, v2, v3);
            return US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v66: int32 = (v0.indexOf("\n") - 1) | 0;
            const v81 = 0;
            const v102: int32 = (((-2 === v66) ? (v0.length + 1) : (v66 + 1)) - 1) | 0;
            return US7_US7_1(concat(`parsing.p_char / expected: '${"\'"}' / line: ${v2} / col: ${v3}
${v1}${v0.slice(v81, v102 + 1)}`, "\n", method27(v3 - 1, 0)("") + "^", ..."\n"));
        }
    }
}

export function method28(v0_mut: string, v1_mut: any, v2_mut: UH1_$union): US7_$union {
    method28:
    while (true) {
        const v0: string = v0_mut, v1: any = v1_mut, v2: UH1_$union = v2_mut;
        if ((v2.tag as int32) === /* UH1_0 */ 0) {
            return US7_US7_1("parsing.choice / no parsers succeeded");
        }
        else {
            const v6 = v2.fields[1] as any;
            const v7: US7_$union = (v2.fields[0] as any)([v0, v1, 1, 1] as [string, any, int32, int32]);
            if ((v7.tag as int32) === /* US7_0 */ 0) {
                const v9 = v7.fields[1] as any;
                const v8 = v7.fields[0] as any;
                const v12: int32 = (v7.fields[4] as any) | 0;
                const v11: int32 = (v7.fields[3] as any) | 0;
                const v10 = v7.fields[2] as any;
                return v7;
            }
            else {
                const v13 = v7.fields[0] as any;
                v0_mut = v0;
                v1_mut = v1;
                v2_mut = v6;
                continue method28;
            }
        }
        break;
    }
}

export function method29(v0_mut: string, v1_mut: int64): boolean {
    method29:
    while (true) {
        const v0: string = v0_mut, v1: int64 = v1_mut;
        if (compare_1(v1, 2n) >= 0) {
            return false;
        }
        else {
            let v11: US9_$union;
            if (equals(v1, 0n)) {
                v11 = US9_US9_0("\"");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1, 1n));
                if (equals(v5, 0n)) {
                    v11 = US9_US9_0("\'");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    v11 = US9_US9_1();
                }
            }
            if (v0 === (((v11.tag as int32) === /* US9_0 */ 0) ? (v11.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_mut = v0;
                v1_mut = toInt64(op_Addition(v1, 1n));
                continue method29;
            }
        }
        break;
    }
}

export function method30(v0_mut: string, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method30:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v98: US7_$union;
        if ("" === v1) {
            v98 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'"], [v2, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v25: string = v1[0];
            if (method29(v25, 0n) === false) {
                const v39 = 1;
                const v60: int32 = (v1.length - 1) | 0;
                const v62: string = v1.slice(v39, v60 + 1);
                const v68: string = v25;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v68.length)), v68, 0n), v2, v3, v4);
                v98 = US7_US7_0(v25, v62, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v98 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v25, ["\"", "\'"], [v2, v3, v4] as [any, int32, int32]])));
            }
        }
        let v110: US7_$union;
        if ((v98.tag as int32) === /* US7_0 */ 0) {
            const v99 = v98.fields[0] as any;
            v110 = US7_US7_0(("\\" === v99) ? "/" : v99, v98.fields[1] as any, v98.fields[2] as any, v98.fields[3] as any, v98.fields[4] as any);
        }
        else {
            v110 = US7_US7_1(v98.fields[0] as any);
        }
        if ((v110.tag as int32) === /* US7_0 */ 0) {
            v0_mut = (v0 + (v110.fields[0] as any));
            v1_mut = (v110.fields[1] as any);
            v2_mut = (v110.fields[2] as any);
            v3_mut = (v110.fields[3] as any);
            v4_mut = (v110.fields[4] as any);
            continue method30;
        }
        else {
            const v127 = v110.fields[0] as any;
            return [v0, v1, v2, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method31(v0_mut: string, v1_mut: any, v2_mut: int32, v3_mut: int32, v4_mut: UH1_$union): US7_$union {
    method31:
    while (true) {
        const v0: string = v0_mut, v1: any = v1_mut, v2: int32 = v2_mut, v3: int32 = v3_mut, v4: UH1_$union = v4_mut;
        if ((v4.tag as int32) === /* UH1_0 */ 0) {
            return US7_US7_1("parsing.choice / no parsers succeeded");
        }
        else {
            const v8 = v4.fields[1] as any;
            const v9: US7_$union = (v4.fields[0] as any)([v0, v1, v2, v3] as [string, any, int32, int32]);
            if ((v9.tag as int32) === /* US7_0 */ 0) {
                const v14_1: int32 = (v9.fields[4] as any) | 0;
                const v13: int32 = (v9.fields[3] as any) | 0;
                const v12 = v9.fields[2] as any;
                const v11 = v9.fields[1] as any;
                const v10 = v9.fields[0] as any;
                return v9;
            }
            else {
                const v15_1 = v9.fields[0] as any;
                v0_mut = v0;
                v1_mut = v1;
                v2_mut = v2;
                v3_mut = v3;
                v4_mut = v8;
                continue method31;
            }
        }
        break;
    }
}

export function method32(v0_mut: string, v1_mut: int64): boolean {
    method32:
    while (true) {
        const v0: string = v0_mut, v1: int64 = v1_mut;
        if (compare_1(v1, 3n) >= 0) {
            return false;
        }
        else {
            let v15_1: US9_$union;
            if (equals(v1, 0n)) {
                v15_1 = US9_US9_0("\"");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1, 1n));
                if (equals(v5, 0n)) {
                    v15_1 = US9_US9_0("\'");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    if (equals(v8, 0n)) {
                        v15_1 = US9_US9_0(" ");
                    }
                    else {
                        const v11: int64 = toInt64(op_Subtraction(v8, 1n));
                        v15_1 = US9_US9_1();
                    }
                }
            }
            if (v0 === (((v15_1.tag as int32) === /* US9_0 */ 0) ? (v15_1.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_mut = v0;
                v1_mut = toInt64(op_Addition(v1, 1n));
                continue method32;
            }
        }
        break;
    }
}

export function method33(v0_mut: string, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method33:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v106: US7_$union;
        if ("" === v1) {
            v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'", " "], [v2, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v29: string = v1[0];
            if (method32(v29, 0n) === false) {
                const v43 = 1;
                const v64: int32 = (v1.length - 1) | 0;
                const v66: string = v1.slice(v43, v64 + 1);
                const v72: string = v29;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v72.length)), v72, 0n), v2, v3, v4);
                v106 = US7_US7_0(v29, v66, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, ["\"", "\'", " "], [v2, v3, v4] as [any, int32, int32]])));
            }
        }
        let v118: US7_$union;
        if ((v106.tag as int32) === /* US7_0 */ 0) {
            const v107 = v106.fields[0] as any;
            v118 = US7_US7_0(("\\" === v107) ? "/" : v107, v106.fields[1] as any, v106.fields[2] as any, v106.fields[3] as any, v106.fields[4] as any);
        }
        else {
            v118 = US7_US7_1(v106.fields[0] as any);
        }
        if ((v118.tag as int32) === /* US7_0 */ 0) {
            v0_mut = (v0 + (v118.fields[0] as any));
            v1_mut = (v118.fields[1] as any);
            v2_mut = (v118.fields[2] as any);
            v3_mut = (v118.fields[3] as any);
            v4_mut = (v118.fields[4] as any);
            continue method33;
        }
        else {
            const v135 = v118.fields[0] as any;
            return [v0, v1, v2, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method34(v0_mut: string, v1_mut: int32): int32 {
    method34:
    while (true) {
        const v0: string = v0_mut, v1: int32 = v1_mut;
        if (v1 >= v0.length) {
            return v1 | 0;
        }
        else if (" " === v0[v1]) {
            v0_mut = v0;
            v1_mut = (v1 + 1);
            continue method34;
        }
        else {
            return v1 | 0;
        }
        break;
    }
}

export function method35(v0_mut: string, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method35:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v66: US7_$union;
        if ("" === v1) {
            v66 = US7_US7_1(toText(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [[v2, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v16_1: string = v1[0];
            const v27 = 1;
            const v48: int32 = (v1.length - 1) | 0;
            const v50: string = v1.slice(v27, v48 + 1);
            const v56: string = v16_1;
            const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v56.length)), v56, 0n), v2, v3, v4);
            v66 = US7_US7_0(v16_1, v50, patternInput[0], patternInput[1], patternInput[2]);
        }
        if ((v66.tag as int32) === /* US7_0 */ 0) {
            v0_mut = (v0 + (v66.fields[0] as any));
            v1_mut = (v66.fields[1] as any);
            v2_mut = (v66.fields[2] as any);
            v3_mut = (v66.fields[3] as any);
            v4_mut = (v66.fields[4] as any);
            continue method35;
        }
        else {
            const v83 = v66.fields[0] as any;
            return [v0, v1, v2, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method23(v0: string): US6_$union {
    let _v0: Option<Option<string>> = undefined;
    _v0 = some(v0);
    const v10: string = defaultArg((_v0 == null) ? (() => {
        throw new Error("optionm\'.of_obj / _v0=None");
    })() : value_12(_v0), "");
    const v16_1: any = StringBuilder_$ctor_Z721C83C5(method24());
    const v19 = (arg10$0040: [string, any, int32, int32]): US7_$union => closure14(undefined, arg10$0040);
    const v20 = (arg10$0040_1: [string, any, int32, int32]): US7_$union => closure16(undefined, arg10$0040_1);
    const v24: US7_$union = method28(v10, v16_1, UH1_UH1_1(v19, UH1_UH1_1(v20, UH1_UH1_0())));
    let v197: US8_$union;
    if ((v24.tag as int32) === /* US7_0 */ 0) {
        const v29: int32 = (v24.fields[4] as any) | 0;
        const v28: int32 = (v24.fields[3] as any) | 0;
        const v27 = v24.fields[2] as any;
        const v26 = v24.fields[1] as any;
        const v25 = v24.fields[0] as any;
        let v123: US7_$union;
        if ("" === v26) {
            v123 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'"], [v27, v28, v29] as [any, int32, int32]])));
        }
        else {
            const v50: string = v26[0];
            if (method29(v50, 0n) === false) {
                const v64 = 1;
                const v85: int32 = (v26.length - 1) | 0;
                const v87: string = v26.slice(v64, v85 + 1);
                const v93: string = v50;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v93.length)), v93, 0n), v27, v28, v29);
                v123 = US7_US7_0(v50, v87, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v123 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v50, ["\"", "\'"], [v27, v28, v29] as [any, int32, int32]])));
            }
        }
        let v135: US7_$union;
        if ((v123.tag as int32) === /* US7_0 */ 0) {
            const v124 = v123.fields[0] as any;
            v135 = US7_US7_0(("\\" === v124) ? "/" : v124, v123.fields[1] as any, v123.fields[2] as any, v123.fields[3] as any, v123.fields[4] as any);
        }
        else {
            v135 = US7_US7_1(v123.fields[0] as any);
        }
        let v155: US8_$union;
        if ((v135.tag as int32) === /* US7_0 */ 0) {
            const patternInput_1: [string, string, any, int32, int32] = method30(v135.fields[0] as any, v135.fields[1] as any, v135.fields[2] as any, v135.fields[3] as any, v135.fields[4] as any);
            v155 = US8_US8_0(patternInput_1[0], patternInput_1[1], patternInput_1[2], patternInput_1[3], patternInput_1[4]);
        }
        else {
            v155 = US8_US8_1(v135.fields[0] as any);
        }
        let v165: US8_$union;
        if ((v155.tag as int32) === /* US8_0 */ 0) {
            v165 = US8_US8_0(v155.fields[0] as any, v155.fields[1] as any, v155.fields[2] as any, v155.fields[3] as any, v155.fields[4] as any);
        }
        else {
            const v162 = v155.fields[0] as any;
            v165 = US8_US8_0("", v26, v27, v28, v29);
        }
        if ((v165.tag as int32) === /* US8_0 */ 0) {
            const v170: int32 = (v165.fields[4] as any) | 0;
            const v169: int32 = (v165.fields[3] as any) | 0;
            const v168 = v165.fields[2] as any;
            const v167 = v165.fields[1] as any;
            const v166 = v165.fields[0] as any;
            const v174: US7_$union = method31(v167, v168, v169, v170, UH1_UH1_1(v19, UH1_UH1_1(v20, UH1_UH1_0())));
            if ((v174.tag as int32) === /* US7_0 */ 0) {
                const v175 = v174.fields[0] as any;
                v197 = US8_US8_0(v166, v174.fields[1] as any, v174.fields[2] as any, v174.fields[3] as any, v174.fields[4] as any);
            }
            else {
                v197 = US8_US8_1(toText(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v174.fields[0] as any, [v10, v16_1, 1, 1] as [string, any, int32, int32], [v26, v27, v28, v29] as [string, any, int32, int32], [v167, v168, v169, v170] as [string, any, int32, int32]])));
            }
        }
        else {
            const v189 = v165.fields[0] as any;
            v197 = US8_US8_1("parsing.between / expected content");
        }
    }
    else {
        v197 = US8_US8_1(v24.fields[0] as any);
    }
    let v416: US8_$union;
    if ((v197.tag as int32) === /* US8_0 */ 0) {
        const v202: int32 = (v197.fields[4] as any) | 0;
        const v201: int32 = (v197.fields[3] as any) | 0;
        const v200 = v197.fields[2] as any;
        const v199 = v197.fields[1] as any;
        const v198 = v197.fields[0] as any;
        v416 = v197;
    }
    else {
        const v203 = v197.fields[0] as any;
        let v307: US7_$union;
        if ("" === v10) {
            v307 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'", " "], [v16_1, 1, 1] as [any, int32, int32]])));
        }
        else {
            const v228: string = v10[0];
            if (method32(v228, 0n) === false) {
                const v242 = 1;
                const v263: int32 = (v10.length - 1) | 0;
                const v265: string = v10.slice(v242, v263 + 1);
                const v271: string = v228;
                const patternInput_2: [any, int32, int32] = method26(method25(toInt64(fromInt32(v271.length)), v271, 0n), v16_1, 1, 1);
                v307 = US7_US7_0(v228, v265, patternInput_2[0], patternInput_2[1], patternInput_2[2]);
            }
            else {
                v307 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v228, ["\"", "\'", " "], [v16_1, 1, 1] as [any, int32, int32]])));
            }
        }
        let v319: US7_$union;
        if ((v307.tag as int32) === /* US7_0 */ 0) {
            const v308 = v307.fields[0] as any;
            v319 = US7_US7_0(("\\" === v308) ? "/" : v308, v307.fields[1] as any, v307.fields[2] as any, v307.fields[3] as any, v307.fields[4] as any);
        }
        else {
            v319 = US7_US7_1(v307.fields[0] as any);
        }
        let v339: US8_$union;
        if ((v319.tag as int32) === /* US7_0 */ 0) {
            const patternInput_3: [string, string, any, int32, int32] = method33(v319.fields[0] as any, v319.fields[1] as any, v319.fields[2] as any, v319.fields[3] as any, v319.fields[4] as any);
            v339 = US8_US8_0(patternInput_3[0], patternInput_3[1], patternInput_3[2], patternInput_3[3], patternInput_3[4]);
        }
        else {
            v339 = US8_US8_1(v319.fields[0] as any);
        }
        if ((v339.tag as int32) === /* US8_0 */ 0) {
            const v344: int32 = (v339.fields[4] as any) | 0;
            const v343: int32 = (v339.fields[3] as any) | 0;
            const v342 = v339.fields[2] as any;
            const v341 = v339.fields[1] as any;
            const v340 = v339.fields[0] as any;
            v416 = v339;
        }
        else {
            const v345 = v339.fields[0] as any;
            const v354: US10_$union = (v10.length === 0) ? US10_US10_0(v10, v16_1, 1, 1) : US10_US10_1(toText(interpolate("parsing.eof / expected end of input / input: %A%P()", [v10])));
            const v363: US8_$union = ((v354.tag as int32) === /* US10_0 */ 0) ? US8_US8_0("", v354.fields[0] as any, v354.fields[1] as any, v354.fields[2] as any, v354.fields[3] as any) : US8_US8_1(v354.fields[0] as any);
            if ((v363.tag as int32) === /* US8_0 */ 0) {
                const v368: int32 = (v363.fields[4] as any) | 0;
                const v367: int32 = (v363.fields[3] as any) | 0;
                const v366 = v363.fields[2] as any;
                const v365 = v363.fields[1] as any;
                const v364 = v363.fields[0] as any;
                const v381: int32 = method34(v365, 0) | 0;
                const v402: int32 = (v365.length - 1) | 0;
                v416 = US8_US8_0(v364, v365.slice(v381, v402 + 1), v366, v367, v368);
            }
            else {
                v416 = US8_US8_1(v363.fields[0] as any);
            }
        }
    }
    let v671: US11_$union;
    if ((v416.tag as int32) === /* US8_0 */ 0) {
        const v421: int32 = (v416.fields[4] as any) | 0;
        const v420: int32 = (v416.fields[3] as any) | 0;
        const v419 = v416.fields[2] as any;
        const v418 = v416.fields[1] as any;
        const v417 = v416.fields[0] as any;
        let v542: US7_$union;
        if ("" === v418) {
            v542 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", [" ", [v419, v420, v421] as [any, int32, int32]])));
        }
        else {
            const v428: string = v418[0];
            if (v428 === " ") {
                const v440 = 1;
                const v461: int32 = (v418.length - 1) | 0;
                const v463: string = v418.slice(v440, v461 + 1);
                const v469: string = v428;
                const patternInput_4: [any, int32, int32] = method26(method25(toInt64(fromInt32(v469.length)), v469, 0n), v419, v420, v421);
                v542 = US7_US7_0(v428, v463, patternInput_4[0], patternInput_4[1], patternInput_4[2]);
            }
            else {
                const v484: int32 = (v418.indexOf("\n") - 1) | 0;
                const v499 = 0;
                const v520: int32 = (((-2 === v484) ? (v418.length + 1) : (v484 + 1)) - 1) | 0;
                v542 = US7_US7_1(concat(`parsing.p_char / expected: '${" "}' / line: ${v420} / col: ${v421}
${v419}${v418.slice(v499, v520 + 1)}`, "\n", method27(v421 - 1, 0)("") + "^", ..."\n"));
            }
        }
        let v554: US12_$union;
        if ((v542.tag as int32) === /* US7_0 */ 0) {
            v554 = US12_US12_0(US9_US9_0(v542.fields[0] as any), v542.fields[1] as any, v542.fields[2] as any, v542.fields[3] as any, v542.fields[4] as any);
        }
        else {
            const v550 = v542.fields[0] as any;
            v554 = US12_US12_0(US9_US9_1(), v418, v419, v420, v421);
        }
        let v645: US8_$union;
        if ((v554.tag as int32) === /* US12_0 */ 0) {
            const v559: int32 = (v554.fields[4] as any) | 0;
            const v558: int32 = (v554.fields[3] as any) | 0;
            const v557 = v554.fields[2] as any;
            const v556 = v554.fields[1] as any;
            const v555 = v554.fields[0] as any;
            let v621: US7_$union;
            if ("" === v556) {
                v621 = US7_US7_1(toText(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [[v557, v558, v559] as [any, int32, int32]])));
            }
            else {
                const v571: string = v556[0];
                const v582 = 1;
                const v603: int32 = (v556.length - 1) | 0;
                const v605: string = v556.slice(v582, v603 + 1);
                const v611: string = v571;
                const patternInput_5: [any, int32, int32] = method26(method25(toInt64(fromInt32(v611.length)), v611, 0n), v557, v558, v559);
                v621 = US7_US7_0(v571, v605, patternInput_5[0], patternInput_5[1], patternInput_5[2]);
            }
            if ((v621.tag as int32) === /* US7_0 */ 0) {
                const patternInput_6: [string, string, any, int32, int32] = method35(v621.fields[0] as any, v621.fields[1] as any, v621.fields[2] as any, v621.fields[3] as any, v621.fields[4] as any);
                v645 = US8_US8_0(patternInput_6[0], patternInput_6[1], patternInput_6[2], patternInput_6[3], patternInput_6[4]);
            }
            else {
                v645 = US8_US8_1(v621.fields[0] as any);
            }
        }
        else {
            v645 = US8_US8_1(v554.fields[0] as any);
        }
        let v657: US13_$union;
        if ((v645.tag as int32) === /* US8_0 */ 0) {
            v657 = US13_US13_0(US5_US5_0(v645.fields[0] as any), v645.fields[1] as any, v645.fields[2] as any, v645.fields[3] as any, v645.fields[4] as any);
        }
        else {
            const v653 = v645.fields[0] as any;
            v657 = US13_US13_0(US5_US5_1(), v418, v419, v420, v421);
        }
        v671 = (((v657.tag as int32) === /* US13_0 */ 0) ? US11_US11_0(v417, v657.fields[0] as any, v657.fields[1] as any, v657.fields[2] as any, v657.fields[3] as any, v657.fields[4] as any) : US11_US11_1(v657.fields[0] as any));
    }
    else {
        v671 = US11_US11_1(v416.fields[0] as any);
    }
    if ((v671.tag as int32) === /* US11_0 */ 0) {
        const v677: int32 = (v671.fields[5] as any) | 0;
        const v676: int32 = (v671.fields[4] as any) | 0;
        const v675 = v671.fields[3] as any;
        const v674 = v671.fields[2] as any;
        return US6_US6_0(v671.fields[0] as any, v671.fields[1] as any);
    }
    else {
        return US6_US6_1(v671.fields[0] as any);
    }
}

export function method36(): string {
    const v4: string = "Debug".toLocaleLowerCase();
    const v7: string = v4[0];
    const v9: Mut3 = new Mut3(method13());
    let v24: any;
    closure7(v9, `${v7}`, undefined);
    v24 = undefined;
    return ("\u001b[94m" + v9.l0) + method14();
}

export function method37(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: US5_$union, v10: string, v11: Option<any>, v12: [string, string][], v13: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v14_1: Option<((arg0: any) => void)>, v15_1: boolean, v16_1: Option<string>): string {
    const v18: Mut3 = new Mut3(method13());
    let v32_1: any;
    closure7(v18, "{ ", undefined);
    v32_1 = undefined;
    let v51: any;
    closure7(v18, "file_name", undefined);
    v51 = undefined;
    let v70: any;
    closure7(v18, " = ", undefined);
    v70 = undefined;
    let v87: any;
    closure7(v18, v8, undefined);
    v87 = undefined;
    let v106: any;
    closure7(v18, "; ", undefined);
    v106 = undefined;
    let v125: any;
    closure7(v18, "arguments", undefined);
    v125 = undefined;
    let v142: any;
    closure7(v18, " = ", undefined);
    v142 = undefined;
    let v163: any;
    closure7(v18, toText(interpolate("%A%P()", [v9])), undefined);
    v163 = undefined;
    let v180: any;
    closure7(v18, "; ", undefined);
    v180 = undefined;
    let v199: any;
    closure7(v18, "options", undefined);
    v199 = undefined;
    let v216: any;
    closure7(v18, " = ", undefined);
    v216 = undefined;
    let v233: any;
    closure7(v18, "{ ", undefined);
    v233 = undefined;
    let v252: any;
    closure7(v18, "command", undefined);
    v252 = undefined;
    let v269: any;
    closure7(v18, " = ", undefined);
    v269 = undefined;
    let v286: any;
    closure7(v18, v10, undefined);
    v286 = undefined;
    let v303: any;
    closure7(v18, "; ", undefined);
    v303 = undefined;
    let v322: any;
    closure7(v18, "cancellation_token", undefined);
    v322 = undefined;
    let v339: any;
    closure7(v18, " = ", undefined);
    v339 = undefined;
    let v398: any;
    closure7(v18, toText(interpolate("%A%P()", [v11])), undefined);
    v398 = undefined;
    let v415: any;
    closure7(v18, "; ", undefined);
    v415 = undefined;
    let v434: any;
    closure7(v18, "environment_variables", undefined);
    v434 = undefined;
    let v451: any;
    closure7(v18, " = ", undefined);
    v451 = undefined;
    let v472: any;
    closure7(v18, toText(interpolate("%A%P()", [v12])), undefined);
    v472 = undefined;
    let v489: any;
    closure7(v18, "; ", undefined);
    v489 = undefined;
    let v508: any;
    closure7(v18, "on_line", undefined);
    v508 = undefined;
    let v525: any;
    closure7(v18, " = ", undefined);
    v525 = undefined;
    let v584: any;
    closure7(v18, toText(interpolate("%A%P()", [v13])), undefined);
    v584 = undefined;
    let v601: any;
    closure7(v18, "; ", undefined);
    v601 = undefined;
    let v620: any;
    closure7(v18, "stdin", undefined);
    v620 = undefined;
    let v637: any;
    closure7(v18, " = ", undefined);
    v637 = undefined;
    let v696: any;
    closure7(v18, toText(interpolate("%A%P()", [v14_1])), undefined);
    v696 = undefined;
    let v713: any;
    closure7(v18, "; ", undefined);
    v713 = undefined;
    let v732: any;
    closure7(v18, "trace", undefined);
    v732 = undefined;
    let v749: any;
    closure7(v18, " = ", undefined);
    v749 = undefined;
    let v769: any;
    closure7(v18, v15_1 ? "true" : "false", undefined);
    v769 = undefined;
    let v786: any;
    closure7(v18, "; ", undefined);
    v786 = undefined;
    let v805: any;
    closure7(v18, "working_directory", undefined);
    v805 = undefined;
    let v822: any;
    closure7(v18, " = ", undefined);
    v822 = undefined;
    let v881: any;
    closure7(v18, toText(interpolate("%A%P()", [v16_1])), undefined);
    v881 = undefined;
    let v900: any;
    closure7(v18, " }", undefined);
    v900 = undefined;
    let v917: any;
    closure7(v18, " }", undefined);
    v917 = undefined;
    const v923: string = v18.l0;
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v923);
}

export function closure17(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: US5_$union, v8: string, unitVar: void): void {
    if (method7(US0_US0_1())) {
        let v27: any;
        closure0(undefined, undefined);
        v27 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v53: Option<int64> = patternInput[5];
        const v52: Mut4 = patternInput[4];
        const v51: Mut3 = patternInput[3];
        const v50: Mut2 = patternInput[2];
        const v49: Mut1 = patternInput[1];
        const v48: Mut0 = patternInput[0];
        method17(method37(v48, v49, v50, v51, v52, v53, method8(v48, v49, v50, v51, v52, v53), method36(), v8, v7, v0, v1, v2, v3, v4, v5, v6));
    }
}

export function method38(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>): [string, string][] {
    return v2;
}

export function method39(v0: int32, v1: Mut5): boolean {
    return v1.l0 < v0;
}

export function method42(v0: boolean): string {
    return defaultOf();
}

export function closure19(unitVar: void, v0: ((arg0: [int32, string, boolean]) => Async<void>)): US14_$union {
    return US14_US14_0(v0);
}

export function method43(): ((arg0: ((arg0: [int32, string, boolean]) => Async<void>)) => US14_$union) {
    return (v: ((arg0: [int32, string, boolean]) => Async<void>)): US14_$union => closure19(undefined, v);
}

export function method44(v0: boolean): int32 {
    return defaultOf();
}

export function method45(): string {
    const v4: string = "Verbose".toLocaleLowerCase();
    const v7: string = v4[0];
    const v9: Mut3 = new Mut3(method13());
    let v24: any;
    closure7(v9, `${v7}`, undefined);
    v24 = undefined;
    return ("\u001b[90m" + v9.l0) + method14();
}

export function method46(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string): string {
    const v10: Mut3 = new Mut3(method13());
    const v11: string = v10.l0;
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + v8) + " / ") + v11);
}

export function closure20(v0: string, unitVar: void): void {
    if (method7(US0_US0_0())) {
        let v19: any;
        closure0(undefined, undefined);
        v19 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v45: Option<int64> = patternInput[5];
        const v44: Mut4 = patternInput[4];
        const v43: Mut3 = patternInput[3];
        const v42: Mut2 = patternInput[2];
        const v41: Mut1 = patternInput[1];
        const v40: Mut0 = patternInput[0];
        method17((v0 === "") ? "" : method46(v40, v41, v42, v43, v44, v45, method8(v40, v41, v42, v43, v44, v45), method45(), v0));
    }
}

export function method41(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: any, v9: boolean, v10: boolean): Async<void> {
    return singleton.Delay<void>((): Async<void> => {
        let v2455: US14_$union, v2461: Async<void>;
        const v2424: string = method42(v10);
        const v2430: boolean = (v2424 === defaultOf()) !== true;
        return singleton.Combine<void>(v2430 ? ((v2455 = defaultArg(map<((arg0: [int32, string, boolean]) => Async<void>), US14_$union>(method43(), v3), US14_US14_1()), singleton.Combine<void>(((v2455.tag as int32) === /* US14_0 */ 0) ? ((v2461 = (v2455.fields[0] as any)([method44(v7), v2424, v9] as [int32, string, boolean]), singleton.Bind<void, void>(v2461, (): Async<void> => {
            return singleton.Zero();
        }))) : (singleton.Zero()), singleton.Delay<void>((): Async<void> => {
            let v2530: any, v2597: any;
            const v2464: string = v9 ? concat("! ", ...v2424) : concat("> ", ...v2424);
            return singleton.Combine<void>(v5 ? ((v2530 = ((closure20(v2464, undefined), undefined)), singleton.Zero())) : ((v2597 = ((closure10(v2464, undefined), undefined)), singleton.Zero())), singleton.Delay<void>((): Async<void> => {
                const v2605: string = concat(v9 ? "\u001b[7;4m" : "", v2424, ...(v9 ? "\u001b[0m" : ""));
                return singleton.Zero();
            }));
        })))) : singleton.Zero(), singleton.Delay<void>((): Async<void> => {
            return singleton.Zero();
        }));
    });
}

export function method40(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: any, v9: boolean, v10: boolean): Async<void> {
    return method41(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
}

export function closure18(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: any, v9: boolean, v10: boolean): void {
    startImmediate(method40(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10));
}

export function closure21(unitVar: void, v0: any): US15_$union {
    return US15_US15_0(v0);
}

export function method47(): ((arg0: any) => US15_$union) {
    return (v: any): US15_$union => closure21(undefined, v);
}

export function method48(v0: any): Async<any> {
    return singleton.Delay<any>((): Async<any> => {
        const v612: any = defaultOf();
        return singleton.Return<any>(v612);
    });
}

export function method49(v0: boolean): boolean {
    return defaultOf();
}

export function method50(v0: boolean): void {
}

export function closure22(v0: boolean, unitVar: void): void {
    if (method49(v0) === false) {
        method50(v0);
    }
}

export function method52(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: any): string {
    const v10: Mut3 = new Mut3(method13());
    let v24: any;
    closure7(v10, "{ ", undefined);
    v24 = undefined;
    let v43: any;
    closure7(v10, "ex", undefined);
    v43 = undefined;
    let v62: any;
    closure7(v10, " = ", undefined);
    v62 = undefined;
    let v121: any;
    closure7(v10, toText(interpolate("%A%P()", [v8])), undefined);
    v121 = undefined;
    let v140: any;
    closure7(v10, " }", undefined);
    v140 = undefined;
    const v146: string = v10.l0;
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.execute_with_options_async / WaitForExitAsync") + " / ") + v146);
}

export function closure23(v0: any, unitVar: void): void {
    if (method7(US0_US0_3())) {
        let v19: any;
        closure0(undefined, undefined);
        v19 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v45: Option<int64> = patternInput[5];
        const v44: Mut4 = patternInput[4];
        const v43: Mut3 = patternInput[3];
        const v42: Mut2 = patternInput[2];
        const v41: Mut1 = patternInput[1];
        const v40: Mut0 = patternInput[0];
        method17(method52(v40, v41, v42, v43, v44, v45, method8(v40, v41, v42, v43, v44, v45), method12(), v0));
    }
}

export function method51(v0: boolean, v1: any, v2: any): Async<int32> {
    return singleton.Delay<int32>((): Async<int32> => singleton.TryWith<int32>(singleton.Delay<int32>((): Async<int32> => {
        const v11152: Async<void> = awaitTask(defaultOf());
        return singleton.Bind<void, int32>(v11152, (): Async<int32> => {
            const v11186: int32 = 0;
            return singleton.Return<int32>(v11186);
        });
    }), (_arg_1: Error): Async<int32> => {
        const v11488: Error = _arg_1;
        const v11507: string = toText(interpolate("%A%P()", [v11488]));
        let v11596: any;
        closure23(v11488, undefined);
        v11596 = undefined;
        return singleton.Return<int32>(-2147483648);
    }));
}

export function method53(): string {
    return "\n";
}

export function method54(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: int32, v10: string, v11: Option<any>, v12: [string, string][], v13: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v14_1: Option<((arg0: any) => void)>, v15_1: boolean, v16_1: Option<string>): string {
    const v18: Mut3 = new Mut3(method13());
    let v32_1: any;
    closure7(v18, "{ ", undefined);
    v32_1 = undefined;
    let v51: any;
    closure7(v18, "exit_code", undefined);
    v51 = undefined;
    let v70: any;
    closure7(v18, " = ", undefined);
    v70 = undefined;
    let v90: any;
    closure7(v18, `${v8}`, undefined);
    v90 = undefined;
    let v109: any;
    closure7(v18, "; ", undefined);
    v109 = undefined;
    let v128: any;
    closure7(v18, "output_length", undefined);
    v128 = undefined;
    let v145: any;
    closure7(v18, " = ", undefined);
    v145 = undefined;
    let v165: any;
    closure7(v18, `${v9}`, undefined);
    v165 = undefined;
    let v182: any;
    closure7(v18, "; ", undefined);
    v182 = undefined;
    let v201: any;
    closure7(v18, "options", undefined);
    v201 = undefined;
    let v218: any;
    closure7(v18, " = ", undefined);
    v218 = undefined;
    let v235: any;
    closure7(v18, "{ ", undefined);
    v235 = undefined;
    let v254: any;
    closure7(v18, "command", undefined);
    v254 = undefined;
    let v271: any;
    closure7(v18, " = ", undefined);
    v271 = undefined;
    let v288: any;
    closure7(v18, v10, undefined);
    v288 = undefined;
    let v305: any;
    closure7(v18, "; ", undefined);
    v305 = undefined;
    let v324: any;
    closure7(v18, "cancellation_token", undefined);
    v324 = undefined;
    let v341: any;
    closure7(v18, " = ", undefined);
    v341 = undefined;
    let v400: any;
    closure7(v18, toText(interpolate("%A%P()", [v11])), undefined);
    v400 = undefined;
    let v417: any;
    closure7(v18, "; ", undefined);
    v417 = undefined;
    let v436: any;
    closure7(v18, "environment_variables", undefined);
    v436 = undefined;
    let v453: any;
    closure7(v18, " = ", undefined);
    v453 = undefined;
    let v474: any;
    closure7(v18, toText(interpolate("%A%P()", [v12])), undefined);
    v474 = undefined;
    let v491: any;
    closure7(v18, "; ", undefined);
    v491 = undefined;
    let v510: any;
    closure7(v18, "on_line", undefined);
    v510 = undefined;
    let v527: any;
    closure7(v18, " = ", undefined);
    v527 = undefined;
    let v586: any;
    closure7(v18, toText(interpolate("%A%P()", [v13])), undefined);
    v586 = undefined;
    let v603: any;
    closure7(v18, "; ", undefined);
    v603 = undefined;
    let v622: any;
    closure7(v18, "stdin", undefined);
    v622 = undefined;
    let v639: any;
    closure7(v18, " = ", undefined);
    v639 = undefined;
    let v698: any;
    closure7(v18, toText(interpolate("%A%P()", [v14_1])), undefined);
    v698 = undefined;
    let v715: any;
    closure7(v18, "; ", undefined);
    v715 = undefined;
    let v734: any;
    closure7(v18, "trace", undefined);
    v734 = undefined;
    let v751: any;
    closure7(v18, " = ", undefined);
    v751 = undefined;
    let v771: any;
    closure7(v18, v15_1 ? "true" : "false", undefined);
    v771 = undefined;
    let v788: any;
    closure7(v18, "; ", undefined);
    v788 = undefined;
    let v807: any;
    closure7(v18, "working_directory", undefined);
    v807 = undefined;
    let v824: any;
    closure7(v18, " = ", undefined);
    v824 = undefined;
    let v883: any;
    closure7(v18, toText(interpolate("%A%P()", [v16_1])), undefined);
    v883 = undefined;
    let v902: any;
    closure7(v18, " }", undefined);
    v902 = undefined;
    let v919: any;
    closure7(v18, " }", undefined);
    v919 = undefined;
    const v925: string = v18.l0;
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v925);
}

export function closure24(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: int32, v8: string, unitVar: void): void {
    if (method7(US0_US0_1())) {
        let v27: any;
        closure0(undefined, undefined);
        v27 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v53: Option<int64> = patternInput[5];
        const v52: Mut4 = patternInput[4];
        const v51: Mut3 = patternInput[3];
        const v50: Mut2 = patternInput[2];
        const v49: Mut1 = patternInput[1];
        const v48: Mut0 = patternInput[0];
        method17(method54(v48, v49, v50, v51, v52, v53, method8(v48, v49, v50, v51, v52, v53), method36(), v7, v8.length, v0, v1, v2, v3, v4, v5, v6));
    }
}

export function method22(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>): Async<[int32, string]> {
    return singleton.Delay<[int32, string]>((): Async<[int32, string]> => {
        const patternInput: [int32, string] = defaultOf();
        return singleton.Return<[int32, string]>([patternInput[0], patternInput[1]] as [int32, string]);
    });
}

export function method21(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>): Async<[int32, string]> {
    return method22(v0, v1, v2, v3, v4, v5, v6);
}

export function method20(v0: string): Async<[int32, string]> {
    return method21(v0, undefined, [], undefined, undefined, true, undefined);
}

export function closure13(unitVar: void, v0: string): Async<[int32, string]> {
    return method20(v0);
}

export function closure25(unitVar: void, _arg: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>]): Async<[int32, string]> {
    return method21(_arg[0], _arg[1], _arg[2], _arg[3], _arg[4], _arg[5], _arg[6]);
}

export function closure26(unitVar: void, v0: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>] {
    const v20: Heap0 = v0(new Heap0("", undefined, [], undefined, undefined, true, undefined));
    return [v20.l0, v20.l1, v20.l2, v20.l3, v20.l4, v20.l5, v20.l6] as [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>];
}

export function method57(v0_mut: string, v1_mut: int64): boolean {
    method57:
    while (true) {
        const v0: string = v0_mut, v1: int64 = v1_mut;
        if (compare_1(v1, 4n) >= 0) {
            return false;
        }
        else {
            let v19: US9_$union;
            if (equals(v1, 0n)) {
                v19 = US9_US9_0("\\");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1, 1n));
                if (equals(v5, 0n)) {
                    v19 = US9_US9_0("`");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    if (equals(v8, 0n)) {
                        v19 = US9_US9_0("\"");
                    }
                    else {
                        const v11: int64 = toInt64(op_Subtraction(v8, 1n));
                        if (equals(v11, 0n)) {
                            v19 = US9_US9_0(" ");
                        }
                        else {
                            const v14_1: int64 = toInt64(op_Subtraction(v11, 1n));
                            v19 = US9_US9_1();
                        }
                    }
                }
            }
            if (v0 === (((v19.tag as int32) === /* US9_0 */ 0) ? (v19.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_mut = v0;
                v1_mut = toInt64(op_Addition(v1, 1n));
                continue method57;
            }
        }
        break;
    }
}

export function method58(v0_mut: string, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method58:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v114: US7_$union;
        if ("" === v1) {
            v114 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\"", " "], [v2, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v33_1: string = v1[0];
            if (method57(v33_1, 0n) === false) {
                const v47 = 1;
                const v68: int32 = (v1.length - 1) | 0;
                const v70: string = v1.slice(v47, v68 + 1);
                const v76: string = v33_1;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v76.length)), v76, 0n), v2, v3, v4);
                v114 = US7_US7_0(v33_1, v70, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v114 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33_1, ["\\", "`", "\"", " "], [v2, v3, v4] as [any, int32, int32]])));
            }
        }
        if ((v114.tag as int32) === /* US7_0 */ 0) {
            v0_mut = (v0 + (v114.fields[0] as any));
            v1_mut = (v114.fields[1] as any);
            v2_mut = (v114.fields[2] as any);
            v3_mut = (v114.fields[3] as any);
            v4_mut = (v114.fields[4] as any);
            continue method58;
        }
        else {
            const v131 = v114.fields[0] as any;
            return [v0, v1, v2, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method60(v0_mut: string, v1_mut: int64): boolean {
    method60:
    while (true) {
        const v0: string = v0_mut, v1: int64 = v1_mut;
        if (compare_1(v1, 3n) >= 0) {
            return false;
        }
        else {
            let v15_1: US9_$union;
            if (equals(v1, 0n)) {
                v15_1 = US9_US9_0("\\");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1, 1n));
                if (equals(v5, 0n)) {
                    v15_1 = US9_US9_0("`");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    if (equals(v8, 0n)) {
                        v15_1 = US9_US9_0("\"");
                    }
                    else {
                        const v11: int64 = toInt64(op_Subtraction(v8, 1n));
                        v15_1 = US9_US9_1();
                    }
                }
            }
            if (v0 === (((v15_1.tag as int32) === /* US9_0 */ 0) ? (v15_1.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_mut = v0;
                v1_mut = toInt64(op_Addition(v1, 1n));
                continue method60;
            }
        }
        break;
    }
}

export function closure28(unitVar: void, _arg: [string, any, int32, int32]): US8_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    let v125: US7_$union;
    if ("" === v0) {
        v125 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\\", [v1, v2, v3] as [any, int32, int32]])));
    }
    else {
        const v10: string = v0[0];
        if (v10 === "\\") {
            const v22 = 1;
            const v43: int32 = (v0.length - 1) | 0;
            const v45: string = v0.slice(v22, v43 + 1);
            const v51: string = v10;
            const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v51.length)), v51, 0n), v1, v2, v3);
            v125 = US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v66: int32 = (v0.indexOf("\n") - 1) | 0;
            const v81 = 0;
            const v102: int32 = (((-2 === v66) ? (v0.length + 1) : (v66 + 1)) - 1) | 0;
            v125 = US7_US7_1(concat(`parsing.p_char / expected: '${"\\"}' / line: ${v2} / col: ${v3}
${v1}${v0.slice(v81, v102 + 1)}`, "\n", method27(v3 - 1, 0)("") + "^", ..."\n"));
        }
    }
    let v196: US7_$union;
    if ((v125.tag as int32) === /* US7_0 */ 0) {
        const v130: int32 = (v125.fields[4] as any) | 0;
        const v129: int32 = (v125.fields[3] as any) | 0;
        const v128 = v125.fields[2] as any;
        const v127 = v125.fields[1] as any;
        const v126 = v125.fields[0] as any;
        if ("" === v127) {
            v196 = US7_US7_1(toText(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [[v128, v129, v130] as [any, int32, int32]])));
        }
        else {
            const v142: string = v127[0];
            const v153 = 1;
            const v174: int32 = (v127.length - 1) | 0;
            const v176: string = v127.slice(v153, v174 + 1);
            const v182: string = v142;
            const patternInput_1: [any, int32, int32] = method26(method25(toInt64(fromInt32(v182.length)), v182, 0n), v128, v129, v130);
            v196 = US7_US7_0(v142, v176, patternInput_1[0], patternInput_1[1], patternInput_1[2]);
        }
    }
    else {
        v196 = US7_US7_1(v125.fields[0] as any);
    }
    if ((v196.tag as int32) === /* US7_0 */ 0) {
        return US8_US8_0("\\" + (v196.fields[0] as any), v196.fields[1] as any, v196.fields[2] as any, v196.fields[3] as any, v196.fields[4] as any);
    }
    else {
        return US8_US8_1(v196.fields[0] as any);
    }
}

export function closure29(unitVar: void, _arg: [string, any, int32, int32]): US8_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    let v125: US7_$union;
    if ("" === v0) {
        v125 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["`", [v1, v2, v3] as [any, int32, int32]])));
    }
    else {
        const v10: string = v0[0];
        if (v10 === "`") {
            const v22 = 1;
            const v43: int32 = (v0.length - 1) | 0;
            const v45: string = v0.slice(v22, v43 + 1);
            const v51: string = v10;
            const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v51.length)), v51, 0n), v1, v2, v3);
            v125 = US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v66: int32 = (v0.indexOf("\n") - 1) | 0;
            const v81 = 0;
            const v102: int32 = (((-2 === v66) ? (v0.length + 1) : (v66 + 1)) - 1) | 0;
            v125 = US7_US7_1(concat(`parsing.p_char / expected: '${"`"}' / line: ${v2} / col: ${v3}
${v1}${v0.slice(v81, v102 + 1)}`, "\n", method27(v3 - 1, 0)("") + "^", ..."\n"));
        }
    }
    let v196: US7_$union;
    if ((v125.tag as int32) === /* US7_0 */ 0) {
        const v130: int32 = (v125.fields[4] as any) | 0;
        const v129: int32 = (v125.fields[3] as any) | 0;
        const v128 = v125.fields[2] as any;
        const v127 = v125.fields[1] as any;
        const v126 = v125.fields[0] as any;
        if ("" === v127) {
            v196 = US7_US7_1(toText(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [[v128, v129, v130] as [any, int32, int32]])));
        }
        else {
            const v142: string = v127[0];
            const v153 = 1;
            const v174: int32 = (v127.length - 1) | 0;
            const v176: string = v127.slice(v153, v174 + 1);
            const v182: string = v142;
            const patternInput_1: [any, int32, int32] = method26(method25(toInt64(fromInt32(v182.length)), v182, 0n), v128, v129, v130);
            v196 = US7_US7_0(v142, v176, patternInput_1[0], patternInput_1[1], patternInput_1[2]);
        }
    }
    else {
        v196 = US7_US7_1(v125.fields[0] as any);
    }
    if ((v196.tag as int32) === /* US7_0 */ 0) {
        return US8_US8_0("`" + (v196.fields[0] as any), v196.fields[1] as any, v196.fields[2] as any, v196.fields[3] as any, v196.fields[4] as any);
    }
    else {
        return US8_US8_1(v196.fields[0] as any);
    }
}

export function method61(v0_mut: string, v1_mut: any, v2_mut: int32, v3_mut: int32, v4_mut: UH3_$union): US8_$union {
    method61:
    while (true) {
        const v0: string = v0_mut, v1: any = v1_mut, v2: int32 = v2_mut, v3: int32 = v3_mut, v4: UH3_$union = v4_mut;
        if ((v4.tag as int32) === /* UH3_0 */ 0) {
            return US8_US8_1("parsing.choice / no parsers succeeded");
        }
        else {
            const v8 = v4.fields[1] as any;
            const v9: US8_$union = (v4.fields[0] as any)([v0, v1, v2, v3] as [string, any, int32, int32]);
            if ((v9.tag as int32) === /* US8_0 */ 0) {
                const v14_1: int32 = (v9.fields[4] as any) | 0;
                const v13: int32 = (v9.fields[3] as any) | 0;
                const v12 = v9.fields[2] as any;
                const v11 = v9.fields[1] as any;
                const v10 = v9.fields[0] as any;
                return v9;
            }
            else {
                const v15_1 = v9.fields[0] as any;
                v0_mut = v0;
                v1_mut = v1;
                v2_mut = v2;
                v3_mut = v3;
                v4_mut = v8;
                continue method61;
            }
        }
        break;
    }
}

export function method62(v0_mut: UH2_$union, v1_mut: UH2_$union): UH2_$union {
    method62:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: UH2_$union = v1_mut;
        if ((v0.tag as int32) === /* UH2_0 */ 0) {
            return v1;
        }
        else {
            v0_mut = (v0.fields[1] as any);
            v1_mut = UH2_UH2_1(v0.fields[0] as any, v1);
            continue method62;
        }
        break;
    }
}

export function method59(v0_mut: UH2_$union, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): US17_$union {
    method59:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v106: US7_$union;
        if ("" === v1) {
            v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\""], [v2, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v29: string = v1[0];
            if (method60(v29, 0n) === false) {
                const v43 = 1;
                const v64: int32 = (v1.length - 1) | 0;
                const v66: string = v1.slice(v43, v64 + 1);
                const v72: string = v29;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v72.length)), v72, 0n), v2, v3, v4);
                v106 = US7_US7_0(v29, v66, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, ["\\", "`", "\""], [v2, v3, v4] as [any, int32, int32]])));
            }
        }
        const v121: US8_$union = ((v106.tag as int32) === /* US7_0 */ 0) ? US8_US8_0(v106.fields[0] as any, v106.fields[1] as any, v106.fields[2] as any, v106.fields[3] as any, v106.fields[4] as any) : US8_US8_1(v106.fields[0] as any);
        let v135: US8_$union;
        if ((v121.tag as int32) === /* US8_0 */ 0) {
            const v126: int32 = (v121.fields[4] as any) | 0;
            const v125: int32 = (v121.fields[3] as any) | 0;
            const v124 = v121.fields[2] as any;
            const v123 = v121.fields[1] as any;
            const v122 = v121.fields[0] as any;
            v135 = v121;
        }
        else {
            const v127 = v121.fields[0] as any;
            v135 = method61(v1, v2, v3, v4, UH3_UH3_1((arg10$0040: [string, any, int32, int32]): US8_$union => closure28(undefined, arg10$0040), UH3_UH3_1((arg10$0040_1: [string, any, int32, int32]): US8_$union => closure29(undefined, arg10$0040_1), UH3_UH3_0())));
        }
        if ((v135.tag as int32) === /* US8_0 */ 0) {
            v0_mut = UH2_UH2_1(v135.fields[0] as any, v0);
            v1_mut = (v135.fields[1] as any);
            v2_mut = (v135.fields[2] as any);
            v3_mut = (v135.fields[3] as any);
            v4_mut = (v135.fields[4] as any);
            continue method59;
        }
        else {
            const v143 = v135.fields[0] as any;
            return US17_US17_0(method62(v0, UH2_UH2_0()), v1, v2, v3, v4);
        }
        break;
    }
}

export function method63(v0: UH2_$union, v1: FSharpList<string>): FSharpList<string> {
    if ((v0.tag as int32) === /* UH2_0 */ 0) {
        return v1;
    }
    else {
        return cons(v0.fields[0] as any, method63(v0.fields[1] as any, v1));
    }
}

export function method64(v0_mut: UH2_$union, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): US17_$union {
    method64:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v106: US7_$union;
        if ("" === v1) {
            v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\""], [v2, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v29: string = v1[0];
            if (method60(v29, 0n) === false) {
                const v43 = 1;
                const v64: int32 = (v1.length - 1) | 0;
                const v66: string = v1.slice(v43, v64 + 1);
                const v72: string = v29;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v72.length)), v72, 0n), v2, v3, v4);
                v106 = US7_US7_0(v29, v66, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, ["\\", "`", "\""], [v2, v3, v4] as [any, int32, int32]])));
            }
        }
        const v121: US8_$union = ((v106.tag as int32) === /* US7_0 */ 0) ? US8_US8_0(v106.fields[0] as any, v106.fields[1] as any, v106.fields[2] as any, v106.fields[3] as any, v106.fields[4] as any) : US8_US8_1(v106.fields[0] as any);
        if ((v121.tag as int32) === /* US8_0 */ 0) {
            v0_mut = UH2_UH2_1(v121.fields[0] as any, v0);
            v1_mut = (v121.fields[1] as any);
            v2_mut = (v121.fields[2] as any);
            v3_mut = (v121.fields[3] as any);
            v4_mut = (v121.fields[4] as any);
            continue method64;
        }
        else {
            const v129 = v121.fields[0] as any;
            return US17_US17_0(method62(v0, UH2_UH2_0()), v1, v2, v3, v4);
        }
        break;
    }
}

export function method56(v0_mut: UH2_$union, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): US17_$union {
    method56:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        const v5: boolean = "" === v1;
        let v114: US7_$union;
        if (v5) {
            v114 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\"", " "], [v2, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v33_1: string = v1[0];
            if (method57(v33_1, 0n) === false) {
                const v47 = 1;
                const v68: int32 = (v1.length - 1) | 0;
                const v70: string = v1.slice(v47, v68 + 1);
                const v76: string = v33_1;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v76.length)), v76, 0n), v2, v3, v4);
                v114 = US7_US7_0(v33_1, v70, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v114 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33_1, ["\\", "`", "\"", " "], [v2, v3, v4] as [any, int32, int32]])));
            }
        }
        let v134: US8_$union;
        if ((v114.tag as int32) === /* US7_0 */ 0) {
            const patternInput_1: [string, string, any, int32, int32] = method58(v114.fields[0] as any, v114.fields[1] as any, v114.fields[2] as any, v114.fields[3] as any, v114.fields[4] as any);
            v134 = US8_US8_0(patternInput_1[0], patternInput_1[1], patternInput_1[2], patternInput_1[3], patternInput_1[4]);
        }
        else {
            v134 = US8_US8_1(v114.fields[0] as any);
        }
        let v522: US8_$union;
        if ((v134.tag as int32) === /* US8_0 */ 0) {
            const v139: int32 = (v134.fields[4] as any) | 0;
            const v138: int32 = (v134.fields[3] as any) | 0;
            const v137 = v134.fields[2] as any;
            const v136 = v134.fields[1] as any;
            const v135 = v134.fields[0] as any;
            v522 = v134;
        }
        else {
            const v140 = v134.fields[0] as any;
            let v261: US7_$union;
            if (v5) {
                v261 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", [v2, v3, v4] as [any, int32, int32]])));
            }
            else {
                const v146: string = v1[0];
                if (v146 === "\"") {
                    const v158 = 1;
                    const v179: int32 = (v1.length - 1) | 0;
                    const v181: string = v1.slice(v158, v179 + 1);
                    const v187: string = v146;
                    const patternInput_2: [any, int32, int32] = method26(method25(toInt64(fromInt32(v187.length)), v187, 0n), v2, v3, v4);
                    v261 = US7_US7_0(v146, v181, patternInput_2[0], patternInput_2[1], patternInput_2[2]);
                }
                else {
                    const v202: int32 = (v1.indexOf("\n") - 1) | 0;
                    const v217 = 0;
                    const v238: int32 = (((-2 === v202) ? (v1.length + 1) : (v202 + 1)) - 1) | 0;
                    v261 = US7_US7_1(concat(`parsing.p_char / expected: '${"\""}' / line: ${v3} / col: ${v4}
${v2}${v1.slice(v217, v238 + 1)}`, "\n", method27(v4 - 1, 0)("") + "^", ..."\n"));
                }
            }
            let v451: US8_$union;
            if ((v261.tag as int32) === /* US7_0 */ 0) {
                const v266: int32 = (v261.fields[4] as any) | 0;
                const v265: int32 = (v261.fields[3] as any) | 0;
                const v264 = v261.fields[2] as any;
                const v263 = v261.fields[1] as any;
                const v262 = v261.fields[0] as any;
                const v268: US17_$union = method59(UH2_UH2_0(), v263, v264, v265, v266);
                let v301: US8_$union;
                if ((v268.tag as int32) === /* US17_0 */ 0) {
                    const v273: int32 = (v268.fields[4] as any) | 0;
                    const v272: int32 = (v268.fields[3] as any) | 0;
                    const v271 = v268.fields[2] as any;
                    const v270 = v268.fields[1] as any;
                    const v275: FSharpList<string> = method63(v268.fields[0] as any, empty<string>());
                    v301 = US8_US8_0(join("", delay<string>((): Iterable<string> => v275)), v270, v271, v272, v273);
                }
                else {
                    v301 = US8_US8_1(v268.fields[0] as any);
                }
                if ((v301.tag as int32) === /* US8_0 */ 0) {
                    const v306: int32 = (v301.fields[4] as any) | 0;
                    const v305: int32 = (v301.fields[3] as any) | 0;
                    const v304 = v301.fields[2] as any;
                    const v303 = v301.fields[1] as any;
                    const v302 = v301.fields[0] as any;
                    let v428: US7_$union;
                    if ("" === v303) {
                        v428 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", [v304, v305, v306] as [any, int32, int32]])));
                    }
                    else {
                        const v313: string = v303[0];
                        if (v313 === "\"") {
                            const v325 = 1;
                            const v346: int32 = (v303.length - 1) | 0;
                            const v348: string = v303.slice(v325, v346 + 1);
                            const v354: string = v313;
                            const patternInput_3: [any, int32, int32] = method26(method25(toInt64(fromInt32(v354.length)), v354, 0n), v304, v305, v306);
                            v428 = US7_US7_0(v313, v348, patternInput_3[0], patternInput_3[1], patternInput_3[2]);
                        }
                        else {
                            const v369: int32 = (v303.indexOf("\n") - 1) | 0;
                            const v384 = 0;
                            const v405: int32 = (((-2 === v369) ? (v303.length + 1) : (v369 + 1)) - 1) | 0;
                            v428 = US7_US7_1(concat(`parsing.p_char / expected: '${"\""}' / line: ${v305} / col: ${v306}
${v304}${v303.slice(v384, v405 + 1)}`, "\n", method27(v306 - 1, 0)("") + "^", ..."\n"));
                        }
                    }
                    if ((v428.tag as int32) === /* US7_0 */ 0) {
                        const v429 = v428.fields[0] as any;
                        v451 = US8_US8_0(v302, v428.fields[1] as any, v428.fields[2] as any, v428.fields[3] as any, v428.fields[4] as any);
                    }
                    else {
                        v451 = US8_US8_1(toText(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v428.fields[0] as any, [v1, v2, v3, v4] as [string, any, int32, int32], [v263, v264, v265, v266] as [string, any, int32, int32], [v303, v304, v305, v306] as [string, any, int32, int32]])));
                    }
                }
                else {
                    const v443 = v301.fields[0] as any;
                    v451 = US8_US8_1("parsing.between / expected content");
                }
            }
            else {
                v451 = US8_US8_1(v261.fields[0] as any);
            }
            if ((v451.tag as int32) === /* US8_0 */ 0) {
                const v456: int32 = (v451.fields[4] as any) | 0;
                const v455: int32 = (v451.fields[3] as any) | 0;
                const v454 = v451.fields[2] as any;
                const v453 = v451.fields[1] as any;
                const v452 = v451.fields[0] as any;
                v522 = v451;
            }
            else {
                const v457 = v451.fields[0] as any;
                const v463: US8_$union = method61(v1, v2, v3, v4, UH3_UH3_1((arg10$0040: [string, any, int32, int32]): US8_$union => closure28(undefined, arg10$0040), UH3_UH3_1((arg10$0040_1: [string, any, int32, int32]): US8_$union => closure29(undefined, arg10$0040_1), UH3_UH3_0())));
                let v474: US8_$union;
                if ((v463.tag as int32) === /* US8_0 */ 0) {
                    const v464 = v463.fields[0] as any;
                    v474 = US8_US8_0("", v463.fields[1] as any, v463.fields[2] as any, v463.fields[3] as any, v463.fields[4] as any);
                }
                else {
                    v474 = US8_US8_1(v463.fields[0] as any);
                }
                let v485: US17_$union;
                if ((v474.tag as int32) === /* US8_0 */ 0) {
                    const v475 = v474.fields[0] as any;
                    v485 = method64(UH2_UH2_0(), v474.fields[1] as any, v474.fields[2] as any, v474.fields[3] as any, v474.fields[4] as any);
                }
                else {
                    v485 = US17_US17_1(v474.fields[0] as any);
                }
                if ((v485.tag as int32) === /* US17_0 */ 0) {
                    const v490: int32 = (v485.fields[4] as any) | 0;
                    const v489: int32 = (v485.fields[3] as any) | 0;
                    const v488 = v485.fields[2] as any;
                    const v487 = v485.fields[1] as any;
                    const v492: FSharpList<string> = method63(v485.fields[0] as any, empty<string>());
                    v522 = US8_US8_0(join("", delay<string>((): Iterable<string> => v492)), v487, v488, v489, v490);
                }
                else {
                    v522 = US8_US8_1(v485.fields[0] as any);
                }
            }
        }
        if ((v522.tag as int32) === /* US8_0 */ 0) {
            const v527: int32 = (v522.fields[4] as any) | 0;
            const v526: int32 = (v522.fields[3] as any) | 0;
            const v525 = v522.fields[2] as any;
            const v524 = v522.fields[1] as any;
            const v523 = v522.fields[0] as any;
            const v529: int32 = method34(v524, 0) | 0;
            let v571: US10_$union;
            if (0 === v529) {
                v571 = US10_US10_1("parsing.spaces1 / expected at least one space");
            }
            else {
                const v543: int32 = v529 | 0;
                const v564: int32 = (v524.length - 1) | 0;
                v571 = US10_US10_0(v524.slice(v543, v564 + 1), v525, v526, v527);
            }
            if ((v571.tag as int32) === /* US10_0 */ 0) {
                v0_mut = UH2_UH2_1(v523, v0);
                v1_mut = (v571.fields[0] as any);
                v2_mut = (v571.fields[1] as any);
                v3_mut = (v571.fields[2] as any);
                v4_mut = (v571.fields[3] as any);
                continue method56;
            }
            else {
                const v578 = v571.fields[0] as any;
                return US17_US17_0(method62(v0, UH2_UH2_1(v523, UH2_UH2_0())), v524, v525, v526, v527);
            }
        }
        else {
            const v585 = v522.fields[0] as any;
            return US17_US17_0(method62(v0, UH2_UH2_0()), v1, v2, v3, v4);
        }
        break;
    }
}

export function method55(v0: string): US16_$union {
    let _v0: Option<Option<string>> = undefined;
    _v0 = some(v0);
    const v22: US17_$union = method56(UH2_UH2_0(), defaultArg((_v0 == null) ? (() => {
        throw new Error("optionm\'.of_obj / _v0=None");
    })() : value_12(_v0), ""), StringBuilder_$ctor_Z721C83C5(method24()), 1, 1);
    if ((v22.tag as int32) === /* US17_0 */ 0) {
        const v27: int32 = (v22.fields[4] as any) | 0;
        const v26: int32 = (v22.fields[3] as any) | 0;
        const v25 = v22.fields[2] as any;
        const v24 = v22.fields[1] as any;
        return US16_US16_0(toArray<string>(method63(v22.fields[0] as any, empty<string>())));
    }
    else {
        return US16_US16_1(v22.fields[0] as any);
    }
}

export function closure27(unitVar: void, v0: string): FSharpResult$2_$union<string[], string> {
    const v1: US16_$union = method55(v0);
    if ((v1.tag as int32) === /* US16_0 */ 0) {
        return FSharpResult$2_Ok<string[], string>(v1.fields[0] as any);
    }
    else {
        return FSharpResult$2_Error<string[], string>(v1.fields[0] as any);
    }
}

export const v14: any = undefined;

export const v15 = (): void => {
    closure0(undefined, undefined);
};

export const v16: any = (v15(), v14);

export const v31 = (): void => {
    closure3(undefined, undefined);
};

export function current_process_kill(): void {
    v31();
}

export const v32 = (v: string): Async<[int32, string]> => closure13(undefined, v);

export function execute_async(x: string): Async<[int32, string]> {
    return v32(x);
}

export const v33 = (arg10$0040: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>]): Async<[int32, string]> => closure25(undefined, arg10$0040);

export function execute_with_options_async(x: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>]): Async<[int32, string]> {
    return v33(x);
}

export const v34 = (v: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>] => closure26(undefined, v);

export function execution_options(x: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>] {
    return v34(x);
}

export const v35 = (v: string): FSharpResult$2_$union<string[], string> => closure27(undefined, v);

export function split_args(x: string): FSharpResult$2_$union<string[], string> {
    return v35(x);
}


