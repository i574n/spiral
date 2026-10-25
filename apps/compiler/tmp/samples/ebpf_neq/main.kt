fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    val v2: UInt = 1u
    val v3: UInt = 1u
    val v4: Float = 1.5f
    val v5: Float = (-(v4))
    val v6: Boolean = (v0 != v1)
    if (v6) {
        val v7: Boolean = (v2 != v3)
        if (v7) {
            return 2
        } else {
            val v8: Boolean = (v5 == -1.5f)
            if (v8) {
                return 0
            } else {
                return 3
            }
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
