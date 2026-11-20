sealed interface US0 { val tag: Int }
object US0_Empty : US0 { override val tag: Int = 0 }
data class US0_Item(val f0: String, val f1: Int) : US0 { override val tag: Int = 1 }
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
fun closure0(): (Int) -> US0 {
    fun body(v0: Int): US0 {
        var v1: Boolean = false
        v1 = (v0 == 0)
        if (v1) {
            return US0_Empty
        } else {
            val v3: String = "managed"
            return US0_Item(v3, 32)
        }
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: (Int) -> US0): US0 {
    var v0: (Int) -> US0 = p0
    return v0(0)
}
fun sp_method1(p0: (Int) -> US0): US0 {
    var v0: (Int) -> US0 = p0
    return v0(1)
}
fun spiral_main(): Int {
    val v0: (Int) -> US0 = closure0()
    var v1: US0 = US0_Empty
    v1 = sp_method0(v0)
    var v7: Int = 0
    when (v1.tag) {
        0 -> {
            v7 = 3
        }
        1 -> {
            var v2: String = (v1 as US0_Item).f0
            var v3: Int = (v1 as US0_Item).f1
            val v4: Int = spiralStringLength(v2)
            val v5: Int = (v4 + v3)
            v7 = v5
        }
        else -> throw RuntimeException()
    }
    val v8: US0 = sp_method1(v0)
    var v14: Int = 0
    when (v8.tag) {
        0 -> {
            v14 = 3
        }
        1 -> {
            var v9: String = (v8 as US0_Item).f0
            var v10: Int = (v8 as US0_Item).f1
            val v11: Int = spiralStringLength(v9)
            val v12: Int = (v11 + v10)
            v14 = v12
        }
        else -> throw RuntimeException()
    }
    val v15: Int = (v7 + v14)
    return v15
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
