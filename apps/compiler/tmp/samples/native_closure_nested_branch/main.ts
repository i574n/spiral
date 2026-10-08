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
// The C backend's StringSlice: inclusive bounds, an empty slice when to = from - 1, and a failure for bounds outside
// the string or inside a code point: exit code 3, like C's abort() and the Rust/Delphi helpers (in run_main.mjs's
// worker, process.exit ends the worker with that code).
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
function closure0(v0: string, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        let v3: boolean = v2 > 0;
        if (v3) {
            let v4: number = spiral_string_length(v0);
            let v5: number = (v4 + v1) | 0;
            let v6: number = (v5 + v2) | 0;
            return v6;
        } else {
            return 0;
        }
    };
}
function closure1(v0: string, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        let v3: boolean = v2 > 0;
        if (v3) {
            let v4: number = spiral_string_length(v0);
            let v5: number = (v4 + v1) | 0;
            let v6: number = (v5 + v2) | 0;
            let v7: number = (v6 - 1) | 0;
            return v7;
        } else {
            return (-1);
        }
    };
}
function method0(v0: ((a0: number) => number)): number {
    return v0(37);
}
export function main(): number {
    let v0: string = "abc";
    let v1: string = "wxyz";
    let v2: number = 2;
    let v3: number = 2;
    let v4: boolean = true;
    let v7: ((a0: number) => number);
    if (v4) {
        v7 = closure0(v0, v2);
    } else {
        v7 = closure1(v1, v3);
    }
    return method0(v7);
}
process.exitCode = main();
