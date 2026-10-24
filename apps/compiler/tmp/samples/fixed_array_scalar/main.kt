fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    v0 = Array(3) { 0 }
    v0[0] = 2
    v0[1] = 3
    v0[2] = 5
    val v1: Int = v0[0]
    val v2: Int = v0[1]
    val v3: Int = v0[2]
    val v4: Int = (v1 + v2)
    val v5: Int = (v4 + v3)
    val v6: Int = (v5 - 10)
    return v6
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
