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
            let v16: number = v7;
            let v18: boolean = v16 < 128;
            if (v18) {
                return v16;
            } else {
                let v19: boolean = v16 < 194;
                if (v19) {
                    throw new Error("UTF-8 scalar starts with an invalid lead byte.");
                } else {
                    let v21: boolean = v16 < 224;
                    if (v21) {
                        let v22: number = (v1 + 1) | 0;
                        let v23: boolean = v22 >= v2;
                        if (v23) {
                            throw new Error("UTF-8 sequence is truncated.");
                        } else {
                            let v25: number = method1(v0, v22);
                            let v26: number = v25;
                            let v27: boolean = v26 < 128;
                            let v29: boolean;
                            if (v27) {
                                v29 = false;
                            } else {
                                let v28: boolean = v26 < 192;
                                v29 = v28;
                            }
                            if (v29) {
                                let v30: number = (v16 - 192) | 0;
                                let v31: number = Math.imul(v30, 64);
                                let v32: number = (v26 - 128) | 0;
                                let v33: number = (v31 + v32) | 0;
                                return v33;
                            } else {
                                throw new Error("UTF-8 sequence has an invalid continuation byte.");
                            }
                        }
                    } else {
                        let v37: boolean = v16 < 240;
                        if (v37) {
                            let v38: number = (v1 + 2) | 0;
                            let v39: boolean = v38 >= v2;
                            if (v39) {
                                throw new Error("UTF-8 sequence is truncated.");
                            } else {
                                let v41: number = (v1 + 1) | 0;
                                let v42: number = method1(v0, v41);
                                let v43: number = v42;
                                let v44: number = method1(v0, v38);
                                let v45: number = v44;
                                let v46: boolean = v43 < 128;
                                let v48: boolean;
                                if (v46) {
                                    v48 = false;
                                } else {
                                    let v47: boolean = v43 < 192;
                                    v48 = v47;
                                }
                                if (v48) {
                                    let v49: boolean = v45 < 128;
                                    let v51: boolean;
                                    if (v49) {
                                        v51 = false;
                                    } else {
                                        let v50: boolean = v45 < 192;
                                        v51 = v50;
                                    }
                                    if (v51) {
                                        let v52: number = (v16 - 224) | 0;
                                        let v53: number = Math.imul(v52, 4096);
                                        let v54: number = (v43 - 128) | 0;
                                        let v55: number = Math.imul(v54, 64);
                                        let v56: number = (v53 + v55) | 0;
                                        let v57: number = (v45 - 128) | 0;
                                        let v58: number = (v56 + v57) | 0;
                                        let v59: boolean = v58 < 2048;
                                        if (v59) {
                                            throw new Error("UTF-8 sequence is overlong.");
                                        } else {
                                            let v61: boolean = v58 >= 55296;
                                            if (v61) {
                                                let v62: boolean = v58 <= 57343;
                                                if (v62) {
                                                    throw new Error("UTF-8 sequence encodes a surrogate.");
                                                } else {
                                                    return v58;
                                                }
                                            } else {
                                                return v58;
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
                            let v72: boolean = v16 < 245;
                            if (v72) {
                                let v73: number = (v1 + 3) | 0;
                                let v74: boolean = v73 >= v2;
                                if (v74) {
                                    throw new Error("UTF-8 sequence is truncated.");
                                } else {
                                    let v76: number = (v1 + 1) | 0;
                                    let v77: number = method1(v0, v76);
                                    let v78: number = v77;
                                    let v79: number = (v1 + 2) | 0;
                                    let v80: number = method1(v0, v79);
                                    let v81: number = v80;
                                    let v82: number = method1(v0, v73);
                                    let v83: number = v82;
                                    let v84: boolean = v78 < 128;
                                    let v86: boolean;
                                    if (v84) {
                                        v86 = false;
                                    } else {
                                        let v85: boolean = v78 < 192;
                                        v86 = v85;
                                    }
                                    if (v86) {
                                        let v87: boolean = v81 < 128;
                                        let v89: boolean;
                                        if (v87) {
                                            v89 = false;
                                        } else {
                                            let v88: boolean = v81 < 192;
                                            v89 = v88;
                                        }
                                        if (v89) {
                                            let v90: boolean = v83 < 128;
                                            let v92: boolean;
                                            if (v90) {
                                                v92 = false;
                                            } else {
                                                let v91: boolean = v83 < 192;
                                                v92 = v91;
                                            }
                                            if (v92) {
                                                let v93: number = (v16 - 240) | 0;
                                                let v94: number = Math.imul(v93, 262144);
                                                let v95: number = (v78 - 128) | 0;
                                                let v96: number = Math.imul(v95, 4096);
                                                let v97: number = (v94 + v96) | 0;
                                                let v98: number = (v81 - 128) | 0;
                                                let v99: number = Math.imul(v98, 64);
                                                let v100: number = (v97 + v99) | 0;
                                                let v101: number = (v83 - 128) | 0;
                                                let v102: number = (v100 + v101) | 0;
                                                let v103: boolean = v102 < 65536;
                                                if (v103) {
                                                    throw new Error("UTF-8 sequence is overlong.");
                                                } else {
                                                    let v105: boolean = v102 > 1114111;
                                                    if (v105) {
                                                        throw new Error("UTF-8 scalar is above U+10FFFF.");
                                                    } else {
                                                        return v102;
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
