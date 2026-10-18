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
    let v12: boolean = v11 === 7;
    let v13: boolean = v12 !== true;
    if (v13) {
        return 1;
    } else {
        let v14: number = spiral_string_index(v6, 2);
        let v15: boolean = v14 === 34;
        let v16: boolean = v15 !== true;
        if (v16) {
            return 2;
        } else {
            let v17: number = spiral_string_length(v7);
            let v18: boolean = v17 === 0;
            let v19: boolean = v18 !== true;
            if (v19) {
                return 3;
            } else {
                let v20: number = spiral_string_length(v8);
                let v21: boolean = v20 === 4;
                let v22: boolean = v21 !== true;
                if (v22) {
                    return 4;
                } else {
                    let v23: number = spiral_string_index(v8, 1);
                    let v24: boolean = v23 === 92;
                    let v25: boolean = v24 !== true;
                    if (v25) {
                        return 5;
                    } else {
                        let v26: number = spiral_string_length(v9);
                        let v27: boolean = v26 === 83;
                        let v28: boolean = v27 !== true;
                        if (v28) {
                            return 6;
                        } else {
                            let v29: number = spiral_string_index(v9, 5);
                            let v30: boolean = v29 === 10;
                            let v31: boolean = v30 !== true;
                            if (v31) {
                                return 7;
                            } else {
                                let v32: number = spiral_string_index(v9, 37);
                                let v33: boolean = v32 === 10;
                                let v34: boolean = v33 !== true;
                                if (v34) {
                                    return 8;
                                } else {
                                    let v35: number = spiral_string_index(v9, 38);
                                    let v36: boolean = v35 === 10;
                                    let v37: boolean = v36 !== true;
                                    if (v37) {
                                        return 9;
                                    } else {
                                        let v38: number = spiral_string_index(v9, 39);
                                        let v39: boolean = v38 === 36;
                                        let v40: boolean = v39 !== true;
                                        if (v40) {
                                            return 10;
                                        } else {
                                            let v41: number = spiral_string_index(v9, 57);
                                            let v42: boolean = v41 === 105;
                                            let v43: boolean = v42 !== true;
                                            if (v43) {
                                                return 11;
                                            } else {
                                                let v44: number = spiral_string_index(v9, 82);
                                                let v45: boolean = v44 === 100;
                                                let v46: boolean = v45 !== true;
                                                if (v46) {
                                                    return 12;
                                                } else {
                                                    let v47: number = spiral_string_length(v10);
                                                    let v48: boolean = v47 === 11;
                                                    let v49: boolean = v48 !== true;
                                                    if (v49) {
                                                        return 13;
                                                    } else {
                                                        let v50: number = spiral_string_index(v10, 0);
                                                        let v51: boolean = v50 === 10;
                                                        let v52: boolean = v51 !== true;
                                                        if (v52) {
                                                            return 14;
                                                        } else {
                                                            let v53: number = spiral_string_index(v10, 5);
                                                            let v54: boolean = v53 === 10;
                                                            let v55: boolean = v54 !== true;
                                                            if (v55) {
                                                                return 15;
                                                            } else {
                                                                let v56: boolean = v0 === 16;
                                                                let v57: boolean = v56 !== true;
                                                                if (v57) {
                                                                    return 16;
                                                                } else {
                                                                    let v58: number = spiral_string_length(v1);
                                                                    let v59: boolean = v58 === 3;
                                                                    let v60: boolean = v59 !== true;
                                                                    if (v60) {
                                                                        return 17;
                                                                    } else {
                                                                        let v61: number = spiral_string_length(v2);
                                                                        let v62: boolean = v61 === 8;
                                                                        let v63: boolean = v62 !== true;
                                                                        if (v63) {
                                                                            return 18;
                                                                        } else {
                                                                            let v64: number = spiral_string_index(v2, 7);
                                                                            let v65: boolean = v64 === 34;
                                                                            let v66: boolean = v65 !== true;
                                                                            if (v66) {
                                                                                return 19;
                                                                            } else {
                                                                                let v67: number = spiral_string_length(v3);
                                                                                let v68: boolean = v67 === 7;
                                                                                let v69: boolean = v68 !== true;
                                                                                if (v69) {
                                                                                    return 20;
                                                                                } else {
                                                                                    let v70: number = spiral_string_index(v3, 4);
                                                                                    let v71: boolean = v70 === 34;
                                                                                    let v72: boolean = v71 !== true;
                                                                                    if (v72) {
                                                                                        return 21;
                                                                                    } else {
                                                                                        let v73: number = spiral_string_length(v4);
                                                                                        let v74: boolean = v73 === 23;
                                                                                        let v75: boolean = v74 !== true;
                                                                                        if (v75) {
                                                                                            return 22;
                                                                                        } else {
                                                                                            let v76: number = spiral_string_index(v4, 6);
                                                                                            let v77: boolean = v76 === 32;
                                                                                            let v78: boolean = v77 !== true;
                                                                                            if (v78) {
                                                                                                return 23;
                                                                                            } else {
                                                                                                let v79: number = spiral_string_index(v4, 10);
                                                                                                let v80: boolean = v79 === 115;
                                                                                                let v81: boolean = v80 !== true;
                                                                                                if (v81) {
                                                                                                    return 24;
                                                                                                } else {
                                                                                                    let v82: number = spiral_string_index(v4, 17);
                                                                                                    let v83: boolean = v82 === 10;
                                                                                                    let v84: boolean = v83 !== true;
                                                                                                    if (v84) {
                                                                                                        return 25;
                                                                                                    } else {
                                                                                                        let v85: number = spiral_string_index(v4, 22);
                                                                                                        let v86: boolean = v85 === 100;
                                                                                                        let v87: boolean = v86 !== true;
                                                                                                        if (v87) {
                                                                                                            return 26;
                                                                                                        } else {
                                                                                                            let v88: number = spiral_string_length(v5);
                                                                                                            let v89: boolean = v88 === 5;
                                                                                                            let v90: boolean = v89 !== true;
                                                                                                            if (v90) {
                                                                                                                return 27;
                                                                                                            } else {
                                                                                                                let v91: number = spiral_string_index(v5, 3);
                                                                                                                let v92: boolean = v91 === 99;
                                                                                                                let v93: boolean = v92 !== true;
                                                                                                                if (v93) {
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
