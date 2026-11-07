fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    v0 = Array(4) { 0 }
    v0[0] = 7
    v0[1] = 7
    v0[2] = 7
    v0[3] = 7
    val v1: Int = v0[3]
    var v2: Array<Int> = emptyArray<Int>()
    v2 = Array(4) { 0 }
    v2[0] = 5
    val v3: Int = v2[3]
    val v4: Int = v2[0]
    val v5: Int = (v3 * 100)
    val v6: Int = (v5 + v4)
    val v7: Int = (v1 - 7)
    val v8: Int = (v6 + v7)
    return v8
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
