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
type UH0_Empty = { readonly tag: 0 };
type UH0_Node = { readonly tag: 1, readonly f0: string, readonly f1: UH0, readonly f2: UH0 };
type UH0 = UH0_Empty | UH0_Node;
const UH0_Empty_shared: UH0 = { tag: 0 }; function UH0_Empty(): UH0 { return UH0_Empty_shared; }
function UH0_Node(f0: string, f1: UH0, f2: UH0): UH0 { return { tag: 1, f0: f0, f1: f1, f2: f2 }; }
function score_0(v0: UH0): number {
    switch (v0.tag) {
        case 0: {
            return 0;
        }
        case 1: {
            const v1: string = v0.f0;
            const v2: UH0 = v0.f1;
            const v3: UH0 = v0.f2;
            const v4: number = spiral_string_length(v1);
            const v5: number = score_0(v2);
            const v6: number = (v4 + v5) | 0;
            const v7: number = score_0(v3);
            const v8: number = (v6 + v7) | 0;
            return v8;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: string = "ab";
    const v1: string = "qwe";
    const v2: UH0 = UH0_Empty();
    const v3: UH0 = UH0_Node(v1, v2, v2);
    const v4: UH0 = UH0_Node(v0, v3, v3);
    const v5: number = score_0(v4);
    const v6: UH0 = UH0_Empty();
    const v7: UH0 = UH0_Node(v1, v6, v6);
    const v8: UH0 = UH0_Node(v0, v7, v7);
    const v9: number = score_0(v8);
    const v10: number = (v5 + v9) | 0;
    const v11: number = (v10 - 16) | 0;
    return v11;
}
process.exitCode = main();
