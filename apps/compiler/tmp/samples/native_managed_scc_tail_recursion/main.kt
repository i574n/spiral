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
fun sp_method2(p0: Int, p1: String): Int {
    var v0: Int = p0
    var v1: String = p1
    var v2: Int = 0
    v2 = (v0 - 1)
    var v3: Boolean = false
    v3 = (v2 == 0)
    if (v3) {
        var v4: Int = 0
        v4 = spiralStringLength(v1)
        return v4
    } else {
        return sp_method1(v2, v1)
    }
}
fun sp_method1(p0: Int, p1: String): Int {
    var v0: Int = p0
    var v1: String = p1
    var v2: Int = 0
    v2 = (v0 - 1)
    var v3: Boolean = false
    v3 = (v2 == 0)
    if (v3) {
        return 99
    } else {
        return sp_method2(v2, v1)
    }
}
fun sp_method0(p0: Int, p1: String): Int {
    var v0: Int = p0
    var v1: String = p1
    var v2: Boolean = false
    v2 = (v0 == 0)
    var v5: Int = 0
    if (v2) {
        var v3: Int = 0
        v3 = spiralStringLength(v1)
        v5 = v3
    } else {
        v5 = sp_method1(v0, v1)
    }
    var v6: Int = 0
    v6 = (v5 - 2)
    return v6
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1000000
    var v1: Int = 0
    v1 = (v0 % 2)
    var v2: Boolean = false
    v2 = (v1 == 0)
    var v5: String = ""
    if (v2) {
        var v3: String = ""
        v3 = "ok"
        v5 = v3
    } else {
        var v4: String = ""
        v4 = "go"
        v5 = v4
    }
    return sp_method0(v0, v5)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
