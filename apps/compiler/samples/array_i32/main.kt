fun spiral_main(): Int {
    val v0: Int = 4
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 10
    v1[1] = 20
    v1[2] = 30
    val v2: Int = v1[0]
    val v3: Int = v1[1]
    val v4: Int = (v2 + v3)
    v1[3] = v4
    val v5: Int = v1[2]
    val v6: Int = v1[3]
    val v7: Int = (v5 + v6)
    val v8: Int = v1.size
    val v9: Boolean = (v8 == v0)
    var v11: Boolean = false
    if (v9) {
        val v10: Boolean = (v7 == 60)
        v11 = v10
    } else {
        v11 = false
    }
    if (v11) {
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
