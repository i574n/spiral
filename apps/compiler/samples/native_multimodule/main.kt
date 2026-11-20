fun sp_method0(p0: Int, p1: Int, p2: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    val v3: Int = (v0 * v1)
    val v4: Int = (v3 + v2)
    val v5: Int = (v4 - 42)
    return v5
}
fun spiral_main(): Int {
    val v0: Int = 5
    val v1: Int = 8
    val v2: Int = 2
    return sp_method0(v0, v1, v2)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
