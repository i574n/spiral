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
function runtime_byte_1(v0: string, v1: number): number {
    const v2: number = spiral_string_index(v0, v1);
    return v2;
}
function utf8_scalar_at_byte_offset_0(v0: string, v1: number): number {
    const v2: number = spiral_string_length(v0);
    const v3: boolean = v1 < 0;
    if (v3) {
        throw new Error("UTF-8 byte offset is negative.");
    } else {
        const v5: boolean = v1 >= v2;
        if (v5) {
            throw new Error("UTF-8 byte offset is outside the string.");
        } else {
            const v7: number = runtime_byte_1(v0, v1);
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
                        const v13: number = (v1 + 1) | 0;
                        const v14: boolean = v13 >= v2;
                        if (v14) {
                            throw new Error("UTF-8 sequence is truncated.");
                        } else {
                            const v16: number = runtime_byte_1(v0, v13);
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
                                const v33: number = runtime_byte_1(v0, v32);
                                const v34: number = v33;
                                const v35: number = runtime_byte_1(v0, v29);
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
                                        const v43: number = (v8 - 224) | 0;
                                        const v44: number = Math.imul(v43, 4096);
                                        const v45: number = (v34 - 128) | 0;
                                        const v46: number = Math.imul(v45, 64);
                                        const v47: number = (v44 + v46) | 0;
                                        const v48: number = (v36 - 128) | 0;
                                        const v49: number = (v47 + v48) | 0;
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
                                let v64: number = (v1 + 3) | 0;
                                let v65: boolean = v64 >= v2;
                                if (v65) {
                                    throw new Error("UTF-8 sequence is truncated.");
                                } else {
                                    const v67: number = (v1 + 1) | 0;
                                    const v68: number = runtime_byte_1(v0, v67);
                                    const v69: number = v68;
                                    const v70: number = (v1 + 2) | 0;
                                    const v71: number = runtime_byte_1(v0, v70);
                                    const v72: number = v71;
                                    const v73: number = runtime_byte_1(v0, v64);
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
export function main(): number {
    const v0: string = "é";
    const v1: number = 0;
    const v2: number = utf8_scalar_at_byte_offset_0(v0, v1);
    const v3: string = "õ";
    const v4: number = 0;
    const v5: number = utf8_scalar_at_byte_offset_0(v3, v4);
    const v6: string = "ç";
    const v7: number = 0;
    const v8: number = utf8_scalar_at_byte_offset_0(v6, v7);
    const v9: string = "́";
    const v10: number = 0;
    const v11: number = utf8_scalar_at_byte_offset_0(v9, v10);
    const v12: string = "̃";
    const v13: number = 0;
    const v14: number = utf8_scalar_at_byte_offset_0(v12, v13);
    const v15: string = "̧";
    const v16: number = 0;
    const v17: number = utf8_scalar_at_byte_offset_0(v15, v16);
    const v18: boolean = v2 === 192;
    let v64: number;
    let v65: number;
    if (v18) {
        v64 = 65;
        v65 = 768;
    } else {
        const v19: boolean = v2 === 193;
        if (v19) {
            v64 = 65;
            v65 = 769;
        } else {
            let v20: boolean = v2 === 195;
            if (v20) {
                v64 = 65;
                v65 = 771;
            } else {
                const v21: boolean = v2 === 196;
                if (v21) {
                    v64 = 65;
                    v65 = 776;
                } else {
                    const v22: boolean = v2 === 199;
                    if (v22) {
                        v64 = 67;
                        v65 = 807;
                    } else {
                        const v23: boolean = v2 === 201;
                        if (v23) {
                            v64 = 69;
                            v65 = 769;
                        } else {
                            const v24: boolean = v2 === 211;
                            if (v24) {
                                v64 = 79;
                                v65 = 769;
                            } else {
                                const v25: boolean = v2 === 213;
                                if (v25) {
                                    v64 = 79;
                                    v65 = 771;
                                } else {
                                    const v26: boolean = v2 === 224;
                                    if (v26) {
                                        v64 = 97;
                                        v65 = 768;
                                    } else {
                                        const v27: boolean = v2 === 225;
                                        if (v27) {
                                            v64 = 97;
                                            v65 = 769;
                                        } else {
                                            const v28: boolean = v2 === 227;
                                            if (v28) {
                                                v64 = 97;
                                                v65 = 771;
                                            } else {
                                                const v29: boolean = v2 === 228;
                                                if (v29) {
                                                    v64 = 97;
                                                    v65 = 776;
                                                } else {
                                                    const v30: boolean = v2 === 231;
                                                    if (v30) {
                                                        v64 = 99;
                                                        v65 = 807;
                                                    } else {
                                                        const v31: boolean = v2 === 233;
                                                        if (v31) {
                                                            v64 = 101;
                                                            v65 = 769;
                                                        } else {
                                                            const v32: boolean = v2 === 243;
                                                            if (v32) {
                                                                v64 = 111;
                                                                v65 = 769;
                                                            } else {
                                                                const v33: boolean = v2 === 245;
                                                                if (v33) {
                                                                    v64 = 111;
                                                                    v65 = 771;
                                                                } else {
                                                                    v64 = v2;
                                                                    v65 = (-1);
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
    const v66: boolean = v5 === 192;
    let v112: number;
    let v113: number;
    if (v66) {
        v112 = 65;
        v113 = 768;
    } else {
        const v67: boolean = v5 === 193;
        if (v67) {
            v112 = 65;
            v113 = 769;
        } else {
            const v68: boolean = v5 === 195;
            if (v68) {
                v112 = 65;
                v113 = 771;
            } else {
                const v69: boolean = v5 === 196;
                if (v69) {
                    v112 = 65;
                    v113 = 776;
                } else {
                    const v70: boolean = v5 === 199;
                    if (v70) {
                        v112 = 67;
                        v113 = 807;
                    } else {
                        const v71: boolean = v5 === 201;
                        if (v71) {
                            v112 = 69;
                            v113 = 769;
                        } else {
                            const v72: boolean = v5 === 211;
                            if (v72) {
                                v112 = 79;
                                v113 = 769;
                            } else {
                                const v73: boolean = v5 === 213;
                                if (v73) {
                                    v112 = 79;
                                    v113 = 771;
                                } else {
                                    const v74: boolean = v5 === 224;
                                    if (v74) {
                                        v112 = 97;
                                        v113 = 768;
                                    } else {
                                        const v75: boolean = v5 === 225;
                                        if (v75) {
                                            v112 = 97;
                                            v113 = 769;
                                        } else {
                                            const v76: boolean = v5 === 227;
                                            if (v76) {
                                                v112 = 97;
                                                v113 = 771;
                                            } else {
                                                let v77: boolean = v5 === 228;
                                                if (v77) {
                                                    v112 = 97;
                                                    v113 = 776;
                                                } else {
                                                    const v78: boolean = v5 === 231;
                                                    if (v78) {
                                                        v112 = 99;
                                                        v113 = 807;
                                                    } else {
                                                        const v79: boolean = v5 === 233;
                                                        if (v79) {
                                                            v112 = 101;
                                                            v113 = 769;
                                                        } else {
                                                            let v80: boolean = v5 === 243;
                                                            if (v80) {
                                                                v112 = 111;
                                                                v113 = 769;
                                                            } else {
                                                                const v81: boolean = v5 === 245;
                                                                if (v81) {
                                                                    v112 = 111;
                                                                    v113 = 771;
                                                                } else {
                                                                    v112 = v5;
                                                                    v113 = (-1);
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
    const v114: boolean = v8 === 192;
    let v160: number;
    let v161: number;
    if (v114) {
        v160 = 65;
        v161 = 768;
    } else {
        const v115: boolean = v8 === 193;
        if (v115) {
            v160 = 65;
            v161 = 769;
        } else {
            const v116: boolean = v8 === 195;
            if (v116) {
                v160 = 65;
                v161 = 771;
            } else {
                const v117: boolean = v8 === 196;
                if (v117) {
                    v160 = 65;
                    v161 = 776;
                } else {
                    const v118: boolean = v8 === 199;
                    if (v118) {
                        v160 = 67;
                        v161 = 807;
                    } else {
                        const v119: boolean = v8 === 201;
                        if (v119) {
                            v160 = 69;
                            v161 = 769;
                        } else {
                            const v120: boolean = v8 === 211;
                            if (v120) {
                                v160 = 79;
                                v161 = 769;
                            } else {
                                const v121: boolean = v8 === 213;
                                if (v121) {
                                    v160 = 79;
                                    v161 = 771;
                                } else {
                                    const v122: boolean = v8 === 224;
                                    if (v122) {
                                        v160 = 97;
                                        v161 = 768;
                                    } else {
                                        const v123: boolean = v8 === 225;
                                        if (v123) {
                                            v160 = 97;
                                            v161 = 769;
                                        } else {
                                            const v124: boolean = v8 === 227;
                                            if (v124) {
                                                v160 = 97;
                                                v161 = 771;
                                            } else {
                                                const v125: boolean = v8 === 228;
                                                if (v125) {
                                                    v160 = 97;
                                                    v161 = 776;
                                                } else {
                                                    const v126: boolean = v8 === 231;
                                                    if (v126) {
                                                        v160 = 99;
                                                        v161 = 807;
                                                    } else {
                                                        const v127: boolean = v8 === 233;
                                                        if (v127) {
                                                            v160 = 101;
                                                            v161 = 769;
                                                        } else {
                                                            const v128: boolean = v8 === 243;
                                                            if (v128) {
                                                                v160 = 111;
                                                                v161 = 769;
                                                            } else {
                                                                const v129: boolean = v8 === 245;
                                                                if (v129) {
                                                                    v160 = 111;
                                                                    v161 = 771;
                                                                } else {
                                                                    v160 = v8;
                                                                    v161 = (-1);
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
    const v162: boolean = v11 === 769;
    let v163: number;
    if (v162) {
        v163 = 233;
    } else {
        v163 = (-1);
    }
    const v164: boolean = v163 < 0;
    let v165: number;
    let v166: number;
    if (v164) {
        v165 = 101;
        v166 = v11;
    } else {
        v165 = v163;
        v166 = (-1);
    }
    const v167: boolean = v14 === 769;
    let v170: number;
    if (v167) {
        v170 = 243;
    } else {
        const v168: boolean = v14 === 771;
        if (v168) {
            v170 = 245;
        } else {
            v170 = (-1);
        }
    }
    const v171: boolean = v170 < 0;
    let v172: number;
    let v173: number;
    if (v171) {
        v172 = 111;
        v173 = v14;
    } else {
        v172 = v170;
        v173 = (-1);
    }
    const v174: boolean = v17 === 807;
    let v175: number;
    if (v174) {
        v175 = 231;
    } else {
        v175 = (-1);
    }
    const v176: boolean = v175 < 0;
    let v177: number;
    let v178: number;
    if (v176) {
        v177 = 99;
        v178 = v17;
    } else {
        v177 = v175;
        v178 = (-1);
    }
    const v179: boolean = v64 === 101;
    let v181: boolean;
    if (v179) {
        const v180: boolean = v65 === v11;
        v181 = v180;
    } else {
        v181 = false;
    }
    if (v181) {
        const v182: boolean = v112 === 111;
        let v184: boolean;
        if (v182) {
            const v183: boolean = v113 === v14;
            v184 = v183;
        } else {
            v184 = false;
        }
        if (v184) {
            const v185: boolean = v160 === 99;
            let v187: boolean;
            if (v185) {
                const v186: boolean = v161 === v17;
                v187 = v186;
            } else {
                v187 = false;
            }
            if (v187) {
                const v188: boolean = v165 === v2;
                let v190: boolean;
                if (v188) {
                    const v189: boolean = v166 === (-1);
                    v190 = v189;
                } else {
                    v190 = false;
                }
                if (v190) {
                    const v191: boolean = v172 === v5;
                    let v193: boolean;
                    if (v191) {
                        const v192: boolean = v173 === (-1);
                        v193 = v192;
                    } else {
                        v193 = false;
                    }
                    if (v193) {
                        const v194: boolean = v177 === v8;
                        let v196: boolean;
                        if (v194) {
                            const v195: boolean = v178 === (-1);
                            v196 = v195;
                        } else {
                            v196 = false;
                        }
                        if (v196) {
                            return 0;
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
