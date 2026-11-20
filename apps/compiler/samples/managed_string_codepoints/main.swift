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
func sp_runtime_byte_0(_ p0: String, _ p1: Int32) -> Int32 {
    var v0: String = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    v2 = spiralStringIndex(v0, v1)
    return v2
}
func sp_codepoint_length_loop_1(_ p0: String, _ p1: Int32, _ p2: Int32, _ p3: Int32, _ p4: Int32, _ p5: Int32) -> Int32 {
    var v0: String = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    var v4: Int32 = p4
    var v5: Int32 = p5
    while true {
        var v6: Bool = false
        v6 = (v3 == v5)
        if (v6) {
            return v4
        } else {
            var v7: Int32 = 0
            v7 = spiralStringIndex(v0, v3)
            var v8: Bool = false
            v8 = (v7 < v1)
            var v10: Bool = false
            if (v8) {
                v10 = false
            } else {
                var v9: Bool = false
                v9 = (v7 < v2)
                v10 = v9
            }
            var v12: Int32 = 0
            if (v10) {
                v12 = v4
            } else {
                var v11: Int32 = 0
                v11 = (v4 &+ 1)
                v12 = v11
            }
            var v13: Int32 = 0
            v13 = (v3 &+ 1)
            v3 = v13
            v4 = v12
            continue
        }
    }
    return 0
}
func sp_codepoint_byte_offset_loop_2(_ p0: String, _ p1: Int32, _ p2: Int32, _ p3: Int32, _ p4: Int32, _ p5: Int32, _ p6: Int32) -> Int32 {
    var v0: String = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    var v4: Int32 = p4
    var v5: Int32 = p5
    var v6: Int32 = p6
    while true {
        var v7: Bool = false
        v7 = (v4 == v6)
        if (v7) {
            return v6
        } else {
            var v8: Int32 = 0
            v8 = spiralStringIndex(v0, v4)
            var v9: Bool = false
            v9 = (v8 < v1)
            var v11: Bool = false
            if (v9) {
                v11 = false
            } else {
                var v10: Bool = false
                v10 = (v8 < v2)
                v11 = v10
            }
            if (v11) {
                var v12: Int32 = 0
                v12 = (v4 &+ 1)
                v4 = v12
                continue
            } else {
                var v14: Bool = false
                v14 = (v5 == v3)
                if (v14) {
                    return v4
                } else {
                    var v15: Int32 = 0
                    v15 = (v4 &+ 1)
                    var v16: Int32 = 0
                    v16 = (v5 &+ 1)
                    v4 = v15
                    v5 = v16
                    continue
                }
            }
        }
    }
    return 0
}
func spiral_main() -> Int32 {
    let v0: String = "À"
    let v1: Int32 = 1
    var v2: Int32 = 0
    v2 = sp_runtime_byte_0(v0, v1)
    var v3: String = ""
    v3 = "©"
    var v4: Int32 = 0
    v4 = 0
    var v5: Int32 = 0
    v5 = sp_runtime_byte_0(v3, v4)
    var v6: String = ""
    v6 = "Aéλ🙂Z"
    var v7: Int32 = 0
    v7 = 0
    var v8: Int32 = 0
    v8 = 0
    var v9: Int32 = 0
    v9 = 10
    var v10: Int32 = 0
    v10 = sp_codepoint_length_loop_1(v6, v2, v5, v7, v8, v9)
    var v11: Int32 = 0
    v11 = 1
    var v12: Int32 = 0
    v12 = sp_runtime_byte_0(v0, v11)
    var v13: Int32 = 0
    v13 = 0
    var v14: Int32 = 0
    v14 = sp_runtime_byte_0(v3, v13)
    var v15: Int32 = 0
    v15 = 1
    var v16: Int32 = 0
    v16 = 0
    let v17: Int32 = 0
    let v18: Int32 = 10
    let v19: Int32 = sp_codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18)
    let v20: Int32 = 1
    let v21: Int32 = sp_runtime_byte_0(v0, v20)
    let v22: Int32 = 0
    let v23: Int32 = sp_runtime_byte_0(v3, v22)
    let v24: Int32 = 2
    let v25: Int32 = 0
    let v26: Int32 = 0
    let v27: Int32 = 10
    let v28: Int32 = sp_codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27)
    let v29: Int32 = (v28 &- 1)
    let v30: String = spiralStringSlice("Aéλ🙂Z", v19, v29)
    let v31: Int32 = 1
    let v32: Int32 = sp_runtime_byte_0(v0, v31)
    let v33: Int32 = 0
    let v34: Int32 = sp_runtime_byte_0(v3, v33)
    let v35: Int32 = 3
    let v36: Int32 = 0
    let v37: Int32 = 0
    let v38: Int32 = 10
    let v39: Int32 = sp_codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38)
    let v40: Int32 = 1
    let v41: Int32 = sp_runtime_byte_0(v0, v40)
    let v42: Int32 = 0
    let v43: Int32 = sp_runtime_byte_0(v3, v42)
    let v44: Int32 = 4
    let v45: Int32 = 0
    let v46: Int32 = 0
    let v47: Int32 = 10
    let v48: Int32 = sp_codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47)
    let v49: Int32 = (v48 &- 1)
    let v50: String = spiralStringSlice("Aéλ🙂Z", v39, v49)
    let v51: Int32 = 1
    let v52: Int32 = sp_runtime_byte_0(v0, v51)
    let v53: Int32 = 0
    let v54: Int32 = sp_runtime_byte_0(v3, v53)
    let v55: Int32 = 1
    let v56: Int32 = 0
    let v57: Int32 = 0
    let v58: Int32 = 10
    let v59: Int32 = sp_codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58)
    let v60: Int32 = 1
    let v61: Int32 = sp_runtime_byte_0(v0, v60)
    let v62: Int32 = 0
    let v63: Int32 = sp_runtime_byte_0(v3, v62)
    let v64: Int32 = 4
    let v65: Int32 = 0
    let v66: Int32 = 0
    let v67: Int32 = 10
    let v68: Int32 = sp_codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67)
    let v69: Int32 = (v68 &- 1)
    let v70: String = spiralStringSlice("Aéλ🙂Z", v59, v69)
    let v71: Int32 = 1
    let v72: Int32 = sp_runtime_byte_0(v0, v71)
    let v73: Int32 = 0
    let v74: Int32 = sp_runtime_byte_0(v3, v73)
    let v75: Int32 = 3
    let v76: Int32 = 0
    let v77: Int32 = 0
    let v78: Int32 = 10
    let v79: Int32 = sp_codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78)
    let v80: Int32 = 0
    let v81: Int32 = sp_runtime_byte_0(v30, v80)
    let v82: String = "é"
    let v83: Int32 = 0
    let v84: Int32 = sp_runtime_byte_0(v82, v83)
    let v85: Int32 = 3
    let v86: Int32 = sp_runtime_byte_0(v50, v85)
    let v87: String = "🙂"
    let v88: Int32 = 3
    let v89: Int32 = sp_runtime_byte_0(v87, v88)
    let v90: Bool = (v10 == 5)
    if (v90) {
        let v91: Int32 = spiralStringLength(v30)
        let v92: Bool = (v91 == 2)
        if (v92) {
            let v93: Bool = (v81 == v84)
            if (v93) {
                let v94: Int32 = spiralStringLength(v50)
                let v95: Bool = (v94 == 4)
                if (v95) {
                    let v96: Bool = (v86 == v89)
                    if (v96) {
                        let v97: Int32 = spiralStringLength(v70)
                        let v98: Bool = (v97 == 8)
                        if (v98) {
                            let v99: Bool = (v79 == 5)
                            if (v99) {
                                return 0
                            } else {
                                return 1
                            }
                        } else {
                            return 2
                        }
                    } else {
                        return 3
                    }
                } else {
                    return 4
                }
            } else {
                return 5
            }
        } else {
            return 6
        }
    } else {
        return 7
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
