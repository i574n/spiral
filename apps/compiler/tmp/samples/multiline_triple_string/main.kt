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
    val v0: Int = 16
    val v1: String = "x\ny"
    val v2: String = "say \"hi\""
    val v3: String = "a \"\"\" b"
    val v4: String = "first\n    second\n\nthird"
    val v5: String = "ab\ncd"
    val v6: String = "a \"b\" c"
    val v7: String = ""
    val v8: String = "a\\nb"
    val v9: String = "first\n(* not a comment *)\n// nor this\n\n\$\"not a macro\" !x\ninl fake () = 1\n  indented"
    val v10: String = "\ntop\n\nlevel"
    val v11: Int = spiralStringLength(v6)
    val v12: Boolean = (v11 != 7)
    if (v12) {
        return 1
    } else {
        val v13: Int = spiralStringIndex(v6, 2)
        val v14: Boolean = (v13 != 34)
        if (v14) {
            return 2
        } else {
            val v15: Int = spiralStringLength(v7)
            val v16: Boolean = (v15 != 0)
            if (v16) {
                return 3
            } else {
                val v17: Int = spiralStringLength(v8)
                val v18: Boolean = (v17 != 4)
                if (v18) {
                    return 4
                } else {
                    val v19: Int = spiralStringIndex(v8, 1)
                    val v20: Boolean = (v19 != 92)
                    if (v20) {
                        return 5
                    } else {
                        val v21: Int = spiralStringLength(v9)
                        val v22: Boolean = (v21 != 83)
                        if (v22) {
                            return 6
                        } else {
                            val v23: Int = spiralStringIndex(v9, 5)
                            val v24: Boolean = (v23 != 10)
                            if (v24) {
                                return 7
                            } else {
                                val v25: Int = spiralStringIndex(v9, 37)
                                val v26: Boolean = (v25 != 10)
                                if (v26) {
                                    return 8
                                } else {
                                    val v27: Int = spiralStringIndex(v9, 38)
                                    val v28: Boolean = (v27 != 10)
                                    if (v28) {
                                        return 9
                                    } else {
                                        val v29: Int = spiralStringIndex(v9, 39)
                                        val v30: Boolean = (v29 != 36)
                                        if (v30) {
                                            return 10
                                        } else {
                                            val v31: Int = spiralStringIndex(v9, 57)
                                            val v32: Boolean = (v31 != 105)
                                            if (v32) {
                                                return 11
                                            } else {
                                                val v33: Int = spiralStringIndex(v9, 82)
                                                val v34: Boolean = (v33 != 100)
                                                if (v34) {
                                                    return 12
                                                } else {
                                                    val v35: Int = spiralStringLength(v10)
                                                    val v36: Boolean = (v35 != 11)
                                                    if (v36) {
                                                        return 13
                                                    } else {
                                                        val v37: Int = spiralStringIndex(v10, 0)
                                                        val v38: Boolean = (v37 != 10)
                                                        if (v38) {
                                                            return 14
                                                        } else {
                                                            val v39: Int = spiralStringIndex(v10, 5)
                                                            val v40: Boolean = (v39 != 10)
                                                            if (v40) {
                                                                return 15
                                                            } else {
                                                                val v41: Boolean = (v0 != 16)
                                                                if (v41) {
                                                                    return 16
                                                                } else {
                                                                    val v42: Int = spiralStringLength(v1)
                                                                    val v43: Boolean = (v42 != 3)
                                                                    if (v43) {
                                                                        return 17
                                                                    } else {
                                                                        val v44: Int = spiralStringLength(v2)
                                                                        val v45: Boolean = (v44 != 8)
                                                                        if (v45) {
                                                                            return 18
                                                                        } else {
                                                                            val v46: Int = spiralStringIndex(v2, 7)
                                                                            val v47: Boolean = (v46 != 34)
                                                                            if (v47) {
                                                                                return 19
                                                                            } else {
                                                                                val v48: Int = spiralStringLength(v3)
                                                                                val v49: Boolean = (v48 != 7)
                                                                                if (v49) {
                                                                                    return 20
                                                                                } else {
                                                                                    val v50: Int = spiralStringIndex(v3, 4)
                                                                                    val v51: Boolean = (v50 != 34)
                                                                                    if (v51) {
                                                                                        return 21
                                                                                    } else {
                                                                                        val v52: Int = spiralStringLength(v4)
                                                                                        val v53: Boolean = (v52 != 23)
                                                                                        if (v53) {
                                                                                            return 22
                                                                                        } else {
                                                                                            val v54: Int = spiralStringIndex(v4, 6)
                                                                                            val v55: Boolean = (v54 != 32)
                                                                                            if (v55) {
                                                                                                return 23
                                                                                            } else {
                                                                                                val v56: Int = spiralStringIndex(v4, 10)
                                                                                                val v57: Boolean = (v56 != 115)
                                                                                                if (v57) {
                                                                                                    return 24
                                                                                                } else {
                                                                                                    val v58: Int = spiralStringIndex(v4, 17)
                                                                                                    val v59: Boolean = (v58 != 10)
                                                                                                    if (v59) {
                                                                                                        return 25
                                                                                                    } else {
                                                                                                        val v60: Int = spiralStringIndex(v4, 22)
                                                                                                        val v61: Boolean = (v60 != 100)
                                                                                                        if (v61) {
                                                                                                            return 26
                                                                                                        } else {
                                                                                                            val v62: Int = spiralStringLength(v5)
                                                                                                            val v63: Boolean = (v62 != 5)
                                                                                                            if (v63) {
                                                                                                                return 27
                                                                                                            } else {
                                                                                                                val v64: Int = spiralStringIndex(v5, 3)
                                                                                                                val v65: Boolean = (v64 != 99)
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
