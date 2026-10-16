fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
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
    var v4: Array<Int> = emptyArray<Int>()
    v4 = v1[0]
    var v5: Array<Int> = emptyArray<Int>()
    v5 = v1[1]
    var v6: Int = 0
    v6 = v4[0]
    var v7: Int = 0
    v7 = v4[1]
    var v8: Int = 0
    v8 = (v6 + v7)
    var v9: Int = 0
    v9 = v5[0]
    var v10: Int = 0
    v10 = (v8 + v9)
    var v11: Int = 0
    v11 = v5[1]
    var v12: Int = 0
    v12 = (v10 + v11)
    var v13: Int = 0
    v13 = (v12 - 18)
    return v13
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
