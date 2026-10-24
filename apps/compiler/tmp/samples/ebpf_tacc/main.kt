class SpiralTuple0(val v0: Int, val v1: Int)
fun sp_method2(p0: Int, p1: Int, p2: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    while (true) {
        var v3: Int = 0
        v3 = (v0 - 1)
        var v4: Int = 0
        v4 = (v1 + 1)
        var v5: Int = 0
        v5 = (v2 + 2)
        val v6: Boolean = (v3 == 0)
        if (v6) {
            return SpiralTuple0(v4, v5)
        } else {
            v0 = v3
            v1 = v4
            v2 = v5
            continue
        }
    }
    return SpiralTuple0(0, 0)
}
fun sp_method1(p0: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = 0
    v1 = 0
    var v2: Int = 0
    v2 = 0
    var v3: Boolean = false
    v3 = (v0 == 0)
    if (v3) {
        return SpiralTuple0(v1, v2)
    } else {
        return sp_method2(v0, v1, v2)
    }
}
fun sp_method0(p0: Int): Int {
    var v0: Int = p0
    var v1: Int = 0
    var v2: Int = 0
    val spiral_tuple96 = sp_method1(v0)
    v1 = spiral_tuple96.v0
    v2 = spiral_tuple96.v1
    var v3: Boolean = false
    v3 = (v1 == 4)
    var v5: Boolean = false
    if (v3) {
        var v4: Boolean = false
        v4 = (v2 == 8)
        v5 = v4
    } else {
        v5 = false
    }
    if (v5) {
        return 0
    } else {
        return 1
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 4
    return sp_method0(v0)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
