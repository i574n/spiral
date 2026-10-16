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
fun sp_method2(p0: Int, p1: String, p2: String): String {
    var v0: Int = p0
    var v1: String = p1
    var v2: String = p2
    while (true) {
        var v3: Int = 0
        v3 = (v0 - 1)
        var v4: String = ""
        v4 = (v1 + v2)
        var v5: Boolean = false
        v5 = (v3 == 0)
        if (v5) {
            return v4
        } else {
            var v6: Int = 0
            v6 = (v3 % 2)
            var v7: Boolean = false
            v7 = (v6 == 0)
            var v10: String = ""
            if (v7) {
                var v8: String = ""
                v8 = "ab"
                v10 = v8
            } else {
                var v9: String = ""
                v9 = "c"
                v10 = v9
            }
            val t763_3: Int = v3
            val t797_4: String = v4
            val t834_10: String = v10
            v0 = t763_3
            v1 = t797_4
            v2 = t834_10
            continue
        }
    }
    return ""
}
fun sp_method1(p0: Int, p1: String): String {
    var v0: Int = p0
    var v1: String = p1
    var v2: Int = 0
    v2 = (v0 - 1)
    var v3: String = ""
    v3 = ("" + v1)
    var v4: Boolean = false
    v4 = (v2 == 0)
    if (v4) {
        return v3
    } else {
        var v5: Int = 0
        v5 = (v2 % 2)
        var v6: Boolean = false
        v6 = (v5 == 0)
        var v9: String = ""
        if (v6) {
            var v7: String = ""
            v7 = "ab"
            v9 = v7
        } else {
            var v8: String = ""
            v8 = "c"
            v9 = v8
        }
        return sp_method2(v2, v3, v9)
    }
}
fun sp_method0(): String {
    var v0: Int = 0
    v0 = 4
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: String = ""
        v2 = ""
        return v2
    } else {
        var v3: Int = 0
        v3 = (v0 % 2)
        var v4: Boolean = false
        v4 = (v3 == 0)
        var v7: String = ""
        if (v4) {
            var v5: String = ""
            v5 = "ab"
            v7 = v5
        } else {
            var v6: String = ""
            v6 = "c"
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
    v2 = (v1 == 6)
    if (v2) {
        var v3: Int = 0
        v3 = spiralStringIndex(v0, 0)
        var v4: Boolean = false
        v4 = (v3 == 97)
        if (v4) {
            var v5: Int = 0
            v5 = spiralStringIndex(v0, 5)
            var v6: Boolean = false
            v6 = (v5 == 99)
            if (v6) {
                return 0
            } else {
                return 1
            }
        } else {
            return 2
        }
    } else {
        return 3
    }
}
fun main() {
    System.exit(spiral_main())
}
