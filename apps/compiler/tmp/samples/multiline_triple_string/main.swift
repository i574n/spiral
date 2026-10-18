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
    v12 = (v11 == 7)
    var v13: Bool = false
    v13 = (v12 != true)
    if (v13) {
        return 1
    } else {
        var v14: Int32 = 0
        v14 = spiralStringIndex(v6, 2)
        var v15: Bool = false
        v15 = (v14 == 34)
        var v16: Bool = false
        v16 = (v15 != true)
        if (v16) {
            return 2
        } else {
            var v17: Int32 = 0
            v17 = spiralStringLength(v7)
            var v18: Bool = false
            v18 = (v17 == 0)
            var v19: Bool = false
            v19 = (v18 != true)
            if (v19) {
                return 3
            } else {
                var v20: Int32 = 0
                v20 = spiralStringLength(v8)
                var v21: Bool = false
                v21 = (v20 == 4)
                var v22: Bool = false
                v22 = (v21 != true)
                if (v22) {
                    return 4
                } else {
                    var v23: Int32 = 0
                    v23 = spiralStringIndex(v8, 1)
                    var v24: Bool = false
                    v24 = (v23 == 92)
                    var v25: Bool = false
                    v25 = (v24 != true)
                    if (v25) {
                        return 5
                    } else {
                        var v26: Int32 = 0
                        v26 = spiralStringLength(v9)
                        var v27: Bool = false
                        v27 = (v26 == 83)
                        var v28: Bool = false
                        v28 = (v27 != true)
                        if (v28) {
                            return 6
                        } else {
                            var v29: Int32 = 0
                            v29 = spiralStringIndex(v9, 5)
                            var v30: Bool = false
                            v30 = (v29 == 10)
                            var v31: Bool = false
                            v31 = (v30 != true)
                            if (v31) {
                                return 7
                            } else {
                                var v32: Int32 = 0
                                v32 = spiralStringIndex(v9, 37)
                                var v33: Bool = false
                                v33 = (v32 == 10)
                                var v34: Bool = false
                                v34 = (v33 != true)
                                if (v34) {
                                    return 8
                                } else {
                                    var v35: Int32 = 0
                                    v35 = spiralStringIndex(v9, 38)
                                    var v36: Bool = false
                                    v36 = (v35 == 10)
                                    var v37: Bool = false
                                    v37 = (v36 != true)
                                    if (v37) {
                                        return 9
                                    } else {
                                        var v38: Int32 = 0
                                        v38 = spiralStringIndex(v9, 39)
                                        var v39: Bool = false
                                        v39 = (v38 == 36)
                                        var v40: Bool = false
                                        v40 = (v39 != true)
                                        if (v40) {
                                            return 10
                                        } else {
                                            var v41: Int32 = 0
                                            v41 = spiralStringIndex(v9, 57)
                                            var v42: Bool = false
                                            v42 = (v41 == 105)
                                            var v43: Bool = false
                                            v43 = (v42 != true)
                                            if (v43) {
                                                return 11
                                            } else {
                                                var v44: Int32 = 0
                                                v44 = spiralStringIndex(v9, 82)
                                                var v45: Bool = false
                                                v45 = (v44 == 100)
                                                var v46: Bool = false
                                                v46 = (v45 != true)
                                                if (v46) {
                                                    return 12
                                                } else {
                                                    var v47: Int32 = 0
                                                    v47 = spiralStringLength(v10)
                                                    var v48: Bool = false
                                                    v48 = (v47 == 11)
                                                    var v49: Bool = false
                                                    v49 = (v48 != true)
                                                    if (v49) {
                                                        return 13
                                                    } else {
                                                        var v50: Int32 = 0
                                                        v50 = spiralStringIndex(v10, 0)
                                                        var v51: Bool = false
                                                        v51 = (v50 == 10)
                                                        var v52: Bool = false
                                                        v52 = (v51 != true)
                                                        if (v52) {
                                                            return 14
                                                        } else {
                                                            var v53: Int32 = 0
                                                            v53 = spiralStringIndex(v10, 5)
                                                            var v54: Bool = false
                                                            v54 = (v53 == 10)
                                                            var v55: Bool = false
                                                            v55 = (v54 != true)
                                                            if (v55) {
                                                                return 15
                                                            } else {
                                                                var v56: Bool = false
                                                                v56 = (v0 == 16)
                                                                var v57: Bool = false
                                                                v57 = (v56 != true)
                                                                if (v57) {
                                                                    return 16
                                                                } else {
                                                                    var v58: Int32 = 0
                                                                    v58 = spiralStringLength(v1)
                                                                    var v59: Bool = false
                                                                    v59 = (v58 == 3)
                                                                    var v60: Bool = false
                                                                    v60 = (v59 != true)
                                                                    if (v60) {
                                                                        return 17
                                                                    } else {
                                                                        var v61: Int32 = 0
                                                                        v61 = spiralStringLength(v2)
                                                                        var v62: Bool = false
                                                                        v62 = (v61 == 8)
                                                                        var v63: Bool = false
                                                                        v63 = (v62 != true)
                                                                        if (v63) {
                                                                            return 18
                                                                        } else {
                                                                            var v64: Int32 = 0
                                                                            v64 = spiralStringIndex(v2, 7)
                                                                            var v65: Bool = false
                                                                            v65 = (v64 == 34)
                                                                            var v66: Bool = false
                                                                            v66 = (v65 != true)
                                                                            if (v66) {
                                                                                return 19
                                                                            } else {
                                                                                var v67: Int32 = 0
                                                                                v67 = spiralStringLength(v3)
                                                                                var v68: Bool = false
                                                                                v68 = (v67 == 7)
                                                                                var v69: Bool = false
                                                                                v69 = (v68 != true)
                                                                                if (v69) {
                                                                                    return 20
                                                                                } else {
                                                                                    var v70: Int32 = 0
                                                                                    v70 = spiralStringIndex(v3, 4)
                                                                                    var v71: Bool = false
                                                                                    v71 = (v70 == 34)
                                                                                    var v72: Bool = false
                                                                                    v72 = (v71 != true)
                                                                                    if (v72) {
                                                                                        return 21
                                                                                    } else {
                                                                                        var v73: Int32 = 0
                                                                                        v73 = spiralStringLength(v4)
                                                                                        var v74: Bool = false
                                                                                        v74 = (v73 == 23)
                                                                                        var v75: Bool = false
                                                                                        v75 = (v74 != true)
                                                                                        if (v75) {
                                                                                            return 22
                                                                                        } else {
                                                                                            var v76: Int32 = 0
                                                                                            v76 = spiralStringIndex(v4, 6)
                                                                                            var v77: Bool = false
                                                                                            v77 = (v76 == 32)
                                                                                            var v78: Bool = false
                                                                                            v78 = (v77 != true)
                                                                                            if (v78) {
                                                                                                return 23
                                                                                            } else {
                                                                                                var v79: Int32 = 0
                                                                                                v79 = spiralStringIndex(v4, 10)
                                                                                                var v80: Bool = false
                                                                                                v80 = (v79 == 115)
                                                                                                var v81: Bool = false
                                                                                                v81 = (v80 != true)
                                                                                                if (v81) {
                                                                                                    return 24
                                                                                                } else {
                                                                                                    var v82: Int32 = 0
                                                                                                    v82 = spiralStringIndex(v4, 17)
                                                                                                    var v83: Bool = false
                                                                                                    v83 = (v82 == 10)
                                                                                                    var v84: Bool = false
                                                                                                    v84 = (v83 != true)
                                                                                                    if (v84) {
                                                                                                        return 25
                                                                                                    } else {
                                                                                                        var v85: Int32 = 0
                                                                                                        v85 = spiralStringIndex(v4, 22)
                                                                                                        var v86: Bool = false
                                                                                                        v86 = (v85 == 100)
                                                                                                        var v87: Bool = false
                                                                                                        v87 = (v86 != true)
                                                                                                        if (v87) {
                                                                                                            return 26
                                                                                                        } else {
                                                                                                            var v88: Int32 = 0
                                                                                                            v88 = spiralStringLength(v5)
                                                                                                            var v89: Bool = false
                                                                                                            v89 = (v88 == 5)
                                                                                                            var v90: Bool = false
                                                                                                            v90 = (v89 != true)
                                                                                                            if (v90) {
                                                                                                                return 27
                                                                                                            } else {
                                                                                                                var v91: Int32 = 0
                                                                                                                v91 = spiralStringIndex(v5, 3)
                                                                                                                var v92: Bool = false
                                                                                                                v92 = (v91 == 99)
                                                                                                                var v93: Bool = false
                                                                                                                v93 = (v92 != true)
                                                                                                                if (v93) {
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
