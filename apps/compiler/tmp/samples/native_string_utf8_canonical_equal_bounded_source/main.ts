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
    let v3: boolean = v1 < 0;
    if (v3) {
        throw new Error("UTF-8 byte offset is negative.");
    } else {
        let v5: boolean = v1 >= v2;
        if (v5) {
            throw new Error("UTF-8 byte offset is outside the string.");
        } else {
            let v7: number = runtime_byte_2(v0, v1);
            let v8: number = v7;
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
                            let v16: number = runtime_byte_2(v0, v13);
                            let v17: number = v16;
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
                                let v33: number = runtime_byte_2(v0, v32);
                                let v34: number = v33;
                                let v35: number = runtime_byte_2(v0, v29);
                                let v36: number = v35;
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
                                    let v68: number = runtime_byte_2(v0, v67);
                                    let v69: number = v68;
                                    let v70: number = (v1 + 2) | 0;
                                    let v71: number = runtime_byte_2(v0, v70);
                                    let v72: number = v71;
                                    let v73: number = runtime_byte_2(v0, v64);
                                    let v74: number = v73;
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
function utf8_canonical_equal_bounded_loop_0(v0: string, v1: number, v2: number, v3: number, v4: number, v5: number, v6: number): boolean {
    tail: while (true) {
        let v7: boolean = v3 >= 0;
        let v75: number;
        let v76: number;
        let v77: number;
        if (v7) {
            v75 = v3;
            v76 = v1;
            v77 = (-1);
        } else {
            let v8: boolean = v1 === v5;
            if (v8) {
                v75 = (-1);
                v76 = v1;
                v77 = (-1);
            } else {
                let v9: boolean = v1 > v5;
                if (v9) {
                    throw new Error("UTF-8 canonical stream offset exceeds the string.");
                } else {
                    let v13: number = utf8_scalar_at_byte_offset_1(v0, v1);
                    let v14: boolean = v13 < 128;
                    let v19: number;
                    if (v14) {
                        v19 = 1;
                    } else {
                        let v15: boolean = v13 < 2048;
                        if (v15) {
                            v19 = 2;
                        } else {
                            let v16: boolean = v13 < 65536;
                            if (v16) {
                                v19 = 3;
                            } else {
                                v19 = 4;
                            }
                        }
                    }
                    let v20: boolean = v13 === 192;
                    let v66: number;
                    let v67: number;
                    if (v20) {
                        v66 = 65;
                        v67 = 768;
                    } else {
                        let v21: boolean = v13 === 193;
                        if (v21) {
                            v66 = 65;
                            v67 = 769;
                        } else {
                            let v22: boolean = v13 === 195;
                            if (v22) {
                                v66 = 65;
                                v67 = 771;
                            } else {
                                let v23: boolean = v13 === 196;
                                if (v23) {
                                    v66 = 65;
                                    v67 = 776;
                                } else {
                                    let v24: boolean = v13 === 199;
                                    if (v24) {
                                        v66 = 67;
                                        v67 = 807;
                                    } else {
                                        let v25: boolean = v13 === 201;
                                        if (v25) {
                                            v66 = 69;
                                            v67 = 769;
                                        } else {
                                            let v26: boolean = v13 === 211;
                                            if (v26) {
                                                v66 = 79;
                                                v67 = 769;
                                            } else {
                                                let v27: boolean = v13 === 213;
                                                if (v27) {
                                                    v66 = 79;
                                                    v67 = 771;
                                                } else {
                                                    let v28: boolean = v13 === 224;
                                                    if (v28) {
                                                        v66 = 97;
                                                        v67 = 768;
                                                    } else {
                                                        let v29: boolean = v13 === 225;
                                                        if (v29) {
                                                            v66 = 97;
                                                            v67 = 769;
                                                        } else {
                                                            let v30: boolean = v13 === 227;
                                                            if (v30) {
                                                                v66 = 97;
                                                                v67 = 771;
                                                            } else {
                                                                let v31: boolean = v13 === 228;
                                                                if (v31) {
                                                                    v66 = 97;
                                                                    v67 = 776;
                                                                } else {
                                                                    let v32: boolean = v13 === 231;
                                                                    if (v32) {
                                                                        v66 = 99;
                                                                        v67 = 807;
                                                                    } else {
                                                                        let v33: boolean = v13 === 233;
                                                                        if (v33) {
                                                                            v66 = 101;
                                                                            v67 = 769;
                                                                        } else {
                                                                            let v34: boolean = v13 === 243;
                                                                            if (v34) {
                                                                                v66 = 111;
                                                                                v67 = 769;
                                                                            } else {
                                                                                let v35: boolean = v13 === 245;
                                                                                if (v35) {
                                                                                    v66 = 111;
                                                                                    v67 = 771;
                                                                                } else {
                                                                                    v66 = v13;
                                                                                    v67 = (-1);
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
                    let v68: number = (v1 + v19) | 0;
                    v75 = v66;
                    v76 = v68;
                    v77 = v67;
                }
            }
        }
        let v78: boolean = v4 >= 0;
        let v146: number;
        let v147: number;
        let v148: number;
        if (v78) {
            v146 = v4;
            v147 = v2;
            v148 = (-1);
        } else {
            let v79: boolean = v2 === v6;
            if (v79) {
                v146 = (-1);
                v147 = v2;
                v148 = (-1);
            } else {
                let v80: boolean = v2 > v6;
                if (v80) {
                    throw new Error("UTF-8 canonical stream offset exceeds the string.");
                } else {
                    let v84: number = utf8_scalar_at_byte_offset_1(v0, v2);
                    let v85: boolean = v84 < 128;
                    let v90: number;
                    if (v85) {
                        v90 = 1;
                    } else {
                        let v86: boolean = v84 < 2048;
                        if (v86) {
                            v90 = 2;
                        } else {
                            let v87: boolean = v84 < 65536;
                            if (v87) {
                                v90 = 3;
                            } else {
                                v90 = 4;
                            }
                        }
                    }
                    let v91: boolean = v84 === 192;
                    let v137: number;
                    let v138: number;
                    if (v91) {
                        v137 = 65;
                        v138 = 768;
                    } else {
                        let v92: boolean = v84 === 193;
                        if (v92) {
                            v137 = 65;
                            v138 = 769;
                        } else {
                            let v93: boolean = v84 === 195;
                            if (v93) {
                                v137 = 65;
                                v138 = 771;
                            } else {
                                let v94: boolean = v84 === 196;
                                if (v94) {
                                    v137 = 65;
                                    v138 = 776;
                                } else {
                                    let v95: boolean = v84 === 199;
                                    if (v95) {
                                        v137 = 67;
                                        v138 = 807;
                                    } else {
                                        let v96: boolean = v84 === 201;
                                        if (v96) {
                                            v137 = 69;
                                            v138 = 769;
                                        } else {
                                            let v97: boolean = v84 === 211;
                                            if (v97) {
                                                v137 = 79;
                                                v138 = 769;
                                            } else {
                                                let v98: boolean = v84 === 213;
                                                if (v98) {
                                                    v137 = 79;
                                                    v138 = 771;
                                                } else {
                                                    let v99: boolean = v84 === 224;
                                                    if (v99) {
                                                        v137 = 97;
                                                        v138 = 768;
                                                    } else {
                                                        let v100: boolean = v84 === 225;
                                                        if (v100) {
                                                            v137 = 97;
                                                            v138 = 769;
                                                        } else {
                                                            let v101: boolean = v84 === 227;
                                                            if (v101) {
                                                                v137 = 97;
                                                                v138 = 771;
                                                            } else {
                                                                let v102: boolean = v84 === 228;
                                                                if (v102) {
                                                                    v137 = 97;
                                                                    v138 = 776;
                                                                } else {
                                                                    let v103: boolean = v84 === 231;
                                                                    if (v103) {
                                                                        v137 = 99;
                                                                        v138 = 807;
                                                                    } else {
                                                                        let v104: boolean = v84 === 233;
                                                                        if (v104) {
                                                                            v137 = 101;
                                                                            v138 = 769;
                                                                        } else {
                                                                            let v105: boolean = v84 === 243;
                                                                            if (v105) {
                                                                                v137 = 111;
                                                                                v138 = 769;
                                                                            } else {
                                                                                let v106: boolean = v84 === 245;
                                                                                if (v106) {
                                                                                    v137 = 111;
                                                                                    v138 = 771;
                                                                                } else {
                                                                                    v137 = v84;
                                                                                    v138 = (-1);
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
                    let v139: number = (v2 + v90) | 0;
                    v146 = v137;
                    v147 = v139;
                    v148 = v138;
                }
            }
        }
        let v149: boolean = v75 < 0;
        if (v149) {
            let v150: boolean = v146 === (-1);
            return v150;
        } else {
            let v151: boolean = v146 < 0;
            if (v151) {
                return false;
            } else {
                let v152: boolean = v75 === v146;
                if (v152) {
                    {
                        let t0 = v0;
                        let t1 = v76;
                        let t2 = v147;
                        let t3 = v77;
                        let t4 = v148;
                        let t5 = v5;
                        let t6 = v6;
                        v0 = t0;
                        v1 = t1;
                        v2 = t2;
                        v3 = t3;
                        v4 = t4;
                        v5 = t5;
                        v6 = t6;
                    }
                    continue tail;
                } else {
                    return false;
                }
            }
        }
    }
}
function utf8_canonical_equal_bounded_loop_3(v0: string, v1: string, v2: number, v3: number, v4: number, v5: number, v6: number, v7: number): boolean {
    tail: while (true) {
        let v8: boolean = v4 >= 0;
        let v76: number;
        let v77: number;
        let v78: number;
        if (v8) {
            v76 = v4;
            v77 = v2;
            v78 = (-1);
        } else {
            let v9: boolean = v2 === v6;
            if (v9) {
                v76 = (-1);
                v77 = v2;
                v78 = (-1);
            } else {
                let v10: boolean = v2 > v6;
                if (v10) {
                    throw new Error("UTF-8 canonical stream offset exceeds the string.");
                } else {
                    let v14: number = utf8_scalar_at_byte_offset_1(v0, v2);
                    let v15: boolean = v14 < 128;
                    let v20: number;
                    if (v15) {
                        v20 = 1;
                    } else {
                        let v16: boolean = v14 < 2048;
                        if (v16) {
                            v20 = 2;
                        } else {
                            let v17: boolean = v14 < 65536;
                            if (v17) {
                                v20 = 3;
                            } else {
                                v20 = 4;
                            }
                        }
                    }
                    let v21: boolean = v14 === 192;
                    let v67: number;
                    let v68: number;
                    if (v21) {
                        v67 = 65;
                        v68 = 768;
                    } else {
                        let v22: boolean = v14 === 193;
                        if (v22) {
                            v67 = 65;
                            v68 = 769;
                        } else {
                            let v23: boolean = v14 === 195;
                            if (v23) {
                                v67 = 65;
                                v68 = 771;
                            } else {
                                let v24: boolean = v14 === 196;
                                if (v24) {
                                    v67 = 65;
                                    v68 = 776;
                                } else {
                                    let v25: boolean = v14 === 199;
                                    if (v25) {
                                        v67 = 67;
                                        v68 = 807;
                                    } else {
                                        let v26: boolean = v14 === 201;
                                        if (v26) {
                                            v67 = 69;
                                            v68 = 769;
                                        } else {
                                            let v27: boolean = v14 === 211;
                                            if (v27) {
                                                v67 = 79;
                                                v68 = 769;
                                            } else {
                                                let v28: boolean = v14 === 213;
                                                if (v28) {
                                                    v67 = 79;
                                                    v68 = 771;
                                                } else {
                                                    let v29: boolean = v14 === 224;
                                                    if (v29) {
                                                        v67 = 97;
                                                        v68 = 768;
                                                    } else {
                                                        let v30: boolean = v14 === 225;
                                                        if (v30) {
                                                            v67 = 97;
                                                            v68 = 769;
                                                        } else {
                                                            let v31: boolean = v14 === 227;
                                                            if (v31) {
                                                                v67 = 97;
                                                                v68 = 771;
                                                            } else {
                                                                let v32: boolean = v14 === 228;
                                                                if (v32) {
                                                                    v67 = 97;
                                                                    v68 = 776;
                                                                } else {
                                                                    let v33: boolean = v14 === 231;
                                                                    if (v33) {
                                                                        v67 = 99;
                                                                        v68 = 807;
                                                                    } else {
                                                                        let v34: boolean = v14 === 233;
                                                                        if (v34) {
                                                                            v67 = 101;
                                                                            v68 = 769;
                                                                        } else {
                                                                            let v35: boolean = v14 === 243;
                                                                            if (v35) {
                                                                                v67 = 111;
                                                                                v68 = 769;
                                                                            } else {
                                                                                let v36: boolean = v14 === 245;
                                                                                if (v36) {
                                                                                    v67 = 111;
                                                                                    v68 = 771;
                                                                                } else {
                                                                                    v67 = v14;
                                                                                    v68 = (-1);
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
                    let v69: number = (v2 + v20) | 0;
                    v76 = v67;
                    v77 = v69;
                    v78 = v68;
                }
            }
        }
        let v79: boolean = v5 >= 0;
        let v147: number;
        let v148: number;
        let v149: number;
        if (v79) {
            v147 = v5;
            v148 = v3;
            v149 = (-1);
        } else {
            let v80: boolean = v3 === v7;
            if (v80) {
                v147 = (-1);
                v148 = v3;
                v149 = (-1);
            } else {
                let v81: boolean = v3 > v7;
                if (v81) {
                    throw new Error("UTF-8 canonical stream offset exceeds the string.");
                } else {
                    let v85: number = utf8_scalar_at_byte_offset_1(v1, v3);
                    let v86: boolean = v85 < 128;
                    let v91: number;
                    if (v86) {
                        v91 = 1;
                    } else {
                        let v87: boolean = v85 < 2048;
                        if (v87) {
                            v91 = 2;
                        } else {
                            let v88: boolean = v85 < 65536;
                            if (v88) {
                                v91 = 3;
                            } else {
                                v91 = 4;
                            }
                        }
                    }
                    let v92: boolean = v85 === 192;
                    let v138: number;
                    let v139: number;
                    if (v92) {
                        v138 = 65;
                        v139 = 768;
                    } else {
                        let v93: boolean = v85 === 193;
                        if (v93) {
                            v138 = 65;
                            v139 = 769;
                        } else {
                            let v94: boolean = v85 === 195;
                            if (v94) {
                                v138 = 65;
                                v139 = 771;
                            } else {
                                let v95: boolean = v85 === 196;
                                if (v95) {
                                    v138 = 65;
                                    v139 = 776;
                                } else {
                                    let v96: boolean = v85 === 199;
                                    if (v96) {
                                        v138 = 67;
                                        v139 = 807;
                                    } else {
                                        let v97: boolean = v85 === 201;
                                        if (v97) {
                                            v138 = 69;
                                            v139 = 769;
                                        } else {
                                            let v98: boolean = v85 === 211;
                                            if (v98) {
                                                v138 = 79;
                                                v139 = 769;
                                            } else {
                                                let v99: boolean = v85 === 213;
                                                if (v99) {
                                                    v138 = 79;
                                                    v139 = 771;
                                                } else {
                                                    let v100: boolean = v85 === 224;
                                                    if (v100) {
                                                        v138 = 97;
                                                        v139 = 768;
                                                    } else {
                                                        let v101: boolean = v85 === 225;
                                                        if (v101) {
                                                            v138 = 97;
                                                            v139 = 769;
                                                        } else {
                                                            let v102: boolean = v85 === 227;
                                                            if (v102) {
                                                                v138 = 97;
                                                                v139 = 771;
                                                            } else {
                                                                let v103: boolean = v85 === 228;
                                                                if (v103) {
                                                                    v138 = 97;
                                                                    v139 = 776;
                                                                } else {
                                                                    let v104: boolean = v85 === 231;
                                                                    if (v104) {
                                                                        v138 = 99;
                                                                        v139 = 807;
                                                                    } else {
                                                                        let v105: boolean = v85 === 233;
                                                                        if (v105) {
                                                                            v138 = 101;
                                                                            v139 = 769;
                                                                        } else {
                                                                            let v106: boolean = v85 === 243;
                                                                            if (v106) {
                                                                                v138 = 111;
                                                                                v139 = 769;
                                                                            } else {
                                                                                let v107: boolean = v85 === 245;
                                                                                if (v107) {
                                                                                    v138 = 111;
                                                                                    v139 = 771;
                                                                                } else {
                                                                                    v138 = v85;
                                                                                    v139 = (-1);
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
                    let v140: number = (v3 + v91) | 0;
                    v147 = v138;
                    v148 = v140;
                    v149 = v139;
                }
            }
        }
        let v150: boolean = v76 < 0;
        if (v150) {
            let v151: boolean = v147 === (-1);
            return v151;
        } else {
            let v152: boolean = v147 < 0;
            if (v152) {
                return false;
            } else {
                let v153: boolean = v76 === v147;
                if (v153) {
                    {
                        let t0 = v0;
                        let t1 = v1;
                        let t2 = v77;
                        let t3 = v148;
                        let t4 = v78;
                        let t5 = v149;
                        let t6 = v6;
                        let t7 = v7;
                        v0 = t0;
                        v1 = t1;
                        v2 = t2;
                        v3 = t3;
                        v4 = t4;
                        v5 = t5;
                        v6 = t6;
                        v7 = t7;
                    }
                    continue tail;
                } else {
                    return false;
                }
            }
        }
    }
}
export function main(): number {
    let v0: string = "plain";
    let v1: number = 0;
    let v2: number = 0;
    let v3: number = (-1);
    let v4: number = (-1);
    let v5: number = 5;
    let v6: number = 5;
    let v7: boolean = utf8_canonical_equal_bounded_loop_0(v0, v1, v2, v3, v4, v5, v6);
    let v8: string = "";
    let v9: number = 0;
    let v10: number = 0;
    let v11: number = (-1);
    let v12: number = (-1);
    let v13: number = 0;
    let v14: number = 0;
    let v15: boolean = utf8_canonical_equal_bounded_loop_0(v8, v9, v10, v11, v12, v13, v14);
    let v16: string = "éõç";
    let v17: string = "éõç";
    let v18: number = 0;
    let v19: number = 0;
    let v20: number = (-1);
    let v21: number = (-1);
    let v22: number = 6;
    let v23: number = 9;
    let v24: boolean = utf8_canonical_equal_bounded_loop_3(v16, v17, v18, v19, v20, v21, v22, v23);
    let v25: string = "é̃";
    let v26: string = "é̃";
    let v27: number = 0;
    let v28: number = 0;
    let v29: number = (-1);
    let v30: number = (-1);
    let v31: number = 4;
    let v32: number = 5;
    let v33: boolean = utf8_canonical_equal_bounded_loop_3(v25, v26, v27, v28, v29, v30, v31, v32);
    let v34: string = "À";
    let v35: string = "À";
    let v36: number = 0;
    let v37: number = 0;
    let v38: number = (-1);
    let v39: number = (-1);
    let v40: number = 2;
    let v41: number = 3;
    let v42: boolean = utf8_canonical_equal_bounded_loop_3(v34, v35, v36, v37, v38, v39, v40, v41);
    let v43: string = "Ω";
    let v44: number = 0;
    let v45: number = 0;
    let v46: number = (-1);
    let v47: number = (-1);
    let v48: number = 2;
    let v49: number = 2;
    let v50: boolean = utf8_canonical_equal_bounded_loop_0(v43, v44, v45, v46, v47, v48, v49);
    let v51: string = "ẽ́";
    let v52: number = 0;
    let v53: number = 0;
    let v54: number = (-1);
    let v55: number = (-1);
    let v56: number = 5;
    let v57: number = 5;
    let v58: boolean = utf8_canonical_equal_bounded_loop_3(v26, v51, v52, v53, v54, v55, v56, v57);
    let v59: string = "é";
    let v60: string = "á";
    let v61: number = 0;
    let v62: number = 0;
    let v63: number = (-1);
    let v64: number = (-1);
    let v65: number = 2;
    let v66: number = 2;
    let v67: boolean = utf8_canonical_equal_bounded_loop_3(v59, v60, v61, v62, v63, v64, v65, v66);
    let v68: string = "ω";
    let v69: number = 0;
    let v70: number = 0;
    let v71: number = (-1);
    let v72: number = (-1);
    let v73: number = 2;
    let v74: number = 2;
    let v75: boolean = utf8_canonical_equal_bounded_loop_3(v43, v68, v69, v70, v71, v72, v73, v74);
    let v76: string = "e";
    let v77: number = 0;
    let v78: number = 0;
    let v79: number = (-1);
    let v80: number = (-1);
    let v81: number = 2;
    let v82: number = 1;
    let v83: boolean = utf8_canonical_equal_bounded_loop_3(v59, v76, v77, v78, v79, v80, v81, v82);
    if (v7) {
        if (v15) {
            if (v24) {
                if (v33) {
                    if (v42) {
                        if (v50) {
                            if (v58) {
                                return 7;
                            } else {
                                if (v67) {
                                    return 8;
                                } else {
                                    if (v75) {
                                        return 9;
                                    } else {
                                        if (v83) {
                                            return 10;
                                        } else {
                                            return 0;
                                        }
                                    }
                                }
                            }
                        } else {
                            return 6;
                        }
                    } else {
                        return 5;
                    }
                } else {
                    return 4;
                }
            } else {
                return 3;
            }
        } else {
            return 2;
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
