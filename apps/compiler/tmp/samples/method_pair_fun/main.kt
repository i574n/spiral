class SpiralTuple0(val v0: (Int) -> Int, val v1: (Int) -> Int)
fun left_c0(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Boolean = false
        v2 = (v0 == 0)
        if (v2) {
            return 0
        } else {
            var v3: Int = 0
            v3 = (v1 + v0)
            return v3
        }
    }
    return { p0: Int -> body(p0) }
}
fun right_c1(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Boolean = false
        v2 = (v0 == 0)
        if (v2) {
            return 0
        } else {
            var v3: Int = 0
            v3 = (v1 + v0)
            return v3
        }
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: Int, p1: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = p1
    var v2: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v2 = left_c0(v0)
    var v3: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v3 = right_c1(v1)
    return SpiralTuple0(v2, v3)
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    var v2: (Int) -> Int = { _: Int -> throw RuntimeException() }
    var v3: (Int) -> Int = { _: Int -> throw RuntimeException() }
    val spiral_tuple219 = sp_method0(v0, v1)
    v2 = spiral_tuple219.v0
    v3 = spiral_tuple219.v1
    val v4: Int = v2(0)
    val v5: Int = v3(0)
    val v6: Int = (v4 + v5)
    val v7: Boolean = (v6 == 7)
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
