import { defaultOf, compare, IComparable, IEquatable, createAtom } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Util.js";
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
    let v48: US1_$union, v55: US1_$union, v62: US1_$union, v69: US1_$union, v76: US1_$union, v83: US1_$union, v90: US1_$union, v97: US1_$union, v104: US1_$union;
    const v1_1: string = method2("TRACE_LEVEL");
    const v6: string = "Critical".toLocaleLowerCase();
    const v13: string = "Warning".toLocaleLowerCase();
    const v20_1: string = "Info".toLocaleLowerCase();
    const v27: string = "Debug".toLocaleLowerCase();
    const v34: string = "Verbose".toLocaleLowerCase();
    const v41: US1_$union = ("Verbose" === v1_1) ? US1_US1_0(US0_US0_0()) : US1_US1_1();
    return [((v41.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v41.fields[0] as any) : ((v48 = (("Debug" === v1_1) ? US1_US1_0(US0_US0_1()) : US1_US1_1()), ((v48.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v48.fields[0] as any) : ((v55 = (("Info" === v1_1) ? US1_US1_0(US0_US0_2()) : US1_US1_1()), ((v55.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v55.fields[0] as any) : ((v62 = (("Warning" === v1_1) ? US1_US1_0(US0_US0_3()) : US1_US1_1()), ((v62.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v62.fields[0] as any) : ((v69 = (("Critical" === v1_1) ? US1_US1_0(US0_US0_4()) : US1_US1_1()), ((v69.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v69.fields[0] as any) : ((v76 = ((v34 === v1_1) ? US1_US1_0(US0_US0_0()) : US1_US1_1()), ((v76.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v76.fields[0] as any) : ((v83 = ((v27 === v1_1) ? US1_US1_0(US0_US0_1()) : US1_US1_1()), ((v83.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v83.fields[0] as any) : ((v90 = ((v20_1 === v1_1) ? US1_US1_0(US0_US0_2()) : US1_US1_1()), ((v90.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v90.fields[0] as any) : ((v97 = ((v13 === v1_1) ? US1_US1_0(US0_US0_3()) : US1_US1_1()), ((v97.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v97.fields[0] as any) : ((v104 = ((v6 === v1_1) ? US1_US1_0(US0_US0_4()) : US1_US1_1()), ((v104.tag as int32) === /* US1_0 */ 0) ? US1_US1_0(v104.fields[0] as any) : US1_US1_1())))))))))))))))))), (method2("AUTOMATION") !== "True") ? US2_US2_1() : US2_US2_0(toInt64(fromInt64(getTicks(now()))))] as [US1_$union, US2_$union];
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
    const v4: string = "Warning".toLocaleLowerCase();
    return ("\u001b[93m" + method13(v4[0])) + method15();
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

export function method27(v0_1: int64, v1_1: string, v2_1: int64): UH0_$union {
    if (compare_1(v2_1, v0_1) < 0) {
        return UH0_UH0_1(v1_1[~~toInt32(v2_1)], method27(v0_1, v1_1, toInt64(op_Addition(v2_1, 1n))));
    }
    else {
        return UH0_UH0_0();
    }
}

export function method28(v0_1_mut: UH0_$union, v1_1_mut: any, v2_1_mut: int32, v3_mut: int32): [any, int32, int32] {
    let v13: any, v24: any;
    method28:
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
            continue method28;
        }
        break;
    }
}

export function closure15(v0_1: int32, v1_1: int32, v2_1: string): string {
    if (v1_1 >= v0_1) {
        return v2_1;
    }
    else {
        return method29(v0_1, v1_1 + 1)(v2_1 + " ");
    }
}

export function method29(v0_1: int32, v1_1: int32): ((arg0: string) => string) {
    return (v: string): string => closure15(v0_1, v1_1, v);
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
            const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v51.length)), v51, 0n), v1_1, v2_1, v3);
            return US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v66: int32 = (v0_1.indexOf("\n") - 1) | 0;
            const v81 = 0;
            const v102: int32 = (((-2 === v66) ? (v0_1.length + 1) : (v66 + 1)) - 1) | 0;
            return US7_US7_1(concat(`parsing.p_char / expected: '${"\""}' / line: ${v2_1} / col: ${v3}
${v1_1}${v0_1.slice(v81, v102 + 1)}`, "\n", method29(v3 - 1, 0)("") + "^", ..."\n"));
        }
    }
}

export function closure16(unitVar: void, _arg: [string, any, int32, int32]): US7_$union {
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
            const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v51.length)), v51, 0n), v1_1, v2_1, v3);
            return US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v66: int32 = (v0_1.indexOf("\n") - 1) | 0;
            const v81 = 0;
            const v102: int32 = (((-2 === v66) ? (v0_1.length + 1) : (v66 + 1)) - 1) | 0;
            return US7_US7_1(concat(`parsing.p_char / expected: '${"\'"}' / line: ${v2_1} / col: ${v3}
${v1_1}${v0_1.slice(v81, v102 + 1)}`, "\n", method29(v3 - 1, 0)("") + "^", ..."\n"));
        }
    }
}

export function method30(v0_1_mut: string, v1_1_mut: any, v2_1_mut: UH1_$union): US7_$union {
    method30:
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
                continue method30;
            }
        }
        break;
    }
}

export function method31(v0_1_mut: string, v1_1_mut: int64): boolean {
    method31:
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
                continue method31;
            }
        }
        break;
    }
}

export function method32(v0_1_mut: string, v1_1_mut: string, v2_1_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method32:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: string = v1_1_mut, v2_1: any = v2_1_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v98: US7_$union;
        if ("" === v1_1) {
            v98 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'"], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v25: string = v1_1[0];
            if (method31(v25, 0n) === false) {
                const v39 = 1;
                const v60: int32 = (v1_1.length - 1) | 0;
                const v62: string = v1_1.slice(v39, v60 + 1);
                const v68: string = v25;
                const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v68.length)), v68, 0n), v2_1, v3, v4);
                v98 = US7_US7_0(v25, v62, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v98 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v25, ["\"", "\'"], [v2_1, v3, v4] as [any, int32, int32]])));
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
            v0_1_mut = (v0_1 + (v110.fields[0] as any));
            v1_1_mut = (v110.fields[1] as any);
            v2_1_mut = (v110.fields[2] as any);
            v3_mut = (v110.fields[3] as any);
            v4_mut = (v110.fields[4] as any);
            continue method32;
        }
        else {
            const v127 = v110.fields[0] as any;
            return [v0_1, v1_1, v2_1, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method33(v0_1_mut: string, v1_1_mut: any, v2_1_mut: int32, v3_mut: int32, v4_mut: UH1_$union): US7_$union {
    method33:
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
                continue method33;
            }
        }
        break;
    }
}

export function method34(v0_1_mut: string, v1_1_mut: int64): boolean {
    method34:
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
                continue method34;
            }
        }
        break;
    }
}

export function method35(v0_1_mut: string, v1_1_mut: string, v2_1_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method35:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: string = v1_1_mut, v2_1: any = v2_1_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v106: US7_$union;
        if ("" === v1_1) {
            v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'", " "], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v29: string = v1_1[0];
            if (method34(v29, 0n) === false) {
                const v43 = 1;
                const v64: int32 = (v1_1.length - 1) | 0;
                const v66: string = v1_1.slice(v43, v64 + 1);
                const v72: string = v29;
                const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v72.length)), v72, 0n), v2_1, v3, v4);
                v106 = US7_US7_0(v29, v66, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, ["\"", "\'", " "], [v2_1, v3, v4] as [any, int32, int32]])));
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
            v0_1_mut = (v0_1 + (v118.fields[0] as any));
            v1_1_mut = (v118.fields[1] as any);
            v2_1_mut = (v118.fields[2] as any);
            v3_mut = (v118.fields[3] as any);
            v4_mut = (v118.fields[4] as any);
            continue method35;
        }
        else {
            const v135 = v118.fields[0] as any;
            return [v0_1, v1_1, v2_1, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method36(v0_1_mut: string, v1_1_mut: int32): int32 {
    method36:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: int32 = v1_1_mut;
        if (v1_1 >= v0_1.length) {
            return v1_1 | 0;
        }
        else if (" " === v0_1[v1_1]) {
            v0_1_mut = v0_1;
            v1_1_mut = (v1_1 + 1);
            continue method36;
        }
        else {
            return v1_1 | 0;
        }
        break;
    }
}

export function method37(v0_1_mut: string, v1_1_mut: string, v2_1_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method37:
    while (true) {
        const v0_1: string = v0_1_mut, v1_1: string = v1_1_mut, v2_1: any = v2_1_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v66: US7_$union;
        if ("" === v1_1) {
            v66 = US7_US7_1(toText(interpolate("parsing.any_char / unexpected end of input / s: %A%P()", [[v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v16: string = v1_1[0];
            const v27 = 1;
            const v48: int32 = (v1_1.length - 1) | 0;
            const v50: string = v1_1.slice(v27, v48 + 1);
            const v56: string = v16;
            const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v56.length)), v56, 0n), v2_1, v3, v4);
            v66 = US7_US7_0(v16, v50, patternInput[0], patternInput[1], patternInput[2]);
        }
        if ((v66.tag as int32) === /* US7_0 */ 0) {
            v0_1_mut = (v0_1 + (v66.fields[0] as any));
            v1_1_mut = (v66.fields[1] as any);
            v2_1_mut = (v66.fields[2] as any);
            v3_mut = (v66.fields[3] as any);
            v4_mut = (v66.fields[4] as any);
            continue method37;
        }
        else {
            const v83 = v66.fields[0] as any;
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
    const v20_1 = (arg10$0040_1: [string, any, int32, int32]): US7_$union => closure16(undefined, arg10$0040_1);
    const v24: US7_$union = method30(v10, v16, UH1_UH1_1(v19_1, UH1_UH1_1(v20_1, UH1_UH1_0())));
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
            if (method31(v50, 0n) === false) {
                const v64 = 1;
                const v85: int32 = (v26.length - 1) | 0;
                const v87: string = v26.slice(v64, v85 + 1);
                const v93: string = v50;
                const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v93.length)), v93, 0n), v27, v28, v29);
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
            const patternInput_1: [string, string, any, int32, int32] = method32(v135.fields[0] as any, v135.fields[1] as any, v135.fields[2] as any, v135.fields[3] as any, v135.fields[4] as any);
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
            const v174: US7_$union = method33(v167, v168, v169, v170, UH1_UH1_1(v19_1, UH1_UH1_1(v20_1, UH1_UH1_0())));
            if ((v174.tag as int32) === /* US7_0 */ 0) {
                const v175 = v174.fields[0] as any;
                v197 = US8_US8_0(v166, v174.fields[1] as any, v174.fields[2] as any, v174.fields[3] as any, v174.fields[4] as any);
            }
            else {
                v197 = US8_US8_1(toText(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v174.fields[0] as any, [v10, v16, 1, 1] as [string, any, int32, int32], [v26, v27, v28, v29] as [string, any, int32, int32], [v167, v168, v169, v170] as [string, any, int32, int32]])));
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
            v307 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\"", "\'", " "], [v16, 1, 1] as [any, int32, int32]])));
        }
        else {
            const v228: string = v10[0];
            if (method34(v228, 0n) === false) {
                const v242 = 1;
                const v263: int32 = (v10.length - 1) | 0;
                const v265: string = v10.slice(v242, v263 + 1);
                const v271: string = v228;
                const patternInput_2: [any, int32, int32] = method28(method27(toInt64(fromInt32(v271.length)), v271, 0n), v16, 1, 1);
                v307 = US7_US7_0(v228, v265, patternInput_2[0], patternInput_2[1], patternInput_2[2]);
            }
            else {
                v307 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v228, ["\"", "\'", " "], [v16, 1, 1] as [any, int32, int32]])));
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
            const patternInput_3: [string, string, any, int32, int32] = method35(v319.fields[0] as any, v319.fields[1] as any, v319.fields[2] as any, v319.fields[3] as any, v319.fields[4] as any);
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
            const v354: US10_$union = (v10.length === 0) ? US10_US10_0(v10, v16, 1, 1) : US10_US10_1(toText(interpolate("parsing.eof / expected end of input / input: %A%P()", [v10])));
            const v363: US8_$union = ((v354.tag as int32) === /* US10_0 */ 0) ? US8_US8_0("", v354.fields[0] as any, v354.fields[1] as any, v354.fields[2] as any, v354.fields[3] as any) : US8_US8_1(v354.fields[0] as any);
            if ((v363.tag as int32) === /* US8_0 */ 0) {
                const v368: int32 = (v363.fields[4] as any) | 0;
                const v367: int32 = (v363.fields[3] as any) | 0;
                const v366 = v363.fields[2] as any;
                const v365 = v363.fields[1] as any;
                const v364 = v363.fields[0] as any;
                const v381: int32 = method36(v365, 0) | 0;
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
                const patternInput_4: [any, int32, int32] = method28(method27(toInt64(fromInt32(v469.length)), v469, 0n), v419, v420, v421);
                v542 = US7_US7_0(v428, v463, patternInput_4[0], patternInput_4[1], patternInput_4[2]);
            }
            else {
                const v484: int32 = (v418.indexOf("\n") - 1) | 0;
                const v499 = 0;
                const v520: int32 = (((-2 === v484) ? (v418.length + 1) : (v484 + 1)) - 1) | 0;
                v542 = US7_US7_1(concat(`parsing.p_char / expected: '${" "}' / line: ${v420} / col: ${v421}
${v419}${v418.slice(v499, v520 + 1)}`, "\n", method29(v421 - 1, 0)("") + "^", ..."\n"));
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
                const patternInput_5: [any, int32, int32] = method28(method27(toInt64(fromInt32(v611.length)), v611, 0n), v557, v558, v559);
                v621 = US7_US7_0(v571, v605, patternInput_5[0], patternInput_5[1], patternInput_5[2]);
            }
            if ((v621.tag as int32) === /* US7_0 */ 0) {
                const patternInput_6: [string, string, any, int32, int32] = method37(v621.fields[0] as any, v621.fields[1] as any, v621.fields[2] as any, v621.fields[3] as any, v621.fields[4] as any);
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

export function method38(): string {
    const v4: string = "Debug".toLocaleLowerCase();
    return ("\u001b[94m" + method13(v4[0])) + method15();
}

export function method40(v0_1: string, v1_1: US5_$union, v2_1: string, v3: Option<any>, v4: [string, string][], v5: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v6: Option<((arg0: any) => void)>, v7: boolean, v8: Option<string>): string {
    const v10: Mut3 = new Mut3(method14());
    let v19_1: any;
    closure7(v10, "{ ", undefined);
    v19_1 = undefined;
    let v30: any;
    closure7(v10, "file_name", undefined);
    v30 = undefined;
    let v41: any;
    closure7(v10, " = ", undefined);
    v41 = undefined;
    let v50: any;
    closure7(v10, v0_1, undefined);
    v50 = undefined;
    let v61: any;
    closure7(v10, "; ", undefined);
    v61 = undefined;
    let v72: any;
    closure7(v10, "arguments", undefined);
    v72 = undefined;
    let v81: any;
    closure7(v10, " = ", undefined);
    v81 = undefined;
    let v94: any;
    closure7(v10, toText(interpolate("%A%P()", [v1_1])), undefined);
    v94 = undefined;
    let v103: any;
    closure7(v10, "; ", undefined);
    v103 = undefined;
    let v114: any;
    closure7(v10, "options", undefined);
    v114 = undefined;
    let v123: any;
    closure7(v10, " = ", undefined);
    v123 = undefined;
    let v132: any;
    closure7(v10, "{ ", undefined);
    v132 = undefined;
    let v143: any;
    closure7(v10, "command", undefined);
    v143 = undefined;
    let v152: any;
    closure7(v10, " = ", undefined);
    v152 = undefined;
    let v161: any;
    closure7(v10, v2_1, undefined);
    v161 = undefined;
    let v170: any;
    closure7(v10, "; ", undefined);
    v170 = undefined;
    let v181: any;
    closure7(v10, "cancellation_token", undefined);
    v181 = undefined;
    let v190: any;
    closure7(v10, " = ", undefined);
    v190 = undefined;
    let v238: any;
    closure7(v10, toText(interpolate("%A%P()", [v3])), undefined);
    v238 = undefined;
    let v247: any;
    closure7(v10, "; ", undefined);
    v247 = undefined;
    let v258: any;
    closure7(v10, "environment_variables", undefined);
    v258 = undefined;
    let v267: any;
    closure7(v10, " = ", undefined);
    v267 = undefined;
    let v280: any;
    closure7(v10, toText(interpolate("%A%P()", [v4])), undefined);
    v280 = undefined;
    let v289: any;
    closure7(v10, "; ", undefined);
    v289 = undefined;
    let v300: any;
    closure7(v10, "on_line", undefined);
    v300 = undefined;
    let v309: any;
    closure7(v10, " = ", undefined);
    v309 = undefined;
    let v357: any;
    closure7(v10, toText(interpolate("%A%P()", [v5])), undefined);
    v357 = undefined;
    let v366: any;
    closure7(v10, "; ", undefined);
    v366 = undefined;
    let v377: any;
    closure7(v10, "stdin", undefined);
    v377 = undefined;
    let v386: any;
    closure7(v10, " = ", undefined);
    v386 = undefined;
    let v434: any;
    closure7(v10, toText(interpolate("%A%P()", [v6])), undefined);
    v434 = undefined;
    let v443: any;
    closure7(v10, "; ", undefined);
    v443 = undefined;
    let v454: any;
    closure7(v10, "trace", undefined);
    v454 = undefined;
    let v463: any;
    closure7(v10, " = ", undefined);
    v463 = undefined;
    let v475: any;
    closure7(v10, v7 ? "true" : "false", undefined);
    v475 = undefined;
    let v484: any;
    closure7(v10, "; ", undefined);
    v484 = undefined;
    let v495: any;
    closure7(v10, "working_directory", undefined);
    v495 = undefined;
    let v504: any;
    closure7(v10, " = ", undefined);
    v504 = undefined;
    let v552: any;
    closure7(v10, toText(interpolate("%A%P()", [v8])), undefined);
    v552 = undefined;
    let v563: any;
    closure7(v10, " }", undefined);
    v563 = undefined;
    let v572: any;
    closure7(v10, " }", undefined);
    v572 = undefined;
    return v10.l0;
}

export function method39(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: US5_$union, v10: string, v11: Option<any>, v12: [string, string][], v13: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v14: Option<((arg0: any) => void)>, v15: boolean, v16: Option<string>): string {
    const v17_1: string = method40(v8, v9, v10, v11, v12, v13, v14, v15, v16);
    return method18(`${v6} ${v7} #${v0_1.l0} ${"runtime.execute_with_options_async"} / ${v17_1}`);
}

export function closure17(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: US5_$union, v8: string, unitVar: void): void {
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
        method19(method39(v34, v35, v36, v37, v38, v39, method8(v34, v35, v36, v37, v38, v39), method38(), v8, v7, v0_1, v1_1, v2_1, v3, v4, v5, v6));
    }
}

export function method41(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>): [string, string][] {
    return v2_1;
}

export function method42(v0_1: int32, v1_1: Mut5): boolean {
    return v1_1.l0 < v0_1;
}

export function method45(v0_1: boolean): string {
    return defaultOf();
}

export function closure19(unitVar: void, v0_1: ((arg0: [int32, string, boolean]) => Async<void>)): US14_$union {
    return US14_US14_0(v0_1);
}

export function method46(): ((arg0: ((arg0: [int32, string, boolean]) => Async<void>)) => US14_$union) {
    return (v: ((arg0: [int32, string, boolean]) => Async<void>)): US14_$union => closure19(undefined, v);
}

export function method47(v0_1: boolean): int32 {
    return defaultOf();
}

export function method48(): string {
    const v4: string = "Verbose".toLocaleLowerCase();
    return ("\u001b[90m" + method13(v4[0])) + method15();
}

export function method49(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string): string {
    const v9: string = method17();
    return method18(`${v6} ${v7} #${v0_1.l0} ${v8} / ${v9}`);
}

export function closure20(v0_1: string, unitVar: void): void {
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
            return singleton.Combine<void>(v5 ? ((v69 = ((closure20(v66, undefined), undefined)), singleton.Zero())) : ((v121 = ((closure10(v66, undefined), undefined)), singleton.Zero())), singleton.Delay<void>((): Async<void> => {
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

export function closure18(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: any, v9: boolean, v10: boolean): void {
    startImmediate(method43(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10));
}

export function closure21(unitVar: void, v0_1: any): US15_$union {
    return US15_US15_0(v0_1);
}

export function method50(): ((arg0: any) => US15_$union) {
    return (v: any): US15_$union => closure21(undefined, v);
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

export function closure22(v0_1: boolean, unitVar: void): void {
    if (method52(v0_1) === false) {
        method53(v0_1);
    }
}

export function method56(v0_1: any): string {
    const v2_1: Mut3 = new Mut3(method14());
    let v11: any;
    closure7(v2_1, "{ ", undefined);
    v11 = undefined;
    let v22: any;
    closure7(v2_1, "ex", undefined);
    v22 = undefined;
    let v33: any;
    closure7(v2_1, " = ", undefined);
    v33 = undefined;
    let v81: any;
    closure7(v2_1, toText(interpolate("%A%P()", [v0_1])), undefined);
    v81 = undefined;
    let v92: any;
    closure7(v2_1, " }", undefined);
    v92 = undefined;
    return v2_1.l0;
}

export function method55(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: any): string {
    const v9: string = method56(v8);
    return method18(`${v6} ${v7} #${v0_1.l0} ${"runtime.execute_with_options_async / WaitForExitAsync"} / ${v9}`);
}

export function closure23(v0_1: any, unitVar: void): void {
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
        closure23(v230, undefined);
        v275 = undefined;
        return singleton.Return<int32>(-2147483648);
    }));
}

export function method57(): string {
    return "\n";
}

export function method59(v0_1: int32, v1_1: int32, v2_1: string, v3: Option<any>, v4: [string, string][], v5: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v6: Option<((arg0: any) => void)>, v7: boolean, v8: Option<string>): string {
    const v10: Mut3 = new Mut3(method14());
    let v19_1: any;
    closure7(v10, "{ ", undefined);
    v19_1 = undefined;
    let v30: any;
    closure7(v10, "exit_code", undefined);
    v30 = undefined;
    let v41: any;
    closure7(v10, " = ", undefined);
    v41 = undefined;
    let v50: any;
    closure7(v10, `${v0_1}`, undefined);
    v50 = undefined;
    let v61: any;
    closure7(v10, "; ", undefined);
    v61 = undefined;
    let v72: any;
    closure7(v10, "output_length", undefined);
    v72 = undefined;
    let v81: any;
    closure7(v10, " = ", undefined);
    v81 = undefined;
    let v90: any;
    closure7(v10, `${v1_1}`, undefined);
    v90 = undefined;
    let v99: any;
    closure7(v10, "; ", undefined);
    v99 = undefined;
    let v110: any;
    closure7(v10, "options", undefined);
    v110 = undefined;
    let v119: any;
    closure7(v10, " = ", undefined);
    v119 = undefined;
    let v128: any;
    closure7(v10, "{ ", undefined);
    v128 = undefined;
    let v139: any;
    closure7(v10, "command", undefined);
    v139 = undefined;
    let v148: any;
    closure7(v10, " = ", undefined);
    v148 = undefined;
    let v157: any;
    closure7(v10, v2_1, undefined);
    v157 = undefined;
    let v166: any;
    closure7(v10, "; ", undefined);
    v166 = undefined;
    let v177: any;
    closure7(v10, "cancellation_token", undefined);
    v177 = undefined;
    let v186: any;
    closure7(v10, " = ", undefined);
    v186 = undefined;
    let v234: any;
    closure7(v10, toText(interpolate("%A%P()", [v3])), undefined);
    v234 = undefined;
    let v243: any;
    closure7(v10, "; ", undefined);
    v243 = undefined;
    let v254: any;
    closure7(v10, "environment_variables", undefined);
    v254 = undefined;
    let v263: any;
    closure7(v10, " = ", undefined);
    v263 = undefined;
    let v276: any;
    closure7(v10, toText(interpolate("%A%P()", [v4])), undefined);
    v276 = undefined;
    let v285: any;
    closure7(v10, "; ", undefined);
    v285 = undefined;
    let v296: any;
    closure7(v10, "on_line", undefined);
    v296 = undefined;
    let v305: any;
    closure7(v10, " = ", undefined);
    v305 = undefined;
    let v353: any;
    closure7(v10, toText(interpolate("%A%P()", [v5])), undefined);
    v353 = undefined;
    let v362: any;
    closure7(v10, "; ", undefined);
    v362 = undefined;
    let v373: any;
    closure7(v10, "stdin", undefined);
    v373 = undefined;
    let v382: any;
    closure7(v10, " = ", undefined);
    v382 = undefined;
    let v430: any;
    closure7(v10, toText(interpolate("%A%P()", [v6])), undefined);
    v430 = undefined;
    let v439: any;
    closure7(v10, "; ", undefined);
    v439 = undefined;
    let v450: any;
    closure7(v10, "trace", undefined);
    v450 = undefined;
    let v459: any;
    closure7(v10, " = ", undefined);
    v459 = undefined;
    let v471: any;
    closure7(v10, v7 ? "true" : "false", undefined);
    v471 = undefined;
    let v480: any;
    closure7(v10, "; ", undefined);
    v480 = undefined;
    let v491: any;
    closure7(v10, "working_directory", undefined);
    v491 = undefined;
    let v500: any;
    closure7(v10, " = ", undefined);
    v500 = undefined;
    let v548: any;
    closure7(v10, toText(interpolate("%A%P()", [v8])), undefined);
    v548 = undefined;
    let v559: any;
    closure7(v10, " }", undefined);
    v559 = undefined;
    let v568: any;
    closure7(v10, " }", undefined);
    v568 = undefined;
    return v10.l0;
}

export function method58(v0_1: Mut0, v1_1: Mut1, v2_1: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: int32, v10: string, v11: Option<any>, v12: [string, string][], v13: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v14: Option<((arg0: any) => void)>, v15: boolean, v16: Option<string>): string {
    const v17_1: string = method59(v8, v9, v10, v11, v12, v13, v14, v15, v16);
    return method18(`${v6} ${v7} #${v0_1.l0} ${"runtime.execute_with_options_async"} / ${v17_1}`);
}

export function closure24(v0_1: string, v1_1: Option<any>, v2_1: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: int32, v8: string, unitVar: void): void {
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
        method19(method58(v34, v35, v36, v37, v38, v39, method8(v34, v35, v36, v37, v38, v39), method38(), v7, v8.length, v0_1, v1_1, v2_1, v3, v4, v5, v6));
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

export function closure25(unitVar: void, _arg: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>]): Async<[int32, string]> {
    return method23(_arg[0], _arg[1], _arg[2], _arg[3], _arg[4], _arg[5], _arg[6]);
}

export function closure26(unitVar: void, v0_1: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>] {
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
        let v114: US7_$union;
        if ("" === v1_1) {
            v114 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\"", " "], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v33: string = v1_1[0];
            if (method62(v33, 0n) === false) {
                const v47 = 1;
                const v68: int32 = (v1_1.length - 1) | 0;
                const v70: string = v1_1.slice(v47, v68 + 1);
                const v76: string = v33;
                const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v76.length)), v76, 0n), v2_1, v3, v4);
                v114 = US7_US7_0(v33, v70, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v114 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33, ["\\", "`", "\"", " "], [v2_1, v3, v4] as [any, int32, int32]])));
            }
        }
        if ((v114.tag as int32) === /* US7_0 */ 0) {
            v0_1_mut = (v0_1 + (v114.fields[0] as any));
            v1_1_mut = (v114.fields[1] as any);
            v2_1_mut = (v114.fields[2] as any);
            v3_mut = (v114.fields[3] as any);
            v4_mut = (v114.fields[4] as any);
            continue method63;
        }
        else {
            const v131 = v114.fields[0] as any;
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

export function closure28(unitVar: void, _arg: [string, any, int32, int32]): US8_$union {
    const v3: int32 = _arg[3] | 0;
    const v2_1: int32 = _arg[2] | 0;
    const v1_1: any = _arg[1];
    const v0_1: string = _arg[0];
    let v125: US7_$union;
    if ("" === v0_1) {
        v125 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\\", [v1_1, v2_1, v3] as [any, int32, int32]])));
    }
    else {
        const v10: string = v0_1[0];
        if (v10 === "\\") {
            const v22 = 1;
            const v43: int32 = (v0_1.length - 1) | 0;
            const v45: string = v0_1.slice(v22, v43 + 1);
            const v51: string = v10;
            const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v51.length)), v51, 0n), v1_1, v2_1, v3);
            v125 = US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v66: int32 = (v0_1.indexOf("\n") - 1) | 0;
            const v81 = 0;
            const v102: int32 = (((-2 === v66) ? (v0_1.length + 1) : (v66 + 1)) - 1) | 0;
            v125 = US7_US7_1(concat(`parsing.p_char / expected: '${"\\"}' / line: ${v2_1} / col: ${v3}
${v1_1}${v0_1.slice(v81, v102 + 1)}`, "\n", method29(v3 - 1, 0)("") + "^", ..."\n"));
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
            const patternInput_1: [any, int32, int32] = method28(method27(toInt64(fromInt32(v182.length)), v182, 0n), v128, v129, v130);
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
    const v2_1: int32 = _arg[2] | 0;
    const v1_1: any = _arg[1];
    const v0_1: string = _arg[0];
    let v125: US7_$union;
    if ("" === v0_1) {
        v125 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["`", [v1_1, v2_1, v3] as [any, int32, int32]])));
    }
    else {
        const v10: string = v0_1[0];
        if (v10 === "`") {
            const v22 = 1;
            const v43: int32 = (v0_1.length - 1) | 0;
            const v45: string = v0_1.slice(v22, v43 + 1);
            const v51: string = v10;
            const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v51.length)), v51, 0n), v1_1, v2_1, v3);
            v125 = US7_US7_0(v10, v45, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v66: int32 = (v0_1.indexOf("\n") - 1) | 0;
            const v81 = 0;
            const v102: int32 = (((-2 === v66) ? (v0_1.length + 1) : (v66 + 1)) - 1) | 0;
            v125 = US7_US7_1(concat(`parsing.p_char / expected: '${"`"}' / line: ${v2_1} / col: ${v3}
${v1_1}${v0_1.slice(v81, v102 + 1)}`, "\n", method29(v3 - 1, 0)("") + "^", ..."\n"));
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
            const patternInput_1: [any, int32, int32] = method28(method27(toInt64(fromInt32(v182.length)), v182, 0n), v128, v129, v130);
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
        let v106: US7_$union;
        if ("" === v1_1) {
            v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\""], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v29: string = v1_1[0];
            if (method65(v29, 0n) === false) {
                const v43 = 1;
                const v64: int32 = (v1_1.length - 1) | 0;
                const v66: string = v1_1.slice(v43, v64 + 1);
                const v72: string = v29;
                const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v72.length)), v72, 0n), v2_1, v3, v4);
                v106 = US7_US7_0(v29, v66, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, ["\\", "`", "\""], [v2_1, v3, v4] as [any, int32, int32]])));
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
            v135 = method66(v1_1, v2_1, v3, v4, UH3_UH3_1((arg10$0040: [string, any, int32, int32]): US8_$union => closure28(undefined, arg10$0040), UH3_UH3_1((arg10$0040_1: [string, any, int32, int32]): US8_$union => closure29(undefined, arg10$0040_1), UH3_UH3_0())));
        }
        if ((v135.tag as int32) === /* US8_0 */ 0) {
            v0_1_mut = UH2_UH2_1(v135.fields[0] as any, v0_1);
            v1_1_mut = (v135.fields[1] as any);
            v2_1_mut = (v135.fields[2] as any);
            v3_mut = (v135.fields[3] as any);
            v4_mut = (v135.fields[4] as any);
            continue method64;
        }
        else {
            const v143 = v135.fields[0] as any;
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
        let v106: US7_$union;
        if ("" === v1_1) {
            v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\""], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v29: string = v1_1[0];
            if (method65(v29, 0n) === false) {
                const v43 = 1;
                const v64: int32 = (v1_1.length - 1) | 0;
                const v66: string = v1_1.slice(v43, v64 + 1);
                const v72: string = v29;
                const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v72.length)), v72, 0n), v2_1, v3, v4);
                v106 = US7_US7_0(v29, v66, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v106 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v29, ["\\", "`", "\""], [v2_1, v3, v4] as [any, int32, int32]])));
            }
        }
        const v121: US8_$union = ((v106.tag as int32) === /* US7_0 */ 0) ? US8_US8_0(v106.fields[0] as any, v106.fields[1] as any, v106.fields[2] as any, v106.fields[3] as any, v106.fields[4] as any) : US8_US8_1(v106.fields[0] as any);
        if ((v121.tag as int32) === /* US8_0 */ 0) {
            v0_1_mut = UH2_UH2_1(v121.fields[0] as any, v0_1);
            v1_1_mut = (v121.fields[1] as any);
            v2_1_mut = (v121.fields[2] as any);
            v3_mut = (v121.fields[3] as any);
            v4_mut = (v121.fields[4] as any);
            continue method69;
        }
        else {
            const v129 = v121.fields[0] as any;
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
        let v114: US7_$union;
        if (v5) {
            v114 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected end of input / chars: %A%P() / s: %A%P()", [["\\", "`", "\"", " "], [v2_1, v3, v4] as [any, int32, int32]])));
        }
        else {
            const v33: string = v1_1[0];
            if (method62(v33, 0n) === false) {
                const v47 = 1;
                const v68: int32 = (v1_1.length - 1) | 0;
                const v70: string = v1_1.slice(v47, v68 + 1);
                const v76: string = v33;
                const patternInput: [any, int32, int32] = method28(method27(toInt64(fromInt32(v76.length)), v76, 0n), v2_1, v3, v4);
                v114 = US7_US7_0(v33, v70, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v114 = US7_US7_1(toText(interpolate("parsing.none_of / unexpected char: \'%P()\' / chars: %A%P() / s: %A%P()", [v33, ["\\", "`", "\"", " "], [v2_1, v3, v4] as [any, int32, int32]])));
            }
        }
        let v134: US8_$union;
        if ((v114.tag as int32) === /* US7_0 */ 0) {
            const patternInput_1: [string, string, any, int32, int32] = method63(v114.fields[0] as any, v114.fields[1] as any, v114.fields[2] as any, v114.fields[3] as any, v114.fields[4] as any);
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
                v261 = US7_US7_1(toText(interpolate("parsing.p_char / unexpected end of input / c: \'%P()\' / s: %A%P()", ["\"", [v2_1, v3, v4] as [any, int32, int32]])));
            }
            else {
                const v146: string = v1_1[0];
                if (v146 === "\"") {
                    const v158 = 1;
                    const v179: int32 = (v1_1.length - 1) | 0;
                    const v181: string = v1_1.slice(v158, v179 + 1);
                    const v187: string = v146;
                    const patternInput_2: [any, int32, int32] = method28(method27(toInt64(fromInt32(v187.length)), v187, 0n), v2_1, v3, v4);
                    v261 = US7_US7_0(v146, v181, patternInput_2[0], patternInput_2[1], patternInput_2[2]);
                }
                else {
                    const v202: int32 = (v1_1.indexOf("\n") - 1) | 0;
                    const v217 = 0;
                    const v238: int32 = (((-2 === v202) ? (v1_1.length + 1) : (v202 + 1)) - 1) | 0;
                    v261 = US7_US7_1(concat(`parsing.p_char / expected: '${"\""}' / line: ${v3} / col: ${v4}
${v2_1}${v1_1.slice(v217, v238 + 1)}`, "\n", method29(v4 - 1, 0)("") + "^", ..."\n"));
                }
            }
            let v451: US8_$union;
            if ((v261.tag as int32) === /* US7_0 */ 0) {
                const v266: int32 = (v261.fields[4] as any) | 0;
                const v265: int32 = (v261.fields[3] as any) | 0;
                const v264 = v261.fields[2] as any;
                const v263 = v261.fields[1] as any;
                const v262 = v261.fields[0] as any;
                const v268: US17_$union = method64(UH2_UH2_0(), v263, v264, v265, v266);
                let v301: US8_$union;
                if ((v268.tag as int32) === /* US17_0 */ 0) {
                    const v273: int32 = (v268.fields[4] as any) | 0;
                    const v272: int32 = (v268.fields[3] as any) | 0;
                    const v271 = v268.fields[2] as any;
                    const v270 = v268.fields[1] as any;
                    const v275: FSharpList<string> = method68(v268.fields[0] as any, empty<string>());
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
                            const patternInput_3: [any, int32, int32] = method28(method27(toInt64(fromInt32(v354.length)), v354, 0n), v304, v305, v306);
                            v428 = US7_US7_0(v313, v348, patternInput_3[0], patternInput_3[1], patternInput_3[2]);
                        }
                        else {
                            const v369: int32 = (v303.indexOf("\n") - 1) | 0;
                            const v384 = 0;
                            const v405: int32 = (((-2 === v369) ? (v303.length + 1) : (v369 + 1)) - 1) | 0;
                            v428 = US7_US7_1(concat(`parsing.p_char / expected: '${"\""}' / line: ${v305} / col: ${v306}
${v304}${v303.slice(v384, v405 + 1)}`, "\n", method29(v306 - 1, 0)("") + "^", ..."\n"));
                        }
                    }
                    if ((v428.tag as int32) === /* US7_0 */ 0) {
                        const v429 = v428.fields[0] as any;
                        v451 = US8_US8_0(v302, v428.fields[1] as any, v428.fields[2] as any, v428.fields[3] as any, v428.fields[4] as any);
                    }
                    else {
                        v451 = US8_US8_1(toText(interpolate("parsing.between / expected closing delimiter / e: %A%P() / input: %A%P() / rest1: %A%P() / rest2: %A%P()", [v428.fields[0] as any, [v1_1, v2_1, v3, v4] as [string, any, int32, int32], [v263, v264, v265, v266] as [string, any, int32, int32], [v303, v304, v305, v306] as [string, any, int32, int32]])));
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
                const v463: US8_$union = method66(v1_1, v2_1, v3, v4, UH3_UH3_1((arg10$0040: [string, any, int32, int32]): US8_$union => closure28(undefined, arg10$0040), UH3_UH3_1((arg10$0040_1: [string, any, int32, int32]): US8_$union => closure29(undefined, arg10$0040_1), UH3_UH3_0())));
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
                    v485 = method69(UH2_UH2_0(), v474.fields[1] as any, v474.fields[2] as any, v474.fields[3] as any, v474.fields[4] as any);
                }
                else {
                    v485 = US17_US17_1(v474.fields[0] as any);
                }
                if ((v485.tag as int32) === /* US17_0 */ 0) {
                    const v490: int32 = (v485.fields[4] as any) | 0;
                    const v489: int32 = (v485.fields[3] as any) | 0;
                    const v488 = v485.fields[2] as any;
                    const v487 = v485.fields[1] as any;
                    const v492: FSharpList<string> = method68(v485.fields[0] as any, empty<string>());
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
            const v529: int32 = method36(v524, 0) | 0;
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
                v0_1_mut = UH2_UH2_1(v523, v0_1);
                v1_1_mut = (v571.fields[0] as any);
                v2_1_mut = (v571.fields[1] as any);
                v3_mut = (v571.fields[2] as any);
                v4_mut = (v571.fields[3] as any);
                continue method61;
            }
            else {
                const v578 = v571.fields[0] as any;
                return US17_US17_0(method67(v0_1, UH2_UH2_1(v523, UH2_UH2_0())), v524, v525, v526, v527);
            }
        }
        else {
            const v585 = v522.fields[0] as any;
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

export function closure27(unitVar: void, v0_1: string): FSharpResult$2_$union<string[], string> {
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

export const v19 = (arg10$0040: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>]): Async<[int32, string]> => closure25(undefined, arg10$0040);

export function execute_with_options_async(x: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>]): Async<[int32, string]> {
    return v19(x);
}

export const v20 = (v: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>] => closure26(undefined, v);

export function execution_options(x: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>] {
    return v20(x);
}

export const v21 = (v: string): FSharpResult$2_$union<string[], string> => closure27(undefined, v);

export function split_args(x: string): FSharpResult$2_$union<string[], string> {
    return v21(x);
}


