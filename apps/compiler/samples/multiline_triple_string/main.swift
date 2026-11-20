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
    let v0: Int32 = 16
    let v1: String = "x\ny"
    let v2: String = "say \"hi\""
    let v3: String = "a \"\"\" b"
    let v4: String = "first\n    second\n\nthird"
    let v5: String = "ab\ncd"
    let v6: String = "a \"b\" c"
    let v7: String = ""
    let v8: String = "a\\nb"
    let v9: String = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
    let v10: String = "\ntop\n\nlevel"
    let v11: Int32 = spiralStringLength(v6)
    let v12: Bool = (v11 != 7)
    if (v12) {
        return 1
    } else {
        let v13: Int32 = spiralStringIndex(v6, 2)
        let v14: Bool = (v13 != 34)
        if (v14) {
            return 2
        } else {
            let v15: Int32 = spiralStringLength(v7)
            let v16: Bool = (v15 != 0)
            if (v16) {
                return 3
            } else {
                let v17: Int32 = spiralStringLength(v8)
                let v18: Bool = (v17 != 4)
                if (v18) {
                    return 4
                } else {
                    let v19: Int32 = spiralStringIndex(v8, 1)
                    let v20: Bool = (v19 != 92)
                    if (v20) {
                        return 5
                    } else {
                        let v21: Int32 = spiralStringLength(v9)
                        let v22: Bool = (v21 != 83)
                        if (v22) {
                            return 6
                        } else {
                            let v23: Int32 = spiralStringIndex(v9, 5)
                            let v24: Bool = (v23 != 10)
                            if (v24) {
                                return 7
                            } else {
                                let v25: Int32 = spiralStringIndex(v9, 37)
                                let v26: Bool = (v25 != 10)
                                if (v26) {
                                    return 8
                                } else {
                                    let v27: Int32 = spiralStringIndex(v9, 38)
                                    let v28: Bool = (v27 != 10)
                                    if (v28) {
                                        return 9
                                    } else {
                                        let v29: Int32 = spiralStringIndex(v9, 39)
                                        let v30: Bool = (v29 != 36)
                                        if (v30) {
                                            return 10
                                        } else {
                                            let v31: Int32 = spiralStringIndex(v9, 57)
                                            let v32: Bool = (v31 != 105)
                                            if (v32) {
                                                return 11
                                            } else {
                                                let v33: Int32 = spiralStringIndex(v9, 82)
                                                let v34: Bool = (v33 != 100)
                                                if (v34) {
                                                    return 12
                                                } else {
                                                    let v35: Int32 = spiralStringLength(v10)
                                                    let v36: Bool = (v35 != 11)
                                                    if (v36) {
                                                        return 13
                                                    } else {
                                                        let v37: Int32 = spiralStringIndex(v10, 0)
                                                        let v38: Bool = (v37 != 10)
                                                        if (v38) {
                                                            return 14
                                                        } else {
                                                            let v39: Int32 = spiralStringIndex(v10, 5)
                                                            let v40: Bool = (v39 != 10)
                                                            if (v40) {
                                                                return 15
                                                            } else {
                                                                let v41: Bool = (v0 != 16)
                                                                if (v41) {
                                                                    return 16
                                                                } else {
                                                                    let v42: Int32 = spiralStringLength(v1)
                                                                    let v43: Bool = (v42 != 3)
                                                                    if (v43) {
                                                                        return 17
                                                                    } else {
                                                                        let v44: Int32 = spiralStringLength(v2)
                                                                        let v45: Bool = (v44 != 8)
                                                                        if (v45) {
                                                                            return 18
                                                                        } else {
                                                                            let v46: Int32 = spiralStringIndex(v2, 7)
                                                                            let v47: Bool = (v46 != 34)
                                                                            if (v47) {
                                                                                return 19
                                                                            } else {
                                                                                let v48: Int32 = spiralStringLength(v3)
                                                                                let v49: Bool = (v48 != 7)
                                                                                if (v49) {
                                                                                    return 20
                                                                                } else {
                                                                                    let v50: Int32 = spiralStringIndex(v3, 4)
                                                                                    let v51: Bool = (v50 != 34)
                                                                                    if (v51) {
                                                                                        return 21
                                                                                    } else {
                                                                                        let v52: Int32 = spiralStringLength(v4)
                                                                                        let v53: Bool = (v52 != 23)
                                                                                        if (v53) {
                                                                                            return 22
                                                                                        } else {
                                                                                            let v54: Int32 = spiralStringIndex(v4, 6)
                                                                                            let v55: Bool = (v54 != 32)
                                                                                            if (v55) {
                                                                                                return 23
                                                                                            } else {
                                                                                                let v56: Int32 = spiralStringIndex(v4, 10)
                                                                                                let v57: Bool = (v56 != 115)
                                                                                                if (v57) {
                                                                                                    return 24
                                                                                                } else {
                                                                                                    let v58: Int32 = spiralStringIndex(v4, 17)
                                                                                                    let v59: Bool = (v58 != 10)
                                                                                                    if (v59) {
                                                                                                        return 25
                                                                                                    } else {
                                                                                                        let v60: Int32 = spiralStringIndex(v4, 22)
                                                                                                        let v61: Bool = (v60 != 100)
                                                                                                        if (v61) {
                                                                                                            return 26
                                                                                                        } else {
                                                                                                            let v62: Int32 = spiralStringLength(v5)
                                                                                                            let v63: Bool = (v62 != 5)
                                                                                                            if (v63) {
                                                                                                                return 27
                                                                                                            } else {
                                                                                                                let v64: Int32 = spiralStringIndex(v5, 3)
                                                                                                                let v65: Bool = (v64 != 99)
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
