import CRT
import WinSDK
func spiralStringLength(_ value: String) -> Int32 { Int32(value.utf8.count) }
func spiralStringIndex(_ value: String, _ index: Int32) -> Int32 {
    let bytes = Array(value.utf8)
    let i = Int(index)
    if !(i >= 0 && i < bytes.count) {
        _ = fputs("string index out of bounds\n", stderr)
        exit(1)
    }
    return Int32(Int8(bitPattern: bytes[i]))
}
func spiralStringSlice(_ value: String, _ from: Int32, _ to: Int32) -> String {
    let bytes = Array(value.utf8)
    let length = bytes.count
    let f = Int(from)
    let t = Int(to)
    if f < 0 || f > length || t < f - 1 || t >= length {
        _ = fputs("string slice out of bounds\n", stderr)
        exit(3)
    }
    if t < f { return "" }
    let start = Int(bytes[f])
    let follows = t + 1 < length && (Int(bytes[t + 1]) & 192) == 128
    if (start & 192) == 128 || follows {
        _ = fputs("string slice splits a code point\n", stderr)
        exit(3)
    }
    return String(decoding: bytes[f...t], as: UTF8.self)
}
func sp_runtime_byte_1(_ p0: String, _ p1: Int32) -> Int32 {
    var v0: String = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    v2 = spiralStringIndex(v0, v1)
    return v2
}
func sp_utf8_scalar_at_byte_offset_0(_ p0: String, _ p1: Int32) -> Int32 {
    var v0: String = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    v2 = spiralStringLength(v0)
    var v3: Bool = false
    v3 = (v1 < 0)
    if (v3) {
        "UTF-8 byte offset is negative.".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    } else {
        var v5: Bool = false
        v5 = (v1 >= v2)
        if (v5) {
            "UTF-8 byte offset is outside the string.".withCString { ptr in _ = fputs(ptr, stderr) }
            fputs("\n", stderr)
            exit(1)
        } else {
            var v7: Int32 = 0
            v7 = sp_runtime_byte_1(v0, v1)
            var v8: Int32 = 0
            v8 = (v7 & 255)
            var v9: Bool = false
            v9 = (v8 < 128)
            if (v9) {
                return v8
            } else {
                var v10: Bool = false
                v10 = (v8 < 194)
                if (v10) {
                    "UTF-8 scalar starts with an invalid lead byte.".withCString { ptr in _ = fputs(ptr, stderr) }
                    fputs("\n", stderr)
                    exit(1)
                } else {
                    var v12: Bool = false
                    v12 = (v8 < 224)
                    if (v12) {
                        var v13: Int32 = 0
                        v13 = (v1 &+ 1)
                        var v14: Bool = false
                        v14 = (v13 >= v2)
                        if (v14) {
                            "UTF-8 sequence is truncated.".withCString { ptr in _ = fputs(ptr, stderr) }
                            fputs("\n", stderr)
                            exit(1)
                        } else {
                            var v16: Int32 = 0
                            v16 = sp_runtime_byte_1(v0, v13)
                            var v17: Int32 = 0
                            v17 = (v16 & 255)
                            var v18: Bool = false
                            v18 = (v17 < 128)
                            var v20: Bool = false
                            if (v18) {
                                v20 = false
                            } else {
                                var v19: Bool = false
                                v19 = (v17 < 192)
                                v20 = v19
                            }
                            if (v20) {
                                var v21: Int32 = 0
                                v21 = (v8 &- 192)
                                var v22: Int32 = 0
                                v22 = (v21 &* 64)
                                var v23: Int32 = 0
                                v23 = (v17 &- 128)
                                var v24: Int32 = 0
                                v24 = (v22 &+ v23)
                                return v24
                            } else {
                                "UTF-8 sequence has an invalid continuation byte.".withCString { ptr in _ = fputs(ptr, stderr) }
                                fputs("\n", stderr)
                                exit(1)
                            }
                        }
                    } else {
                        var v28: Bool = false
                        v28 = (v8 < 240)
                        if (v28) {
                            var v29: Int32 = 0
                            v29 = (v1 &+ 2)
                            var v30: Bool = false
                            v30 = (v29 >= v2)
                            if (v30) {
                                "UTF-8 sequence is truncated.".withCString { ptr in _ = fputs(ptr, stderr) }
                                fputs("\n", stderr)
                                exit(1)
                            } else {
                                var v32: Int32 = 0
                                v32 = (v1 &+ 1)
                                var v33: Int32 = 0
                                v33 = sp_runtime_byte_1(v0, v32)
                                let v34: Int32 = (v33 & 255)
                                let v35: Int32 = sp_runtime_byte_1(v0, v29)
                                let v36: Int32 = (v35 & 255)
                                let v37: Bool = (v34 < 128)
                                var v39: Bool = false
                                if (v37) {
                                    v39 = false
                                } else {
                                    let v38: Bool = (v34 < 192)
                                    v39 = v38
                                }
                                if (v39) {
                                    let v40: Bool = (v36 < 128)
                                    var v42: Bool = false
                                    if (v40) {
                                        v42 = false
                                    } else {
                                        let v41: Bool = (v36 < 192)
                                        v42 = v41
                                    }
                                    if (v42) {
                                        let v43: Int32 = (v8 &- 224)
                                        let v44: Int32 = (v43 &* 4096)
                                        let v45: Int32 = (v34 &- 128)
                                        let v46: Int32 = (v45 &* 64)
                                        let v47: Int32 = (v44 &+ v46)
                                        let v48: Int32 = (v36 &- 128)
                                        let v49: Int32 = (v47 &+ v48)
                                        let v50: Bool = (v49 < 2048)
                                        if (v50) {
                                            "UTF-8 sequence is overlong.".withCString { ptr in _ = fputs(ptr, stderr) }
                                            fputs("\n", stderr)
                                            exit(1)
                                        } else {
                                            let v52: Bool = (v49 >= 55296)
                                            if (v52) {
                                                let v53: Bool = (v49 <= 57343)
                                                if (v53) {
                                                    "UTF-8 sequence encodes a surrogate.".withCString { ptr in _ = fputs(ptr, stderr) }
                                                    fputs("\n", stderr)
                                                    exit(1)
                                                } else {
                                                    return v49
                                                }
                                            } else {
                                                return v49
                                            }
                                        }
                                    } else {
                                        "UTF-8 sequence has an invalid continuation byte.".withCString { ptr in _ = fputs(ptr, stderr) }
                                        fputs("\n", stderr)
                                        exit(1)
                                    }
                                } else {
                                    "UTF-8 sequence has an invalid continuation byte.".withCString { ptr in _ = fputs(ptr, stderr) }
                                    fputs("\n", stderr)
                                    exit(1)
                                }
                            }
                        } else {
                            let v63: Bool = (v8 < 245)
                            if (v63) {
                                var v64: Int32 = 0
                                v64 = (v1 &+ 3)
                                var v65: Bool = false
                                v65 = (v64 >= v2)
                                if (v65) {
                                    "UTF-8 sequence is truncated.".withCString { ptr in _ = fputs(ptr, stderr) }
                                    fputs("\n", stderr)
                                    exit(1)
                                } else {
                                    var v67: Int32 = 0
                                    v67 = (v1 &+ 1)
                                    var v68: Int32 = 0
                                    v68 = sp_runtime_byte_1(v0, v67)
                                    var v69: Int32 = 0
                                    v69 = (v68 & 255)
                                    var v70: Int32 = 0
                                    v70 = (v1 &+ 2)
                                    var v71: Int32 = 0
                                    v71 = sp_runtime_byte_1(v0, v70)
                                    var v72: Int32 = 0
                                    v72 = (v71 & 255)
                                    var v73: Int32 = 0
                                    v73 = sp_runtime_byte_1(v0, v64)
                                    var v74: Int32 = 0
                                    v74 = (v73 & 255)
                                    var v75: Bool = false
                                    v75 = (v69 < 128)
                                    var v77: Bool = false
                                    if (v75) {
                                        v77 = false
                                    } else {
                                        var v76: Bool = false
                                        v76 = (v69 < 192)
                                        v77 = v76
                                    }
                                    if (v77) {
                                        var v78: Bool = false
                                        v78 = (v72 < 128)
                                        var v80: Bool = false
                                        if (v78) {
                                            v80 = false
                                        } else {
                                            var v79: Bool = false
                                            v79 = (v72 < 192)
                                            v80 = v79
                                        }
                                        if (v80) {
                                            var v81: Bool = false
                                            v81 = (v74 < 128)
                                            var v83: Bool = false
                                            if (v81) {
                                                v83 = false
                                            } else {
                                                let v82: Bool = (v74 < 192)
                                                v83 = v82
                                            }
                                            if (v83) {
                                                let v84: Int32 = (v8 &- 240)
                                                let v85: Int32 = (v84 &* 262144)
                                                let v86: Int32 = (v69 &- 128)
                                                let v87: Int32 = (v86 &* 4096)
                                                let v88: Int32 = (v85 &+ v87)
                                                let v89: Int32 = (v72 &- 128)
                                                let v90: Int32 = (v89 &* 64)
                                                let v91: Int32 = (v88 &+ v90)
                                                let v92: Int32 = (v74 &- 128)
                                                let v93: Int32 = (v91 &+ v92)
                                                let v94: Bool = (v93 < 65536)
                                                if (v94) {
                                                    "UTF-8 sequence is overlong.".withCString { ptr in _ = fputs(ptr, stderr) }
                                                    fputs("\n", stderr)
                                                    exit(1)
                                                } else {
                                                    let v96: Bool = (v93 > 1114111)
                                                    if (v96) {
                                                        "UTF-8 scalar is above U+10FFFF.".withCString { ptr in _ = fputs(ptr, stderr) }
                                                        fputs("\n", stderr)
                                                        exit(1)
                                                    } else {
                                                        return v93
                                                    }
                                                }
                                            } else {
                                                "UTF-8 sequence has an invalid continuation byte.".withCString { ptr in _ = fputs(ptr, stderr) }
                                                fputs("\n", stderr)
                                                exit(1)
                                            }
                                        } else {
                                            "UTF-8 sequence has an invalid continuation byte.".withCString { ptr in _ = fputs(ptr, stderr) }
                                            fputs("\n", stderr)
                                            exit(1)
                                        }
                                    } else {
                                        "UTF-8 sequence has an invalid continuation byte.".withCString { ptr in _ = fputs(ptr, stderr) }
                                        fputs("\n", stderr)
                                        exit(1)
                                    }
                                }
                            } else {
                                "UTF-8 scalar starts with an invalid lead byte.".withCString { ptr in _ = fputs(ptr, stderr) }
                                fputs("\n", stderr)
                                exit(1)
                            }
                        }
                    }
                }
            }
        }
    }
}
func spiral_main() -> Int32 {
    let v0: String = "é"
    let v1: Int32 = 0
    var v2: Int32 = 0
    v2 = sp_utf8_scalar_at_byte_offset_0(v0, v1)
    var v3: String = ""
    v3 = "õ"
    let v4: Int32 = 0
    var v5: Int32 = 0
    v5 = sp_utf8_scalar_at_byte_offset_0(v3, v4)
    let v6: String = "ç"
    var v7: Int32 = 0
    v7 = 0
    var v8: Int32 = 0
    v8 = sp_utf8_scalar_at_byte_offset_0(v6, v7)
    var v9: String = ""
    v9 = "́"
    var v10: Int32 = 0
    v10 = 0
    let v11: Int32 = sp_utf8_scalar_at_byte_offset_0(v9, v10)
    var v12: String = ""
    v12 = "̃"
    var v13: Int32 = 0
    v13 = 0
    var v14: Int32 = 0
    v14 = sp_utf8_scalar_at_byte_offset_0(v12, v13)
    let v15: String = "̧"
    var v16: Int32 = 0
    v16 = 0
    var v17: Int32 = 0
    v17 = sp_utf8_scalar_at_byte_offset_0(v15, v16)
    var v18: Bool = false
    v18 = (v2 == 192)
    var v64: Int32 = 0
    var v65: Int32 = 0
    if (v18) {
        v64 = 65
        v65 = 768
    } else {
        var v19: Bool = false
        v19 = (v2 == 193)
        if (v19) {
            v64 = 65
            v65 = 769
        } else {
            var v20: Bool = false
            v20 = (v2 == 195)
            if (v20) {
                v64 = 65
                v65 = 771
            } else {
                var v21: Bool = false
                v21 = (v2 == 196)
                if (v21) {
                    v64 = 65
                    v65 = 776
                } else {
                    var v22: Bool = false
                    v22 = (v2 == 199)
                    if (v22) {
                        v64 = 67
                        v65 = 807
                    } else {
                        var v23: Bool = false
                        v23 = (v2 == 201)
                        if (v23) {
                            v64 = 69
                            v65 = 769
                        } else {
                            var v24: Bool = false
                            v24 = (v2 == 211)
                            if (v24) {
                                v64 = 79
                                v65 = 769
                            } else {
                                let v25: Bool = (v2 == 213)
                                if (v25) {
                                    v64 = 79
                                    v65 = 771
                                } else {
                                    let v26: Bool = (v2 == 224)
                                    if (v26) {
                                        v64 = 97
                                        v65 = 768
                                    } else {
                                        let v27: Bool = (v2 == 225)
                                        if (v27) {
                                            v64 = 97
                                            v65 = 769
                                        } else {
                                            var v28: Bool = false
                                            v28 = (v2 == 227)
                                            if (v28) {
                                                v64 = 97
                                                v65 = 771
                                            } else {
                                                var v29: Bool = false
                                                v29 = (v2 == 228)
                                                if (v29) {
                                                    v64 = 97
                                                    v65 = 776
                                                } else {
                                                    var v30: Bool = false
                                                    v30 = (v2 == 231)
                                                    if (v30) {
                                                        v64 = 99
                                                        v65 = 807
                                                    } else {
                                                        let v31: Bool = (v2 == 233)
                                                        if (v31) {
                                                            v64 = 101
                                                            v65 = 769
                                                        } else {
                                                            var v32: Bool = false
                                                            v32 = (v2 == 243)
                                                            if (v32) {
                                                                v64 = 111
                                                                v65 = 769
                                                            } else {
                                                                var v33: Bool = false
                                                                v33 = (v2 == 245)
                                                                if (v33) {
                                                                    v64 = 111
                                                                    v65 = 771
                                                                } else {
                                                                    v64 = v2
                                                                    v65 = -1
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
    let v66: Bool = (v5 == 192)
    var v112: Int32 = 0
    var v113: Int32 = 0
    if (v66) {
        v112 = 65
        v113 = 768
    } else {
        var v67: Bool = false
        v67 = (v5 == 193)
        if (v67) {
            v112 = 65
            v113 = 769
        } else {
            var v68: Bool = false
            v68 = (v5 == 195)
            if (v68) {
                v112 = 65
                v113 = 771
            } else {
                var v69: Bool = false
                v69 = (v5 == 196)
                if (v69) {
                    v112 = 65
                    v113 = 776
                } else {
                    var v70: Bool = false
                    v70 = (v5 == 199)
                    if (v70) {
                        v112 = 67
                        v113 = 807
                    } else {
                        var v71: Bool = false
                        v71 = (v5 == 201)
                        if (v71) {
                            v112 = 69
                            v113 = 769
                        } else {
                            var v72: Bool = false
                            v72 = (v5 == 211)
                            if (v72) {
                                v112 = 79
                                v113 = 769
                            } else {
                                var v73: Bool = false
                                v73 = (v5 == 213)
                                if (v73) {
                                    v112 = 79
                                    v113 = 771
                                } else {
                                    var v74: Bool = false
                                    v74 = (v5 == 224)
                                    if (v74) {
                                        v112 = 97
                                        v113 = 768
                                    } else {
                                        var v75: Bool = false
                                        v75 = (v5 == 225)
                                        if (v75) {
                                            v112 = 97
                                            v113 = 769
                                        } else {
                                            var v76: Bool = false
                                            v76 = (v5 == 227)
                                            if (v76) {
                                                v112 = 97
                                                v113 = 771
                                            } else {
                                                var v77: Bool = false
                                                v77 = (v5 == 228)
                                                if (v77) {
                                                    v112 = 97
                                                    v113 = 776
                                                } else {
                                                    var v78: Bool = false
                                                    v78 = (v5 == 231)
                                                    if (v78) {
                                                        v112 = 99
                                                        v113 = 807
                                                    } else {
                                                        var v79: Bool = false
                                                        v79 = (v5 == 233)
                                                        if (v79) {
                                                            v112 = 101
                                                            v113 = 769
                                                        } else {
                                                            var v80: Bool = false
                                                            v80 = (v5 == 243)
                                                            if (v80) {
                                                                v112 = 111
                                                                v113 = 769
                                                            } else {
                                                                var v81: Bool = false
                                                                v81 = (v5 == 245)
                                                                if (v81) {
                                                                    v112 = 111
                                                                    v113 = 771
                                                                } else {
                                                                    v112 = v5
                                                                    v113 = -1
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
    let v114: Bool = (v8 == 192)
    var v160: Int32 = 0
    var v161: Int32 = 0
    if (v114) {
        v160 = 65
        v161 = 768
    } else {
        let v115: Bool = (v8 == 193)
        if (v115) {
            v160 = 65
            v161 = 769
        } else {
            let v116: Bool = (v8 == 195)
            if (v116) {
                v160 = 65
                v161 = 771
            } else {
                let v117: Bool = (v8 == 196)
                if (v117) {
                    v160 = 65
                    v161 = 776
                } else {
                    let v118: Bool = (v8 == 199)
                    if (v118) {
                        v160 = 67
                        v161 = 807
                    } else {
                        let v119: Bool = (v8 == 201)
                        if (v119) {
                            v160 = 69
                            v161 = 769
                        } else {
                            let v120: Bool = (v8 == 211)
                            if (v120) {
                                v160 = 79
                                v161 = 769
                            } else {
                                let v121: Bool = (v8 == 213)
                                if (v121) {
                                    v160 = 79
                                    v161 = 771
                                } else {
                                    let v122: Bool = (v8 == 224)
                                    if (v122) {
                                        v160 = 97
                                        v161 = 768
                                    } else {
                                        let v123: Bool = (v8 == 225)
                                        if (v123) {
                                            v160 = 97
                                            v161 = 769
                                        } else {
                                            let v124: Bool = (v8 == 227)
                                            if (v124) {
                                                v160 = 97
                                                v161 = 771
                                            } else {
                                                let v125: Bool = (v8 == 228)
                                                if (v125) {
                                                    v160 = 97
                                                    v161 = 776
                                                } else {
                                                    let v126: Bool = (v8 == 231)
                                                    if (v126) {
                                                        v160 = 99
                                                        v161 = 807
                                                    } else {
                                                        let v127: Bool = (v8 == 233)
                                                        if (v127) {
                                                            v160 = 101
                                                            v161 = 769
                                                        } else {
                                                            let v128: Bool = (v8 == 243)
                                                            if (v128) {
                                                                v160 = 111
                                                                v161 = 769
                                                            } else {
                                                                let v129: Bool = (v8 == 245)
                                                                if (v129) {
                                                                    v160 = 111
                                                                    v161 = 771
                                                                } else {
                                                                    v160 = v8
                                                                    v161 = -1
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
    let v162: Bool = (v11 == 769)
    var v163: Int32 = 0
    if (v162) {
        v163 = 233
    } else {
        v163 = -1
    }
    let v164: Bool = (v163 < 0)
    var v165: Int32 = 0
    var v166: Int32 = 0
    if (v164) {
        v165 = 101
        v166 = v11
    } else {
        v165 = v163
        v166 = -1
    }
    let v167: Bool = (v14 == 769)
    var v170: Int32 = 0
    if (v167) {
        v170 = 243
    } else {
        let v168: Bool = (v14 == 771)
        if (v168) {
            v170 = 245
        } else {
            v170 = -1
        }
    }
    let v171: Bool = (v170 < 0)
    var v172: Int32 = 0
    var v173: Int32 = 0
    if (v171) {
        v172 = 111
        v173 = v14
    } else {
        v172 = v170
        v173 = -1
    }
    let v174: Bool = (v17 == 807)
    var v175: Int32 = 0
    if (v174) {
        v175 = 231
    } else {
        v175 = -1
    }
    let v176: Bool = (v175 < 0)
    var v177: Int32 = 0
    var v178: Int32 = 0
    if (v176) {
        v177 = 99
        v178 = v17
    } else {
        v177 = v175
        v178 = -1
    }
    let v179: Bool = (v64 == 101)
    var v181: Bool = false
    if (v179) {
        let v180: Bool = (v65 == v11)
        v181 = v180
    } else {
        v181 = false
    }
    if (v181) {
        let v182: Bool = (v112 == 111)
        var v184: Bool = false
        if (v182) {
            let v183: Bool = (v113 == v14)
            v184 = v183
        } else {
            v184 = false
        }
        if (v184) {
            let v185: Bool = (v160 == 99)
            var v187: Bool = false
            if (v185) {
                let v186: Bool = (v161 == v17)
                v187 = v186
            } else {
                v187 = false
            }
            if (v187) {
                let v188: Bool = (v165 == v2)
                var v190: Bool = false
                if (v188) {
                    let v189: Bool = (v166 == -1)
                    v190 = v189
                } else {
                    v190 = false
                }
                if (v190) {
                    let v191: Bool = (v172 == v5)
                    var v193: Bool = false
                    if (v191) {
                        let v192: Bool = (v173 == -1)
                        v193 = v192
                    } else {
                        v193 = false
                    }
                    if (v193) {
                        let v194: Bool = (v177 == v8)
                        var v196: Bool = false
                        if (v194) {
                            let v195: Bool = (v178 == -1)
                            v196 = v195
                        } else {
                            v196 = false
                        }
                        if (v196) {
                            return 0
                        } else {
                            return 6
                        }
                    } else {
                        return 5
                    }
                } else {
                    return 4
                }
            } else {
                return 3
            }
        } else {
            return 2
        }
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
