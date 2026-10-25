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
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 16
    var v1: String = ""
    v1 = "x\ny"
    var v2: String = ""
    v2 = "say \"hi\""
    var v3: String = ""
    v3 = "a \"\"\" b"
    var v4: String = ""
    v4 = "first\n    second\n\nthird"
    var v5: String = ""
    v5 = "ab\ncd"
    var v6: String = ""
    v6 = "a \"b\" c"
    var v7: String = ""
    v7 = ""
    var v8: String = ""
    v8 = "a\\nb"
    var v9: String = ""
    v9 = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
    var v10: String = ""
    v10 = "\ntop\n\nlevel"
    var v11: Int32 = 0
    v11 = spiralStringLength(v6)
    var v12: Bool = false
    v12 = (v11 != 7)
    if (v12) {
        return 1
    } else {
        var v13: Int32 = 0
        v13 = spiralStringIndex(v6, 2)
        var v14: Bool = false
        v14 = (v13 != 34)
        if (v14) {
            return 2
        } else {
            var v15: Int32 = 0
            v15 = spiralStringLength(v7)
            var v16: Bool = false
            v16 = (v15 != 0)
            if (v16) {
                return 3
            } else {
                var v17: Int32 = 0
                v17 = spiralStringLength(v8)
                var v18: Bool = false
                v18 = (v17 != 4)
                if (v18) {
                    return 4
                } else {
                    var v19: Int32 = 0
                    v19 = spiralStringIndex(v8, 1)
                    var v20: Bool = false
                    v20 = (v19 != 92)
                    if (v20) {
                        return 5
                    } else {
                        var v21: Int32 = 0
                        v21 = spiralStringLength(v9)
                        var v22: Bool = false
                        v22 = (v21 != 83)
                        if (v22) {
                            return 6
                        } else {
                            var v23: Int32 = 0
                            v23 = spiralStringIndex(v9, 5)
                            var v24: Bool = false
                            v24 = (v23 != 10)
                            if (v24) {
                                return 7
                            } else {
                                var v25: Int32 = 0
                                v25 = spiralStringIndex(v9, 37)
                                var v26: Bool = false
                                v26 = (v25 != 10)
                                if (v26) {
                                    return 8
                                } else {
                                    var v27: Int32 = 0
                                    v27 = spiralStringIndex(v9, 38)
                                    var v28: Bool = false
                                    v28 = (v27 != 10)
                                    if (v28) {
                                        return 9
                                    } else {
                                        var v29: Int32 = 0
                                        v29 = spiralStringIndex(v9, 39)
                                        var v30: Bool = false
                                        v30 = (v29 != 36)
                                        if (v30) {
                                            return 10
                                        } else {
                                            var v31: Int32 = 0
                                            v31 = spiralStringIndex(v9, 57)
                                            var v32: Bool = false
                                            v32 = (v31 != 105)
                                            if (v32) {
                                                return 11
                                            } else {
                                                var v33: Int32 = 0
                                                v33 = spiralStringIndex(v9, 82)
                                                var v34: Bool = false
                                                v34 = (v33 != 100)
                                                if (v34) {
                                                    return 12
                                                } else {
                                                    var v35: Int32 = 0
                                                    v35 = spiralStringLength(v10)
                                                    var v36: Bool = false
                                                    v36 = (v35 != 11)
                                                    if (v36) {
                                                        return 13
                                                    } else {
                                                        var v37: Int32 = 0
                                                        v37 = spiralStringIndex(v10, 0)
                                                        var v38: Bool = false
                                                        v38 = (v37 != 10)
                                                        if (v38) {
                                                            return 14
                                                        } else {
                                                            var v39: Int32 = 0
                                                            v39 = spiralStringIndex(v10, 5)
                                                            var v40: Bool = false
                                                            v40 = (v39 != 10)
                                                            if (v40) {
                                                                return 15
                                                            } else {
                                                                var v41: Bool = false
                                                                v41 = (v0 != 16)
                                                                if (v41) {
                                                                    return 16
                                                                } else {
                                                                    var v42: Int32 = 0
                                                                    v42 = spiralStringLength(v1)
                                                                    var v43: Bool = false
                                                                    v43 = (v42 != 3)
                                                                    if (v43) {
                                                                        return 17
                                                                    } else {
                                                                        var v44: Int32 = 0
                                                                        v44 = spiralStringLength(v2)
                                                                        var v45: Bool = false
                                                                        v45 = (v44 != 8)
                                                                        if (v45) {
                                                                            return 18
                                                                        } else {
                                                                            var v46: Int32 = 0
                                                                            v46 = spiralStringIndex(v2, 7)
                                                                            var v47: Bool = false
                                                                            v47 = (v46 != 34)
                                                                            if (v47) {
                                                                                return 19
                                                                            } else {
                                                                                var v48: Int32 = 0
                                                                                v48 = spiralStringLength(v3)
                                                                                var v49: Bool = false
                                                                                v49 = (v48 != 7)
                                                                                if (v49) {
                                                                                    return 20
                                                                                } else {
                                                                                    var v50: Int32 = 0
                                                                                    v50 = spiralStringIndex(v3, 4)
                                                                                    var v51: Bool = false
                                                                                    v51 = (v50 != 34)
                                                                                    if (v51) {
                                                                                        return 21
                                                                                    } else {
                                                                                        var v52: Int32 = 0
                                                                                        v52 = spiralStringLength(v4)
                                                                                        var v53: Bool = false
                                                                                        v53 = (v52 != 23)
                                                                                        if (v53) {
                                                                                            return 22
                                                                                        } else {
                                                                                            var v54: Int32 = 0
                                                                                            v54 = spiralStringIndex(v4, 6)
                                                                                            var v55: Bool = false
                                                                                            v55 = (v54 != 32)
                                                                                            if (v55) {
                                                                                                return 23
                                                                                            } else {
                                                                                                var v56: Int32 = 0
                                                                                                v56 = spiralStringIndex(v4, 10)
                                                                                                var v57: Bool = false
                                                                                                v57 = (v56 != 115)
                                                                                                if (v57) {
                                                                                                    return 24
                                                                                                } else {
                                                                                                    var v58: Int32 = 0
                                                                                                    v58 = spiralStringIndex(v4, 17)
                                                                                                    var v59: Bool = false
                                                                                                    v59 = (v58 != 10)
                                                                                                    if (v59) {
                                                                                                        return 25
                                                                                                    } else {
                                                                                                        var v60: Int32 = 0
                                                                                                        v60 = spiralStringIndex(v4, 22)
                                                                                                        var v61: Bool = false
                                                                                                        v61 = (v60 != 100)
                                                                                                        if (v61) {
                                                                                                            return 26
                                                                                                        } else {
                                                                                                            var v62: Int32 = 0
                                                                                                            v62 = spiralStringLength(v5)
                                                                                                            var v63: Bool = false
                                                                                                            v63 = (v62 != 5)
                                                                                                            if (v63) {
                                                                                                                return 27
                                                                                                            } else {
                                                                                                                var v64: Int32 = 0
                                                                                                                v64 = spiralStringIndex(v5, 3)
                                                                                                                var v65: Bool = false
                                                                                                                v65 = (v64 != 99)
                                                                                                                if (v65) {
                                                                                                                    return 28
                                                                                                                } else {
                                                                                                                    return 0
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
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
