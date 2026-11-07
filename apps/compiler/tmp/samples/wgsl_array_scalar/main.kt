fun spiral_main(): Int {
    val v0: Int = 5
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 0
    v1[1] = 1
    v1[2] = 4
    val v2: Int = 3
    v1[v2] = 9
    val v3: Int = (v2 + 1)
    v1[v3] = 16
    var v4: Array<Boolean> = emptyArray<Boolean>()
    v4 = Array(3) { false }
    v4[0] = false
    v4[1] = true
    v4[2] = false
    val v5: Int = v1[1]
    val v6: Int = v1[2]
    val v7: Int = (v5 + v6)
    val v8: Int = v1[3]
    val v9: Int = (v7 + v8)
    val v10: Int = v1[4]
    val v11: Int = (v9 + v10)
    val v12: Boolean = v4[1]
    var v15: Int = 0
    if (v12) {
        val v13: Boolean = v4[0]
        if (v13) {
            v15 = 0
        } else {
            v15 = 100
        }
    } else {
        v15 = 0
    }
    val v16: Int = (v11 + v15)
    val v17: Int = v1.size
    val v18: Int = (v16 + v17)
    return v18
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
