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
    let v0: number = 16;
    let v1: string = "x\ny";
    let v2: string = "say \"hi\"";
    let v3: string = "a \"\"\" b";
    let v4: string = "first\n    second\n\nthird";
    let v5: string = "ab\ncd";
    let v6: string = "a \"b\" c";
    let v7: string = "";
    let v8: string = "a\\nb";
    let v9: string = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented";
    let v10: string = "\ntop\n\nlevel";
    let v11: number = spiral_string_length(v6);
    let v12: boolean = v11 !== 7;
    if (v12) {
        return 1;
    } else {
        let v13: number = spiral_string_index(v6, 2);
        let v14: boolean = v13 !== 34;
        if (v14) {
            return 2;
        } else {
            let v15: number = spiral_string_length(v7);
            let v16: boolean = v15 !== 0;
            if (v16) {
                return 3;
            } else {
                let v17: number = spiral_string_length(v8);
                let v18: boolean = v17 !== 4;
                if (v18) {
                    return 4;
                } else {
                    let v19: number = spiral_string_index(v8, 1);
                    let v20: boolean = v19 !== 92;
                    if (v20) {
                        return 5;
                    } else {
                        let v21: number = spiral_string_length(v9);
                        let v22: boolean = v21 !== 83;
                        if (v22) {
                            return 6;
                        } else {
                            let v23: number = spiral_string_index(v9, 5);
                            let v24: boolean = v23 !== 10;
                            if (v24) {
                                return 7;
                            } else {
                                let v25: number = spiral_string_index(v9, 37);
                                let v26: boolean = v25 !== 10;
                                if (v26) {
                                    return 8;
                                } else {
                                    let v27: number = spiral_string_index(v9, 38);
                                    let v28: boolean = v27 !== 10;
                                    if (v28) {
                                        return 9;
                                    } else {
                                        let v29: number = spiral_string_index(v9, 39);
                                        let v30: boolean = v29 !== 36;
                                        if (v30) {
                                            return 10;
                                        } else {
                                            let v31: number = spiral_string_index(v9, 57);
                                            let v32: boolean = v31 !== 105;
                                            if (v32) {
                                                return 11;
                                            } else {
                                                let v33: number = spiral_string_index(v9, 82);
                                                let v34: boolean = v33 !== 100;
                                                if (v34) {
                                                    return 12;
                                                } else {
                                                    let v35: number = spiral_string_length(v10);
                                                    let v36: boolean = v35 !== 11;
                                                    if (v36) {
                                                        return 13;
                                                    } else {
                                                        let v37: number = spiral_string_index(v10, 0);
                                                        let v38: boolean = v37 !== 10;
                                                        if (v38) {
                                                            return 14;
                                                        } else {
                                                            let v39: number = spiral_string_index(v10, 5);
                                                            let v40: boolean = v39 !== 10;
                                                            if (v40) {
                                                                return 15;
                                                            } else {
                                                                let v41: boolean = v0 !== 16;
                                                                if (v41) {
                                                                    return 16;
                                                                } else {
                                                                    let v42: number = spiral_string_length(v1);
                                                                    let v43: boolean = v42 !== 3;
                                                                    if (v43) {
                                                                        return 17;
                                                                    } else {
                                                                        let v44: number = spiral_string_length(v2);
                                                                        let v45: boolean = v44 !== 8;
                                                                        if (v45) {
                                                                            return 18;
                                                                        } else {
                                                                            let v46: number = spiral_string_index(v2, 7);
                                                                            let v47: boolean = v46 !== 34;
                                                                            if (v47) {
                                                                                return 19;
                                                                            } else {
                                                                                let v48: number = spiral_string_length(v3);
                                                                                let v49: boolean = v48 !== 7;
                                                                                if (v49) {
                                                                                    return 20;
                                                                                } else {
                                                                                    let v50: number = spiral_string_index(v3, 4);
                                                                                    let v51: boolean = v50 !== 34;
                                                                                    if (v51) {
                                                                                        return 21;
                                                                                    } else {
                                                                                        let v52: number = spiral_string_length(v4);
                                                                                        let v53: boolean = v52 !== 23;
                                                                                        if (v53) {
                                                                                            return 22;
                                                                                        } else {
                                                                                            let v54: number = spiral_string_index(v4, 6);
                                                                                            let v55: boolean = v54 !== 32;
                                                                                            if (v55) {
                                                                                                return 23;
                                                                                            } else {
                                                                                                let v56: number = spiral_string_index(v4, 10);
                                                                                                let v57: boolean = v56 !== 115;
                                                                                                if (v57) {
                                                                                                    return 24;
                                                                                                } else {
                                                                                                    let v58: number = spiral_string_index(v4, 17);
                                                                                                    let v59: boolean = v58 !== 10;
                                                                                                    if (v59) {
                                                                                                        return 25;
                                                                                                    } else {
                                                                                                        let v60: number = spiral_string_index(v4, 22);
                                                                                                        let v61: boolean = v60 !== 100;
                                                                                                        if (v61) {
                                                                                                            return 26;
                                                                                                        } else {
                                                                                                            let v62: number = spiral_string_length(v5);
                                                                                                            let v63: boolean = v62 !== 5;
                                                                                                            if (v63) {
                                                                                                                return 27;
                                                                                                            } else {
                                                                                                                let v64: number = spiral_string_index(v5, 3);
                                                                                                                let v65: boolean = v64 !== 99;
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
