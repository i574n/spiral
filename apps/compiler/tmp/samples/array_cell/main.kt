class Heap0(val l0: Int)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Heap0> = emptyArray<Heap0>()
    v1 = Array(v0) { Heap0(0) }
    var v2: Int = 0
    v2 = 4
    var v3: Int = 0
    v3 = 6
    var v4: Heap0 = Heap0(0)
    v4 = Heap0(v2)
    v1[0] = v4
    var v5: Heap0 = Heap0(0)
    v5 = Heap0(v3)
    v1[1] = v5
    var v6: Heap0 = Heap0(0)
    v6 = v1[0]
    var v7: Int = 0
    v7 = v6.l0
    var v8: Heap0 = Heap0(0)
    v8 = v1[1]
    var v9: Int = 0
    v9 = v8.l0
    var v10: Int = 0
    v10 = (v7 + v9)
    var v11: Boolean = false
    v11 = (v10 == 10)
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
