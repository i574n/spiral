fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = -2
    val v2: UInt = 7u
    val v3: Float = 2.9f
    val v4: Float = (v0).toFloat()
    val v5: Float = (v1).toFloat()
    val v6: Float = (v2).toFloat()
    val v7: UInt = (v3).toUInt()
    val v8: Boolean = (v4 == 3.0f)
    var v10: Boolean = false
    if (v8) {
        val v9: Boolean = (v5 == -2.0f)
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Boolean = false
    if (v10) {
        val v11: Boolean = (v6 == 7.0f)
        v12 = v11
    } else {
        v12 = false
    }
    var v14: Boolean = false
    if (v12) {
        val v13: Boolean = (v7 == 2u)
        v14 = v13
    } else {
        v14 = false
    }
    if (v14) {
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
