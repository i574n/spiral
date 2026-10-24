fun spiral_main(): Int {
    val v0: UByte = (250).toUByte()
    val v1: UByte = (10).toUByte()
    val v2: UInt = 4294967295u
    val v3: ULong = 18446744073709551615uL
    val v4: Byte = (127).toByte()
    val v5: Byte = (1).toByte()
    val v6: Int = 7
    val v7: Int = 2
    val v8: Long = 9223372036854775807L
    val v9: Int = (-(v6))
    val v10: Long = (-(v8))
    val v11: UByte = ((v0 + v1)).toUByte()
    val v12: Boolean = (v11 == (4).toUByte())
    if (v12) {
        val v13: UInt = (v2 + 1u)
        val v14: Boolean = (v13 == 0u)
        if (v14) {
            val v15: UInt = (v2 * v2)
            val v16: Boolean = (v15 == 1u)
            if (v16) {
                val v17: ULong = (v3 + 1uL)
                val v18: Boolean = (v17 == 0uL)
                if (v18) {
                    val v19: ULong = (v3 * v3)
                    val v20: Boolean = (v19 == 1uL)
                    if (v20) {
                        val v21: ULong = (v3 / 3uL)
                        val v22: Boolean = (v21 == 6148914691236517205uL)
                        if (v22) {
                            val v23: Byte = ((v4 + v5)).toByte()
                            val v24: Boolean = (v23 < (0).toByte())
                            if (v24) {
                                val v25: Int = (v9 / v7)
                                val v26: Boolean = (v25 == -3)
                                if (v26) {
                                    val v27: Int = (v9 % v7)
                                    val v28: Boolean = (v27 == -1)
                                    if (v28) {
                                        val v29: Long = (v10 % 10L)
                                        val v30: Boolean = (v29 == -7L)
                                        if (v30) {
                                            val v31: UInt = (v2 shr 28)
                                            val v32: Boolean = (v31 == 15u)
                                            if (v32) {
                                                val v33: Int = (v9 shr 1)
                                                val v34: Boolean = (v33 == -4)
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
