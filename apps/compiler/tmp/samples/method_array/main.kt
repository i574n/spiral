fun sp_method0(p0: Int): Array<Int> {
    var v0: Int = p0
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(1) { 0 }
    v1[0] = v0
    return v1
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Array<Int> = emptyArray<Int>()
    v1 = sp_method0(v0)
    var v2: Int = 0
    v2 = v1[0]
    var v3: Boolean = false
    v3 = (v2 == 7)
    if (v3) {
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
