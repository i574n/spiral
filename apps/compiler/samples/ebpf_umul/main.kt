fun spiral_main(): Int {
    val v0: UInt = 65536u
    val v1: UInt = 65536u
    val v2: UInt = 4294967295u
    val v3: UInt = 3u
    val v4: UInt = (v0 * v1)
    val v5: UInt = (v2 * v3)
    val v6: Boolean = (v4 == 0u)
    var v8: Boolean = false
    if (v6) {
        val v7: Boolean = (v5 == 4294967293u)
        v8 = v7
    } else {
        v8 = false
    }
    if (v8) {
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
