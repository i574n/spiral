class Heap0(val l0: Int)
sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 1 }
class SpiralTuple0(val v0: US0, val v1: Heap0)
fun f_c0(v0: Int, v1: Heap0): (Int) -> SpiralTuple0 {
    fun body(v2: Int): SpiralTuple0 {
        var v3: Boolean = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: US0 = US0_None()
            v4 = US0_None()
            return SpiralTuple0(v4, v1)
        } else {
            var v5: US0 = US0_None()
            v5 = US0_Some(v0)
            return SpiralTuple0(v5, v1)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Int = 0
    v1 = 4
    var v2: Heap0 = Heap0(0)
    v2 = Heap0(v1)
    var v3: (Int) -> SpiralTuple0 = { _: Int -> throw RuntimeException() }
    v3 = f_c0(v0, v2)
    var v4: US0 = US0_None()
    var v5: Heap0 = Heap0(0)
    val spiral_tuple301 = v3(1)
    v4 = spiral_tuple301.v0
    v5 = spiral_tuple301.v1
    when (v4.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v6: Int = (v4 as US0_Some).f0
            var v7: Int = 0
            v7 = v5.l0
            var v8: Int = 0
            v8 = (v6 + v7)
            var v9: Boolean = false
            v9 = (v8 == 7)
            if (v9) {
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
