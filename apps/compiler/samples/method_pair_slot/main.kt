sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 1 }
class SpiralTuple0(val v0: US0, val v1: Int)
fun sp_method0(p0: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: US0 = US0_None
        v2 = US0_None
        return SpiralTuple0(v2, 0)
    } else {
        val v3: US0 = US0_Some(v0)
        return SpiralTuple0(v3, v0)
    }
}
fun spiral_main(): Int {
    val v0: Int = 7
    var v1: US0 = US0_None
    var v2: Int = 0
    val spiral_tuple103 = sp_method0(v0)
    v1 = spiral_tuple103.v0
    v2 = spiral_tuple103.v1
    when (v1.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v3: Int = (v1 as US0_Some).f0
            val v4: Boolean = (v3 == 7)
            var v6: Boolean = false
            if (v4) {
                val v5: Boolean = (v2 == 7)
                v6 = v5
            } else {
                v6 = false
            }
            if (v6) {
                return 0
            } else {
                return 1
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
