fun spiral_main(): Int {
    val v0: Float = 1.5f
    val v1: Float = -2.0f
    val v2: Float = -0.5f
    val v3: Float = (v0 / v1)
    val v4: Float = (v2 / v1)
    val v5: Boolean = (v3 == -0.75f)
    var v7: Boolean = false
    if (v5) {
        val v6: Boolean = (v4 == 0.25f)
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
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
