fun spiral_main(): Int {
    var v0: Int = 0
    v0 = -1
    var v1: Int = 0
    v1 = -8
    var v2: Int = 0
    v2 = (v0.inv())
    var v3: Int = 0
    v3 = (v1.inv())
    var v4: Boolean = false
    v4 = (v2 == 0)
    var v6: Boolean = false
    if (v4) {
        var v5: Boolean = false
        v5 = (v3 == 7)
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
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
