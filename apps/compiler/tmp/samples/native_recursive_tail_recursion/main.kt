sealed interface UH0 { val tag: Int }
class UH0_Empty : UH0 { override val tag: Int = 0 }
data class UH0_Box(val f0: Int, val f1: UH0) : UH0 { override val tag: Int = 1 }
fun sp_method2(p0: Int): UH0 {
    var v0: Int = p0
    var v1: Int = 0
    v1 = (v0 - 1)
    var v2: Boolean = false
    v2 = (v1 == 0)
    if (v2) {
        var v3: UH0 = UH0_Empty()
        v3 = UH0_Empty()
        return UH0_Box(7, v3)
    } else {
        return sp_method1(v1)
    }
}
fun sp_method1(p0: Int): UH0 {
    var v0: Int = p0
    var v1: Int = 0
    v1 = (v0 - 1)
    var v2: Boolean = false
    v2 = (v1 == 0)
    if (v2) {
        var v3: UH0 = UH0_Empty()
        v3 = UH0_Empty()
        return UH0_Box(11, v3)
    } else {
        return sp_method2(v1)
    }
}
fun sp_method0(): UH0 {
    var v0: Int = 0
    v0 = 1000000
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: UH0 = UH0_Empty()
        v2 = UH0_Empty()
        return UH0_Box(7, v2)
    } else {
        return sp_method1(v0)
    }
}
fun spiral_main(): Int {
    var v0: UH0 = UH0_Empty()
    v0 = sp_method0()
    when (v0.tag) {
        1 -> {
            var v1: Int = (v0 as UH0_Box).f0
            var v2: UH0 = (v0 as UH0_Box).f1
            var v3: Boolean = false
            v3 = (v1 == 7)
            if (v3) {
                return 0
            } else {
                return 3
            }
        }
        0 -> {
            return 1
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
