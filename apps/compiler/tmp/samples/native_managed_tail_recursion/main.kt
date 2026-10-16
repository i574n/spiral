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
fun sp_method1(p0: Int, p1: String): String {
    var v0: Int = p0
    var v1: String = p1
    while (true) {
        var v2: Int = 0
        v2 = (v0 - 1)
        var v3: Boolean = false
        v3 = (v2 == 0)
        if (v3) {
            return v1
        } else {
            var v4: Int = 0
            v4 = (v2 % 2)
            var v5: Boolean = false
            v5 = (v4 == 0)
            var v8: String = ""
            if (v5) {
                var v6: String = ""
                v6 = "ok"
                v8 = v6
            } else {
                var v7: String = ""
                v7 = "go"
                v8 = v7
            }
            val t671_2: Int = v2
            val t705_8: String = v8
            v0 = t671_2
            v1 = t705_8
            continue
        }
    }
    return ""
}
fun sp_method0(): String {
    var v0: Int = 0
    v0 = 1000000
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: String = ""
        v2 = "seed"
        return v2
    } else {
        var v3: Int = 0
        v3 = (v0 % 2)
        var v4: Boolean = false
        v4 = (v3 == 0)
        var v7: String = ""
        if (v4) {
            var v5: String = ""
            v5 = "ok"
            v7 = v5
        } else {
            var v6: String = ""
            v6 = "go"
            v7 = v6
        }
        return sp_method1(v0, v7)
    }
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = sp_method0()
    var v1: Int = 0
    v1 = spiralStringLength(v0)
    var v2: Boolean = false
    v2 = (v1 == 2)
    if (v2) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
