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
    let v2: number = spiral_string_index(v0, v1);
    return v2;
}
function utf8_scalar_at_byte_offset_0(v0: string, v1: number): number {
    let v2: number = spiral_string_length(v0);
    let v3: boolean = v1 < 0;
    if (v3) {
        throw new Error("UTF-8 byte offset is negative.");
    } else {
        let v5: boolean = v1 >= v2;
        if (v5) {
            throw new Error("UTF-8 byte offset is outside the string.");
        } else {
            let v7: number = runtime_byte_1(v0, v1);
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
                            let v16: number = runtime_byte_1(v0, v13);
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
                                let v33: number = runtime_byte_1(v0, v32);
                                let v34: number = v33;
                                let v35: number = runtime_byte_1(v0, v29);
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
                                    let v68: number = runtime_byte_1(v0, v67);
                                    let v69: number = v68;
                                    let v70: number = (v1 + 2) | 0;
                                    let v71: number = runtime_byte_1(v0, v70);
                                    let v72: number = v71;
                                    let v73: number = runtime_byte_1(v0, v64);
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
export function main(): number {
    let v0: string = "é";
    let v1: number = 0;
    let v2: number = utf8_scalar_at_byte_offset_0(v0, v1);
    let v3: string = "õ";
    let v4: number = 0;
    let v5: number = utf8_scalar_at_byte_offset_0(v3, v4);
    let v6: string = "ç";
    let v7: number = 0;
    let v8: number = utf8_scalar_at_byte_offset_0(v6, v7);
    let v9: string = "́";
    let v10: number = 0;
    let v11: number = utf8_scalar_at_byte_offset_0(v9, v10);
    let v12: string = "̃";
    let v13: number = 0;
    let v14: number = utf8_scalar_at_byte_offset_0(v12, v13);
    let v15: string = "̧";
    let v16: number = 0;
    let v17: number = utf8_scalar_at_byte_offset_0(v15, v16);
    let v18: boolean = v2 === 192;
    let v64: number;
    let v65: number;
    if (v18) {
        v64 = 65;
        v65 = 768;
    } else {
        let v19: boolean = v2 === 193;
        if (v19) {
            v64 = 65;
            v65 = 769;
        } else {
            let v20: boolean = v2 === 195;
            if (v20) {
                v64 = 65;
                v65 = 771;
            } else {
                let v21: boolean = v2 === 196;
                if (v21) {
                    v64 = 65;
                    v65 = 776;
                } else {
                    let v22: boolean = v2 === 199;
                    if (v22) {
                        v64 = 67;
                        v65 = 807;
                    } else {
                        let v23: boolean = v2 === 201;
                        if (v23) {
                            v64 = 69;
                            v65 = 769;
                        } else {
                            let v24: boolean = v2 === 211;
                            if (v24) {
                                v64 = 79;
                                v65 = 769;
                            } else {
                                let v25: boolean = v2 === 213;
                                if (v25) {
                                    v64 = 79;
                                    v65 = 771;
                                } else {
                                    let v26: boolean = v2 === 224;
                                    if (v26) {
                                        v64 = 97;
                                        v65 = 768;
                                    } else {
                                        let v27: boolean = v2 === 225;
                                        if (v27) {
                                            v64 = 97;
                                            v65 = 769;
                                        } else {
                                            let v28: boolean = v2 === 227;
                                            if (v28) {
                                                v64 = 97;
                                                v65 = 771;
                                            } else {
                                                let v29: boolean = v2 === 228;
                                                if (v29) {
                                                    v64 = 97;
                                                    v65 = 776;
                                                } else {
                                                    let v30: boolean = v2 === 231;
                                                    if (v30) {
                                                        v64 = 99;
                                                        v65 = 807;
                                                    } else {
                                                        let v31: boolean = v2 === 233;
                                                        if (v31) {
                                                            v64 = 101;
                                                            v65 = 769;
                                                        } else {
                                                            let v32: boolean = v2 === 243;
                                                            if (v32) {
                                                                v64 = 111;
                                                                v65 = 769;
                                                            } else {
                                                                let v33: boolean = v2 === 245;
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
    let v66: boolean = v5 === 192;
    let v112: number;
    let v113: number;
    if (v66) {
        v112 = 65;
        v113 = 768;
    } else {
        let v67: boolean = v5 === 193;
        if (v67) {
            v112 = 65;
            v113 = 769;
        } else {
            let v68: boolean = v5 === 195;
            if (v68) {
                v112 = 65;
                v113 = 771;
            } else {
                let v69: boolean = v5 === 196;
                if (v69) {
                    v112 = 65;
                    v113 = 776;
                } else {
                    let v70: boolean = v5 === 199;
                    if (v70) {
                        v112 = 67;
                        v113 = 807;
                    } else {
                        let v71: boolean = v5 === 201;
                        if (v71) {
                            v112 = 69;
                            v113 = 769;
                        } else {
                            let v72: boolean = v5 === 211;
                            if (v72) {
                                v112 = 79;
                                v113 = 769;
                            } else {
                                let v73: boolean = v5 === 213;
                                if (v73) {
                                    v112 = 79;
                                    v113 = 771;
                                } else {
                                    let v74: boolean = v5 === 224;
                                    if (v74) {
                                        v112 = 97;
                                        v113 = 768;
                                    } else {
                                        let v75: boolean = v5 === 225;
                                        if (v75) {
                                            v112 = 97;
                                            v113 = 769;
                                        } else {
                                            let v76: boolean = v5 === 227;
                                            if (v76) {
                                                v112 = 97;
                                                v113 = 771;
                                            } else {
                                                let v77: boolean = v5 === 228;
                                                if (v77) {
                                                    v112 = 97;
                                                    v113 = 776;
                                                } else {
                                                    let v78: boolean = v5 === 231;
                                                    if (v78) {
                                                        v112 = 99;
                                                        v113 = 807;
                                                    } else {
                                                        let v79: boolean = v5 === 233;
                                                        if (v79) {
                                                            v112 = 101;
                                                            v113 = 769;
                                                        } else {
                                                            let v80: boolean = v5 === 243;
                                                            if (v80) {
                                                                v112 = 111;
                                                                v113 = 769;
                                                            } else {
                                                                let v81: boolean = v5 === 245;
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
    let v114: boolean = v8 === 192;
    let v160: number;
    let v161: number;
    if (v114) {
        v160 = 65;
        v161 = 768;
    } else {
        let v115: boolean = v8 === 193;
        if (v115) {
            v160 = 65;
            v161 = 769;
        } else {
            let v116: boolean = v8 === 195;
            if (v116) {
                v160 = 65;
                v161 = 771;
            } else {
                let v117: boolean = v8 === 196;
                if (v117) {
                    v160 = 65;
                    v161 = 776;
                } else {
                    let v118: boolean = v8 === 199;
                    if (v118) {
                        v160 = 67;
                        v161 = 807;
                    } else {
                        let v119: boolean = v8 === 201;
                        if (v119) {
                            v160 = 69;
                            v161 = 769;
                        } else {
                            let v120: boolean = v8 === 211;
                            if (v120) {
                                v160 = 79;
                                v161 = 769;
                            } else {
                                let v121: boolean = v8 === 213;
                                if (v121) {
                                    v160 = 79;
                                    v161 = 771;
                                } else {
                                    let v122: boolean = v8 === 224;
                                    if (v122) {
                                        v160 = 97;
                                        v161 = 768;
                                    } else {
                                        let v123: boolean = v8 === 225;
                                        if (v123) {
                                            v160 = 97;
                                            v161 = 769;
                                        } else {
                                            let v124: boolean = v8 === 227;
                                            if (v124) {
                                                v160 = 97;
                                                v161 = 771;
                                            } else {
                                                let v125: boolean = v8 === 228;
                                                if (v125) {
                                                    v160 = 97;
                                                    v161 = 776;
                                                } else {
                                                    let v126: boolean = v8 === 231;
                                                    if (v126) {
                                                        v160 = 99;
                                                        v161 = 807;
                                                    } else {
                                                        let v127: boolean = v8 === 233;
                                                        if (v127) {
                                                            v160 = 101;
                                                            v161 = 769;
                                                        } else {
                                                            let v128: boolean = v8 === 243;
                                                            if (v128) {
                                                                v160 = 111;
                                                                v161 = 769;
                                                            } else {
                                                                let v129: boolean = v8 === 245;
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
    let v162: boolean = v11 === 769;
    let v163: number;
    if (v162) {
        v163 = 233;
    } else {
        v163 = (-1);
    }
    let v164: boolean = v163 < 0;
    let v165: number;
    let v166: number;
    if (v164) {
        v165 = 101;
        v166 = v11;
    } else {
        v165 = v163;
        v166 = (-1);
    }
    let v167: boolean = v14 === 769;
    let v170: number;
    if (v167) {
        v170 = 243;
    } else {
        let v168: boolean = v14 === 771;
        if (v168) {
            v170 = 245;
        } else {
            v170 = (-1);
        }
    }
    let v171: boolean = v170 < 0;
    let v172: number;
    let v173: number;
    if (v171) {
        v172 = 111;
        v173 = v14;
    } else {
        v172 = v170;
        v173 = (-1);
    }
    let v174: boolean = v17 === 807;
    let v175: number;
    if (v174) {
        v175 = 231;
    } else {
        v175 = (-1);
    }
    let v176: boolean = v175 < 0;
    let v177: number;
    let v178: number;
    if (v176) {
        v177 = 99;
        v178 = v17;
    } else {
        v177 = v175;
        v178 = (-1);
    }
    let v179: boolean = v64 === 101;
    let v181: boolean;
    if (v179) {
        let v180: boolean = v65 === v11;
        v181 = v180;
    } else {
        v181 = false;
    }
    if (v181) {
        let v182: boolean = v112 === 111;
        let v184: boolean;
        if (v182) {
            let v183: boolean = v113 === v14;
            v184 = v183;
        } else {
            v184 = false;
        }
        if (v184) {
            let v185: boolean = v160 === 99;
            let v187: boolean;
            if (v185) {
                let v186: boolean = v161 === v17;
                v187 = v186;
            } else {
                v187 = false;
            }
            if (v187) {
                let v188: boolean = v165 === v2;
                let v190: boolean;
                if (v188) {
                    let v189: boolean = v166 === (-1);
                    v190 = v189;
                } else {
                    v190 = false;
                }
                if (v190) {
                    let v191: boolean = v172 === v5;
                    let v193: boolean;
                    if (v191) {
                        let v192: boolean = v173 === (-1);
                        v193 = v192;
                    } else {
                        v193 = false;
                    }
                    if (v193) {
                        let v194: boolean = v177 === v8;
                        let v196: boolean;
                        if (v194) {
                            let v195: boolean = v178 === (-1);
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
