fun sp_count_down_0(p0: Int, p1: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    while (true) {
        var v2: Boolean = false
        v2 = (0 < v0)
        if (v2) {
            var v3: Int = 0
            v3 = (v0 - 1)
            val v4: Int = (v1 + 1)
            v0 = v3
            v1 = v4
            continue
        } else {
            return v1
        }
    }
    return 0
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 5000
    var v1: Int = 0
    v1 = 0
    var v2: Int = 0
    v2 = sp_count_down_0(v0, v1)
    var v3: Boolean = false
    v3 = (v2 == 5000)
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
