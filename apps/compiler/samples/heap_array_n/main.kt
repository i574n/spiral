class Heap0(val l0: Array<Int>, val l1: Int)
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    var v2: Array<Int> = emptyArray<Int>()
    v2 = Array(1) { 0 }
    v2[0] = v0
    val v3: Heap0 = Heap0(v2, v1)
    var v4: Array<Int> = emptyArray<Int>()
    var v5: Int = 0
    v4 = v3.l0
    v5 = v3.l1
    val v6: Int = v4[0]
    val v7: Int = (v6 + v5)
    val v8: Boolean = (v7 == 7)
    if (v8) {
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
