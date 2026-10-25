fun spiral_main(): Int {
    val v0: Float = -2.0f
    val v1: Float = -1.0f
    val v2: Float = 0.0f
    val v3: Boolean = (v0 < v1)
    var v5: Boolean = false
    if (v3) {
        val v4: Boolean = (v1 < v2)
        v5 = v4
    } else {
        v5 = false
    }
    var v8: Boolean = false
    if (v5) {
        val v6: Boolean = (v0 > v1)
        val v7: Boolean = (v6 == false)
        v8 = v7
    } else {
        v8 = false
    }
    var v11: Boolean = false
    if (v8) {
        val v9: Boolean = (v0 >= v1)
        val v10: Boolean = (v9 == false)
        v11 = v10
    } else {
        v11 = false
    }
    var v13: Boolean = false
    if (v11) {
        val v12: Boolean = (v1 <= v2)
        v13 = v12
    } else {
        v13 = false
    }
    if (v13) {
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
