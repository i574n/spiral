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
            v3 = v13
            v4 = v12
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
                v4 = v12
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
                    v4 = v15
                    v5 = v16
                    continue
                }
            }
        }
    }
    return 0
}
fun spiral_main(): Int {
    val v0: String = "À"
    val v1: Int = 1
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
    val v17: Int = 0
    val v18: Int = 10
    val v19: Int = sp_codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18)
    val v20: Int = 1
    val v21: Int = sp_runtime_byte_0(v0, v20)
    val v22: Int = 0
    val v23: Int = sp_runtime_byte_0(v3, v22)
    val v24: Int = 2
    val v25: Int = 0
    val v26: Int = 0
    val v27: Int = 10
    val v28: Int = sp_codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27)
    val v29: Int = (v28 - 1)
    val v30: String = spiralStringSlice("Aéλ🙂Z", v19, v29)
    val v31: Int = 1
    val v32: Int = sp_runtime_byte_0(v0, v31)
    val v33: Int = 0
    val v34: Int = sp_runtime_byte_0(v3, v33)
    val v35: Int = 3
    val v36: Int = 0
    val v37: Int = 0
    val v38: Int = 10
    val v39: Int = sp_codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38)
    val v40: Int = 1
    val v41: Int = sp_runtime_byte_0(v0, v40)
    val v42: Int = 0
    val v43: Int = sp_runtime_byte_0(v3, v42)
    val v44: Int = 4
    val v45: Int = 0
    val v46: Int = 0
    val v47: Int = 10
    val v48: Int = sp_codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47)
    val v49: Int = (v48 - 1)
    val v50: String = spiralStringSlice("Aéλ🙂Z", v39, v49)
    val v51: Int = 1
    val v52: Int = sp_runtime_byte_0(v0, v51)
    val v53: Int = 0
    val v54: Int = sp_runtime_byte_0(v3, v53)
    val v55: Int = 1
    val v56: Int = 0
    val v57: Int = 0
    val v58: Int = 10
    val v59: Int = sp_codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58)
    val v60: Int = 1
    val v61: Int = sp_runtime_byte_0(v0, v60)
    val v62: Int = 0
    val v63: Int = sp_runtime_byte_0(v3, v62)
    val v64: Int = 4
    val v65: Int = 0
    val v66: Int = 0
    val v67: Int = 10
    val v68: Int = sp_codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67)
    val v69: Int = (v68 - 1)
    val v70: String = spiralStringSlice("Aéλ🙂Z", v59, v69)
    val v71: Int = 1
    val v72: Int = sp_runtime_byte_0(v0, v71)
    val v73: Int = 0
    val v74: Int = sp_runtime_byte_0(v3, v73)
    val v75: Int = 3
    val v76: Int = 0
    val v77: Int = 0
    val v78: Int = 10
    val v79: Int = sp_codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78)
    val v80: Int = 0
    val v81: Int = sp_runtime_byte_0(v30, v80)
    val v82: String = "é"
    val v83: Int = 0
    val v84: Int = sp_runtime_byte_0(v82, v83)
    val v85: Int = 3
    val v86: Int = sp_runtime_byte_0(v50, v85)
    val v87: String = "🙂"
    val v88: Int = 3
    val v89: Int = sp_runtime_byte_0(v87, v88)
    val v90: Boolean = (v10 == 5)
    if (v90) {
        val v91: Int = spiralStringLength(v30)
        val v92: Boolean = (v91 == 2)
        if (v92) {
            val v93: Boolean = (v81 == v84)
            if (v93) {
                val v94: Int = spiralStringLength(v50)
                val v95: Boolean = (v94 == 4)
                if (v95) {
                    val v96: Boolean = (v86 == v89)
                    if (v96) {
                        val v97: Int = spiralStringLength(v70)
                        val v98: Boolean = (v97 == 8)
                        if (v98) {
                            val v99: Boolean = (v79 == 5)
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
