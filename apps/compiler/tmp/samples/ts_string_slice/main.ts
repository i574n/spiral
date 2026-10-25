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
function middle_0(v0: string): string {
    let v1: string = spiral_string_slice(v0, 1, 3);
    return v1;
}
export function main(): number {
    let v0: string = "alpha";
    let v1: string = middle_0(v0);
    let v2: number = spiral_string_length(v1);
    let v3: boolean = v2 === 3;
    if (v3) {
        let v4: number = spiral_string_index(v1, 0);
        let v5: boolean = v4 === 108;
        if (v5) {
            let v6: number = spiral_string_index(v1, 2);
            let v7: boolean = v6 === 104;
            if (v7) {
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
