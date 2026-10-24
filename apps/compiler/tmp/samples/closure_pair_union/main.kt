sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 1 }
class SpiralTuple0(val v0: US0, val v1: US0)
fun f_c0(v0: Int): (Int) -> SpiralTuple0 {
    fun body(v1: Int): SpiralTuple0 {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            var v3: US0 = US0_None
            v3 = US0_None
            val v4: US0 = US0_None
            return SpiralTuple0(v3, v4)
        } else {
            var v5: US0 = US0_None
            v5 = US0_Some(v0)
            val v6: US0 = US0_None
            return SpiralTuple0(v5, v6)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: (Int) -> SpiralTuple0 = f_c0(v0)
    var v2: US0 = US0_None
    var v3: US0 = US0_None
    val spiral_tuple210 = v1(1)
    v2 = spiral_tuple210.v0
    v3 = spiral_tuple210.v1
    when (v2.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v4: Int = (v2 as US0_Some).f0
            when (v3.tag) {
                0 -> {
                    var v5: Boolean = false
                    v5 = (v4 == 7)
                    if (v5) {
                        return 0
                    } else {
                        return 1
                    }
                }
                1 -> {
                    var v7: Int = (v3 as US0_Some).f0
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
