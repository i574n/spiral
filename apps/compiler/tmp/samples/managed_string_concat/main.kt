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
fun sp_choose_left_0(p0: Boolean): String {
    var v0: Boolean = p0
    if (v0) {
        var v1: String = ""
        v1 = "spi"
        return v1
    } else {
        var v2: String = ""
        v2 = "bad"
        return v2
    }
}
fun sp_choose_right_1(p0: Boolean): String {
    var v0: Boolean = p0
    if (v0) {
        var v1: String = ""
        v1 = "bad"
        return v1
    } else {
        var v2: String = ""
        v2 = "ral"
        return v2
    }
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v1: String = ""
    v1 = sp_choose_left_0(v0)
    var v2: Boolean = false
    v2 = false
    var v3: String = ""
    v3 = sp_choose_right_1(v2)
    var v4: String = ""
    v4 = (v1 + v3)
    var v5: Int = 0
    v5 = spiralStringLength(v4)
    var v6: Boolean = false
    v6 = (v5 == 6)
    if (v6) {
        var v7: Int = 0
        v7 = spiralStringIndex(v4, 0)
        var v8: Boolean = false
        v8 = (v7 == 115)
        if (v8) {
            var v9: Int = 0
            v9 = spiralStringIndex(v4, 5)
            var v10: Boolean = false
            v10 = (v9 == 108)
            if (v10) {
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
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
