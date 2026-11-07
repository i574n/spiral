class Heap0(val l0: Array<Float>, val l1: Int)
fun spiral_main(): Int {
    var v0: Array<Float> = emptyArray<Float>()
    v0 = Array(1) { 0.0f }
    val v1: Float = 1.5f
    v0[0] = v1
    val v2: Int = 7
    val v3: Heap0 = Heap0(v0, v2)
    var v4: Array<Float> = emptyArray<Float>()
    var v5: Int = 0
    v4 = v3.l0
    v5 = v3.l1
    val v6: Float = v4[0]
    val v7: Boolean = (v6 == 1.5f)
    var v9: Boolean = false
    if (v7) {
        val v8: Boolean = (v5 == 7)
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
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
