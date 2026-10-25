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
                                v33 = sp_runtime_byte_1(v0, v32)
                                var v34: Int = 0
                                v34 = (v33 and 255)
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
                                    v68 = sp_runtime_byte_1(v0, v67)
                                    var v69: Int = 0
                                    v69 = (v68 and 255)
                                    var v70: Int = 0
                                    v70 = (v1 + 2)
                                    var v71: Int = 0
                                    v71 = sp_runtime_byte_1(v0, v70)
                                    var v72: Int = 0
                                    v72 = (v71 and 255)
                                    var v73: Int = 0
                                    v73 = sp_runtime_byte_1(v0, v64)
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
                                                            var v25: Boolean = false
                                                            v25 = (v7 <= 65071)
                                                            if (v25) {
                                                                v44 = true
                                                            } else {
                                                                var v26: Boolean = false
                                                                v26 = (v7 >= 127995)
                                                                if (v26) {
                                                                    var v27: Boolean = false
                                                                    v27 = (v7 <= 127999)
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
                val t7474_0: String = v0
                val t7516_49: Int = v49
                val t7557_48: Int = v48
                val t7598_3: Int = v3
                v0 = t7474_0
                v1 = t7516_49
                v2 = t7557_48
                v3 = t7598_3
                continue
            }
        }
    }
    return 0
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "éZ"
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
                var v6: Boolean = false
                v6 = (v2 <= 6911)
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
                                    var v11: Boolean = false
                                    v11 = (v2 >= 65024)
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
