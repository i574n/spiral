class SpiralTuple0(val v0: Byte, val v1: Byte)
fun f_c0(v0: Byte): (Int) -> SpiralTuple0 {
    fun body(v1: Int): SpiralTuple0 {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            return SpiralTuple0((0).toByte(), (0).toByte())
        } else {
            return SpiralTuple0(v0, (7).toByte())
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Byte = (0).toByte()
    v0 = (100).toByte()
    var v1: (Int) -> SpiralTuple0 = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: Byte = (0).toByte()
    var v3: Byte = (0).toByte()
    val spiral_tuple245 = v1(1)
    v2 = spiral_tuple245.v0
    v3 = spiral_tuple245.v1
    var v4: Boolean = false
    v4 = (v2 == (100).toByte())
    var v6: Boolean = false
    if (v4) {
        var v5: Boolean = false
        v5 = (v3 == (7).toByte())
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
