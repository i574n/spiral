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
fun sp_first_codepoint_0(p0: String): String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 0, 1)
    return v1
}
fun sp_second_codepoint_1(p0: String): String {
    var v0: String = p0
    var v1: String = ""
    v1 = spiralStringSlice(v0, 2, 3)
    return v1
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "éλ"
    var v1: String = ""
    v1 = sp_first_codepoint_0(v0)
    var v2: String = ""
    v2 = sp_second_codepoint_1(v0)
    var v3: String = ""
    v3 = (v1 + v2)
    var v4: Int = 0
    v4 = spiralStringLength(v1)
    var v5: Boolean = false
    v5 = (v4 == 2)
    if (v5) {
        var v6: Int = 0
        v6 = spiralStringLength(v2)
        var v7: Boolean = false
        v7 = (v6 == 2)
        if (v7) {
            var v8: Int = 0
            v8 = spiralStringLength(v3)
            var v9: Boolean = false
            v9 = (v8 == 4)
            if (v9) {
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
    System.exit(spiral_main())
}
