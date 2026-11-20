fun sp_fib_0(p0: Int): Int {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 <= 1)
    if (v1) {
        return v0
    } else {
        var v2: Int = 0
        v2 = (v0 - 1)
        val v3: Int = sp_fib_0(v2)
        val v4: Int = (v0 - 2)
        val v5: Int = sp_fib_0(v4)
        val v6: Int = (v3 + v5)
        return v6
    }
}
fun spiral_main(): Int {
    val v0: Int = 10
    var v1: Int = 0
    v1 = sp_fib_0(v0)
    var v2: Int = 0
    v2 = (v1 - 55)
    return v2
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
