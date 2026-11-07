fun spiral_main(): Int {
    val v0: Float = 144.0f
    val v1: Double = 81.0
    val v2: Float = kotlin.math.sqrt(v0)
    val v3: Double = kotlin.math.sqrt(v1)
    val v4: Boolean = (v2 == 12.0f)
    var v6: Boolean = false
    if (v4) {
        val v5: Boolean = (v3 == 9.0)
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
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
