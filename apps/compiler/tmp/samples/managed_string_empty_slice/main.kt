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
fun sp_empty_middle_0(p0: String): String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 2, 1)
    return v1
}
fun sp_empty_end_1(p0: String): String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 5, 4)
    return v1
}
fun sp_empty_source_2(p0: String): String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 0, -1)
    return v1
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "alpha"
    var v1: String = ""
    v1 = sp_empty_middle_0(v0)
    var v2: String = ""
    v2 = sp_empty_end_1(v0)
    var v3: String = ""
    v3 = ""
    var v4: String = ""
    v4 = sp_empty_source_2(v3)
    var v5: String = ""
    v5 = (v1 + v2)
    var v6: String = ""
    v6 = (v4 + "ok")
    var v7: String = ""
    v7 = (v5 + v6)
    var v8: Int = 0
    v8 = spiralStringLength(v1)
    var v9: Boolean = false
    v9 = (v8 == 0)
    if (v9) {
        var v10: Int = 0
        v10 = spiralStringLength(v2)
        var v11: Boolean = false
        v11 = (v10 == 0)
        if (v11) {
            var v12: Int = 0
            v12 = spiralStringLength(v4)
            var v13: Boolean = false
            v13 = (v12 == 0)
            if (v13) {
                var v14: Int = 0
                v14 = spiralStringLength(v7)
                var v15: Boolean = false
                v15 = (v14 == 2)
                if (v15) {
                    var v16: Int = 0
                    v16 = spiralStringIndex(v7, 0)
                    var v17: Boolean = false
                    v17 = (v16 == 111)
                    if (v17) {
                        var v18: Int = 0
                        v18 = spiralStringIndex(v7, 1)
                        var v19: Boolean = false
                        v19 = (v18 == 107)
                        if (v19) {
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
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
