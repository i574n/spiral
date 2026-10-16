fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = 1.5f
    var v1: Float = 0.0f
    v1 = -2.0f
    var v2: Float = 0.0f
    v2 = -0.5f
    var v3: Float = 0.0f
    v3 = (v0 / v1)
    var v4: Float = 0.0f
    v4 = (v2 / v1)
    var v5: Boolean = false
    v5 = (v3 == -0.75f)
    var v7: Boolean = false
    if (v5) {
        var v6: Boolean = false
        v6 = (v4 == 0.25f)
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
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
