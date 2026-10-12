class Heap0(val l0: Int)
sealed interface US0 { val tag: Int }
class US0_Missing : US0 { override val tag: Int = 0 }
data class US0_Box(val f0: Heap0) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Heap0 = Heap0(0)
    v1 = Heap0(v0)
    var v2: Boolean = false
    v2 = true
    var v5: US0 = US0_Missing()
    if (v2) {
        v5 = US0_Box(v1)
    } else {
        v5 = US0_Missing()
    }
    when (v5.tag) {
        1 -> {
            var v6: Heap0 = (v5 as US0_Box).f0
            var v7: Int = 0
            v7 = v6.l0
            var v8: Boolean = false
            v8 = (v7 == 7)
            if (v8) {
                return 0
            } else {
                return 1
            }
        }
        0 -> {
            return 1
        }
        else -> throw RuntimeException()
    }
}
fun main() {
    System.exit(spiral_main())
}
