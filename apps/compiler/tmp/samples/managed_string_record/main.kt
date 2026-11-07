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
class SpiralTuple0(val v0: String, val v1: Int)
fun sp_method0(p0: String): SpiralTuple0 {
    var v0: String = p0
    var v1: Int = 0
    v1 = spiralStringLength(v0)
    return SpiralTuple0(v0, v1)
}
fun sp_score_1(p0: Int, p1: String): Int {
    var v0: Int = p0
    var v1: String = p1
    var v2: Int = 0
    v2 = spiralStringLength(v1)
    var v3: Int = 0
    v3 = (v2 + v0)
    return v3
}
fun spiral_main(): Int {
    val v0: String = "qwe"
    var v1: String = ""
    var v2: Int = 0
    val spiral_tuple108 = sp_method0(v0)
    v1 = spiral_tuple108.v0
    v2 = spiral_tuple108.v1
    var v3: Int = 0
    v3 = sp_score_1(v2, v1)
    val v4: Int = sp_score_1(v2, v1)
    val v5: Int = (v3 + v4)
    val v6: Int = (v5 - 12)
    return v6
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
