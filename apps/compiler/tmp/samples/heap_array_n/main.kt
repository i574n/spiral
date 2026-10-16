class Heap0(val l0: Array<Int>, val l1: Int)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Int = 0
    v1 = 4
    var v2: Array<Int> = emptyArray<Int>()
    v2 = Array(1) { 0 }
    v2[0] = v0
    var v3: Heap0 = Heap0(emptyArray<Int>(), 0)
    v3 = Heap0(v2, v1)
    var v4: Array<Int> = emptyArray<Int>()
    var v5: Int = 0
    v4 = v3.l0
    v5 = v3.l1
    var v6: Int = 0
    v6 = v4[0]
    var v7: Int = 0
    v7 = (v6 + v5)
    var v8: Boolean = false
    v8 = (v7 == 7)
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
