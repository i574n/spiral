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
function method2(v0: number, v1: string): number {
    let v2: number = (v0 - 1) | 0;
    let v3: boolean = v2 === 0;
    if (v3) {
        let v4: number = spiral_string_length(v1);
        return v4;
    } else {
        return method1(v2, v1);
    }
}
function method1(v0: number, v1: string): number {
    let v2: number = (v0 - 1) | 0;
    let v3: boolean = v2 === 0;
    if (v3) {
        return 99;
    } else {
        return method2(v2, v1);
    }
}
function method0(v0: number, v1: string): number {
    let v2: boolean = v0 === 0;
    let v5: number;
    if (v2) {
        let v3: number = spiral_string_length(v1);
        v5 = v3;
    } else {
        v5 = method1(v0, v1);
    }
    let v6: number = (v5 - 2) | 0;
    return v6;
}
export function main(): number {
    let v0: number = 1000000;
    let v1: number = (v0 % 2) | 0;
    let v2: boolean = v1 === 0;
    let v5: string;
    if (v2) {
        let v3: string = "ok";
        v5 = v3;
    } else {
        let v4: string = "go";
        v5 = v4;
    }
    return method0(v0, v5);
}
process.exitCode = main();
