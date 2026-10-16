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
fun sp_choose_0(p0: Boolean): String {
    var v0: Boolean = p0
    if (v0) {
        var v1: String = ""
        v1 = "alpha"
        return v1
    } else {
        var v2: String = ""
        v2 = "beta"
        return v2
    }
}
fun sp_measure_1(p0: String): Int {
    var v0: String = p0
    var v1: Int = 0
    v1 = spiralStringLength(v0)
    return v1
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v1: String = ""
    v1 = sp_choose_0(v0)
    var v2: Boolean = false
    v2 = false
    var v3: String = ""
    v3 = sp_choose_0(v2)
    var v4: Int = 0
    v4 = sp_measure_1(v1)
    var v5: Int = 0
    v5 = sp_measure_1(v1)
    var v6: Int = 0
    v6 = (v4 + v5)
    var v7: Int = 0
    v7 = sp_measure_1(v3)
    var v8: Int = 0
    v8 = (v6 + v7)
    var v9: Int = 0
    v9 = (v8 - 14)
    return v9
}
fun main() {
    System.exit(spiral_main())
}
