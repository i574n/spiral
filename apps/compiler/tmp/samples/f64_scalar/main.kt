fun spiral_main(): Int {
    val v0: Double = 1.5
    val v1: Double = -2.0
    val v2: Double = (v0 / v1)
    val v3: Double = 1000000.0
    val v4: Double = (v3 * v3)
    val v5: Double = (v4 * v3)
    val v6: Double = (v5 * 10000.0)
    val v7: Double = (v6 * v6)
    val v8: Int = 3
    val v9: Double = (v8).toDouble()
    val v10: Double = 2.9
    val v11: Double = -1.9
    val v12: Int = (v10).toInt()
    val v13: Int = (v11).toInt()
    val v14: Float = 1.5f
    val v15: Double = (v14).toDouble()
    val v16: Boolean = (v2 == -0.75)
    var v18: Boolean = false
    if (v16) {
        val v17: Boolean = (v7 > v6)
        v18 = v17
    } else {
        v18 = false
    }
    var v21: Boolean = false
    if (v18) {
        val v19: Double = (v7 * v6)
        val v20: Boolean = (v7 < v19)
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Boolean = false
    if (v21) {
        val v22: Boolean = (v9 == 3.0)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        val v24: Boolean = (v12 == 2)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Boolean = false
    if (v25) {
        val v26: Boolean = (v13 == -1)
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Boolean = false
    if (v27) {
        val v28: Boolean = (v15 == 1.5)
        v29 = v28
    } else {
        v29 = false
    }
    if (v29) {
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
