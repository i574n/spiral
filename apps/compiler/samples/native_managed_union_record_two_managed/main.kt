sealed interface US0 { val tag: Int }
object US0_Empty : US0 { override val tag: Int = 0 }
data class US0_Item(val f0: String, val f1: Array<Int>) : US0 { override val tag: Int = 1 }
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
            var v3: Array<Int> = emptyArray<Int>()
            v3 = Array(2) { 0 }
            v3[0] = v0
            var v4: Int = 0
            v4 = (v0 + 1)
            v3[1] = v4
            var v5: String = ""
            v5 = "hi"
            return US0_Item(v5, v3)
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
    return v0(4)
}
fun spiral_main(): Int {
    val v0: (Int) -> US0 = closure0()
    var v1: US0 = US0_Empty
    v1 = sp_method0(v0)
    var v12: Int = 0
    when (v1.tag) {
        0 -> {
            v12 = 3
        }
        1 -> {
            var v2: String = (v1 as US0_Item).f0
            var v3: Array<Int> = (v1 as US0_Item).f1
            var v4: Int = 0
            v4 = spiralStringLength(v2)
            var v5: Int = 0
            v5 = v3.size
            val v6: Int = (v4 + v5)
            val v7: Int = v3[0]
            val v8: Int = (v6 + v7)
            val v9: Int = v3[1]
            val v10: Int = (v8 + v9)
            v12 = v10
        }
        else -> throw RuntimeException()
    }
    val v13: US0 = sp_method1(v0)
    var v24: Int = 0
    when (v13.tag) {
        0 -> {
            v24 = 3
        }
        1 -> {
            var v14: String = (v13 as US0_Item).f0
            var v15: Array<Int> = (v13 as US0_Item).f1
            val v16: Int = spiralStringLength(v14)
            val v17: Int = v15.size
            val v18: Int = (v16 + v17)
            val v19: Int = v15[0]
            val v20: Int = (v18 + v19)
            val v21: Int = v15[1]
            val v22: Int = (v20 + v21)
            v24 = v22
        }
        else -> throw RuntimeException()
    }
    val v25: Int = (v12 + v24)
    val v26: Int = (v25 + 26)
    return v26
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
