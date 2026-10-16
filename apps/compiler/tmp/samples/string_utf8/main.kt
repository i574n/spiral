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
    var v0: String = ""
    v0 = "é"
    var v1: Int = 0
    v1 = spiralStringLength(v0)
    var v2: Int = 0
    v2 = spiralStringIndex(v0, 0)
    var v3: Int = 0
    v3 = spiralStringIndex(v0, 1)
    var v4: String = ""
    v4 = "x"
    var v5: String = ""
    v5 = (v0 + v4)
    var v6: Int = 0
    v6 = spiralStringLength(v5)
    var v7: String = ""
    v7 = "ab"
    var v8: Int = 0
    v8 = spiralStringIndex(v7, 0)
    var v9: String = ""
    v9 = spiralStringSlice(v7, 0, 0)
    var v10: Int = 0
    v10 = spiralStringLength(v9)
    var v11: String = ""
    v11 = spiralStringSlice(v7, 1, 0)
    var v12: Int = 0
    v12 = spiralStringLength(v11)
    var v13: String = ""
    v13 = spiralStringSlice(v0, 0, 1)
    var v14: Int = 0
    v14 = spiralStringLength(v13)
    var v15: Boolean = false
    v15 = (v2 == v3)
    if (v15) {
        return 1
    } else {
        var v16: Boolean = false
        v16 = (v1 == 2)
        var v18: Boolean = false
        if (v16) {
            var v17: Boolean = false
            v17 = (v8 == 97)
            v18 = v17
        } else {
            v18 = false
        }
        var v20: Boolean = false
        if (v18) {
            var v19: Boolean = false
            v19 = (v6 == 3)
            v20 = v19
        } else {
            v20 = false
        }
        var v22: Boolean = false
        if (v20) {
            var v21: Boolean = false
            v21 = (v10 == 1)
            v22 = v21
        } else {
            v22 = false
        }
        var v24: Boolean = false
        if (v22) {
            var v23: Boolean = false
            v23 = (v12 == 0)
            v24 = v23
        } else {
            v24 = false
        }
        var v26: Boolean = false
        if (v24) {
            var v25: Boolean = false
            v25 = (v14 == 2)
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
