class Heap0(val l0: Array<Int>)
fun spiral_main(): Int {
    val v0: Int = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    val v2: Int = 7
    v1[0] = v2
    val v3: Heap0 = Heap0(v1)
    val v4: Array<Int> = v3.l0
    val v5: Int = v4[0]
    val v6: Boolean = (v5 == 7)
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
