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
fun spiral_main(): Int {
    val v0: String = "é"
    val v1: Int = spiralStringLength(v0)
    val v2: Int = spiralStringIndex(v0, 0)
    val v3: Int = spiralStringIndex(v0, 1)
    val v4: String = "x"
    val v5: String = (v0 + v4)
    val v6: Int = spiralStringLength(v5)
    val v7: String = "ab"
    val v8: Int = spiralStringIndex(v7, 0)
    val v9: String = spiralStringSlice(v7, 0, 0)
    val v10: Int = spiralStringLength(v9)
    val v11: String = spiralStringSlice(v7, 1, 0)
    val v12: Int = spiralStringLength(v11)
    val v13: String = spiralStringSlice(v0, 0, 1)
    val v14: Int = spiralStringLength(v13)
    val v15: Boolean = (v2 == v3)
    if (v15) {
        return 1
    } else {
        val v16: Boolean = (v1 == 2)
        var v18: Boolean = false
        if (v16) {
            val v17: Boolean = (v8 == 97)
            v18 = v17
        } else {
            v18 = false
        }
        var v20: Boolean = false
        if (v18) {
            val v19: Boolean = (v6 == 3)
            v20 = v19
        } else {
            v20 = false
        }
        var v22: Boolean = false
        if (v20) {
            val v21: Boolean = (v10 == 1)
            v22 = v21
        } else {
            v22 = false
        }
        var v24: Boolean = false
        if (v22) {
            val v23: Boolean = (v12 == 0)
            v24 = v23
        } else {
            v24 = false
        }
        var v26: Boolean = false
        if (v24) {
            val v25: Boolean = (v14 == 2)
            v26 = v25
        } else {
            v26 = false
        }
        if (v26) {
            return 0
        } else {
            return 1
        }
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
