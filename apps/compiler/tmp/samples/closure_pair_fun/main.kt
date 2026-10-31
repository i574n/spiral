class SpiralTuple0(val v0: (Int) -> Int, val v1: (Int) -> Int)
fun right_c1(v0: Int, v1: Int): (Int) -> Int {
    fun body(v2: Int): Int {
        var v3: Boolean = false
        v3 = (v1 == 0)
        if (v3) {
            return 0
        } else {
            var v4: Int = 0
            v4 = (v2 + v0)
            return v4
        }
    }
    return { p0: Int -> body(p0) }
}
fun left_c2(v0: Int, v1: Int): (Int) -> Int {
    fun body(v2: Int): Int {
        var v3: Boolean = false
        v3 = (v1 == 0)
        if (v3) {
            return 0
        } else {
            var v4: Int = 0
            v4 = (v2 + v0)
            return v4
        }
    }
    return { p0: Int -> body(p0) }
}
fun f_c0(v0: Int, v1: Int): (Int) -> SpiralTuple0 {
    fun body(v2: Int): SpiralTuple0 {
        var v3: Boolean = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: (Int) -> Int = { _: Int -> throw RuntimeException() }
            v4 = right_c1(v1, v2)
            var v5: (Int) -> Int = { _: Int -> throw RuntimeException() }
            v5 = left_c2(v0, v2)
            return SpiralTuple0(v4, v5)
        } else {
            var v6: (Int) -> Int = { _: Int -> throw RuntimeException() }
            v6 = left_c2(v0, v2)
            var v7: (Int) -> Int = { _: Int -> throw RuntimeException() }
            v7 = right_c1(v1, v2)
            return SpiralTuple0(v6, v7)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    val v2: (Int) -> SpiralTuple0 = f_c0(v0, v1)
    var v3: (Int) -> Int = { _: Int -> throw RuntimeException() }
    var v4: (Int) -> Int = { _: Int -> throw RuntimeException() }
    val spiral_tuple316 = v2(1)
    v3 = spiral_tuple316.v0
    v4 = spiral_tuple316.v1
    var v5: Int = 0
    v5 = v3(0)
    var v6: Int = 0
    v6 = v4(0)
    var v7: Int = 0
    v7 = (v5 + v6)
    val v8: Boolean = (v7 == 7)
    if (v8) {
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
