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
export function main(): number {
    let v0: string = "é";
    let v1: number = spiral_string_length(v0);
    let v2: number = spiral_string_index(v0, 0);
    let v3: number = spiral_string_index(v0, 1);
    let v4: string = "x";
    let v5: string = v0 + v4;
    let v6: number = spiral_string_length(v5);
    let v7: string = "ab";
    let v8: number = spiral_string_index(v7, 0);
    let v9: string = spiral_string_slice(v7, 0, 0);
    let v10: number = spiral_string_length(v9);
    let v11: string = spiral_string_slice(v7, 1, 0);
    let v12: number = spiral_string_length(v11);
    let v13: string = spiral_string_slice(v0, 0, 1);
    let v14: number = spiral_string_length(v13);
    let v15: boolean = v2 === v3;
    if (v15) {
        return 1;
    } else {
        let v16: boolean = v1 === 2;
        let v18: boolean;
        if (v16) {
            let v17: boolean = v8 === 97;
            v18 = v17;
        } else {
            v18 = false;
        }
        let v20: boolean;
        if (v18) {
            let v19: boolean = v6 === 3;
            v20 = v19;
        } else {
            v20 = false;
        }
        let v22: boolean;
        if (v20) {
            let v21: boolean = v10 === 1;
            v22 = v21;
        } else {
            v22 = false;
        }
        let v24: boolean;
        if (v22) {
            let v23: boolean = v12 === 0;
            v24 = v23;
        } else {
            v24 = false;
        }
        let v26: boolean;
        if (v24) {
            let v25: boolean = v14 === 2;
            v26 = v25;
        } else {
            v26 = false;
        }
        if (v26) {
            return 0;
        } else {
            return 1;
        }
    }
}
process.exitCode = main();
