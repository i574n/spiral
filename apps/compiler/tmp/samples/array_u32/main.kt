fun spiral_main(): Int {
    val v0: Int = 3
    var v1: Array<UInt> = emptyArray<UInt>()
    v1 = Array(v0) { 0u }
    v1[0] = 4000000000u
    v1[1] = 1u
    val v2: UInt = v1[0]
    val v3: UInt = v1[1]
    val v4: UInt = (v2 + v3)
    val v5: Int = v1.size
    val v6: Boolean = (v5 == v0)
    var v8: Boolean = false
    if (v6) {
        val v7: Boolean = (v4 == 4000000001u)
        v8 = v7
    } else {
        v8 = false
    }
    if (v8) {
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
