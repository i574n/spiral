fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = 144.0f
    var v1: Double = 0.0
    v1 = 81.0
    var v2: Float = 0.0f
    v2 = kotlin.math.sqrt(v0)
    var v3: Double = 0.0
    v3 = kotlin.math.sqrt(v1)
    var v4: Boolean = false
    v4 = (v2 == 12.0f)
    var v6: Boolean = false
    if (v4) {
        var v5: Boolean = false
        v5 = (v3 == 9.0)
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
