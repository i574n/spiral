class SpiralTuple0(val v0: Int, val v1: Boolean)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Array<SpiralTuple0> = emptyArray<SpiralTuple0>()
    v1 = Array(v0) { SpiralTuple0(0, false) }
    var v2: Int = 0
    v2 = 4
    v1[0] = SpiralTuple0(v2, true)
    v1[1] = SpiralTuple0(7, false)
    v1[2] = SpiralTuple0(9, true)
    var v3: Int = 0
    var v4: Boolean = false
    val spiral_tuple358 = v1[0]
    v3 = spiral_tuple358.v0
    v4 = spiral_tuple358.v1
    var v5: Int = 0
    var v6: Boolean = false
    val spiral_tuple499 = v1[1]
    v5 = spiral_tuple499.v0
    v6 = spiral_tuple499.v1
    var v7: Int = 0
    v7 = 2
    var v8: Int = 0
    var v9: Boolean = false
    val spiral_tuple673 = v1[v7]
    v8 = spiral_tuple673.v0
    v9 = spiral_tuple673.v1
    var v10: Int = 0
    if (v4) {
        v10 = 1
    } else {
        v10 = 0
    }
    var v11: Int = 0
    if (v6) {
        v11 = 10
    } else {
        v11 = 0
    }
    var v12: Int = 0
    if (v9) {
        v12 = 100
    } else {
        v12 = 0
    }
    var v13: Int = 0
    v13 = (v3 + v5)
    var v14: Int = 0
    v14 = (v13 + v8)
    var v15: Int = 0
    v15 = (v14 + v10)
    var v16: Int = 0
    v16 = (v15 + v11)
    var v17: Int = 0
    v17 = (v16 + v12)
    return v17
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
