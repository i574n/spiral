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
    val v1: String = "x"
    val v2: String = (v0 + v1)
    val v3: String = "éx"
    val v4: String = "éy"
    val v5: String = ""
    val v6: String = spiralStringSlice(v3, 1, 0)
    val v7: Boolean = (v2 == v3)
    var v9: Boolean = false
    if (v7) {
        val v8: Boolean = (v2 != v4)
        v9 = v8
    } else {
        v9 = false
    }
    var v11: Boolean = false
    if (v9) {
        val v10: Boolean = (v0 != v3)
        v11 = v10
    } else {
        v11 = false
    }
    var v13: Boolean = false
    if (v11) {
        val v12: Boolean = (v5 == v6)
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Boolean = false
    if (v13) {
        val v14: Boolean = (v5 != v0)
        v15 = v14
    } else {
        v15 = false
    }
    if (v15) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
