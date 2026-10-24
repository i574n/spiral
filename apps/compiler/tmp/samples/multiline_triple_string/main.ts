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
    const v0: number = 16;
    const v1: string = "x\ny";
    const v2: string = "say \"hi\"";
    const v3: string = "a \"\"\" b";
    const v4: string = "first\n    second\n\nthird";
    const v5: string = "ab\ncd";
    const v6: string = "a \"b\" c";
    const v7: string = "";
    const v8: string = "a\\nb";
    const v9: string = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented";
    const v10: string = "\ntop\n\nlevel";
    const v11: number = spiral_string_length(v6);
    const v12: boolean = v11 !== 7;
    if (v12) {
        return 1;
    } else {
        const v13: number = spiral_string_index(v6, 2);
        const v14: boolean = v13 !== 34;
        if (v14) {
            return 2;
        } else {
            const v15: number = spiral_string_length(v7);
            const v16: boolean = v15 !== 0;
            if (v16) {
                return 3;
            } else {
                const v17: number = spiral_string_length(v8);
                const v18: boolean = v17 !== 4;
                if (v18) {
                    return 4;
                } else {
                    const v19: number = spiral_string_index(v8, 1);
                    const v20: boolean = v19 !== 92;
                    if (v20) {
                        return 5;
                    } else {
                        const v21: number = spiral_string_length(v9);
                        const v22: boolean = v21 !== 83;
                        if (v22) {
                            return 6;
                        } else {
                            const v23: number = spiral_string_index(v9, 5);
                            const v24: boolean = v23 !== 10;
                            if (v24) {
                                return 7;
                            } else {
                                const v25: number = spiral_string_index(v9, 37);
                                const v26: boolean = v25 !== 10;
                                if (v26) {
                                    return 8;
                                } else {
                                    const v27: number = spiral_string_index(v9, 38);
                                    const v28: boolean = v27 !== 10;
                                    if (v28) {
                                        return 9;
                                    } else {
                                        const v29: number = spiral_string_index(v9, 39);
                                        const v30: boolean = v29 !== 36;
                                        if (v30) {
                                            return 10;
                                        } else {
                                            const v31: number = spiral_string_index(v9, 57);
                                            const v32: boolean = v31 !== 105;
                                            if (v32) {
                                                return 11;
                                            } else {
                                                const v33: number = spiral_string_index(v9, 82);
                                                const v34: boolean = v33 !== 100;
                                                if (v34) {
                                                    return 12;
                                                } else {
                                                    const v35: number = spiral_string_length(v10);
                                                    const v36: boolean = v35 !== 11;
                                                    if (v36) {
                                                        return 13;
                                                    } else {
                                                        const v37: number = spiral_string_index(v10, 0);
                                                        const v38: boolean = v37 !== 10;
                                                        if (v38) {
                                                            return 14;
                                                        } else {
                                                            const v39: number = spiral_string_index(v10, 5);
                                                            const v40: boolean = v39 !== 10;
                                                            if (v40) {
                                                                return 15;
                                                            } else {
                                                                const v41: boolean = v0 !== 16;
                                                                if (v41) {
                                                                    return 16;
                                                                } else {
                                                                    const v42: number = spiral_string_length(v1);
                                                                    const v43: boolean = v42 !== 3;
                                                                    if (v43) {
                                                                        return 17;
                                                                    } else {
                                                                        const v44: number = spiral_string_length(v2);
                                                                        const v45: boolean = v44 !== 8;
                                                                        if (v45) {
                                                                            return 18;
                                                                        } else {
                                                                            const v46: number = spiral_string_index(v2, 7);
                                                                            const v47: boolean = v46 !== 34;
                                                                            if (v47) {
                                                                                return 19;
                                                                            } else {
                                                                                const v48: number = spiral_string_length(v3);
                                                                                const v49: boolean = v48 !== 7;
                                                                                if (v49) {
                                                                                    return 20;
                                                                                } else {
                                                                                    const v50: number = spiral_string_index(v3, 4);
                                                                                    const v51: boolean = v50 !== 34;
                                                                                    if (v51) {
                                                                                        return 21;
                                                                                    } else {
                                                                                        const v52: number = spiral_string_length(v4);
                                                                                        const v53: boolean = v52 !== 23;
                                                                                        if (v53) {
                                                                                            return 22;
                                                                                        } else {
                                                                                            const v54: number = spiral_string_index(v4, 6);
                                                                                            const v55: boolean = v54 !== 32;
                                                                                            if (v55) {
                                                                                                return 23;
                                                                                            } else {
                                                                                                const v56: number = spiral_string_index(v4, 10);
                                                                                                const v57: boolean = v56 !== 115;
                                                                                                if (v57) {
                                                                                                    return 24;
                                                                                                } else {
                                                                                                    const v58: number = spiral_string_index(v4, 17);
                                                                                                    const v59: boolean = v58 !== 10;
                                                                                                    if (v59) {
                                                                                                        return 25;
                                                                                                    } else {
                                                                                                        const v60: number = spiral_string_index(v4, 22);
                                                                                                        const v61: boolean = v60 !== 100;
                                                                                                        if (v61) {
                                                                                                            return 26;
                                                                                                        } else {
                                                                                                            const v62: number = spiral_string_length(v5);
                                                                                                            const v63: boolean = v62 !== 5;
                                                                                                            if (v63) {
                                                                                                                return 27;
                                                                                                            } else {
                                                                                                                const v64: number = spiral_string_index(v5, 3);
                                                                                                                const v65: boolean = v64 !== 99;
                                                                                                                if (v65) {
                                                                                                                    return 28;
                                                                                                                } else {
                                                                                                                    return 0;
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
process.exitCode = main();
