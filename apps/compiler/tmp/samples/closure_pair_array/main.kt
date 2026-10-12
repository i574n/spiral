class SpiralTuple0(val v0: Array<Int>, val v1: Array<Int>)
fun f_c0(v0: Int, v1: Int): (Int) -> SpiralTuple0 {
    fun body(v2: Int): SpiralTuple0 {
        var v3: Array<Int> = emptyArray<Int>()
        v3 = Array(1) { 0 }
        var v4: Array<Int> = emptyArray<Int>()
        v4 = Array(1) { 0 }
        var v5: Boolean = false
        v5 = (v2 == 0)
        if (v5) {
            v3[0] = 0
            v4[0] = 0
            return SpiralTuple0(v3, v4)
        } else {
            v3[0] = v0
            v4[0] = v1
            return SpiralTuple0(v3, v4)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Int = 0
    v1 = 4
    var v2: (Int) -> SpiralTuple0 = { _: Int -> throw RuntimeException() }
    v2 = f_c0(v0, v1)
    var v3: Array<Int> = emptyArray<Int>()
    var v4: Array<Int> = emptyArray<Int>()
    val spiral_tuple279 = v2(1)
    v3 = spiral_tuple279.v0
    v4 = spiral_tuple279.v1
    var v5: Int = 0
    v5 = v3[0]
    var v6: Int = 0
    v6 = v4[0]
    var v7: Int = 0
    v7 = (v5 + v6)
    var v8: Boolean = false
    v8 = (v7 == 7)
    if (v8) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
