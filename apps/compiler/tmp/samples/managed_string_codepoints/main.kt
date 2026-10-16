fun spiralUtf8(value: String): ByteArray = value.toByteArray(Charsets.UTF_8)
fun spiralStringLength(value: String): Int = spiralUtf8(value).size
fun spiralStringIndex(value: String, index: Int): Int {
    val bytes = spiralUtf8(value)
    if (!(index >= 0 && index < bytes.size)) {
        System.err.println("string index out of bounds")
        System.exit(1)
        throw RuntimeException()
    }
    return bytes[index].toInt()
}
fun spiralStringSlice(value: String, from: Int, to: Int): String {
    val bytes = spiralUtf8(value)
    val length = bytes.size
    if (from < 0 || from > length || to < from - 1 || to >= length) {
        System.err.println("string slice out of bounds")
        System.exit(3)
        throw RuntimeException()
    }
    if (to < from) return ""
    val start = bytes[from].toInt()
    val follows = to + 1 < length && ((bytes[to + 1].toInt() and 192) == 128)
    if ((start and 192) == 128 || follows) {
        System.err.println("string slice splits a code point")
        System.exit(3)
        throw RuntimeException()
    }
    return bytes.copyOfRange(from, to + 1).toString(Charsets.UTF_8)
}
fun sp_runtime_byte_0(p0: String, p1: Int): Int {
    var v0: String = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = spiralStringIndex(v0, v1)
    return v2
}
fun sp_codepoint_length_loop_1(p0: String, p1: Int, p2: Int, p3: Int, p4: Int, p5: Int): Int {
    var v0: String = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = p3
    var v4: Int = p4
    var v5: Int = p5
    while (true) {
        var v6: Boolean = false
        v6 = (v3 == v5)
        if (v6) {
            return v4
        } else {
            var v7: Int = 0
            v7 = spiralStringIndex(v0, v3)
            var v8: Boolean = false
            v8 = (v7 < v1)
            var v10: Boolean = false
            if (v8) {
                v10 = false
            } else {
                var v9: Boolean = false
                v9 = (v7 < v2)
                v10 = v9
            }
            var v12: Int = 0
            if (v10) {
                v12 = v4
            } else {
                var v11: Int = 0
                v11 = (v4 + 1)
                v12 = v11
            }
            var v13: Int = 0
            v13 = (v3 + 1)
            val t1001_0: String = v0
            val t1039_1: Int = v1
            val t1074_2: Int = v2
            val t1109_13: Int = v13
            val t1146_12: Int = v12
            val t1183_5: Int = v5
            v0 = t1001_0
            v1 = t1039_1
            v2 = t1074_2
            v3 = t1109_13
            v4 = t1146_12
            v5 = t1183_5
            continue
        }
    }
    return 0
}
fun sp_codepoint_byte_offset_loop_2(p0: String, p1: Int, p2: Int, p3: Int, p4: Int, p5: Int, p6: Int): Int {
    var v0: String = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = p3
    var v4: Int = p4
    var v5: Int = p5
    var v6: Int = p6
    while (true) {
        var v7: Boolean = false
        v7 = (v4 == v6)
        if (v7) {
            return v6
        } else {
            var v8: Int = 0
            v8 = spiralStringIndex(v0, v4)
            var v9: Boolean = false
            v9 = (v8 < v1)
            var v11: Boolean = false
            if (v9) {
                v11 = false
            } else {
                var v10: Boolean = false
                v10 = (v8 < v2)
                v11 = v10
            }
            if (v11) {
                var v12: Int = 0
                v12 = (v4 + 1)
                val t862_0: String = v0
                val t903_1: Int = v1
                val t941_2: Int = v2
                val t979_3: Int = v3
                val t1017_12: Int = v12
                val t1058_5: Int = v5
                val t1097_6: Int = v6
                v0 = t862_0
                v1 = t903_1
                v2 = t941_2
                v3 = t979_3
                v4 = t1017_12
                v5 = t1058_5
                v6 = t1097_6
                continue
            } else {
                var v14: Boolean = false
                v14 = (v5 == v3)
                if (v14) {
                    return v4
                } else {
                    var v15: Int = 0
                    v15 = (v4 + 1)
                    var v16: Int = 0
                    v16 = (v5 + 1)
                    val t1700_0: String = v0
                    val t1746_1: Int = v1
                    val t1789_2: Int = v2
                    val t1832_3: Int = v3
                    val t1875_15: Int = v15
                    val t1920_16: Int = v16
                    val t1965_6: Int = v6
                    v0 = t1700_0
                    v1 = t1746_1
                    v2 = t1789_2
                    v3 = t1832_3
                    v4 = t1875_15
                    v5 = t1920_16
                    v6 = t1965_6
                    continue
                }
            }
        }
    }
    return 0
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "À"
    var v1: Int = 0
    v1 = 1
    var v2: Int = 0
    v2 = sp_runtime_byte_0(v0, v1)
    var v3: String = ""
    v3 = "©"
    var v4: Int = 0
    v4 = 0
    var v5: Int = 0
    v5 = sp_runtime_byte_0(v3, v4)
    var v6: String = ""
    v6 = "Aéλ🙂Z"
    var v7: Int = 0
    v7 = 0
    var v8: Int = 0
    v8 = 0
    var v9: Int = 0
    v9 = 10
    var v10: Int = 0
    v10 = sp_codepoint_length_loop_1(v6, v2, v5, v7, v8, v9)
    var v11: Int = 0
    v11 = 1
    var v12: Int = 0
    v12 = sp_runtime_byte_0(v0, v11)
    var v13: Int = 0
    v13 = 0
    var v14: Int = 0
    v14 = sp_runtime_byte_0(v3, v13)
    var v15: Int = 0
    v15 = 1
    var v16: Int = 0
    v16 = 0
    var v17: Int = 0
    v17 = 0
    var v18: Int = 0
    v18 = 10
    var v19: Int = 0
    v19 = sp_codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18)
    var v20: Int = 0
    v20 = 1
    var v21: Int = 0
    v21 = sp_runtime_byte_0(v0, v20)
    var v22: Int = 0
    v22 = 0
    var v23: Int = 0
    v23 = sp_runtime_byte_0(v3, v22)
    var v24: Int = 0
    v24 = 2
    var v25: Int = 0
    v25 = 0
    var v26: Int = 0
    v26 = 0
    var v27: Int = 0
    v27 = 10
    var v28: Int = 0
    v28 = sp_codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27)
    var v29: Int = 0
    v29 = (v28 - 1)
    var v30: String = ""
    v30 = spiralStringSlice("Aéλ🙂Z", v19, v29)
    var v31: Int = 0
    v31 = 1
    var v32: Int = 0
    v32 = sp_runtime_byte_0(v0, v31)
    var v33: Int = 0
    v33 = 0
    var v34: Int = 0
    v34 = sp_runtime_byte_0(v3, v33)
    var v35: Int = 0
    v35 = 3
    var v36: Int = 0
    v36 = 0
    var v37: Int = 0
    v37 = 0
    var v38: Int = 0
    v38 = 10
    var v39: Int = 0
    v39 = sp_codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38)
    var v40: Int = 0
    v40 = 1
    var v41: Int = 0
    v41 = sp_runtime_byte_0(v0, v40)
    var v42: Int = 0
    v42 = 0
    var v43: Int = 0
    v43 = sp_runtime_byte_0(v3, v42)
    var v44: Int = 0
    v44 = 4
    var v45: Int = 0
    v45 = 0
    var v46: Int = 0
    v46 = 0
    var v47: Int = 0
    v47 = 10
    var v48: Int = 0
    v48 = sp_codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47)
    var v49: Int = 0
    v49 = (v48 - 1)
    var v50: String = ""
    v50 = spiralStringSlice("Aéλ🙂Z", v39, v49)
    var v51: Int = 0
    v51 = 1
    var v52: Int = 0
    v52 = sp_runtime_byte_0(v0, v51)
    var v53: Int = 0
    v53 = 0
    var v54: Int = 0
    v54 = sp_runtime_byte_0(v3, v53)
    var v55: Int = 0
    v55 = 1
    var v56: Int = 0
    v56 = 0
    var v57: Int = 0
    v57 = 0
    var v58: Int = 0
    v58 = 10
    var v59: Int = 0
    v59 = sp_codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58)
    var v60: Int = 0
    v60 = 1
    var v61: Int = 0
    v61 = sp_runtime_byte_0(v0, v60)
    var v62: Int = 0
    v62 = 0
    var v63: Int = 0
    v63 = sp_runtime_byte_0(v3, v62)
    var v64: Int = 0
    v64 = 4
    var v65: Int = 0
    v65 = 0
    var v66: Int = 0
    v66 = 0
    var v67: Int = 0
    v67 = 10
    var v68: Int = 0
    v68 = sp_codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67)
    var v69: Int = 0
    v69 = (v68 - 1)
    var v70: String = ""
    v70 = spiralStringSlice("Aéλ🙂Z", v59, v69)
    var v71: Int = 0
    v71 = 1
    var v72: Int = 0
    v72 = sp_runtime_byte_0(v0, v71)
    var v73: Int = 0
    v73 = 0
    var v74: Int = 0
    v74 = sp_runtime_byte_0(v3, v73)
    var v75: Int = 0
    v75 = 3
    var v76: Int = 0
    v76 = 0
    var v77: Int = 0
    v77 = 0
    var v78: Int = 0
    v78 = 10
    var v79: Int = 0
    v79 = sp_codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78)
    var v80: Int = 0
    v80 = 0
    var v81: Int = 0
    v81 = sp_runtime_byte_0(v30, v80)
    var v82: String = ""
    v82 = "é"
    var v83: Int = 0
    v83 = 0
    var v84: Int = 0
    v84 = sp_runtime_byte_0(v82, v83)
    var v85: Int = 0
    v85 = 3
    var v86: Int = 0
    v86 = sp_runtime_byte_0(v50, v85)
    var v87: String = ""
    v87 = "🙂"
    var v88: Int = 0
    v88 = 3
    var v89: Int = 0
    v89 = sp_runtime_byte_0(v87, v88)
    var v90: Boolean = false
    v90 = (v10 == 5)
    if (v90) {
        var v91: Int = 0
        v91 = spiralStringLength(v30)
        var v92: Boolean = false
        v92 = (v91 == 2)
        if (v92) {
            var v93: Boolean = false
            v93 = (v81 == v84)
            if (v93) {
                var v94: Int = 0
                v94 = spiralStringLength(v50)
                var v95: Boolean = false
                v95 = (v94 == 4)
                if (v95) {
                    var v96: Boolean = false
                    v96 = (v86 == v89)
                    if (v96) {
                        var v97: Int = 0
                        v97 = spiralStringLength(v70)
                        var v98: Boolean = false
                        v98 = (v97 == 8)
                        if (v98) {
                            var v99: Boolean = false
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
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
