fun sp_method0(): Boolean {
    return true
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 0
    var v1: Int = 0
    v1 = 0
    while (true) {
        if (!(sp_method0())) break
        val v3: Int = (v0 + 1)
        v0 = v3
        val v4: Boolean = (v0 < 3)
        if (v4) {
            continue
        } else {
            val v5: Boolean = (v0 >= 6)
            if (v5) {
                break
            } else {
                val v6: Int = (v1 + v0)
                v1 = v6
            }
        }
    }
    val v7: Int = (v1 - 12)
    return v7
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
