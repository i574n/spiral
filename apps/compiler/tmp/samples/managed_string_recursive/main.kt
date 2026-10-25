sealed interface UH0 { val tag: Int }
object UH0_Empty : UH0 { override val tag: Int = 0 }
data class UH0_Node(val f0: String, val f1: UH0, val f2: UH0) : UH0 { override val tag: Int = 1 }
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
fun sp_score_0(p0: UH0): Int {
    var v0: UH0 = p0
    when (v0.tag) {
        0 -> {
            return 0
        }
        1 -> {
            var v1: String = (v0 as UH0_Node).f0
            var v2: UH0 = (v0 as UH0_Node).f1
            var v3: UH0 = (v0 as UH0_Node).f2
            var v4: Int = 0
            v4 = spiralStringLength(v1)
            var v5: Int = 0
            v5 = sp_score_0(v2)
            var v6: Int = 0
            v6 = (v4 + v5)
            var v7: Int = 0
            v7 = sp_score_0(v3)
            var v8: Int = 0
            v8 = (v6 + v7)
            return v8
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: String = "ab"
    val v1: String = "qwe"
    val v2: UH0 = UH0_Empty
    val v3: UH0 = UH0_Node(v1, v2, v2)
    var v4: UH0 = UH0_Empty
    v4 = UH0_Node(v0, v3, v3)
    var v5: Int = 0
    v5 = sp_score_0(v4)
    var v6: UH0 = UH0_Empty
    v6 = UH0_Empty
    var v7: UH0 = UH0_Empty
    v7 = UH0_Node(v1, v6, v6)
    var v8: UH0 = UH0_Empty
    v8 = UH0_Node(v0, v7, v7)
    val v9: Int = sp_score_0(v8)
    val v10: Int = (v5 + v9)
    val v11: Int = (v10 - 16)
    return v11
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
