fun sp_method0(p0: Int, p1: Int): Boolean {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = -v0 
    var v3: Boolean = false
    v3 = (v2 <= 0)
    if (v3) {
        var v4: Int = 0
        v4 = (v1 * 2)
        var v5: Int = 0
        v5 = (v0 + v4)
        var v6: Boolean = false
        v6 = (v5 >= 9)
        if (v6) {
            return true
        } else {
            var v7: Boolean = false
            v7 = (v1 == 0)
            return v7
        }
    } else {
        return false
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Int = 0
    v1 = 3
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
