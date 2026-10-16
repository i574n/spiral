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
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "a \"b\" c"
    var v1: String = ""
    v1 = ""
    var v2: String = ""
    v2 = "a\\nb"
    var v3: String = ""
    v3 = "first\n(* not a comment *)\n// nor this\n\n\$\"not a macro\" !x\ninl fake () = 1\n  indented"
    var v4: String = ""
    v4 = "\ntop\n\nlevel"
    var v5: Int = 0
    v5 = spiralStringLength(v0)
    var v6: Boolean = false
    v6 = (v5 == 7)
    var v7: Boolean = false
    v7 = (v6 != true)
    if (v7) {
        return 1
    } else {
        var v8: Int = 0
        v8 = spiralStringIndex(v0, 2)
        var v9: Boolean = false
        v9 = (v8 == 34)
        var v10: Boolean = false
        v10 = (v9 != true)
        if (v10) {
            return 2
        } else {
            var v11: Int = 0
            v11 = spiralStringLength(v1)
            var v12: Boolean = false
            v12 = (v11 == 0)
            var v13: Boolean = false
            v13 = (v12 != true)
            if (v13) {
                return 3
            } else {
                var v14: Int = 0
                v14 = spiralStringLength(v2)
                var v15: Boolean = false
                v15 = (v14 == 4)
                var v16: Boolean = false
                v16 = (v15 != true)
                if (v16) {
                    return 4
                } else {
                    var v17: Int = 0
                    v17 = spiralStringIndex(v2, 1)
                    var v18: Boolean = false
                    v18 = (v17 == 92)
                    var v19: Boolean = false
                    v19 = (v18 != true)
                    if (v19) {
                        return 5
                    } else {
                        var v20: Int = 0
                        v20 = spiralStringLength(v3)
                        var v21: Boolean = false
                        v21 = (v20 == 83)
                        var v22: Boolean = false
                        v22 = (v21 != true)
                        if (v22) {
                            return 6
                        } else {
                            var v23: Int = 0
                            v23 = spiralStringIndex(v3, 5)
                            var v24: Boolean = false
                            v24 = (v23 == 10)
                            var v25: Boolean = false
                            v25 = (v24 != true)
                            if (v25) {
                                return 7
                            } else {
                                var v26: Int = 0
                                v26 = spiralStringIndex(v3, 37)
                                var v27: Boolean = false
                                v27 = (v26 == 10)
                                var v28: Boolean = false
                                v28 = (v27 != true)
                                if (v28) {
                                    return 8
                                } else {
                                    var v29: Int = 0
                                    v29 = spiralStringIndex(v3, 38)
                                    var v30: Boolean = false
                                    v30 = (v29 == 10)
                                    var v31: Boolean = false
                                    v31 = (v30 != true)
                                    if (v31) {
                                        return 9
                                    } else {
                                        var v32: Int = 0
                                        v32 = spiralStringIndex(v3, 39)
                                        var v33: Boolean = false
                                        v33 = (v32 == 36)
                                        var v34: Boolean = false
                                        v34 = (v33 != true)
                                        if (v34) {
                                            return 10
                                        } else {
                                            var v35: Int = 0
                                            v35 = spiralStringIndex(v3, 57)
                                            var v36: Boolean = false
                                            v36 = (v35 == 105)
                                            var v37: Boolean = false
                                            v37 = (v36 != true)
                                            if (v37) {
                                                return 11
                                            } else {
                                                var v38: Int = 0
                                                v38 = spiralStringIndex(v3, 82)
                                                var v39: Boolean = false
                                                v39 = (v38 == 100)
                                                var v40: Boolean = false
                                                v40 = (v39 != true)
                                                if (v40) {
                                                    return 12
                                                } else {
                                                    var v41: Int = 0
                                                    v41 = spiralStringLength(v4)
                                                    var v42: Boolean = false
                                                    v42 = (v41 == 11)
                                                    var v43: Boolean = false
                                                    v43 = (v42 != true)
                                                    if (v43) {
                                                        return 13
                                                    } else {
                                                        var v44: Int = 0
                                                        v44 = spiralStringIndex(v4, 0)
                                                        var v45: Boolean = false
                                                        v45 = (v44 == 10)
                                                        var v46: Boolean = false
                                                        v46 = (v45 != true)
                                                        if (v46) {
                                                            return 14
                                                        } else {
                                                            var v47: Int = 0
                                                            v47 = spiralStringIndex(v4, 5)
                                                            var v48: Boolean = false
                                                            v48 = (v47 == 10)
                                                            var v49: Boolean = false
                                                            v49 = (v48 != true)
                                                            if (v49) {
                                                                return 15
                                                            } else {
                                                                return 0
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
fun main() {
    System.exit(spiral_main())
}
