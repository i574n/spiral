class Heap0(val l0: Float, val l1: UInt)
fun spiral_main(): Int {
    val v0: Float = 1.5f
    val v1: UInt = 4000000000u
    val v2: Heap0 = Heap0(v0, v1)
    var v3: Float = 0.0f
    var v4: UInt = 0u
    v3 = v2.l0
    v4 = v2.l1
    val v5: Boolean = (v3 == 1.5f)
    var v7: Boolean = false
    if (v5) {
        val v6: Boolean = (v4 == 4000000000u)
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
