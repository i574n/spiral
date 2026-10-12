class Heap0(val l0: Int)
class SpiralTuple0(val v0: Heap0, val v1: Heap0)
fun sp_method0(p0: Heap0, p1: Heap0): SpiralTuple0 {
    var v0: Heap0 = p0
    var v1: Heap0 = p1
    return SpiralTuple0(v0, v1)
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Int = 0
    v1 = 4
    var v2: Heap0 = Heap0(0)
    v2 = Heap0(v0)
    var v3: Heap0 = Heap0(0)
    v3 = Heap0(v1)
    var v4: Heap0 = Heap0(0)
    var v5: Heap0 = Heap0(0)
    val spiral_tuple252 = sp_method0(v2, v3)
    v4 = spiral_tuple252.v0
    v5 = spiral_tuple252.v1
    var v6: Int = 0
    v6 = v4.l0
    var v7: Int = 0
    v7 = v5.l0
    var v8: Int = 0
    v8 = (v6 + v7)
    var v9: Boolean = false
    v9 = (v8 == 7)
    if (v9) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
