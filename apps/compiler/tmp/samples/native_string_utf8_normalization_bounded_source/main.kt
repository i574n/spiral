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
                                val v34: Int = (v33 and 255)
                                val v35: Int = sp_runtime_byte_1(v0, v29)
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
fun spiral_main(): Int {
    val v0: String = "é"
    val v1: Int = 0
    var v2: Int = 0
    v2 = sp_utf8_scalar_at_byte_offset_0(v0, v1)
    var v3: String = ""
    v3 = "õ"
    val v4: Int = 0
    var v5: Int = 0
    v5 = sp_utf8_scalar_at_byte_offset_0(v3, v4)
    val v6: String = "ç"
    var v7: Int = 0
    v7 = 0
    var v8: Int = 0
    v8 = sp_utf8_scalar_at_byte_offset_0(v6, v7)
    var v9: String = ""
    v9 = "́"
    var v10: Int = 0
    v10 = 0
    val v11: Int = sp_utf8_scalar_at_byte_offset_0(v9, v10)
    var v12: String = ""
    v12 = "̃"
    var v13: Int = 0
    v13 = 0
    var v14: Int = 0
    v14 = sp_utf8_scalar_at_byte_offset_0(v12, v13)
    val v15: String = "̧"
    var v16: Int = 0
    v16 = 0
    var v17: Int = 0
    v17 = sp_utf8_scalar_at_byte_offset_0(v15, v16)
    var v18: Boolean = false
    v18 = (v2 == 192)
    var v64: Int = 0
    var v65: Int = 0
    if (v18) {
        v64 = 65
        v65 = 768
    } else {
        var v19: Boolean = false
        v19 = (v2 == 193)
        if (v19) {
            v64 = 65
            v65 = 769
        } else {
            var v20: Boolean = false
            v20 = (v2 == 195)
            if (v20) {
                v64 = 65
                v65 = 771
            } else {
                var v21: Boolean = false
                v21 = (v2 == 196)
                if (v21) {
                    v64 = 65
                    v65 = 776
                } else {
                    var v22: Boolean = false
                    v22 = (v2 == 199)
                    if (v22) {
                        v64 = 67
                        v65 = 807
                    } else {
                        var v23: Boolean = false
                        v23 = (v2 == 201)
                        if (v23) {
                            v64 = 69
                            v65 = 769
                        } else {
                            var v24: Boolean = false
                            v24 = (v2 == 211)
                            if (v24) {
                                v64 = 79
                                v65 = 769
                            } else {
                                val v25: Boolean = (v2 == 213)
                                if (v25) {
                                    v64 = 79
                                    v65 = 771
                                } else {
                                    val v26: Boolean = (v2 == 224)
                                    if (v26) {
                                        v64 = 97
                                        v65 = 768
                                    } else {
                                        val v27: Boolean = (v2 == 225)
                                        if (v27) {
                                            v64 = 97
                                            v65 = 769
                                        } else {
                                            var v28: Boolean = false
                                            v28 = (v2 == 227)
                                            if (v28) {
                                                v64 = 97
                                                v65 = 771
                                            } else {
                                                var v29: Boolean = false
                                                v29 = (v2 == 228)
                                                if (v29) {
                                                    v64 = 97
                                                    v65 = 776
                                                } else {
                                                    var v30: Boolean = false
                                                    v30 = (v2 == 231)
                                                    if (v30) {
                                                        v64 = 99
                                                        v65 = 807
                                                    } else {
                                                        val v31: Boolean = (v2 == 233)
                                                        if (v31) {
                                                            v64 = 101
                                                            v65 = 769
                                                        } else {
                                                            var v32: Boolean = false
                                                            v32 = (v2 == 243)
                                                            if (v32) {
                                                                v64 = 111
                                                                v65 = 769
                                                            } else {
                                                                var v33: Boolean = false
                                                                v33 = (v2 == 245)
                                                                if (v33) {
                                                                    v64 = 111
                                                                    v65 = 771
                                                                } else {
                                                                    v64 = v2
                                                                    v65 = -1
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
    val v66: Boolean = (v5 == 192)
    var v112: Int = 0
    var v113: Int = 0
    if (v66) {
        v112 = 65
        v113 = 768
    } else {
        var v67: Boolean = false
        v67 = (v5 == 193)
        if (v67) {
            v112 = 65
            v113 = 769
        } else {
            var v68: Boolean = false
            v68 = (v5 == 195)
            if (v68) {
                v112 = 65
                v113 = 771
            } else {
                var v69: Boolean = false
                v69 = (v5 == 196)
                if (v69) {
                    v112 = 65
                    v113 = 776
                } else {
                    var v70: Boolean = false
                    v70 = (v5 == 199)
                    if (v70) {
                        v112 = 67
                        v113 = 807
                    } else {
                        var v71: Boolean = false
                        v71 = (v5 == 201)
                        if (v71) {
                            v112 = 69
                            v113 = 769
                        } else {
                            var v72: Boolean = false
                            v72 = (v5 == 211)
                            if (v72) {
                                v112 = 79
                                v113 = 769
                            } else {
                                var v73: Boolean = false
                                v73 = (v5 == 213)
                                if (v73) {
                                    v112 = 79
                                    v113 = 771
                                } else {
                                    var v74: Boolean = false
                                    v74 = (v5 == 224)
                                    if (v74) {
                                        v112 = 97
                                        v113 = 768
                                    } else {
                                        var v75: Boolean = false
                                        v75 = (v5 == 225)
                                        if (v75) {
                                            v112 = 97
                                            v113 = 769
                                        } else {
                                            var v76: Boolean = false
                                            v76 = (v5 == 227)
                                            if (v76) {
                                                v112 = 97
                                                v113 = 771
                                            } else {
                                                var v77: Boolean = false
                                                v77 = (v5 == 228)
                                                if (v77) {
                                                    v112 = 97
                                                    v113 = 776
                                                } else {
                                                    var v78: Boolean = false
                                                    v78 = (v5 == 231)
                                                    if (v78) {
                                                        v112 = 99
                                                        v113 = 807
                                                    } else {
                                                        var v79: Boolean = false
                                                        v79 = (v5 == 233)
                                                        if (v79) {
                                                            v112 = 101
                                                            v113 = 769
                                                        } else {
                                                            var v80: Boolean = false
                                                            v80 = (v5 == 243)
                                                            if (v80) {
                                                                v112 = 111
                                                                v113 = 769
                                                            } else {
                                                                var v81: Boolean = false
                                                                v81 = (v5 == 245)
                                                                if (v81) {
                                                                    v112 = 111
                                                                    v113 = 771
                                                                } else {
                                                                    v112 = v5
                                                                    v113 = -1
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
    val v114: Boolean = (v8 == 192)
    var v160: Int = 0
    var v161: Int = 0
    if (v114) {
        v160 = 65
        v161 = 768
    } else {
        val v115: Boolean = (v8 == 193)
        if (v115) {
            v160 = 65
            v161 = 769
        } else {
            val v116: Boolean = (v8 == 195)
            if (v116) {
                v160 = 65
                v161 = 771
            } else {
                val v117: Boolean = (v8 == 196)
                if (v117) {
                    v160 = 65
                    v161 = 776
                } else {
                    val v118: Boolean = (v8 == 199)
                    if (v118) {
                        v160 = 67
                        v161 = 807
                    } else {
                        val v119: Boolean = (v8 == 201)
                        if (v119) {
                            v160 = 69
                            v161 = 769
                        } else {
                            val v120: Boolean = (v8 == 211)
                            if (v120) {
                                v160 = 79
                                v161 = 769
                            } else {
                                val v121: Boolean = (v8 == 213)
                                if (v121) {
                                    v160 = 79
                                    v161 = 771
                                } else {
                                    val v122: Boolean = (v8 == 224)
                                    if (v122) {
                                        v160 = 97
                                        v161 = 768
                                    } else {
                                        val v123: Boolean = (v8 == 225)
                                        if (v123) {
                                            v160 = 97
                                            v161 = 769
                                        } else {
                                            val v124: Boolean = (v8 == 227)
                                            if (v124) {
                                                v160 = 97
                                                v161 = 771
                                            } else {
                                                val v125: Boolean = (v8 == 228)
                                                if (v125) {
                                                    v160 = 97
                                                    v161 = 776
                                                } else {
                                                    val v126: Boolean = (v8 == 231)
                                                    if (v126) {
                                                        v160 = 99
                                                        v161 = 807
                                                    } else {
                                                        val v127: Boolean = (v8 == 233)
                                                        if (v127) {
                                                            v160 = 101
                                                            v161 = 769
                                                        } else {
                                                            val v128: Boolean = (v8 == 243)
                                                            if (v128) {
                                                                v160 = 111
                                                                v161 = 769
                                                            } else {
                                                                val v129: Boolean = (v8 == 245)
                                                                if (v129) {
                                                                    v160 = 111
                                                                    v161 = 771
                                                                } else {
                                                                    v160 = v8
                                                                    v161 = -1
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
    val v162: Boolean = (v11 == 769)
    var v163: Int = 0
    if (v162) {
        v163 = 233
    } else {
        v163 = -1
    }
    val v164: Boolean = (v163 < 0)
    var v165: Int = 0
    var v166: Int = 0
    if (v164) {
        v165 = 101
        v166 = v11
    } else {
        v165 = v163
        v166 = -1
    }
    val v167: Boolean = (v14 == 769)
    var v170: Int = 0
    if (v167) {
        v170 = 243
    } else {
        val v168: Boolean = (v14 == 771)
        if (v168) {
            v170 = 245
        } else {
            v170 = -1
        }
    }
    val v171: Boolean = (v170 < 0)
    var v172: Int = 0
    var v173: Int = 0
    if (v171) {
        v172 = 111
        v173 = v14
    } else {
        v172 = v170
        v173 = -1
    }
    val v174: Boolean = (v17 == 807)
    var v175: Int = 0
    if (v174) {
        v175 = 231
    } else {
        v175 = -1
    }
    val v176: Boolean = (v175 < 0)
    var v177: Int = 0
    var v178: Int = 0
    if (v176) {
        v177 = 99
        v178 = v17
    } else {
        v177 = v175
        v178 = -1
    }
    val v179: Boolean = (v64 == 101)
    var v181: Boolean = false
    if (v179) {
        val v180: Boolean = (v65 == v11)
        v181 = v180
    } else {
        v181 = false
    }
    if (v181) {
        val v182: Boolean = (v112 == 111)
        var v184: Boolean = false
        if (v182) {
            val v183: Boolean = (v113 == v14)
            v184 = v183
        } else {
            v184 = false
        }
        if (v184) {
            val v185: Boolean = (v160 == 99)
            var v187: Boolean = false
            if (v185) {
                val v186: Boolean = (v161 == v17)
                v187 = v186
            } else {
                v187 = false
            }
            if (v187) {
                val v188: Boolean = (v165 == v2)
                var v190: Boolean = false
                if (v188) {
                    val v189: Boolean = (v166 == -1)
                    v190 = v189
                } else {
                    v190 = false
                }
                if (v190) {
                    val v191: Boolean = (v172 == v5)
                    var v193: Boolean = false
                    if (v191) {
                        val v192: Boolean = (v173 == -1)
                        v193 = v192
                    } else {
                        v193 = false
                    }
                    if (v193) {
                        val v194: Boolean = (v177 == v8)
                        var v196: Boolean = false
                        if (v194) {
                            val v195: Boolean = (v178 == -1)
                            v196 = v195
                        } else {
                            v196 = false
                        }
                        if (v196) {
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
