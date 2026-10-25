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
                                var v21: Int = 0
                                v21 = (v8 - 192)
                                var v22: Int = 0
                                v22 = (v21 * 64)
                                var v23: Int = 0
                                v23 = (v17 - 128)
                                var v24: Int = 0
                                v24 = (v22 + v23)
                                return v24
                            } else {
                                System.err.println("UTF-8 sequence has an invalid continuation byte.")
                                System.exit(1)
                                throw RuntimeException()
                            }
                        }
                    } else {
                        var v28: Boolean = false
                        v28 = (v8 < 240)
                        if (v28) {
                            var v29: Int = 0
                            v29 = (v1 + 2)
                            var v30: Boolean = false
                            v30 = (v29 >= v2)
                            if (v30) {
                                System.err.println("UTF-8 sequence is truncated.")
                                System.exit(1)
                                throw RuntimeException()
                            } else {
                                var v32: Int = 0
                                v32 = (v1 + 1)
                                var v33: Int = 0
                                v33 = sp_runtime_byte_2(v0, v32)
                                var v34: Int = 0
                                v34 = (v33 and 255)
                                var v35: Int = 0
                                v35 = sp_runtime_byte_2(v0, v29)
                                var v36: Int = 0
                                v36 = (v35 and 255)
                                var v37: Boolean = false
                                v37 = (v34 < 128)
                                var v39: Boolean = false
                                if (v37) {
                                    v39 = false
                                } else {
                                    var v38: Boolean = false
                                    v38 = (v34 < 192)
                                    v39 = v38
                                }
                                if (v39) {
                                    var v40: Boolean = false
                                    v40 = (v36 < 128)
                                    var v42: Boolean = false
                                    if (v40) {
                                        v42 = false
                                    } else {
                                        var v41: Boolean = false
                                        v41 = (v36 < 192)
                                        v42 = v41
                                    }
                                    if (v42) {
                                        var v43: Int = 0
                                        v43 = (v8 - 224)
                                        var v44: Int = 0
                                        v44 = (v43 * 4096)
                                        var v45: Int = 0
                                        v45 = (v34 - 128)
                                        var v46: Int = 0
                                        v46 = (v45 * 64)
                                        var v47: Int = 0
                                        v47 = (v44 + v46)
                                        var v48: Int = 0
                                        v48 = (v36 - 128)
                                        var v49: Int = 0
                                        v49 = (v47 + v48)
                                        var v50: Boolean = false
                                        v50 = (v49 < 2048)
                                        if (v50) {
                                            System.err.println("UTF-8 sequence is overlong.")
                                            System.exit(1)
                                            throw RuntimeException()
                                        } else {
                                            var v52: Boolean = false
                                            v52 = (v49 >= 55296)
                                            if (v52) {
                                                var v53: Boolean = false
                                                v53 = (v49 <= 57343)
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
                            var v63: Boolean = false
                            v63 = (v8 < 245)
                            if (v63) {
                                var v64: Int = 0
                                v64 = (v1 + 3)
                                var v65: Boolean = false
                                v65 = (v64 >= v2)
                                if (v65) {
                                    System.err.println("UTF-8 sequence is truncated.")
                                    System.exit(1)
                                    throw RuntimeException()
                                } else {
                                    var v67: Int = 0
                                    v67 = (v1 + 1)
                                    var v68: Int = 0
                                    v68 = sp_runtime_byte_2(v0, v67)
                                    var v69: Int = 0
                                    v69 = (v68 and 255)
                                    var v70: Int = 0
                                    v70 = (v1 + 2)
                                    var v71: Int = 0
                                    v71 = sp_runtime_byte_2(v0, v70)
                                    var v72: Int = 0
                                    v72 = (v71 and 255)
                                    var v73: Int = 0
                                    v73 = sp_runtime_byte_2(v0, v64)
                                    var v74: Int = 0
                                    v74 = (v73 and 255)
                                    var v75: Boolean = false
                                    v75 = (v69 < 128)
                                    var v77: Boolean = false
                                    if (v75) {
                                        v77 = false
                                    } else {
                                        var v76: Boolean = false
                                        v76 = (v69 < 192)
                                        v77 = v76
                                    }
                                    if (v77) {
                                        var v78: Boolean = false
                                        v78 = (v72 < 128)
                                        var v80: Boolean = false
                                        if (v78) {
                                            v80 = false
                                        } else {
                                            var v79: Boolean = false
                                            v79 = (v72 < 192)
                                            v80 = v79
                                        }
                                        if (v80) {
                                            var v81: Boolean = false
                                            v81 = (v74 < 128)
                                            var v83: Boolean = false
                                            if (v81) {
                                                v83 = false
                                            } else {
                                                var v82: Boolean = false
                                                v82 = (v74 < 192)
                                                v83 = v82
                                            }
                                            if (v83) {
                                                var v84: Int = 0
                                                v84 = (v8 - 240)
                                                var v85: Int = 0
                                                v85 = (v84 * 262144)
                                                var v86: Int = 0
                                                v86 = (v69 - 128)
                                                var v87: Int = 0
                                                v87 = (v86 * 4096)
                                                var v88: Int = 0
                                                v88 = (v85 + v87)
                                                var v89: Int = 0
                                                v89 = (v72 - 128)
                                                var v90: Int = 0
                                                v90 = (v89 * 64)
                                                var v91: Int = 0
                                                v91 = (v88 + v90)
                                                var v92: Int = 0
                                                v92 = (v74 - 128)
                                                var v93: Int = 0
                                                v93 = (v91 + v92)
                                                var v94: Boolean = false
                                                v94 = (v93 < 65536)
                                                if (v94) {
                                                    System.err.println("UTF-8 sequence is overlong.")
                                                    System.exit(1)
                                                    throw RuntimeException()
                                                } else {
                                                    var v96: Boolean = false
                                                    v96 = (v93 > 1114111)
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
                val t1718_15: Int = v15
                val t1759_16: Int = v16
                val t1800_19: Int = v19
                v0 = t1718_15
                v1 = t1759_16
                v2 = t1800_19
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
                val t1710_15: Int = v15
                val t1751_16: Int = v16
                val t1792_19: Int = v19
                v0 = t1710_15
                v1 = t1751_16
                v2 = t1792_19
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
    var v6: Int = 0
    v6 = 0
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
