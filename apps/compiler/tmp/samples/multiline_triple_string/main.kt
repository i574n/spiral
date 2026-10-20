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
    var v0: Int = 0
    v0 = 16
    var v1: String = ""
    v1 = "x\ny"
    var v2: String = ""
    v2 = "say \"hi\""
    var v3: String = ""
    v3 = "a \"\"\" b"
    var v4: String = ""
    v4 = "first\n    second\n\nthird"
    var v5: String = ""
    v5 = "ab\ncd"
    var v6: String = ""
    v6 = "a \"b\" c"
    var v7: String = ""
    v7 = ""
    var v8: String = ""
    v8 = "a\\nb"
    var v9: String = ""
    v9 = "first\n(* not a comment *)\n// nor this\n\n\$\"not a macro\" !x\ninl fake () = 1\n  indented"
    var v10: String = ""
    v10 = "\ntop\n\nlevel"
    var v11: Int = 0
    v11 = spiralStringLength(v6)
    var v12: Boolean = false
    v12 = (v11 != 7)
    if (v12) {
        return 1
    } else {
        var v13: Int = 0
        v13 = spiralStringIndex(v6, 2)
        var v14: Boolean = false
        v14 = (v13 != 34)
        if (v14) {
            return 2
        } else {
            var v15: Int = 0
            v15 = spiralStringLength(v7)
            var v16: Boolean = false
            v16 = (v15 != 0)
            if (v16) {
                return 3
            } else {
                var v17: Int = 0
                v17 = spiralStringLength(v8)
                var v18: Boolean = false
                v18 = (v17 != 4)
                if (v18) {
                    return 4
                } else {
                    var v19: Int = 0
                    v19 = spiralStringIndex(v8, 1)
                    var v20: Boolean = false
                    v20 = (v19 != 92)
                    if (v20) {
                        return 5
                    } else {
                        var v21: Int = 0
                        v21 = spiralStringLength(v9)
                        var v22: Boolean = false
                        v22 = (v21 != 83)
                        if (v22) {
                            return 6
                        } else {
                            var v23: Int = 0
                            v23 = spiralStringIndex(v9, 5)
                            var v24: Boolean = false
                            v24 = (v23 != 10)
                            if (v24) {
                                return 7
                            } else {
                                var v25: Int = 0
                                v25 = spiralStringIndex(v9, 37)
                                var v26: Boolean = false
                                v26 = (v25 != 10)
                                if (v26) {
                                    return 8
                                } else {
                                    var v27: Int = 0
                                    v27 = spiralStringIndex(v9, 38)
                                    var v28: Boolean = false
                                    v28 = (v27 != 10)
                                    if (v28) {
                                        return 9
                                    } else {
                                        var v29: Int = 0
                                        v29 = spiralStringIndex(v9, 39)
                                        var v30: Boolean = false
                                        v30 = (v29 != 36)
                                        if (v30) {
                                            return 10
                                        } else {
                                            var v31: Int = 0
                                            v31 = spiralStringIndex(v9, 57)
                                            var v32: Boolean = false
                                            v32 = (v31 != 105)
                                            if (v32) {
                                                return 11
                                            } else {
                                                var v33: Int = 0
                                                v33 = spiralStringIndex(v9, 82)
                                                var v34: Boolean = false
                                                v34 = (v33 != 100)
                                                if (v34) {
                                                    return 12
                                                } else {
                                                    var v35: Int = 0
                                                    v35 = spiralStringLength(v10)
                                                    var v36: Boolean = false
                                                    v36 = (v35 != 11)
                                                    if (v36) {
                                                        return 13
                                                    } else {
                                                        var v37: Int = 0
                                                        v37 = spiralStringIndex(v10, 0)
                                                        var v38: Boolean = false
                                                        v38 = (v37 != 10)
                                                        if (v38) {
                                                            return 14
                                                        } else {
                                                            var v39: Int = 0
                                                            v39 = spiralStringIndex(v10, 5)
                                                            var v40: Boolean = false
                                                            v40 = (v39 != 10)
                                                            if (v40) {
                                                                return 15
                                                            } else {
                                                                var v41: Boolean = false
                                                                v41 = (v0 != 16)
                                                                if (v41) {
                                                                    return 16
                                                                } else {
                                                                    var v42: Int = 0
                                                                    v42 = spiralStringLength(v1)
                                                                    var v43: Boolean = false
                                                                    v43 = (v42 != 3)
                                                                    if (v43) {
                                                                        return 17
                                                                    } else {
                                                                        var v44: Int = 0
                                                                        v44 = spiralStringLength(v2)
                                                                        var v45: Boolean = false
                                                                        v45 = (v44 != 8)
                                                                        if (v45) {
                                                                            return 18
                                                                        } else {
                                                                            var v46: Int = 0
                                                                            v46 = spiralStringIndex(v2, 7)
                                                                            var v47: Boolean = false
                                                                            v47 = (v46 != 34)
                                                                            if (v47) {
                                                                                return 19
                                                                            } else {
                                                                                var v48: Int = 0
                                                                                v48 = spiralStringLength(v3)
                                                                                var v49: Boolean = false
                                                                                v49 = (v48 != 7)
                                                                                if (v49) {
                                                                                    return 20
                                                                                } else {
                                                                                    var v50: Int = 0
                                                                                    v50 = spiralStringIndex(v3, 4)
                                                                                    var v51: Boolean = false
                                                                                    v51 = (v50 != 34)
                                                                                    if (v51) {
                                                                                        return 21
                                                                                    } else {
                                                                                        var v52: Int = 0
                                                                                        v52 = spiralStringLength(v4)
                                                                                        var v53: Boolean = false
                                                                                        v53 = (v52 != 23)
                                                                                        if (v53) {
                                                                                            return 22
                                                                                        } else {
                                                                                            var v54: Int = 0
                                                                                            v54 = spiralStringIndex(v4, 6)
                                                                                            var v55: Boolean = false
                                                                                            v55 = (v54 != 32)
                                                                                            if (v55) {
                                                                                                return 23
                                                                                            } else {
                                                                                                var v56: Int = 0
                                                                                                v56 = spiralStringIndex(v4, 10)
                                                                                                var v57: Boolean = false
                                                                                                v57 = (v56 != 115)
                                                                                                if (v57) {
                                                                                                    return 24
                                                                                                } else {
                                                                                                    var v58: Int = 0
                                                                                                    v58 = spiralStringIndex(v4, 17)
                                                                                                    var v59: Boolean = false
                                                                                                    v59 = (v58 != 10)
                                                                                                    if (v59) {
                                                                                                        return 25
                                                                                                    } else {
                                                                                                        var v60: Int = 0
                                                                                                        v60 = spiralStringIndex(v4, 22)
                                                                                                        var v61: Boolean = false
                                                                                                        v61 = (v60 != 100)
                                                                                                        if (v61) {
                                                                                                            return 26
                                                                                                        } else {
                                                                                                            var v62: Int = 0
                                                                                                            v62 = spiralStringLength(v5)
                                                                                                            var v63: Boolean = false
                                                                                                            v63 = (v62 != 5)
                                                                                                            if (v63) {
                                                                                                                return 27
                                                                                                            } else {
                                                                                                                var v64: Int = 0
                                                                                                                v64 = spiralStringIndex(v5, 3)
                                                                                                                var v65: Boolean = false
                                                                                                                v65 = (v64 != 99)
                                                                                                                if (v65) {
                                                                                                                    return 28
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
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
