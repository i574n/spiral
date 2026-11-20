function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
const spiral_utf8_encoder = new TextEncoder();
const spiral_utf8_decoder = new TextDecoder("utf-8");
let spiral_utf8_last = "";
let spiral_utf8_bytes: Uint8Array = new Uint8Array(0);
function spiral_utf8(value: string): Uint8Array {
    if (value !== spiral_utf8_last) {
        spiral_utf8_bytes = spiral_utf8_encoder.encode(value);
        spiral_utf8_last = value;
    }
    return spiral_utf8_bytes;
}
function spiral_string_length(value: string): number {
    return spiral_utf8(value).length;
}
function spiral_string_index(value: string, index: number): number {
    const bytes = spiral_utf8(value);
    if (!(index >= 0 && index < bytes.length)) throw new RangeError("string index " + index + " out of bounds for length " + bytes.length);
    return bytes[index];
}
function spiral_slice_abort(message: string): never {
    console.error(message);
    process.exit(3);
}
function spiral_string_slice(value: string, from: number, to: number): string {
    const bytes = spiral_utf8(value);
    const length = bytes.length;
    if (from < 0 || from > length || to < from - 1 || to >= length) spiral_slice_abort("string slice " + from + ".." + to + " out of bounds for length " + length);
    if (to < from) return "";
    if ((bytes[from] & 0xc0) === 0x80 || (to + 1 < length && (bytes[to + 1] & 0xc0) === 0x80)) spiral_slice_abort("string slice " + from + ".." + to + " splits a code point");
    return spiral_utf8_decoder.decode(bytes.subarray(from, to + 1));
}
type US0_Empty = { readonly tag: 0 };
type US0_Item = { readonly tag: 1, readonly f0: string, readonly f1: Array<number> };
type US0 = US0_Empty | US0_Item;
const US0_Empty_shared: US0 = { tag: 0 }; function US0_Empty(): US0 { return US0_Empty_shared; }
function US0_Item(f0: string, f1: Array<number>): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function closure1(v0: US0): ((a0: number) => number) {
    return (v1: number): number => {
        let v12: number;
        switch (v0.tag) {
            case 0: {
                v12 = 3;
                break;
            }
            case 1: {
                const v2: string = v0.f0;
                const v3: Array<number> = v0.f1;
                const v4: number = spiral_string_length(v2);
                const v5: number = v3.length;
                const v6: number = (v4 + v5) | 0;
                let v7: number = spiral_array_index(v3, 0);
                const v8: number = (v6 + v7) | 0;
                const v9: number = spiral_array_index(v3, 1);
                const v10: number = (v8 + v9) | 0;
                v12 = v10;
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
        const v13: number = (v12 + v1) | 0;
        return v13;
    };
}
function closure0(): ((a0: number) => ((a0: number) => number)) {
    return (v0: number): ((a0: number) => number) => {
        const v1: Array<number> = new Array<number>(2).fill(0);
        spiral_array_set(v1, 0, v0);
        const v2: number = (v0 + 1) | 0;
        spiral_array_set(v1, 1, v2);
        const v3: boolean = v0 === 0;
        let v7: US0;
        if (v3) {
            v7 = US0_Empty();
        } else {
            const v5: string = "hi";
            v7 = US0_Item(v5, v1);
        }
        return closure1(v7);
    };
}
function method0(v0: ((a0: number) => ((a0: number) => number))): ((a0: number) => number) {
    return v0(0);
}
function method1(v0: ((a0: number) => ((a0: number) => number))): ((a0: number) => number) {
    return v0(4);
}
function method4(v0: ((a0: number) => number)): number {
    const v1: number = v0(2);
    const v2: number = (v1 + 5) | 0;
    return v2;
}
function method3(v0: ((a0: number) => number)): number {
    const v1: number = v0(1);
    const v2: number = method4(v0);
    const v3: number = (v1 + v2) | 0;
    return v3;
}
function method2(v0: ((a0: number) => number), v1: ((a0: number) => number)): number {
    const v2: number = v0(5);
    const v3: number = method3(v1);
    const v4: number = (v2 + v3) | 0;
    return v4;
}
export function main(): number {
    const v0: ((a0: number) => ((a0: number) => number)) = closure0();
    const v1: ((a0: number) => number) = method0(v0);
    const v2: ((a0: number) => number) = method1(v0);
    return method2(v1, v2);
}
process.exitCode = main();
