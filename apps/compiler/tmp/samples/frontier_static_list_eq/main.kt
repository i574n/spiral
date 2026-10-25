fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 120
    var v1: Boolean = false
    v1 = (v0 == 32)
    var v3: Boolean = false
    if (v1) {
        v3 = true
    } else {
        var v2: Boolean = false
        v2 = (v0 == 47)
        v3 = v2
    }
    if (v3) {
        return 1
    } else {
        return 0
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
