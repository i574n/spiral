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
function runtime_byte_2(v0: string, v1: number): number {
    let v2: number = spiral_string_index(v0, v1);
    return v2;
}
function utf8_scalar_at_byte_offset_1(v0: string, v1: number): number {
    let v2: number = spiral_string_length(v0);
    const v3: boolean = v1 < 0;
    if (v3) {
        throw new Error("UTF-8 byte offset is negative.");
    } else {
        const v5: boolean = v1 >= v2;
        if (v5) {
            throw new Error("UTF-8 byte offset is outside the string.");
        } else {
            const v7: number = runtime_byte_2(v0, v1);
            const v8: number = v7;
            const v9: boolean = v8 < 128;
            if (v9) {
                return v8;
            } else {
                const v10: boolean = v8 < 194;
                if (v10) {
                    throw new Error("UTF-8 scalar starts with an invalid lead byte.");
                } else {
                    const v12: boolean = v8 < 224;
                    if (v12) {
                        let v13: number = (v1 + 1) | 0;
                        const v14: boolean = v13 >= v2;
                        if (v14) {
                            throw new Error("UTF-8 sequence is truncated.");
                        } else {
                            const v16: number = runtime_byte_2(v0, v13);
                            const v17: number = v16;
                            const v18: boolean = v17 < 128;
                            let v20: boolean;
                            if (v18) {
                                v20 = false;
                            } else {
                                const v19: boolean = v17 < 192;
                                v20 = v19;
                            }
                            if (v20) {
                                const v21: number = (v8 - 192) | 0;
                                const v22: number = Math.imul(v21, 64);
                                const v23: number = (v17 - 128) | 0;
                                const v24: number = (v22 + v23) | 0;
                                return v24;
                            } else {
                                throw new Error("UTF-8 sequence has an invalid continuation byte.");
                            }
                        }
                    } else {
                        const v28: boolean = v8 < 240;
                        if (v28) {
                            const v29: number = (v1 + 2) | 0;
                            const v30: boolean = v29 >= v2;
                            if (v30) {
                                throw new Error("UTF-8 sequence is truncated.");
                            } else {
                                const v32: number = (v1 + 1) | 0;
                                const v33: number = runtime_byte_2(v0, v32);
                                const v34: number = v33;
                                const v35: number = runtime_byte_2(v0, v29);
                                const v36: number = v35;
                                const v37: boolean = v34 < 128;
                                let v39: boolean;
                                if (v37) {
                                    v39 = false;
                                } else {
                                    const v38: boolean = v34 < 192;
                                    v39 = v38;
                                }
                                if (v39) {
                                    const v40: boolean = v36 < 128;
                                    let v42: boolean;
                                    if (v40) {
                                        v42 = false;
                                    } else {
                                        const v41: boolean = v36 < 192;
                                        v42 = v41;
                                    }
                                    if (v42) {
                                        let v43: number = (v8 - 224) | 0;
                                        let v44: number = Math.imul(v43, 4096);
                                        const v45: number = (v34 - 128) | 0;
                                        const v46: number = Math.imul(v45, 64);
                                        const v47: number = (v44 + v46) | 0;
                                        let v48: number = (v36 - 128) | 0;
                                        let v49: number = (v47 + v48) | 0;
                                        const v50: boolean = v49 < 2048;
                                        if (v50) {
                                            throw new Error("UTF-8 sequence is overlong.");
                                        } else {
                                            const v52: boolean = v49 >= 55296;
                                            if (v52) {
                                                const v53: boolean = v49 <= 57343;
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
                            const v63: boolean = v8 < 245;
                            if (v63) {
                                const v64: number = (v1 + 3) | 0;
                                const v65: boolean = v64 >= v2;
                                if (v65) {
                                    throw new Error("UTF-8 sequence is truncated.");
                                } else {
                                    const v67: number = (v1 + 1) | 0;
                                    const v68: number = runtime_byte_2(v0, v67);
                                    const v69: number = v68;
                                    const v70: number = (v1 + 2) | 0;
                                    const v71: number = runtime_byte_2(v0, v70);
                                    const v72: number = v71;
                                    const v73: number = runtime_byte_2(v0, v64);
                                    const v74: number = v73;
                                    const v75: boolean = v69 < 128;
                                    let v77: boolean;
                                    if (v75) {
                                        v77 = false;
                                    } else {
                                        const v76: boolean = v69 < 192;
                                        v77 = v76;
                                    }
                                    if (v77) {
                                        const v78: boolean = v72 < 128;
                                        let v80: boolean;
                                        if (v78) {
                                            v80 = false;
                                        } else {
                                            const v79: boolean = v72 < 192;
                                            v80 = v79;
                                        }
                                        if (v80) {
                                            const v81: boolean = v74 < 128;
                                            let v83: boolean;
                                            if (v81) {
                                                v83 = false;
                                            } else {
                                                const v82: boolean = v74 < 192;
                                                v83 = v82;
                                            }
                                            if (v83) {
                                                const v84: number = (v8 - 240) | 0;
                                                const v85: number = Math.imul(v84, 262144);
                                                const v86: number = (v69 - 128) | 0;
                                                const v87: number = Math.imul(v86, 4096);
                                                const v88: number = (v85 + v87) | 0;
                                                const v89: number = (v72 - 128) | 0;
                                                const v90: number = Math.imul(v89, 64);
                                                const v91: number = (v88 + v90) | 0;
                                                const v92: number = (v74 - 128) | 0;
                                                const v93: number = (v91 + v92) | 0;
                                                const v94: boolean = v93 < 65536;
                                                if (v94) {
                                                    throw new Error("UTF-8 sequence is overlong.");
                                                } else {
                                                    const v96: boolean = v93 > 1114111;
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
function utf8_grapheme_count_bounded_loop_0(v0: string, v1: number, v2: number, v3: number): number {
    tail: while (true) {
        const v4: boolean = v1 === v3;
        if (v4) {
            return v2;
        } else {
            const v5: boolean = v1 > v3;
            if (v5) {
                throw new Error("UTF-8 scalar width exceeds the string.");
            } else {
                const v7: number = utf8_scalar_at_byte_offset_1(v0, v1);
                const v8: boolean = v7 < 128;
                let v13: number;
                if (v8) {
                    v13 = 1;
                } else {
                    const v9: boolean = v7 < 2048;
                    if (v9) {
                        v13 = 2;
                    } else {
                        const v10: boolean = v7 < 65536;
                        if (v10) {
                            v13 = 3;
                        } else {
                            v13 = 4;
                        }
                    }
                }
                const v14: boolean = v7 >= 768;
                let v44: boolean;
                if (v14) {
                    const v15: boolean = v7 <= 879;
                    if (v15) {
                        v44 = true;
                    } else {
                        const v16: boolean = v7 >= 6832;
                        if (v16) {
                            const v17: boolean = v7 <= 6911;
                            if (v17) {
                                v44 = true;
                            } else {
                                const v18: boolean = v7 >= 7616;
                                if (v18) {
                                    const v19: boolean = v7 <= 7679;
                                    if (v19) {
                                        v44 = true;
                                    } else {
                                        let v20: boolean = v7 >= 8400;
                                        if (v20) {
                                            const v21: boolean = v7 <= 8447;
                                            if (v21) {
                                                v44 = true;
                                            } else {
                                                const v22: boolean = v7 >= 65024;
                                                if (v22) {
                                                    const v23: boolean = v7 <= 65039;
                                                    if (v23) {
                                                        v44 = true;
                                                    } else {
                                                        const v24: boolean = v7 >= 65056;
                                                        if (v24) {
                                                            const v25: boolean = v7 <= 65071;
                                                            if (v25) {
                                                                v44 = true;
                                                            } else {
                                                                const v26: boolean = v7 >= 127995;
                                                                if (v26) {
                                                                    const v27: boolean = v7 <= 127999;
                                                                    if (v27) {
                                                                        v44 = true;
                                                                    } else {
                                                                        const v28: boolean = v7 >= 917760;
                                                                        if (v28) {
                                                                            const v29: boolean = v7 <= 917999;
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
                    const v45: boolean = v2 === 0;
                    if (v45) {
                        v48 = 1;
                    } else {
                        v48 = v2;
                    }
                } else {
                    const v47: number = (v2 + 1) | 0;
                    v48 = v47;
                }
                let v49: number = (v1 + v13) | 0;
                v1 = v49;
                v2 = v48;
                continue tail;
            }
        }
    }
}
export function main(): number {
    const v0: string = "Aéé☕️👍🏽Z";
    let v1: number = 0;
    let v2: number = 0;
    const v3: number = 21;
    const v4: number = utf8_grapheme_count_bounded_loop_0(v0, v1, v2, v3);
    const v5: string = "́̈A";
    const v6: number = 0;
    const v7: number = 0;
    const v8: number = 5;
    const v9: number = utf8_grapheme_count_bounded_loop_0(v5, v6, v7, v8);
    const v10: string = "Aé🙂Z";
    const v11: number = 4;
    const v12: number = utf8_scalar_at_byte_offset_1(v10, v11);
    let v13: boolean = v12 >= 768;
    let v43: boolean;
    if (v13) {
        const v14: boolean = v12 <= 879;
        if (v14) {
            v43 = true;
        } else {
            const v15: boolean = v12 >= 6832;
            if (v15) {
                const v16: boolean = v12 <= 6911;
                if (v16) {
                    v43 = true;
                } else {
                    const v17: boolean = v12 >= 7616;
                    if (v17) {
                        const v18: boolean = v12 <= 7679;
                        if (v18) {
                            v43 = true;
                        } else {
                            const v19: boolean = v12 >= 8400;
                            if (v19) {
                                let v20: boolean = v12 <= 8447;
                                if (v20) {
                                    v43 = true;
                                } else {
                                    const v21: boolean = v12 >= 65024;
                                    if (v21) {
                                        const v22: boolean = v12 <= 65039;
                                        if (v22) {
                                            v43 = true;
                                        } else {
                                            const v23: boolean = v12 >= 65056;
                                            if (v23) {
                                                const v24: boolean = v12 <= 65071;
                                                if (v24) {
                                                    v43 = true;
                                                } else {
                                                    const v25: boolean = v12 >= 127995;
                                                    if (v25) {
                                                        const v26: boolean = v12 <= 127999;
                                                        if (v26) {
                                                            v43 = true;
                                                        } else {
                                                            const v27: boolean = v12 >= 917760;
                                                            if (v27) {
                                                                const v28: boolean = v12 <= 917999;
                                                                v43 = v28;
                                                            } else {
                                                                v43 = false;
                                                            }
                                                        }
                                                    } else {
                                                        v43 = false;
                                                    }
                                                }
                                            } else {
                                                v43 = false;
                                            }
                                        }
                                    } else {
                                        v43 = false;
                                    }
                                }
                            } else {
                                v43 = false;
                            }
                        }
                    } else {
                        v43 = false;
                    }
                }
            } else {
                v43 = false;
            }
        }
    } else {
        v43 = false;
    }
    let v49: number;
    if (v43) {
        throw new Error("UTF-8 grapheme byte offset is inside a bounded grapheme cluster.");
    } else {
        const v45: number = 4;
        const v46: number = 0;
        const v47: number = 9;
        v49 = utf8_grapheme_count_bounded_loop_0(v10, v45, v46, v47);
    }
    const v50: boolean = v4 === 6;
    if (v50) {
        const v51: boolean = v9 === 2;
        if (v51) {
            const v52: boolean = v49 === 2;
            if (v52) {
                return 0;
            } else {
                return 4;
            }
        } else {
            return 2;
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
