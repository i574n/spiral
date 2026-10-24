fun f_c0(v0: Double): (Int) -> Double {
    fun body(v1: Int): Double {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            return 0.0
        } else {
            return v0
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Double = 1.5
    val v1: (Int) -> Double = f_c0(v0)
    var v2: Double = 0.0
    v2 = v1(1)
    val v3: Boolean = (v2 == 1.5)
    if (v3) {
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
