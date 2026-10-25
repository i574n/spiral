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
func sp_runtime_byte_2(_ p0: String, _ p1: Int32) -> Int32 {
    var v0: String = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    v2 = spiralStringIndex(v0, v1)
    return v2
}
func sp_utf8_scalar_at_byte_offset_1(_ p0: String, _ p1: Int32) -> Int32 {
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
            v7 = sp_runtime_byte_2(v0, v1)
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
                            v16 = sp_runtime_byte_2(v0, v13)
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
                                v33 = sp_runtime_byte_2(v0, v32)
                                var v34: Int32 = 0
                                v34 = (v33 & 255)
                                var v35: Int32 = 0
                                v35 = sp_runtime_byte_2(v0, v29)
                                var v36: Int32 = 0
                                v36 = (v35 & 255)
                                var v37: Bool = false
                                v37 = (v34 < 128)
                                var v39: Bool = false
                                if (v37) {
                                    v39 = false
                                } else {
                                    var v38: Bool = false
                                    v38 = (v34 < 192)
                                    v39 = v38
                                }
                                if (v39) {
                                    var v40: Bool = false
                                    v40 = (v36 < 128)
                                    var v42: Bool = false
                                    if (v40) {
                                        v42 = false
                                    } else {
                                        var v41: Bool = false
                                        v41 = (v36 < 192)
                                        v42 = v41
                                    }
                                    if (v42) {
                                        var v43: Int32 = 0
                                        v43 = (v8 &- 224)
                                        var v44: Int32 = 0
                                        v44 = (v43 &* 4096)
                                        var v45: Int32 = 0
                                        v45 = (v34 &- 128)
                                        var v46: Int32 = 0
                                        v46 = (v45 &* 64)
                                        var v47: Int32 = 0
                                        v47 = (v44 &+ v46)
                                        var v48: Int32 = 0
                                        v48 = (v36 &- 128)
                                        var v49: Int32 = 0
                                        v49 = (v47 &+ v48)
                                        var v50: Bool = false
                                        v50 = (v49 < 2048)
                                        if (v50) {
                                            "UTF-8 sequence is overlong.".withCString { ptr in _ = fputs(ptr, stderr) }
                                            fputs("\n", stderr)
                                            exit(1)
                                        } else {
                                            var v52: Bool = false
                                            v52 = (v49 >= 55296)
                                            if (v52) {
                                                var v53: Bool = false
                                                v53 = (v49 <= 57343)
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
                            var v63: Bool = false
                            v63 = (v8 < 245)
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
                                    v68 = sp_runtime_byte_2(v0, v67)
                                    var v69: Int32 = 0
                                    v69 = (v68 & 255)
                                    var v70: Int32 = 0
                                    v70 = (v1 &+ 2)
                                    var v71: Int32 = 0
                                    v71 = sp_runtime_byte_2(v0, v70)
                                    var v72: Int32 = 0
                                    v72 = (v71 & 255)
                                    var v73: Int32 = 0
                                    v73 = sp_runtime_byte_2(v0, v64)
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
                                                var v82: Bool = false
                                                v82 = (v74 < 192)
                                                v83 = v82
                                            }
                                            if (v83) {
                                                var v84: Int32 = 0
                                                v84 = (v8 &- 240)
                                                var v85: Int32 = 0
                                                v85 = (v84 &* 262144)
                                                var v86: Int32 = 0
                                                v86 = (v69 &- 128)
                                                var v87: Int32 = 0
                                                v87 = (v86 &* 4096)
                                                var v88: Int32 = 0
                                                v88 = (v85 &+ v87)
                                                var v89: Int32 = 0
                                                v89 = (v72 &- 128)
                                                var v90: Int32 = 0
                                                v90 = (v89 &* 64)
                                                var v91: Int32 = 0
                                                v91 = (v88 &+ v90)
                                                var v92: Int32 = 0
                                                v92 = (v74 &- 128)
                                                var v93: Int32 = 0
                                                v93 = (v91 &+ v92)
                                                var v94: Bool = false
                                                v94 = (v93 < 65536)
                                                if (v94) {
                                                    "UTF-8 sequence is overlong.".withCString { ptr in _ = fputs(ptr, stderr) }
                                                    fputs("\n", stderr)
                                                    exit(1)
                                                } else {
                                                    var v96: Bool = false
                                                    v96 = (v93 > 1114111)
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
func sp_utf8_canonical_equal_bounded_loop_0(_ p0: String, _ p1: String, _ p2: Int32, _ p3: Int32, _ p4: Int32, _ p5: Int32, _ p6: Int32, _ p7: Int32) -> Bool {
    var v0: String = p0
    var v1: String = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    var v4: Int32 = p4
    var v5: Int32 = p5
    var v6: Int32 = p6
    var v7: Int32 = p7
    while true {
        var v8: Bool = false
        v8 = (v4 >= 0)
        var v76: Int32 = 0
        var v77: Int32 = 0
        var v78: Int32 = 0
        if (v8) {
            v76 = v4
            v77 = v2
            v78 = -1
        } else {
            var v9: Bool = false
            v9 = (v2 == v6)
            if (v9) {
                v76 = -1
                v77 = v2
                v78 = -1
            } else {
                var v10: Bool = false
                v10 = (v2 > v6)
                if (v10) {
                    "UTF-8 canonical stream offset exceeds the string.".withCString { ptr in _ = fputs(ptr, stderr) }
                    fputs("\n", stderr)
                    exit(1)
                } else {
                    var v14: Int32 = 0
                    v14 = sp_utf8_scalar_at_byte_offset_1(v0, v2)
                    var v15: Bool = false
                    v15 = (v14 < 128)
                    var v20: Int32 = 0
                    if (v15) {
                        v20 = 1
                    } else {
                        var v16: Bool = false
                        v16 = (v14 < 2048)
                        if (v16) {
                            v20 = 2
                        } else {
                            var v17: Bool = false
                            v17 = (v14 < 65536)
                            if (v17) {
                                v20 = 3
                            } else {
                                v20 = 4
                            }
                        }
                    }
                    var v21: Bool = false
                    v21 = (v14 == 192)
                    var v67: Int32 = 0
                    var v68: Int32 = 0
                    if (v21) {
                        v67 = 65
                        v68 = 768
                    } else {
                        var v22: Bool = false
                        v22 = (v14 == 193)
                        if (v22) {
                            v67 = 65
                            v68 = 769
                        } else {
                            var v23: Bool = false
                            v23 = (v14 == 195)
                            if (v23) {
                                v67 = 65
                                v68 = 771
                            } else {
                                var v24: Bool = false
                                v24 = (v14 == 196)
                                if (v24) {
                                    v67 = 65
                                    v68 = 776
                                } else {
                                    var v25: Bool = false
                                    v25 = (v14 == 199)
                                    if (v25) {
                                        v67 = 67
                                        v68 = 807
                                    } else {
                                        var v26: Bool = false
                                        v26 = (v14 == 201)
                                        if (v26) {
                                            v67 = 69
                                            v68 = 769
                                        } else {
                                            var v27: Bool = false
                                            v27 = (v14 == 211)
                                            if (v27) {
                                                v67 = 79
                                                v68 = 769
                                            } else {
                                                var v28: Bool = false
                                                v28 = (v14 == 213)
                                                if (v28) {
                                                    v67 = 79
                                                    v68 = 771
                                                } else {
                                                    var v29: Bool = false
                                                    v29 = (v14 == 224)
                                                    if (v29) {
                                                        v67 = 97
                                                        v68 = 768
                                                    } else {
                                                        var v30: Bool = false
                                                        v30 = (v14 == 225)
                                                        if (v30) {
                                                            v67 = 97
                                                            v68 = 769
                                                        } else {
                                                            var v31: Bool = false
                                                            v31 = (v14 == 227)
                                                            if (v31) {
                                                                v67 = 97
                                                                v68 = 771
                                                            } else {
                                                                var v32: Bool = false
                                                                v32 = (v14 == 228)
                                                                if (v32) {
                                                                    v67 = 97
                                                                    v68 = 776
                                                                } else {
                                                                    var v33: Bool = false
                                                                    v33 = (v14 == 231)
                                                                    if (v33) {
                                                                        v67 = 99
                                                                        v68 = 807
                                                                    } else {
                                                                        var v34: Bool = false
                                                                        v34 = (v14 == 233)
                                                                        if (v34) {
                                                                            v67 = 101
                                                                            v68 = 769
                                                                        } else {
                                                                            var v35: Bool = false
                                                                            v35 = (v14 == 243)
                                                                            if (v35) {
                                                                                v67 = 111
                                                                                v68 = 769
                                                                            } else {
                                                                                var v36: Bool = false
                                                                                v36 = (v14 == 245)
                                                                                if (v36) {
                                                                                    v67 = 111
                                                                                    v68 = 771
                                                                                } else {
                                                                                    v67 = v14
                                                                                    v68 = -1
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
                    var v69: Int32 = 0
                    v69 = (v2 &+ v20)
                    v76 = v67
                    v77 = v69
                    v78 = v68
                }
            }
        }
        var v79: Bool = false
        v79 = (v5 >= 0)
        var v147: Int32 = 0
        var v148: Int32 = 0
        var v149: Int32 = 0
        if (v79) {
            v147 = v5
            v148 = v3
            v149 = -1
        } else {
            var v80: Bool = false
            v80 = (v3 == v7)
            if (v80) {
                v147 = -1
                v148 = v3
                v149 = -1
            } else {
                var v81: Bool = false
                v81 = (v3 > v7)
                if (v81) {
                    "UTF-8 canonical stream offset exceeds the string.".withCString { ptr in _ = fputs(ptr, stderr) }
                    fputs("\n", stderr)
                    exit(1)
                } else {
                    var v85: Int32 = 0
                    v85 = sp_utf8_scalar_at_byte_offset_1(v1, v3)
                    var v86: Bool = false
                    v86 = (v85 < 128)
                    var v91: Int32 = 0
                    if (v86) {
                        v91 = 1
                    } else {
                        var v87: Bool = false
                        v87 = (v85 < 2048)
                        if (v87) {
                            v91 = 2
                        } else {
                            var v88: Bool = false
                            v88 = (v85 < 65536)
                            if (v88) {
                                v91 = 3
                            } else {
                                v91 = 4
                            }
                        }
                    }
                    var v92: Bool = false
                    v92 = (v85 == 192)
                    var v138: Int32 = 0
                    var v139: Int32 = 0
                    if (v92) {
                        v138 = 65
                        v139 = 768
                    } else {
                        var v93: Bool = false
                        v93 = (v85 == 193)
                        if (v93) {
                            v138 = 65
                            v139 = 769
                        } else {
                            var v94: Bool = false
                            v94 = (v85 == 195)
                            if (v94) {
                                v138 = 65
                                v139 = 771
                            } else {
                                var v95: Bool = false
                                v95 = (v85 == 196)
                                if (v95) {
                                    v138 = 65
                                    v139 = 776
                                } else {
                                    var v96: Bool = false
                                    v96 = (v85 == 199)
                                    if (v96) {
                                        v138 = 67
                                        v139 = 807
                                    } else {
                                        var v97: Bool = false
                                        v97 = (v85 == 201)
                                        if (v97) {
                                            v138 = 69
                                            v139 = 769
                                        } else {
                                            var v98: Bool = false
                                            v98 = (v85 == 211)
                                            if (v98) {
                                                v138 = 79
                                                v139 = 769
                                            } else {
                                                var v99: Bool = false
                                                v99 = (v85 == 213)
                                                if (v99) {
                                                    v138 = 79
                                                    v139 = 771
                                                } else {
                                                    var v100: Bool = false
                                                    v100 = (v85 == 224)
                                                    if (v100) {
                                                        v138 = 97
                                                        v139 = 768
                                                    } else {
                                                        var v101: Bool = false
                                                        v101 = (v85 == 225)
                                                        if (v101) {
                                                            v138 = 97
                                                            v139 = 769
                                                        } else {
                                                            var v102: Bool = false
                                                            v102 = (v85 == 227)
                                                            if (v102) {
                                                                v138 = 97
                                                                v139 = 771
                                                            } else {
                                                                var v103: Bool = false
                                                                v103 = (v85 == 228)
                                                                if (v103) {
                                                                    v138 = 97
                                                                    v139 = 776
                                                                } else {
                                                                    var v104: Bool = false
                                                                    v104 = (v85 == 231)
                                                                    if (v104) {
                                                                        v138 = 99
                                                                        v139 = 807
                                                                    } else {
                                                                        var v105: Bool = false
                                                                        v105 = (v85 == 233)
                                                                        if (v105) {
                                                                            v138 = 101
                                                                            v139 = 769
                                                                        } else {
                                                                            var v106: Bool = false
                                                                            v106 = (v85 == 243)
                                                                            if (v106) {
                                                                                v138 = 111
                                                                                v139 = 769
                                                                            } else {
                                                                                var v107: Bool = false
                                                                                v107 = (v85 == 245)
                                                                                if (v107) {
                                                                                    v138 = 111
                                                                                    v139 = 771
                                                                                } else {
                                                                                    v138 = v85
                                                                                    v139 = -1
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
                    var v140: Int32 = 0
                    v140 = (v3 &+ v91)
                    v147 = v138
                    v148 = v140
                    v149 = v139
                }
            }
        }
        var v150: Bool = false
        v150 = (v76 < 0)
        if (v150) {
            var v151: Bool = false
            v151 = (v147 == -1)
            return v151
        } else {
            var v152: Bool = false
            v152 = (v147 < 0)
            if (v152) {
                return false
            } else {
                var v153: Bool = false
                v153 = (v76 == v147)
                if (v153) {
                    let t19390_0: String = v0
                    let t19437_1: String = v1
                    let t19484_77: Int32 = v77
                    let t19532_148: Int32 = v148
                    let t19582_78: Int32 = v78
                    let t19630_149: Int32 = v149
                    let t19680_6: Int32 = v6
                    let t19726_7: Int32 = v7
                    v0 = t19390_0
                    v1 = t19437_1
                    v2 = t19484_77
                    v3 = t19532_148
                    v4 = t19582_78
                    v5 = t19630_149
                    v6 = t19680_6
                    v7 = t19726_7
                    continue
                } else {
                    return false
                }
            }
        }
    }
    return false
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "plain"
    var v1: Int32 = 0
    v1 = 0
    var v2: Int32 = 0
    v2 = 0
    var v3: Int32 = 0
    v3 = -1
    var v4: Int32 = 0
    v4 = -1
    var v5: Int32 = 0
    v5 = 5
    var v6: Int32 = 0
    v6 = 5
    var v7: Bool = false
    v7 = sp_utf8_canonical_equal_bounded_loop_0(v0, v0, v1, v2, v3, v4, v5, v6)
    var v8: String = ""
    v8 = ""
    var v9: Int32 = 0
    v9 = 0
    var v10: Int32 = 0
    v10 = 0
    var v11: Int32 = 0
    v11 = -1
    var v12: Int32 = 0
    v12 = -1
    var v13: Int32 = 0
    v13 = 0
    var v14: Int32 = 0
    v14 = 0
    var v15: Bool = false
    v15 = sp_utf8_canonical_equal_bounded_loop_0(v8, v8, v9, v10, v11, v12, v13, v14)
    var v16: String = ""
    v16 = "éõç"
    var v17: String = ""
    v17 = "éõç"
    var v18: Int32 = 0
    v18 = 0
    var v19: Int32 = 0
    v19 = 0
    var v20: Int32 = 0
    v20 = -1
    var v21: Int32 = 0
    v21 = -1
    var v22: Int32 = 0
    v22 = 6
    var v23: Int32 = 0
    v23 = 9
    var v24: Bool = false
    v24 = sp_utf8_canonical_equal_bounded_loop_0(v16, v17, v18, v19, v20, v21, v22, v23)
    var v25: String = ""
    v25 = "é̃"
    var v26: String = ""
    v26 = "é̃"
    var v27: Int32 = 0
    v27 = 0
    var v28: Int32 = 0
    v28 = 0
    var v29: Int32 = 0
    v29 = -1
    var v30: Int32 = 0
    v30 = -1
    var v31: Int32 = 0
    v31 = 4
    var v32: Int32 = 0
    v32 = 5
    var v33: Bool = false
    v33 = sp_utf8_canonical_equal_bounded_loop_0(v25, v26, v27, v28, v29, v30, v31, v32)
    var v34: String = ""
    v34 = "À"
    var v35: String = ""
    v35 = "À"
    var v36: Int32 = 0
    v36 = 0
    var v37: Int32 = 0
    v37 = 0
    var v38: Int32 = 0
    v38 = -1
    var v39: Int32 = 0
    v39 = -1
    var v40: Int32 = 0
    v40 = 2
    var v41: Int32 = 0
    v41 = 3
    var v42: Bool = false
    v42 = sp_utf8_canonical_equal_bounded_loop_0(v34, v35, v36, v37, v38, v39, v40, v41)
    var v43: String = ""
    v43 = "Ω"
    var v44: Int32 = 0
    v44 = 0
    var v45: Int32 = 0
    v45 = 0
    var v46: Int32 = 0
    v46 = -1
    var v47: Int32 = 0
    v47 = -1
    var v48: Int32 = 0
    v48 = 2
    var v49: Int32 = 0
    v49 = 2
    var v50: Bool = false
    v50 = sp_utf8_canonical_equal_bounded_loop_0(v43, v43, v44, v45, v46, v47, v48, v49)
    var v51: String = ""
    v51 = "ẽ́"
    var v52: Int32 = 0
    v52 = 0
    var v53: Int32 = 0
    v53 = 0
    var v54: Int32 = 0
    v54 = -1
    var v55: Int32 = 0
    v55 = -1
    var v56: Int32 = 0
    v56 = 5
    var v57: Int32 = 0
    v57 = 5
    var v58: Bool = false
    v58 = sp_utf8_canonical_equal_bounded_loop_0(v26, v51, v52, v53, v54, v55, v56, v57)
    var v59: String = ""
    v59 = "é"
    var v60: String = ""
    v60 = "á"
    var v61: Int32 = 0
    v61 = 0
    var v62: Int32 = 0
    v62 = 0
    var v63: Int32 = 0
    v63 = -1
    var v64: Int32 = 0
    v64 = -1
    var v65: Int32 = 0
    v65 = 2
    var v66: Int32 = 0
    v66 = 2
    var v67: Bool = false
    v67 = sp_utf8_canonical_equal_bounded_loop_0(v59, v60, v61, v62, v63, v64, v65, v66)
    var v68: String = ""
    v68 = "ω"
    var v69: Int32 = 0
    v69 = 0
    var v70: Int32 = 0
    v70 = 0
    var v71: Int32 = 0
    v71 = -1
    var v72: Int32 = 0
    v72 = -1
    var v73: Int32 = 0
    v73 = 2
    var v74: Int32 = 0
    v74 = 2
    var v75: Bool = false
    v75 = sp_utf8_canonical_equal_bounded_loop_0(v43, v68, v69, v70, v71, v72, v73, v74)
    var v76: String = ""
    v76 = "e"
    var v77: Int32 = 0
    v77 = 0
    var v78: Int32 = 0
    v78 = 0
    var v79: Int32 = 0
    v79 = -1
    var v80: Int32 = 0
    v80 = -1
    var v81: Int32 = 0
    v81 = 2
    var v82: Int32 = 0
    v82 = 1
    var v83: Bool = false
    v83 = sp_utf8_canonical_equal_bounded_loop_0(v59, v76, v77, v78, v79, v80, v81, v82)
    if (v7) {
        if (v15) {
            if (v24) {
                if (v33) {
                    if (v42) {
                        if (v50) {
                            if (v58) {
                                return 7
                            } else {
                                if (v67) {
                                    return 8
                                } else {
                                    if (v75) {
                                        return 9
                                    } else {
                                        if (v83) {
                                            return 10
                                        } else {
                                            return 0
                                        }
                                    }
                                }
                            }
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
