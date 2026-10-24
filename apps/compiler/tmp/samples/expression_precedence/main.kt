fun sp_method0(p0: Int, p1: Int): Boolean {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = -v0 
    val v3: Boolean = (v2 <= 0)
    if (v3) {
        val v4: Int = (v1 * 2)
        val v5: Int = (v0 + v4)
        val v6: Boolean = (v5 >= 9)
        if (v6) {
            return true
        } else {
            val v7: Boolean = (v1 == 0)
            return v7
        }
    } else {
        return false
    }
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 3
    var v2: Boolean = false
    v2 = sp_method0(v0, v1)
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
