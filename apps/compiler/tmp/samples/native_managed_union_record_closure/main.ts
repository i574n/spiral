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
type US0_Item = { readonly tag: 1, readonly f0: string, readonly f1: number };
type US0 = US0_Empty | US0_Item;
function US0_Empty(): US0 { return { tag: 0 }; }
function US0_Item(f0: string, f1: number): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function closure0(): ((a0: number) => US0) {
    return (v0: number): US0 => {
        let v1: boolean = v0 === 0;
        if (v1) {
            return US0_Empty();
        } else {
            let v3: string = "managed";
            return US0_Item(v3, 32);
        }
    };
}
function method0(v0: ((a0: number) => US0)): US0 {
    return v0(0);
}
function method1(v0: ((a0: number) => US0)): US0 {
    return v0(1);
}
export function main(): number {
    let v0: ((a0: number) => US0) = closure0();
    let v1: US0 = method0(v0);
    let v7: number;
    switch (v1.tag) {
        case 0: {
            v7 = 3;
            break;
        }
        case 1: {
            let v2: string = v1.f0;
            let v3: number = v1.f1;
            let v4: number = spiral_string_length(v2);
            let v5: number = (v4 + v3) | 0;
            v7 = v5;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v8: US0 = method1(v0);
    let v14: number;
    switch (v8.tag) {
        case 0: {
            v14 = 3;
            break;
        }
        case 1: {
            let v9: string = v8.f0;
            let v10: number = v8.f1;
            let v11: number = spiral_string_length(v9);
            let v12: number = (v11 + v10) | 0;
            v14 = v12;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v15: number = (v7 + v14) | 0;
    return v15;
}
process.exitCode = main();
