fun sp_method0(p0: Int, p1: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = (v0 + v1)
    var v3: Int = 0
    v3 = (v2 - 42)
    return v3
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 20
    var v1: Int = 0
    v1 = 22
    return sp_method0(v0, v1)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
