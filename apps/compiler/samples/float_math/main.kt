fun sp_method0(p0: Float, p1: Float): Float {
    var v0: Float = p0
    var v1: Float = p1
    var v2: Float = 0.0f
    v2 = (v0 * v1)
    var v3: Float = 0.0f
    v3 = (v2 + 0.5f)
    return v3
}
fun spiral_main(): Int {
    val v0: Float = 1.5f
    val v1: Float = 2.0f
    var v2: Float = 0.0f
    v2 = sp_method0(v0, v1)
    var v3: Boolean = false
    v3 = (v2 >= 3.5f)
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
