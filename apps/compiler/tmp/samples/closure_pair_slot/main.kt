sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 1 }
class SpiralTuple0(val v0: US0, val v1: Int)
fun f_c0(v0: Int): (Int) -> SpiralTuple0 {
    fun body(v1: Int): SpiralTuple0 {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            var v3: US0 = US0_None()
            v3 = US0_None()
            return SpiralTuple0(v3, 0)
        } else {
            var v4: US0 = US0_None()
            v4 = US0_Some(v0)
            return SpiralTuple0(v4, v0)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: (Int) -> SpiralTuple0 = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: US0 = US0_None()
    var v3: Int = 0
    val spiral_tuple205 = v1(1)
    v2 = spiral_tuple205.v0
    v3 = spiral_tuple205.v1
    when (v2.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v4: Int = (v2 as US0_Some).f0
            var v5: Boolean = false
            v5 = (v4 == 7)
            var v7: Boolean = false
            if (v5) {
                var v6: Boolean = false
                v6 = (v3 == 7)
                v7 = v6
            } else {
                v7 = false
            }
            if (v7) {
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
