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
    val v0: String = "alpha"
    var v1: String = ""
    v1 = sp_empty_middle_0(v0)
    val v2: String = sp_empty_end_1(v0)
    val v3: String = ""
    val v4: String = sp_empty_source_2(v3)
    val v5: String = (v1 + v2)
    val v6: String = (v4 + "ok")
    val v7: String = (v5 + v6)
    val v8: Int = spiralStringLength(v1)
    val v9: Boolean = (v8 == 0)
    if (v9) {
        val v10: Int = spiralStringLength(v2)
        val v11: Boolean = (v10 == 0)
        if (v11) {
            val v12: Int = spiralStringLength(v4)
            val v13: Boolean = (v12 == 0)
            if (v13) {
                val v14: Int = spiralStringLength(v7)
                val v15: Boolean = (v14 == 2)
                if (v15) {
                    val v16: Int = spiralStringIndex(v7, 0)
                    val v17: Boolean = (v16 == 111)
                    if (v17) {
                        val v18: Int = spiralStringIndex(v7, 1)
                        val v19: Boolean = (v18 == 107)
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
