fun spiral_main(): Int {
    val v0: Double = 2.7
    val v1: Double = 3.2
    val v2: Double = -2.5
    val v3: Double = 3.5
    val v4: Double = 0.5
    val v5: Double = 1.0
    val v6: Float = 2.7f
    val v7: Double = kotlin.math.floor(v0)
    val v8: Boolean = (v7 != 2.0)
    if (v8) {
        return 1
    } else {
        val v9: Double = kotlin.math.ceil(v0)
        val v10: Boolean = (v9 != 3.0)
        if (v10) {
            return 2
        } else {
            val v11: Double = kotlin.math.round(v0)
            val v12: Boolean = (v11 != 3.0)
            if (v12) {
                return 3
            } else {
                val v13: Double = kotlin.math.round(v1)
                val v14: Boolean = (v13 != 3.0)
                if (v14) {
                    return 4
                } else {
                    val v15: Double = kotlin.math.round(v2)
                    val v16: Boolean = (v15 != -2.0)
                    if (v16) {
                        return 5
                    } else {
                        val v17: Double = kotlin.math.round(v3)
                        val v18: Boolean = (v17 != 4.0)
                        if (v18) {
                            return 6
                        } else {
                            val v19: Double = kotlin.math.round(v4)
                            val v20: Boolean = (v19 != 0.0)
                            if (v20) {
                                return 7
                            } else {
                                val v21: Double = kotlin.math.atan2(v5, v5)
                                val v22: Double = (v21 * 1000.0)
                                val v23: Double = kotlin.math.floor(v22)
                                val v24: Boolean = (v23 != 785.0)
                                if (v24) {
                                    return 8
                                } else {
                                    val v25: Float = kotlin.math.floor(v6)
                                    val v26: Boolean = (v25 != 2.0f)
                                    if (v26) {
                                        return 9
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
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
