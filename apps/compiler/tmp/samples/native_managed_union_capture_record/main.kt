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
fun closure1(v0: US0): (Int) -> Int {
    fun body(v1: Int): Int {
        var v12: Int = 0
        when (v0.tag) {
            0 -> {
                v12 = 3
            }
            1 -> {
                var v2: String = (v0 as US0_Item).f0
                var v3: Array<Int> = (v0 as US0_Item).f1
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
        var v13: Int = 0
        v13 = (v12 + v1)
        return v13
    }
    return { p0: Int -> body(p0) }
}
fun closure0(): (Int) -> (Int) -> Int {
    fun body(v0: Int): (Int) -> Int {
        var v1: Array<Int> = emptyArray<Int>()
        v1 = Array(2) { 0 }
        v1[0] = v0
        var v2: Int = 0
        v2 = (v0 + 1)
        v1[1] = v2
        var v3: Boolean = false
        v3 = (v0 == 0)
        var v7: US0 = US0_Empty()
        if (v3) {
            v7 = US0_Empty()
        } else {
            var v5: String = ""
            v5 = "hi"
            v7 = US0_Item(v5, v1)
        }
        return closure1(v7)
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: (Int) -> (Int) -> Int): (Int) -> Int {
    var v0: (Int) -> (Int) -> Int = p0
    return v0(0)
}
fun sp_method1(p0: (Int) -> (Int) -> Int): (Int) -> Int {
    var v0: (Int) -> (Int) -> Int = p0
    return v0(4)
}
fun sp_method4(p0: (Int) -> Int): Int {
    var v0: (Int) -> Int = p0
    var v1: Int = 0
    v1 = v0(2)
    var v2: Int = 0
    v2 = (v1 + 5)
    return v2
}
fun sp_method3(p0: (Int) -> Int): Int {
    var v0: (Int) -> Int = p0
    var v1: Int = 0
    v1 = v0(1)
    var v2: Int = 0
    v2 = sp_method4(v0)
    var v3: Int = 0
    v3 = (v1 + v2)
    return v3
}
fun sp_method2(p0: (Int) -> Int, p1: (Int) -> Int): Int {
    var v0: (Int) -> Int = p0
    var v1: (Int) -> Int = p1
    var v2: Int = 0
    v2 = v0(5)
    var v3: Int = 0
    v3 = sp_method3(v1)
    var v4: Int = 0
    v4 = (v2 + v3)
    return v4
}
fun spiral_main(): Int {
    var v0: (Int) -> (Int) -> Int = { _: Int -> throw RuntimeException() }
    v0 = closure0()
    var v1: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v1 = sp_method0(v0)
    var v2: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v2 = sp_method1(v0)
    return sp_method2(v1, v2)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
