class SpiralTuple0(val v0: UInt, val v1: String, val v2: Boolean)
fun f_c0(v0: UInt, v1: String, v2: Boolean): (Int) -> SpiralTuple0 {
    fun body(v3: Int): SpiralTuple0 {
        var v4: Boolean = false
        v4 = (v3 == 0)
        if (v4) {
            var v5: String = ""
            v5 = "no"
            return SpiralTuple0(0u, v5, false)
        } else {
            return SpiralTuple0(v0, v1, v2)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: UInt = 0u
    v0 = 4000000000u
    var v1: String = ""
    v1 = "hi"
    var v2: Boolean = false
    v2 = true
    var v3: (Int) -> SpiralTuple0 = { _: Int -> throw RuntimeException() }
    v3 = f_c0(v0, v1, v2)
    var v4: UInt = 0u
    var v5: String = ""
    var v6: Boolean = false
    val spiral_tuple335 = v3(1)
    v4 = spiral_tuple335.v0
    v5 = spiral_tuple335.v1
    v6 = spiral_tuple335.v2
    var v7: Boolean = false
    v7 = (v4 == 4000000000u)
    var v9: Boolean = false
    if (v7) {
        var v8: Boolean = false
        v8 = (v5 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    var v10: Boolean = false
    v10 = (v9 && v6)
    if (v10) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
