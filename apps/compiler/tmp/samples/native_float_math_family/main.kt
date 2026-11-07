fun spiral_main(): Int {
    val v0: Float = 0.0f
    val v1: Float = 1.0f
    val v2: Double = 0.0
    val v3: Double = 1.0
    val v4: Float = kotlin.math.ln(v1)
    val v5: Boolean = (v4 == v0)
    var v8: Boolean = false
    if (v5) {
        val v6: Double = kotlin.math.ln(v3)
        val v7: Boolean = (v6 == v2)
        v8 = v7
    } else {
        v8 = false
    }
    var v11: Boolean = false
    if (v8) {
        val v9: Float = kotlin.math.exp(v0)
        val v10: Boolean = (v9 == v1)
        v11 = v10
    } else {
        v11 = false
    }
    var v14: Boolean = false
    if (v11) {
        val v12: Double = kotlin.math.exp(v2)
        val v13: Boolean = (v12 == v3)
        v14 = v13
    } else {
        v14 = false
    }
    var v17: Boolean = false
    if (v14) {
        val v15: Float = kotlin.math.tanh(v0)
        val v16: Boolean = (v15 == v0)
        v17 = v16
    } else {
        v17 = false
    }
    var v20: Boolean = false
    if (v17) {
        val v18: Double = kotlin.math.tanh(v2)
        val v19: Boolean = (v18 == v2)
        v20 = v19
    } else {
        v20 = false
    }
    var v23: Boolean = false
    if (v20) {
        val v21: Float = kotlin.math.sin(v0)
        val v22: Boolean = (v21 == v0)
        v23 = v22
    } else {
        v23 = false
    }
    var v26: Boolean = false
    if (v23) {
        val v24: Double = kotlin.math.sin(v2)
        val v25: Boolean = (v24 == v2)
        v26 = v25
    } else {
        v26 = false
    }
    var v29: Boolean = false
    if (v26) {
        val v27: Float = kotlin.math.cos(v0)
        val v28: Boolean = (v27 == v1)
        v29 = v28
    } else {
        v29 = false
    }
    var v32: Boolean = false
    if (v29) {
        val v30: Double = kotlin.math.cos(v2)
        val v31: Boolean = (v30 == v3)
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
