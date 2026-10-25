sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    val v0: Int = 2
    var v1: Array<US0> = emptyArray<US0>()
    v1 = Array(v0) { US0_None }
    val v2: Int = 7
    val v3: US0 = US0_Some(v2)
    v1[0] = v3
    val v4: US0 = US0_None
    v1[1] = v4
    val v5: US0 = v1[0]
    when (v5.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v6: Int = (v5 as US0_Some).f0
            val v7: US0 = v1[1]
            when (v7.tag) {
                0 -> {
                    val v8: Boolean = (v6 == 7)
                    if (v8) {
                        return 0
                    } else {
                        return 1
                    }
                }
                1 -> {
                    var v10: Int = (v7 as US0_Some).f0
                    return 1
                }
                else -> throw RuntimeException()
            }
        }
        else -> throw RuntimeException()
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
