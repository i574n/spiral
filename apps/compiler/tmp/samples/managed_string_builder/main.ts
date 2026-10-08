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
function method2(v0: number, v1: string, v2: string): string {
    tail: while (true) {
        let v3: number = (v0 - 1) | 0;
        let v4: string = v1 + v2;
        let v5: boolean = v3 === 0;
        if (v5) {
            return v4;
        } else {
            let v6: number = (v3 % 2) | 0;
            let v7: boolean = v6 === 0;
            let v10: string;
            if (v7) {
                let v8: string = "ab";
                v10 = v8;
            } else {
                let v9: string = "c";
                v10 = v9;
            }
            {
                let t0 = v3;
                let t1 = v4;
                let t2 = v10;
                v0 = t0;
                v1 = t1;
                v2 = t2;
            }
            continue tail;
        }
    }
}
function method1(v0: number, v1: string): string {
    let v2: number = (v0 - 1) | 0;
    let v3: string = "" + v1;
    let v4: boolean = v2 === 0;
    if (v4) {
        return v3;
    } else {
        let v5: number = (v2 % 2) | 0;
        let v6: boolean = v5 === 0;
        let v9: string;
        if (v6) {
            let v7: string = "ab";
            v9 = v7;
        } else {
            let v8: string = "c";
            v9 = v8;
        }
        return method2(v2, v3, v9);
    }
}
function method0(): string {
    let v0: number = 4;
    let v1: boolean = v0 === 0;
    if (v1) {
        let v2: string = "";
        return v2;
    } else {
        let v3: number = (v0 % 2) | 0;
        let v4: boolean = v3 === 0;
        let v7: string;
        if (v4) {
            let v5: string = "ab";
            v7 = v5;
        } else {
            let v6: string = "c";
            v7 = v6;
        }
        return method1(v0, v7);
    }
}
export function main(): number {
    let v0: string = method0();
    let v1: number = spiral_string_length(v0);
    let v2: boolean = v1 === 6;
    if (v2) {
        let v3: number = spiral_string_index(v0, 0);
        let v4: boolean = v3 === 97;
        if (v4) {
            let v5: number = spiral_string_index(v0, 5);
            let v6: boolean = v5 === 99;
            if (v6) {
                return 0;
            } else {
                return 1;
            }
        } else {
            return 2;
        }
    } else {
        return 3;
    }
}
process.exitCode = main();
