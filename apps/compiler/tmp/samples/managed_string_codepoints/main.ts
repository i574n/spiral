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
function runtime_byte_0(v0: string, v1: number): number {
    const v2: number = spiral_string_index(v0, v1);
    return v2;
}
function codepoint_length_loop_1(v0: string, v1: number, v2: number, v3: number, v4: number, v5: number): number {
    tail: while (true) {
        const v6: boolean = v3 === v5;
        if (v6) {
            return v4;
        } else {
            const v7: number = spiral_string_index(v0, v3);
            const v8: boolean = v7 < v1;
            let v10: boolean;
            if (v8) {
                v10 = false;
            } else {
                const v9: boolean = v7 < v2;
                v10 = v9;
            }
            let v12: number;
            if (v10) {
                v12 = v4;
            } else {
                let v11: number = (v4 + 1) | 0;
                v12 = v11;
            }
            const v13: number = (v3 + 1) | 0;
            v3 = v13;
            v4 = v12;
            continue tail;
        }
    }
}
function codepoint_byte_offset_loop_2(v0: string, v1: number, v2: number, v3: number, v4: number, v5: number, v6: number): number {
    tail: while (true) {
        const v7: boolean = v4 === v6;
        if (v7) {
            return v6;
        } else {
            const v8: number = spiral_string_index(v0, v4);
            const v9: boolean = v8 < v1;
            let v11: boolean;
            if (v9) {
                v11 = false;
            } else {
                let v10: boolean = v8 < v2;
                v11 = v10;
            }
            if (v11) {
                let v12: number = (v4 + 1) | 0;
                v4 = v12;
                continue tail;
            } else {
                const v14: boolean = v5 === v3;
                if (v14) {
                    return v4;
                } else {
                    const v15: number = (v4 + 1) | 0;
                    const v16: number = (v5 + 1) | 0;
                    v4 = v15;
                    v5 = v16;
                    continue tail;
                }
            }
        }
    }
}
export function main(): number {
    const v0: string = "À";
    const v1: number = 1;
    const v2: number = runtime_byte_0(v0, v1);
    let v3: string = "©";
    let v4: number = 0;
    let v5: number = runtime_byte_0(v3, v4);
    const v6: string = "Aéλ🙂Z";
    const v7: number = 0;
    const v8: number = 0;
    const v9: number = 10;
    let v10: number = codepoint_length_loop_1(v6, v2, v5, v7, v8, v9);
    let v11: number = 1;
    let v12: number = runtime_byte_0(v0, v11);
    const v13: number = 0;
    const v14: number = runtime_byte_0(v3, v13);
    const v15: number = 1;
    const v16: number = 0;
    const v17: number = 0;
    const v18: number = 10;
    const v19: number = codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18);
    const v20: number = 1;
    const v21: number = runtime_byte_0(v0, v20);
    const v22: number = 0;
    const v23: number = runtime_byte_0(v3, v22);
    const v24: number = 2;
    const v25: number = 0;
    const v26: number = 0;
    const v27: number = 10;
    const v28: number = codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27);
    const v29: number = (v28 - 1) | 0;
    const v30: string = spiral_string_slice("Aéλ🙂Z", v19, v29);
    const v31: number = 1;
    const v32: number = runtime_byte_0(v0, v31);
    const v33: number = 0;
    const v34: number = runtime_byte_0(v3, v33);
    const v35: number = 3;
    const v36: number = 0;
    const v37: number = 0;
    const v38: number = 10;
    const v39: number = codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38);
    const v40: number = 1;
    const v41: number = runtime_byte_0(v0, v40);
    const v42: number = 0;
    const v43: number = runtime_byte_0(v3, v42);
    const v44: number = 4;
    const v45: number = 0;
    const v46: number = 0;
    const v47: number = 10;
    const v48: number = codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47);
    const v49: number = (v48 - 1) | 0;
    const v50: string = spiral_string_slice("Aéλ🙂Z", v39, v49);
    const v51: number = 1;
    const v52: number = runtime_byte_0(v0, v51);
    const v53: number = 0;
    const v54: number = runtime_byte_0(v3, v53);
    const v55: number = 1;
    const v56: number = 0;
    const v57: number = 0;
    const v58: number = 10;
    const v59: number = codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58);
    const v60: number = 1;
    const v61: number = runtime_byte_0(v0, v60);
    const v62: number = 0;
    const v63: number = runtime_byte_0(v3, v62);
    const v64: number = 4;
    const v65: number = 0;
    const v66: number = 0;
    const v67: number = 10;
    const v68: number = codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67);
    const v69: number = (v68 - 1) | 0;
    const v70: string = spiral_string_slice("Aéλ🙂Z", v59, v69);
    const v71: number = 1;
    const v72: number = runtime_byte_0(v0, v71);
    const v73: number = 0;
    const v74: number = runtime_byte_0(v3, v73);
    const v75: number = 3;
    const v76: number = 0;
    const v77: number = 0;
    const v78: number = 10;
    const v79: number = codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78);
    const v80: number = 0;
    const v81: number = runtime_byte_0(v30, v80);
    const v82: string = "é";
    const v83: number = 0;
    const v84: number = runtime_byte_0(v82, v83);
    const v85: number = 3;
    const v86: number = runtime_byte_0(v50, v85);
    const v87: string = "🙂";
    const v88: number = 3;
    const v89: number = runtime_byte_0(v87, v88);
    const v90: boolean = v10 === 5;
    if (v90) {
        const v91: number = spiral_string_length(v30);
        const v92: boolean = v91 === 2;
        if (v92) {
            const v93: boolean = v81 === v84;
            if (v93) {
                const v94: number = spiral_string_length(v50);
                const v95: boolean = v94 === 4;
                if (v95) {
                    const v96: boolean = v86 === v89;
                    if (v96) {
                        const v97: number = spiral_string_length(v70);
                        const v98: boolean = v97 === 8;
                        if (v98) {
                            const v99: boolean = v79 === 5;
                            if (v99) {
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
                } else {
                    return 4;
                }
            } else {
                return 5;
            }
        } else {
            return 6;
        }
    } else {
        return 7;
    }
}
process.exitCode = main();
