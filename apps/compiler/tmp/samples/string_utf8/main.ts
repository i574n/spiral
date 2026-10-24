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
    const v0: string = "é";
    const v1: number = spiral_string_length(v0);
    const v2: number = spiral_string_index(v0, 0);
    const v3: number = spiral_string_index(v0, 1);
    const v4: string = "x";
    const v5: string = v0 + v4;
    const v6: number = spiral_string_length(v5);
    const v7: string = "ab";
    const v8: number = spiral_string_index(v7, 0);
    const v9: string = spiral_string_slice(v7, 0, 0);
    const v10: number = spiral_string_length(v9);
    const v11: string = spiral_string_slice(v7, 1, 0);
    const v12: number = spiral_string_length(v11);
    const v13: string = spiral_string_slice(v0, 0, 1);
    const v14: number = spiral_string_length(v13);
    const v15: boolean = v2 === v3;
    if (v15) {
        return 1;
    } else {
        const v16: boolean = v1 === 2;
        let v18: boolean;
        if (v16) {
            const v17: boolean = v8 === 97;
            v18 = v17;
        } else {
            v18 = false;
        }
        let v20: boolean;
        if (v18) {
            const v19: boolean = v6 === 3;
            v20 = v19;
        } else {
            v20 = false;
        }
        let v22: boolean;
        if (v20) {
            const v21: boolean = v10 === 1;
            v22 = v21;
        } else {
            v22 = false;
        }
        let v24: boolean;
        if (v22) {
            const v23: boolean = v12 === 0;
            v24 = v23;
        } else {
            v24 = false;
        }
        let v26: boolean;
        if (v24) {
            const v25: boolean = v14 === 2;
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
