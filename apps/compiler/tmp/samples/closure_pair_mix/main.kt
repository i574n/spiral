class SpiralTuple0(val v0: Int, val v1: String)
fun f_c0(v0: Int, v1: String): (Int) -> SpiralTuple0 {
    fun body(v2: Int): SpiralTuple0 {
        var v3: Boolean = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: String = ""
            v4 = "no"
            return SpiralTuple0(0, v4)
        } else {
            return SpiralTuple0(v0, v1)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: (Int) -> SpiralTuple0 = { _: Int -> throw RuntimeException() }
    v2 = f_c0(v0, v1)
    var v3: Int = 0
    var v4: String = ""
    val spiral_tuple244 = v2(1)
    v3 = spiral_tuple244.v0
    v4 = spiral_tuple244.v1
    var v5: Boolean = false
    v5 = (v3 == 7)
    var v7: Boolean = false
    if (v5) {
        var v6: Boolean = false
        v6 = (v4 == "hi")
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
    System.exit(spiral_main())
}
