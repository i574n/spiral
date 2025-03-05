import { defaultOf, uncurry2, compare, IComparable, IEquatable, createAtom } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Util.js";
import { some, map, defaultArg, value as value_12, Option } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Option.js";
import { equals, compare as compare_1, op_Addition, op_Subtraction, fromInt64, toInt64, int64 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/BigInt.js";
import { Record, Union } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Types.js";
import { array_type, option_type, tuple_type, int32_type, class_type, char_type, bool_type, lambda_type, unit_type, string_type, record_type, int64_type, union_type, TypeInfo } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Reflection.js";
import { int32 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Int32.js";
import { singleton, Async } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/AsyncBuilder.js";
import { toString, create, now, getTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Date.js";
import { ofSeq, find } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Map.js";
import { milliseconds, seconds, minutes, hours, fromTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/TimeSpan.js";
import { join, concat, interpolate, toText, trimStart, trimEnd } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/String.js";
import { StringBuilder_$ctor_Z721C83C5, StringBuilder__Append_Z721C83C5, StringBuilder__Clear } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/System.Text.js";
import { setItem, fill } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Array.js";
import { toArray, empty, cons, foldBack, FSharpList, ofArray } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/List.js";
import { awaitTask, startImmediate } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Async.js";
import { delay } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Seq.js";
import { FSharpResult$2_$union, FSharpResult$2_Error, FSharpResult$2_Ok } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Result.js";

export let TraceState_trace_state = createAtom<Option<[Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>]>>(undefined);

export interface IOsEnviron {
    environ(): any
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
    return union_type("Runtime.US4", [], US4, () => [[["f0_0", US3_$reflection()]], [["f1_0", US3_$reflection()]], [["f2_0", US3_$reflection()]], [["f3_0", US3_$reflection()]], [["f4_0", US3_$reflection()]], [["f5_0", US3_$reflection()]]]);
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

export function method3(v0_1: string): string {
    return v0_1;
}

export function method4(): string {
    return "";
}

export function closure1(unitVar: void, v0_1: string): US5_$union {
    return US5_US5_0(v0_1);
}

export function method5(): ((arg0: string) => US5_$union) {
    return (v: string): US5_$union => closure1(undefined, v);
}

export function method2(v0_1: string): string {
    return process.env[v0_1] ?? "";
}

export function method1(): [US1_$union, US2_$union] {
    let v13: US1_$union, v20_1: US1_$union, v27: US1_$union, v34: US1_$union;
    const v1_1: string = method2("TRACE_LEVEL");
    const v6: US1_$union = ("Verbose" === v1_1) ? US1_US1_0(US0_US0_0()) : US1_US1_1();
    return [((v6.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v6.fields[0] as any) : ((v13 = (("Debug" === v1_1) ? US1_US1_0(US0_US0_1()) : US1_US1_1()), ((v13.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v13.fields[0] as any) : ((v20_1 = (("Info" === v1_1) ? US1_US1_0(US0_US0_2()) : US1_US1_1()), ((v20_1.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v20_1.fields[0] as any) : ((v27 = (("Warning" === v1_1) ? US1_US1_0(US0_US0_3()) : US1_US1_1()), ((v27.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v27.fields[0] as any) : ((v34 = (("Critical" === v1_1) ? US1_US1_0(US0_US0_4()) : US1_US1_1()), ((v34.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v34.fields[0] as any) : US1_US1_1())))))))), (method2("AUTOMATION") !== "True") ? US2_US2_1() : US2_US2_0(toInt64(fromInt64(getTicks(now()))))] as [US1_$union, US2_$union];
}

export function closure2(unitVar: void, v0_1: string): void {
}

export function method0(v0_1: US0_$union): [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] {
    const patternInput: [US1_$union, US2_$union] = method1();
    const _run_target_args$0027_v3 = [patternInput[0], patternInput[1]] as [US1_$union, US2_$union];
    const v173: US2_$union = _run_target_args$0027_v3[1];
    const v172: US1_$union = _run_target_args$0027_v3[0];
    return [new Mut0(1n), new Mut1((v: string): void => {
        closure2(undefined, v);
    }), new Mut2(true), new Mut3(""), new Mut4(((v172.tag as int32) === /* US1_0 */ 0) ? (v172.fields[0] as any) : v0_1), ((v173.tag as int32) === /* US2_0 */ 0) ? (v173.fields[0] as any) : undefined] as [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>];
}

export function closure0(unitVar: void, unitVar_1: void): void {
    if (TraceState_trace_state() == null) {
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = method0(US0_US0_0());
        TraceState_trace_state([patternInput[0], patternInput[1], patternInput[2], patternInput[3], patternInput[4], patternInput[5]] as [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>]);
    }
}

export function method7(v0_1: US0_$union): boolean {
    let v3: any;
    closure0(undefined, undefined);
    v3 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
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

export function method9(): ((arg0: int64) => US2_$union) {
    return (v: int64): US2_$union => closure6(undefined, v);
}

export function method10(): string {
    return "hh:mm:ss";
}

export function method11(): string {
    return "HH:mm:ss";
}

export function method8(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>): string {
    const v551: US2_$union = defaultArg(map<int64, US2_$union>(method9(), v5), US2_US2_1());
    let v669: Date;
    if ((v551.tag as int32) === /* US2_0 */ 0) {
        const v555 = v551.fields[0] as any;
        const v621: number = fromTicks(toInt64(op_Subtraction(toInt64(fromInt64(getTicks(now()))), v555)));
        v669 = create(1, 1, 1, hours(v621), minutes(v621), seconds(v621), milliseconds(v621));
    }
    else {
        v669 = now();
    }
    const v671: string = method11();
    return toString(v669, (v671 === "") ? "M-d-y hh:mm:ss tt" : v671);
}

export function method14(): string {
    return "";
}

export function closure7(v0_1: Mut3, v1_1: string, unitVar: void): void {
    const v3: string = v0_1.l0 + v1_1;
    v0_1.l0 = v3;
}

export function method13(v0_1: string): string {
    const v2_1: Mut3 = new Mut3(method14());
    let v9: any;
    closure7(v2_1, `${v0_1}`, undefined);
    v9 = undefined;
    return v2_1.l0;
}

export function method15(): string {
    return "\u001b[0m";
}

export function method12(): string {
    const v3: string = "Warning".toLocaleLowerCase();
    return ("\u001b[93m" + method13(v3[0])) + method15();
}

export function method17(): string {
    const v1_1: Mut3 = new Mut3(method14());
    return v1_1.l0;
}

export function method18(v0_1: string): string {
    return trimEnd(trimStart(v0_1, ...[]), ...[" ", "/"]);
}

export function method16(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v8: string = method17();
    return method18(`${v6} ${v7} #${v0_1.l0} ${"runtime.current_process_kill / exiting... 3"} / ${v8}`);
}

export function closure8(v0_1: Mut0, unitVar: void): void {
    const v2_1: int64 = toInt64(op_Addition(v0_1.l0, 1n));
    v0_1.l0 = v2_1;
}

export function closure10(v0_1: string, unitVar: void): void {
    console.log(v0_1);
}

export function closure9(unitVar: void, v0_1: string): void {
    let v3: any;
    closure10(v0_1, undefined);
    v3 = undefined;
}

export function method19(v0_1: string): void {
    let v3: any;
    closure0(undefined, undefined);
    v3 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    let v44: any;
    closure8(patternInput[0], undefined);
    v44 = undefined;
    closure9(undefined, v0_1);
    patternInput[1].l0(v0_1);
}

export function closure5(unitVar: void, unitVar_1: void): void {
    if (method7(US0_US0_3())) {
        let v4: any;
        closure0(undefined, undefined);
        v4 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v30: Option<int64> = patternInput[5];
        const v29: Mut4 = patternInput[4];
        const v28: Mut3 = patternInput[3];
        const v27: Mut2 = patternInput[2];
        const v26: Mut1 = patternInput[1];
        const v25: Mut0 = patternInput[0];
        method19(method16(v25, v26, v27, v28, v29, v30, method8(v25, v26, v27, v28, v29, v30), method12()));
    }
}

export function method20(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v8: string = method17();
    return method18(`${v6} ${v7} #${v0_1.l0} ${"runtime.current_process_kill / exiting... 2"} / ${v8}`);
}

export function closure11(unitVar: void, unitVar_1: void): void {
    if (method7(US0_US0_3())) {
        let v4: any;
        closure0(undefined, undefined);
        v4 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v30: Option<int64> = patternInput[5];
        const v29: Mut4 = patternInput[4];
        const v28: Mut3 = patternInput[3];
        const v27: Mut2 = patternInput[2];
        const v26: Mut1 = patternInput[1];
        const v25: Mut0 = patternInput[0];
        method19(method20(v25, v26, v27, v28, v29, v30, method8(v25, v26, v27, v28, v29, v30), method12()));
    }
}

export function method21(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v8: string = method17();
    return method18(`${v6} ${v7} #${v0_1.l0} ${"runtime.current_process_kill / exiting... 1"} / ${v8}`);
}

export function closure12(unitVar: void, unitVar_1: void): void {
    if (method7(US0_US0_3())) {
        let v4: any;
        closure0(undefined, undefined);
        v4 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v30: Option<int64> = patternInput[5];
        const v29: Mut4 = patternInput[4];
        const v28: Mut3 = patternInput[3];
        const v27: Mut2 = patternInput[2];
        const v26: Mut1 = patternInput[1];
        const v25: Mut0 = patternInput[0];
        method19(method21(v25, v26, v27, v28, v29, v30, method8(v25, v26, v27, v28, v29, v30), method12()));
    }
}

export function closure4(unitVar: void, unitVar_1: void): void {
}

export function method6(): void {
}

export function closure3(unitVar: void, unitVar_1: void): void {
    method6();
}

export function method26(): string {
    return "";
}

export function method27(v0_1: int32, v1_1: Mut5): boolean {
    return v1_1.l0 < v0_1;
}

export function closure16(v0_1: string, v1_1: UH0_$union): UH0_$union {
    return UH0_UH0_1(v0_1, v1_1);
}

export function closure15(unitVar: void, v0_1: string): ((arg0: UH0_$union) => UH0_$union) {
    return (v: UH0_$union): UH0_$union => closure16(v0_1, v);
}

export function method28(): ((arg0: string) => ((arg0: UH0_$union) => UH0_$union)) {
    return (v: string): ((arg0: UH0_$union) => UH0_$union) => closure15(undefined, v);
}

export function method29(v0_1_mut: UH0_$union, v1_1_mut: any, v2_1_mut: int32, v3_mut: int32): [any, int32, int32] {
    let v13: any, v24: any;
    method29:
    while (true) {
        const v0_1: UH0_$union = v0_1_mut, v1_1: any = v1_1_mut, v2_1: int32 = v2_1_mut, v3: int32 = v3_mut;
        if ((v0_1.tag as int32) === /* UH0_0 */ 0) {
            return [v1_1, v2_1, v3] as [any, int32, int32];
        }
        else {
            const v4 = v0_1.fields[0] as any;
            const v6: boolean = "\n" === v4;
            const patternInput: [int32, int32] = v6 ? ([v2_1 + 1, 1] as [int32, int32]) : ([v2_1, v3 + 1] as [int32, int32]);
            v0_1_mut = (v0_1.fields[1] as any);
            v1_1_mut = (v6 ? ((v13 = StringBuilder__Clear(v1_1), v1_1)) : ((v24 = StringBuilder__Append_Z721C83C5(v1_1, v4), v1_1)));
            v2_1_mut = patternInput[0];
            v3_mut = patternInput[1];
            continue method29;
        }
        break;
    }
}

export function closure17(v0_1: int32, v1_1: int32, v2_1: string): string {
    if (v1_1 >= v0_1) {
        return v2_1;
    }
    else {
        return method30(v0_1, v1_1 + 1)(v2_1 + " ");
    }
}

export function method30(v0_1: int32, v1_1: int32): ((arg0: string) => string) {
    return (v: string): string => closure17(v0_1, v1_1, v);
}

export function closure14(unitVar: void, _arg: [string, any, int32, int32]): US7_$union {
    const v3: int32 = _arg[3] | 0;
    const v2_1: int32 = _arg[2] | 0;
    const v1_1: any = _arg[1];
    const v0_1: string = _arg[0];
    if ("" === v0_1) {
        return US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", [v1_1, v2_1, v3] as [any, int32, int32]])));
    }
    else {
        const v10: string = v0_1[0];
        if (v10 === "\"") {
            const v22 = 1;
            const v43: int32 = (v0_1.length - 1) | 0;
            const v45: string = v0_1.slice(v22, v43 + 1);
            const v51: string = v10;
            const v54: int32 = v51.length | 0;
            const v55: string[] = fill(new Array(v54), 0, v54, "");
            const v56: Mut5 = new Mut5(0);
            while (method27(v54, v56)) {
                const v58: int32 = v56.l0 | 0;
                const v59: string = v51[v58];
                setItem(v55, v58, v59);
                const v60: int32 = (v58 + 1) | 0;
                v56.l0 = (v60 | 0);
            }
            const v62: FSharpList<string> = ofArray<string>(v55);
            const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v62, UH0_UH0_0()), v1_1, v2_1, v3);
            return US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v113: int32 = (v0_1.indexOf("\n") - 1) | 0;
            const v128 = 0;
            const v149: int32 = (((-2 === v113) ? (v0_1.length + 1) : (v113 + 1)) - 1) | 0;
            return US7_US7_1(concat(`parsing.p_char / expected: '${"\""}' / line: ${v2_1} / col: ${v3}
${v1_1}${v0_1.slice(v128, v149 + 1)}`, "\n", method30(v3 - 1, 0)("") + "^", ..."\n"));
        }
    }
}

export function closure18(unitVar: void, _arg: [string, any, int32, int32]): US7_$union {
    const v3: int32 = _arg[3] | 0;
    const v2_1: int32 = _arg[2] | 0;
    const v1_1: any = _arg[1];
    const v0_1: string = _arg[0];
    if ("" === v0_1) {
        return US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\'", [v1_1, v2_1, v3] as [any, int32, int32]])));
    }
    else {
        const v10: string = v0_1[0];
        if (v10 === "\'") {
            const v22 = 1;
            const v43: int32 = (v0_1.length - 1) | 0;
            const v45: string = v0_1.slice(v22, v43 + 1);
            const v51: string = v10;
            const v54: int32 = v51.length | 0;
            const v55: string[] = fill(new Array(v54), 0, v54, "");
            const v56: Mut5 = new Mut5(0);
            while (method27(v54, v56)) {
                const v58: int32 = v56.l0 | 0;
                const v59: string = v51[v58];
                setItem(v55, v58, v59);
                const v60: int32 = (v58 + 1) | 0;
                v56.l0 = (v60 | 0);
            }
            const v62: FSharpList<string> = ofArray<string>(v55);
            const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v62, UH0_UH0_0()), v1_1, v2_1, v3);
            return US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v113: int32 = (v0_1.indexOf("\n") - 1) | 0;
            const v128 = 0;
            const v149: int32 = (((-2 === v113) ? (v0_1.length + 1) : (v113 + 1)) - 1) | 0;
            return US7_US7_1(concat(`parsing.p_char / expected: '${"\'"}' / line: ${v2_1} / col: ${v3}
${v1_1}${v0_1.slice(v128, v149 + 1)}`, "\n", method30(v3 - 1, 0)("") + "^", ..."\n"));
        }
    }
}

export function method31(v0_1_mut: string, v1_1_mut: any, v2_1_mut: UH1_$union): US7_$union {
    method31:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: any = v1_1_mut, v2_1: UH1_$union = v2_1_mut;
        if ((v2_1.tag as int32) === /* UH1_0 */ 0) {
            return US7_US7_1("parsing.choice / no parsers succeeded");
        }
        else {
            const v6 = v2_1.fields[1] as any;
            const v7: US7_$union = (v2_1.fields[0] as any)([v0_1, v1_1, 1, 1] as [string, any, int32, int32]);
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
                v0_1_mut = v0_1;
                v1_1_mut = v1_1;
                v2_1_mut = v6;
                continue method31;
            }
        }
        break;
    }
}

export function method32(v0_1_mut: string, v1_1_mut: int64): boolean {
    method32:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: int64 = v1_1_mut;
        if (compare_1(v1_1, 2n) >= 0) {
            return false;
        }
        else {
            let v11: US9_$union;
            if (equals(v1_1, 0n)) {
                v11 = US9_US9_0("\"");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1_1, 1n));
                if (equals(v5, 0n)) {
                    v11 = US9_US9_0("\'");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    v11 = US9_US9_1();
                }
            }
            if (v0_1 === (((v11.tag as int32) === /* US9_0 */ 0) ? (v11.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_1_mut = v0_1;
                v1_1_mut = toInt64(op_Addition(v1_1, 1n));
                continue method32;
            }
        }
        break;
    }
}

export function method33(v0_1_mut: string, v1_1_mut: string, v2_1_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method33:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: string = v1_1_mut, v2_1: any = v2_1_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v145: US7_$union;
        if ("" === v1_1) {
            v145 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'"], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v25: string = v1_1[0];
            if (method32(v25, 0n) === false) {
                const v39 = 1;
                const v60: int32 = (v1_1.length - 1) | 0;
                const v62: string = v1_1.slice(v39, v60 + 1);
                const v68: string = v25;
                const v71: int32 = v68.length | 0;
                const v72: string[] = fill(new Array(v71), 0, v71, "");
                const v73: Mut5 = new Mut5(0);
                while (method27(v71, v73)) {
                    const v75: int32 = v73.l0 | 0;
                    const v76: string = v68[v75];
                    setItem(v72, v75, v76);
                    const v77: int32 = (v75 + 1) | 0;
                    v73.l0 = (v77 | 0);
                }
                const v79: FSharpList<string> = ofArray<string>(v72);
                const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v79, UH0_UH0_0()), v2_1, v3, v4);
                v145 = US7_US7_0(v25, v62, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v145 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v25, ["\"", "\'"], [v2_1, v3, v4] as [any, int32, int32]])));
            }
        }
        let v157: US7_$union;
        if ((v145.tag as int32) === /* US7_0 */ 0) {
            const v146 = v145.fields[0] as any;
            v157 = US7_US7_0(("\\" === v146) ? "/" : v146, v145.fields[1] as any, v145.fields[2] as any, v145.fields[3] as any, v145.fields[4] as any);
        }
        else {
            v157 = US7_US7_1(v145.fields[0] as any);
        }
        if ((v157.tag as int32) === /* US7_0 */ 0) {
            v0_1_mut = (v0_1 + (v157.fields[0] as any));
            v1_1_mut = (v157.fields[1] as any);
            v2_1_mut = (v157.fields[2] as any);
            v3_mut = (v157.fields[3] as any);
            v4_mut = (v157.fields[4] as any);
            continue method33;
        }
        else {
            const v174 = v157.fields[0] as any;
            return [v0_1, v1_1, v2_1, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method34(v0_1_mut: string, v1_1_mut: any, v2_1_mut: int32, v3_mut: int32, v4_mut: UH1_$union): US7_$union {
    method34:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: any = v1_1_mut, v2_1: int32 = v2_1_mut, v3: int32 = v3_mut, v4: UH1_$union = v4_mut;
        if ((v4.tag as int32) === /* UH1_0 */ 0) {
            return US7_US7_1("parsing.choice / no parsers succeeded");
        }
        else {
            const v8 = v4.fields[1] as any;
            const v9: US7_$union = (v4.fields[0] as any)([v0_1, v1_1, v2_1, v3] as [string, any, int32, int32]);
            if ((v9.tag as int32) === /* US7_0 */ 0) {
                const v14: int32 = (v9.fields[4] as any) | 0;
                const v13: int32 = (v9.fields[3] as any) | 0;
                const v12 = v9.fields[2] as any;
                const v11 = v9.fields[1] as any;
                const v10 = v9.fields[0] as any;
                return v9;
            }
            else {
                const v15 = v9.fields[0] as any;
                v0_1_mut = v0_1;
                v1_1_mut = v1_1;
                v2_1_mut = v2_1;
                v3_mut = v3;
                v4_mut = v8;
                continue method34;
            }
        }
        break;
    }
}

export function method35(v0_1_mut: string, v1_1_mut: int64): boolean {
    method35:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: int64 = v1_1_mut;
        if (compare_1(v1_1, 3n) >= 0) {
            return false;
        }
        else {
            let v15: US9_$union;
            if (equals(v1_1, 0n)) {
                v15 = US9_US9_0("\"");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1_1, 1n));
                if (equals(v5, 0n)) {
                    v15 = US9_US9_0("\'");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    if (equals(v8, 0n)) {
                        v15 = US9_US9_0(" ");
                    }
                    else {
                        const v11: int64 = toInt64(op_Subtraction(v8, 1n));
                        v15 = US9_US9_1();
                    }
                }
            }
            if (v0_1 === (((v15.tag as int32) === /* US9_0 */ 0) ? (v15.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_1_mut = v0_1;
                v1_1_mut = toInt64(op_Addition(v1_1, 1n));
                continue method35;
            }
        }
        break;
    }
}

export function method36(v0_1_mut: string, v1_1_mut: string, v2_1_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method36:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: string = v1_1_mut, v2_1: any = v2_1_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v153: US7_$union;
        if ("" === v1_1) {
            v153 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'", " "], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v29: string = v1_1[0];
            if (method35(v29, 0n) === false) {
                const v43 = 1;
                const v64: int32 = (v1_1.length - 1) | 0;
                const v66: string = v1_1.slice(v43, v64 + 1);
                const v72: string = v29;
                const v75: int32 = v72.length | 0;
                const v76: string[] = fill(new Array(v75), 0, v75, "");
                const v77: Mut5 = new Mut5(0);
                while (method27(v75, v77)) {
                    const v79: int32 = v77.l0 | 0;
                    const v80: string = v72[v79];
                    setItem(v76, v79, v80);
                    const v81: int32 = (v79 + 1) | 0;
                    v77.l0 = (v81 | 0);
                }
                const v83: FSharpList<string> = ofArray<string>(v76);
                const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v83, UH0_UH0_0()), v2_1, v3, v4);
                v153 = US7_US7_0(v29, v66, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v153 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, ["\"", "\'", " "], [v2_1, v3, v4] as [any, int32, int32]])));
            }
        }
        let v165: US7_$union;
        if ((v153.tag as int32) === /* US7_0 */ 0) {
            const v154 = v153.fields[0] as any;
            v165 = US7_US7_0(("\\" === v154) ? "/" : v154, v153.fields[1] as any, v153.fields[2] as any, v153.fields[3] as any, v153.fields[4] as any);
        }
        else {
            v165 = US7_US7_1(v153.fields[0] as any);
        }
        if ((v165.tag as int32) === /* US7_0 */ 0) {
            v0_1_mut = (v0_1 + (v165.fields[0] as any));
            v1_1_mut = (v165.fields[1] as any);
            v2_1_mut = (v165.fields[2] as any);
            v3_mut = (v165.fields[3] as any);
            v4_mut = (v165.fields[4] as any);
            continue method36;
        }
        else {
            const v182 = v165.fields[0] as any;
            return [v0_1, v1_1, v2_1, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method37(v0_1_mut: string, v1_1_mut: int32): int32 {
    method37:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: int32 = v1_1_mut;
        if (v1_1 >= v0_1.length) {
            return v1_1 | 0;
        }
        else if (" " === v0_1[v1_1]) {
            v0_1_mut = v0_1;
            v1_1_mut = (v1_1 + 1);
            continue method37;
        }
        else {
            return v1_1 | 0;
        }
        break;
    }
}

export function method38(v0_1_mut: string, v1_1_mut: string, v2_1_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method38:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: string = v1_1_mut, v2_1: any = v2_1_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v108: US7_$union;
        if ("" === v1_1) {
            v108 = US7_US7_1(toText(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [[v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v11: string = v1_1[0];
            const v22 = 1;
            const v43: int32 = (v1_1.length - 1) | 0;
            const v45: string = v1_1.slice(v22, v43 + 1);
            const v51: string = v11;
            const v54: int32 = v51.length | 0;
            const v55: string[] = fill(new Array(v54), 0, v54, "");
            const v56: Mut5 = new Mut5(0);
            while (method27(v54, v56)) {
                const v58: int32 = v56.l0 | 0;
                const v59: string = v51[v58];
                setItem(v55, v58, v59);
                const v60: int32 = (v58 + 1) | 0;
                v56.l0 = (v60 | 0);
            }
            const v62: FSharpList<string> = ofArray<string>(v55);
            const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v62, UH0_UH0_0()), v2_1, v3, v4);
            v108 = US7_US7_0(v11, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        if ((v108.tag as int32) === /* US7_0 */ 0) {
            v0_1_mut = (v0_1 + (v108.fields[0] as any));
            v1_1_mut = (v108.fields[1] as any);
            v2_1_mut = (v108.fields[2] as any);
            v3_mut = (v108.fields[3] as any);
            v4_mut = (v108.fields[4] as any);
            continue method38;
        }
        else {
            const v125 = v108.fields[0] as any;
            return [v0_1, v1_1, v2_1, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method25(v0_1: string): US6_$union {
    let _v0: Option<Option<string>> = undefined;
    _v0 = some(v0_1);
    const v10: string = defaultArg((_v0 == null) ? (() => {
        throw new Error("optionm\'.of_obj / _v0=None");
    })() : value_12(_v0), "");
    const v16: any = StringBuilder_$ctor_Z721C83C5(method26());
    const v19_1 = (arg10$0040: [string, any, int32, int32]): US7_$union => closure14(undefined, arg10$0040);
    const v20_1 = (arg10$0040_1: [string, any, int32, int32]): US7_$union => closure18(undefined, arg10$0040_1);
    const v24: US7_$union = method31(v10, v16, UH1_UH1_1(v19_1, UH1_UH1_1(v20_1, UH1_UH1_0())));
    let v244: US8_$union;
    if ((v24.tag as int32) === /* US7_0 */ 0) {
        const v29: int32 = (v24.fields[4] as any) | 0;
        const v28: int32 = (v24.fields[3] as any) | 0;
        const v27 = v24.fields[2] as any;
        const v26 = v24.fields[1] as any;
        const v25 = v24.fields[0] as any;
        let v170: US7_$union;
        if ("" === v26) {
            v170 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'"], [v27, v28, v29] as [any, int32, int32]])));
        }
        else {
            const v50: string = v26[0];
            if (method32(v50, 0n) === false) {
                const v64 = 1;
                const v85: int32 = (v26.length - 1) | 0;
                const v87: string = v26.slice(v64, v85 + 1);
                const v93: string = v50;
                const v96: int32 = v93.length | 0;
                const v97: string[] = fill(new Array(v96), 0, v96, "");
                const v98: Mut5 = new Mut5(0);
                while (method27(v96, v98)) {
                    const v100: int32 = v98.l0 | 0;
                    const v101: string = v93[v100];
                    setItem(v97, v100, v101);
                    const v102: int32 = (v100 + 1) | 0;
                    v98.l0 = (v102 | 0);
                }
                const v104: FSharpList<string> = ofArray<string>(v97);
                const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v104, UH0_UH0_0()), v27, v28, v29);
                v170 = US7_US7_0(v50, v87, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v170 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v50, ["\"", "\'"], [v27, v28, v29] as [any, int32, int32]])));
            }
        }
        let v182: US7_$union;
        if ((v170.tag as int32) === /* US7_0 */ 0) {
            const v171 = v170.fields[0] as any;
            v182 = US7_US7_0(("\\" === v171) ? "/" : v171, v170.fields[1] as any, v170.fields[2] as any, v170.fields[3] as any, v170.fields[4] as any);
        }
        else {
            v182 = US7_US7_1(v170.fields[0] as any);
        }
        let v202: US8_$union;
        if ((v182.tag as int32) === /* US7_0 */ 0) {
            const patternInput_1: [string, string, any, int32, int32] = method33(v182.fields[0] as any, v182.fields[1] as any, v182.fields[2] as any, v182.fields[3] as any, v182.fields[4] as any);
            v202 = US8_US8_0(patternInput_1[0], patternInput_1[1], patternInput_1[2], patternInput_1[3], patternInput_1[4]);
        }
        else {
            v202 = US8_US8_1(v182.fields[0] as any);
        }
        let v212: US8_$union;
        if ((v202.tag as int32) === /* US8_0 */ 0) {
            v212 = US8_US8_0(v202.fields[0] as any, v202.fields[1] as any, v202.fields[2] as any, v202.fields[3] as any, v202.fields[4] as any);
        }
        else {
            const v209 = v202.fields[0] as any;
            v212 = US8_US8_0("", v26, v27, v28, v29);
        }
        if ((v212.tag as int32) === /* US8_0 */ 0) {
            const v217: int32 = (v212.fields[4] as any) | 0;
            const v216: int32 = (v212.fields[3] as any) | 0;
            const v215 = v212.fields[2] as any;
            const v214 = v212.fields[1] as any;
            const v213 = v212.fields[0] as any;
            const v221: US7_$union = method34(v214, v215, v216, v217, UH1_UH1_1(v19_1, UH1_UH1_1(v20_1, UH1_UH1_0())));
            if ((v221.tag as int32) === /* US7_0 */ 0) {
                const v222 = v221.fields[0] as any;
                v244 = US8_US8_0(v213, v221.fields[1] as any, v221.fields[2] as any, v221.fields[3] as any, v221.fields[4] as any);
            }
            else {
                v244 = US8_US8_1(toText(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v221.fields[0] as any, [v10, v16, 1, 1] as [string, any, int32, int32], [v26, v27, v28, v29] as [string, any, int32, int32], [v214, v215, v216, v217] as [string, any, int32, int32]])));
            }
        }
        else {
            const v236 = v212.fields[0] as any;
            v244 = US8_US8_1("parsing.between / expected content");
        }
    }
    else {
        v244 = US8_US8_1(v24.fields[0] as any);
    }
    let v510: US8_$union;
    if ((v244.tag as int32) === /* US8_0 */ 0) {
        const v249: int32 = (v244.fields[4] as any) | 0;
        const v248: int32 = (v244.fields[3] as any) | 0;
        const v247 = v244.fields[2] as any;
        const v246 = v244.fields[1] as any;
        const v245 = v244.fields[0] as any;
        v510 = v244;
    }
    else {
        const v250 = v244.fields[0] as any;
        let v401: US7_$union;
        if ("" === v10) {
            v401 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'", " "], [v16, 1, 1] as [any, int32, int32]])));
        }
        else {
            const v275: string = v10[0];
            if (method35(v275, 0n) === false) {
                const v289 = 1;
                const v310: int32 = (v10.length - 1) | 0;
                const v312: string = v10.slice(v289, v310 + 1);
                const v318: string = v275;
                const v321: int32 = v318.length | 0;
                const v322: string[] = fill(new Array(v321), 0, v321, "");
                const v323: Mut5 = new Mut5(0);
                while (method27(v321, v323)) {
                    const v325: int32 = v323.l0 | 0;
                    const v326: string = v318[v325];
                    setItem(v322, v325, v326);
                    const v327: int32 = (v325 + 1) | 0;
                    v323.l0 = (v327 | 0);
                }
                const v329: FSharpList<string> = ofArray<string>(v322);
                const patternInput_2: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v329, UH0_UH0_0()), v16, 1, 1);
                v401 = US7_US7_0(v275, v312, patternInput_2[0], patternInput_2[1], patternInput_2[2]);
            }
            else {
                v401 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v275, ["\"", "\'", " "], [v16, 1, 1] as [any, int32, int32]])));
            }
        }
        let v413: US7_$union;
        if ((v401.tag as int32) === /* US7_0 */ 0) {
            const v402 = v401.fields[0] as any;
            v413 = US7_US7_0(("\\" === v402) ? "/" : v402, v401.fields[1] as any, v401.fields[2] as any, v401.fields[3] as any, v401.fields[4] as any);
        }
        else {
            v413 = US7_US7_1(v401.fields[0] as any);
        }
        let v433: US8_$union;
        if ((v413.tag as int32) === /* US7_0 */ 0) {
            const patternInput_3: [string, string, any, int32, int32] = method36(v413.fields[0] as any, v413.fields[1] as any, v413.fields[2] as any, v413.fields[3] as any, v413.fields[4] as any);
            v433 = US8_US8_0(patternInput_3[0], patternInput_3[1], patternInput_3[2], patternInput_3[3], patternInput_3[4]);
        }
        else {
            v433 = US8_US8_1(v413.fields[0] as any);
        }
        if ((v433.tag as int32) === /* US8_0 */ 0) {
            const v438: int32 = (v433.fields[4] as any) | 0;
            const v437: int32 = (v433.fields[3] as any) | 0;
            const v436 = v433.fields[2] as any;
            const v435 = v433.fields[1] as any;
            const v434 = v433.fields[0] as any;
            v510 = v433;
        }
        else {
            const v439 = v433.fields[0] as any;
            const v448: US10_$union = (v10.length === 0) ? US10_US10_0(v10, v16, 1, 1) : US10_US10_1(toText(interpolate("parsing.eof / expected end of input / input: %A%P()", [v10])));
            const v457: US8_$union = ((v448.tag as int32) === /* US10_0 */ 0) ? US8_US8_0("", v448.fields[0] as any, v448.fields[1] as any, v448.fields[2] as any, v448.fields[3] as any) : US8_US8_1(v448.fields[0] as any);
            if ((v457.tag as int32) === /* US8_0 */ 0) {
                const v462: int32 = (v457.fields[4] as any) | 0;
                const v461: int32 = (v457.fields[3] as any) | 0;
                const v460 = v457.fields[2] as any;
                const v459 = v457.fields[1] as any;
                const v458 = v457.fields[0] as any;
                const v475: int32 = method37(v459, 0) | 0;
                const v496: int32 = (v459.length - 1) | 0;
                v510 = US8_US8_0(v458, v459.slice(v475, v496 + 1), v460, v461, v462);
            }
            else {
                v510 = US8_US8_1(v457.fields[0] as any);
            }
        }
    }
    let v854: US11_$union;
    if ((v510.tag as int32) === /* US8_0 */ 0) {
        const v515: int32 = (v510.fields[4] as any) | 0;
        const v514: int32 = (v510.fields[3] as any) | 0;
        const v513 = v510.fields[2] as any;
        const v512 = v510.fields[1] as any;
        const v511 = v510.fields[0] as any;
        let v683: US7_$union;
        if ("" === v512) {
            v683 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", [" ", [v513, v514, v515] as [any, int32, int32]])));
        }
        else {
            const v522: string = v512[0];
            if (v522 === " ") {
                const v534 = 1;
                const v555: int32 = (v512.length - 1) | 0;
                const v557: string = v512.slice(v534, v555 + 1);
                const v563: string = v522;
                const v566: int32 = v563.length | 0;
                const v567: string[] = fill(new Array(v566), 0, v566, "");
                const v568: Mut5 = new Mut5(0);
                while (method27(v566, v568)) {
                    const v570: int32 = v568.l0 | 0;
                    const v571: string = v563[v570];
                    setItem(v567, v570, v571);
                    const v572: int32 = (v570 + 1) | 0;
                    v568.l0 = (v572 | 0);
                }
                const v574: FSharpList<string> = ofArray<string>(v567);
                const patternInput_4: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v574, UH0_UH0_0()), v513, v514, v515);
                v683 = US7_US7_0(v522, v557, patternInput_4[0], patternInput_4[1], patternInput_4[2]);
            }
            else {
                const v625: int32 = (v512.indexOf("\n") - 1) | 0;
                const v640 = 0;
                const v661: int32 = (((-2 === v625) ? (v512.length + 1) : (v625 + 1)) - 1) | 0;
                v683 = US7_US7_1(concat(`parsing.p_char / expected: '${" "}' / line: ${v514} / col: ${v515}
${v513}${v512.slice(v640, v661 + 1)}`, "\n", method30(v515 - 1, 0)("") + "^", ..."\n"));
            }
        }
        let v695: US12_$union;
        if ((v683.tag as int32) === /* US7_0 */ 0) {
            v695 = US12_US12_0(US9_US9_0(v683.fields[0] as any), v683.fields[1] as any, v683.fields[2] as any, v683.fields[3] as any, v683.fields[4] as any);
        }
        else {
            const v691 = v683.fields[0] as any;
            v695 = US12_US12_0(US9_US9_1(), v512, v513, v514, v515);
        }
        let v828: US8_$union;
        if ((v695.tag as int32) === /* US12_0 */ 0) {
            const v700: int32 = (v695.fields[4] as any) | 0;
            const v699: int32 = (v695.fields[3] as any) | 0;
            const v698 = v695.fields[2] as any;
            const v697 = v695.fields[1] as any;
            const v696 = v695.fields[0] as any;
            let v804: US7_$union;
            if ("" === v697) {
                v804 = US7_US7_1(toText(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [[v698, v699, v700] as [any, int32, int32]])));
            }
            else {
                const v707: string = v697[0];
                const v718 = 1;
                const v739: int32 = (v697.length - 1) | 0;
                const v741: string = v697.slice(v718, v739 + 1);
                const v747: string = v707;
                const v750: int32 = v747.length | 0;
                const v751: string[] = fill(new Array(v750), 0, v750, "");
                const v752: Mut5 = new Mut5(0);
                while (method27(v750, v752)) {
                    const v754: int32 = v752.l0 | 0;
                    const v755: string = v747[v754];
                    setItem(v751, v754, v755);
                    const v756: int32 = (v754 + 1) | 0;
                    v752.l0 = (v756 | 0);
                }
                const v758: FSharpList<string> = ofArray<string>(v751);
                const patternInput_5: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v758, UH0_UH0_0()), v698, v699, v700);
                v804 = US7_US7_0(v707, v741, patternInput_5[0], patternInput_5[1], patternInput_5[2]);
            }
            if ((v804.tag as int32) === /* US7_0 */ 0) {
                const patternInput_6: [string, string, any, int32, int32] = method38(v804.fields[0] as any, v804.fields[1] as any, v804.fields[2] as any, v804.fields[3] as any, v804.fields[4] as any);
                v828 = US8_US8_0(patternInput_6[0], patternInput_6[1], patternInput_6[2], patternInput_6[3], patternInput_6[4]);
            }
            else {
                v828 = US8_US8_1(v804.fields[0] as any);
            }
        }
        else {
            v828 = US8_US8_1(v695.fields[0] as any);
        }
        let v840: US13_$union;
        if ((v828.tag as int32) === /* US8_0 */ 0) {
            v840 = US13_US13_0(US5_US5_0(v828.fields[0] as any), v828.fields[1] as any, v828.fields[2] as any, v828.fields[3] as any, v828.fields[4] as any);
        }
        else {
            const v836 = v828.fields[0] as any;
            v840 = US13_US13_0(US5_US5_1(), v512, v513, v514, v515);
        }
        v854 = (((v840.tag as int32) === /* US13_0 */ 0) ? US11_US11_0(v511, v840.fields[0] as any, v840.fields[1] as any, v840.fields[2] as any, v840.fields[3] as any, v840.fields[4] as any) : US11_US11_1(v840.fields[0] as any));
    }
    else {
        v854 = US11_US11_1(v510.fields[0] as any);
    }
    if ((v854.tag as int32) === /* US11_0 */ 0) {
        const v860: int32 = (v854.fields[5] as any) | 0;
        const v859: int32 = (v854.fields[4] as any) | 0;
        const v858 = v854.fields[3] as any;
        const v857 = v854.fields[2] as any;
        return US6_US6_0(v854.fields[0] as any, v854.fields[1] as any);
    }
    else {
        return US6_US6_1(v854.fields[0] as any);
    }
}

export function method39(): string {
    const v3: string = "Debug".toLocaleLowerCase();
    return ("\u001b[94m" + method13(v3[0])) + method15();
}

export function method41(v0_1: string, v1_1: US5_$union, v2_1: string, v3: Option<any>, v4: [string, string][], v5: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v6: Option<((arg0: any) => void)>, v7: boolean, v8: Option<string>): string {
    const v10: Mut3 = new Mut3(method14());
    let v18_1: any;
    closure7(v10, "{ ", undefined);
    v18_1 = undefined;
    let v28: any;
    closure7(v10, "file_name", undefined);
    v28 = undefined;
    let v38: any;
    closure7(v10, " = ", undefined);
    v38 = undefined;
    let v47: any;
    closure7(v10, v0_1, undefined);
    v47 = undefined;
    let v57: any;
    closure7(v10, "; ", undefined);
    v57 = undefined;
    let v67: any;
    closure7(v10, "arguments", undefined);
    v67 = undefined;
    let v76: any;
    closure7(v10, " = ", undefined);
    v76 = undefined;
    let v89: any;
    closure7(v10, toText(interpolate("%A%P()", [v1_1])), undefined);
    v89 = undefined;
    let v98: any;
    closure7(v10, "; ", undefined);
    v98 = undefined;
    let v108: any;
    closure7(v10, "options", undefined);
    v108 = undefined;
    let v117: any;
    closure7(v10, " = ", undefined);
    v117 = undefined;
    let v126: any;
    closure7(v10, "{ ", undefined);
    v126 = undefined;
    let v136: any;
    closure7(v10, "command", undefined);
    v136 = undefined;
    let v145: any;
    closure7(v10, " = ", undefined);
    v145 = undefined;
    let v154: any;
    closure7(v10, v2_1, undefined);
    v154 = undefined;
    let v163: any;
    closure7(v10, "; ", undefined);
    v163 = undefined;
    let v173: any;
    closure7(v10, "cancellation_token", undefined);
    v173 = undefined;
    let v182: any;
    closure7(v10, " = ", undefined);
    v182 = undefined;
    let v230: any;
    closure7(v10, toText(interpolate("%A%P()", [v3])), undefined);
    v230 = undefined;
    let v239: any;
    closure7(v10, "; ", undefined);
    v239 = undefined;
    let v249: any;
    closure7(v10, "environment_variables", undefined);
    v249 = undefined;
    let v258: any;
    closure7(v10, " = ", undefined);
    v258 = undefined;
    let v271: any;
    closure7(v10, toText(interpolate("%A%P()", [v4])), undefined);
    v271 = undefined;
    let v280: any;
    closure7(v10, "; ", undefined);
    v280 = undefined;
    let v290: any;
    closure7(v10, "on_line", undefined);
    v290 = undefined;
    let v299: any;
    closure7(v10, " = ", undefined);
    v299 = undefined;
    let v347: any;
    closure7(v10, toText(interpolate("%A%P()", [v5])), undefined);
    v347 = undefined;
    let v356: any;
    closure7(v10, "; ", undefined);
    v356 = undefined;
    let v366: any;
    closure7(v10, "stdin", undefined);
    v366 = undefined;
    let v375: any;
    closure7(v10, " = ", undefined);
    v375 = undefined;
    let v423: any;
    closure7(v10, toText(interpolate("%A%P()", [v6])), undefined);
    v423 = undefined;
    let v432: any;
    closure7(v10, "; ", undefined);
    v432 = undefined;
    let v442: any;
    closure7(v10, "trace", undefined);
    v442 = undefined;
    let v451: any;
    closure7(v10, " = ", undefined);
    v451 = undefined;
    let v463: any;
    closure7(v10, v7 ? "true" : "false", undefined);
    v463 = undefined;
    let v472: any;
    closure7(v10, "; ", undefined);
    v472 = undefined;
    let v482: any;
    closure7(v10, "working_directory", undefined);
    v482 = undefined;
    let v491: any;
    closure7(v10, " = ", undefined);
    v491 = undefined;
    let v539: any;
    closure7(v10, toText(interpolate("%A%P()", [v8])), undefined);
    v539 = undefined;
    let v549: any;
    closure7(v10, " }", undefined);
    v549 = undefined;
    let v558: any;
    closure7(v10, " }", undefined);
    v558 = undefined;
    return v10.l0;
}

export function method40(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: US5_$union, v10: string, v11: Option<any>, v12: [string, string][], v13: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v14: Option<((arg0: any) => void)>, v15: boolean, v16: Option<string>): string {
    const v17_1: string = method41(v8, v9, v10, v11, v12, v13, v14, v15, v16);
    return method18(`${v6} ${v7} #${v0_1.l0} ${"runtime.execute_with_options_async"} / ${v17_1}`);
}

export function closure19(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: US5_$union, v8: string, unitVar: void): void {
    if (method7(US0_US0_1())) {
        let v13: any;
        closure0(undefined, undefined);
        v13 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v39: Option<int64> = patternInput[5];
        const v38: Mut4 = patternInput[4];
        const v37: Mut3 = patternInput[3];
        const v36: Mut2 = patternInput[2];
        const v35: Mut1 = patternInput[1];
        const v34: Mut0 = patternInput[0];
        method19(method40(v34, v35, v36, v37, v38, v39, method8(v34, v35, v36, v37, v38, v39), method39(), v8, v7, v0_1, v1_1, v2_1, v3, v4, v5, v6));
    }
}

export function method42(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>): [string, string][] {
    return v2_1;
}

export function method45(v0_1: boolean): string {
    return defaultOf();
}

export function closure21(unitVar: void, v0_1: ((arg0: [int32, string, boolean]) => Async<void>)): US14_$union {
    return US14_US14_0(v0_1);
}

export function method46(): ((arg0: ((arg0: [int32, string, boolean]) => Async<void>)) => US14_$union) {
    return (v: ((arg0: [int32, string, boolean]) => Async<void>)): US14_$union => closure21(undefined, v);
}

export function method47(v0_1: boolean): int32 {
    return defaultOf();
}

export function method48(): string {
    const v3: string = "Verbose".toLocaleLowerCase();
    return ("\u001b[90m" + method13(v3[0])) + method15();
}

export function method49(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string): string {
    const v9: string = method17();
    return method18(`${v6} ${v7} #${v0_1.l0} ${v8} / ${v9}`);
}

export function closure22(v0_1: string, unitVar: void): void {
    if (method7(US0_US0_0())) {
        let v5: any;
        closure0(undefined, undefined);
        v5 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v31: Option<int64> = patternInput[5];
        const v30: Mut4 = patternInput[4];
        const v29: Mut3 = patternInput[3];
        const v28: Mut2 = patternInput[2];
        const v27: Mut1 = patternInput[1];
        const v26: Mut0 = patternInput[0];
        method19((v0_1 === "") ? "" : method49(v26, v27, v28, v29, v30, v31, method8(v26, v27, v28, v29, v30, v31), method48(), v0_1));
    }
}

export function method44(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: any, v9: boolean, v10: boolean): Async<void> {
    return singleton.Delay<void>((): Async<void> => {
        let v57: US14_$union, v63: Async<void>;
        const v32: string = method45(v10);
        const v38: boolean = (v32 === defaultOf()) !== true;
        return singleton.Combine<void>(v38 ? ((v57 = defaultArg(map<((arg0: [int32, string, boolean]) => Async<void>), US14_$union>(method46(), v3), US14_US14_1()), singleton.Combine<void>(((v57.tag as int32) === /* US14_0 */ 0) ? ((v63 = (v57.fields[0] as any)([method47(v7), v32, v9] as [int32, string, boolean]), singleton.Bind<void, void>(v63, (): Async<void> => {
            return singleton.Zero();
        }))) : (singleton.Zero()), singleton.Delay<void>((): Async<void> => {
            let v69: any, v121: any;
            const v66: string = v9 ? concat("! ", ...v32) : concat("> ", ...v32);
            return singleton.Combine<void>(v5 ? ((v69 = ((closure22(v66, undefined), undefined)), singleton.Zero())) : ((v121 = ((closure10(v66, undefined), undefined)), singleton.Zero())), singleton.Delay<void>((): Async<void> => {
                const v129: string = concat(v9 ? "\u001b[7;4m" : "", v32, ...(v9 ? "\u001b[0m" : ""));
                return singleton.Zero();
            }));
        })))) : singleton.Zero(), singleton.Delay<void>((): Async<void> => {
            return singleton.Zero();
        }));
    });
}

export function method43(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: any, v9: boolean, v10: boolean): Async<void> {
    return method44(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10);
}

export function closure20(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: any, v9: boolean, v10: boolean): void {
    startImmediate(method43(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10));
}

export function closure23(unitVar: void, v0_1: any): US15_$union {
    return US15_US15_0(v0_1);
}

export function method50(): ((arg0: any) => US15_$union) {
    return (v: any): US15_$union => closure23(undefined, v);
}

export function method51(v0_1: any): Async<any> {
    return singleton.Delay<any>((): Async<any> => {
        const v40: any = defaultOf();
        return singleton.Return<any>(v40);
    });
}

export function method52(v0_1: boolean): boolean {
    return defaultOf();
}

export function method53(v0_1: boolean): void {
}

export function closure24(v0_1: boolean, unitVar: void): void {
    if (method52(v0_1) === false) {
        method53(v0_1);
    }
}

export function method56(v0_1: any): string {
    const v2_1: Mut3 = new Mut3(method14());
    let v10: any;
    closure7(v2_1, "{ ", undefined);
    v10 = undefined;
    let v20_1: any;
    closure7(v2_1, "ex", undefined);
    v20_1 = undefined;
    let v30: any;
    closure7(v2_1, " = ", undefined);
    v30 = undefined;
    let v78: any;
    closure7(v2_1, toText(interpolate("%A%P()", [v0_1])), undefined);
    v78 = undefined;
    let v88: any;
    closure7(v2_1, " }", undefined);
    v88 = undefined;
    return v2_1.l0;
}

export function method55(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: any): string {
    const v9: string = method56(v8);
    return method18(`${v6} ${v7} #${v0_1.l0} ${"runtime.execute_with_options_async / WaitForExitAsync"} / ${v9}`);
}

export function closure25(v0_1: any, unitVar: void): void {
    if (method7(US0_US0_3())) {
        let v5: any;
        closure0(undefined, undefined);
        v5 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v31: Option<int64> = patternInput[5];
        const v30: Mut4 = patternInput[4];
        const v29: Mut3 = patternInput[3];
        const v28: Mut2 = patternInput[2];
        const v27: Mut1 = patternInput[1];
        const v26: Mut0 = patternInput[0];
        method19(method55(v26, v27, v28, v29, v30, v31, method8(v26, v27, v28, v29, v30, v31), method12(), v0_1));
    }
}

export function method54(v0_1: boolean, v1_1: any, v2_1: any): Async<int32> {
    return singleton.Delay<int32>((): Async<int32> => singleton.TryWith<int32>(singleton.Delay<int32>((): Async<int32> => {
        const v78: Async<void> = awaitTask(defaultOf());
        return singleton.Bind<void, int32>(v78, (): Async<int32> => {
            const v109: int32 = 0;
            return singleton.Return<int32>(v109);
        });
    }), (_arg_1: Error): Async<int32> => {
        const v230: Error = _arg_1;
        const v249: string = toText(interpolate("%A%P()", [v230]));
        let v275: any;
        closure25(v230, undefined);
        v275 = undefined;
        return singleton.Return<int32>(-2147483648);
    }));
}

export function method57(): string {
    return "\n";
}

export function method59(v0_1: int32, v1_1: int32, v2_1: string, v3: Option<any>, v4: [string, string][], v5: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v6: Option<((arg0: any) => void)>, v7: boolean, v8: Option<string>): string {
    const v10: Mut3 = new Mut3(method14());
    let v18_1: any;
    closure7(v10, "{ ", undefined);
    v18_1 = undefined;
    let v28: any;
    closure7(v10, "exit_code", undefined);
    v28 = undefined;
    let v38: any;
    closure7(v10, " = ", undefined);
    v38 = undefined;
    let v47: any;
    closure7(v10, `${v0_1}`, undefined);
    v47 = undefined;
    let v57: any;
    closure7(v10, "; ", undefined);
    v57 = undefined;
    let v67: any;
    closure7(v10, "output_length", undefined);
    v67 = undefined;
    let v76: any;
    closure7(v10, " = ", undefined);
    v76 = undefined;
    let v85: any;
    closure7(v10, `${v1_1}`, undefined);
    v85 = undefined;
    let v94: any;
    closure7(v10, "; ", undefined);
    v94 = undefined;
    let v104: any;
    closure7(v10, "options", undefined);
    v104 = undefined;
    let v113: any;
    closure7(v10, " = ", undefined);
    v113 = undefined;
    let v122: any;
    closure7(v10, "{ ", undefined);
    v122 = undefined;
    let v132: any;
    closure7(v10, "command", undefined);
    v132 = undefined;
    let v141: any;
    closure7(v10, " = ", undefined);
    v141 = undefined;
    let v150: any;
    closure7(v10, v2_1, undefined);
    v150 = undefined;
    let v159: any;
    closure7(v10, "; ", undefined);
    v159 = undefined;
    let v169: any;
    closure7(v10, "cancellation_token", undefined);
    v169 = undefined;
    let v178: any;
    closure7(v10, " = ", undefined);
    v178 = undefined;
    let v226: any;
    closure7(v10, toText(interpolate("%A%P()", [v3])), undefined);
    v226 = undefined;
    let v235: any;
    closure7(v10, "; ", undefined);
    v235 = undefined;
    let v245: any;
    closure7(v10, "environment_variables", undefined);
    v245 = undefined;
    let v254: any;
    closure7(v10, " = ", undefined);
    v254 = undefined;
    let v267: any;
    closure7(v10, toText(interpolate("%A%P()", [v4])), undefined);
    v267 = undefined;
    let v276: any;
    closure7(v10, "; ", undefined);
    v276 = undefined;
    let v286: any;
    closure7(v10, "on_line", undefined);
    v286 = undefined;
    let v295: any;
    closure7(v10, " = ", undefined);
    v295 = undefined;
    let v343: any;
    closure7(v10, toText(interpolate("%A%P()", [v5])), undefined);
    v343 = undefined;
    let v352: any;
    closure7(v10, "; ", undefined);
    v352 = undefined;
    let v362: any;
    closure7(v10, "stdin", undefined);
    v362 = undefined;
    let v371: any;
    closure7(v10, " = ", undefined);
    v371 = undefined;
    let v419: any;
    closure7(v10, toText(interpolate("%A%P()", [v6])), undefined);
    v419 = undefined;
    let v428: any;
    closure7(v10, "; ", undefined);
    v428 = undefined;
    let v438: any;
    closure7(v10, "trace", undefined);
    v438 = undefined;
    let v447: any;
    closure7(v10, " = ", undefined);
    v447 = undefined;
    let v459: any;
    closure7(v10, v7 ? "true" : "false", undefined);
    v459 = undefined;
    let v468: any;
    closure7(v10, "; ", undefined);
    v468 = undefined;
    let v478: any;
    closure7(v10, "working_directory", undefined);
    v478 = undefined;
    let v487: any;
    closure7(v10, " = ", undefined);
    v487 = undefined;
    let v535: any;
    closure7(v10, toText(interpolate("%A%P()", [v8])), undefined);
    v535 = undefined;
    let v545: any;
    closure7(v10, " }", undefined);
    v545 = undefined;
    let v554: any;
    closure7(v10, " }", undefined);
    v554 = undefined;
    return v10.l0;
}

export function method58(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: int32, v10: string, v11: Option<any>, v12: [string, string][], v13: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v14: Option<((arg0: any) => void)>, v15: boolean, v16: Option<string>): string {
    const v17_1: string = method59(v8, v9, v10, v11, v12, v13, v14, v15, v16);
    return method18(`${v6} ${v7} #${v0_1.l0} ${"runtime.execute_with_options_async"} / ${v17_1}`);
}

export function closure26(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: int32, v8: string, unitVar: void): void {
    if (method7(US0_US0_1())) {
        let v13: any;
        closure0(undefined, undefined);
        v13 = undefined;
        const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v39: Option<int64> = patternInput[5];
        const v38: Mut4 = patternInput[4];
        const v37: Mut3 = patternInput[3];
        const v36: Mut2 = patternInput[2];
        const v35: Mut1 = patternInput[1];
        const v34: Mut0 = patternInput[0];
        method19(method58(v34, v35, v36, v37, v38, v39, method8(v34, v35, v36, v37, v38, v39), method39(), v7, v8.length, v0_1, v1_1, v2_1, v3, v4, v5, v6));
    }
}

export function method24(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>): Async<[int32, string]> {
    return singleton.Delay<[int32, string]>((): Async<[int32, string]> => {
        const patternInput: [int32, string] = defaultOf();
        return singleton.Return<[int32, string]>([patternInput[0], patternInput[1]] as [int32, string]);
    });
}

export function method23(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>): Async<[int32, string]> {
    return method24(v0_1, v1_1, v2_1, v3, v4, v5, v6);
}

export function method22(v0_1: string): Async<[int32, string]> {
    return method23(v0_1, undefined, [], undefined, undefined, true, undefined);
}

export function closure13(unitVar: void, v0_1: string): Async<[int32, string]> {
    return method22(v0_1);
}

export function closure27(unitVar: void, _arg: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>]): Async<[int32, string]> {
    return method23(_arg[0], _arg[1], _arg[2], _arg[3], _arg[4], _arg[5], _arg[6]);
}

export function closure28(unitVar: void, v0_1: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>] {
    const v8: Heap0 = v0_1(new Heap0("", undefined, [], undefined, undefined, true, undefined));
    return [v8.l0, v8.l1, v8.l2, v8.l3, v8.l4, v8.l5, v8.l6] as [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>];
}

export function method62(v0_1_mut: string, v1_1_mut: int64): boolean {
    method62:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: int64 = v1_1_mut;
        if (compare_1(v1_1, 4n) >= 0) {
            return false;
        }
        else {
            let v19_1: US9_$union;
            if (equals(v1_1, 0n)) {
                v19_1 = US9_US9_0("\\");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1_1, 1n));
                if (equals(v5, 0n)) {
                    v19_1 = US9_US9_0("`");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    if (equals(v8, 0n)) {
                        v19_1 = US9_US9_0("\"");
                    }
                    else {
                        const v11: int64 = toInt64(op_Subtraction(v8, 1n));
                        if (equals(v11, 0n)) {
                            v19_1 = US9_US9_0(" ");
                        }
                        else {
                            const v14: int64 = toInt64(op_Subtraction(v11, 1n));
                            v19_1 = US9_US9_1();
                        }
                    }
                }
            }
            if (v0_1 === (((v19_1.tag as int32) === /* US9_0 */ 0) ? (v19_1.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_1_mut = v0_1;
                v1_1_mut = toInt64(op_Addition(v1_1, 1n));
                continue method62;
            }
        }
        break;
    }
}

export function method63(v0_1_mut: string, v1_1_mut: string, v2_1_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method63:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: string = v1_1_mut, v2_1: any = v2_1_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v161: US7_$union;
        if ("" === v1_1) {
            v161 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\"", " "], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v33: string = v1_1[0];
            if (method62(v33, 0n) === false) {
                const v47 = 1;
                const v68: int32 = (v1_1.length - 1) | 0;
                const v70: string = v1_1.slice(v47, v68 + 1);
                const v76: string = v33;
                const v79: int32 = v76.length | 0;
                const v80: string[] = fill(new Array(v79), 0, v79, "");
                const v81: Mut5 = new Mut5(0);
                while (method27(v79, v81)) {
                    const v83: int32 = v81.l0 | 0;
                    const v84: string = v76[v83];
                    setItem(v80, v83, v84);
                    const v85: int32 = (v83 + 1) | 0;
                    v81.l0 = (v85 | 0);
                }
                const v87: FSharpList<string> = ofArray<string>(v80);
                const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v87, UH0_UH0_0()), v2_1, v3, v4);
                v161 = US7_US7_0(v33, v70, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v161 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33, ["\\", "`", "\"", " "], [v2_1, v3, v4] as [any, int32, int32]])));
            }
        }
        if ((v161.tag as int32) === /* US7_0 */ 0) {
            v0_1_mut = (v0_1 + (v161.fields[0] as any));
            v1_1_mut = (v161.fields[1] as any);
            v2_1_mut = (v161.fields[2] as any);
            v3_mut = (v161.fields[3] as any);
            v4_mut = (v161.fields[4] as any);
            continue method63;
        }
        else {
            const v178 = v161.fields[0] as any;
            return [v0_1, v1_1, v2_1, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method65(v0_1_mut: string, v1_1_mut: int64): boolean {
    method65:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: int64 = v1_1_mut;
        if (compare_1(v1_1, 3n) >= 0) {
            return false;
        }
        else {
            let v15: US9_$union;
            if (equals(v1_1, 0n)) {
                v15 = US9_US9_0("\\");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1_1, 1n));
                if (equals(v5, 0n)) {
                    v15 = US9_US9_0("`");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    if (equals(v8, 0n)) {
                        v15 = US9_US9_0("\"");
                    }
                    else {
                        const v11: int64 = toInt64(op_Subtraction(v8, 1n));
                        v15 = US9_US9_1();
                    }
                }
            }
            if (v0_1 === (((v15.tag as int32) === /* US9_0 */ 0) ? (v15.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_1_mut = v0_1;
                v1_1_mut = toInt64(op_Addition(v1_1, 1n));
                continue method65;
            }
        }
        break;
    }
}

export function closure30(unitVar: void, _arg: [string, any, int32, int32]): US8_$union {
    const v3: int32 = _arg[3] | 0;
    const v2_1: int32 = _arg[2] | 0;
    const v1_1: any = _arg[1];
    const v0_1: string = _arg[0];
    let v172: US7_$union;
    if ("" === v0_1) {
        v172 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\\", [v1_1, v2_1, v3] as [any, int32, int32]])));
    }
    else {
        const v10: string = v0_1[0];
        if (v10 === "\\") {
            const v22 = 1;
            const v43: int32 = (v0_1.length - 1) | 0;
            const v45: string = v0_1.slice(v22, v43 + 1);
            const v51: string = v10;
            const v54: int32 = v51.length | 0;
            const v55: string[] = fill(new Array(v54), 0, v54, "");
            const v56: Mut5 = new Mut5(0);
            while (method27(v54, v56)) {
                const v58: int32 = v56.l0 | 0;
                const v59: string = v51[v58];
                setItem(v55, v58, v59);
                const v60: int32 = (v58 + 1) | 0;
                v56.l0 = (v60 | 0);
            }
            const v62: FSharpList<string> = ofArray<string>(v55);
            const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v62, UH0_UH0_0()), v1_1, v2_1, v3);
            v172 = US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v113: int32 = (v0_1.indexOf("\n") - 1) | 0;
            const v128 = 0;
            const v149: int32 = (((-2 === v113) ? (v0_1.length + 1) : (v113 + 1)) - 1) | 0;
            v172 = US7_US7_1(concat(`parsing.p_char / expected: '${"\\"}' / line: ${v2_1} / col: ${v3}
${v1_1}${v0_1.slice(v128, v149 + 1)}`, "\n", method30(v3 - 1, 0)("") + "^", ..."\n"));
        }
    }
    let v285: US7_$union;
    if ((v172.tag as int32) === /* US7_0 */ 0) {
        const v177: int32 = (v172.fields[4] as any) | 0;
        const v176: int32 = (v172.fields[3] as any) | 0;
        const v175 = v172.fields[2] as any;
        const v174 = v172.fields[1] as any;
        const v173 = v172.fields[0] as any;
        if ("" === v174) {
            v285 = US7_US7_1(toText(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [[v175, v176, v177] as [any, int32, int32]])));
        }
        else {
            const v184: string = v174[0];
            const v195 = 1;
            const v216: int32 = (v174.length - 1) | 0;
            const v218: string = v174.slice(v195, v216 + 1);
            const v224: string = v184;
            const v227: int32 = v224.length | 0;
            const v228: string[] = fill(new Array(v227), 0, v227, "");
            const v229: Mut5 = new Mut5(0);
            while (method27(v227, v229)) {
                const v231: int32 = v229.l0 | 0;
                const v232: string = v224[v231];
                setItem(v228, v231, v232);
                const v233: int32 = (v231 + 1) | 0;
                v229.l0 = (v233 | 0);
            }
            const v235: FSharpList<string> = ofArray<string>(v228);
            const patternInput_1: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v235, UH0_UH0_0()), v175, v176, v177);
            v285 = US7_US7_0(v184, v218, patternInput_1[0], patternInput_1[1], patternInput_1[2]);
        }
    }
    else {
        v285 = US7_US7_1(v172.fields[0] as any);
    }
    if ((v285.tag as int32) === /* US7_0 */ 0) {
        return US8_US8_0("\\" + (v285.fields[0] as any), v285.fields[1] as any, v285.fields[2] as any, v285.fields[3] as any, v285.fields[4] as any);
    }
    else {
        return US8_US8_1(v285.fields[0] as any);
    }
}

export function closure31(unitVar: void, _arg: [string, any, int32, int32]): US8_$union {
    const v3: int32 = _arg[3] | 0;
    const v2_1: int32 = _arg[2] | 0;
    const v1_1: any = _arg[1];
    const v0_1: string = _arg[0];
    let v172: US7_$union;
    if ("" === v0_1) {
        v172 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["`", [v1_1, v2_1, v3] as [any, int32, int32]])));
    }
    else {
        const v10: string = v0_1[0];
        if (v10 === "`") {
            const v22 = 1;
            const v43: int32 = (v0_1.length - 1) | 0;
            const v45: string = v0_1.slice(v22, v43 + 1);
            const v51: string = v10;
            const v54: int32 = v51.length | 0;
            const v55: string[] = fill(new Array(v54), 0, v54, "");
            const v56: Mut5 = new Mut5(0);
            while (method27(v54, v56)) {
                const v58: int32 = v56.l0 | 0;
                const v59: string = v51[v58];
                setItem(v55, v58, v59);
                const v60: int32 = (v58 + 1) | 0;
                v56.l0 = (v60 | 0);
            }
            const v62: FSharpList<string> = ofArray<string>(v55);
            const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v62, UH0_UH0_0()), v1_1, v2_1, v3);
            v172 = US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v113: int32 = (v0_1.indexOf("\n") - 1) | 0;
            const v128 = 0;
            const v149: int32 = (((-2 === v113) ? (v0_1.length + 1) : (v113 + 1)) - 1) | 0;
            v172 = US7_US7_1(concat(`parsing.p_char / expected: '${"`"}' / line: ${v2_1} / col: ${v3}
${v1_1}${v0_1.slice(v128, v149 + 1)}`, "\n", method30(v3 - 1, 0)("") + "^", ..."\n"));
        }
    }
    let v285: US7_$union;
    if ((v172.tag as int32) === /* US7_0 */ 0) {
        const v177: int32 = (v172.fields[4] as any) | 0;
        const v176: int32 = (v172.fields[3] as any) | 0;
        const v175 = v172.fields[2] as any;
        const v174 = v172.fields[1] as any;
        const v173 = v172.fields[0] as any;
        if ("" === v174) {
            v285 = US7_US7_1(toText(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [[v175, v176, v177] as [any, int32, int32]])));
        }
        else {
            const v184: string = v174[0];
            const v195 = 1;
            const v216: int32 = (v174.length - 1) | 0;
            const v218: string = v174.slice(v195, v216 + 1);
            const v224: string = v184;
            const v227: int32 = v224.length | 0;
            const v228: string[] = fill(new Array(v227), 0, v227, "");
            const v229: Mut5 = new Mut5(0);
            while (method27(v227, v229)) {
                const v231: int32 = v229.l0 | 0;
                const v232: string = v224[v231];
                setItem(v228, v231, v232);
                const v233: int32 = (v231 + 1) | 0;
                v229.l0 = (v233 | 0);
            }
            const v235: FSharpList<string> = ofArray<string>(v228);
            const patternInput_1: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v235, UH0_UH0_0()), v175, v176, v177);
            v285 = US7_US7_0(v184, v218, patternInput_1[0], patternInput_1[1], patternInput_1[2]);
        }
    }
    else {
        v285 = US7_US7_1(v172.fields[0] as any);
    }
    if ((v285.tag as int32) === /* US7_0 */ 0) {
        return US8_US8_0("`" + (v285.fields[0] as any), v285.fields[1] as any, v285.fields[2] as any, v285.fields[3] as any, v285.fields[4] as any);
    }
    else {
        return US8_US8_1(v285.fields[0] as any);
    }
}

export function method66(v0_1_mut: string, v1_1_mut: any, v2_1_mut: int32, v3_mut: int32, v4_mut: UH3_$union): US8_$union {
    method66:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: any = v1_1_mut, v2_1: int32 = v2_1_mut, v3: int32 = v3_mut, v4: UH3_$union = v4_mut;
        if ((v4.tag as int32) === /* UH3_0 */ 0) {
            return US8_US8_1("parsing.choice / no parsers succeeded");
        }
        else {
            const v8 = v4.fields[1] as any;
            const v9: US8_$union = (v4.fields[0] as any)([v0_1, v1_1, v2_1, v3] as [string, any, int32, int32]);
            if ((v9.tag as int32) === /* US8_0 */ 0) {
                const v14: int32 = (v9.fields[4] as any) | 0;
                const v13: int32 = (v9.fields[3] as any) | 0;
                const v12 = v9.fields[2] as any;
                const v11 = v9.fields[1] as any;
                const v10 = v9.fields[0] as any;
                return v9;
            }
            else {
                const v15 = v9.fields[0] as any;
                v0_1_mut = v0_1;
                v1_1_mut = v1_1;
                v2_1_mut = v2_1;
                v3_mut = v3;
                v4_mut = v8;
                continue method66;
            }
        }
        break;
    }
}

export function method67(v0_1_mut: UH2_$union, v1_1_mut: UH2_$union): UH2_$union {
    method67:
    while (true) {
        const v0_1: UH2_$union = v0_1_mut, v1_1: UH2_$union = v1_1_mut;
        if ((v0_1.tag as int32) === /* UH2_0 */ 0) {
            return v1_1;
        }
        else {
            v0_1_mut = (v0_1.fields[1] as any);
            v1_1_mut = UH2_UH2_1(v0_1.fields[0] as any, v1_1);
            continue method67;
        }
        break;
    }
}

export function method64(v0_1_mut: UH2_$union, v1_1_mut: string, v2_1_mut: any, v3_mut: int32, v4_mut: int32): US17_$union {
    method64:
    while (true) {
        const v0_1: UH2_$union = v0_1_mut, v1_1: string = v1_1_mut, v2_1: any = v2_1_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v153: US7_$union;
        if ("" === v1_1) {
            v153 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\""], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v29: string = v1_1[0];
            if (method65(v29, 0n) === false) {
                const v43 = 1;
                const v64: int32 = (v1_1.length - 1) | 0;
                const v66: string = v1_1.slice(v43, v64 + 1);
                const v72: string = v29;
                const v75: int32 = v72.length | 0;
                const v76: string[] = fill(new Array(v75), 0, v75, "");
                const v77: Mut5 = new Mut5(0);
                while (method27(v75, v77)) {
                    const v79: int32 = v77.l0 | 0;
                    const v80: string = v72[v79];
                    setItem(v76, v79, v80);
                    const v81: int32 = (v79 + 1) | 0;
                    v77.l0 = (v81 | 0);
                }
                const v83: FSharpList<string> = ofArray<string>(v76);
                const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v83, UH0_UH0_0()), v2_1, v3, v4);
                v153 = US7_US7_0(v29, v66, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v153 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, ["\\", "`", "\""], [v2_1, v3, v4] as [any, int32, int32]])));
            }
        }
        const v168: US8_$union = ((v153.tag as int32) === /* US7_0 */ 0) ? US8_US8_0(v153.fields[0] as any, v153.fields[1] as any, v153.fields[2] as any, v153.fields[3] as any, v153.fields[4] as any) : US8_US8_1(v153.fields[0] as any);
        let v182: US8_$union;
        if ((v168.tag as int32) === /* US8_0 */ 0) {
            const v173: int32 = (v168.fields[4] as any) | 0;
            const v172: int32 = (v168.fields[3] as any) | 0;
            const v171 = v168.fields[2] as any;
            const v170 = v168.fields[1] as any;
            const v169 = v168.fields[0] as any;
            v182 = v168;
        }
        else {
            const v174 = v168.fields[0] as any;
            v182 = method66(v1_1, v2_1, v3, v4, UH3_UH3_1((arg10$0040: [string, any, int32, int32]): US8_$union => closure30(undefined, arg10$0040), UH3_UH3_1((arg10$0040_1: [string, any, int32, int32]): US8_$union => closure31(undefined, arg10$0040_1), UH3_UH3_0())));
        }
        if ((v182.tag as int32) === /* US8_0 */ 0) {
            v0_1_mut = UH2_UH2_1(v182.fields[0] as any, v0_1);
            v1_1_mut = (v182.fields[1] as any);
            v2_1_mut = (v182.fields[2] as any);
            v3_mut = (v182.fields[3] as any);
            v4_mut = (v182.fields[4] as any);
            continue method64;
        }
        else {
            const v190 = v182.fields[0] as any;
            return US17_US17_0(method67(v0_1, UH2_UH2_0()), v1_1, v2_1, v3, v4);
        }
        break;
    }
}

export function method68(v0_1: UH2_$union, v1_1: FSharpList<string>): FSharpList<string> {
    if ((v0_1.tag as int32) === /* UH2_0 */ 0) {
        return v1_1;
    }
    else {
        return cons(v0_1.fields[0] as any, method68(v0_1.fields[1] as any, v1_1));
    }
}

export function method69(v0_1_mut: UH2_$union, v1_1_mut: string, v2_1_mut: any, v3_mut: int32, v4_mut: int32): US17_$union {
    method69:
    while (true) {
        const v0_1: UH2_$union = v0_1_mut, v1_1: string = v1_1_mut, v2_1: any = v2_1_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v153: US7_$union;
        if ("" === v1_1) {
            v153 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\""], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v29: string = v1_1[0];
            if (method65(v29, 0n) === false) {
                const v43 = 1;
                const v64: int32 = (v1_1.length - 1) | 0;
                const v66: string = v1_1.slice(v43, v64 + 1);
                const v72: string = v29;
                const v75: int32 = v72.length | 0;
                const v76: string[] = fill(new Array(v75), 0, v75, "");
                const v77: Mut5 = new Mut5(0);
                while (method27(v75, v77)) {
                    const v79: int32 = v77.l0 | 0;
                    const v80: string = v72[v79];
                    setItem(v76, v79, v80);
                    const v81: int32 = (v79 + 1) | 0;
                    v77.l0 = (v81 | 0);
                }
                const v83: FSharpList<string> = ofArray<string>(v76);
                const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v83, UH0_UH0_0()), v2_1, v3, v4);
                v153 = US7_US7_0(v29, v66, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v153 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, ["\\", "`", "\""], [v2_1, v3, v4] as [any, int32, int32]])));
            }
        }
        const v168: US8_$union = ((v153.tag as int32) === /* US7_0 */ 0) ? US8_US8_0(v153.fields[0] as any, v153.fields[1] as any, v153.fields[2] as any, v153.fields[3] as any, v153.fields[4] as any) : US8_US8_1(v153.fields[0] as any);
        if ((v168.tag as int32) === /* US8_0 */ 0) {
            v0_1_mut = UH2_UH2_1(v168.fields[0] as any, v0_1);
            v1_1_mut = (v168.fields[1] as any);
            v2_1_mut = (v168.fields[2] as any);
            v3_mut = (v168.fields[3] as any);
            v4_mut = (v168.fields[4] as any);
            continue method69;
        }
        else {
            const v176 = v168.fields[0] as any;
            return US17_US17_0(method67(v0_1, UH2_UH2_0()), v1_1, v2_1, v3, v4);
        }
        break;
    }
}

export function method61(v0_1_mut: UH2_$union, v1_1_mut: string, v2_1_mut: any, v3_mut: int32, v4_mut: int32): US17_$union {
    method61:
    while (true) {
        const v0_1: UH2_$union = v0_1_mut, v1_1: string = v1_1_mut, v2_1: any = v2_1_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        const v5: boolean = "" === v1_1;
        let v161: US7_$union;
        if (v5) {
            v161 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\"", " "], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v33: string = v1_1[0];
            if (method62(v33, 0n) === false) {
                const v47 = 1;
                const v68: int32 = (v1_1.length - 1) | 0;
                const v70: string = v1_1.slice(v47, v68 + 1);
                const v76: string = v33;
                const v79: int32 = v76.length | 0;
                const v80: string[] = fill(new Array(v79), 0, v79, "");
                const v81: Mut5 = new Mut5(0);
                while (method27(v79, v81)) {
                    const v83: int32 = v81.l0 | 0;
                    const v84: string = v76[v83];
                    setItem(v80, v83, v84);
                    const v85: int32 = (v83 + 1) | 0;
                    v81.l0 = (v85 | 0);
                }
                const v87: FSharpList<string> = ofArray<string>(v80);
                const patternInput: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v87, UH0_UH0_0()), v2_1, v3, v4);
                v161 = US7_US7_0(v33, v70, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v161 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33, ["\\", "`", "\"", " "], [v2_1, v3, v4] as [any, int32, int32]])));
            }
        }
        let v181: US8_$union;
        if ((v161.tag as int32) === /* US7_0 */ 0) {
            const patternInput_1: [string, string, any, int32, int32] = method63(v161.fields[0] as any, v161.fields[1] as any, v161.fields[2] as any, v161.fields[3] as any, v161.fields[4] as any);
            v181 = US8_US8_0(patternInput_1[0], patternInput_1[1], patternInput_1[2], patternInput_1[3], patternInput_1[4]);
        }
        else {
            v181 = US8_US8_1(v161.fields[0] as any);
        }
        let v659: US8_$union;
        if ((v181.tag as int32) === /* US8_0 */ 0) {
            const v186: int32 = (v181.fields[4] as any) | 0;
            const v185: int32 = (v181.fields[3] as any) | 0;
            const v184 = v181.fields[2] as any;
            const v183 = v181.fields[1] as any;
            const v182 = v181.fields[0] as any;
            v659 = v181;
        }
        else {
            const v187 = v181.fields[0] as any;
            let v355: US7_$union;
            if (v5) {
                v355 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", [v2_1, v3, v4] as [any, int32, int32]])));
            }
            else {
                const v193: string = v1_1[0];
                if (v193 === "\"") {
                    const v205 = 1;
                    const v226: int32 = (v1_1.length - 1) | 0;
                    const v228: string = v1_1.slice(v205, v226 + 1);
                    const v234: string = v193;
                    const v237: int32 = v234.length | 0;
                    const v238: string[] = fill(new Array(v237), 0, v237, "");
                    const v239: Mut5 = new Mut5(0);
                    while (method27(v237, v239)) {
                        const v241: int32 = v239.l0 | 0;
                        const v242: string = v234[v241];
                        setItem(v238, v241, v242);
                        const v243: int32 = (v241 + 1) | 0;
                        v239.l0 = (v243 | 0);
                    }
                    const v245: FSharpList<string> = ofArray<string>(v238);
                    const patternInput_2: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v245, UH0_UH0_0()), v2_1, v3, v4);
                    v355 = US7_US7_0(v193, v228, patternInput_2[0], patternInput_2[1], patternInput_2[2]);
                }
                else {
                    const v296: int32 = (v1_1.indexOf("\n") - 1) | 0;
                    const v311 = 0;
                    const v332: int32 = (((-2 === v296) ? (v1_1.length + 1) : (v296 + 1)) - 1) | 0;
                    v355 = US7_US7_1(concat(`parsing.p_char / expected: '${"\""}' / line: ${v3} / col: ${v4}
${v2_1}${v1_1.slice(v311, v332 + 1)}`, "\n", method30(v4 - 1, 0)("") + "^", ..."\n"));
                }
            }
            let v590: US8_$union;
            if ((v355.tag as int32) === /* US7_0 */ 0) {
                const v360: int32 = (v355.fields[4] as any) | 0;
                const v359: int32 = (v355.fields[3] as any) | 0;
                const v358 = v355.fields[2] as any;
                const v357 = v355.fields[1] as any;
                const v356 = v355.fields[0] as any;
                const v362: US17_$union = method64(UH2_UH2_0(), v357, v358, v359, v360);
                let v393: US8_$union;
                if ((v362.tag as int32) === /* US17_0 */ 0) {
                    const v367: int32 = (v362.fields[4] as any) | 0;
                    const v366: int32 = (v362.fields[3] as any) | 0;
                    const v365 = v362.fields[2] as any;
                    const v364 = v362.fields[1] as any;
                    const v369: FSharpList<string> = method68(v362.fields[0] as any, empty<string>());
                    v393 = US8_US8_0(join("", delay<string>((): Iterable<string> => v369)), v364, v365, v366, v367);
                }
                else {
                    v393 = US8_US8_1(v362.fields[0] as any);
                }
                if ((v393.tag as int32) === /* US8_0 */ 0) {
                    const v398: int32 = (v393.fields[4] as any) | 0;
                    const v397: int32 = (v393.fields[3] as any) | 0;
                    const v396 = v393.fields[2] as any;
                    const v395 = v393.fields[1] as any;
                    const v394 = v393.fields[0] as any;
                    let v567: US7_$union;
                    if ("" === v395) {
                        v567 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", [v396, v397, v398] as [any, int32, int32]])));
                    }
                    else {
                        const v405: string = v395[0];
                        if (v405 === "\"") {
                            const v417 = 1;
                            const v438: int32 = (v395.length - 1) | 0;
                            const v440: string = v395.slice(v417, v438 + 1);
                            const v446: string = v405;
                            const v449: int32 = v446.length | 0;
                            const v450: string[] = fill(new Array(v449), 0, v449, "");
                            const v451: Mut5 = new Mut5(0);
                            while (method27(v449, v451)) {
                                const v453: int32 = v451.l0 | 0;
                                const v454: string = v446[v453];
                                setItem(v450, v453, v454);
                                const v455: int32 = (v453 + 1) | 0;
                                v451.l0 = (v455 | 0);
                            }
                            const v457: FSharpList<string> = ofArray<string>(v450);
                            const patternInput_3: [any, int32, int32] = method29(foldBack<string, UH0_$union>(uncurry2(method28()), v457, UH0_UH0_0()), v396, v397, v398);
                            v567 = US7_US7_0(v405, v440, patternInput_3[0], patternInput_3[1], patternInput_3[2]);
                        }
                        else {
                            const v508: int32 = (v395.indexOf("\n") - 1) | 0;
                            const v523 = 0;
                            const v544: int32 = (((-2 === v508) ? (v395.length + 1) : (v508 + 1)) - 1) | 0;
                            v567 = US7_US7_1(concat(`parsing.p_char / expected: '${"\""}' / line: ${v397} / col: ${v398}
${v396}${v395.slice(v523, v544 + 1)}`, "\n", method30(v398 - 1, 0)("") + "^", ..."\n"));
                        }
                    }
                    if ((v567.tag as int32) === /* US7_0 */ 0) {
                        const v568 = v567.fields[0] as any;
                        v590 = US8_US8_0(v394, v567.fields[1] as any, v567.fields[2] as any, v567.fields[3] as any, v567.fields[4] as any);
                    }
                    else {
                        v590 = US8_US8_1(toText(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v567.fields[0] as any, [v1_1, v2_1, v3, v4] as [string, any, int32, int32], [v357, v358, v359, v360] as [string, any, int32, int32], [v395, v396, v397, v398] as [string, any, int32, int32]])));
                    }
                }
                else {
                    const v582 = v393.fields[0] as any;
                    v590 = US8_US8_1("parsing.between / expected content");
                }
            }
            else {
                v590 = US8_US8_1(v355.fields[0] as any);
            }
            if ((v590.tag as int32) === /* US8_0 */ 0) {
                const v595: int32 = (v590.fields[4] as any) | 0;
                const v594: int32 = (v590.fields[3] as any) | 0;
                const v593 = v590.fields[2] as any;
                const v592 = v590.fields[1] as any;
                const v591 = v590.fields[0] as any;
                v659 = v590;
            }
            else {
                const v596 = v590.fields[0] as any;
                const v602: US8_$union = method66(v1_1, v2_1, v3, v4, UH3_UH3_1((arg10$0040: [string, any, int32, int32]): US8_$union => closure30(undefined, arg10$0040), UH3_UH3_1((arg10$0040_1: [string, any, int32, int32]): US8_$union => closure31(undefined, arg10$0040_1), UH3_UH3_0())));
                let v613: US8_$union;
                if ((v602.tag as int32) === /* US8_0 */ 0) {
                    const v603 = v602.fields[0] as any;
                    v613 = US8_US8_0("", v602.fields[1] as any, v602.fields[2] as any, v602.fields[3] as any, v602.fields[4] as any);
                }
                else {
                    v613 = US8_US8_1(v602.fields[0] as any);
                }
                let v624: US17_$union;
                if ((v613.tag as int32) === /* US8_0 */ 0) {
                    const v614 = v613.fields[0] as any;
                    v624 = method69(UH2_UH2_0(), v613.fields[1] as any, v613.fields[2] as any, v613.fields[3] as any, v613.fields[4] as any);
                }
                else {
                    v624 = US17_US17_1(v613.fields[0] as any);
                }
                if ((v624.tag as int32) === /* US17_0 */ 0) {
                    const v629: int32 = (v624.fields[4] as any) | 0;
                    const v628: int32 = (v624.fields[3] as any) | 0;
                    const v627 = v624.fields[2] as any;
                    const v626 = v624.fields[1] as any;
                    const v631: FSharpList<string> = method68(v624.fields[0] as any, empty<string>());
                    v659 = US8_US8_0(join("", delay<string>((): Iterable<string> => v631)), v626, v627, v628, v629);
                }
                else {
                    v659 = US8_US8_1(v624.fields[0] as any);
                }
            }
        }
        if ((v659.tag as int32) === /* US8_0 */ 0) {
            const v664: int32 = (v659.fields[4] as any) | 0;
            const v663: int32 = (v659.fields[3] as any) | 0;
            const v662 = v659.fields[2] as any;
            const v661 = v659.fields[1] as any;
            const v660 = v659.fields[0] as any;
            const v666: int32 = method37(v661, 0) | 0;
            let v708: US10_$union;
            if (0 === v666) {
                v708 = US10_US10_1("parsing.spaces1 / expected at least one space");
            }
            else {
                const v680: int32 = v666 | 0;
                const v701: int32 = (v661.length - 1) | 0;
                v708 = US10_US10_0(v661.slice(v680, v701 + 1), v662, v663, v664);
            }
            if ((v708.tag as int32) === /* US10_0 */ 0) {
                v0_1_mut = UH2_UH2_1(v660, v0_1);
                v1_1_mut = (v708.fields[0] as any);
                v2_1_mut = (v708.fields[1] as any);
                v3_mut = (v708.fields[2] as any);
                v4_mut = (v708.fields[3] as any);
                continue method61;
            }
            else {
                const v715 = v708.fields[0] as any;
                return US17_US17_0(method67(v0_1, UH2_UH2_1(v660, UH2_UH2_0())), v661, v662, v663, v664);
            }
        }
        else {
            const v722 = v659.fields[0] as any;
            return US17_US17_0(method67(v0_1, UH2_UH2_0()), v1_1, v2_1, v3, v4);
        }
        break;
    }
}

export function method60(v0_1: string): US16_$union {
    let _v0: Option<Option<string>> = undefined;
    _v0 = some(v0_1);
    const v22: US17_$union = method61(UH2_UH2_0(), defaultArg((_v0 == null) ? (() => {
        throw new Error("optionm\'.of_obj / _v0=None");
    })() : value_12(_v0), ""), StringBuilder_$ctor_Z721C83C5(method26()), 1, 1);
    if ((v22.tag as int32) === /* US17_0 */ 0) {
        const v27: int32 = (v22.fields[4] as any) | 0;
        const v26: int32 = (v22.fields[3] as any) | 0;
        const v25 = v22.fields[2] as any;
        const v24 = v22.fields[1] as any;
        return US16_US16_0(toArray<string>(method68(v22.fields[0] as any, empty<string>())));
    }
    else {
        return US16_US16_1(v22.fields[0] as any);
    }
}

export function closure29(unitVar: void, v0_1: string): FSharpResult$2_$union<string[], string> {
    const v1_1: US16_$union = method60(v0_1);
    if ((v1_1.tag as int32) === /* US16_0 */ 0) {
        return FSharpResult$2_Ok<string[], string>(v1_1.fields[0] as any);
    }
    else {
        return FSharpResult$2_Error<string[], string>(v1_1.fields[0] as any);
    }
}

export const v0: any = undefined;

export const v1 = (): void => {
    closure0(undefined, undefined);
};

export const v2: any = (v1(), v0);

export const v17 = (): void => {
    closure3(undefined, undefined);
};

export function current_process_kill(): void {
    v17();
}

export const v18 = (v: string): Async<[int32, string]> => closure13(undefined, v);

export function execute_async(x: string): Async<[int32, string]> {
    return v18(x);
}

export const v19 = (arg10$0040: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>]): Async<[int32, string]> => closure27(undefined, arg10$0040);

export function execute_with_options_async(x: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>]): Async<[int32, string]> {
    return v19(x);
}

export const v20 = (v: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>] => closure28(undefined, v);

export function execution_options(x: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>] {
    return v20(x);
}

export const v21 = (v: string): FSharpResult$2_$union<string[], string> => closure29(undefined, v);

export function split_args(x: string): FSharpResult$2_$union<string[], string> {
    return v21(x);
}


