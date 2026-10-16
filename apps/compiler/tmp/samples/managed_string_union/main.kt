sealed interface US0 { val tag: Int }
data class US0_Text(val f0: String) : US0 { override val tag: Int = 0 }
data class US0_Number(val f0: Int) : US0 { override val tag: Int = 1 }
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
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v3: Int = (v0 as US0_Number).f0
            return v3
        }
        0 -> {
            var v1: String = (v0 as US0_Text).f0
            var v2: Int = 0
            v2 = spiralStringLength(v1)
            return v2
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = false
    var v4: US0 = US0_Text("")
    if (v0) {
        v4 = US0_Number(7)
    } else {
        var v2: String = ""
        v2 = "qwe"
        v4 = US0_Text(v2)
    }
    var v5: Int = 0
    v5 = sp_score_0(v4)
    var v6: Int = 0
    v6 = sp_score_0(v4)
    var v7: Int = 0
    v7 = (v5 + v6)
    var v8: Int = 0
    v8 = (v7 - 6)
    return v8
}
fun main() {
    System.exit(spiral_main())
}
