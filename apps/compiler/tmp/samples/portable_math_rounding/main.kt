fun spiral_main(): Int {
    var v0: Double = 0.0
    v0 = 2.7
    var v1: Double = 0.0
    v1 = 3.2
    var v2: Double = 0.0
    v2 = -2.5
    var v3: Double = 0.0
    v3 = 3.5
    var v4: Double = 0.0
    v4 = 0.5
    var v5: Double = 0.0
    v5 = 1.0
    var v6: Float = 0.0f
    v6 = 2.7f
    var v7: Double = 0.0
    v7 = kotlin.math.floor(v0)
    var v8: Boolean = false
    v8 = (v7 != 2.0)
    if (v8) {
        return 1
    } else {
        var v9: Double = 0.0
        v9 = kotlin.math.ceil(v0)
        var v10: Boolean = false
        v10 = (v9 != 3.0)
        if (v10) {
            return 2
        } else {
            var v11: Double = 0.0
            v11 = kotlin.math.round(v0)
            var v12: Boolean = false
            v12 = (v11 != 3.0)
            if (v12) {
                return 3
            } else {
                var v13: Double = 0.0
                v13 = kotlin.math.round(v1)
                var v14: Boolean = false
                v14 = (v13 != 3.0)
                if (v14) {
                    return 4
                } else {
                    var v15: Double = 0.0
                    v15 = kotlin.math.round(v2)
                    var v16: Boolean = false
                    v16 = (v15 != -2.0)
                    if (v16) {
                        return 5
                    } else {
                        var v17: Double = 0.0
                        v17 = kotlin.math.round(v3)
                        var v18: Boolean = false
                        v18 = (v17 != 4.0)
                        if (v18) {
                            return 6
                        } else {
                            var v19: Double = 0.0
                            v19 = kotlin.math.round(v4)
                            var v20: Boolean = false
                            v20 = (v19 != 0.0)
                            if (v20) {
                                return 7
                            } else {
                                var v21: Double = 0.0
                                v21 = kotlin.math.atan2(v5, v5)
                                var v22: Double = 0.0
                                v22 = (v21 * 1000.0)
                                var v23: Double = 0.0
                                v23 = kotlin.math.floor(v22)
                                var v24: Boolean = false
                                v24 = (v23 != 785.0)
                                if (v24) {
                                    return 8
                                } else {
                                    var v25: Float = 0.0f
                                    v25 = kotlin.math.floor(v6)
                                    var v26: Boolean = false
                                    v26 = (v25 != 2.0f)
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
