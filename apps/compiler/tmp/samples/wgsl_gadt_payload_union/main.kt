sealed interface US1 { val tag: Int }
data class US1_Living(val f0: Int, val f1: Int) : US1 { override val tag: Int = 0 }
sealed interface US2 { val tag: Int }
data class US2_Fallen(val f0: Int) : US2 { override val tag: Int = 1 }
sealed interface US0 { val tag: Int }
data class US0_Survived(val f0: US1) : US0 { override val tag: Int = 0 }
data class US0_Slain(val f0: US2) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    val v0: Int = 60
    val v1: Boolean = (v0 > 0)
    var v6: US0 = US0_Survived(US1_Living(0, 0))
    if (v1) {
        val v2: US1 = US1_Living(v0, 100)
        v6 = US0_Survived(v2)
    } else {
        val v4: US2 = US2_Fallen(100)
        v6 = US0_Slain(v4)
    }
    when (v6.tag) {
        1 -> {
            var v13: US2 = (v6 as US0_Slain).f0
            return 2
        }
        0 -> {
            var v7: US1 = (v6 as US0_Survived).f0
            when (v7.tag) {
                0 -> {
                    var v8: Int = (v7 as US1_Living).f0
                    var v9: Int = (v7 as US1_Living).f1
                    val v10: Boolean = (v8 == 60)
                    if (v10) {
                        return 0
                    } else {
                        return 1
                    }
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
