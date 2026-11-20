fun spiral_main(): Int {
    val v0: Int = 2
    var v1: Array<Array<Int>> = emptyArray<Array<Int>>()
    v1 = Array(v0) { emptyArray<Int>() }
    var v2: Array<Int> = emptyArray<Int>()
    v2 = Array(v0) { 0 }
    var v3: Array<Int> = emptyArray<Int>()
    v3 = Array(v0) { 0 }
    v2[0] = 3
    v2[1] = 4
    v3[0] = 5
    v3[1] = 6
    v1[0] = v2
    v1[1] = v3
    val v4: Array<Int> = v1[0]
    val v5: Array<Int> = v1[1]
    val v6: Int = v4[0]
    val v7: Int = v4[1]
    val v8: Int = (v6 + v7)
    val v9: Int = v5[0]
    val v10: Int = (v8 + v9)
    val v11: Int = v5[1]
    val v12: Int = (v10 + v11)
    val v13: Int = (v12 - 18)
    return v13
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
