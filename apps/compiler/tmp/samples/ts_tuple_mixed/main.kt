class SpiralTuple0(val v0: Boolean, val v1: Float, val v2: Int)
fun sp_method0(p0: Float): SpiralTuple0 {
    var v0: Float = p0
    var v1: Boolean = false
    v1 = (v0 >= 3.5f)
    return SpiralTuple0(v1, v0, 7)
}
fun sp_method1(p0: Boolean, p1: Float, p2: Int): Int {
    var v0: Boolean = p0
    var v1: Float = p1
    var v2: Int = p2
    if (v0) {
        var v3: Boolean = false
        v3 = (v1 >= 3.5f)
        if (v3) {
            var v4: Int = 0
            v4 = (v2 - 7)
            return v4
        } else {
            return 1
        }
    } else {
        return 2
    }
}
fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = 4.0f
    var v1: Boolean = false
    var v2: Float = 0.0f
    var v3: Int = 0
    val spiral_tuple143 = sp_method0(v0)
    v1 = spiral_tuple143.v0
    v2 = spiral_tuple143.v1
    v3 = spiral_tuple143.v2
    return sp_method1(v1, v2, v3)
}
fun main() {
    System.exit(spiral_main())
}
