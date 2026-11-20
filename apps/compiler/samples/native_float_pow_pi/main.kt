fun spiral_main(): Int {
    val v0: Float = 2.0f
    val v1: Float = 3.0f
    val v2: Double = 2.0
    val v3: Double = 3.0
    val v4: Float = 3.1415927f
    val v5: Double = 3.141592653589793
    val v6: Float = Math.pow((v0).toDouble(), (v1).toDouble()).toFloat()
    val v7: Boolean = (v6 == 8.0f)
    var v10: Boolean = false
    if (v7) {
        val v8: Double = Math.pow(v2, v3)
        val v9: Boolean = (v8 == 8.0)
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Boolean = false
    if (v10) {
        val v11: Boolean = (v4 > 3.0f)
        v12 = v11
    } else {
        v12 = false
    }
    var v14: Boolean = false
    if (v12) {
        val v13: Boolean = (v4 < 4.0f)
        v14 = v13
    } else {
        v14 = false
    }
    var v16: Boolean = false
    if (v14) {
        val v15: Boolean = (v5 > 3.0)
        v16 = v15
    } else {
        v16 = false
    }
    var v18: Boolean = false
    if (v16) {
        val v17: Boolean = (v5 < 4.0)
        v18 = v17
    } else {
        v18 = false
    }
    if (v18) {
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
