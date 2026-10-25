fun spiral_main(): Int {
    var v0: UByte = (0).toUByte()
    v0 = (250).toUByte()
    var v1: UByte = (0).toUByte()
    v1 = (10).toUByte()
    var v2: UInt = 0u
    v2 = 4294967295u
    var v3: ULong = 0uL
    v3 = 18446744073709551615uL
    var v4: Byte = (0).toByte()
    v4 = (127).toByte()
    var v5: Byte = (0).toByte()
    v5 = (1).toByte()
    var v6: Int = 0
    v6 = 7
    var v7: Int = 0
    v7 = 2
    var v8: Long = 0L
    v8 = 9223372036854775807L
    var v9: Int = 0
    v9 = (-(v6))
    var v10: Long = 0L
    v10 = (-(v8))
    var v11: UByte = (0).toUByte()
    v11 = ((v0 + v1)).toUByte()
    var v12: Boolean = false
    v12 = (v11 == (4).toUByte())
    if (v12) {
        var v13: UInt = 0u
        v13 = (v2 + 1u)
        var v14: Boolean = false
        v14 = (v13 == 0u)
        if (v14) {
            var v15: UInt = 0u
            v15 = (v2 * v2)
            var v16: Boolean = false
            v16 = (v15 == 1u)
            if (v16) {
                var v17: ULong = 0uL
                v17 = (v3 + 1uL)
                var v18: Boolean = false
                v18 = (v17 == 0uL)
                if (v18) {
                    var v19: ULong = 0uL
                    v19 = (v3 * v3)
                    var v20: Boolean = false
                    v20 = (v19 == 1uL)
                    if (v20) {
                        var v21: ULong = 0uL
                        v21 = (v3 / 3uL)
                        var v22: Boolean = false
                        v22 = (v21 == 6148914691236517205uL)
                        if (v22) {
                            var v23: Byte = (0).toByte()
                            v23 = ((v4 + v5)).toByte()
                            var v24: Boolean = false
                            v24 = (v23 < (0).toByte())
                            if (v24) {
                                var v25: Int = 0
                                v25 = (v9 / v7)
                                var v26: Boolean = false
                                v26 = (v25 == -3)
                                if (v26) {
                                    var v27: Int = 0
                                    v27 = (v9 % v7)
                                    var v28: Boolean = false
                                    v28 = (v27 == -1)
                                    if (v28) {
                                        var v29: Long = 0L
                                        v29 = (v10 % 10L)
                                        var v30: Boolean = false
                                        v30 = (v29 == -7L)
                                        if (v30) {
                                            var v31: UInt = 0u
                                            v31 = (v2 shr 28)
                                            var v32: Boolean = false
                                            v32 = (v31 == 15u)
                                            if (v32) {
                                                var v33: Int = 0
                                                v33 = (v9 shr 1)
                                                var v34: Boolean = false
                                                v34 = (v33 == -4)
                                                if (v34) {
                                                    return 0
                                                } else {
                                                    return 12
                                                }
                                            } else {
                                                return 11
                                            }
                                        } else {
                                            return 10
                                        }
                                    } else {
                                        return 9
                                    }
                                } else {
                                    return 8
                                }
                            } else {
                                return 7
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
