fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    v0 = Array(3) { 0 }
    v0[0] = 2
    v0[1] = 3
    v0[2] = 5
    var v1: Int = 0
    v1 = v0[0]
    var v2: Int = 0
    v2 = v0[1]
    var v3: Int = 0
    v3 = v0[2]
    var v4: Int = 0
    v4 = (v1 + v2)
    var v5: Int = 0
    v5 = (v4 + v3)
    var v6: Int = 0
    v6 = (v5 - 10)
    return v6
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
