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
    let v1: string = "x";
    let v2: string = v0 + v1;
    let v3: string = "éx";
    let v4: string = "éy";
    let v5: string = "";
    let v6: string = spiral_string_slice(v3, 1, 0);
    let v7: boolean = v2 === v3;
    let v9: boolean;
    if (v7) {
        let v8: boolean = v2 !== v4;
        v9 = v8;
    } else {
        v9 = false;
    }
    let v11: boolean;
    if (v9) {
        let v10: boolean = v0 !== v3;
        v11 = v10;
    } else {
        v11 = false;
    }
    let v13: boolean;
    if (v11) {
        let v12: boolean = v5 === v6;
        v13 = v12;
    } else {
        v13 = false;
    }
    let v15: boolean;
    if (v13) {
        let v14: boolean = v5 !== v0;
        v15 = v14;
    } else {
        v15 = false;
    }
    if (v15) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
