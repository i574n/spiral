sealed interface US0 { val tag: Int }
class US0_Empty : US0 { override val tag: Int = 0 }
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
            return US0_Empty()
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
    var v0: (Int) -> US0 = { _: Int -> throw RuntimeException() }
    v0 = closure0()
    var v1: US0 = US0_Empty()
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
            var v6: Int = 0
            v6 = (v4 + v5)
            var v7: Int = 0
            v7 = v3[0]
            var v8: Int = 0
            v8 = (v6 + v7)
            var v9: Int = 0
            v9 = v3[1]
            var v10: Int = 0
            v10 = (v8 + v9)
            v12 = v10
        }
        else -> throw RuntimeException()
    }
    var v13: US0 = US0_Empty()
    v13 = sp_method1(v0)
    var v24: Int = 0
    when (v13.tag) {
        0 -> {
            v24 = 3
        }
        1 -> {
            var v14: String = (v13 as US0_Item).f0
            var v15: Array<Int> = (v13 as US0_Item).f1
            var v16: Int = 0
            v16 = spiralStringLength(v14)
            var v17: Int = 0
            v17 = v15.size
            var v18: Int = 0
            v18 = (v16 + v17)
            var v19: Int = 0
            v19 = v15[0]
            var v20: Int = 0
            v20 = (v18 + v19)
            var v21: Int = 0
            v21 = v15[1]
            var v22: Int = 0
            v22 = (v20 + v21)
            v24 = v22
        }
        else -> throw RuntimeException()
    }
    var v25: Int = 0
    v25 = (v12 + v24)
    var v26: Int = 0
    v26 = (v25 + 26)
    return v26
}
fun main() {
    System.exit(spiral_main())
}
