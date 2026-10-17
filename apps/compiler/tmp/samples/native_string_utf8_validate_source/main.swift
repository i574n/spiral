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
func sp_utf8_validate_loop_0(_ p0: String, _ p1: Int32, _ p2: Int32, _ p3: Int32) -> Int32 {
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
                v7 = sp_utf8_scalar_at_byte_offset_1(v0, v1)
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
                var v14: Int32 = 0
                v14 = (v1 &+ v13)
                var v15: Int32 = 0
                v15 = (v2 &+ 1)
                let t1501_0: String = v0
                let t1543_14: Int32 = v14
                let t1586_15: Int32 = v15
                let t1629_3: Int32 = v3
                v0 = t1501_0
                v1 = t1543_14
                v2 = t1586_15
                v3 = t1629_3
                continue
            }
        }
    }
    return 0
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "Aéλ🙂Z"
    var v1: Int32 = 0
    v1 = 0
    var v2: Int32 = 0
    v2 = 0
    var v3: Int32 = 0
    v3 = 10
    var v4: Int32 = 0
    v4 = sp_utf8_validate_loop_0(v0, v1, v2, v3)
    var v5: String = ""
    v5 = ""
    var v6: Int32 = 0
    v6 = 0
    var v7: Int32 = 0
    v7 = 0
    var v8: Int32 = 0
    v8 = 0
    var v9: Int32 = 0
    v9 = sp_utf8_validate_loop_0(v5, v6, v7, v8)
    var v10: Bool = false
    v10 = (v4 == 5)
    if (v10) {
        var v11: Bool = false
        v11 = (v9 == 0)
        if (v11) {
            return 0
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
