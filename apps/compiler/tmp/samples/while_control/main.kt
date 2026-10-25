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
        var v3: Int = 0
        v3 = (v0 + 1)
        v0 = v3
        var v4: Boolean = false
        v4 = (v0 < 3)
        if (v4) {
            continue
        } else {
            var v5: Boolean = false
            v5 = (v0 >= 6)
            if (v5) {
                break
            } else {
                var v6: Int = 0
                v6 = (v1 + v0)
                v1 = v6
            }
        }
    }
    var v7: Int = 0
    v7 = (v1 - 12)
    return v7
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
