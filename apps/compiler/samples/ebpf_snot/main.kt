fun spiral_main(): Int {
    val v0: Int = -1
    val v1: Int = -8
    val v2: Int = (v0.inv())
    val v3: Int = (v1.inv())
    val v4: Boolean = (v2 == 0)
    var v6: Boolean = false
    if (v4) {
        val v5: Boolean = (v3 == 7)
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
