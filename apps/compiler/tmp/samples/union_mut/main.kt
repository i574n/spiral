class Mut0(var l0: Int)
sealed interface US0 { val tag: Int }
class US0_Missing : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Mut0) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    var v0: Mut0 = Mut0(0)
    v0 = Mut0(1)
    var v1: Boolean = false
    v1 = true
    var v4: US0 = US0_Missing()
    if (v1) {
        v4 = US0_Held(v0)
    } else {
        v4 = US0_Missing()
    }
    when (v4.tag) {
        1 -> {
            var v5: Mut0 = (v4 as US0_Held).f0
            v5.l0 = 7
            var v6: Int = 0
            v6 = v5.l0
            var v7: Boolean = false
            v7 = (v6 == 7)
            if (v7) {
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
