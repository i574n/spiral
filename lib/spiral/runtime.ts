import { defaultOf, compare, int64ToString, IComparable, IEquatable, createAtom } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Util.js";
import { some, value as value_12, map, defaultArg, Option } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Option.js";
import { equals, fromInt32, toInt32, compare as compare_1, op_Addition, op_Subtraction, fromInt64, toInt64, int64 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/BigInt.js";
import { toString as toString_1, Record, Union } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Types.js";
import { array_type, tuple_type, int32_type, class_type, char_type, option_type, bool_type, lambda_type, unit_type, string_type, record_type, int64_type, union_type, TypeInfo } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Reflection.js";
import { int32 } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Int32.js";
import { singleton, Async } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/AsyncBuilder.js";
import { toString, create, now, getTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Date.js";
import { milliseconds, seconds, minutes, hours, fromTicks } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/TimeSpan.js";
import { join, concat, interpolate, toText, trimStart, trimEnd } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/String.js";
import { ofSeq, find } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Map.js";
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
    return union_type("Runtime.US6", [], US6, () => [[["f0_0", Mut0_$reflection()], ["f0_1", Mut1_$reflection()], ["f0_2", Mut2_$reflection()], ["f0_3", Mut3_$reflection()], ["f0_4", Mut4_$reflection()], ["f0_5", option_type(int64_type)]], []]);
}

export type US7_$union = 
    | US7<0>
    | US7<1>

export type US7_$cases = {
    0: ["US7_0", [string, US5_$union]],
    1: ["US7_1", [string]]
}

export function US7_US7_0(f0_0: string, f0_1: US5_$union) {
    return new US7<0>(0, [f0_0, f0_1]);
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
    return union_type("Runtime.US7", [], US7, () => [[["f0_0", string_type], ["f0_1", US5_$reflection()]], [["f1_0", string_type]]]);
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
    return union_type("Runtime.US8", [], US8, () => [[["f0_0", char_type], ["f0_1", string_type], ["f0_2", class_type("System.Text.StringBuilder")], ["f0_3", int32_type], ["f0_4", int32_type]], [["f1_0", string_type]]]);
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
    1: ["UH1_1", [((arg0: [string, any, int32, int32]) => US8_$union), UH1_$union]]
}

export function UH1_UH1_0() {
    return new UH1<0>(0, []);
}

export function UH1_UH1_1(Item1: ((arg0: [string, any, int32, int32]) => US8_$union), Item2: UH1_$union) {
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
    return union_type("Runtime.UH1", [], UH1, () => [[], [["Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US8_$reflection())], ["Item2", UH1_$reflection()]]]);
}

export type US9_$union = 
    | US9<0>
    | US9<1>

export type US9_$cases = {
    0: ["US9_0", [string, string, any, int32, int32]],
    1: ["US9_1", [string]]
}

export function US9_US9_0(f0_0: string, f0_1: string, f0_2: any, f0_3: int32, f0_4: int32) {
    return new US9<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4]);
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
    return union_type("Runtime.US9", [], US9, () => [[["f0_0", string_type], ["f0_1", string_type], ["f0_2", class_type("System.Text.StringBuilder")], ["f0_3", int32_type], ["f0_4", int32_type]], [["f1_0", string_type]]]);
}

export type US10_$union = 
    | US10<0>
    | US10<1>

export type US10_$cases = {
    0: ["US10_0", [string]],
    1: ["US10_1", []]
}

export function US10_US10_0(f0_0: string) {
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
    return union_type("Runtime.US10", [], US10, () => [[["f0_0", char_type]], []]);
}

export type US11_$union = 
    | US11<0>
    | US11<1>

export type US11_$cases = {
    0: ["US11_0", [string, any, int32, int32]],
    1: ["US11_1", [string]]
}

export function US11_US11_0(f0_0: string, f0_1: any, f0_2: int32, f0_3: int32) {
    return new US11<0>(0, [f0_0, f0_1, f0_2, f0_3]);
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
    return union_type("Runtime.US11", [], US11, () => [[["f0_0", string_type], ["f0_1", class_type("System.Text.StringBuilder")], ["f0_2", int32_type], ["f0_3", int32_type]], [["f1_0", string_type]]]);
}

export type US12_$union = 
    | US12<0>
    | US12<1>

export type US12_$cases = {
    0: ["US12_0", [string, US5_$union, string, any, int32, int32]],
    1: ["US12_1", [string]]
}

export function US12_US12_0(f0_0: string, f0_1: US5_$union, f0_2: string, f0_3: any, f0_4: int32, f0_5: int32) {
    return new US12<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4, f0_5]);
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
    return union_type("Runtime.US12", [], US12, () => [[["f0_0", string_type], ["f0_1", US5_$reflection()], ["f0_2", string_type], ["f0_3", class_type("System.Text.StringBuilder")], ["f0_4", int32_type], ["f0_5", int32_type]], [["f1_0", string_type]]]);
}

export type US13_$union = 
    | US13<0>
    | US13<1>

export type US13_$cases = {
    0: ["US13_0", [US10_$union, string, any, int32, int32]],
    1: ["US13_1", [string]]
}

export function US13_US13_0(f0_0: US10_$union, f0_1: string, f0_2: any, f0_3: int32, f0_4: int32) {
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
    return union_type("Runtime.US13", [], US13, () => [[["f0_0", US10_$reflection()], ["f0_1", string_type], ["f0_2", class_type("System.Text.StringBuilder")], ["f0_3", int32_type], ["f0_4", int32_type]], [["f1_0", string_type]]]);
}

export type US14_$union = 
    | US14<0>
    | US14<1>

export type US14_$cases = {
    0: ["US14_0", [US5_$union, string, any, int32, int32]],
    1: ["US14_1", [string]]
}

export function US14_US14_0(f0_0: US5_$union, f0_1: string, f0_2: any, f0_3: int32, f0_4: int32) {
    return new US14<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4]);
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
    return union_type("Runtime.US14", [], US14, () => [[["f0_0", US5_$reflection()], ["f0_1", string_type], ["f0_2", class_type("System.Text.StringBuilder")], ["f0_3", int32_type], ["f0_4", int32_type]], [["f1_0", string_type]]]);
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

export type US15_$union = 
    | US15<0>
    | US15<1>

export type US15_$cases = {
    0: ["US15_0", [((arg0: [int32, string, boolean]) => Async<void>)]],
    1: ["US15_1", []]
}

export function US15_US15_0(f0_0: ((arg0: [int32, string, boolean]) => Async<void>)) {
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
    return union_type("Runtime.US15", [], US15, () => [[["f0_0", lambda_type(tuple_type(int32_type, string_type, bool_type), class_type("Microsoft.FSharp.Control.FSharpAsync`1", [unit_type]))]], []]);
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
    return union_type("Runtime.US16", [], US16, () => [[["f0_0", class_type("System.Threading.CancellationToken")]], []]);
}

export class Heap0 extends Record {
    readonly l0: string;
    readonly l1: Option<any>;
    readonly l2: [string, string][];
    readonly l3: Option<((arg0: [int32, string, boolean]) => Async<void>)>;
    readonly l4: Option<((arg0: any) => void)>;
    readonly l5: boolean;
    readonly l6: Option<string>;
    readonly l7: boolean;
    constructor(l0: string, l1: Option<any>, l2: [string, string][], l3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, l4: Option<((arg0: any) => void)>, l5: boolean, l6: Option<string>, l7: boolean) {
        super();
        this.l0 = l0;
        this.l1 = l1;
        this.l2 = l2;
        this.l3 = l3;
        this.l4 = l4;
        this.l5 = l5;
        this.l6 = l6;
        this.l7 = l7;
    }
}

export function Heap0_$reflection(): TypeInfo {
    return record_type("Runtime.Heap0", [], Heap0, () => [["l0", string_type], ["l1", option_type(class_type("System.Threading.CancellationToken"))], ["l2", array_type(tuple_type(string_type, string_type))], ["l3", option_type(lambda_type(tuple_type(int32_type, string_type, bool_type), class_type("Microsoft.FSharp.Control.FSharpAsync`1", [unit_type])))], ["l4", option_type(lambda_type(string_type, unit_type))], ["l5", bool_type], ["l6", option_type(string_type)], ["l7", bool_type]]);
}

export type US17_$union = 
    | US17<0>
    | US17<1>

export type US17_$cases = {
    0: ["US17_0", [string[]]],
    1: ["US17_1", [string]]
}

export function US17_US17_0(f0_0: string[]) {
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
    return union_type("Runtime.US17", [], US17, () => [[["f0_0", array_type(string_type)]], [["f1_0", string_type]]]);
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

export type US18_$union = 
    | US18<0>
    | US18<1>

export type US18_$cases = {
    0: ["US18_0", [UH2_$union, string, any, int32, int32]],
    1: ["US18_1", [string]]
}

export function US18_US18_0(f0_0: UH2_$union, f0_1: string, f0_2: any, f0_3: int32, f0_4: int32) {
    return new US18<0>(0, [f0_0, f0_1, f0_2, f0_3, f0_4]);
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
    return union_type("Runtime.US18", [], US18, () => [[["f0_0", UH2_$reflection()], ["f0_1", string_type], ["f0_2", class_type("System.Text.StringBuilder")], ["f0_3", int32_type], ["f0_4", int32_type]], [["f1_0", string_type]]]);
}

export type UH3_$union = 
    | UH3<0>
    | UH3<1>

export type UH3_$cases = {
    0: ["UH3_0", []],
    1: ["UH3_1", [((arg0: [string, any, int32, int32]) => US9_$union), UH3_$union]]
}

export function UH3_UH3_0() {
    return new UH3<0>(0, []);
}

export function UH3_UH3_1(Item1: ((arg0: [string, any, int32, int32]) => US9_$union), Item2: UH3_$union) {
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
    return union_type("Runtime.UH3", [], UH3, () => [[], [["Item1", lambda_type(tuple_type(string_type, class_type("System.Text.StringBuilder"), int32_type, int32_type), US9_$reflection())], ["Item2", UH3_$reflection()]]]);
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

export function method8(): ((arg0: int64) => US2_$union) {
    return (v: int64): US2_$union => closure6(undefined, v);
}

export function method9(): string {
    return "hh:mm:ss";
}

export function method10(): string {
    return "HH:mm:ss";
}

export function method7(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>): string {
    const v710: US2_$union = defaultArg(map<int64, US2_$union>(method8(), v5), US2_US2_1());
    let v864: Date;
    if ((v710.tag as int32) === /* US2_0 */ 0) {
        const v714 = v710.fields[0] as any;
        const v793: number = fromTicks(toInt64(op_Subtraction(toInt64(fromInt64(getTicks(now()))), v714)));
        v864 = create(1, 1, 1, hours(v793), minutes(v793), seconds(v793), milliseconds(v793));
    }
    else {
        v864 = now();
    }
    const v865: string = method10();
    return toString(v864, (v865 === "") ? "M-d-y hh:mm:ss tt" : v865);
}

export function method13(): string {
    return "";
}

export function closure7(v0: Mut3, v1: string, unitVar: void): void {
    const v4: string = v0.l0 + v1;
    v0.l0 = v4;
}

export function method12(v0: string): string {
    const v2: Mut3 = new Mut3(method13());
    let v17: any;
    closure7(v2, `${v0}`, undefined);
    v17 = undefined;
    return v2.l0;
}

export function method11(): string {
    const v133: string = "Warning".toLocaleLowerCase();
    return ("\u001b[93m" + method12(v133[0])) + "\u001b[0m";
}

export function method15(): string {
    const v1: Mut3 = new Mut3(method13());
    return v1.l0;
}

export function method16(v0: string): string {
    return trimEnd(trimStart(v0, ...[]), ...[" ", "/"]);
}

export function method14(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v8: string = method15();
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 3") + " / ") + v8);
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

export function closure5(unitVar: void, unitVar_1: void): void {
    const v15_1 = (): void => {
        closure0(undefined, undefined);
    };
    let v16_1: any;
    v15_1();
    v16_1 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    const v57: US0_$union = patternInput[4].l0;
    let v297: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (3 >= find<US0_$union, int32>(v57, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v297 = US6_US6_1();
    }
    else {
        let v80: any;
        v15_1();
        v80 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v108: Option<int64> = patternInput_1[5];
        const v107: Mut4 = patternInput_1[4];
        const v106: Mut3 = patternInput_1[3];
        const v105: Mut2 = patternInput_1[2];
        const v104: Mut1 = patternInput_1[1];
        const v103: Mut0 = patternInput_1[0];
        const v123: string = method14(v103, v104, v105, v106, v107, v108, method7(v103, v104, v105, v106, v107, v108), method11());
        let v139: any;
        v15_1();
        v139 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v163: Mut1 = patternInput_2[1];
        const v162: Mut0 = patternInput_2[0];
        let v184: any;
        closure8(v162, undefined);
        v184 = undefined;
        closure9(undefined, v123);
        v163.l0(v123);
        v297 = US6_US6_0(v162, v163, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method17(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v8: string = method15();
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 2") + " / ") + v8);
}

export function closure11(unitVar: void, unitVar_1: void): void {
    const v15_1 = (): void => {
        closure0(undefined, undefined);
    };
    let v16_1: any;
    v15_1();
    v16_1 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    const v57: US0_$union = patternInput[4].l0;
    let v297: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (3 >= find<US0_$union, int32>(v57, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v297 = US6_US6_1();
    }
    else {
        let v80: any;
        v15_1();
        v80 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v108: Option<int64> = patternInput_1[5];
        const v107: Mut4 = patternInput_1[4];
        const v106: Mut3 = patternInput_1[3];
        const v105: Mut2 = patternInput_1[2];
        const v104: Mut1 = patternInput_1[1];
        const v103: Mut0 = patternInput_1[0];
        const v123: string = method17(v103, v104, v105, v106, v107, v108, method7(v103, v104, v105, v106, v107, v108), method11());
        let v139: any;
        v15_1();
        v139 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v163: Mut1 = patternInput_2[1];
        const v162: Mut0 = patternInput_2[0];
        let v184: any;
        closure8(v162, undefined);
        v184 = undefined;
        closure9(undefined, v123);
        v163.l0(v123);
        v297 = US6_US6_0(v162, v163, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method18(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v8: string = method15();
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 1") + " / ") + v8);
}

export function closure12(unitVar: void, unitVar_1: void): void {
    const v15_1 = (): void => {
        closure0(undefined, undefined);
    };
    let v16_1: any;
    v15_1();
    v16_1 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    const v57: US0_$union = patternInput[4].l0;
    let v297: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (3 >= find<US0_$union, int32>(v57, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v297 = US6_US6_1();
    }
    else {
        let v80: any;
        v15_1();
        v80 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v108: Option<int64> = patternInput_1[5];
        const v107: Mut4 = patternInput_1[4];
        const v106: Mut3 = patternInput_1[3];
        const v105: Mut2 = patternInput_1[2];
        const v104: Mut1 = patternInput_1[1];
        const v103: Mut0 = patternInput_1[0];
        const v123: string = method18(v103, v104, v105, v106, v107, v108, method7(v103, v104, v105, v106, v107, v108), method11());
        let v139: any;
        v15_1();
        v139 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v163: Mut1 = patternInput_2[1];
        const v162: Mut0 = patternInput_2[0];
        let v184: any;
        closure8(v162, undefined);
        v184 = undefined;
        closure9(undefined, v123);
        v163.l0(v123);
        v297 = US6_US6_0(v162, v163, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function closure4(unitVar: void, unitVar_1: void): void {
}

export function method6(): void {
}

export function closure3(unitVar: void, unitVar_1: void): void {
    method6();
}

export function method23(): string {
    return "";
}

export function method24(v0: string, v1: any, v2: int32, v3: int32): string {
    const v5: Mut3 = new Mut3(method13());
    let v19: any;
    closure7(v5, "{ ", undefined);
    v19 = undefined;
    let v38: any;
    closure7(v5, "c", undefined);
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
    closure7(v5, "s", undefined);
    v115 = undefined;
    let v132: any;
    closure7(v5, " = ", undefined);
    v132 = undefined;
    let v191: any;
    closure7(v5, toText(interpolate("%A%P()", [[v1, v2, v3] as [any, int32, int32]])), undefined);
    v191 = undefined;
    let v210: any;
    closure7(v5, " }", undefined);
    v210 = undefined;
    return v5.l0;
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
    let v12: any, v23: any;
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
            v1_mut = (v6 ? ((v12 = StringBuilder__Clear(v1), v1)) : ((v23 = StringBuilder__Append_Z721C83C5(v1, v4), v1)));
            v2_mut = patternInput[0];
            v3_mut = patternInput[1];
            continue method26;
        }
        break;
    }
}

export function method27(v0: string, v1: int32, v2: int32): string {
    const v4: Mut3 = new Mut3(method13());
    let v18: any;
    closure7(v4, "{ ", undefined);
    v18 = undefined;
    let v37: any;
    closure7(v4, "expected", undefined);
    v37 = undefined;
    let v56: any;
    closure7(v4, " = ", undefined);
    v56 = undefined;
    let v76: any;
    closure7(v4, `${v0}`, undefined);
    v76 = undefined;
    let v95: any;
    closure7(v4, "; ", undefined);
    v95 = undefined;
    let v114: any;
    closure7(v4, "line", undefined);
    v114 = undefined;
    let v131: any;
    closure7(v4, " = ", undefined);
    v131 = undefined;
    let v151: any;
    closure7(v4, `${v1}`, undefined);
    v151 = undefined;
    let v168: any;
    closure7(v4, "; ", undefined);
    v168 = undefined;
    let v187: any;
    closure7(v4, "col", undefined);
    v187 = undefined;
    let v204: any;
    closure7(v4, " = ", undefined);
    v204 = undefined;
    let v224: any;
    closure7(v4, `${v2}`, undefined);
    v224 = undefined;
    let v243: any;
    closure7(v4, " }", undefined);
    v243 = undefined;
    return v4.l0;
}

export function closure15(v0: int32, v1: int32, v2: string): string {
    if (v1 >= v0) {
        return v2;
    }
    else {
        return method28(v0, v1 + 1)(v2 + " ");
    }
}

export function method28(v0: int32, v1: int32): ((arg0: string) => string) {
    return (v: string): string => closure15(v0, v1, v);
}

export function closure14(unitVar: void, _arg: [string, any, int32, int32]): US8_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    if ("" === v0) {
        return US8_US8_1("parsing.p_char / unexpected end of input / " + method24("\"", v1, v2, v3));
    }
    else {
        const v14_1: string = v0[0];
        if (v14_1 === "\"") {
            const v28 = 1;
            const v49: int32 = (v0.length - 1) | 0;
            const v51: string = v0.slice(v28, v49 + 1);
            const v57: string = v14_1;
            const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v57.length)), v57, 0n), v1, v2, v3);
            return US8_US8_0(v14_1, v51, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v74: int32 = (v0.indexOf("\n") - 1) | 0;
            const v91 = 0;
            const v112: int32 = (((-2 === v74) ? (v0.length + 1) : (v74 + 1)) - 1) | 0;
            const v114: string = v0.slice(v91, v112 + 1);
            return US8_US8_1((((((("parsing.p_char / " + method27("\"", v2, v3)) + "\n") + toString_1(v1)) + v114) + "\n") + (method28(v3 - 1, 0)("") + "^")) + "\n");
        }
    }
}

export function closure16(unitVar: void, _arg: [string, any, int32, int32]): US8_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    if ("" === v0) {
        return US8_US8_1("parsing.p_char / unexpected end of input / " + method24("\'", v1, v2, v3));
    }
    else {
        const v14_1: string = v0[0];
        if (v14_1 === "\'") {
            const v28 = 1;
            const v49: int32 = (v0.length - 1) | 0;
            const v51: string = v0.slice(v28, v49 + 1);
            const v57: string = v14_1;
            const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v57.length)), v57, 0n), v1, v2, v3);
            return US8_US8_0(v14_1, v51, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v74: int32 = (v0.indexOf("\n") - 1) | 0;
            const v91 = 0;
            const v112: int32 = (((-2 === v74) ? (v0.length + 1) : (v74 + 1)) - 1) | 0;
            const v114: string = v0.slice(v91, v112 + 1);
            return US8_US8_1((((((("parsing.p_char / " + method27("\'", v2, v3)) + "\n") + toString_1(v1)) + v114) + "\n") + (method28(v3 - 1, 0)("") + "^")) + "\n");
        }
    }
}

export function method29(v0_mut: string, v1_mut: any, v2_mut: UH1_$union): US8_$union {
    method29:
    while (true) {
        const v0: string = v0_mut, v1: any = v1_mut, v2: UH1_$union = v2_mut;
        if ((v2.tag as int32) === /* UH1_0 */ 0) {
            return US8_US8_1("parsing.choice / no parsers succeeded");
        }
        else {
            const v6 = v2.fields[1] as any;
            const v7: US8_$union = (v2.fields[0] as any)([v0, v1, 1, 1] as [string, any, int32, int32]);
            if ((v7.tag as int32) === /* US8_0 */ 0) {
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
                continue method29;
            }
        }
        break;
    }
}

export function method30(v0: string[]): string {
    const v2: Mut3 = new Mut3(method13());
    let v19: any;
    closure7(v2, toText(interpolate("%A%P()", [v0])), undefined);
    v19 = undefined;
    return v2.l0;
}

export function method31(v0: string, v1: any, v2: int32, v3: int32): string {
    const v5: Mut3 = new Mut3(method13());
    let v19: any;
    closure7(v5, "{ ", undefined);
    v19 = undefined;
    let v38: any;
    closure7(v5, "chars", undefined);
    v38 = undefined;
    let v57: any;
    closure7(v5, " = ", undefined);
    v57 = undefined;
    let v74: any;
    closure7(v5, v0, undefined);
    v74 = undefined;
    let v93: any;
    closure7(v5, "; ", undefined);
    v93 = undefined;
    let v112: any;
    closure7(v5, "s", undefined);
    v112 = undefined;
    let v129: any;
    closure7(v5, " = ", undefined);
    v129 = undefined;
    let v188: any;
    closure7(v5, toText(interpolate("%A%P()", [[v1, v2, v3] as [any, int32, int32]])), undefined);
    v188 = undefined;
    let v207: any;
    closure7(v5, " }", undefined);
    v207 = undefined;
    return v5.l0;
}

export function method32(v0_mut: string, v1_mut: int64): boolean {
    method32:
    while (true) {
        const v0: string = v0_mut, v1: int64 = v1_mut;
        if (compare_1(v1, 2n) >= 0) {
            return false;
        }
        else {
            let v11: US10_$union;
            if (equals(v1, 0n)) {
                v11 = US10_US10_0("\"");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1, 1n));
                if (equals(v5, 0n)) {
                    v11 = US10_US10_0("\'");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    v11 = US10_US10_1();
                }
            }
            if (v0 === (((v11.tag as int32) === /* US10_0 */ 0) ? (v11.fields[0] as any) : (() => {
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

export function method33(v0: string, v1: string, v2: any, v3: int32, v4: int32): string {
    const v6: Mut3 = new Mut3(method13());
    let v20: any;
    closure7(v6, "{ ", undefined);
    v20 = undefined;
    let v39: any;
    closure7(v6, "first_char", undefined);
    v39 = undefined;
    let v58: any;
    closure7(v6, " = ", undefined);
    v58 = undefined;
    let v78: any;
    closure7(v6, `${v0}`, undefined);
    v78 = undefined;
    let v97: any;
    closure7(v6, "; ", undefined);
    v97 = undefined;
    let v116: any;
    closure7(v6, "chars", undefined);
    v116 = undefined;
    let v133: any;
    closure7(v6, " = ", undefined);
    v133 = undefined;
    let v150: any;
    closure7(v6, v1, undefined);
    v150 = undefined;
    let v167: any;
    closure7(v6, "; ", undefined);
    v167 = undefined;
    let v186: any;
    closure7(v6, "s", undefined);
    v186 = undefined;
    let v203: any;
    closure7(v6, " = ", undefined);
    v203 = undefined;
    let v262: any;
    closure7(v6, toText(interpolate("%A%P()", [[v2, v3, v4] as [any, int32, int32]])), undefined);
    v262 = undefined;
    let v281: any;
    closure7(v6, " }", undefined);
    v281 = undefined;
    return v6.l0;
}

export function method34(v0_mut: string, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method34:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v176: US8_$union;
        if ("" === v1) {
            v176 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(method30(["\"", "\'"]), v2, v3, v4));
        }
        else {
            const v63: string = v1[0];
            if (method32(v63, 0n) === false) {
                const v79 = 1;
                const v100: int32 = (v1.length - 1) | 0;
                const v102: string = v1.slice(v79, v100 + 1);
                const v108: string = v63;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v108.length)), v108, 0n), v2, v3, v4);
                v176 = US8_US8_0(v63, v102, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v176 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v63, method30(["\"", "\'"]), v2, v3, v4));
            }
        }
        let v188: US8_$union;
        if ((v176.tag as int32) === /* US8_0 */ 0) {
            const v177 = v176.fields[0] as any;
            v188 = US8_US8_0(("\\" === v177) ? "/" : v177, v176.fields[1] as any, v176.fields[2] as any, v176.fields[3] as any, v176.fields[4] as any);
        }
        else {
            v188 = US8_US8_1(v176.fields[0] as any);
        }
        if ((v188.tag as int32) === /* US8_0 */ 0) {
            v0_mut = (v0 + (v188.fields[0] as any));
            v1_mut = (v188.fields[1] as any);
            v2_mut = (v188.fields[2] as any);
            v3_mut = (v188.fields[3] as any);
            v4_mut = (v188.fields[4] as any);
            continue method34;
        }
        else {
            const v208 = v188.fields[0] as any;
            return [v0, v1, v2, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method35(v0_mut: string, v1_mut: any, v2_mut: int32, v3_mut: int32, v4_mut: UH1_$union): US8_$union {
    method35:
    while (true) {
        const v0: string = v0_mut, v1: any = v1_mut, v2: int32 = v2_mut, v3: int32 = v3_mut, v4: UH1_$union = v4_mut;
        if ((v4.tag as int32) === /* UH1_0 */ 0) {
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
                continue method35;
            }
        }
        break;
    }
}

export function method36(v0: string, v1: string, v2: any, v3: int32, v4: int32, v5: string, v6: any, v7: int32, v8: int32, v9: string, v10: any, v11: int32, v12: int32): string {
    const v14_1: Mut3 = new Mut3(method13());
    let v28: any;
    closure7(v14_1, "{ ", undefined);
    v28 = undefined;
    let v47: any;
    closure7(v14_1, "e", undefined);
    v47 = undefined;
    let v66: any;
    closure7(v14_1, " = ", undefined);
    v66 = undefined;
    let v83: any;
    closure7(v14_1, v0, undefined);
    v83 = undefined;
    let v102: any;
    closure7(v14_1, "; ", undefined);
    v102 = undefined;
    let v121: any;
    closure7(v14_1, "input", undefined);
    v121 = undefined;
    let v138: any;
    closure7(v14_1, " = ", undefined);
    v138 = undefined;
    let v155: any;
    closure7(v14_1, v1, undefined);
    v155 = undefined;
    let v174: any;
    closure7(v14_1, ", ", undefined);
    v174 = undefined;
    let v233: any;
    closure7(v14_1, toText(interpolate("%A%P()", [[v2, v3, v4] as [any, int32, int32]])), undefined);
    v233 = undefined;
    let v250: any;
    closure7(v14_1, "; ", undefined);
    v250 = undefined;
    let v269: any;
    closure7(v14_1, "rest1", undefined);
    v269 = undefined;
    let v286: any;
    closure7(v14_1, " = ", undefined);
    v286 = undefined;
    let v303: any;
    closure7(v14_1, v5, undefined);
    v303 = undefined;
    let v320: any;
    closure7(v14_1, ", ", undefined);
    v320 = undefined;
    let v379: any;
    closure7(v14_1, toText(interpolate("%A%P()", [[v6, v7, v8] as [any, int32, int32]])), undefined);
    v379 = undefined;
    let v396: any;
    closure7(v14_1, "; ", undefined);
    v396 = undefined;
    let v415: any;
    closure7(v14_1, "rest2", undefined);
    v415 = undefined;
    let v432: any;
    closure7(v14_1, " = ", undefined);
    v432 = undefined;
    let v449: any;
    closure7(v14_1, v9, undefined);
    v449 = undefined;
    let v466: any;
    closure7(v14_1, ", ", undefined);
    v466 = undefined;
    let v525: any;
    closure7(v14_1, toText(interpolate("%A%P()", [[v10, v11, v12] as [any, int32, int32]])), undefined);
    v525 = undefined;
    let v544: any;
    closure7(v14_1, " }", undefined);
    v544 = undefined;
    return v14_1.l0;
}

export function method37(v0_mut: string, v1_mut: int64): boolean {
    method37:
    while (true) {
        const v0: string = v0_mut, v1: int64 = v1_mut;
        if (compare_1(v1, 3n) >= 0) {
            return false;
        }
        else {
            let v15_1: US10_$union;
            if (equals(v1, 0n)) {
                v15_1 = US10_US10_0("\"");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1, 1n));
                if (equals(v5, 0n)) {
                    v15_1 = US10_US10_0("\'");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    if (equals(v8, 0n)) {
                        v15_1 = US10_US10_0(" ");
                    }
                    else {
                        const v11: int64 = toInt64(op_Subtraction(v8, 1n));
                        v15_1 = US10_US10_1();
                    }
                }
            }
            if (v0 === (((v15_1.tag as int32) === /* US10_0 */ 0) ? (v15_1.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_mut = v0;
                v1_mut = toInt64(op_Addition(v1, 1n));
                continue method37;
            }
        }
        break;
    }
}

export function method38(v0_mut: string, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method38:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v200: US8_$union;
        if ("" === v1) {
            v200 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(method30(["\"", "\'", " "]), v2, v3, v4));
        }
        else {
            const v75: string = v1[0];
            if (method37(v75, 0n) === false) {
                const v91 = 1;
                const v112: int32 = (v1.length - 1) | 0;
                const v114: string = v1.slice(v91, v112 + 1);
                const v120: string = v75;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v120.length)), v120, 0n), v2, v3, v4);
                v200 = US8_US8_0(v75, v114, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v200 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v75, method30(["\"", "\'", " "]), v2, v3, v4));
            }
        }
        let v212: US8_$union;
        if ((v200.tag as int32) === /* US8_0 */ 0) {
            const v201 = v200.fields[0] as any;
            v212 = US8_US8_0(("\\" === v201) ? "/" : v201, v200.fields[1] as any, v200.fields[2] as any, v200.fields[3] as any, v200.fields[4] as any);
        }
        else {
            v212 = US8_US8_1(v200.fields[0] as any);
        }
        if ((v212.tag as int32) === /* US8_0 */ 0) {
            v0_mut = (v0 + (v212.fields[0] as any));
            v1_mut = (v212.fields[1] as any);
            v2_mut = (v212.fields[2] as any);
            v3_mut = (v212.fields[3] as any);
            v4_mut = (v212.fields[4] as any);
            continue method38;
        }
        else {
            const v232 = v212.fields[0] as any;
            return [v0, v1, v2, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method39(v0: string): string {
    const v2: Mut3 = new Mut3(method13());
    let v16_1: any;
    closure7(v2, "{ ", undefined);
    v16_1 = undefined;
    let v35_1: any;
    closure7(v2, "input", undefined);
    v35_1 = undefined;
    let v54: any;
    closure7(v2, " = ", undefined);
    v54 = undefined;
    let v71: any;
    closure7(v2, v0, undefined);
    v71 = undefined;
    let v90: any;
    closure7(v2, " }", undefined);
    v90 = undefined;
    return v2.l0;
}

export function method40(v0_mut: string, v1_mut: int32): int32 {
    method40:
    while (true) {
        const v0: string = v0_mut, v1: int32 = v1_mut;
        if (v1 >= v0.length) {
            return v1 | 0;
        }
        else if (" " === v0[v1]) {
            v0_mut = v0;
            v1_mut = (v1 + 1);
            continue method40;
        }
        else {
            return v1 | 0;
        }
        break;
    }
}

export function method41(v0: any, v1: int32, v2: int32): string {
    const v4: Mut3 = new Mut3(method13());
    let v18: any;
    closure7(v4, "{ ", undefined);
    v18 = undefined;
    let v37: any;
    closure7(v4, "s", undefined);
    v37 = undefined;
    let v56: any;
    closure7(v4, " = ", undefined);
    v56 = undefined;
    let v115: any;
    closure7(v4, toText(interpolate("%A%P()", [[v0, v1, v2] as [any, int32, int32]])), undefined);
    v115 = undefined;
    let v134: any;
    closure7(v4, " }", undefined);
    v134 = undefined;
    return v4.l0;
}

export function method42(v0_mut: string, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method42:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v66: US8_$union;
        if ("" === v1) {
            v66 = US8_US8_1("parsing.any_char / unexpected end of input / " + method41(v2, v3, v4));
        }
        else {
            const v14_1: string = v1[0];
            const v27 = 1;
            const v48: int32 = (v1.length - 1) | 0;
            const v50: string = v1.slice(v27, v48 + 1);
            const v56: string = v14_1;
            const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v56.length)), v56, 0n), v2, v3, v4);
            v66 = US8_US8_0(v14_1, v50, patternInput[0], patternInput[1], patternInput[2]);
        }
        if ((v66.tag as int32) === /* US8_0 */ 0) {
            v0_mut = (v0 + (v66.fields[0] as any));
            v1_mut = (v66.fields[1] as any);
            v2_mut = (v66.fields[2] as any);
            v3_mut = (v66.fields[3] as any);
            v4_mut = (v66.fields[4] as any);
            continue method42;
        }
        else {
            const v86 = v66.fields[0] as any;
            return [v0, v1, v2, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method22(v0: string): US7_$union {
    let _v0: Option<Option<string>> = undefined;
    _v0 = some(v0);
    const v10: string = defaultArg((_v0 == null) ? (() => {
        throw new Error("optionm\'.of_obj / _v0=None");
    })() : value_12(_v0), "");
    const v16_1: any = StringBuilder_$ctor_Z721C83C5(method23());
    const v19 = (arg10$0040: [string, any, int32, int32]): US8_$union => closure14(undefined, arg10$0040);
    const v20 = (arg10$0040_1: [string, any, int32, int32]): US8_$union => closure16(undefined, arg10$0040_1);
    const v24: US8_$union = method29(v10, v16_1, UH1_UH1_1(v19, UH1_UH1_1(v20, UH1_UH1_0())));
    let v280: US9_$union;
    if ((v24.tag as int32) === /* US8_0 */ 0) {
        const v29: int32 = (v24.fields[4] as any) | 0;
        const v28: int32 = (v24.fields[3] as any) | 0;
        const v27 = v24.fields[2] as any;
        const v26 = v24.fields[1] as any;
        const v25 = v24.fields[0] as any;
        let v201: US8_$union;
        if ("" === v26) {
            v201 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(method30(["\"", "\'"]), v27, v28, v29));
        }
        else {
            const v88: string = v26[0];
            if (method32(v88, 0n) === false) {
                const v104 = 1;
                const v125: int32 = (v26.length - 1) | 0;
                const v127: string = v26.slice(v104, v125 + 1);
                const v133: string = v88;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v133.length)), v133, 0n), v27, v28, v29);
                v201 = US8_US8_0(v88, v127, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v201 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v88, method30(["\"", "\'"]), v27, v28, v29));
            }
        }
        let v213: US8_$union;
        if ((v201.tag as int32) === /* US8_0 */ 0) {
            const v202 = v201.fields[0] as any;
            v213 = US8_US8_0(("\\" === v202) ? "/" : v202, v201.fields[1] as any, v201.fields[2] as any, v201.fields[3] as any, v201.fields[4] as any);
        }
        else {
            v213 = US8_US8_1(v201.fields[0] as any);
        }
        let v233: US9_$union;
        if ((v213.tag as int32) === /* US8_0 */ 0) {
            const patternInput_1: [string, string, any, int32, int32] = method34(v213.fields[0] as any, v213.fields[1] as any, v213.fields[2] as any, v213.fields[3] as any, v213.fields[4] as any);
            v233 = US9_US9_0(patternInput_1[0], patternInput_1[1], patternInput_1[2], patternInput_1[3], patternInput_1[4]);
        }
        else {
            v233 = US9_US9_1(v213.fields[0] as any);
        }
        let v243: US9_$union;
        if ((v233.tag as int32) === /* US9_0 */ 0) {
            v243 = US9_US9_0(v233.fields[0] as any, v233.fields[1] as any, v233.fields[2] as any, v233.fields[3] as any, v233.fields[4] as any);
        }
        else {
            const v240 = v233.fields[0] as any;
            v243 = US9_US9_0("", v26, v27, v28, v29);
        }
        if ((v243.tag as int32) === /* US9_0 */ 0) {
            const v248: int32 = (v243.fields[4] as any) | 0;
            const v247: int32 = (v243.fields[3] as any) | 0;
            const v246 = v243.fields[2] as any;
            const v245 = v243.fields[1] as any;
            const v244 = v243.fields[0] as any;
            const v252: US8_$union = method35(v245, v246, v247, v248, UH1_UH1_1(v19, UH1_UH1_1(v20, UH1_UH1_0())));
            if ((v252.tag as int32) === /* US8_0 */ 0) {
                const v253 = v252.fields[0] as any;
                v280 = US9_US9_0(v244, v252.fields[1] as any, v252.fields[2] as any, v252.fields[3] as any, v252.fields[4] as any);
            }
            else {
                v280 = US9_US9_1("parsing.between / expected closing delimiter / " + method36(v252.fields[0] as any, v10, v16_1, 1, 1, v26, v27, v28, v29, v245, v246, v247, v248));
            }
        }
        else {
            const v272 = v243.fields[0] as any;
            v280 = US9_US9_1("parsing.between / expected content");
        }
    }
    else {
        v280 = US9_US9_1(v24.fields[0] as any);
    }
    let v602: US9_$union;
    if ((v280.tag as int32) === /* US9_0 */ 0) {
        const v285: int32 = (v280.fields[4] as any) | 0;
        const v284: int32 = (v280.fields[3] as any) | 0;
        const v283 = v280.fields[2] as any;
        const v282 = v280.fields[1] as any;
        const v281 = v280.fields[0] as any;
        v602 = v280;
    }
    else {
        const v286 = v280.fields[0] as any;
        let v488: US8_$union;
        if ("" === v10) {
            v488 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(method30(["\"", "\'", " "]), v16_1, 1, 1));
        }
        else {
            const v359: string = v10[0];
            if (method37(v359, 0n) === false) {
                const v375 = 1;
                const v396: int32 = (v10.length - 1) | 0;
                const v398: string = v10.slice(v375, v396 + 1);
                const v404: string = v359;
                const patternInput_2: [any, int32, int32] = method26(method25(toInt64(fromInt32(v404.length)), v404, 0n), v16_1, 1, 1);
                v488 = US8_US8_0(v359, v398, patternInput_2[0], patternInput_2[1], patternInput_2[2]);
            }
            else {
                v488 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v359, method30(["\"", "\'", " "]), v16_1, 1, 1));
            }
        }
        let v500: US8_$union;
        if ((v488.tag as int32) === /* US8_0 */ 0) {
            const v489 = v488.fields[0] as any;
            v500 = US8_US8_0(("\\" === v489) ? "/" : v489, v488.fields[1] as any, v488.fields[2] as any, v488.fields[3] as any, v488.fields[4] as any);
        }
        else {
            v500 = US8_US8_1(v488.fields[0] as any);
        }
        let v520: US9_$union;
        if ((v500.tag as int32) === /* US8_0 */ 0) {
            const patternInput_3: [string, string, any, int32, int32] = method38(v500.fields[0] as any, v500.fields[1] as any, v500.fields[2] as any, v500.fields[3] as any, v500.fields[4] as any);
            v520 = US9_US9_0(patternInput_3[0], patternInput_3[1], patternInput_3[2], patternInput_3[3], patternInput_3[4]);
        }
        else {
            v520 = US9_US9_1(v500.fields[0] as any);
        }
        if ((v520.tag as int32) === /* US9_0 */ 0) {
            const v525: int32 = (v520.fields[4] as any) | 0;
            const v524: int32 = (v520.fields[3] as any) | 0;
            const v523 = v520.fields[2] as any;
            const v522 = v520.fields[1] as any;
            const v521 = v520.fields[0] as any;
            v602 = v520;
        }
        else {
            const v526 = v520.fields[0] as any;
            const v538: US11_$union = (v10.length === 0) ? US11_US11_0(v10, v16_1, 1, 1) : US11_US11_1("parsing.eof / expected end of input / " + method39(v10));
            const v547: US9_$union = ((v538.tag as int32) === /* US11_0 */ 0) ? US9_US9_0("", v538.fields[0] as any, v538.fields[1] as any, v538.fields[2] as any, v538.fields[3] as any) : US9_US9_1(v538.fields[0] as any);
            if ((v547.tag as int32) === /* US9_0 */ 0) {
                const v552: int32 = (v547.fields[4] as any) | 0;
                const v551: int32 = (v547.fields[3] as any) | 0;
                const v550 = v547.fields[2] as any;
                const v549 = v547.fields[1] as any;
                const v548 = v547.fields[0] as any;
                const v567: int32 = method40(v549, 0) | 0;
                const v588: int32 = (v549.length - 1) | 0;
                v602 = US9_US9_0(v548, v549.slice(v567, v588 + 1), v550, v551, v552);
            }
            else {
                v602 = US9_US9_1(v547.fields[0] as any);
            }
        }
    }
    let v900: US12_$union;
    if ((v602.tag as int32) === /* US9_0 */ 0) {
        const v607: int32 = (v602.fields[4] as any) | 0;
        const v606: int32 = (v602.fields[3] as any) | 0;
        const v605 = v602.fields[2] as any;
        const v604 = v602.fields[1] as any;
        const v603 = v602.fields[0] as any;
        let v771: US8_$union;
        if ("" === v604) {
            v771 = US8_US8_1("parsing.p_char / unexpected end of input / " + method24(" ", v605, v606, v607));
        }
        else {
            const v618: string = v604[0];
            if (v618 === " ") {
                const v632 = 1;
                const v653: int32 = (v604.length - 1) | 0;
                const v655: string = v604.slice(v632, v653 + 1);
                const v661: string = v618;
                const patternInput_4: [any, int32, int32] = method26(method25(toInt64(fromInt32(v661.length)), v661, 0n), v605, v606, v607);
                v771 = US8_US8_0(v618, v655, patternInput_4[0], patternInput_4[1], patternInput_4[2]);
            }
            else {
                const v678: int32 = (v604.indexOf("\n") - 1) | 0;
                const v695 = 0;
                const v716: int32 = (((-2 === v678) ? (v604.length + 1) : (v678 + 1)) - 1) | 0;
                const v718: string = v604.slice(v695, v716 + 1);
                v771 = US8_US8_1((((((("parsing.p_char / " + method27(" ", v606, v607)) + "\n") + toString_1(v605)) + v718) + "\n") + (method28(v607 - 1, 0)("") + "^")) + "\n");
            }
        }
        let v783: US13_$union;
        if ((v771.tag as int32) === /* US8_0 */ 0) {
            v783 = US13_US13_0(US10_US10_0(v771.fields[0] as any), v771.fields[1] as any, v771.fields[2] as any, v771.fields[3] as any, v771.fields[4] as any);
        }
        else {
            const v779 = v771.fields[0] as any;
            v783 = US13_US13_0(US10_US10_1(), v604, v605, v606, v607);
        }
        let v874: US9_$union;
        if ((v783.tag as int32) === /* US13_0 */ 0) {
            const v788: int32 = (v783.fields[4] as any) | 0;
            const v787: int32 = (v783.fields[3] as any) | 0;
            const v786 = v783.fields[2] as any;
            const v785 = v783.fields[1] as any;
            const v784 = v783.fields[0] as any;
            let v850: US8_$union;
            if ("" === v785) {
                v850 = US8_US8_1("parsing.any_char / unexpected end of input / " + method41(v786, v787, v788));
            }
            else {
                const v798: string = v785[0];
                const v811 = 1;
                const v832: int32 = (v785.length - 1) | 0;
                const v834: string = v785.slice(v811, v832 + 1);
                const v840: string = v798;
                const patternInput_5: [any, int32, int32] = method26(method25(toInt64(fromInt32(v840.length)), v840, 0n), v786, v787, v788);
                v850 = US8_US8_0(v798, v834, patternInput_5[0], patternInput_5[1], patternInput_5[2]);
            }
            if ((v850.tag as int32) === /* US8_0 */ 0) {
                const patternInput_6: [string, string, any, int32, int32] = method42(v850.fields[0] as any, v850.fields[1] as any, v850.fields[2] as any, v850.fields[3] as any, v850.fields[4] as any);
                v874 = US9_US9_0(patternInput_6[0], patternInput_6[1], patternInput_6[2], patternInput_6[3], patternInput_6[4]);
            }
            else {
                v874 = US9_US9_1(v850.fields[0] as any);
            }
        }
        else {
            v874 = US9_US9_1(v783.fields[0] as any);
        }
        let v886: US14_$union;
        if ((v874.tag as int32) === /* US9_0 */ 0) {
            v886 = US14_US14_0(US5_US5_0(v874.fields[0] as any), v874.fields[1] as any, v874.fields[2] as any, v874.fields[3] as any, v874.fields[4] as any);
        }
        else {
            const v882 = v874.fields[0] as any;
            v886 = US14_US14_0(US5_US5_1(), v604, v605, v606, v607);
        }
        v900 = (((v886.tag as int32) === /* US14_0 */ 0) ? US12_US12_0(v603, v886.fields[0] as any, v886.fields[1] as any, v886.fields[2] as any, v886.fields[3] as any, v886.fields[4] as any) : US12_US12_1(v886.fields[0] as any));
    }
    else {
        v900 = US12_US12_1(v602.fields[0] as any);
    }
    if ((v900.tag as int32) === /* US12_0 */ 0) {
        const v906: int32 = (v900.fields[5] as any) | 0;
        const v905: int32 = (v900.fields[4] as any) | 0;
        const v904 = v900.fields[3] as any;
        const v903 = v900.fields[2] as any;
        return US7_US7_0(v900.fields[0] as any, v900.fields[1] as any);
    }
    else {
        return US7_US7_1(v900.fields[0] as any);
    }
}

export function method43(): string {
    const v133: string = "Debug".toLocaleLowerCase();
    return ("\u001b[94m" + method12(v133[0])) + "\u001b[0m";
}

export function method45(v0: string, v1: US5_$union, v2: string, v3: Option<any>, v4: [string, string][], v5: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v6: Option<((arg0: any) => void)>, v7: boolean, v8: Option<string>, v9: boolean): string {
    const v11: Mut3 = new Mut3(method13());
    let v25: any;
    closure7(v11, "{ ", undefined);
    v25 = undefined;
    let v44: any;
    closure7(v11, "file_name", undefined);
    v44 = undefined;
    let v63: any;
    closure7(v11, " = ", undefined);
    v63 = undefined;
    let v80: any;
    closure7(v11, v0, undefined);
    v80 = undefined;
    let v99: any;
    closure7(v11, "; ", undefined);
    v99 = undefined;
    let v118: any;
    closure7(v11, "arguments", undefined);
    v118 = undefined;
    let v135: any;
    closure7(v11, " = ", undefined);
    v135 = undefined;
    let v156: any;
    closure7(v11, toText(interpolate("%A%P()", [v1])), undefined);
    v156 = undefined;
    let v173: any;
    closure7(v11, "; ", undefined);
    v173 = undefined;
    let v192: any;
    closure7(v11, "options", undefined);
    v192 = undefined;
    let v209: any;
    closure7(v11, " = ", undefined);
    v209 = undefined;
    let v226: any;
    closure7(v11, "{ ", undefined);
    v226 = undefined;
    let v245: any;
    closure7(v11, "command", undefined);
    v245 = undefined;
    let v262: any;
    closure7(v11, " = ", undefined);
    v262 = undefined;
    let v279: any;
    closure7(v11, v2, undefined);
    v279 = undefined;
    let v296: any;
    closure7(v11, "; ", undefined);
    v296 = undefined;
    let v315: any;
    closure7(v11, "cancellation_token", undefined);
    v315 = undefined;
    let v332: any;
    closure7(v11, " = ", undefined);
    v332 = undefined;
    let v391: any;
    closure7(v11, toText(interpolate("%A%P()", [v3])), undefined);
    v391 = undefined;
    let v408: any;
    closure7(v11, "; ", undefined);
    v408 = undefined;
    let v427: any;
    closure7(v11, "environment_variables", undefined);
    v427 = undefined;
    let v444: any;
    closure7(v11, " = ", undefined);
    v444 = undefined;
    let v466: any;
    closure7(v11, toText(interpolate("%A%P()", [v4])), undefined);
    v466 = undefined;
    let v483: any;
    closure7(v11, "; ", undefined);
    v483 = undefined;
    let v502: any;
    closure7(v11, "on_line", undefined);
    v502 = undefined;
    let v519: any;
    closure7(v11, " = ", undefined);
    v519 = undefined;
    let v578: any;
    closure7(v11, toText(interpolate("%A%P()", [v5])), undefined);
    v578 = undefined;
    let v595: any;
    closure7(v11, "; ", undefined);
    v595 = undefined;
    let v614: any;
    closure7(v11, "stdin", undefined);
    v614 = undefined;
    let v631: any;
    closure7(v11, " = ", undefined);
    v631 = undefined;
    let v690: any;
    closure7(v11, toText(interpolate("%A%P()", [v6])), undefined);
    v690 = undefined;
    let v707: any;
    closure7(v11, "; ", undefined);
    v707 = undefined;
    let v726: any;
    closure7(v11, "trace", undefined);
    v726 = undefined;
    let v743: any;
    closure7(v11, " = ", undefined);
    v743 = undefined;
    let v763: any;
    closure7(v11, v7 ? "true" : "false", undefined);
    v763 = undefined;
    let v780: any;
    closure7(v11, "; ", undefined);
    v780 = undefined;
    let v799: any;
    closure7(v11, "working_directory", undefined);
    v799 = undefined;
    let v816: any;
    closure7(v11, " = ", undefined);
    v816 = undefined;
    let v875: any;
    closure7(v11, toText(interpolate("%A%P()", [v8])), undefined);
    v875 = undefined;
    let v892: any;
    closure7(v11, "; ", undefined);
    v892 = undefined;
    let v911: any;
    closure7(v11, "stderr", undefined);
    v911 = undefined;
    let v928: any;
    closure7(v11, " = ", undefined);
    v928 = undefined;
    let v948: any;
    closure7(v11, v9 ? "true" : "false", undefined);
    v948 = undefined;
    let v967: any;
    closure7(v11, " }", undefined);
    v967 = undefined;
    let v984: any;
    closure7(v11, " }", undefined);
    v984 = undefined;
    return v11.l0;
}

export function method44(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: US5_$union, v10: string, v11: Option<any>, v12: [string, string][], v13: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v14_1: Option<((arg0: any) => void)>, v15_1: boolean, v16_1: Option<string>, v17: boolean): string {
    const v18: string = method45(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1, v17);
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v18);
}

export function closure17(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: US5_$union, v9: string, unitVar: void): void {
    const v25 = (): void => {
        closure0(undefined, undefined);
    };
    let v26: any;
    v25();
    v26 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    const v67: US0_$union = patternInput[4].l0;
    let v307: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (1 >= find<US0_$union, int32>(v67, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v307 = US6_US6_1();
    }
    else {
        let v90: any;
        v25();
        v90 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v118: Option<int64> = patternInput_1[5];
        const v117: Mut4 = patternInput_1[4];
        const v116: Mut3 = patternInput_1[3];
        const v115: Mut2 = patternInput_1[2];
        const v114: Mut1 = patternInput_1[1];
        const v113: Mut0 = patternInput_1[0];
        const v133: string = method44(v113, v114, v115, v116, v117, v118, method7(v113, v114, v115, v116, v117, v118), method43(), v9, v8, v0, v1, v2, v3, v4, v5, v6, v7);
        let v149: any;
        v25();
        v149 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v173: Mut1 = patternInput_2[1];
        const v172: Mut0 = patternInput_2[0];
        let v194: any;
        closure8(v172, undefined);
        v194 = undefined;
        closure9(undefined, v133);
        v173.l0(v133);
        v307 = US6_US6_0(v172, v173, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method46(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean): [string, string][] {
    return v2;
}

export function method47(v0: int32, v1: Mut5): boolean {
    return v1.l0 < v0;
}

export function method50(v0: boolean): string {
    return defaultOf();
}

export function closure19(unitVar: void, v0: ((arg0: [int32, string, boolean]) => Async<void>)): US15_$union {
    return US15_US15_0(v0);
}

export function method51(): ((arg0: ((arg0: [int32, string, boolean]) => Async<void>)) => US15_$union) {
    return (v: ((arg0: [int32, string, boolean]) => Async<void>)): US15_$union => closure19(undefined, v);
}

export function method52(v0: boolean): int32 {
    return defaultOf();
}

export function method53(): string {
    const v133: string = "Verbose".toLocaleLowerCase();
    return ("\u001b[90m" + method12(v133[0])) + "\u001b[0m";
}

export function method54(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string): string {
    const v9: string = method15();
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + v8) + " / ") + v9);
}

export function closure20(v0: string, unitVar: void): void {
    const v16_1 = (): void => {
        closure0(undefined, undefined);
    };
    let v17: any;
    v16_1();
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    const v58: US0_$union = patternInput[4].l0;
    let v301: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (0 >= find<US0_$union, int32>(v58, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v301 = US6_US6_1();
    }
    else {
        let v81: any;
        v16_1();
        v81 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v109: Option<int64> = patternInput_1[5];
        const v108: Mut4 = patternInput_1[4];
        const v107: Mut3 = patternInput_1[3];
        const v106: Mut2 = patternInput_1[2];
        const v105: Mut1 = patternInput_1[1];
        const v104: Mut0 = patternInput_1[0];
        const v127: string = (v0 === "") ? "" : method54(v104, v105, v106, v107, v108, v109, method7(v104, v105, v106, v107, v108, v109), method53(), v0);
        let v143: any;
        v16_1();
        v143 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
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

export function method49(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: boolean, v9: any, v10: boolean, v11: boolean): Async<void> {
    return singleton.Delay<void>((): Async<void> => {
        let v8991: US15_$union, v8997: Async<void>;
        const v8960: string = method50(v11);
        const v8966: boolean = (v8960 === defaultOf()) !== true;
        return singleton.Combine<void>(v8966 ? ((v8991 = defaultArg(map<((arg0: [int32, string, boolean]) => Async<void>), US15_$union>(method51(), v3), US15_US15_1()), singleton.Combine<void>(((v8991.tag as int32) === /* US15_0 */ 0) ? ((v8997 = (v8991.fields[0] as any)([method52(v8), v8960, v10] as [int32, string, boolean]), singleton.Bind<void, void>(v8997, (): Async<void> => {
            return singleton.Zero();
        }))) : (singleton.Zero()), singleton.Delay<void>((): Async<void> => {
            let v9317: any, v9638: any;
            const v9000: string = v10 ? concat("! ", ...v8960) : concat("> ", ...v8960);
            return singleton.Combine<void>(v5 ? ((v9317 = ((closure20(v9000, undefined), undefined)), singleton.Zero())) : ((v9638 = ((closure10(v9000, undefined), undefined)), singleton.Zero())), singleton.Delay<void>((): Async<void> => {
                const v9646: string = concat(v10 ? "\u001b[7;4m" : "", v8960, ...(v10 ? "\u001b[0m" : ""));
                return singleton.Zero();
            }));
        })))) : singleton.Zero(), singleton.Delay<void>((): Async<void> => {
            return singleton.Zero();
        }));
    });
}

export function method48(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: boolean, v9: any, v10: boolean, v11: boolean): Async<void> {
    return method49(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11);
}

export function closure18(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: boolean, v9: any, v10: boolean, v11: boolean): void {
    startImmediate(method48(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11));
}

export function closure21(unitVar: void, v0: any): US16_$union {
    return US16_US16_0(v0);
}

export function method55(): ((arg0: any) => US16_$union) {
    return (v: any): US16_$union => closure21(undefined, v);
}

export function method57(v0: any): Async<any> {
    return singleton.Delay<any>((): Async<any> => {
        const v612: any = defaultOf();
        return singleton.Return<any>(v612);
    });
}

export function method56(v0: any): Async<any> {
    return method57(v0);
}

export function method58(v0: boolean): boolean {
    return defaultOf();
}

export function method59(v0: boolean): void {
}

export function closure22(v0: boolean, unitVar: void): void {
    if (method58(v0) === false) {
        method59(v0);
    }
}

export function method62(v0: any): string {
    const v2: Mut3 = new Mut3(method13());
    let v16_1: any;
    closure7(v2, "{ ", undefined);
    v16_1 = undefined;
    let v35_1: any;
    closure7(v2, "ex", undefined);
    v35_1 = undefined;
    let v54: any;
    closure7(v2, " = ", undefined);
    v54 = undefined;
    let v113: any;
    closure7(v2, toText(interpolate("%A%P()", [v0])), undefined);
    v113 = undefined;
    let v132: any;
    closure7(v2, " }", undefined);
    v132 = undefined;
    return v2.l0;
}

export function method61(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: any): string {
    const v9: string = method62(v8);
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.execute_with_options_async / WaitForExitAsync") + " / ") + v9);
}

export function closure23(v0: any, unitVar: void): void {
    const v16_1 = (): void => {
        closure0(undefined, undefined);
    };
    let v17: any;
    v16_1();
    v17 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    const v58: US0_$union = patternInput[4].l0;
    let v298: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (3 >= find<US0_$union, int32>(v58, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v298 = US6_US6_1();
    }
    else {
        let v81: any;
        v16_1();
        v81 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v109: Option<int64> = patternInput_1[5];
        const v108: Mut4 = patternInput_1[4];
        const v107: Mut3 = patternInput_1[3];
        const v106: Mut2 = patternInput_1[2];
        const v105: Mut1 = patternInput_1[1];
        const v104: Mut0 = patternInput_1[0];
        const v124: string = method61(v104, v105, v106, v107, v108, v109, method7(v104, v105, v106, v107, v108, v109), method11(), v0);
        let v140: any;
        v16_1();
        v140 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
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

export function method60(v0: boolean, v1: any, v2: any): Async<int32> {
    return singleton.Delay<int32>((): Async<int32> => singleton.TryWith<int32>(singleton.Delay<int32>((): Async<int32> => {
        const v30769: Async<void> = awaitTask(defaultOf());
        return singleton.Bind<void, int32>(v30769, (): Async<int32> => {
            const v30803: int32 = 0;
            return singleton.Return<int32>(v30803);
        });
    }), (_arg_1: Error): Async<int32> => {
        const v31604: Error = _arg_1;
        const v31623: string = toText(interpolate("%A%P()", [v31604]));
        let v31963: any;
        closure23(v31604, undefined);
        v31963 = undefined;
        return singleton.Return<int32>(-2147483648);
    }));
}

export function method63(): string {
    return "\n";
}

export function method65(v0: int32, v1: int32, v2: string, v3: Option<any>, v4: [string, string][], v5: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v6: Option<((arg0: any) => void)>, v7: boolean, v8: Option<string>, v9: boolean): string {
    const v11: Mut3 = new Mut3(method13());
    let v25: any;
    closure7(v11, "{ ", undefined);
    v25 = undefined;
    let v44: any;
    closure7(v11, "exit_code", undefined);
    v44 = undefined;
    let v63: any;
    closure7(v11, " = ", undefined);
    v63 = undefined;
    let v83: any;
    closure7(v11, `${v0}`, undefined);
    v83 = undefined;
    let v102: any;
    closure7(v11, "; ", undefined);
    v102 = undefined;
    let v121: any;
    closure7(v11, "output_length", undefined);
    v121 = undefined;
    let v138: any;
    closure7(v11, " = ", undefined);
    v138 = undefined;
    let v158: any;
    closure7(v11, `${v1}`, undefined);
    v158 = undefined;
    let v175: any;
    closure7(v11, "; ", undefined);
    v175 = undefined;
    let v194: any;
    closure7(v11, "options", undefined);
    v194 = undefined;
    let v211: any;
    closure7(v11, " = ", undefined);
    v211 = undefined;
    let v228: any;
    closure7(v11, "{ ", undefined);
    v228 = undefined;
    let v247: any;
    closure7(v11, "command", undefined);
    v247 = undefined;
    let v264: any;
    closure7(v11, " = ", undefined);
    v264 = undefined;
    let v281: any;
    closure7(v11, v2, undefined);
    v281 = undefined;
    let v298: any;
    closure7(v11, "; ", undefined);
    v298 = undefined;
    let v317: any;
    closure7(v11, "cancellation_token", undefined);
    v317 = undefined;
    let v334: any;
    closure7(v11, " = ", undefined);
    v334 = undefined;
    let v393: any;
    closure7(v11, toText(interpolate("%A%P()", [v3])), undefined);
    v393 = undefined;
    let v410: any;
    closure7(v11, "; ", undefined);
    v410 = undefined;
    let v429: any;
    closure7(v11, "environment_variables", undefined);
    v429 = undefined;
    let v446: any;
    closure7(v11, " = ", undefined);
    v446 = undefined;
    let v468: any;
    closure7(v11, toText(interpolate("%A%P()", [v4])), undefined);
    v468 = undefined;
    let v485: any;
    closure7(v11, "; ", undefined);
    v485 = undefined;
    let v504: any;
    closure7(v11, "on_line", undefined);
    v504 = undefined;
    let v521: any;
    closure7(v11, " = ", undefined);
    v521 = undefined;
    let v580: any;
    closure7(v11, toText(interpolate("%A%P()", [v5])), undefined);
    v580 = undefined;
    let v597: any;
    closure7(v11, "; ", undefined);
    v597 = undefined;
    let v616: any;
    closure7(v11, "stdin", undefined);
    v616 = undefined;
    let v633: any;
    closure7(v11, " = ", undefined);
    v633 = undefined;
    let v692: any;
    closure7(v11, toText(interpolate("%A%P()", [v6])), undefined);
    v692 = undefined;
    let v709: any;
    closure7(v11, "; ", undefined);
    v709 = undefined;
    let v728: any;
    closure7(v11, "trace", undefined);
    v728 = undefined;
    let v745: any;
    closure7(v11, " = ", undefined);
    v745 = undefined;
    let v765: any;
    closure7(v11, v7 ? "true" : "false", undefined);
    v765 = undefined;
    let v782: any;
    closure7(v11, "; ", undefined);
    v782 = undefined;
    let v801: any;
    closure7(v11, "working_directory", undefined);
    v801 = undefined;
    let v818: any;
    closure7(v11, " = ", undefined);
    v818 = undefined;
    let v877: any;
    closure7(v11, toText(interpolate("%A%P()", [v8])), undefined);
    v877 = undefined;
    let v894: any;
    closure7(v11, "; ", undefined);
    v894 = undefined;
    let v913: any;
    closure7(v11, "stderr", undefined);
    v913 = undefined;
    let v930: any;
    closure7(v11, " = ", undefined);
    v930 = undefined;
    let v950: any;
    closure7(v11, v9 ? "true" : "false", undefined);
    v950 = undefined;
    let v969: any;
    closure7(v11, " }", undefined);
    v969 = undefined;
    let v986: any;
    closure7(v11, " }", undefined);
    v986 = undefined;
    return v11.l0;
}

export function method64(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: int32, v10: string, v11: Option<any>, v12: [string, string][], v13: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v14_1: Option<((arg0: any) => void)>, v15_1: boolean, v16_1: Option<string>, v17: boolean): string {
    const v18: string = method65(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1, v17);
    return method16((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v18);
}

export function closure24(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: int32, v9: string, unitVar: void): void {
    const v25 = (): void => {
        closure0(undefined, undefined);
    };
    let v26: any;
    v25();
    v26 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    const v67: US0_$union = patternInput[4].l0;
    let v308: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (1 >= find<US0_$union, int32>(v67, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v308 = US6_US6_1();
    }
    else {
        let v90: any;
        v25();
        v90 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v118: Option<int64> = patternInput_1[5];
        const v117: Mut4 = patternInput_1[4];
        const v116: Mut3 = patternInput_1[3];
        const v115: Mut2 = patternInput_1[2];
        const v114: Mut1 = patternInput_1[1];
        const v113: Mut0 = patternInput_1[0];
        const v134: string = method64(v113, v114, v115, v116, v117, v118, method7(v113, v114, v115, v116, v117, v118), method43(), v8, v9.length, v0, v1, v2, v3, v4, v5, v6, v7);
        let v150: any;
        v25();
        v150 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v174: Mut1 = patternInput_2[1];
        const v173: Mut0 = patternInput_2[0];
        let v195: any;
        closure8(v173, undefined);
        v195 = undefined;
        closure9(undefined, v134);
        v174.l0(v134);
        v308 = US6_US6_0(v173, v174, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method21(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean): Async<[int32, string]> {
    return singleton.Delay<[int32, string]>((): Async<[int32, string]> => {
        const patternInput: [int32, string] = defaultOf();
        return singleton.Return<[int32, string]>([patternInput[0], patternInput[1]] as [int32, string]);
    });
}

export function method20(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean): Async<[int32, string]> {
    return method21(v0, v1, v2, v3, v4, v5, v6, v7);
}

export function method19(v0: string): Async<[int32, string]> {
    return method20(v0, undefined, [], undefined, undefined, true, undefined, true);
}

export function closure13(unitVar: void, v0: string): Async<[int32, string]> {
    return method19(v0);
}

export function closure25(unitVar: void, _arg: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>, boolean]): Async<[int32, string]> {
    return method20(_arg[0], _arg[1], _arg[2], _arg[3], _arg[4], _arg[5], _arg[6], _arg[7]);
}

export function closure26(unitVar: void, v0: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>, boolean] {
    const v20: Heap0 = v0(new Heap0("", undefined, [], undefined, undefined, true, undefined, true));
    return [v20.l0, v20.l1, v20.l2, v20.l3, v20.l4, v20.l5, v20.l6, v20.l7] as [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>, boolean];
}

export function method68(v0_mut: string, v1_mut: int64): boolean {
    method68:
    while (true) {
        const v0: string = v0_mut, v1: int64 = v1_mut;
        if (compare_1(v1, 4n) >= 0) {
            return false;
        }
        else {
            let v19: US10_$union;
            if (equals(v1, 0n)) {
                v19 = US10_US10_0("\\");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1, 1n));
                if (equals(v5, 0n)) {
                    v19 = US10_US10_0("`");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    if (equals(v8, 0n)) {
                        v19 = US10_US10_0("\"");
                    }
                    else {
                        const v11: int64 = toInt64(op_Subtraction(v8, 1n));
                        if (equals(v11, 0n)) {
                            v19 = US10_US10_0(" ");
                        }
                        else {
                            const v14_1: int64 = toInt64(op_Subtraction(v11, 1n));
                            v19 = US10_US10_1();
                        }
                    }
                }
            }
            if (v0 === (((v19.tag as int32) === /* US10_0 */ 0) ? (v19.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_mut = v0;
                v1_mut = toInt64(op_Addition(v1, 1n));
                continue method68;
            }
        }
        break;
    }
}

export function method69(v0_mut: string, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method69:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v224: US8_$union;
        if ("" === v1) {
            v224 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(method30(["\\", "`", "\"", " "]), v2, v3, v4));
        }
        else {
            const v87: string = v1[0];
            if (method68(v87, 0n) === false) {
                const v103 = 1;
                const v124: int32 = (v1.length - 1) | 0;
                const v126: string = v1.slice(v103, v124 + 1);
                const v132: string = v87;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v132.length)), v132, 0n), v2, v3, v4);
                v224 = US8_US8_0(v87, v126, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v224 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v87, method30(["\\", "`", "\"", " "]), v2, v3, v4));
            }
        }
        if ((v224.tag as int32) === /* US8_0 */ 0) {
            v0_mut = (v0 + (v224.fields[0] as any));
            v1_mut = (v224.fields[1] as any);
            v2_mut = (v224.fields[2] as any);
            v3_mut = (v224.fields[3] as any);
            v4_mut = (v224.fields[4] as any);
            continue method69;
        }
        else {
            const v244 = v224.fields[0] as any;
            return [v0, v1, v2, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method71(v0_mut: string, v1_mut: int64): boolean {
    method71:
    while (true) {
        const v0: string = v0_mut, v1: int64 = v1_mut;
        if (compare_1(v1, 3n) >= 0) {
            return false;
        }
        else {
            let v15_1: US10_$union;
            if (equals(v1, 0n)) {
                v15_1 = US10_US10_0("\\");
            }
            else {
                const v5: int64 = toInt64(op_Subtraction(v1, 1n));
                if (equals(v5, 0n)) {
                    v15_1 = US10_US10_0("`");
                }
                else {
                    const v8: int64 = toInt64(op_Subtraction(v5, 1n));
                    if (equals(v8, 0n)) {
                        v15_1 = US10_US10_0("\"");
                    }
                    else {
                        const v11: int64 = toInt64(op_Subtraction(v8, 1n));
                        v15_1 = US10_US10_1();
                    }
                }
            }
            if (v0 === (((v15_1.tag as int32) === /* US10_0 */ 0) ? (v15_1.fields[0] as any) : (() => {
                throw new Error("Option does not have a value.");
            })())) {
                return true;
            }
            else {
                v0_mut = v0;
                v1_mut = toInt64(op_Addition(v1, 1n));
                continue method71;
            }
        }
        break;
    }
}

export function closure28(unitVar: void, _arg: [string, any, int32, int32]): US9_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    let v168: US8_$union;
    if ("" === v0) {
        v168 = US8_US8_1("parsing.p_char / unexpected end of input / " + method24("\\", v1, v2, v3));
    }
    else {
        const v14_1: string = v0[0];
        if (v14_1 === "\\") {
            const v28 = 1;
            const v49: int32 = (v0.length - 1) | 0;
            const v51: string = v0.slice(v28, v49 + 1);
            const v57: string = v14_1;
            const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v57.length)), v57, 0n), v1, v2, v3);
            v168 = US8_US8_0(v14_1, v51, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v74: int32 = (v0.indexOf("\n") - 1) | 0;
            const v91 = 0;
            const v112: int32 = (((-2 === v74) ? (v0.length + 1) : (v74 + 1)) - 1) | 0;
            const v114: string = v0.slice(v91, v112 + 1);
            v168 = US8_US8_1((((((("parsing.p_char / " + method27("\\", v2, v3)) + "\n") + toString_1(v1)) + v114) + "\n") + (method28(v3 - 1, 0)("") + "^")) + "\n");
        }
    }
    let v239: US8_$union;
    if ((v168.tag as int32) === /* US8_0 */ 0) {
        const v173: int32 = (v168.fields[4] as any) | 0;
        const v172: int32 = (v168.fields[3] as any) | 0;
        const v171 = v168.fields[2] as any;
        const v170 = v168.fields[1] as any;
        const v169 = v168.fields[0] as any;
        if ("" === v170) {
            v239 = US8_US8_1("parsing.any_char / unexpected end of input / " + method41(v171, v172, v173));
        }
        else {
            const v183: string = v170[0];
            const v196 = 1;
            const v217: int32 = (v170.length - 1) | 0;
            const v219: string = v170.slice(v196, v217 + 1);
            const v225: string = v183;
            const patternInput_1: [any, int32, int32] = method26(method25(toInt64(fromInt32(v225.length)), v225, 0n), v171, v172, v173);
            v239 = US8_US8_0(v183, v219, patternInput_1[0], patternInput_1[1], patternInput_1[2]);
        }
    }
    else {
        v239 = US8_US8_1(v168.fields[0] as any);
    }
    if ((v239.tag as int32) === /* US8_0 */ 0) {
        return US9_US9_0("\\" + (v239.fields[0] as any), v239.fields[1] as any, v239.fields[2] as any, v239.fields[3] as any, v239.fields[4] as any);
    }
    else {
        return US9_US9_1(v239.fields[0] as any);
    }
}

export function closure29(unitVar: void, _arg: [string, any, int32, int32]): US9_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    let v168: US8_$union;
    if ("" === v0) {
        v168 = US8_US8_1("parsing.p_char / unexpected end of input / " + method24("`", v1, v2, v3));
    }
    else {
        const v14_1: string = v0[0];
        if (v14_1 === "`") {
            const v28 = 1;
            const v49: int32 = (v0.length - 1) | 0;
            const v51: string = v0.slice(v28, v49 + 1);
            const v57: string = v14_1;
            const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v57.length)), v57, 0n), v1, v2, v3);
            v168 = US8_US8_0(v14_1, v51, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v74: int32 = (v0.indexOf("\n") - 1) | 0;
            const v91 = 0;
            const v112: int32 = (((-2 === v74) ? (v0.length + 1) : (v74 + 1)) - 1) | 0;
            const v114: string = v0.slice(v91, v112 + 1);
            v168 = US8_US8_1((((((("parsing.p_char / " + method27("`", v2, v3)) + "\n") + toString_1(v1)) + v114) + "\n") + (method28(v3 - 1, 0)("") + "^")) + "\n");
        }
    }
    let v239: US8_$union;
    if ((v168.tag as int32) === /* US8_0 */ 0) {
        const v173: int32 = (v168.fields[4] as any) | 0;
        const v172: int32 = (v168.fields[3] as any) | 0;
        const v171 = v168.fields[2] as any;
        const v170 = v168.fields[1] as any;
        const v169 = v168.fields[0] as any;
        if ("" === v170) {
            v239 = US8_US8_1("parsing.any_char / unexpected end of input / " + method41(v171, v172, v173));
        }
        else {
            const v183: string = v170[0];
            const v196 = 1;
            const v217: int32 = (v170.length - 1) | 0;
            const v219: string = v170.slice(v196, v217 + 1);
            const v225: string = v183;
            const patternInput_1: [any, int32, int32] = method26(method25(toInt64(fromInt32(v225.length)), v225, 0n), v171, v172, v173);
            v239 = US8_US8_0(v183, v219, patternInput_1[0], patternInput_1[1], patternInput_1[2]);
        }
    }
    else {
        v239 = US8_US8_1(v168.fields[0] as any);
    }
    if ((v239.tag as int32) === /* US8_0 */ 0) {
        return US9_US9_0("`" + (v239.fields[0] as any), v239.fields[1] as any, v239.fields[2] as any, v239.fields[3] as any, v239.fields[4] as any);
    }
    else {
        return US9_US9_1(v239.fields[0] as any);
    }
}

export function method72(v0_mut: string, v1_mut: any, v2_mut: int32, v3_mut: int32, v4_mut: UH3_$union): US9_$union {
    method72:
    while (true) {
        const v0: string = v0_mut, v1: any = v1_mut, v2: int32 = v2_mut, v3: int32 = v3_mut, v4: UH3_$union = v4_mut;
        if ((v4.tag as int32) === /* UH3_0 */ 0) {
            return US9_US9_1("parsing.choice / no parsers succeeded");
        }
        else {
            const v8 = v4.fields[1] as any;
            const v9: US9_$union = (v4.fields[0] as any)([v0, v1, v2, v3] as [string, any, int32, int32]);
            if ((v9.tag as int32) === /* US9_0 */ 0) {
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
                continue method72;
            }
        }
        break;
    }
}

export function method73(v0_mut: UH2_$union, v1_mut: UH2_$union): UH2_$union {
    method73:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: UH2_$union = v1_mut;
        if ((v0.tag as int32) === /* UH2_0 */ 0) {
            return v1;
        }
        else {
            v0_mut = (v0.fields[1] as any);
            v1_mut = UH2_UH2_1(v0.fields[0] as any, v1);
            continue method73;
        }
        break;
    }
}

export function method70(v0_mut: UH2_$union, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): US18_$union {
    method70:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v200: US8_$union;
        if ("" === v1) {
            v200 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(method30(["\\", "`", "\""]), v2, v3, v4));
        }
        else {
            const v75: string = v1[0];
            if (method71(v75, 0n) === false) {
                const v91 = 1;
                const v112: int32 = (v1.length - 1) | 0;
                const v114: string = v1.slice(v91, v112 + 1);
                const v120: string = v75;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v120.length)), v120, 0n), v2, v3, v4);
                v200 = US8_US8_0(v75, v114, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v200 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v75, method30(["\\", "`", "\""]), v2, v3, v4));
            }
        }
        const v215: US9_$union = ((v200.tag as int32) === /* US8_0 */ 0) ? US9_US9_0(v200.fields[0] as any, v200.fields[1] as any, v200.fields[2] as any, v200.fields[3] as any, v200.fields[4] as any) : US9_US9_1(v200.fields[0] as any);
        let v229: US9_$union;
        if ((v215.tag as int32) === /* US9_0 */ 0) {
            const v220: int32 = (v215.fields[4] as any) | 0;
            const v219: int32 = (v215.fields[3] as any) | 0;
            const v218 = v215.fields[2] as any;
            const v217 = v215.fields[1] as any;
            const v216 = v215.fields[0] as any;
            v229 = v215;
        }
        else {
            const v221 = v215.fields[0] as any;
            v229 = method72(v1, v2, v3, v4, UH3_UH3_1((arg10$0040: [string, any, int32, int32]): US9_$union => closure28(undefined, arg10$0040), UH3_UH3_1((arg10$0040_1: [string, any, int32, int32]): US9_$union => closure29(undefined, arg10$0040_1), UH3_UH3_0())));
        }
        if ((v229.tag as int32) === /* US9_0 */ 0) {
            v0_mut = UH2_UH2_1(v229.fields[0] as any, v0);
            v1_mut = (v229.fields[1] as any);
            v2_mut = (v229.fields[2] as any);
            v3_mut = (v229.fields[3] as any);
            v4_mut = (v229.fields[4] as any);
            continue method70;
        }
        else {
            const v237 = v229.fields[0] as any;
            return US18_US18_0(method73(v0, UH2_UH2_0()), v1, v2, v3, v4);
        }
        break;
    }
}

export function method74(v0: UH2_$union, v1: FSharpList<string>): FSharpList<string> {
    if ((v0.tag as int32) === /* UH2_0 */ 0) {
        return v1;
    }
    else {
        return cons(v0.fields[0] as any, method74(v0.fields[1] as any, v1));
    }
}

export function method75(v0_mut: UH2_$union, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): US18_$union {
    method75:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v200: US8_$union;
        if ("" === v1) {
            v200 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(method30(["\\", "`", "\""]), v2, v3, v4));
        }
        else {
            const v75: string = v1[0];
            if (method71(v75, 0n) === false) {
                const v91 = 1;
                const v112: int32 = (v1.length - 1) | 0;
                const v114: string = v1.slice(v91, v112 + 1);
                const v120: string = v75;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v120.length)), v120, 0n), v2, v3, v4);
                v200 = US8_US8_0(v75, v114, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v200 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v75, method30(["\\", "`", "\""]), v2, v3, v4));
            }
        }
        const v215: US9_$union = ((v200.tag as int32) === /* US8_0 */ 0) ? US9_US9_0(v200.fields[0] as any, v200.fields[1] as any, v200.fields[2] as any, v200.fields[3] as any, v200.fields[4] as any) : US9_US9_1(v200.fields[0] as any);
        if ((v215.tag as int32) === /* US9_0 */ 0) {
            v0_mut = UH2_UH2_1(v215.fields[0] as any, v0);
            v1_mut = (v215.fields[1] as any);
            v2_mut = (v215.fields[2] as any);
            v3_mut = (v215.fields[3] as any);
            v4_mut = (v215.fields[4] as any);
            continue method75;
        }
        else {
            const v223 = v215.fields[0] as any;
            return US18_US18_0(method73(v0, UH2_UH2_0()), v1, v2, v3, v4);
        }
        break;
    }
}

export function method67(v0_mut: UH2_$union, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): US18_$union {
    method67:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        const v5: boolean = "" === v1;
        let v224: US8_$union;
        if (v5) {
            v224 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(method30(["\\", "`", "\"", " "]), v2, v3, v4));
        }
        else {
            const v87: string = v1[0];
            if (method68(v87, 0n) === false) {
                const v103 = 1;
                const v124: int32 = (v1.length - 1) | 0;
                const v126: string = v1.slice(v103, v124 + 1);
                const v132: string = v87;
                const patternInput: [any, int32, int32] = method26(method25(toInt64(fromInt32(v132.length)), v132, 0n), v2, v3, v4);
                v224 = US8_US8_0(v87, v126, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v224 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v87, method30(["\\", "`", "\"", " "]), v2, v3, v4));
            }
        }
        let v244: US9_$union;
        if ((v224.tag as int32) === /* US8_0 */ 0) {
            const patternInput_1: [string, string, any, int32, int32] = method69(v224.fields[0] as any, v224.fields[1] as any, v224.fields[2] as any, v224.fields[3] as any, v224.fields[4] as any);
            v244 = US9_US9_0(patternInput_1[0], patternInput_1[1], patternInput_1[2], patternInput_1[3], patternInput_1[4]);
        }
        else {
            v244 = US9_US9_1(v224.fields[0] as any);
        }
        let v721: US9_$union;
        if ((v244.tag as int32) === /* US9_0 */ 0) {
            const v249: int32 = (v244.fields[4] as any) | 0;
            const v248: int32 = (v244.fields[3] as any) | 0;
            const v247 = v244.fields[2] as any;
            const v246 = v244.fields[1] as any;
            const v245 = v244.fields[0] as any;
            v721 = v244;
        }
        else {
            const v250 = v244.fields[0] as any;
            let v414: US8_$union;
            if (v5) {
                v414 = US8_US8_1("parsing.p_char / unexpected end of input / " + method24("\"", v2, v3, v4));
            }
            else {
                const v260: string = v1[0];
                if (v260 === "\"") {
                    const v274 = 1;
                    const v295: int32 = (v1.length - 1) | 0;
                    const v297: string = v1.slice(v274, v295 + 1);
                    const v303: string = v260;
                    const patternInput_2: [any, int32, int32] = method26(method25(toInt64(fromInt32(v303.length)), v303, 0n), v2, v3, v4);
                    v414 = US8_US8_0(v260, v297, patternInput_2[0], patternInput_2[1], patternInput_2[2]);
                }
                else {
                    const v320: int32 = (v1.indexOf("\n") - 1) | 0;
                    const v337 = 0;
                    const v358: int32 = (((-2 === v320) ? (v1.length + 1) : (v320 + 1)) - 1) | 0;
                    const v360: string = v1.slice(v337, v358 + 1);
                    v414 = US8_US8_1((((((("parsing.p_char / " + method27("\"", v3, v4)) + "\n") + toString_1(v2)) + v360) + "\n") + (method28(v4 - 1, 0)("") + "^")) + "\n");
                }
            }
            let v650: US9_$union;
            if ((v414.tag as int32) === /* US8_0 */ 0) {
                const v419: int32 = (v414.fields[4] as any) | 0;
                const v418: int32 = (v414.fields[3] as any) | 0;
                const v417 = v414.fields[2] as any;
                const v416 = v414.fields[1] as any;
                const v415 = v414.fields[0] as any;
                const v421: US18_$union = method70(UH2_UH2_0(), v416, v417, v418, v419);
                let v454: US9_$union;
                if ((v421.tag as int32) === /* US18_0 */ 0) {
                    const v426: int32 = (v421.fields[4] as any) | 0;
                    const v425: int32 = (v421.fields[3] as any) | 0;
                    const v424 = v421.fields[2] as any;
                    const v423 = v421.fields[1] as any;
                    const v428: FSharpList<string> = method74(v421.fields[0] as any, empty<string>());
                    v454 = US9_US9_0(join("", delay<string>((): Iterable<string> => v428)), v423, v424, v425, v426);
                }
                else {
                    v454 = US9_US9_1(v421.fields[0] as any);
                }
                if ((v454.tag as int32) === /* US9_0 */ 0) {
                    const v459: int32 = (v454.fields[4] as any) | 0;
                    const v458: int32 = (v454.fields[3] as any) | 0;
                    const v457 = v454.fields[2] as any;
                    const v456 = v454.fields[1] as any;
                    const v455 = v454.fields[0] as any;
                    let v624: US8_$union;
                    if ("" === v456) {
                        v624 = US8_US8_1("parsing.p_char / unexpected end of input / " + method24("\"", v457, v458, v459));
                    }
                    else {
                        const v470: string = v456[0];
                        if (v470 === "\"") {
                            const v484 = 1;
                            const v505: int32 = (v456.length - 1) | 0;
                            const v507: string = v456.slice(v484, v505 + 1);
                            const v513: string = v470;
                            const patternInput_3: [any, int32, int32] = method26(method25(toInt64(fromInt32(v513.length)), v513, 0n), v457, v458, v459);
                            v624 = US8_US8_0(v470, v507, patternInput_3[0], patternInput_3[1], patternInput_3[2]);
                        }
                        else {
                            const v530: int32 = (v456.indexOf("\n") - 1) | 0;
                            const v547 = 0;
                            const v568: int32 = (((-2 === v530) ? (v456.length + 1) : (v530 + 1)) - 1) | 0;
                            const v570: string = v456.slice(v547, v568 + 1);
                            v624 = US8_US8_1((((((("parsing.p_char / " + method27("\"", v458, v459)) + "\n") + toString_1(v457)) + v570) + "\n") + (method28(v459 - 1, 0)("") + "^")) + "\n");
                        }
                    }
                    if ((v624.tag as int32) === /* US8_0 */ 0) {
                        const v625 = v624.fields[0] as any;
                        v650 = US9_US9_0(v455, v624.fields[1] as any, v624.fields[2] as any, v624.fields[3] as any, v624.fields[4] as any);
                    }
                    else {
                        v650 = US9_US9_1("parsing.between / expected closing delimiter / " + method36(v624.fields[0] as any, v1, v2, v3, v4, v416, v417, v418, v419, v456, v457, v458, v459));
                    }
                }
                else {
                    const v642 = v454.fields[0] as any;
                    v650 = US9_US9_1("parsing.between / expected content");
                }
            }
            else {
                v650 = US9_US9_1(v414.fields[0] as any);
            }
            if ((v650.tag as int32) === /* US9_0 */ 0) {
                const v655: int32 = (v650.fields[4] as any) | 0;
                const v654: int32 = (v650.fields[3] as any) | 0;
                const v653 = v650.fields[2] as any;
                const v652 = v650.fields[1] as any;
                const v651 = v650.fields[0] as any;
                v721 = v650;
            }
            else {
                const v656 = v650.fields[0] as any;
                const v662: US9_$union = method72(v1, v2, v3, v4, UH3_UH3_1((arg10$0040: [string, any, int32, int32]): US9_$union => closure28(undefined, arg10$0040), UH3_UH3_1((arg10$0040_1: [string, any, int32, int32]): US9_$union => closure29(undefined, arg10$0040_1), UH3_UH3_0())));
                let v673: US9_$union;
                if ((v662.tag as int32) === /* US9_0 */ 0) {
                    const v663 = v662.fields[0] as any;
                    v673 = US9_US9_0("", v662.fields[1] as any, v662.fields[2] as any, v662.fields[3] as any, v662.fields[4] as any);
                }
                else {
                    v673 = US9_US9_1(v662.fields[0] as any);
                }
                let v684: US18_$union;
                if ((v673.tag as int32) === /* US9_0 */ 0) {
                    const v674 = v673.fields[0] as any;
                    v684 = method75(UH2_UH2_0(), v673.fields[1] as any, v673.fields[2] as any, v673.fields[3] as any, v673.fields[4] as any);
                }
                else {
                    v684 = US18_US18_1(v673.fields[0] as any);
                }
                if ((v684.tag as int32) === /* US18_0 */ 0) {
                    const v689: int32 = (v684.fields[4] as any) | 0;
                    const v688: int32 = (v684.fields[3] as any) | 0;
                    const v687 = v684.fields[2] as any;
                    const v686 = v684.fields[1] as any;
                    const v691: FSharpList<string> = method74(v684.fields[0] as any, empty<string>());
                    v721 = US9_US9_0(join("", delay<string>((): Iterable<string> => v691)), v686, v687, v688, v689);
                }
                else {
                    v721 = US9_US9_1(v684.fields[0] as any);
                }
            }
        }
        if ((v721.tag as int32) === /* US9_0 */ 0) {
            const v726: int32 = (v721.fields[4] as any) | 0;
            const v725: int32 = (v721.fields[3] as any) | 0;
            const v724 = v721.fields[2] as any;
            const v723 = v721.fields[1] as any;
            const v722 = v721.fields[0] as any;
            const v728: int32 = method40(v723, 0) | 0;
            let v772: US11_$union;
            if (0 === v728) {
                v772 = US11_US11_1("parsing.spaces1 / expected at least one space");
            }
            else {
                const v744: int32 = v728 | 0;
                const v765: int32 = (v723.length - 1) | 0;
                v772 = US11_US11_0(v723.slice(v744, v765 + 1), v724, v725, v726);
            }
            if ((v772.tag as int32) === /* US11_0 */ 0) {
                v0_mut = UH2_UH2_1(v722, v0);
                v1_mut = (v772.fields[0] as any);
                v2_mut = (v772.fields[1] as any);
                v3_mut = (v772.fields[2] as any);
                v4_mut = (v772.fields[3] as any);
                continue method67;
            }
            else {
                const v779 = v772.fields[0] as any;
                return US18_US18_0(method73(v0, UH2_UH2_1(v722, UH2_UH2_0())), v723, v724, v725, v726);
            }
        }
        else {
            const v786 = v721.fields[0] as any;
            return US18_US18_0(method73(v0, UH2_UH2_0()), v1, v2, v3, v4);
        }
        break;
    }
}

export function method66(v0: string): US17_$union {
    let _v0: Option<Option<string>> = undefined;
    _v0 = some(v0);
    const v22: US18_$union = method67(UH2_UH2_0(), defaultArg((_v0 == null) ? (() => {
        throw new Error("optionm\'.of_obj / _v0=None");
    })() : value_12(_v0), ""), StringBuilder_$ctor_Z721C83C5(method23()), 1, 1);
    if ((v22.tag as int32) === /* US18_0 */ 0) {
        const v27: int32 = (v22.fields[4] as any) | 0;
        const v26: int32 = (v22.fields[3] as any) | 0;
        const v25 = v22.fields[2] as any;
        const v24 = v22.fields[1] as any;
        return US17_US17_0(toArray<string>(method74(v22.fields[0] as any, empty<string>())));
    }
    else {
        return US17_US17_1(v22.fields[0] as any);
    }
}

export function closure27(unitVar: void, v0: string): FSharpResult$2_$union<string[], string> {
    const v1: US17_$union = method66(v0);
    if ((v1.tag as int32) === /* US17_0 */ 0) {
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

export const v33 = (arg10$0040: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>, boolean]): Async<[int32, string]> => closure25(undefined, arg10$0040);

export function execute_with_options_async(x: [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>, boolean]): Async<[int32, string]> {
    return v33(x);
}

export const v34 = (v: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>, boolean] => closure26(undefined, v);

export function execution_options(x: ((arg0: Heap0) => Heap0)): [string, Option<any>, [string, string][], Option<((arg0: [int32, string, boolean]) => Async<void>)>, Option<((arg0: any) => void)>, boolean, Option<string>, boolean] {
    return v34(x);
}

export const v35 = (v: string): FSharpResult$2_$union<string[], string> => closure27(undefined, v);

export function split_args(x: string): FSharpResult$2_$union<string[], string> {
    return v35(x);
}


