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
fun sp_middle_0(p0: String): String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 1, 3)
    return v1
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "alpha"
    var v1: String = ""
    v1 = sp_middle_0(v0)
    var v2: Int = 0
    v2 = spiralStringLength(v1)
    var v3: Boolean = false
    v3 = (v2 == 3)
    if (v3) {
        var v4: Int = 0
        v4 = spiralStringIndex(v1, 0)
        var v5: Boolean = false
        v5 = (v4 == 108)
        if (v5) {
            var v6: Int = 0
            v6 = spiralStringIndex(v1, 2)
            var v7: Boolean = false
            v7 = (v6 == 104)
            if (v7) {
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
