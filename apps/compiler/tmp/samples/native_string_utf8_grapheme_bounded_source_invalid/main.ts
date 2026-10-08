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
// The C backend's StringSlice: inclusive bounds, an empty slice when to = from - 1, and a failure for bounds outside
// the string or inside a code point: exit code 3, like C's abort() and the Rust/Delphi helpers (in run_main.mjs's
// worker, process.exit ends the worker with that code).
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
function method1(v0: string, v1: number): number {
    let v2: number = spiral_string_index(v0, v1);
    return v2;
}
function method0(v0: string, v1: number): number {
    let v2: number = spiral_string_length(v0);
    let v3: boolean = v1 < 0;
    if (v3) {
        throw new Error("UTF-8 byte offset is negative.");
    } else {
        let v5: boolean = v1 >= v2;
        if (v5) {
            throw new Error("UTF-8 byte offset is outside the string.");
        } else {
            let v7: number = method1(v0, v1);
            let v8: number = ((uint8_t)v7);
            let v9: boolean = v8 < 128;
            if (v9) {
                return v8;
            } else {
                let v10: boolean = v8 < 194;
                if (v10) {
                    throw new Error("UTF-8 scalar starts with an invalid lead byte.");
                } else {
                    let v12: boolean = v8 < 224;
                    if (v12) {
                        let v13: number = (v1 + 1) | 0;
                        let v14: boolean = v13 >= v2;
                        if (v14) {
                            throw new Error("UTF-8 sequence is truncated.");
                        } else {
                            let v16: number = method1(v0, v13);
                            let v17: number = ((uint8_t)v16);
                            let v18: boolean = v17 < 128;
                            let v20: boolean;
                            if (v18) {
                                v20 = false;
                            } else {
                                let v19: boolean = v17 < 192;
                                v20 = v19;
                            }
                            if (v20) {
                                let v21: number = (v8 - 192) | 0;
                                let v22: number = Math.imul(v21, 64);
                                let v23: number = (v17 - 128) | 0;
                                let v24: number = (v22 + v23) | 0;
                                return v24;
                            } else {
                                throw new Error("UTF-8 sequence has an invalid continuation byte.");
                            }
                        }
                    } else {
                        let v28: boolean = v8 < 240;
                        if (v28) {
                            let v29: number = (v1 + 2) | 0;
                            let v30: boolean = v29 >= v2;
                            if (v30) {
                                throw new Error("UTF-8 sequence is truncated.");
                            } else {
                                let v32: number = (v1 + 1) | 0;
                                let v33: number = method1(v0, v32);
                                let v34: number = ((uint8_t)v33);
                                let v35: number = method1(v0, v29);
                                let v36: number = ((uint8_t)v35);
                                let v37: boolean = v34 < 128;
                                let v39: boolean;
                                if (v37) {
                                    v39 = false;
                                } else {
                                    let v38: boolean = v34 < 192;
                                    v39 = v38;
                                }
                                if (v39) {
                                    let v40: boolean = v36 < 128;
                                    let v42: boolean;
                                    if (v40) {
                                        v42 = false;
                                    } else {
                                        let v41: boolean = v36 < 192;
                                        v42 = v41;
                                    }
                                    if (v42) {
                                        let v43: number = (v8 - 224) | 0;
                                        let v44: number = Math.imul(v43, 4096);
                                        let v45: number = (v34 - 128) | 0;
                                        let v46: number = Math.imul(v45, 64);
                                        let v47: number = (v44 + v46) | 0;
                                        let v48: number = (v36 - 128) | 0;
                                        let v49: number = (v47 + v48) | 0;
                                        let v50: boolean = v49 < 2048;
                                        if (v50) {
                                            throw new Error("UTF-8 sequence is overlong.");
                                        } else {
                                            let v52: boolean = v49 >= 55296;
                                            if (v52) {
                                                let v53: boolean = v49 <= 57343;
                                                if (v53) {
                                                    throw new Error("UTF-8 sequence encodes a surrogate.");
                                                } else {
                                                    return v49;
                                                }
                                            } else {
                                                return v49;
                                            }
                                        }
                                    } else {
                                        throw new Error("UTF-8 sequence has an invalid continuation byte.");
                                    }
                                } else {
                                    throw new Error("UTF-8 sequence has an invalid continuation byte.");
                                }
                            }
                        } else {
                            let v63: boolean = v8 < 245;
                            if (v63) {
                                let v64: number = (v1 + 3) | 0;
                                let v65: boolean = v64 >= v2;
                                if (v65) {
                                    throw new Error("UTF-8 sequence is truncated.");
                                } else {
                                    let v67: number = (v1 + 1) | 0;
                                    let v68: number = method1(v0, v67);
                                    let v69: number = ((uint8_t)v68);
                                    let v70: number = (v1 + 2) | 0;
                                    let v71: number = method1(v0, v70);
                                    let v72: number = ((uint8_t)v71);
                                    let v73: number = method1(v0, v64);
                                    let v74: number = ((uint8_t)v73);
                                    let v75: boolean = v69 < 128;
                                    let v77: boolean;
                                    if (v75) {
                                        v77 = false;
                                    } else {
                                        let v76: boolean = v69 < 192;
                                        v77 = v76;
                                    }
                                    if (v77) {
                                        let v78: boolean = v72 < 128;
                                        let v80: boolean;
                                        if (v78) {
                                            v80 = false;
                                        } else {
                                            let v79: boolean = v72 < 192;
                                            v80 = v79;
                                        }
                                        if (v80) {
                                            let v81: boolean = v74 < 128;
                                            let v83: boolean;
                                            if (v81) {
                                                v83 = false;
                                            } else {
                                                let v82: boolean = v74 < 192;
                                                v83 = v82;
                                            }
                                            if (v83) {
                                                let v84: number = (v8 - 240) | 0;
                                                let v85: number = Math.imul(v84, 262144);
                                                let v86: number = (v69 - 128) | 0;
                                                let v87: number = Math.imul(v86, 4096);
                                                let v88: number = (v85 + v87) | 0;
                                                let v89: number = (v72 - 128) | 0;
                                                let v90: number = Math.imul(v89, 64);
                                                let v91: number = (v88 + v90) | 0;
                                                let v92: number = (v74 - 128) | 0;
                                                let v93: number = (v91 + v92) | 0;
                                                let v94: boolean = v93 < 65536;
                                                if (v94) {
                                                    throw new Error("UTF-8 sequence is overlong.");
                                                } else {
                                                    let v96: boolean = v93 > 1114111;
                                                    if (v96) {
                                                        throw new Error("UTF-8 scalar is above U+10FFFF.");
                                                    } else {
                                                        return v93;
                                                    }
                                                }
                                            } else {
                                                throw new Error("UTF-8 sequence has an invalid continuation byte.");
                                            }
                                        } else {
                                            throw new Error("UTF-8 sequence has an invalid continuation byte.");
                                        }
                                    } else {
                                        throw new Error("UTF-8 sequence has an invalid continuation byte.");
                                    }
                                }
                            } else {
                                throw new Error("UTF-8 scalar starts with an invalid lead byte.");
                            }
                        }
                    }
                }
            }
        }
    }
}
function method2(v0: string, v1: number, v2: number, v3: number): number {
    tail: while (true) {
        let v4: boolean = v1 === v3;
        if (v4) {
            return v2;
        } else {
            let v5: boolean = v1 > v3;
            if (v5) {
                throw new Error("UTF-8 scalar width exceeds the string.");
            } else {
                let v7: number = method0(v0, v1);
                let v8: boolean = v7 < 128;
                let v13: number;
                if (v8) {
                    v13 = 1;
                } else {
                    let v9: boolean = v7 < 2048;
                    if (v9) {
                        v13 = 2;
                    } else {
                        let v10: boolean = v7 < 65536;
                        if (v10) {
                            v13 = 3;
                        } else {
                            v13 = 4;
                        }
                    }
                }
                let v14: boolean = v7 >= 768;
                let v44: boolean;
                if (v14) {
                    let v15: boolean = v7 <= 879;
                    if (v15) {
                        v44 = true;
                    } else {
                        let v16: boolean = v7 >= 6832;
                        if (v16) {
                            let v17: boolean = v7 <= 6911;
                            if (v17) {
                                v44 = true;
                            } else {
                                let v18: boolean = v7 >= 7616;
                                if (v18) {
                                    let v19: boolean = v7 <= 7679;
                                    if (v19) {
                                        v44 = true;
                                    } else {
                                        let v20: boolean = v7 >= 8400;
                                        if (v20) {
                                            let v21: boolean = v7 <= 8447;
                                            if (v21) {
                                                v44 = true;
                                            } else {
                                                let v22: boolean = v7 >= 65024;
                                                if (v22) {
                                                    let v23: boolean = v7 <= 65039;
                                                    if (v23) {
                                                        v44 = true;
                                                    } else {
                                                        let v24: boolean = v7 >= 65056;
                                                        if (v24) {
                                                            let v25: boolean = v7 <= 65071;
                                                            if (v25) {
                                                                v44 = true;
                                                            } else {
                                                                let v26: boolean = v7 >= 127995;
                                                                if (v26) {
                                                                    let v27: boolean = v7 <= 127999;
                                                                    if (v27) {
                                                                        v44 = true;
                                                                    } else {
                                                                        let v28: boolean = v7 >= 917760;
                                                                        if (v28) {
                                                                            let v29: boolean = v7 <= 917999;
                                                                            v44 = v29;
                                                                        } else {
                                                                            v44 = false;
                                                                        }
                                                                    }
                                                                } else {
                                                                    v44 = false;
                                                                }
                                                            }
                                                        } else {
                                                            v44 = false;
                                                        }
                                                    }
                                                } else {
                                                    v44 = false;
                                                }
                                            }
                                        } else {
                                            v44 = false;
                                        }
                                    }
                                } else {
                                    v44 = false;
                                }
                            }
                        } else {
                            v44 = false;
                        }
                    }
                } else {
                    v44 = false;
                }
                let v48: number;
                if (v44) {
                    let v45: boolean = v2 === 0;
                    if (v45) {
                        v48 = 1;
                    } else {
                        v48 = v2;
                    }
                } else {
                    let v47: number = (v2 + 1) | 0;
                    v48 = v47;
                }
                let v49: number = (v1 + v13) | 0;
                {
                    let t0 = v0;
                    let t1 = v49;
                    let t2 = v48;
                    let t3 = v3;
                    v0 = t0;
                    v1 = t1;
                    v2 = t2;
                    v3 = t3;
                }
                continue tail;
            }
        }
    }
}
export function main(): number {
    let v0: string = "éZ";
    let v1: number = 1;
    let v2: number = method0(v0, v1);
    let v3: boolean = v2 >= 768;
    let v33: boolean;
    if (v3) {
        let v4: boolean = v2 <= 879;
        if (v4) {
            v33 = true;
        } else {
            let v5: boolean = v2 >= 6832;
            if (v5) {
                let v6: boolean = v2 <= 6911;
                if (v6) {
                    v33 = true;
                } else {
                    let v7: boolean = v2 >= 7616;
                    if (v7) {
                        let v8: boolean = v2 <= 7679;
                        if (v8) {
                            v33 = true;
                        } else {
                            let v9: boolean = v2 >= 8400;
                            if (v9) {
                                let v10: boolean = v2 <= 8447;
                                if (v10) {
                                    v33 = true;
                                } else {
                                    let v11: boolean = v2 >= 65024;
                                    if (v11) {
                                        let v12: boolean = v2 <= 65039;
                                        if (v12) {
                                            v33 = true;
                                        } else {
                                            let v13: boolean = v2 >= 65056;
                                            if (v13) {
                                                let v14: boolean = v2 <= 65071;
                                                if (v14) {
                                                    v33 = true;
                                                } else {
                                                    let v15: boolean = v2 >= 127995;
                                                    if (v15) {
                                                        let v16: boolean = v2 <= 127999;
                                                        if (v16) {
                                                            v33 = true;
                                                        } else {
                                                            let v17: boolean = v2 >= 917760;
                                                            if (v17) {
                                                                let v18: boolean = v2 <= 917999;
                                                                v33 = v18;
                                                            } else {
                                                                v33 = false;
                                                            }
                                                        }
                                                    } else {
                                                        v33 = false;
                                                    }
                                                }
                                            } else {
                                                v33 = false;
                                            }
                                        }
                                    } else {
                                        v33 = false;
                                    }
                                }
                            } else {
                                v33 = false;
                            }
                        }
                    } else {
                        v33 = false;
                    }
                }
            } else {
                v33 = false;
            }
        }
    } else {
        v33 = false;
    }
    if (v33) {
        throw new Error("UTF-8 grapheme byte offset is inside a bounded grapheme cluster.");
    } else {
        let v35: number = 1;
        let v36: number = 0;
        let v37: number = 4;
        return method2(v0, v35, v36, v37);
    }
}
process.exitCode = main();
