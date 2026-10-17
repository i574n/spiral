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
    v8 = (v7 == 2.0)
    var v9: Boolean = false
    v9 = (v8 != true)
    if (v9) {
        return 1
    } else {
        var v10: Double = 0.0
        v10 = kotlin.math.ceil(v0)
        var v11: Boolean = false
        v11 = (v10 == 3.0)
        var v12: Boolean = false
        v12 = (v11 != true)
        if (v12) {
            return 2
        } else {
            var v13: Double = 0.0
            v13 = kotlin.math.round(v0)
            var v14: Boolean = false
            v14 = (v13 == 3.0)
            var v15: Boolean = false
            v15 = (v14 != true)
            if (v15) {
                return 3
            } else {
                var v16: Double = 0.0
                v16 = kotlin.math.round(v1)
                var v17: Boolean = false
                v17 = (v16 == 3.0)
                var v18: Boolean = false
                v18 = (v17 != true)
                if (v18) {
                    return 4
                } else {
                    var v19: Double = 0.0
                    v19 = kotlin.math.round(v2)
                    var v20: Boolean = false
                    v20 = (v19 == -2.0)
                    var v21: Boolean = false
                    v21 = (v20 != true)
                    if (v21) {
                        return 5
                    } else {
                        var v22: Double = 0.0
                        v22 = kotlin.math.round(v3)
                        var v23: Boolean = false
                        v23 = (v22 == 4.0)
                        var v24: Boolean = false
                        v24 = (v23 != true)
                        if (v24) {
                            return 6
                        } else {
                            var v25: Double = 0.0
                            v25 = kotlin.math.round(v4)
                            var v26: Boolean = false
                            v26 = (v25 == 0.0)
                            var v27: Boolean = false
                            v27 = (v26 != true)
                            if (v27) {
                                return 7
                            } else {
                                var v28: Double = 0.0
                                v28 = kotlin.math.atan2(v5, v5)
                                var v29: Double = 0.0
                                v29 = (v28 * 1000.0)
                                var v30: Double = 0.0
                                v30 = kotlin.math.floor(v29)
                                var v31: Boolean = false
                                v31 = (v30 == 785.0)
                                var v32: Boolean = false
                                v32 = (v31 != true)
                                if (v32) {
                                    return 8
                                } else {
                                    var v33: Float = 0.0f
                                    v33 = kotlin.math.floor(v6)
                                    var v34: Boolean = false
                                    v34 = (v33 == 2.0f)
                                    var v35: Boolean = false
                                    v35 = (v34 != true)
                                    if (v35) {
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
