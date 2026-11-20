class Heap0(val l0: Int)
fun spiral_main(): Int {
    val v0: Int = 2
    var v1: Array<Heap0> = emptyArray<Heap0>()
    v1 = Array(v0) { Heap0(0) }
    val v2: Int = 4
    val v3: Int = 6
    val v4: Heap0 = Heap0(v2)
    v1[0] = v4
    val v5: Heap0 = Heap0(v3)
    v1[1] = v5
    val v6: Heap0 = v1[0]
    val v7: Int = v6.l0
    val v8: Heap0 = v1[1]
    val v9: Int = v8.l0
    val v10: Int = (v7 + v9)
    val v11: Boolean = (v10 == 10)
    if (v11) {
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
