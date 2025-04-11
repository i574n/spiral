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
    const v641: US2_$union = defaultArg(map<int64, US2_$union>(method8(), v5), US2_US2_1());
    let v781: Date;
    if ((v641.tag as int32) === /* US2_0 */ 0) {
        const v645 = v641.fields[0] as any;
        const v724: number = fromTicks(toInt64(op_Subtraction(toInt64(fromInt64(getTicks(now()))), v645)));
        v781 = create(1, 1, 1, hours(v724), minutes(v724), seconds(v724), milliseconds(v724));
    }
    else {
        v781 = now();
    }
    const v782: string = method10();
    return toString(v781, (v782 === "") ? "M-d-y hh:mm:ss tt" : v782);
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

export function method14(): string {
    return "\u001b[0m";
}

export function method11(): string {
    const v4: string = "Warning".toLocaleLowerCase();
    return ("\u001b[93m" + method12(v4[0])) + method14();
}

export function method16(): string {
    const v1: Mut3 = new Mut3(method13());
    return v1.l0;
}

export function method17(v0: string): string {
    return trimEnd(trimStart(v0, ...[]), ...[" ", "/"]);
}

export function method15(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v8: string = method16();
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 3") + " / ") + v8);
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
        const v123: string = method15(v103, v104, v105, v106, v107, v108, method7(v103, v104, v105, v106, v107, v108), method11());
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
    const v8: string = method16();
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 2") + " / ") + v8);
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

export function method19(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string): string {
    const v8: string = method16();
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.current_process_kill / exiting... 1") + " / ") + v8);
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
        const v123: string = method19(v103, v104, v105, v106, v107, v108, method7(v103, v104, v105, v106, v107, v108), method11());
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

export function method24(): string {
    return "";
}

export function method25(v0: string, v1: any, v2: int32, v3: int32): string {
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

export function method26(v0: int64, v1: string, v2: int64): UH0_$union {
    if (compare_1(v2, v0) < 0) {
        return UH0_UH0_1(v1[~~toInt32(v2)], method26(v0, v1, toInt64(op_Addition(v2, 1n))));
    }
    else {
        return UH0_UH0_0();
    }
}

export function method27(v0_mut: UH0_$union, v1_mut: any, v2_mut: int32, v3_mut: int32): [any, int32, int32] {
    let v12: any, v23: any;
    method27:
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
            continue method27;
        }
        break;
    }
}

export function method28(v0: string, v1: int32, v2: int32): string {
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
        return method29(v0, v1 + 1)(v2 + " ");
    }
}

export function method29(v0: int32, v1: int32): ((arg0: string) => string) {
    return (v: string): string => closure15(v0, v1, v);
}

export function closure14(unitVar: void, _arg: [string, any, int32, int32]): US8_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    if ("" === v0) {
        return US8_US8_1("parsing.p_char / unexpected end of input / " + method25("\"", v1, v2, v3));
    }
    else {
        const v14_1: string = v0[0];
        if (v14_1 === "\"") {
            const v26 = 1;
            const v47: int32 = (v0.length - 1) | 0;
            const v49: string = v0.slice(v26, v47 + 1);
            const v55: string = v14_1;
            const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v55.length)), v55, 0n), v1, v2, v3);
            return US8_US8_0(v14_1, v49, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v72: int32 = (v0.indexOf("\n") - 1) | 0;
            const v87 = 0;
            const v108: int32 = (((-2 === v72) ? (v0.length + 1) : (v72 + 1)) - 1) | 0;
            const v110: string = v0.slice(v87, v108 + 1);
            return US8_US8_1((((((("parsing.p_char / " + method28("\"", v2, v3)) + "\n") + toString_1(v1)) + v110) + "\n") + (method29(v3 - 1, 0)("") + "^")) + "\n");
        }
    }
}

export function closure16(unitVar: void, _arg: [string, any, int32, int32]): US8_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    if ("" === v0) {
        return US8_US8_1("parsing.p_char / unexpected end of input / " + method25("\'", v1, v2, v3));
    }
    else {
        const v14_1: string = v0[0];
        if (v14_1 === "\'") {
            const v26 = 1;
            const v47: int32 = (v0.length - 1) | 0;
            const v49: string = v0.slice(v26, v47 + 1);
            const v55: string = v14_1;
            const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v55.length)), v55, 0n), v1, v2, v3);
            return US8_US8_0(v14_1, v49, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v72: int32 = (v0.indexOf("\n") - 1) | 0;
            const v87 = 0;
            const v108: int32 = (((-2 === v72) ? (v0.length + 1) : (v72 + 1)) - 1) | 0;
            const v110: string = v0.slice(v87, v108 + 1);
            return US8_US8_1((((((("parsing.p_char / " + method28("\'", v2, v3)) + "\n") + toString_1(v1)) + v110) + "\n") + (method29(v3 - 1, 0)("") + "^")) + "\n");
        }
    }
}

export function method30(v0_mut: string, v1_mut: any, v2_mut: UH1_$union): US8_$union {
    method30:
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
                continue method30;
            }
        }
        break;
    }
}

export function method31(v0: string[], v1: any, v2: int32, v3: int32): string {
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
    let v78: any;
    closure7(v5, toText(interpolate("%A%P()", [v0])), undefined);
    v78 = undefined;
    let v97: any;
    closure7(v5, "; ", undefined);
    v97 = undefined;
    let v116: any;
    closure7(v5, "s", undefined);
    v116 = undefined;
    let v133: any;
    closure7(v5, " = ", undefined);
    v133 = undefined;
    let v192: any;
    closure7(v5, toText(interpolate("%A%P()", [[v1, v2, v3] as [any, int32, int32]])), undefined);
    v192 = undefined;
    let v211: any;
    closure7(v5, " }", undefined);
    v211 = undefined;
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

export function method33(v0: string, v1: string[], v2: any, v3: int32, v4: int32): string {
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
    let v154: any;
    closure7(v6, toText(interpolate("%A%P()", [v1])), undefined);
    v154 = undefined;
    let v171: any;
    closure7(v6, "; ", undefined);
    v171 = undefined;
    let v190: any;
    closure7(v6, "s", undefined);
    v190 = undefined;
    let v207: any;
    closure7(v6, " = ", undefined);
    v207 = undefined;
    let v266: any;
    closure7(v6, toText(interpolate("%A%P()", [[v2, v3, v4] as [any, int32, int32]])), undefined);
    v266 = undefined;
    let v285: any;
    closure7(v6, " }", undefined);
    v285 = undefined;
    return v6.l0;
}

export function method34(v0_mut: string, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method34:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v104: US8_$union;
        if ("" === v1) {
            v104 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(["\"", "\'"], v2, v3, v4));
        }
        else {
            const v28: string = v1[0];
            if (method32(v28, 0n) === false) {
                const v42 = 1;
                const v63: int32 = (v1.length - 1) | 0;
                const v65: string = v1.slice(v42, v63 + 1);
                const v71: string = v28;
                const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v71.length)), v71, 0n), v2, v3, v4);
                v104 = US8_US8_0(v28, v65, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v104 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v28, ["\"", "\'"], v2, v3, v4));
            }
        }
        let v116: US8_$union;
        if ((v104.tag as int32) === /* US8_0 */ 0) {
            const v105 = v104.fields[0] as any;
            v116 = US8_US8_0(("\\" === v105) ? "/" : v105, v104.fields[1] as any, v104.fields[2] as any, v104.fields[3] as any, v104.fields[4] as any);
        }
        else {
            v116 = US8_US8_1(v104.fields[0] as any);
        }
        if ((v116.tag as int32) === /* US8_0 */ 0) {
            v0_mut = (v0 + (v116.fields[0] as any));
            v1_mut = (v116.fields[1] as any);
            v2_mut = (v116.fields[2] as any);
            v3_mut = (v116.fields[3] as any);
            v4_mut = (v116.fields[4] as any);
            continue method34;
        }
        else {
            const v133 = v116.fields[0] as any;
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
        let v112: US8_$union;
        if ("" === v1) {
            v112 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(["\"", "\'", " "], v2, v3, v4));
        }
        else {
            const v32_1: string = v1[0];
            if (method37(v32_1, 0n) === false) {
                const v46 = 1;
                const v67: int32 = (v1.length - 1) | 0;
                const v69: string = v1.slice(v46, v67 + 1);
                const v75: string = v32_1;
                const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v75.length)), v75, 0n), v2, v3, v4);
                v112 = US8_US8_0(v32_1, v69, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v112 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v32_1, ["\"", "\'", " "], v2, v3, v4));
            }
        }
        let v124: US8_$union;
        if ((v112.tag as int32) === /* US8_0 */ 0) {
            const v113 = v112.fields[0] as any;
            v124 = US8_US8_0(("\\" === v113) ? "/" : v113, v112.fields[1] as any, v112.fields[2] as any, v112.fields[3] as any, v112.fields[4] as any);
        }
        else {
            v124 = US8_US8_1(v112.fields[0] as any);
        }
        if ((v124.tag as int32) === /* US8_0 */ 0) {
            v0_mut = (v0 + (v124.fields[0] as any));
            v1_mut = (v124.fields[1] as any);
            v2_mut = (v124.fields[2] as any);
            v3_mut = (v124.fields[3] as any);
            v4_mut = (v124.fields[4] as any);
            continue method38;
        }
        else {
            const v141 = v124.fields[0] as any;
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
        let v64: US8_$union;
        if ("" === v1) {
            v64 = US8_US8_1("parsing.any_char / unexpected end of input / " + method41(v2, v3, v4));
        }
        else {
            const v14_1: string = v1[0];
            const v25 = 1;
            const v46: int32 = (v1.length - 1) | 0;
            const v48: string = v1.slice(v25, v46 + 1);
            const v54: string = v14_1;
            const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v54.length)), v54, 0n), v2, v3, v4);
            v64 = US8_US8_0(v14_1, v48, patternInput[0], patternInput[1], patternInput[2]);
        }
        if ((v64.tag as int32) === /* US8_0 */ 0) {
            v0_mut = (v0 + (v64.fields[0] as any));
            v1_mut = (v64.fields[1] as any);
            v2_mut = (v64.fields[2] as any);
            v3_mut = (v64.fields[3] as any);
            v4_mut = (v64.fields[4] as any);
            continue method42;
        }
        else {
            const v81 = v64.fields[0] as any;
            return [v0, v1, v2, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method23(v0: string): US7_$union {
    let _v0: Option<Option<string>> = undefined;
    _v0 = some(v0);
    const v10: string = defaultArg((_v0 == null) ? (() => {
        throw new Error("optionm\'.of_obj / _v0=None");
    })() : value_12(_v0), "");
    const v16_1: any = StringBuilder_$ctor_Z721C83C5(method24());
    const v19 = (arg10$0040: [string, any, int32, int32]): US8_$union => closure14(undefined, arg10$0040);
    const v20 = (arg10$0040_1: [string, any, int32, int32]): US8_$union => closure16(undefined, arg10$0040_1);
    const v24: US8_$union = method30(v10, v16_1, UH1_UH1_1(v19, UH1_UH1_1(v20, UH1_UH1_0())));
    let v208: US9_$union;
    if ((v24.tag as int32) === /* US8_0 */ 0) {
        const v29: int32 = (v24.fields[4] as any) | 0;
        const v28: int32 = (v24.fields[3] as any) | 0;
        const v27 = v24.fields[2] as any;
        const v26 = v24.fields[1] as any;
        const v25 = v24.fields[0] as any;
        let v129: US8_$union;
        if ("" === v26) {
            v129 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(["\"", "\'"], v27, v28, v29));
        }
        else {
            const v53: string = v26[0];
            if (method32(v53, 0n) === false) {
                const v67 = 1;
                const v88: int32 = (v26.length - 1) | 0;
                const v90: string = v26.slice(v67, v88 + 1);
                const v96: string = v53;
                const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v96.length)), v96, 0n), v27, v28, v29);
                v129 = US8_US8_0(v53, v90, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v129 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v53, ["\"", "\'"], v27, v28, v29));
            }
        }
        let v141: US8_$union;
        if ((v129.tag as int32) === /* US8_0 */ 0) {
            const v130 = v129.fields[0] as any;
            v141 = US8_US8_0(("\\" === v130) ? "/" : v130, v129.fields[1] as any, v129.fields[2] as any, v129.fields[3] as any, v129.fields[4] as any);
        }
        else {
            v141 = US8_US8_1(v129.fields[0] as any);
        }
        let v161: US9_$union;
        if ((v141.tag as int32) === /* US8_0 */ 0) {
            const patternInput_1: [string, string, any, int32, int32] = method34(v141.fields[0] as any, v141.fields[1] as any, v141.fields[2] as any, v141.fields[3] as any, v141.fields[4] as any);
            v161 = US9_US9_0(patternInput_1[0], patternInput_1[1], patternInput_1[2], patternInput_1[3], patternInput_1[4]);
        }
        else {
            v161 = US9_US9_1(v141.fields[0] as any);
        }
        let v171: US9_$union;
        if ((v161.tag as int32) === /* US9_0 */ 0) {
            v171 = US9_US9_0(v161.fields[0] as any, v161.fields[1] as any, v161.fields[2] as any, v161.fields[3] as any, v161.fields[4] as any);
        }
        else {
            const v168 = v161.fields[0] as any;
            v171 = US9_US9_0("", v26, v27, v28, v29);
        }
        if ((v171.tag as int32) === /* US9_0 */ 0) {
            const v176: int32 = (v171.fields[4] as any) | 0;
            const v175: int32 = (v171.fields[3] as any) | 0;
            const v174 = v171.fields[2] as any;
            const v173 = v171.fields[1] as any;
            const v172 = v171.fields[0] as any;
            const v180: US8_$union = method35(v173, v174, v175, v176, UH1_UH1_1(v19, UH1_UH1_1(v20, UH1_UH1_0())));
            if ((v180.tag as int32) === /* US8_0 */ 0) {
                const v181 = v180.fields[0] as any;
                v208 = US9_US9_0(v172, v180.fields[1] as any, v180.fields[2] as any, v180.fields[3] as any, v180.fields[4] as any);
            }
            else {
                v208 = US9_US9_1("parsing.between / expected closing delimiter / " + method36(v180.fields[0] as any, v10, v16_1, 1, 1, v26, v27, v28, v29, v173, v174, v175, v176));
            }
        }
        else {
            const v200 = v171.fields[0] as any;
            v208 = US9_US9_1("parsing.between / expected content");
        }
    }
    else {
        v208 = US9_US9_1(v24.fields[0] as any);
    }
    let v440: US9_$union;
    if ((v208.tag as int32) === /* US9_0 */ 0) {
        const v213: int32 = (v208.fields[4] as any) | 0;
        const v212: int32 = (v208.fields[3] as any) | 0;
        const v211 = v208.fields[2] as any;
        const v210 = v208.fields[1] as any;
        const v209 = v208.fields[0] as any;
        v440 = v208;
    }
    else {
        const v214 = v208.fields[0] as any;
        let v328: US8_$union;
        if ("" === v10) {
            v328 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(["\"", "\'", " "], v16_1, 1, 1));
        }
        else {
            const v244: string = v10[0];
            if (method37(v244, 0n) === false) {
                const v258 = 1;
                const v279: int32 = (v10.length - 1) | 0;
                const v281: string = v10.slice(v258, v279 + 1);
                const v287: string = v244;
                const patternInput_2: [any, int32, int32] = method27(method26(toInt64(fromInt32(v287.length)), v287, 0n), v16_1, 1, 1);
                v328 = US8_US8_0(v244, v281, patternInput_2[0], patternInput_2[1], patternInput_2[2]);
            }
            else {
                v328 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v244, ["\"", "\'", " "], v16_1, 1, 1));
            }
        }
        let v340: US8_$union;
        if ((v328.tag as int32) === /* US8_0 */ 0) {
            const v329 = v328.fields[0] as any;
            v340 = US8_US8_0(("\\" === v329) ? "/" : v329, v328.fields[1] as any, v328.fields[2] as any, v328.fields[3] as any, v328.fields[4] as any);
        }
        else {
            v340 = US8_US8_1(v328.fields[0] as any);
        }
        let v360: US9_$union;
        if ((v340.tag as int32) === /* US8_0 */ 0) {
            const patternInput_3: [string, string, any, int32, int32] = method38(v340.fields[0] as any, v340.fields[1] as any, v340.fields[2] as any, v340.fields[3] as any, v340.fields[4] as any);
            v360 = US9_US9_0(patternInput_3[0], patternInput_3[1], patternInput_3[2], patternInput_3[3], patternInput_3[4]);
        }
        else {
            v360 = US9_US9_1(v340.fields[0] as any);
        }
        if ((v360.tag as int32) === /* US9_0 */ 0) {
            const v365: int32 = (v360.fields[4] as any) | 0;
            const v364: int32 = (v360.fields[3] as any) | 0;
            const v363 = v360.fields[2] as any;
            const v362 = v360.fields[1] as any;
            const v361 = v360.fields[0] as any;
            v440 = v360;
        }
        else {
            const v366 = v360.fields[0] as any;
            const v378: US11_$union = (v10.length === 0) ? US11_US11_0(v10, v16_1, 1, 1) : US11_US11_1("parsing.eof / expected end of input / " + method39(v10));
            const v387: US9_$union = ((v378.tag as int32) === /* US11_0 */ 0) ? US9_US9_0("", v378.fields[0] as any, v378.fields[1] as any, v378.fields[2] as any, v378.fields[3] as any) : US9_US9_1(v378.fields[0] as any);
            if ((v387.tag as int32) === /* US9_0 */ 0) {
                const v392: int32 = (v387.fields[4] as any) | 0;
                const v391: int32 = (v387.fields[3] as any) | 0;
                const v390 = v387.fields[2] as any;
                const v389 = v387.fields[1] as any;
                const v388 = v387.fields[0] as any;
                const v405: int32 = method40(v389, 0) | 0;
                const v426: int32 = (v389.length - 1) | 0;
                v440 = US9_US9_0(v388, v389.slice(v405, v426 + 1), v390, v391, v392);
            }
            else {
                v440 = US9_US9_1(v387.fields[0] as any);
            }
        }
    }
    let v732: US12_$union;
    if ((v440.tag as int32) === /* US9_0 */ 0) {
        const v445: int32 = (v440.fields[4] as any) | 0;
        const v444: int32 = (v440.fields[3] as any) | 0;
        const v443 = v440.fields[2] as any;
        const v442 = v440.fields[1] as any;
        const v441 = v440.fields[0] as any;
        let v605: US8_$union;
        if ("" === v442) {
            v605 = US8_US8_1("parsing.p_char / unexpected end of input / " + method25(" ", v443, v444, v445));
        }
        else {
            const v456: string = v442[0];
            if (v456 === " ") {
                const v468 = 1;
                const v489: int32 = (v442.length - 1) | 0;
                const v491: string = v442.slice(v468, v489 + 1);
                const v497: string = v456;
                const patternInput_4: [any, int32, int32] = method27(method26(toInt64(fromInt32(v497.length)), v497, 0n), v443, v444, v445);
                v605 = US8_US8_0(v456, v491, patternInput_4[0], patternInput_4[1], patternInput_4[2]);
            }
            else {
                const v514: int32 = (v442.indexOf("\n") - 1) | 0;
                const v529 = 0;
                const v550: int32 = (((-2 === v514) ? (v442.length + 1) : (v514 + 1)) - 1) | 0;
                const v552: string = v442.slice(v529, v550 + 1);
                v605 = US8_US8_1((((((("parsing.p_char / " + method28(" ", v444, v445)) + "\n") + toString_1(v443)) + v552) + "\n") + (method29(v445 - 1, 0)("") + "^")) + "\n");
            }
        }
        let v617: US13_$union;
        if ((v605.tag as int32) === /* US8_0 */ 0) {
            v617 = US13_US13_0(US10_US10_0(v605.fields[0] as any), v605.fields[1] as any, v605.fields[2] as any, v605.fields[3] as any, v605.fields[4] as any);
        }
        else {
            const v613 = v605.fields[0] as any;
            v617 = US13_US13_0(US10_US10_1(), v442, v443, v444, v445);
        }
        let v706: US9_$union;
        if ((v617.tag as int32) === /* US13_0 */ 0) {
            const v622: int32 = (v617.fields[4] as any) | 0;
            const v621: int32 = (v617.fields[3] as any) | 0;
            const v620 = v617.fields[2] as any;
            const v619 = v617.fields[1] as any;
            const v618 = v617.fields[0] as any;
            let v682: US8_$union;
            if ("" === v619) {
                v682 = US8_US8_1("parsing.any_char / unexpected end of input / " + method41(v620, v621, v622));
            }
            else {
                const v632: string = v619[0];
                const v643 = 1;
                const v664: int32 = (v619.length - 1) | 0;
                const v666: string = v619.slice(v643, v664 + 1);
                const v672: string = v632;
                const patternInput_5: [any, int32, int32] = method27(method26(toInt64(fromInt32(v672.length)), v672, 0n), v620, v621, v622);
                v682 = US8_US8_0(v632, v666, patternInput_5[0], patternInput_5[1], patternInput_5[2]);
            }
            if ((v682.tag as int32) === /* US8_0 */ 0) {
                const patternInput_6: [string, string, any, int32, int32] = method42(v682.fields[0] as any, v682.fields[1] as any, v682.fields[2] as any, v682.fields[3] as any, v682.fields[4] as any);
                v706 = US9_US9_0(patternInput_6[0], patternInput_6[1], patternInput_6[2], patternInput_6[3], patternInput_6[4]);
            }
            else {
                v706 = US9_US9_1(v682.fields[0] as any);
            }
        }
        else {
            v706 = US9_US9_1(v617.fields[0] as any);
        }
        let v718: US14_$union;
        if ((v706.tag as int32) === /* US9_0 */ 0) {
            v718 = US14_US14_0(US5_US5_0(v706.fields[0] as any), v706.fields[1] as any, v706.fields[2] as any, v706.fields[3] as any, v706.fields[4] as any);
        }
        else {
            const v714 = v706.fields[0] as any;
            v718 = US14_US14_0(US5_US5_1(), v442, v443, v444, v445);
        }
        v732 = (((v718.tag as int32) === /* US14_0 */ 0) ? US12_US12_0(v441, v718.fields[0] as any, v718.fields[1] as any, v718.fields[2] as any, v718.fields[3] as any, v718.fields[4] as any) : US12_US12_1(v718.fields[0] as any));
    }
    else {
        v732 = US12_US12_1(v440.fields[0] as any);
    }
    if ((v732.tag as int32) === /* US12_0 */ 0) {
        const v738: int32 = (v732.fields[5] as any) | 0;
        const v737: int32 = (v732.fields[4] as any) | 0;
        const v736 = v732.fields[3] as any;
        const v735 = v732.fields[2] as any;
        return US7_US7_0(v732.fields[0] as any, v732.fields[1] as any);
    }
    else {
        return US7_US7_1(v732.fields[0] as any);
    }
}

export function method43(): string {
    const v4: string = "Debug".toLocaleLowerCase();
    return ("\u001b[94m" + method12(v4[0])) + method14();
}

export function method45(v0: string, v1: US5_$union, v2: string, v3: Option<any>, v4: [string, string][], v5: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v6: Option<((arg0: any) => void)>, v7: boolean, v8: Option<string>): string {
    const v10: Mut3 = new Mut3(method13());
    let v24: any;
    closure7(v10, "{ ", undefined);
    v24 = undefined;
    let v43: any;
    closure7(v10, "file_name", undefined);
    v43 = undefined;
    let v62: any;
    closure7(v10, " = ", undefined);
    v62 = undefined;
    let v79: any;
    closure7(v10, v0, undefined);
    v79 = undefined;
    let v98: any;
    closure7(v10, "; ", undefined);
    v98 = undefined;
    let v117: any;
    closure7(v10, "arguments", undefined);
    v117 = undefined;
    let v134: any;
    closure7(v10, " = ", undefined);
    v134 = undefined;
    let v155: any;
    closure7(v10, toText(interpolate("%A%P()", [v1])), undefined);
    v155 = undefined;
    let v172: any;
    closure7(v10, "; ", undefined);
    v172 = undefined;
    let v191: any;
    closure7(v10, "options", undefined);
    v191 = undefined;
    let v208: any;
    closure7(v10, " = ", undefined);
    v208 = undefined;
    let v225: any;
    closure7(v10, "{ ", undefined);
    v225 = undefined;
    let v244: any;
    closure7(v10, "command", undefined);
    v244 = undefined;
    let v261: any;
    closure7(v10, " = ", undefined);
    v261 = undefined;
    let v278: any;
    closure7(v10, v2, undefined);
    v278 = undefined;
    let v295: any;
    closure7(v10, "; ", undefined);
    v295 = undefined;
    let v314: any;
    closure7(v10, "cancellation_token", undefined);
    v314 = undefined;
    let v331: any;
    closure7(v10, " = ", undefined);
    v331 = undefined;
    let v390: any;
    closure7(v10, toText(interpolate("%A%P()", [v3])), undefined);
    v390 = undefined;
    let v407: any;
    closure7(v10, "; ", undefined);
    v407 = undefined;
    let v426: any;
    closure7(v10, "environment_variables", undefined);
    v426 = undefined;
    let v443: any;
    closure7(v10, " = ", undefined);
    v443 = undefined;
    let v464: any;
    closure7(v10, toText(interpolate("%A%P()", [v4])), undefined);
    v464 = undefined;
    let v481: any;
    closure7(v10, "; ", undefined);
    v481 = undefined;
    let v500: any;
    closure7(v10, "on_line", undefined);
    v500 = undefined;
    let v517: any;
    closure7(v10, " = ", undefined);
    v517 = undefined;
    let v576: any;
    closure7(v10, toText(interpolate("%A%P()", [v5])), undefined);
    v576 = undefined;
    let v593: any;
    closure7(v10, "; ", undefined);
    v593 = undefined;
    let v612: any;
    closure7(v10, "stdin", undefined);
    v612 = undefined;
    let v629: any;
    closure7(v10, " = ", undefined);
    v629 = undefined;
    let v688: any;
    closure7(v10, toText(interpolate("%A%P()", [v6])), undefined);
    v688 = undefined;
    let v705: any;
    closure7(v10, "; ", undefined);
    v705 = undefined;
    let v724: any;
    closure7(v10, "trace", undefined);
    v724 = undefined;
    let v741: any;
    closure7(v10, " = ", undefined);
    v741 = undefined;
    let v761: any;
    closure7(v10, v7 ? "true" : "false", undefined);
    v761 = undefined;
    let v778: any;
    closure7(v10, "; ", undefined);
    v778 = undefined;
    let v797: any;
    closure7(v10, "working_directory", undefined);
    v797 = undefined;
    let v814: any;
    closure7(v10, " = ", undefined);
    v814 = undefined;
    let v873: any;
    closure7(v10, toText(interpolate("%A%P()", [v8])), undefined);
    v873 = undefined;
    let v892: any;
    closure7(v10, " }", undefined);
    v892 = undefined;
    let v909: any;
    closure7(v10, " }", undefined);
    v909 = undefined;
    return v10.l0;
}

export function method44(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string, v9: US5_$union, v10: string, v11: Option<any>, v12: [string, string][], v13: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v14_1: Option<((arg0: any) => void)>, v15_1: boolean, v16_1: Option<string>): string {
    const v17: string = method45(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1);
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v17);
}

export function closure17(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: US5_$union, v8: string, unitVar: void): void {
    const v24 = (): void => {
        closure0(undefined, undefined);
    };
    let v25: any;
    v24();
    v25 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    const v66: US0_$union = patternInput[4].l0;
    let v306: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (1 >= find<US0_$union, int32>(v66, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v306 = US6_US6_1();
    }
    else {
        let v89: any;
        v24();
        v89 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v117: Option<int64> = patternInput_1[5];
        const v116: Mut4 = patternInput_1[4];
        const v115: Mut3 = patternInput_1[3];
        const v114: Mut2 = patternInput_1[2];
        const v113: Mut1 = patternInput_1[1];
        const v112: Mut0 = patternInput_1[0];
        const v132: string = method44(v112, v113, v114, v115, v116, v117, method7(v112, v113, v114, v115, v116, v117), method43(), v8, v7, v0, v1, v2, v3, v4, v5, v6);
        let v148: any;
        v24();
        v148 = undefined;
        const patternInput_2: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v172: Mut1 = patternInput_2[1];
        const v171: Mut0 = patternInput_2[0];
        let v193: any;
        closure8(v171, undefined);
        v193 = undefined;
        closure9(undefined, v132);
        v172.l0(v132);
        v306 = US6_US6_0(v171, v172, patternInput_2[2], patternInput_2[3], patternInput_2[4], patternInput_2[5]);
    }
}

export function method46(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>): [string, string][] {
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
    const v4: string = "Verbose".toLocaleLowerCase();
    return ("\u001b[90m" + method12(v4[0])) + method14();
}

export function method54(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: string): string {
    const v9: string = method16();
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + v8) + " / ") + v9);
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

export function method49(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: any, v9: boolean, v10: boolean): Async<void> {
    return singleton.Delay<void>((): Async<void> => {
        let v8990: US15_$union, v8996: Async<void>;
        const v8959: string = method50(v10);
        const v8965: boolean = (v8959 === defaultOf()) !== true;
        return singleton.Combine<void>(v8965 ? ((v8990 = defaultArg(map<((arg0: [int32, string, boolean]) => Async<void>), US15_$union>(method51(), v3), US15_US15_1()), singleton.Combine<void>(((v8990.tag as int32) === /* US15_0 */ 0) ? ((v8996 = (v8990.fields[0] as any)([method52(v7), v8959, v9] as [int32, string, boolean]), singleton.Bind<void, void>(v8996, (): Async<void> => {
            return singleton.Zero();
        }))) : (singleton.Zero()), singleton.Delay<void>((): Async<void> => {
            let v9316: any, v9637: any;
            const v8999: string = v9 ? concat("! ", ...v8959) : concat("> ", ...v8959);
            return singleton.Combine<void>(v5 ? ((v9316 = ((closure20(v8999, undefined), undefined)), singleton.Zero())) : ((v9637 = ((closure10(v8999, undefined), undefined)), singleton.Zero())), singleton.Delay<void>((): Async<void> => {
                const v9645: string = concat(v9 ? "\u001b[7;4m" : "", v8959, ...(v9 ? "\u001b[0m" : ""));
                return singleton.Zero();
            }));
        })))) : singleton.Zero(), singleton.Delay<void>((): Async<void> => {
            return singleton.Zero();
        }));
    });
}

export function method48(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: any, v9: boolean, v10: boolean): Async<void> {
    return method49(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
}

export function closure18(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: boolean, v8: any, v9: boolean, v10: boolean): void {
    startImmediate(method48(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10));
}

export function closure21(unitVar: void, v0: any): US16_$union {
    return US16_US16_0(v0);
}

export function method55(): ((arg0: any) => US16_$union) {
    return (v: any): US16_$union => closure21(undefined, v);
}

export function method56(v0: any): Async<any> {
    return singleton.Delay<any>((): Async<any> => {
        const v612: any = defaultOf();
        return singleton.Return<any>(v612);
    });
}

export function method57(v0: boolean): boolean {
    return defaultOf();
}

export function method58(v0: boolean): void {
}

export function closure22(v0: boolean, unitVar: void): void {
    if (method57(v0) === false) {
        method58(v0);
    }
}

export function method61(v0: any): string {
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

export function method60(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: any): string {
    const v9: string = method61(v8);
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.execute_with_options_async / WaitForExitAsync") + " / ") + v9);
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
        const v124: string = method60(v104, v105, v106, v107, v108, v109, method7(v104, v105, v106, v107, v108, v109), method11(), v0);
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

export function method59(v0: boolean, v1: any, v2: any): Async<int32> {
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

export function method62(): string {
    return "\n";
}

export function method64(v0: int32, v1: int32, v2: string, v3: Option<any>, v4: [string, string][], v5: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v6: Option<((arg0: any) => void)>, v7: boolean, v8: Option<string>): string {
    const v10: Mut3 = new Mut3(method13());
    let v24: any;
    closure7(v10, "{ ", undefined);
    v24 = undefined;
    let v43: any;
    closure7(v10, "exit_code", undefined);
    v43 = undefined;
    let v62: any;
    closure7(v10, " = ", undefined);
    v62 = undefined;
    let v82: any;
    closure7(v10, `${v0}`, undefined);
    v82 = undefined;
    let v101: any;
    closure7(v10, "; ", undefined);
    v101 = undefined;
    let v120: any;
    closure7(v10, "output_length", undefined);
    v120 = undefined;
    let v137: any;
    closure7(v10, " = ", undefined);
    v137 = undefined;
    let v157: any;
    closure7(v10, `${v1}`, undefined);
    v157 = undefined;
    let v174: any;
    closure7(v10, "; ", undefined);
    v174 = undefined;
    let v193: any;
    closure7(v10, "options", undefined);
    v193 = undefined;
    let v210: any;
    closure7(v10, " = ", undefined);
    v210 = undefined;
    let v227: any;
    closure7(v10, "{ ", undefined);
    v227 = undefined;
    let v246: any;
    closure7(v10, "command", undefined);
    v246 = undefined;
    let v263: any;
    closure7(v10, " = ", undefined);
    v263 = undefined;
    let v280: any;
    closure7(v10, v2, undefined);
    v280 = undefined;
    let v297: any;
    closure7(v10, "; ", undefined);
    v297 = undefined;
    let v316: any;
    closure7(v10, "cancellation_token", undefined);
    v316 = undefined;
    let v333: any;
    closure7(v10, " = ", undefined);
    v333 = undefined;
    let v392: any;
    closure7(v10, toText(interpolate("%A%P()", [v3])), undefined);
    v392 = undefined;
    let v409: any;
    closure7(v10, "; ", undefined);
    v409 = undefined;
    let v428: any;
    closure7(v10, "environment_variables", undefined);
    v428 = undefined;
    let v445: any;
    closure7(v10, " = ", undefined);
    v445 = undefined;
    let v466: any;
    closure7(v10, toText(interpolate("%A%P()", [v4])), undefined);
    v466 = undefined;
    let v483: any;
    closure7(v10, "; ", undefined);
    v483 = undefined;
    let v502: any;
    closure7(v10, "on_line", undefined);
    v502 = undefined;
    let v519: any;
    closure7(v10, " = ", undefined);
    v519 = undefined;
    let v578: any;
    closure7(v10, toText(interpolate("%A%P()", [v5])), undefined);
    v578 = undefined;
    let v595: any;
    closure7(v10, "; ", undefined);
    v595 = undefined;
    let v614: any;
    closure7(v10, "stdin", undefined);
    v614 = undefined;
    let v631: any;
    closure7(v10, " = ", undefined);
    v631 = undefined;
    let v690: any;
    closure7(v10, toText(interpolate("%A%P()", [v6])), undefined);
    v690 = undefined;
    let v707: any;
    closure7(v10, "; ", undefined);
    v707 = undefined;
    let v726: any;
    closure7(v10, "trace", undefined);
    v726 = undefined;
    let v743: any;
    closure7(v10, " = ", undefined);
    v743 = undefined;
    let v763: any;
    closure7(v10, v7 ? "true" : "false", undefined);
    v763 = undefined;
    let v780: any;
    closure7(v10, "; ", undefined);
    v780 = undefined;
    let v799: any;
    closure7(v10, "working_directory", undefined);
    v799 = undefined;
    let v816: any;
    closure7(v10, " = ", undefined);
    v816 = undefined;
    let v875: any;
    closure7(v10, toText(interpolate("%A%P()", [v8])), undefined);
    v875 = undefined;
    let v894: any;
    closure7(v10, " }", undefined);
    v894 = undefined;
    let v911: any;
    closure7(v10, " }", undefined);
    v911 = undefined;
    return v10.l0;
}

export function method63(v0: Mut0, v1: Mut1, v2: Mut2, v3: Mut3, v4: Mut4, v5: Option<int64>, v6: string, v7: string, v8: int32, v9: int32, v10: string, v11: Option<any>, v12: [string, string][], v13: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v14_1: Option<((arg0: any) => void)>, v15_1: boolean, v16_1: Option<string>): string {
    const v17: string = method64(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1);
    return method17((((((((v6 + " ") + v7) + " #") + int64ToString(v0.l0)) + " ") + "runtime.execute_with_options_async") + " / ") + v17);
}

export function closure24(v0: string, v1: Option<any>, v2: [string, string][], v3: Option<((arg0: [int32, string, boolean]) => Async<void>)>, v4: Option<((arg0: any) => void)>, v5: boolean, v6: Option<string>, v7: int32, v8: string, unitVar: void): void {
    const v24 = (): void => {
        closure0(undefined, undefined);
    };
    let v25: any;
    v24();
    v25 = undefined;
    const patternInput: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
    const v66: US0_$union = patternInput[4].l0;
    let v307: US6_$union;
    if (((patternInput[2].l0 === false) ? false : (1 >= find<US0_$union, int32>(v66, ofSeq([[US0_US0_0(), 0] as [US0_$union, int32], [US0_US0_1(), 1] as [US0_$union, int32], [US0_US0_2(), 2] as [US0_$union, int32], [US0_US0_3(), 3] as [US0_$union, int32], [US0_US0_4(), 4] as [US0_$union, int32]], {
        Compare: compare,
    })))) === false) {
        v307 = US6_US6_1();
    }
    else {
        let v89: any;
        v24();
        v89 = undefined;
        const patternInput_1: [Mut0, Mut1, Mut2, Mut3, Mut4, Option<int64>] = value_12(TraceState_trace_state());
        const v117: Option<int64> = patternInput_1[5];
        const v116: Mut4 = patternInput_1[4];
        const v115: Mut3 = patternInput_1[3];
        const v114: Mut2 = patternInput_1[2];
        const v113: Mut1 = patternInput_1[1];
        const v112: Mut0 = patternInput_1[0];
        const v133: string = method63(v112, v113, v114, v115, v116, v117, method7(v112, v113, v114, v115, v116, v117), method43(), v7, v8.length, v0, v1, v2, v3, v4, v5, v6);
        let v149: any;
        v24();
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

export function method67(v0_mut: string, v1_mut: int64): boolean {
    method67:
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
                continue method67;
            }
        }
        break;
    }
}

export function method68(v0_mut: string, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): [string, string, any, int32, int32] {
    method68:
    while (true) {
        const v0: string = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v120: US8_$union;
        if ("" === v1) {
            v120 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(["\\", "`", "\"", " "], v2, v3, v4));
        }
        else {
            const v36: string = v1[0];
            if (method67(v36, 0n) === false) {
                const v50 = 1;
                const v71: int32 = (v1.length - 1) | 0;
                const v73: string = v1.slice(v50, v71 + 1);
                const v79: string = v36;
                const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v79.length)), v79, 0n), v2, v3, v4);
                v120 = US8_US8_0(v36, v73, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v120 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v36, ["\\", "`", "\"", " "], v2, v3, v4));
            }
        }
        if ((v120.tag as int32) === /* US8_0 */ 0) {
            v0_mut = (v0 + (v120.fields[0] as any));
            v1_mut = (v120.fields[1] as any);
            v2_mut = (v120.fields[2] as any);
            v3_mut = (v120.fields[3] as any);
            v4_mut = (v120.fields[4] as any);
            continue method68;
        }
        else {
            const v137 = v120.fields[0] as any;
            return [v0, v1, v2, v3, v4] as [string, string, any, int32, int32];
        }
        break;
    }
}

export function method70(v0_mut: string, v1_mut: int64): boolean {
    method70:
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
                continue method70;
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
    let v164: US8_$union;
    if ("" === v0) {
        v164 = US8_US8_1("parsing.p_char / unexpected end of input / " + method25("\\", v1, v2, v3));
    }
    else {
        const v14_1: string = v0[0];
        if (v14_1 === "\\") {
            const v26 = 1;
            const v47: int32 = (v0.length - 1) | 0;
            const v49: string = v0.slice(v26, v47 + 1);
            const v55: string = v14_1;
            const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v55.length)), v55, 0n), v1, v2, v3);
            v164 = US8_US8_0(v14_1, v49, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v72: int32 = (v0.indexOf("\n") - 1) | 0;
            const v87 = 0;
            const v108: int32 = (((-2 === v72) ? (v0.length + 1) : (v72 + 1)) - 1) | 0;
            const v110: string = v0.slice(v87, v108 + 1);
            v164 = US8_US8_1((((((("parsing.p_char / " + method28("\\", v2, v3)) + "\n") + toString_1(v1)) + v110) + "\n") + (method29(v3 - 1, 0)("") + "^")) + "\n");
        }
    }
    let v233: US8_$union;
    if ((v164.tag as int32) === /* US8_0 */ 0) {
        const v169: int32 = (v164.fields[4] as any) | 0;
        const v168: int32 = (v164.fields[3] as any) | 0;
        const v167 = v164.fields[2] as any;
        const v166 = v164.fields[1] as any;
        const v165 = v164.fields[0] as any;
        if ("" === v166) {
            v233 = US8_US8_1("parsing.any_char / unexpected end of input / " + method41(v167, v168, v169));
        }
        else {
            const v179: string = v166[0];
            const v190 = 1;
            const v211: int32 = (v166.length - 1) | 0;
            const v213: string = v166.slice(v190, v211 + 1);
            const v219: string = v179;
            const patternInput_1: [any, int32, int32] = method27(method26(toInt64(fromInt32(v219.length)), v219, 0n), v167, v168, v169);
            v233 = US8_US8_0(v179, v213, patternInput_1[0], patternInput_1[1], patternInput_1[2]);
        }
    }
    else {
        v233 = US8_US8_1(v164.fields[0] as any);
    }
    if ((v233.tag as int32) === /* US8_0 */ 0) {
        return US9_US9_0("\\" + (v233.fields[0] as any), v233.fields[1] as any, v233.fields[2] as any, v233.fields[3] as any, v233.fields[4] as any);
    }
    else {
        return US9_US9_1(v233.fields[0] as any);
    }
}

export function closure29(unitVar: void, _arg: [string, any, int32, int32]): US9_$union {
    const v3: int32 = _arg[3] | 0;
    const v2: int32 = _arg[2] | 0;
    const v1: any = _arg[1];
    const v0: string = _arg[0];
    let v164: US8_$union;
    if ("" === v0) {
        v164 = US8_US8_1("parsing.p_char / unexpected end of input / " + method25("`", v1, v2, v3));
    }
    else {
        const v14_1: string = v0[0];
        if (v14_1 === "`") {
            const v26 = 1;
            const v47: int32 = (v0.length - 1) | 0;
            const v49: string = v0.slice(v26, v47 + 1);
            const v55: string = v14_1;
            const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v55.length)), v55, 0n), v1, v2, v3);
            v164 = US8_US8_0(v14_1, v49, patternInput[0], patternInput[1], patternInput[2]);
        }
        else {
            const v72: int32 = (v0.indexOf("\n") - 1) | 0;
            const v87 = 0;
            const v108: int32 = (((-2 === v72) ? (v0.length + 1) : (v72 + 1)) - 1) | 0;
            const v110: string = v0.slice(v87, v108 + 1);
            v164 = US8_US8_1((((((("parsing.p_char / " + method28("`", v2, v3)) + "\n") + toString_1(v1)) + v110) + "\n") + (method29(v3 - 1, 0)("") + "^")) + "\n");
        }
    }
    let v233: US8_$union;
    if ((v164.tag as int32) === /* US8_0 */ 0) {
        const v169: int32 = (v164.fields[4] as any) | 0;
        const v168: int32 = (v164.fields[3] as any) | 0;
        const v167 = v164.fields[2] as any;
        const v166 = v164.fields[1] as any;
        const v165 = v164.fields[0] as any;
        if ("" === v166) {
            v233 = US8_US8_1("parsing.any_char / unexpected end of input / " + method41(v167, v168, v169));
        }
        else {
            const v179: string = v166[0];
            const v190 = 1;
            const v211: int32 = (v166.length - 1) | 0;
            const v213: string = v166.slice(v190, v211 + 1);
            const v219: string = v179;
            const patternInput_1: [any, int32, int32] = method27(method26(toInt64(fromInt32(v219.length)), v219, 0n), v167, v168, v169);
            v233 = US8_US8_0(v179, v213, patternInput_1[0], patternInput_1[1], patternInput_1[2]);
        }
    }
    else {
        v233 = US8_US8_1(v164.fields[0] as any);
    }
    if ((v233.tag as int32) === /* US8_0 */ 0) {
        return US9_US9_0("`" + (v233.fields[0] as any), v233.fields[1] as any, v233.fields[2] as any, v233.fields[3] as any, v233.fields[4] as any);
    }
    else {
        return US9_US9_1(v233.fields[0] as any);
    }
}

export function method71(v0_mut: string, v1_mut: any, v2_mut: int32, v3_mut: int32, v4_mut: UH3_$union): US9_$union {
    method71:
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
                continue method71;
            }
        }
        break;
    }
}

export function method72(v0_mut: UH2_$union, v1_mut: UH2_$union): UH2_$union {
    method72:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: UH2_$union = v1_mut;
        if ((v0.tag as int32) === /* UH2_0 */ 0) {
            return v1;
        }
        else {
            v0_mut = (v0.fields[1] as any);
            v1_mut = UH2_UH2_1(v0.fields[0] as any, v1);
            continue method72;
        }
        break;
    }
}

export function method69(v0_mut: UH2_$union, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): US18_$union {
    method69:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v112: US8_$union;
        if ("" === v1) {
            v112 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(["\\", "`", "\""], v2, v3, v4));
        }
        else {
            const v32_1: string = v1[0];
            if (method70(v32_1, 0n) === false) {
                const v46 = 1;
                const v67: int32 = (v1.length - 1) | 0;
                const v69: string = v1.slice(v46, v67 + 1);
                const v75: string = v32_1;
                const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v75.length)), v75, 0n), v2, v3, v4);
                v112 = US8_US8_0(v32_1, v69, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v112 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v32_1, ["\\", "`", "\""], v2, v3, v4));
            }
        }
        const v127: US9_$union = ((v112.tag as int32) === /* US8_0 */ 0) ? US9_US9_0(v112.fields[0] as any, v112.fields[1] as any, v112.fields[2] as any, v112.fields[3] as any, v112.fields[4] as any) : US9_US9_1(v112.fields[0] as any);
        let v141: US9_$union;
        if ((v127.tag as int32) === /* US9_0 */ 0) {
            const v132: int32 = (v127.fields[4] as any) | 0;
            const v131: int32 = (v127.fields[3] as any) | 0;
            const v130 = v127.fields[2] as any;
            const v129 = v127.fields[1] as any;
            const v128 = v127.fields[0] as any;
            v141 = v127;
        }
        else {
            const v133 = v127.fields[0] as any;
            v141 = method71(v1, v2, v3, v4, UH3_UH3_1((arg10$0040: [string, any, int32, int32]): US9_$union => closure28(undefined, arg10$0040), UH3_UH3_1((arg10$0040_1: [string, any, int32, int32]): US9_$union => closure29(undefined, arg10$0040_1), UH3_UH3_0())));
        }
        if ((v141.tag as int32) === /* US9_0 */ 0) {
            v0_mut = UH2_UH2_1(v141.fields[0] as any, v0);
            v1_mut = (v141.fields[1] as any);
            v2_mut = (v141.fields[2] as any);
            v3_mut = (v141.fields[3] as any);
            v4_mut = (v141.fields[4] as any);
            continue method69;
        }
        else {
            const v149 = v141.fields[0] as any;
            return US18_US18_0(method72(v0, UH2_UH2_0()), v1, v2, v3, v4);
        }
        break;
    }
}

export function method73(v0: UH2_$union, v1: FSharpList<string>): FSharpList<string> {
    if ((v0.tag as int32) === /* UH2_0 */ 0) {
        return v1;
    }
    else {
        return cons(v0.fields[0] as any, method73(v0.fields[1] as any, v1));
    }
}

export function method74(v0_mut: UH2_$union, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): US18_$union {
    method74:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        let v112: US8_$union;
        if ("" === v1) {
            v112 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(["\\", "`", "\""], v2, v3, v4));
        }
        else {
            const v32_1: string = v1[0];
            if (method70(v32_1, 0n) === false) {
                const v46 = 1;
                const v67: int32 = (v1.length - 1) | 0;
                const v69: string = v1.slice(v46, v67 + 1);
                const v75: string = v32_1;
                const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v75.length)), v75, 0n), v2, v3, v4);
                v112 = US8_US8_0(v32_1, v69, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v112 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v32_1, ["\\", "`", "\""], v2, v3, v4));
            }
        }
        const v127: US9_$union = ((v112.tag as int32) === /* US8_0 */ 0) ? US9_US9_0(v112.fields[0] as any, v112.fields[1] as any, v112.fields[2] as any, v112.fields[3] as any, v112.fields[4] as any) : US9_US9_1(v112.fields[0] as any);
        if ((v127.tag as int32) === /* US9_0 */ 0) {
            v0_mut = UH2_UH2_1(v127.fields[0] as any, v0);
            v1_mut = (v127.fields[1] as any);
            v2_mut = (v127.fields[2] as any);
            v3_mut = (v127.fields[3] as any);
            v4_mut = (v127.fields[4] as any);
            continue method74;
        }
        else {
            const v135 = v127.fields[0] as any;
            return US18_US18_0(method72(v0, UH2_UH2_0()), v1, v2, v3, v4);
        }
        break;
    }
}

export function method66(v0_mut: UH2_$union, v1_mut: string, v2_mut: any, v3_mut: int32, v4_mut: int32): US18_$union {
    method66:
    while (true) {
        const v0: UH2_$union = v0_mut, v1: string = v1_mut, v2: any = v2_mut, v3: int32 = v3_mut, v4: int32 = v4_mut;
        const v5: boolean = "" === v1;
        let v120: US8_$union;
        if (v5) {
            v120 = US8_US8_1("parsing.none_of / unexpected end of input / " + method31(["\\", "`", "\"", " "], v2, v3, v4));
        }
        else {
            const v36: string = v1[0];
            if (method67(v36, 0n) === false) {
                const v50 = 1;
                const v71: int32 = (v1.length - 1) | 0;
                const v73: string = v1.slice(v50, v71 + 1);
                const v79: string = v36;
                const patternInput: [any, int32, int32] = method27(method26(toInt64(fromInt32(v79.length)), v79, 0n), v2, v3, v4);
                v120 = US8_US8_0(v36, v73, patternInput[0], patternInput[1], patternInput[2]);
            }
            else {
                v120 = US8_US8_1("parsing.none_of / unexpected char / " + method33(v36, ["\\", "`", "\"", " "], v2, v3, v4));
            }
        }
        let v140: US9_$union;
        if ((v120.tag as int32) === /* US8_0 */ 0) {
            const patternInput_1: [string, string, any, int32, int32] = method68(v120.fields[0] as any, v120.fields[1] as any, v120.fields[2] as any, v120.fields[3] as any, v120.fields[4] as any);
            v140 = US9_US9_0(patternInput_1[0], patternInput_1[1], patternInput_1[2], patternInput_1[3], patternInput_1[4]);
        }
        else {
            v140 = US9_US9_1(v120.fields[0] as any);
        }
        let v609: US9_$union;
        if ((v140.tag as int32) === /* US9_0 */ 0) {
            const v145: int32 = (v140.fields[4] as any) | 0;
            const v144: int32 = (v140.fields[3] as any) | 0;
            const v143 = v140.fields[2] as any;
            const v142 = v140.fields[1] as any;
            const v141 = v140.fields[0] as any;
            v609 = v140;
        }
        else {
            const v146 = v140.fields[0] as any;
            let v306: US8_$union;
            if (v5) {
                v306 = US8_US8_1("parsing.p_char / unexpected end of input / " + method25("\"", v2, v3, v4));
            }
            else {
                const v156: string = v1[0];
                if (v156 === "\"") {
                    const v168 = 1;
                    const v189: int32 = (v1.length - 1) | 0;
                    const v191: string = v1.slice(v168, v189 + 1);
                    const v197: string = v156;
                    const patternInput_2: [any, int32, int32] = method27(method26(toInt64(fromInt32(v197.length)), v197, 0n), v2, v3, v4);
                    v306 = US8_US8_0(v156, v191, patternInput_2[0], patternInput_2[1], patternInput_2[2]);
                }
                else {
                    const v214: int32 = (v1.indexOf("\n") - 1) | 0;
                    const v229 = 0;
                    const v250: int32 = (((-2 === v214) ? (v1.length + 1) : (v214 + 1)) - 1) | 0;
                    const v252: string = v1.slice(v229, v250 + 1);
                    v306 = US8_US8_1((((((("parsing.p_char / " + method28("\"", v3, v4)) + "\n") + toString_1(v2)) + v252) + "\n") + (method29(v4 - 1, 0)("") + "^")) + "\n");
                }
            }
            let v538: US9_$union;
            if ((v306.tag as int32) === /* US8_0 */ 0) {
                const v311: int32 = (v306.fields[4] as any) | 0;
                const v310: int32 = (v306.fields[3] as any) | 0;
                const v309 = v306.fields[2] as any;
                const v308 = v306.fields[1] as any;
                const v307 = v306.fields[0] as any;
                const v313: US18_$union = method69(UH2_UH2_0(), v308, v309, v310, v311);
                let v346: US9_$union;
                if ((v313.tag as int32) === /* US18_0 */ 0) {
                    const v318: int32 = (v313.fields[4] as any) | 0;
                    const v317: int32 = (v313.fields[3] as any) | 0;
                    const v316 = v313.fields[2] as any;
                    const v315 = v313.fields[1] as any;
                    const v320: FSharpList<string> = method73(v313.fields[0] as any, empty<string>());
                    v346 = US9_US9_0(join("", delay<string>((): Iterable<string> => v320)), v315, v316, v317, v318);
                }
                else {
                    v346 = US9_US9_1(v313.fields[0] as any);
                }
                if ((v346.tag as int32) === /* US9_0 */ 0) {
                    const v351: int32 = (v346.fields[4] as any) | 0;
                    const v350: int32 = (v346.fields[3] as any) | 0;
                    const v349 = v346.fields[2] as any;
                    const v348 = v346.fields[1] as any;
                    const v347 = v346.fields[0] as any;
                    let v512: US8_$union;
                    if ("" === v348) {
                        v512 = US8_US8_1("parsing.p_char / unexpected end of input / " + method25("\"", v349, v350, v351));
                    }
                    else {
                        const v362: string = v348[0];
                        if (v362 === "\"") {
                            const v374 = 1;
                            const v395: int32 = (v348.length - 1) | 0;
                            const v397: string = v348.slice(v374, v395 + 1);
                            const v403: string = v362;
                            const patternInput_3: [any, int32, int32] = method27(method26(toInt64(fromInt32(v403.length)), v403, 0n), v349, v350, v351);
                            v512 = US8_US8_0(v362, v397, patternInput_3[0], patternInput_3[1], patternInput_3[2]);
                        }
                        else {
                            const v420: int32 = (v348.indexOf("\n") - 1) | 0;
                            const v435 = 0;
                            const v456: int32 = (((-2 === v420) ? (v348.length + 1) : (v420 + 1)) - 1) | 0;
                            const v458: string = v348.slice(v435, v456 + 1);
                            v512 = US8_US8_1((((((("parsing.p_char / " + method28("\"", v350, v351)) + "\n") + toString_1(v349)) + v458) + "\n") + (method29(v351 - 1, 0)("") + "^")) + "\n");
                        }
                    }
                    if ((v512.tag as int32) === /* US8_0 */ 0) {
                        const v513 = v512.fields[0] as any;
                        v538 = US9_US9_0(v347, v512.fields[1] as any, v512.fields[2] as any, v512.fields[3] as any, v512.fields[4] as any);
                    }
                    else {
                        v538 = US9_US9_1("parsing.between / expected closing delimiter / " + method36(v512.fields[0] as any, v1, v2, v3, v4, v308, v309, v310, v311, v348, v349, v350, v351));
                    }
                }
                else {
                    const v530 = v346.fields[0] as any;
                    v538 = US9_US9_1("parsing.between / expected content");
                }
            }
            else {
                v538 = US9_US9_1(v306.fields[0] as any);
            }
            if ((v538.tag as int32) === /* US9_0 */ 0) {
                const v543: int32 = (v538.fields[4] as any) | 0;
                const v542: int32 = (v538.fields[3] as any) | 0;
                const v541 = v538.fields[2] as any;
                const v540 = v538.fields[1] as any;
                const v539 = v538.fields[0] as any;
                v609 = v538;
            }
            else {
                const v544 = v538.fields[0] as any;
                const v550: US9_$union = method71(v1, v2, v3, v4, UH3_UH3_1((arg10$0040: [string, any, int32, int32]): US9_$union => closure28(undefined, arg10$0040), UH3_UH3_1((arg10$0040_1: [string, any, int32, int32]): US9_$union => closure29(undefined, arg10$0040_1), UH3_UH3_0())));
                let v561: US9_$union;
                if ((v550.tag as int32) === /* US9_0 */ 0) {
                    const v551 = v550.fields[0] as any;
                    v561 = US9_US9_0("", v550.fields[1] as any, v550.fields[2] as any, v550.fields[3] as any, v550.fields[4] as any);
                }
                else {
                    v561 = US9_US9_1(v550.fields[0] as any);
                }
                let v572: US18_$union;
                if ((v561.tag as int32) === /* US9_0 */ 0) {
                    const v562 = v561.fields[0] as any;
                    v572 = method74(UH2_UH2_0(), v561.fields[1] as any, v561.fields[2] as any, v561.fields[3] as any, v561.fields[4] as any);
                }
                else {
                    v572 = US18_US18_1(v561.fields[0] as any);
                }
                if ((v572.tag as int32) === /* US18_0 */ 0) {
                    const v577: int32 = (v572.fields[4] as any) | 0;
                    const v576: int32 = (v572.fields[3] as any) | 0;
                    const v575 = v572.fields[2] as any;
                    const v574 = v572.fields[1] as any;
                    const v579: FSharpList<string> = method73(v572.fields[0] as any, empty<string>());
                    v609 = US9_US9_0(join("", delay<string>((): Iterable<string> => v579)), v574, v575, v576, v577);
                }
                else {
                    v609 = US9_US9_1(v572.fields[0] as any);
                }
            }
        }
        if ((v609.tag as int32) === /* US9_0 */ 0) {
            const v614: int32 = (v609.fields[4] as any) | 0;
            const v613: int32 = (v609.fields[3] as any) | 0;
            const v612 = v609.fields[2] as any;
            const v611 = v609.fields[1] as any;
            const v610 = v609.fields[0] as any;
            const v616: int32 = method40(v611, 0) | 0;
            let v658: US11_$union;
            if (0 === v616) {
                v658 = US11_US11_1("parsing.spaces1 / expected at least one space");
            }
            else {
                const v630: int32 = v616 | 0;
                const v651: int32 = (v611.length - 1) | 0;
                v658 = US11_US11_0(v611.slice(v630, v651 + 1), v612, v613, v614);
            }
            if ((v658.tag as int32) === /* US11_0 */ 0) {
                v0_mut = UH2_UH2_1(v610, v0);
                v1_mut = (v658.fields[0] as any);
                v2_mut = (v658.fields[1] as any);
                v3_mut = (v658.fields[2] as any);
                v4_mut = (v658.fields[3] as any);
                continue method66;
            }
            else {
                const v665 = v658.fields[0] as any;
                return US18_US18_0(method72(v0, UH2_UH2_1(v610, UH2_UH2_0())), v611, v612, v613, v614);
            }
        }
        else {
            const v672 = v609.fields[0] as any;
            return US18_US18_0(method72(v0, UH2_UH2_0()), v1, v2, v3, v4);
        }
        break;
    }
}

export function method65(v0: string): US17_$union {
    let _v0: Option<Option<string>> = undefined;
    _v0 = some(v0);
    const v22: US18_$union = method66(UH2_UH2_0(), defaultArg((_v0 == null) ? (() => {
        throw new Error("optionm\'.of_obj / _v0=None");
    })() : value_12(_v0), ""), StringBuilder_$ctor_Z721C83C5(method24()), 1, 1);
    if ((v22.tag as int32) === /* US18_0 */ 0) {
        const v27: int32 = (v22.fields[4] as any) | 0;
        const v26: int32 = (v22.fields[3] as any) | 0;
        const v25 = v22.fields[2] as any;
        const v24 = v22.fields[1] as any;
        return US17_US17_0(toArray<string>(method73(v22.fields[0] as any, empty<string>())));
    }
    else {
        return US17_US17_1(v22.fields[0] as any);
    }
}

export function closure27(unitVar: void, v0: string): FSharpResult$2_$union<string[], string> {
    const v1: US17_$union = method65(v0);
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


