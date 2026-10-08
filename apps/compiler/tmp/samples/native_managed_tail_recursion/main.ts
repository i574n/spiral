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
function method1(v0: number, v1: string): string {
    tail: while (true) {
        let v2: number = (v0 - 1) | 0;
        let v3: boolean = v2 === 0;
        if (v3) {
            return v1;
        } else {
            let v4: number = (v2 % 2) | 0;
            let v5: boolean = v4 === 0;
            let v8: string;
            if (v5) {
                let v6: string = "ok";
                v8 = v6;
            } else {
                let v7: string = "go";
                v8 = v7;
            }
            {
                let t0 = v2;
                let t1 = v8;
                v0 = t0;
                v1 = t1;
            }
            continue tail;
        }
    }
}
function method0(): string {
    let v0: number = 1000000;
    let v1: boolean = v0 === 0;
    if (v1) {
        let v2: string = "seed";
        return v2;
    } else {
        let v3: number = (v0 % 2) | 0;
        let v4: boolean = v3 === 0;
        let v7: string;
        if (v4) {
            let v5: string = "ok";
            v7 = v5;
        } else {
            let v6: string = "go";
            v7 = v6;
        }
        return method1(v0, v7);
    }
}
export function main(): number {
    let v0: string = method0();
    let v1: number = spiral_string_length(v0);
    let v2: boolean = v1 === 2;
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
