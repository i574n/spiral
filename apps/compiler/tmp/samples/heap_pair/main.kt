class Heap0(val l0: Int, val l1: Int)
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    val v2: Heap0 = Heap0(v0, v1)
    var v3: Int = 0
    var v4: Int = 0
    v3 = v2.l0
    v4 = v2.l1
    val v5: Int = (v3 + v4)
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
