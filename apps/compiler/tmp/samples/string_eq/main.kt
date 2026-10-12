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
    var v1: String = ""
    v1 = "x"
    var v2: String = ""
    v2 = (v0 + v1)
    var v3: String = ""
    v3 = "éx"
    var v4: String = ""
    v4 = "éy"
    var v5: String = ""
    v5 = ""
    var v6: String = ""
    v6 = spiralStringSlice(v3, 1, 0)
    var v7: Boolean = false
    v7 = (v2 == v3)
    var v9: Boolean = false
    if (v7) {
        var v8: Boolean = false
        v8 = (v2 != v4)
        v9 = v8
    } else {
        v9 = false
    }
    var v11: Boolean = false
    if (v9) {
        var v10: Boolean = false
        v10 = (v0 != v3)
        v11 = v10
    } else {
        v11 = false
    }
    var v13: Boolean = false
    if (v11) {
        var v12: Boolean = false
        v12 = (v5 == v6)
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Boolean = false
    if (v13) {
        var v14: Boolean = false
        v14 = (v5 != v0)
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
    System.exit(spiral_main())
}
