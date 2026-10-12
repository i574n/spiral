class Heap0(val l0: Array<Float>, val l1: Int)
fun spiral_main(): Int {
    var v0: Array<Float> = emptyArray<Float>()
    v0 = Array(1) { 0.0f }
    var v1: Float = 0.0f
    v1 = 1.5f
    v0[0] = v1
    var v2: Int = 0
    v2 = 7
    var v3: Heap0 = Heap0(emptyArray<Float>(), 0)
    v3 = Heap0(v0, v2)
    var v4: Array<Float> = emptyArray<Float>()
    var v5: Int = 0
    v4 = v3.l0
    v5 = v3.l1
    var v6: Float = 0.0f
    v6 = v4[0]
    var v7: Boolean = false
    v7 = (v6 == 1.5f)
    var v9: Boolean = false
    if (v7) {
        var v8: Boolean = false
        v8 = (v5 == 7)
        v9 = v8
    } else {
        v9 = false
    }
    if (v9) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
