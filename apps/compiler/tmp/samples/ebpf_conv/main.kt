fun spiral_main(): Int {
    val v0: Int = Int.MIN_VALUE
    val v1: UInt = 4294967295u
    val v2: Int = -1
    val v3: Float = 0.0f
    val v4: Float = 1.9f
    val v5: Float = 2.9f
    val v6: UInt = 4294967294u
    val v7: UInt = 5u
    val v8: UInt = 0u
    val v9: Float = (v3 - v4)
    val v10: UInt = (v0).toUInt()
    val v11: Int = (v10).toInt()
    val v12: Int = (v1).toInt()
    val v13: UInt = (v2).toUInt()
    val v14: Int = (v9).toInt()
    val v15: Int = (v5).toInt()
    val v16: UInt = (v10 / 2u)
    val v17: UInt = (v6 / 2u)
    val v18: UInt = (v7 % 3u)
    val v19: UInt = (v8.inv())
    val v20: UInt = (v1 shr 31)
    val v21: Boolean = (v0 < -1)
    var v23: Boolean = false
    if (v21) {
        val v22: Boolean = (v0 <= v0)
        v23 = v22
    } else {
        v23 = false
    }
    var v26: Boolean = false
    if (v23) {
        val v24: Boolean = (v0 > 0)
        val v25: Boolean = (v24 == false)
        v26 = v25
    } else {
        v26 = false
    }
    if (v26) {
        val v27: Boolean = (v10 > 1u)
        var v29: Boolean = false
        if (v27) {
            val v28: Boolean = (v11 == v0)
            v29 = v28
        } else {
            v29 = false
        }
        var v31: Boolean = false
        if (v29) {
            val v30: Boolean = (v12 == v2)
            v31 = v30
        } else {
            v31 = false
        }
        var v33: Boolean = false
        if (v31) {
            val v32: Boolean = (v13 == v1)
            v33 = v32
        } else {
            v33 = false
        }
        if (v33) {
            val v34: Boolean = (v14 == v2)
            var v36: Boolean = false
            if (v34) {
                val v35: Boolean = (v15 == 2)
                v36 = v35
            } else {
                v36 = false
            }
            if (v36) {
                val v37: Boolean = (v16 == 1073741824u)
                var v39: Boolean = false
                if (v37) {
                    val v38: Boolean = (v17 == 2147483647u)
                    v39 = v38
                } else {
                    v39 = false
                }
                var v41: Boolean = false
                if (v39) {
                    val v40: Boolean = (v18 == 2u)
                    v41 = v40
                } else {
                    v41 = false
                }
                if (v41) {
                    val v42: Boolean = (v19 == v1)
                    var v44: Boolean = false
                    if (v42) {
                        val v43: Boolean = (v20 == 1u)
                        v44 = v43
                    } else {
                        v44 = false
                    }
                    if (v44) {
                        return 0
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
