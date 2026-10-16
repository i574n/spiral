fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = 2.0f
    var v1: Float = 0.0f
    v1 = 3.0f
    var v2: Double = 0.0
    v2 = 2.0
    var v3: Double = 0.0
    v3 = 3.0
    var v4: Float = 0.0f
    v4 = 3.1415927f
    var v5: Double = 0.0
    v5 = 3.141592653589793
    var v6: Float = 0.0f
    v6 = Math.pow((v0).toDouble(), (v1).toDouble()).toFloat()
    var v7: Boolean = false
    v7 = (v6 == 8.0f)
    var v10: Boolean = false
    if (v7) {
        var v8: Double = 0.0
        v8 = Math.pow(v2, v3)
        var v9: Boolean = false
        v9 = (v8 == 8.0)
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Boolean = false
    if (v10) {
        var v11: Boolean = false
        v11 = (v4 > 3.0f)
        v12 = v11
    } else {
        v12 = false
    }
    var v14: Boolean = false
    if (v12) {
        var v13: Boolean = false
        v13 = (v4 < 4.0f)
        v14 = v13
    } else {
        v14 = false
    }
    var v16: Boolean = false
    if (v14) {
        var v15: Boolean = false
        v15 = (v5 > 3.0)
        v16 = v15
    } else {
        v16 = false
    }
    var v18: Boolean = false
    if (v16) {
        var v17: Boolean = false
        v17 = (v5 < 4.0)
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
