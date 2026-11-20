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
fun sp_runtime_byte_1(p0: String, p1: Int): Int {
    var v0: String = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = spiralStringIndex(v0, v1)
    return v2
}
fun sp_utf8_scalar_at_byte_offset_0(p0: String, p1: Int): Int {
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
            v7 = sp_runtime_byte_1(v0, v1)
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
                            v16 = sp_runtime_byte_1(v0, v13)
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
                            val v30: Boolean = (v29 >= v2)
                            if (v30) {
                                System.err.println("UTF-8 sequence is truncated.")
                                System.exit(1)
                                throw RuntimeException()
                            } else {
                                val v32: Int = (v1 + 1)
                                var v33: Int = 0
                                v33 = sp_runtime_byte_1(v0, v32)
                                val v34: Int = (v33 and 255)
                                var v35: Int = 0
                                v35 = sp_runtime_byte_1(v0, v29)
                                var v36: Int = 0
                                v36 = (v35 and 255)
                                var v37: Boolean = false
                                v37 = (v34 < 128)
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
                                        var v44: Int = 0
                                        v44 = (v43 * 4096)
                                        var v45: Int = 0
                                        v45 = (v34 - 128)
                                        val v46: Int = (v45 * 64)
                                        var v47: Int = 0
                                        v47 = (v44 + v46)
                                        var v48: Int = 0
                                        v48 = (v36 - 128)
                                        var v49: Int = 0
                                        v49 = (v47 + v48)
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
                                    val v68: Int = sp_runtime_byte_1(v0, v67)
                                    val v69: Int = (v68 and 255)
                                    val v70: Int = (v1 + 2)
                                    val v71: Int = sp_runtime_byte_1(v0, v70)
                                    val v72: Int = (v71 and 255)
                                    val v73: Int = sp_runtime_byte_1(v0, v64)
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
fun sp_utf8_grapheme_count_bounded_loop_2(p0: String, p1: Int, p2: Int, p3: Int): Int {
    var v0: String = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = p3
    while (true) {
        var v4: Boolean = false
        v4 = (v1 == v3)
        if (v4) {
            return v2
        } else {
            var v5: Boolean = false
            v5 = (v1 > v3)
            if (v5) {
                System.err.println("UTF-8 scalar width exceeds the string.")
                System.exit(1)
                throw RuntimeException()
            } else {
                var v7: Int = 0
                v7 = sp_utf8_scalar_at_byte_offset_0(v0, v1)
                var v8: Boolean = false
                v8 = (v7 < 128)
                var v13: Int = 0
                if (v8) {
                    v13 = 1
                } else {
                    var v9: Boolean = false
                    v9 = (v7 < 2048)
                    if (v9) {
                        v13 = 2
                    } else {
                        var v10: Boolean = false
                        v10 = (v7 < 65536)
                        if (v10) {
                            v13 = 3
                        } else {
                            v13 = 4
                        }
                    }
                }
                var v14: Boolean = false
                v14 = (v7 >= 768)
                var v44: Boolean = false
                if (v14) {
                    var v15: Boolean = false
                    v15 = (v7 <= 879)
                    if (v15) {
                        v44 = true
                    } else {
                        var v16: Boolean = false
                        v16 = (v7 >= 6832)
                        if (v16) {
                            var v17: Boolean = false
                            v17 = (v7 <= 6911)
                            if (v17) {
                                v44 = true
                            } else {
                                var v18: Boolean = false
                                v18 = (v7 >= 7616)
                                if (v18) {
                                    var v19: Boolean = false
                                    v19 = (v7 <= 7679)
                                    if (v19) {
                                        v44 = true
                                    } else {
                                        var v20: Boolean = false
                                        v20 = (v7 >= 8400)
                                        if (v20) {
                                            var v21: Boolean = false
                                            v21 = (v7 <= 8447)
                                            if (v21) {
                                                v44 = true
                                            } else {
                                                var v22: Boolean = false
                                                v22 = (v7 >= 65024)
                                                if (v22) {
                                                    var v23: Boolean = false
                                                    v23 = (v7 <= 65039)
                                                    if (v23) {
                                                        v44 = true
                                                    } else {
                                                        var v24: Boolean = false
                                                        v24 = (v7 >= 65056)
                                                        if (v24) {
                                                            val v25: Boolean = (v7 <= 65071)
                                                            if (v25) {
                                                                v44 = true
                                                            } else {
                                                                val v26: Boolean = (v7 >= 127995)
                                                                if (v26) {
                                                                    val v27: Boolean = (v7 <= 127999)
                                                                    if (v27) {
                                                                        v44 = true
                                                                    } else {
                                                                        var v28: Boolean = false
                                                                        v28 = (v7 >= 917760)
                                                                        if (v28) {
                                                                            var v29: Boolean = false
                                                                            v29 = (v7 <= 917999)
                                                                            v44 = v29
                                                                        } else {
                                                                            v44 = false
                                                                        }
                                                                    }
                                                                } else {
                                                                    v44 = false
                                                                }
                                                            }
                                                        } else {
                                                            v44 = false
                                                        }
                                                    }
                                                } else {
                                                    v44 = false
                                                }
                                            }
                                        } else {
                                            v44 = false
                                        }
                                    }
                                } else {
                                    v44 = false
                                }
                            }
                        } else {
                            v44 = false
                        }
                    }
                } else {
                    v44 = false
                }
                var v48: Int = 0
                if (v44) {
                    var v45: Boolean = false
                    v45 = (v2 == 0)
                    if (v45) {
                        v48 = 1
                    } else {
                        v48 = v2
                    }
                } else {
                    var v47: Int = 0
                    v47 = (v2 + 1)
                    v48 = v47
                }
                var v49: Int = 0
                v49 = (v1 + v13)
                v1 = v49
                v2 = v48
                continue
            }
        }
    }
    return 0
}
fun spiral_main(): Int {
    val v0: String = "éZ"
    var v1: Int = 0
    v1 = 1
    var v2: Int = 0
    v2 = sp_utf8_scalar_at_byte_offset_0(v0, v1)
    var v3: Boolean = false
    v3 = (v2 >= 768)
    var v33: Boolean = false
    if (v3) {
        var v4: Boolean = false
        v4 = (v2 <= 879)
        if (v4) {
            v33 = true
        } else {
            var v5: Boolean = false
            v5 = (v2 >= 6832)
            if (v5) {
                val v6: Boolean = (v2 <= 6911)
                if (v6) {
                    v33 = true
                } else {
                    var v7: Boolean = false
                    v7 = (v2 >= 7616)
                    if (v7) {
                        var v8: Boolean = false
                        v8 = (v2 <= 7679)
                        if (v8) {
                            v33 = true
                        } else {
                            var v9: Boolean = false
                            v9 = (v2 >= 8400)
                            if (v9) {
                                var v10: Boolean = false
                                v10 = (v2 <= 8447)
                                if (v10) {
                                    v33 = true
                                } else {
                                    val v11: Boolean = (v2 >= 65024)
                                    if (v11) {
                                        var v12: Boolean = false
                                        v12 = (v2 <= 65039)
                                        if (v12) {
                                            v33 = true
                                        } else {
                                            var v13: Boolean = false
                                            v13 = (v2 >= 65056)
                                            if (v13) {
                                                var v14: Boolean = false
                                                v14 = (v2 <= 65071)
                                                if (v14) {
                                                    v33 = true
                                                } else {
                                                    var v15: Boolean = false
                                                    v15 = (v2 >= 127995)
                                                    if (v15) {
                                                        var v16: Boolean = false
                                                        v16 = (v2 <= 127999)
                                                        if (v16) {
                                                            v33 = true
                                                        } else {
                                                            var v17: Boolean = false
                                                            v17 = (v2 >= 917760)
                                                            if (v17) {
                                                                var v18: Boolean = false
                                                                v18 = (v2 <= 917999)
                                                                v33 = v18
                                                            } else {
                                                                v33 = false
                                                            }
                                                        }
                                                    } else {
                                                        v33 = false
                                                    }
                                                }
                                            } else {
                                                v33 = false
                                            }
                                        }
                                    } else {
                                        v33 = false
                                    }
                                }
                            } else {
                                v33 = false
                            }
                        }
                    } else {
                        v33 = false
                    }
                }
            } else {
                v33 = false
            }
        }
    } else {
        v33 = false
    }
    if (v33) {
        System.err.println("UTF-8 grapheme byte offset is inside a bounded grapheme cluster.")
        System.exit(1)
        throw RuntimeException()
    } else {
        var v35: Int = 0
        v35 = 1
        var v36: Int = 0
        v36 = 0
        var v37: Int = 0
        v37 = 4
        return sp_utf8_grapheme_count_bounded_loop_2(v0, v35, v36, v37)
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
