fun sp_method0(p0: Int): Boolean {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 < 10)
    return v1
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 0
    var v1: Int = 0
    v1 = 0
    while (true) {
        if (!(sp_method0(v0))) break
        val v3: Int = (v1 + v0)
        v1 = v3
        val v4: Int = (v0 + 1)
        v0 = v4
    }
    val v5: Int = (v1 - 45)
    return v5
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
