fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    v0 = Array(4) { 0 }
    v0[0] = 2
    v0[1] = 3
    v0[2] = 5
    v0[3] = 7
    var v1: Int = 0
    v1 = 2
    var v2: Int = 0
    v2 = v0[v1]
    var v3: Int = 0
    v3 = (v2 - 5)
    return v3
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
