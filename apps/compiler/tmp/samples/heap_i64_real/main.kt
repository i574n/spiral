class Heap0(val l0: Long, val l1: Double)
fun spiral_main(): Int {
    var v0: Long = 0L
    v0 = 5000000000L
    var v1: Double = 0.0
    v1 = 1.5
    var v2: Heap0 = Heap0(0L, 0.0)
    v2 = Heap0(v0, v1)
    var v3: Long = 0L
    var v4: Double = 0.0
    v3 = v2.l0
    v4 = v2.l1
    var v5: Boolean = false
    v5 = (v3 == 5000000000L)
    var v7: Boolean = false
    if (v5) {
        var v6: Boolean = false
        v6 = (v4 == 1.5)
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
