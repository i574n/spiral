class SpiralTuple0(val v0: Int, val v1: UInt, val v2: Float)
fun sp_method1(p0: Int, p1: UInt, p2: Float): SpiralTuple0 {
    var v0: Int = p0
    var v1: UInt = p1
    var v2: Float = p2
    return SpiralTuple0(v0, v1, v2)
}
fun sp_method0(p0: Int, p1: UInt, p2: Float): Int {
    var v0: Int = p0
    var v1: UInt = p1
    var v2: Float = p2
    var v3: Int = 0
    var v4: UInt = 0u
    var v5: Float = 0.0f
    val spiral_tuple192 = sp_method1(v0, v1, v2)
    v3 = spiral_tuple192.v0
    v4 = spiral_tuple192.v1
    v5 = spiral_tuple192.v2
    var v6: Boolean = false
    v6 = (v3 == 2)
    var v8: Boolean = false
    if (v6) {
        var v7: Boolean = false
        v7 = (v4 == 3u)
        v8 = v7
    } else {
        v8 = false
    }
    var v10: Boolean = false
    if (v8) {
        var v9: Boolean = false
        v9 = (v5 == 1.5f)
        v10 = v9
    } else {
        v10 = false
    }
    if (v10) {
        return 0
    } else {
        return 1
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: UInt = 0u
    v1 = 3u
    var v2: Float = 0.0f
    v2 = 1.5f
    return sp_method0(v0, v1, v2)
}
fun main() {
    System.exit(spiral_main())
}
