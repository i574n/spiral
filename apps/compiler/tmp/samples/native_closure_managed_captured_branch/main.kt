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
fun left_c0(v0: String): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = spiralStringLength(v0)
        var v3: Int = 0
        v3 = (v2 + v1)
        return v3
    }
    return { p0: Int -> body(p0) }
}
fun right_c1(v0: String): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = spiralStringLength(v0)
        var v3: Int = 0
        v3 = (v2 + v1)
        var v4: Int = 0
        v4 = (v3 - 1)
        return v4
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: (Int) -> Int): Int {
    var v0: (Int) -> Int = p0
    return v0(39)
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "abc"
    var v1: String = ""
    v1 = "wxyz"
    var v2: Boolean = false
    v2 = true
    var v5: (Int) -> Int = { _: Int -> throw RuntimeException() }
    if (v2) {
        v5 = left_c0(v0)
    } else {
        v5 = right_c1(v1)
    }
    return sp_method0(v5)
}
fun main() {
    System.exit(spiral_main())
}
