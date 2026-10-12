class SpiralTuple0(val v0: Int, val v1: Int, val v2: Int, val v3: Int)
fun sp_method0(p0: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = 0
    v1 = (v0 + 1)
    var v2: Int = 0
    v2 = (v0 + 2)
    var v3: Int = 0
    v3 = (v0 + 3)
    return SpiralTuple0(v0, v1, v2, v3)
}
fun sp_method1(p0: Int, p1: Int, p2: Int, p3: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = p3
    var v4: Int = 0
    v4 = (v0 + v1)
    var v5: Int = 0
    v5 = (v4 + v2)
    var v6: Int = 0
    v6 = (v5 + v3)
    var v7: Int = 0
    v7 = (v6 - 10)
    return v7
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    var v1: Int = 0
    var v2: Int = 0
    var v3: Int = 0
    var v4: Int = 0
    val spiral_tuple143 = sp_method0(v0)
    v1 = spiral_tuple143.v0
    v2 = spiral_tuple143.v1
    v3 = spiral_tuple143.v2
    v4 = spiral_tuple143.v3
    return sp_method1(v1, v2, v3, v4)
}
fun main() {
    System.exit(spiral_main())
}
