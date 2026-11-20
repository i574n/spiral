fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    v0 = Array(4) { 0 }
    v0[0] = 2
    v0[1] = 3
    v0[2] = 5
    v0[3] = 7
    val v1: Int = 1
    v0[v1] = 11
    val v2: Int = v0[0]
    val v3: Int = v0[1]
    val v4: Int = v0[2]
    val v5: Int = v0[3]
    val v6: Int = (v2 + v3)
    val v7: Int = (v6 + v4)
    val v8: Int = (v7 + v5)
    val v9: Int = (v8 - 25)
    return v9
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
