fun spiral_main(): Int {
    val v0: Int = 43
    val v1: Int = 15
    val v2: Int = 2
    val v3: Int = 5
    val v4: Int = (v0 and v1)
    val v5: Int = (v0 or v1)
    val v6: Int = (v0 xor v1)
    val v7: Int = (v0.inv())
    val v8: Int = (v7 and 255)
    val v9: Int = (1 shl v3)
    val v10: Int = (168 shr v2)
    val v11: Int = (v4 - 11)
    val v12: Int = (v10 + v11)
    val v13: Int = (v5 - 47)
    val v14: Int = (v12 + v13)
    val v15: Int = (v6 - 36)
    val v16: Int = (v14 + v15)
    val v17: Int = (v8 - 212)
    val v18: Int = (v16 + v17)
    val v19: Int = (v9 - 32)
    val v20: Int = (v18 + v19)
    return v20
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
