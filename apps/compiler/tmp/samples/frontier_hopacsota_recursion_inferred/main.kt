fun sp_count_0(p0: Int): Int {
    var v0: Int = p0
    while (true) {
        var v1: Boolean = false
        v1 = (v0 <= 0)
        if (v1) {
            return 0
        } else {
            var v2: Int = 0
            v2 = (v0 - 1)
            val t246_2: Int = v2
            v0 = t246_2
            continue
        }
    }
    return 0
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 5
    return sp_count_0(v0)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
