fun spiral_main(): Int {
    val v0: Int = -8
    val v1: Int = 3
    val v2: Int = 1
    val v3: UInt = 4294967295u
    val v4: Int = 4
    val v5: Int = (v0 shr v2)
    val v6: Int = (v1 shl v2)
    val v7: UInt = (v3 shr v4)
    val v8: UInt = (v3 shl v2)
    val v9: Boolean = (v5 == -4)
    if (v9) {
        val v10: Boolean = (v6 == 6)
        if (v10) {
            val v11: Boolean = (v7 == 268435455u)
            if (v11) {
                val v12: Boolean = (v8 == 4294967294u)
                if (v12) {
                    return 0
                } else {
                    return 4
                }
            } else {
                return 3
            }
        } else {
            return 2
        }
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
