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
class SpiralTuple0(val v0: Int, val v1: Int)
fun sp_runtime_byte_2(p0: String, p1: Int): Int {
    var v0: String = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = spiralStringIndex(v0, v1)
    return v2
}
fun sp_utf8_scalar_at_byte_offset_1(p0: String, p1: Int): Int {
    var v0: String = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = spiralStringLength(v0)
    var v3: Boolean = false
    v3 = (v1 < 0)
    if (v3) {
        System.err.println("UTF-8 byte offset is negative.")
        System.exit(1)
        throw RuntimeException()
    } else {
        var v5: Boolean = false
        v5 = (v1 >= v2)
        if (v5) {
            System.err.println("UTF-8 byte offset is outside the string.")
            System.exit(1)
            throw RuntimeException()
        } else {
            var v7: Int = 0
            v7 = sp_runtime_byte_2(v0, v1)
            var v8: Int = 0
            v8 = (v7 and 255)
            var v9: Boolean = false
            v9 = (v8 < 128)
            if (v9) {
                return v8
            } else {
                var v10: Boolean = false
                v10 = (v8 < 194)
                if (v10) {
                    System.err.println("UTF-8 scalar starts with an invalid lead byte.")
                    System.exit(1)
                    throw RuntimeException()
                } else {
                    var v12: Boolean = false
                    v12 = (v8 < 224)
                    if (v12) {
                        var v13: Int = 0
                        v13 = (v1 + 1)
                        var v14: Boolean = false
                        v14 = (v13 >= v2)
                        if (v14) {
                            System.err.println("UTF-8 sequence is truncated.")
                            System.exit(1)
                            throw RuntimeException()
                        } else {
                            var v16: Int = 0
                            v16 = sp_runtime_byte_2(v0, v13)
                            var v17: Int = 0
                            v17 = (v16 and 255)
                            var v18: Boolean = false
                            v18 = (v17 < 128)
                            var v20: Boolean = false
                            if (v18) {
                                v20 = false
                            } else {
                                var v19: Boolean = false
                                v19 = (v17 < 192)
                                v20 = v19
                            }
                            if (v20) {
                                val v21: Int = (v8 - 192)
                                val v22: Int = (v21 * 64)
                                val v23: Int = (v17 - 128)
                                val v24: Int = (v22 + v23)
                                return v24
                            } else {
                                System.err.println("UTF-8 sequence has an invalid continuation byte.")
                                System.exit(1)
                                throw RuntimeException()
                            }
                        }
                    } else {
                        val v28: Boolean = (v8 < 240)
                        if (v28) {
                            val v29: Int = (v1 + 2)
                            val v30: Boolean = (v29 >= v2)
                            if (v30) {
                                System.err.println("UTF-8 sequence is truncated.")
                                System.exit(1)
                                throw RuntimeException()
                            } else {
                                val v32: Int = (v1 + 1)
                                val v33: Int = sp_runtime_byte_2(v0, v32)
                                val v34: Int = (v33 and 255)
                                val v35: Int = sp_runtime_byte_2(v0, v29)
                                val v36: Int = (v35 and 255)
                                val v37: Boolean = (v34 < 128)
                                var v39: Boolean = false
                                if (v37) {
                                    v39 = false
                                } else {
                                    val v38: Boolean = (v34 < 192)
                                    v39 = v38
                                }
                                if (v39) {
                                    val v40: Boolean = (v36 < 128)
                                    var v42: Boolean = false
                                    if (v40) {
                                        v42 = false
                                    } else {
                                        val v41: Boolean = (v36 < 192)
                                        v42 = v41
                                    }
                                    if (v42) {
                                        val v43: Int = (v8 - 224)
                                        val v44: Int = (v43 * 4096)
                                        val v45: Int = (v34 - 128)
                                        val v46: Int = (v45 * 64)
                                        val v47: Int = (v44 + v46)
                                        val v48: Int = (v36 - 128)
                                        val v49: Int = (v47 + v48)
                                        val v50: Boolean = (v49 < 2048)
                                        if (v50) {
                                            System.err.println("UTF-8 sequence is overlong.")
                                            System.exit(1)
                                            throw RuntimeException()
                                        } else {
                                            val v52: Boolean = (v49 >= 55296)
                                            if (v52) {
                                                val v53: Boolean = (v49 <= 57343)
                                                if (v53) {
                                                    System.err.println("UTF-8 sequence encodes a surrogate.")
                                                    System.exit(1)
                                                    throw RuntimeException()
                                                } else {
                                                    return v49
                                                }
                                            } else {
                                                return v49
                                            }
                                        }
                                    } else {
                                        System.err.println("UTF-8 sequence has an invalid continuation byte.")
                                        System.exit(1)
                                        throw RuntimeException()
                                    }
                                } else {
                                    System.err.println("UTF-8 sequence has an invalid continuation byte.")
                                    System.exit(1)
                                    throw RuntimeException()
                                }
                            }
                        } else {
                            val v63: Boolean = (v8 < 245)
                            if (v63) {
                                val v64: Int = (v1 + 3)
                                val v65: Boolean = (v64 >= v2)
                                if (v65) {
                                    System.err.println("UTF-8 sequence is truncated.")
                                    System.exit(1)
                                    throw RuntimeException()
                                } else {
                                    val v67: Int = (v1 + 1)
                                    val v68: Int = sp_runtime_byte_2(v0, v67)
                                    val v69: Int = (v68 and 255)
                                    val v70: Int = (v1 + 2)
                                    val v71: Int = sp_runtime_byte_2(v0, v70)
                                    val v72: Int = (v71 and 255)
                                    val v73: Int = sp_runtime_byte_2(v0, v64)
                                    val v74: Int = (v73 and 255)
                                    val v75: Boolean = (v69 < 128)
                                    var v77: Boolean = false
                                    if (v75) {
                                        v77 = false
                                    } else {
                                        val v76: Boolean = (v69 < 192)
                                        v77 = v76
                                    }
                                    if (v77) {
                                        val v78: Boolean = (v72 < 128)
                                        var v80: Boolean = false
                                        if (v78) {
                                            v80 = false
                                        } else {
                                            val v79: Boolean = (v72 < 192)
                                            v80 = v79
                                        }
                                        if (v80) {
                                            val v81: Boolean = (v74 < 128)
                                            var v83: Boolean = false
                                            if (v81) {
                                                v83 = false
                                            } else {
                                                val v82: Boolean = (v74 < 192)
                                                v83 = v82
                                            }
                                            if (v83) {
                                                val v84: Int = (v8 - 240)
                                                val v85: Int = (v84 * 262144)
                                                val v86: Int = (v69 - 128)
                                                val v87: Int = (v86 * 4096)
                                                val v88: Int = (v85 + v87)
                                                val v89: Int = (v72 - 128)
                                                val v90: Int = (v89 * 64)
                                                val v91: Int = (v88 + v90)
                                                val v92: Int = (v74 - 128)
                                                val v93: Int = (v91 + v92)
                                                val v94: Boolean = (v93 < 65536)
                                                if (v94) {
                                                    System.err.println("UTF-8 sequence is overlong.")
                                                    System.exit(1)
                                                    throw RuntimeException()
                                                } else {
                                                    val v96: Boolean = (v93 > 1114111)
                                                    if (v96) {
                                                        System.err.println("UTF-8 scalar is above U+10FFFF.")
                                                        System.exit(1)
                                                        throw RuntimeException()
                                                    } else {
                                                        return v93
                                                    }
                                                }
                                            } else {
                                                System.err.println("UTF-8 sequence has an invalid continuation byte.")
                                                System.exit(1)
                                                throw RuntimeException()
                                            }
                                        } else {
                                            System.err.println("UTF-8 sequence has an invalid continuation byte.")
                                            System.exit(1)
                                            throw RuntimeException()
                                        }
                                    } else {
                                        System.err.println("UTF-8 sequence has an invalid continuation byte.")
                                        System.exit(1)
                                        throw RuntimeException()
                                    }
                                }
                            } else {
                                System.err.println("UTF-8 scalar starts with an invalid lead byte.")
                                System.exit(1)
                                throw RuntimeException()
                            }
                        }
                    }
                }
            }
        }
    }
}
fun sp_loop_0(p0: Int, p1: Int, p2: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    while (true) {
        var v3: Boolean = false
        v3 = (v0 == 10)
        if (v3) {
            return SpiralTuple0(v1, v2)
        } else {
            var v4: Boolean = false
            v4 = (v0 > 10)
            if (v4) {
                System.err.println("UTF-8 scalar width exceeds the string.")
                System.exit(1)
                throw RuntimeException()
            } else {
                var v7: String = ""
                v7 = "Aéλ🙂Z"
                var v8: Int = 0
                v8 = sp_utf8_scalar_at_byte_offset_1(v7, v0)
                var v9: Boolean = false
                v9 = (v8 < 128)
                var v14: Int = 0
                if (v9) {
                    v14 = 1
                } else {
                    var v10: Boolean = false
                    v10 = (v8 < 2048)
                    if (v10) {
                        v14 = 2
                    } else {
                        var v11: Boolean = false
                        v11 = (v8 < 65536)
                        if (v11) {
                            v14 = 3
                        } else {
                            v14 = 4
                        }
                    }
                }
                var v15: Int = 0
                v15 = (v0 + v14)
                var v16: Int = 0
                v16 = (v1 + 1)
                var v17: Int = 0
                v17 = (v2 * 3)
                var v18: Int = 0
                v18 = (v8 % 17)
                var v19: Int = 0
                v19 = (v17 + v18)
                v0 = v15
                v1 = v16
                v2 = v19
                continue
            }
        }
    }
    return SpiralTuple0(0, 0)
}
fun sp_loop_3(p0: Int, p1: Int, p2: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    while (true) {
        var v3: Boolean = false
        v3 = (v0 == 0)
        if (v3) {
            return SpiralTuple0(v1, v2)
        } else {
            var v4: Boolean = false
            v4 = (v0 > 0)
            if (v4) {
                System.err.println("UTF-8 scalar width exceeds the string.")
                System.exit(1)
                throw RuntimeException()
            } else {
                var v7: String = ""
                v7 = ""
                var v8: Int = 0
                v8 = sp_utf8_scalar_at_byte_offset_1(v7, v0)
                var v9: Boolean = false
                v9 = (v8 < 128)
                var v14: Int = 0
                if (v9) {
                    v14 = 1
                } else {
                    var v10: Boolean = false
                    v10 = (v8 < 2048)
                    if (v10) {
                        v14 = 2
                    } else {
                        var v11: Boolean = false
                        v11 = (v8 < 65536)
                        if (v11) {
                            v14 = 3
                        } else {
                            v14 = 4
                        }
                    }
                }
                var v15: Int = 0
                v15 = (v0 + v14)
                var v16: Int = 0
                v16 = (v1 + 1)
                var v17: Int = 0
                v17 = (v2 * 3)
                var v18: Int = 0
                v18 = (v8 % 17)
                var v19: Int = 0
                v19 = (v17 + v18)
                v0 = v15
                v1 = v16
                v2 = v19
                continue
            }
        }
    }
    return SpiralTuple0(0, 0)
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 0
    var v1: Int = 0
    v1 = 0
    var v2: Int = 0
    v2 = 0
    var v3: Int = 0
    var v4: Int = 0
    val spiral_tuple167 = sp_loop_0(v0, v1, v2)
    v3 = spiral_tuple167.v0
    v4 = spiral_tuple167.v1
    var v5: Int = 0
    v5 = 0
    val v6: Int = 0
    var v7: Int = 0
    v7 = 0
    var v8: Int = 0
    var v9: Int = 0
    val spiral_tuple415 = sp_loop_3(v5, v6, v7)
    v8 = spiral_tuple415.v0
    v9 = spiral_tuple415.v1
    var v10: Int = 0
    v10 = 5
    var v11: Int = 0
    v11 = 0
    var v12: Int = 0
    v12 = 0
    var v13: Int = 0
    var v14: Int = 0
    val spiral_tuple671 = sp_loop_0(v10, v11, v12)
    v13 = spiral_tuple671.v0
    v14 = spiral_tuple671.v1
    var v15: Boolean = false
    v15 = (v3 == 5)
    if (v15) {
        var v16: Boolean = false
        v16 = (v4 == 1511)
        if (v16) {
            var v17: Boolean = false
            v17 = (v8 == 0)
            if (v17) {
                var v18: Boolean = false
                v18 = (v9 == 0)
                if (v18) {
                    var v19: Boolean = false
                    v19 = (v13 == 2)
                    if (v19) {
                        var v20: Boolean = false
                        v20 = (v14 == 26)
                        if (v20) {
                            return 0
                        } else {
                            return 6
                        }
                    } else {
                        return 5
                    }
                } else {
                    return 4
                }
            } else {
                return 3
            }
        } else {
            return 2
        }
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
