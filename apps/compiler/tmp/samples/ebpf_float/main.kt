fun spiral_main(): Int {
    val v0: Float = -1.5f
    val v1: Float = 2.0f
    val v2: Float = (v0 / v1)
    val v3: Float = -0.75f
    val v4: Float = (v0 * v1)
    val v5: Float = (v4 + 0.5f)
    val v6: Float = -2.5f
    val v7: Boolean = (v2 == v3)
    if (v7) {
        val v8: Boolean = (v5 == v6)
        if (v8) {
            return 0
        } else {
            return 2
        }
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
