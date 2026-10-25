class Heap0(val l0: Array<Int>)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    var v2: Int = 0
    v2 = 7
    v1[0] = v2
    var v3: Heap0 = Heap0(emptyArray<Int>())
    v3 = Heap0(v1)
    var v4: Array<Int> = emptyArray<Int>()
    v4 = v3.l0
    var v5: Int = 0
    v5 = v4[0]
    var v6: Boolean = false
    v6 = (v5 == 7)
    if (v6) {
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
