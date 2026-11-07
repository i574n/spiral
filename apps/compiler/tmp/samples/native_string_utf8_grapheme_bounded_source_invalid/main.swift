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
                            let v30: Bool = (v29 >= v2)
                            if (v30) {
                                "UTF-8 sequence is truncated.".withCString { ptr in _ = fputs(ptr, stderr) }
                                fputs("\n", stderr)
                                exit(1)
                            } else {
                                let v32: Int32 = (v1 &+ 1)
                                var v33: Int32 = 0
                                v33 = sp_runtime_byte_1(v0, v32)
                                let v34: Int32 = (v33 & 255)
                                var v35: Int32 = 0
                                v35 = sp_runtime_byte_1(v0, v29)
                                var v36: Int32 = 0
                                v36 = (v35 & 255)
                                var v37: Bool = false
                                v37 = (v34 < 128)
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
                                        var v44: Int32 = 0
                                        v44 = (v43 &* 4096)
                                        var v45: Int32 = 0
                                        v45 = (v34 &- 128)
                                        let v46: Int32 = (v45 &* 64)
                                        var v47: Int32 = 0
                                        v47 = (v44 &+ v46)
                                        var v48: Int32 = 0
                                        v48 = (v36 &- 128)
                                        var v49: Int32 = 0
                                        v49 = (v47 &+ v48)
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
                                let v64: Int32 = (v1 &+ 3)
                                let v65: Bool = (v64 >= v2)
                                if (v65) {
                                    "UTF-8 sequence is truncated.".withCString { ptr in _ = fputs(ptr, stderr) }
                                    fputs("\n", stderr)
                                    exit(1)
                                } else {
                                    let v67: Int32 = (v1 &+ 1)
                                    let v68: Int32 = sp_runtime_byte_1(v0, v67)
                                    let v69: Int32 = (v68 & 255)
                                    let v70: Int32 = (v1 &+ 2)
                                    let v71: Int32 = sp_runtime_byte_1(v0, v70)
                                    let v72: Int32 = (v71 & 255)
                                    let v73: Int32 = sp_runtime_byte_1(v0, v64)
                                    let v74: Int32 = (v73 & 255)
                                    let v75: Bool = (v69 < 128)
                                    var v77: Bool = false
                                    if (v75) {
                                        v77 = false
                                    } else {
                                        let v76: Bool = (v69 < 192)
                                        v77 = v76
                                    }
                                    if (v77) {
                                        let v78: Bool = (v72 < 128)
                                        var v80: Bool = false
                                        if (v78) {
                                            v80 = false
                                        } else {
                                            let v79: Bool = (v72 < 192)
                                            v80 = v79
                                        }
                                        if (v80) {
                                            let v81: Bool = (v74 < 128)
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
func sp_utf8_grapheme_count_bounded_loop_2(_ p0: String, _ p1: Int32, _ p2: Int32, _ p3: Int32) -> Int32 {
    var v0: String = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    while true {
        var v4: Bool = false
        v4 = (v1 == v3)
        if (v4) {
            return v2
        } else {
            var v5: Bool = false
            v5 = (v1 > v3)
            if (v5) {
                "UTF-8 scalar width exceeds the string.".withCString { ptr in _ = fputs(ptr, stderr) }
                fputs("\n", stderr)
                exit(1)
            } else {
                var v7: Int32 = 0
                v7 = sp_utf8_scalar_at_byte_offset_0(v0, v1)
                var v8: Bool = false
                v8 = (v7 < 128)
                var v13: Int32 = 0
                if (v8) {
                    v13 = 1
                } else {
                    var v9: Bool = false
                    v9 = (v7 < 2048)
                    if (v9) {
                        v13 = 2
                    } else {
                        var v10: Bool = false
                        v10 = (v7 < 65536)
                        if (v10) {
                            v13 = 3
                        } else {
                            v13 = 4
                        }
                    }
                }
                var v14: Bool = false
                v14 = (v7 >= 768)
                var v44: Bool = false
                if (v14) {
                    var v15: Bool = false
                    v15 = (v7 <= 879)
                    if (v15) {
                        v44 = true
                    } else {
                        var v16: Bool = false
                        v16 = (v7 >= 6832)
                        if (v16) {
                            var v17: Bool = false
                            v17 = (v7 <= 6911)
                            if (v17) {
                                v44 = true
                            } else {
                                var v18: Bool = false
                                v18 = (v7 >= 7616)
                                if (v18) {
                                    var v19: Bool = false
                                    v19 = (v7 <= 7679)
                                    if (v19) {
                                        v44 = true
                                    } else {
                                        var v20: Bool = false
                                        v20 = (v7 >= 8400)
                                        if (v20) {
                                            var v21: Bool = false
                                            v21 = (v7 <= 8447)
                                            if (v21) {
                                                v44 = true
                                            } else {
                                                var v22: Bool = false
                                                v22 = (v7 >= 65024)
                                                if (v22) {
                                                    var v23: Bool = false
                                                    v23 = (v7 <= 65039)
                                                    if (v23) {
                                                        v44 = true
                                                    } else {
                                                        var v24: Bool = false
                                                        v24 = (v7 >= 65056)
                                                        if (v24) {
                                                            let v25: Bool = (v7 <= 65071)
                                                            if (v25) {
                                                                v44 = true
                                                            } else {
                                                                let v26: Bool = (v7 >= 127995)
                                                                if (v26) {
                                                                    let v27: Bool = (v7 <= 127999)
                                                                    if (v27) {
                                                                        v44 = true
                                                                    } else {
                                                                        var v28: Bool = false
                                                                        v28 = (v7 >= 917760)
                                                                        if (v28) {
                                                                            var v29: Bool = false
                                                                            v29 = (v7 <= 917999)
                                                                            v44 = v29
                                                                        } else {
                                                                            v44 = false
                                                                        }
                                                                    }
                                                                } else {
                                                                    v44 = false
                                                                }
                                                            }
                                                        } else {
                                                            v44 = false
                                                        }
                                                    }
                                                } else {
                                                    v44 = false
                                                }
                                            }
                                        } else {
                                            v44 = false
                                        }
                                    }
                                } else {
                                    v44 = false
                                }
                            }
                        } else {
                            v44 = false
                        }
                    }
                } else {
                    v44 = false
                }
                var v48: Int32 = 0
                if (v44) {
                    var v45: Bool = false
                    v45 = (v2 == 0)
                    if (v45) {
                        v48 = 1
                    } else {
                        v48 = v2
                    }
                } else {
                    var v47: Int32 = 0
                    v47 = (v2 &+ 1)
                    v48 = v47
                }
                var v49: Int32 = 0
                v49 = (v1 &+ v13)
                v1 = v49
                v2 = v48
                continue
            }
        }
    }
    return 0
}
func spiral_main() -> Int32 {
    let v0: String = "éZ"
    var v1: Int32 = 0
    v1 = 1
    var v2: Int32 = 0
    v2 = sp_utf8_scalar_at_byte_offset_0(v0, v1)
    var v3: Bool = false
    v3 = (v2 >= 768)
    var v33: Bool = false
    if (v3) {
        var v4: Bool = false
        v4 = (v2 <= 879)
        if (v4) {
            v33 = true
        } else {
            var v5: Bool = false
            v5 = (v2 >= 6832)
            if (v5) {
                let v6: Bool = (v2 <= 6911)
                if (v6) {
                    v33 = true
                } else {
                    var v7: Bool = false
                    v7 = (v2 >= 7616)
                    if (v7) {
                        var v8: Bool = false
                        v8 = (v2 <= 7679)
                        if (v8) {
                            v33 = true
                        } else {
                            var v9: Bool = false
                            v9 = (v2 >= 8400)
                            if (v9) {
                                var v10: Bool = false
                                v10 = (v2 <= 8447)
                                if (v10) {
                                    v33 = true
                                } else {
                                    let v11: Bool = (v2 >= 65024)
                                    if (v11) {
                                        var v12: Bool = false
                                        v12 = (v2 <= 65039)
                                        if (v12) {
                                            v33 = true
                                        } else {
                                            var v13: Bool = false
                                            v13 = (v2 >= 65056)
                                            if (v13) {
                                                var v14: Bool = false
                                                v14 = (v2 <= 65071)
                                                if (v14) {
                                                    v33 = true
                                                } else {
                                                    var v15: Bool = false
                                                    v15 = (v2 >= 127995)
                                                    if (v15) {
                                                        var v16: Bool = false
                                                        v16 = (v2 <= 127999)
                                                        if (v16) {
                                                            v33 = true
                                                        } else {
                                                            var v17: Bool = false
                                                            v17 = (v2 >= 917760)
                                                            if (v17) {
                                                                var v18: Bool = false
                                                                v18 = (v2 <= 917999)
                                                                v33 = v18
                                                            } else {
                                                                v33 = false
                                                            }
                                                        }
                                                    } else {
                                                        v33 = false
                                                    }
                                                }
                                            } else {
                                                v33 = false
                                            }
                                        }
                                    } else {
                                        v33 = false
                                    }
                                }
                            } else {
                                v33 = false
                            }
                        }
                    } else {
                        v33 = false
                    }
                }
            } else {
                v33 = false
            }
        }
    } else {
        v33 = false
    }
    if (v33) {
        "UTF-8 grapheme byte offset is inside a bounded grapheme cluster.".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    } else {
        var v35: Int32 = 0
        v35 = 1
        var v36: Int32 = 0
        v36 = 0
        var v37: Int32 = 0
        v37 = 4
        return sp_utf8_grapheme_count_bounded_loop_2(v0, v35, v36, v37)
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
