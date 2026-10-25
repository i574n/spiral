sealed interface UH1 { val tag: Int }
data class UH1_B(val f0: UH0) : UH1 { override val tag: Int = 0 }
class UH1_StopB : UH1 { override val tag: Int = 1 }
sealed interface UH0 { val tag: Int }
data class UH0_A(val f0: UH1) : UH0 { override val tag: Int = 0 }
class UH0_StopA : UH0 { override val tag: Int = 1 }
object UH0_Zero : UH0 { override val tag: Int = -1 }
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v5: UH0 = UH0_A(UH1_B(UH0_Zero))
    if (v0) {
        var v1: UH0 = UH0_A(UH1_B(UH0_Zero))
        v1 = UH0_StopA()
        var v2: UH1 = UH1_B(UH0_Zero)
        v2 = UH1_B(v1)
        v5 = UH0_A(v2)
    } else {
        v5 = UH0_StopA()
    }
    when (v5.tag) {
        0 -> {
            var v6: UH1 = (v5 as UH0_A).f0
            return 0
        }
        1 -> {
            return 0
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
