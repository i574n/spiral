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
function method0(v0: string): string {
    let v1: string = spiral_string_slice(v0, 0, 1);
    return v1;
}
function method1(v0: string): string {
    let v1: string = spiral_string_slice(v0, 2, 3);
    return v1;
}
export function main(): number {
    let v0: string = "éλ";
    let v1: string = method0(v0);
    let v2: string = method1(v0);
    let v3: string = v1 + v2;
    let v4: number = spiral_string_length(v1);
    let v5: boolean = v4 === 2;
    if (v5) {
        let v6: number = spiral_string_length(v2);
        let v7: boolean = v6 === 2;
        if (v7) {
            let v8: number = spiral_string_length(v3);
            let v9: boolean = v8 === 4;
            if (v9) {
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
