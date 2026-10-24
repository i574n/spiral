class Heap0(val l0: Int)
sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 1 }
class SpiralTuple0(val v0: US0, val v1: Heap0)
fun sp_method0(p0: Int, p1: Heap0): SpiralTuple0 {
    var v0: Int = p0
    var v1: Heap0 = p1
    var v2: US0 = US0_None
    v2 = US0_Some(v0)
    return SpiralTuple0(v2, v1)
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    var v2: Heap0 = Heap0(0)
    v2 = Heap0(v1)
    var v3: US0 = US0_None
    var v4: Heap0 = Heap0(0)
    val spiral_tuple200 = sp_method0(v0, v2)
    v3 = spiral_tuple200.v0
    v4 = spiral_tuple200.v1
    when (v3.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v5: Int = (v3 as US0_Some).f0
            val v6: Int = v4.l0
            val v7: Int = (v5 + v6)
            val v8: Boolean = (v7 == 7)
            if (v8) {
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
