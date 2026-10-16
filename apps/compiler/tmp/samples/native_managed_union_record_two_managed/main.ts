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
function US0_Empty(): US0 { return { tag: 0 }; }
function US0_Item(f0: string, f1: Array<number>): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function closure0(): ((a0: number) => US0) {
    return (v0: number): US0 => {
        let v1: boolean = v0 === 0;
        if (v1) {
            return US0_Empty();
        } else {
            let v3: Array<number> = new Array<number>(2).fill(0);
            spiral_array_set(v3, 0, v0);
            let v4: number = (v0 + 1) | 0;
            spiral_array_set(v3, 1, v4);
            let v5: string = "hi";
            return US0_Item(v5, v3);
        }
    };
}
function method0(v0: ((a0: number) => US0)): US0 {
    return v0(0);
}
function method1(v0: ((a0: number) => US0)): US0 {
    return v0(4);
}
export function main(): number {
    let v0: ((a0: number) => US0) = closure0();
    let v1: US0 = method0(v0);
    let v12: number;
    switch (v1.tag) {
        case 0: {
            v12 = 3;
            break;
        }
        case 1: {
            let v2: string = v1.f0;
            let v3: Array<number> = v1.f1;
            let v4: number = spiral_string_length(v2);
            let v5: number = v3.length;
            let v6: number = (v4 + v5) | 0;
            let v7: number = spiral_array_index(v3, 0);
            let v8: number = (v6 + v7) | 0;
            let v9: number = spiral_array_index(v3, 1);
            let v10: number = (v8 + v9) | 0;
            v12 = v10;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v13: US0 = method1(v0);
    let v24: number;
    switch (v13.tag) {
        case 0: {
            v24 = 3;
            break;
        }
        case 1: {
            let v14: string = v13.f0;
            let v15: Array<number> = v13.f1;
            let v16: number = spiral_string_length(v14);
            let v17: number = v15.length;
            let v18: number = (v16 + v17) | 0;
            let v19: number = spiral_array_index(v15, 0);
            let v20: number = (v18 + v19) | 0;
            let v21: number = spiral_array_index(v15, 1);
            let v22: number = (v20 + v21) | 0;
            v24 = v22;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v25: number = (v12 + v24) | 0;
    let v26: number = (v25 + 26) | 0;
    return v26;
}
process.exitCode = main();
