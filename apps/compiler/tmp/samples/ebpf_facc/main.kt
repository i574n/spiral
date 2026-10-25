fun sp_method1(p0: Int, p1: Float): Float {
    var v0: Int = p0
    var v1: Float = p1
    while (true) {
        var v2: Int = 0
        v2 = (v0 - 1)
        var v3: Float = 0.0f
        v3 = (v1 + 1.5f)
        var v4: Boolean = false
        v4 = (v2 == 0)
        if (v4) {
            return v3
        } else {
            val t332_2: Int = v2
            val t366_3: Float = v3
            v0 = t332_2
            v1 = t366_3
            continue
        }
    }
    return 0.0f
}
fun sp_method0(p0: Int, p1: Float): Float {
    var v0: Int = p0
    var v1: Float = p1
    var v2: Boolean = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method1(v0, v1)
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 4
    var v1: Float = 0.0f
    v1 = 0.0f
    var v2: Float = 0.0f
    v2 = sp_method0(v0, v1)
    var v3: Boolean = false
    v3 = (v2 == 6.0f)
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
