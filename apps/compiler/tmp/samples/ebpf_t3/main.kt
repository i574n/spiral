class SpiralTuple0(val v0: Int, val v1: Int, val v2: Int)
fun sp_method2(p0: Int, p1: Int, p2: Int, p3: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = p3
    while (true) {
        var v4: Int = 0
        v4 = (v0 - 1)
        var v5: Int = 0
        v5 = (v1 + 1)
        var v6: Int = 0
        v6 = (v2 + 2)
        var v7: Int = 0
        v7 = (v3 + 3)
        var v8: Boolean = false
        v8 = (v4 == 0)
        if (v8) {
            return SpiralTuple0(v5, v6, v7)
        } else {
            val t507_4: Int = v4
            val t541_5: Int = v5
            val t575_6: Int = v6
            val t609_7: Int = v7
            v0 = t507_4
            v1 = t541_5
            v2 = t575_6
            v3 = t609_7
            continue
        }
    }
    return SpiralTuple0(0, 0, 0)
}
fun sp_method1(p0: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = 0
    v1 = 0
    var v2: Int = 0
    v2 = 0
    var v3: Int = 0
    v3 = 0
    var v4: Boolean = false
    v4 = (v0 == 0)
    if (v4) {
        return SpiralTuple0(v1, v2, v3)
    } else {
        return sp_method2(v0, v1, v2, v3)
    }
}
fun sp_method0(p0: Int): Int {
    var v0: Int = p0
    var v1: Int = 0
    var v2: Int = 0
    var v3: Int = 0
    val spiral_tuple117 = sp_method1(v0)
    v1 = spiral_tuple117.v0
    v2 = spiral_tuple117.v1
    v3 = spiral_tuple117.v2
    var v4: Boolean = false
    v4 = (v1 == 3)
    var v6: Boolean = false
    if (v4) {
        var v5: Boolean = false
        v5 = (v2 == 6)
        v6 = v5
    } else {
        v6 = false
    }
    var v8: Boolean = false
    if (v6) {
        var v7: Boolean = false
        v7 = (v3 == 9)
        v8 = v7
    } else {
        v8 = false
    }
    if (v8) {
        return 0
    } else {
        return 1
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    return sp_method0(v0)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
