class SpiralTuple0(val v0: Int, val v1: Boolean)
fun spiral_main(): Int {
    val v0: Int = 3
    var v1: Array<SpiralTuple0> = emptyArray<SpiralTuple0>()
    v1 = Array(v0) { SpiralTuple0(0, false) }
    val v2: Int = 4
    v1[0] = SpiralTuple0(v2, true)
    v1[1] = SpiralTuple0(7, false)
    v1[2] = SpiralTuple0(9, true)
    var v3: Int = 0
    var v4: Boolean = false
    val spiral_tuple346 = v1[0]
    v3 = spiral_tuple346.v0
    v4 = spiral_tuple346.v1
    var v5: Int = 0
    var v6: Boolean = false
    val spiral_tuple482 = v1[1]
    v5 = spiral_tuple482.v0
    v6 = spiral_tuple482.v1
    val v7: Int = 2
    var v8: Int = 0
    var v9: Boolean = false
    val spiral_tuple649 = v1[v7]
    v8 = spiral_tuple649.v0
    v9 = spiral_tuple649.v1
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
    val v13: Int = (v3 + v5)
    val v14: Int = (v13 + v8)
    val v15: Int = (v14 + v10)
    val v16: Int = (v15 + v11)
    val v17: Int = (v16 + v12)
    return v17
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
