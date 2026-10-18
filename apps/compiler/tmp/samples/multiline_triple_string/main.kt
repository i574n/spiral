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
    v12 = (v11 == 7)
    var v13: Boolean = false
    v13 = (v12 != true)
    if (v13) {
        return 1
    } else {
        var v14: Int = 0
        v14 = spiralStringIndex(v6, 2)
        var v15: Boolean = false
        v15 = (v14 == 34)
        var v16: Boolean = false
        v16 = (v15 != true)
        if (v16) {
            return 2
        } else {
            var v17: Int = 0
            v17 = spiralStringLength(v7)
            var v18: Boolean = false
            v18 = (v17 == 0)
            var v19: Boolean = false
            v19 = (v18 != true)
            if (v19) {
                return 3
            } else {
                var v20: Int = 0
                v20 = spiralStringLength(v8)
                var v21: Boolean = false
                v21 = (v20 == 4)
                var v22: Boolean = false
                v22 = (v21 != true)
                if (v22) {
                    return 4
                } else {
                    var v23: Int = 0
                    v23 = spiralStringIndex(v8, 1)
                    var v24: Boolean = false
                    v24 = (v23 == 92)
                    var v25: Boolean = false
                    v25 = (v24 != true)
                    if (v25) {
                        return 5
                    } else {
                        var v26: Int = 0
                        v26 = spiralStringLength(v9)
                        var v27: Boolean = false
                        v27 = (v26 == 83)
                        var v28: Boolean = false
                        v28 = (v27 != true)
                        if (v28) {
                            return 6
                        } else {
                            var v29: Int = 0
                            v29 = spiralStringIndex(v9, 5)
                            var v30: Boolean = false
                            v30 = (v29 == 10)
                            var v31: Boolean = false
                            v31 = (v30 != true)
                            if (v31) {
                                return 7
                            } else {
                                var v32: Int = 0
                                v32 = spiralStringIndex(v9, 37)
                                var v33: Boolean = false
                                v33 = (v32 == 10)
                                var v34: Boolean = false
                                v34 = (v33 != true)
                                if (v34) {
                                    return 8
                                } else {
                                    var v35: Int = 0
                                    v35 = spiralStringIndex(v9, 38)
                                    var v36: Boolean = false
                                    v36 = (v35 == 10)
                                    var v37: Boolean = false
                                    v37 = (v36 != true)
                                    if (v37) {
                                        return 9
                                    } else {
                                        var v38: Int = 0
                                        v38 = spiralStringIndex(v9, 39)
                                        var v39: Boolean = false
                                        v39 = (v38 == 36)
                                        var v40: Boolean = false
                                        v40 = (v39 != true)
                                        if (v40) {
                                            return 10
                                        } else {
                                            var v41: Int = 0
                                            v41 = spiralStringIndex(v9, 57)
                                            var v42: Boolean = false
                                            v42 = (v41 == 105)
                                            var v43: Boolean = false
                                            v43 = (v42 != true)
                                            if (v43) {
                                                return 11
                                            } else {
                                                var v44: Int = 0
                                                v44 = spiralStringIndex(v9, 82)
                                                var v45: Boolean = false
                                                v45 = (v44 == 100)
                                                var v46: Boolean = false
                                                v46 = (v45 != true)
                                                if (v46) {
                                                    return 12
                                                } else {
                                                    var v47: Int = 0
                                                    v47 = spiralStringLength(v10)
                                                    var v48: Boolean = false
                                                    v48 = (v47 == 11)
                                                    var v49: Boolean = false
                                                    v49 = (v48 != true)
                                                    if (v49) {
                                                        return 13
                                                    } else {
                                                        var v50: Int = 0
                                                        v50 = spiralStringIndex(v10, 0)
                                                        var v51: Boolean = false
                                                        v51 = (v50 == 10)
                                                        var v52: Boolean = false
                                                        v52 = (v51 != true)
                                                        if (v52) {
                                                            return 14
                                                        } else {
                                                            var v53: Int = 0
                                                            v53 = spiralStringIndex(v10, 5)
                                                            var v54: Boolean = false
                                                            v54 = (v53 == 10)
                                                            var v55: Boolean = false
                                                            v55 = (v54 != true)
                                                            if (v55) {
                                                                return 15
                                                            } else {
                                                                var v56: Boolean = false
                                                                v56 = (v0 == 16)
                                                                var v57: Boolean = false
                                                                v57 = (v56 != true)
                                                                if (v57) {
                                                                    return 16
                                                                } else {
                                                                    var v58: Int = 0
                                                                    v58 = spiralStringLength(v1)
                                                                    var v59: Boolean = false
                                                                    v59 = (v58 == 3)
                                                                    var v60: Boolean = false
                                                                    v60 = (v59 != true)
                                                                    if (v60) {
                                                                        return 17
                                                                    } else {
                                                                        var v61: Int = 0
                                                                        v61 = spiralStringLength(v2)
                                                                        var v62: Boolean = false
                                                                        v62 = (v61 == 8)
                                                                        var v63: Boolean = false
                                                                        v63 = (v62 != true)
                                                                        if (v63) {
                                                                            return 18
                                                                        } else {
                                                                            var v64: Int = 0
                                                                            v64 = spiralStringIndex(v2, 7)
                                                                            var v65: Boolean = false
                                                                            v65 = (v64 == 34)
                                                                            var v66: Boolean = false
                                                                            v66 = (v65 != true)
                                                                            if (v66) {
                                                                                return 19
                                                                            } else {
                                                                                var v67: Int = 0
                                                                                v67 = spiralStringLength(v3)
                                                                                var v68: Boolean = false
                                                                                v68 = (v67 == 7)
                                                                                var v69: Boolean = false
                                                                                v69 = (v68 != true)
                                                                                if (v69) {
                                                                                    return 20
                                                                                } else {
                                                                                    var v70: Int = 0
                                                                                    v70 = spiralStringIndex(v3, 4)
                                                                                    var v71: Boolean = false
                                                                                    v71 = (v70 == 34)
                                                                                    var v72: Boolean = false
                                                                                    v72 = (v71 != true)
                                                                                    if (v72) {
                                                                                        return 21
                                                                                    } else {
                                                                                        var v73: Int = 0
                                                                                        v73 = spiralStringLength(v4)
                                                                                        var v74: Boolean = false
                                                                                        v74 = (v73 == 23)
                                                                                        var v75: Boolean = false
                                                                                        v75 = (v74 != true)
                                                                                        if (v75) {
                                                                                            return 22
                                                                                        } else {
                                                                                            var v76: Int = 0
                                                                                            v76 = spiralStringIndex(v4, 6)
                                                                                            var v77: Boolean = false
                                                                                            v77 = (v76 == 32)
                                                                                            var v78: Boolean = false
                                                                                            v78 = (v77 != true)
                                                                                            if (v78) {
                                                                                                return 23
                                                                                            } else {
                                                                                                var v79: Int = 0
                                                                                                v79 = spiralStringIndex(v4, 10)
                                                                                                var v80: Boolean = false
                                                                                                v80 = (v79 == 115)
                                                                                                var v81: Boolean = false
                                                                                                v81 = (v80 != true)
                                                                                                if (v81) {
                                                                                                    return 24
                                                                                                } else {
                                                                                                    var v82: Int = 0
                                                                                                    v82 = spiralStringIndex(v4, 17)
                                                                                                    var v83: Boolean = false
                                                                                                    v83 = (v82 == 10)
                                                                                                    var v84: Boolean = false
                                                                                                    v84 = (v83 != true)
                                                                                                    if (v84) {
                                                                                                        return 25
                                                                                                    } else {
                                                                                                        var v85: Int = 0
                                                                                                        v85 = spiralStringIndex(v4, 22)
                                                                                                        var v86: Boolean = false
                                                                                                        v86 = (v85 == 100)
                                                                                                        var v87: Boolean = false
                                                                                                        v87 = (v86 != true)
                                                                                                        if (v87) {
                                                                                                            return 26
                                                                                                        } else {
                                                                                                            var v88: Int = 0
                                                                                                            v88 = spiralStringLength(v5)
                                                                                                            var v89: Boolean = false
                                                                                                            v89 = (v88 == 5)
                                                                                                            var v90: Boolean = false
                                                                                                            v90 = (v89 != true)
                                                                                                            if (v90) {
                                                                                                                return 27
                                                                                                            } else {
                                                                                                                var v91: Int = 0
                                                                                                                v91 = spiralStringIndex(v5, 3)
                                                                                                                var v92: Boolean = false
                                                                                                                v92 = (v91 == 99)
                                                                                                                var v93: Boolean = false
                                                                                                                v93 = (v92 != true)
                                                                                                                if (v93) {
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
