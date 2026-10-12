class SpiralTuple0(val v0: Double, val v1: Double)
fun sp_method0(p0: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        return SpiralTuple0(0.0, 0.0)
    } else {
        return SpiralTuple0(1.5, 2.5)
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Double = 0.0
    var v2: Double = 0.0
    val spiral_tuple111 = sp_method0(v0)
    v1 = spiral_tuple111.v0
    v2 = spiral_tuple111.v1
    var v3: Boolean = false
    v3 = (v1 == 1.5)
    var v5: Boolean = false
    if (v3) {
        var v4: Boolean = false
        v4 = (v2 == 2.5)
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
fun main() {
    System.exit(spiral_main())
}
