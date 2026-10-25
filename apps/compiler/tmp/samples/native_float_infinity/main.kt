fun spiral_main(): Int {
    val v0: Float = Float.POSITIVE_INFINITY
    val v1: Double = Double.POSITIVE_INFINITY
    val v2: Float = (-(v0))
    val v3: Double = (-(v1))
    val v4: Float = 1.0f
    val v5: Double = 1.0
    val v6: Boolean = (v4 != v4)
    var v8: Boolean = false
    if (v6) {
        v8 = true
    } else {
        val v7: Boolean = (v5 != v5)
        v8 = v7
    }
    if (v8) {
        return 3
    } else {
        val v9: Boolean = (v0 > v4)
        var v11: Boolean = false
        if (v9) {
            val v10: Boolean = (v1 > v5)
            v11 = v10
        } else {
            v11 = false
        }
        if (v11) {
            val v12: Boolean = (v2 < 0.0f)
            var v14: Boolean = false
            if (v12) {
                val v13: Boolean = (v3 < 0.0)
                v14 = v13
            } else {
                v14 = false
            }
            if (v14) {
                return 0
            } else {
                return 2
            }
        } else {
            return 1
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
