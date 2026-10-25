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
fun sp_utf8_canonical_equal_bounded_loop_0(p0: String, p1: String, p2: Int, p3: Int, p4: Int, p5: Int, p6: Int, p7: Int): Boolean {
    var v0: String = p0
    var v1: String = p1
    var v2: Int = p2
    var v3: Int = p3
    var v4: Int = p4
    var v5: Int = p5
    var v6: Int = p6
    var v7: Int = p7
    while (true) {
        var v8: Boolean = false
        v8 = (v4 >= 0)
        var v76: Int = 0
        var v77: Int = 0
        var v78: Int = 0
        if (v8) {
            v76 = v4
            v77 = v2
            v78 = -1
        } else {
            var v9: Boolean = false
            v9 = (v2 == v6)
            if (v9) {
                v76 = -1
                v77 = v2
                v78 = -1
            } else {
                var v10: Boolean = false
                v10 = (v2 > v6)
                if (v10) {
                    System.err.println("UTF-8 canonical stream offset exceeds the string.")
                    System.exit(1)
                    throw RuntimeException()
                } else {
                    var v14: Int = 0
                    v14 = sp_utf8_scalar_at_byte_offset_1(v0, v2)
                    var v15: Boolean = false
                    v15 = (v14 < 128)
                    var v20: Int = 0
                    if (v15) {
                        v20 = 1
                    } else {
                        var v16: Boolean = false
                        v16 = (v14 < 2048)
                        if (v16) {
                            v20 = 2
                        } else {
                            var v17: Boolean = false
                            v17 = (v14 < 65536)
                            if (v17) {
                                v20 = 3
                            } else {
                                v20 = 4
                            }
                        }
                    }
                    var v21: Boolean = false
                    v21 = (v14 == 192)
                    var v67: Int = 0
                    var v68: Int = 0
                    if (v21) {
                        v67 = 65
                        v68 = 768
                    } else {
                        var v22: Boolean = false
                        v22 = (v14 == 193)
                        if (v22) {
                            v67 = 65
                            v68 = 769
                        } else {
                            var v23: Boolean = false
                            v23 = (v14 == 195)
                            if (v23) {
                                v67 = 65
                                v68 = 771
                            } else {
                                var v24: Boolean = false
                                v24 = (v14 == 196)
                                if (v24) {
                                    v67 = 65
                                    v68 = 776
                                } else {
                                    var v25: Boolean = false
                                    v25 = (v14 == 199)
                                    if (v25) {
                                        v67 = 67
                                        v68 = 807
                                    } else {
                                        var v26: Boolean = false
                                        v26 = (v14 == 201)
                                        if (v26) {
                                            v67 = 69
                                            v68 = 769
                                        } else {
                                            var v27: Boolean = false
                                            v27 = (v14 == 211)
                                            if (v27) {
                                                v67 = 79
                                                v68 = 769
                                            } else {
                                                var v28: Boolean = false
                                                v28 = (v14 == 213)
                                                if (v28) {
                                                    v67 = 79
                                                    v68 = 771
                                                } else {
                                                    var v29: Boolean = false
                                                    v29 = (v14 == 224)
                                                    if (v29) {
                                                        v67 = 97
                                                        v68 = 768
                                                    } else {
                                                        var v30: Boolean = false
                                                        v30 = (v14 == 225)
                                                        if (v30) {
                                                            v67 = 97
                                                            v68 = 769
                                                        } else {
                                                            var v31: Boolean = false
                                                            v31 = (v14 == 227)
                                                            if (v31) {
                                                                v67 = 97
                                                                v68 = 771
                                                            } else {
                                                                var v32: Boolean = false
                                                                v32 = (v14 == 228)
                                                                if (v32) {
                                                                    v67 = 97
                                                                    v68 = 776
                                                                } else {
                                                                    var v33: Boolean = false
                                                                    v33 = (v14 == 231)
                                                                    if (v33) {
                                                                        v67 = 99
                                                                        v68 = 807
                                                                    } else {
                                                                        var v34: Boolean = false
                                                                        v34 = (v14 == 233)
                                                                        if (v34) {
                                                                            v67 = 101
                                                                            v68 = 769
                                                                        } else {
                                                                            var v35: Boolean = false
                                                                            v35 = (v14 == 243)
                                                                            if (v35) {
                                                                                v67 = 111
                                                                                v68 = 769
                                                                            } else {
                                                                                var v36: Boolean = false
                                                                                v36 = (v14 == 245)
                                                                                if (v36) {
                                                                                    v67 = 111
                                                                                    v68 = 771
                                                                                } else {
                                                                                    v67 = v14
                                                                                    v68 = -1
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
                    var v69: Int = 0
                    v69 = (v2 + v20)
                    v76 = v67
                    v77 = v69
                    v78 = v68
                }
            }
        }
        var v79: Boolean = false
        v79 = (v5 >= 0)
        var v147: Int = 0
        var v148: Int = 0
        var v149: Int = 0
        if (v79) {
            v147 = v5
            v148 = v3
            v149 = -1
        } else {
            var v80: Boolean = false
            v80 = (v3 == v7)
            if (v80) {
                v147 = -1
                v148 = v3
                v149 = -1
            } else {
                var v81: Boolean = false
                v81 = (v3 > v7)
                if (v81) {
                    System.err.println("UTF-8 canonical stream offset exceeds the string.")
                    System.exit(1)
                    throw RuntimeException()
                } else {
                    var v85: Int = 0
                    v85 = sp_utf8_scalar_at_byte_offset_1(v1, v3)
                    var v86: Boolean = false
                    v86 = (v85 < 128)
                    var v91: Int = 0
                    if (v86) {
                        v91 = 1
                    } else {
                        var v87: Boolean = false
                        v87 = (v85 < 2048)
                        if (v87) {
                            v91 = 2
                        } else {
                            var v88: Boolean = false
                            v88 = (v85 < 65536)
                            if (v88) {
                                v91 = 3
                            } else {
                                v91 = 4
                            }
                        }
                    }
                    var v92: Boolean = false
                    v92 = (v85 == 192)
                    var v138: Int = 0
                    var v139: Int = 0
                    if (v92) {
                        v138 = 65
                        v139 = 768
                    } else {
                        var v93: Boolean = false
                        v93 = (v85 == 193)
                        if (v93) {
                            v138 = 65
                            v139 = 769
                        } else {
                            var v94: Boolean = false
                            v94 = (v85 == 195)
                            if (v94) {
                                v138 = 65
                                v139 = 771
                            } else {
                                var v95: Boolean = false
                                v95 = (v85 == 196)
                                if (v95) {
                                    v138 = 65
                                    v139 = 776
                                } else {
                                    var v96: Boolean = false
                                    v96 = (v85 == 199)
                                    if (v96) {
                                        v138 = 67
                                        v139 = 807
                                    } else {
                                        var v97: Boolean = false
                                        v97 = (v85 == 201)
                                        if (v97) {
                                            v138 = 69
                                            v139 = 769
                                        } else {
                                            var v98: Boolean = false
                                            v98 = (v85 == 211)
                                            if (v98) {
                                                v138 = 79
                                                v139 = 769
                                            } else {
                                                var v99: Boolean = false
                                                v99 = (v85 == 213)
                                                if (v99) {
                                                    v138 = 79
                                                    v139 = 771
                                                } else {
                                                    var v100: Boolean = false
                                                    v100 = (v85 == 224)
                                                    if (v100) {
                                                        v138 = 97
                                                        v139 = 768
                                                    } else {
                                                        var v101: Boolean = false
                                                        v101 = (v85 == 225)
                                                        if (v101) {
                                                            v138 = 97
                                                            v139 = 769
                                                        } else {
                                                            var v102: Boolean = false
                                                            v102 = (v85 == 227)
                                                            if (v102) {
                                                                v138 = 97
                                                                v139 = 771
                                                            } else {
                                                                var v103: Boolean = false
                                                                v103 = (v85 == 228)
                                                                if (v103) {
                                                                    v138 = 97
                                                                    v139 = 776
                                                                } else {
                                                                    var v104: Boolean = false
                                                                    v104 = (v85 == 231)
                                                                    if (v104) {
                                                                        v138 = 99
                                                                        v139 = 807
                                                                    } else {
                                                                        var v105: Boolean = false
                                                                        v105 = (v85 == 233)
                                                                        if (v105) {
                                                                            v138 = 101
                                                                            v139 = 769
                                                                        } else {
                                                                            var v106: Boolean = false
                                                                            v106 = (v85 == 243)
                                                                            if (v106) {
                                                                                v138 = 111
                                                                                v139 = 769
                                                                            } else {
                                                                                var v107: Boolean = false
                                                                                v107 = (v85 == 245)
                                                                                if (v107) {
                                                                                    v138 = 111
                                                                                    v139 = 771
                                                                                } else {
                                                                                    v138 = v85
                                                                                    v139 = -1
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
                    var v140: Int = 0
                    v140 = (v3 + v91)
                    v147 = v138
                    v148 = v140
                    v149 = v139
                }
            }
        }
        var v150: Boolean = false
        v150 = (v76 < 0)
        if (v150) {
            var v151: Boolean = false
            v151 = (v147 == -1)
            return v151
        } else {
            var v152: Boolean = false
            v152 = (v147 < 0)
            if (v152) {
                return false
            } else {
                var v153: Boolean = false
                v153 = (v76 == v147)
                if (v153) {
                    val t19434_0: String = v0
                    val t19481_1: String = v1
                    val t19528_77: Int = v77
                    val t19574_148: Int = v148
                    val t19622_78: Int = v78
                    val t19668_149: Int = v149
                    val t19716_6: Int = v6
                    val t19760_7: Int = v7
                    v0 = t19434_0
                    v1 = t19481_1
                    v2 = t19528_77
                    v3 = t19574_148
                    v4 = t19622_78
                    v5 = t19668_149
                    v6 = t19716_6
                    v7 = t19760_7
                    continue
                } else {
                    return false
                }
            }
        }
    }
    return false
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "plain"
    var v1: Int = 0
    v1 = 0
    var v2: Int = 0
    v2 = 0
    var v3: Int = 0
    v3 = -1
    var v4: Int = 0
    v4 = -1
    var v5: Int = 0
    v5 = 5
    var v6: Int = 0
    v6 = 5
    var v7: Boolean = false
    v7 = sp_utf8_canonical_equal_bounded_loop_0(v0, v0, v1, v2, v3, v4, v5, v6)
    var v8: String = ""
    v8 = ""
    var v9: Int = 0
    v9 = 0
    var v10: Int = 0
    v10 = 0
    var v11: Int = 0
    v11 = -1
    var v12: Int = 0
    v12 = -1
    var v13: Int = 0
    v13 = 0
    var v14: Int = 0
    v14 = 0
    var v15: Boolean = false
    v15 = sp_utf8_canonical_equal_bounded_loop_0(v8, v8, v9, v10, v11, v12, v13, v14)
    var v16: String = ""
    v16 = "éõç"
    var v17: String = ""
    v17 = "éõç"
    var v18: Int = 0
    v18 = 0
    var v19: Int = 0
    v19 = 0
    var v20: Int = 0
    v20 = -1
    var v21: Int = 0
    v21 = -1
    var v22: Int = 0
    v22 = 6
    var v23: Int = 0
    v23 = 9
    var v24: Boolean = false
    v24 = sp_utf8_canonical_equal_bounded_loop_0(v16, v17, v18, v19, v20, v21, v22, v23)
    var v25: String = ""
    v25 = "é̃"
    var v26: String = ""
    v26 = "é̃"
    var v27: Int = 0
    v27 = 0
    var v28: Int = 0
    v28 = 0
    var v29: Int = 0
    v29 = -1
    var v30: Int = 0
    v30 = -1
    var v31: Int = 0
    v31 = 4
    var v32: Int = 0
    v32 = 5
    var v33: Boolean = false
    v33 = sp_utf8_canonical_equal_bounded_loop_0(v25, v26, v27, v28, v29, v30, v31, v32)
    var v34: String = ""
    v34 = "À"
    var v35: String = ""
    v35 = "À"
    var v36: Int = 0
    v36 = 0
    var v37: Int = 0
    v37 = 0
    var v38: Int = 0
    v38 = -1
    var v39: Int = 0
    v39 = -1
    var v40: Int = 0
    v40 = 2
    var v41: Int = 0
    v41 = 3
    var v42: Boolean = false
    v42 = sp_utf8_canonical_equal_bounded_loop_0(v34, v35, v36, v37, v38, v39, v40, v41)
    var v43: String = ""
    v43 = "Ω"
    var v44: Int = 0
    v44 = 0
    var v45: Int = 0
    v45 = 0
    var v46: Int = 0
    v46 = -1
    var v47: Int = 0
    v47 = -1
    var v48: Int = 0
    v48 = 2
    var v49: Int = 0
    v49 = 2
    var v50: Boolean = false
    v50 = sp_utf8_canonical_equal_bounded_loop_0(v43, v43, v44, v45, v46, v47, v48, v49)
    var v51: String = ""
    v51 = "ẽ́"
    var v52: Int = 0
    v52 = 0
    var v53: Int = 0
    v53 = 0
    var v54: Int = 0
    v54 = -1
    var v55: Int = 0
    v55 = -1
    var v56: Int = 0
    v56 = 5
    var v57: Int = 0
    v57 = 5
    var v58: Boolean = false
    v58 = sp_utf8_canonical_equal_bounded_loop_0(v26, v51, v52, v53, v54, v55, v56, v57)
    var v59: String = ""
    v59 = "é"
    var v60: String = ""
    v60 = "á"
    var v61: Int = 0
    v61 = 0
    var v62: Int = 0
    v62 = 0
    var v63: Int = 0
    v63 = -1
    var v64: Int = 0
    v64 = -1
    var v65: Int = 0
    v65 = 2
    var v66: Int = 0
    v66 = 2
    var v67: Boolean = false
    v67 = sp_utf8_canonical_equal_bounded_loop_0(v59, v60, v61, v62, v63, v64, v65, v66)
    var v68: String = ""
    v68 = "ω"
    var v69: Int = 0
    v69 = 0
    var v70: Int = 0
    v70 = 0
    var v71: Int = 0
    v71 = -1
    var v72: Int = 0
    v72 = -1
    var v73: Int = 0
    v73 = 2
    var v74: Int = 0
    v74 = 2
    var v75: Boolean = false
    v75 = sp_utf8_canonical_equal_bounded_loop_0(v43, v68, v69, v70, v71, v72, v73, v74)
    var v76: String = ""
    v76 = "e"
    var v77: Int = 0
    v77 = 0
    var v78: Int = 0
    v78 = 0
    var v79: Int = 0
    v79 = -1
    var v80: Int = 0
    v80 = -1
    var v81: Int = 0
    v81 = 2
    var v82: Int = 0
    v82 = 1
    var v83: Boolean = false
    v83 = sp_utf8_canonical_equal_bounded_loop_0(v59, v76, v77, v78, v79, v80, v81, v82)
    if (v7) {
        if (v15) {
            if (v24) {
                if (v33) {
                    if (v42) {
                        if (v50) {
                            if (v58) {
                                return 7
                            } else {
                                if (v67) {
                                    return 8
                                } else {
                                    if (v75) {
                                        return 9
                                    } else {
                                        if (v83) {
                                            return 10
                                        } else {
                                            return 0
                                        }
                                    }
                                }
                            }
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
