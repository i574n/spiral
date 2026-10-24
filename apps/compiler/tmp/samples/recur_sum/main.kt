fun sp_sum_0(p0: Int): Int {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 < 1)
    if (v1) {
        return 0
    } else {
        var v2: Int = 0
        v2 = (v0 - 1)
        val v3: Int = sp_sum_0(v2)
        val v4: Int = (v0 + v3)
        return v4
    }
}
fun spiral_main(): Int {
    val v0: Int = 4
    var v1: Int = 0
    v1 = sp_sum_0(v0)
    var v2: Boolean = false
    v2 = (v1 == 10)
    if (v2) {
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
