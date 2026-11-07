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
function left_c0(v0: string, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        const v3: boolean = v2 > 0;
        if (v3) {
            const v4: number = spiral_string_length(v0);
            const v5: number = (v4 + v1) | 0;
            const v6: number = (v5 + v2) | 0;
            return v6;
        } else {
            return 0;
        }
    };
}
function right_c1(v0: string, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        const v3: boolean = v2 > 0;
        if (v3) {
            const v4: number = spiral_string_length(v0);
            const v5: number = (v4 + v1) | 0;
            const v6: number = (v5 + v2) | 0;
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
    const v0: string = "abc";
    const v1: string = "wxyz";
    const v2: number = 2;
    const v3: number = 2;
    const v4: boolean = true;
    let v7: ((a0: number) => number);
    if (v4) {
        v7 = left_c0(v0, v2);
    } else {
        v7 = right_c1(v1, v3);
    }
    return method0(v7);
}
process.exitCode = main();
