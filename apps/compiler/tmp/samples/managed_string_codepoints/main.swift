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
            let t1034_0: String = v0
            let t1072_1: Int32 = v1
            let t1109_2: Int32 = v2
            let t1146_13: Int32 = v13
            let t1185_12: Int32 = v12
            let t1224_5: Int32 = v5
            v0 = t1034_0
            v1 = t1072_1
            v2 = t1109_2
            v3 = t1146_13
            v4 = t1185_12
            v5 = t1224_5
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
                let t896_0: String = v0
                let t937_1: Int32 = v1
                let t977_2: Int32 = v2
                let t1017_3: Int32 = v3
                let t1058_12: Int32 = v12
                let t1101_5: Int32 = v5
                let t1142_6: Int32 = v6
                v0 = t896_0
                v1 = t937_1
                v2 = t977_2
                v3 = t1017_3
                v4 = t1058_12
                v5 = t1101_5
                v6 = t1142_6
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
                    let t1751_0: String = v0
                    let t1797_1: Int32 = v1
                    let t1842_2: Int32 = v2
                    let t1887_3: Int32 = v3
                    let t1932_15: Int32 = v15
                    let t1979_16: Int32 = v16
                    let t2026_6: Int32 = v6
                    v0 = t1751_0
                    v1 = t1797_1
                    v2 = t1842_2
                    v3 = t1887_3
                    v4 = t1932_15
                    v5 = t1979_16
                    v6 = t2026_6
                    continue
                }
            }
        }
    }
    return 0
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "À"
    var v1: Int32 = 0
    v1 = 1
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
    var v17: Int32 = 0
    v17 = 0
    var v18: Int32 = 0
    v18 = 10
    var v19: Int32 = 0
    v19 = sp_codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18)
    var v20: Int32 = 0
    v20 = 1
    var v21: Int32 = 0
    v21 = sp_runtime_byte_0(v0, v20)
    var v22: Int32 = 0
    v22 = 0
    var v23: Int32 = 0
    v23 = sp_runtime_byte_0(v3, v22)
    var v24: Int32 = 0
    v24 = 2
    var v25: Int32 = 0
    v25 = 0
    var v26: Int32 = 0
    v26 = 0
    var v27: Int32 = 0
    v27 = 10
    var v28: Int32 = 0
    v28 = sp_codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27)
    var v29: Int32 = 0
    v29 = (v28 &- 1)
    var v30: String = ""
    v30 = spiralStringSlice("Aéλ🙂Z", v19, v29)
    var v31: Int32 = 0
    v31 = 1
    var v32: Int32 = 0
    v32 = sp_runtime_byte_0(v0, v31)
    var v33: Int32 = 0
    v33 = 0
    var v34: Int32 = 0
    v34 = sp_runtime_byte_0(v3, v33)
    var v35: Int32 = 0
    v35 = 3
    var v36: Int32 = 0
    v36 = 0
    var v37: Int32 = 0
    v37 = 0
    var v38: Int32 = 0
    v38 = 10
    var v39: Int32 = 0
    v39 = sp_codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38)
    var v40: Int32 = 0
    v40 = 1
    var v41: Int32 = 0
    v41 = sp_runtime_byte_0(v0, v40)
    var v42: Int32 = 0
    v42 = 0
    var v43: Int32 = 0
    v43 = sp_runtime_byte_0(v3, v42)
    var v44: Int32 = 0
    v44 = 4
    var v45: Int32 = 0
    v45 = 0
    var v46: Int32 = 0
    v46 = 0
    var v47: Int32 = 0
    v47 = 10
    var v48: Int32 = 0
    v48 = sp_codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47)
    var v49: Int32 = 0
    v49 = (v48 &- 1)
    var v50: String = ""
    v50 = spiralStringSlice("Aéλ🙂Z", v39, v49)
    var v51: Int32 = 0
    v51 = 1
    var v52: Int32 = 0
    v52 = sp_runtime_byte_0(v0, v51)
    var v53: Int32 = 0
    v53 = 0
    var v54: Int32 = 0
    v54 = sp_runtime_byte_0(v3, v53)
    var v55: Int32 = 0
    v55 = 1
    var v56: Int32 = 0
    v56 = 0
    var v57: Int32 = 0
    v57 = 0
    var v58: Int32 = 0
    v58 = 10
    var v59: Int32 = 0
    v59 = sp_codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58)
    var v60: Int32 = 0
    v60 = 1
    var v61: Int32 = 0
    v61 = sp_runtime_byte_0(v0, v60)
    var v62: Int32 = 0
    v62 = 0
    var v63: Int32 = 0
    v63 = sp_runtime_byte_0(v3, v62)
    var v64: Int32 = 0
    v64 = 4
    var v65: Int32 = 0
    v65 = 0
    var v66: Int32 = 0
    v66 = 0
    var v67: Int32 = 0
    v67 = 10
    var v68: Int32 = 0
    v68 = sp_codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67)
    var v69: Int32 = 0
    v69 = (v68 &- 1)
    var v70: String = ""
    v70 = spiralStringSlice("Aéλ🙂Z", v59, v69)
    var v71: Int32 = 0
    v71 = 1
    var v72: Int32 = 0
    v72 = sp_runtime_byte_0(v0, v71)
    var v73: Int32 = 0
    v73 = 0
    var v74: Int32 = 0
    v74 = sp_runtime_byte_0(v3, v73)
    var v75: Int32 = 0
    v75 = 3
    var v76: Int32 = 0
    v76 = 0
    var v77: Int32 = 0
    v77 = 0
    var v78: Int32 = 0
    v78 = 10
    var v79: Int32 = 0
    v79 = sp_codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78)
    var v80: Int32 = 0
    v80 = 0
    var v81: Int32 = 0
    v81 = sp_runtime_byte_0(v30, v80)
    var v82: String = ""
    v82 = "é"
    var v83: Int32 = 0
    v83 = 0
    var v84: Int32 = 0
    v84 = sp_runtime_byte_0(v82, v83)
    var v85: Int32 = 0
    v85 = 3
    var v86: Int32 = 0
    v86 = sp_runtime_byte_0(v50, v85)
    var v87: String = ""
    v87 = "🙂"
    var v88: Int32 = 0
    v88 = 3
    var v89: Int32 = 0
    v89 = sp_runtime_byte_0(v87, v88)
    var v90: Bool = false
    v90 = (v10 == 5)
    if (v90) {
        var v91: Int32 = 0
        v91 = spiralStringLength(v30)
        var v92: Bool = false
        v92 = (v91 == 2)
        if (v92) {
            var v93: Bool = false
            v93 = (v81 == v84)
            if (v93) {
                var v94: Int32 = 0
                v94 = spiralStringLength(v50)
                var v95: Bool = false
                v95 = (v94 == 4)
                if (v95) {
                    var v96: Bool = false
                    v96 = (v86 == v89)
                    if (v96) {
                        var v97: Int32 = 0
                        v97 = spiralStringLength(v70)
                        var v98: Bool = false
                        v98 = (v97 == 8)
                        if (v98) {
                            var v99: Bool = false
                            v99 = (v79 == 5)
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
