fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = 0.0f
    var v1: Float = 0.0f
    v1 = 1.0f
    var v2: Double = 0.0
    v2 = 0.0
    var v3: Double = 0.0
    v3 = 1.0
    var v4: Float = 0.0f
    v4 = kotlin.math.ln(v1)
    var v5: Boolean = false
    v5 = (v4 == v0)
    var v8: Boolean = false
    if (v5) {
        var v6: Double = 0.0
        v6 = kotlin.math.ln(v3)
        var v7: Boolean = false
        v7 = (v6 == v2)
        v8 = v7
    } else {
        v8 = false
    }
    var v11: Boolean = false
    if (v8) {
        var v9: Float = 0.0f
        v9 = kotlin.math.exp(v0)
        var v10: Boolean = false
        v10 = (v9 == v1)
        v11 = v10
    } else {
        v11 = false
    }
    var v14: Boolean = false
    if (v11) {
        var v12: Double = 0.0
        v12 = kotlin.math.exp(v2)
        var v13: Boolean = false
        v13 = (v12 == v3)
        v14 = v13
    } else {
        v14 = false
    }
    var v17: Boolean = false
    if (v14) {
        var v15: Float = 0.0f
        v15 = kotlin.math.tanh(v0)
        var v16: Boolean = false
        v16 = (v15 == v0)
        v17 = v16
    } else {
        v17 = false
    }
    var v20: Boolean = false
    if (v17) {
        var v18: Double = 0.0
        v18 = kotlin.math.tanh(v2)
        var v19: Boolean = false
        v19 = (v18 == v2)
        v20 = v19
    } else {
        v20 = false
    }
    var v23: Boolean = false
    if (v20) {
        var v21: Float = 0.0f
        v21 = kotlin.math.sin(v0)
        var v22: Boolean = false
        v22 = (v21 == v0)
        v23 = v22
    } else {
        v23 = false
    }
    var v26: Boolean = false
    if (v23) {
        var v24: Double = 0.0
        v24 = kotlin.math.sin(v2)
        var v25: Boolean = false
        v25 = (v24 == v2)
        v26 = v25
    } else {
        v26 = false
    }
    var v29: Boolean = false
    if (v26) {
        var v27: Float = 0.0f
        v27 = kotlin.math.cos(v0)
        var v28: Boolean = false
        v28 = (v27 == v1)
        v29 = v28
    } else {
        v29 = false
    }
    var v32: Boolean = false
    if (v29) {
        var v30: Double = 0.0
        v30 = kotlin.math.cos(v2)
        var v31: Boolean = false
        v31 = (v30 == v3)
        v32 = v31
    } else {
        v32 = false
    }
    if (v32) {
        return 0
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
