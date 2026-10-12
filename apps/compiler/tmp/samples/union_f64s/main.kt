sealed interface US0 { val tag: Int }
class US0_Missing : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Array<Double>) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    var v0: Array<Double> = emptyArray<Double>()
    v0 = Array(1) { 0.0 }
    var v1: Double = 0.0
    v1 = 1.5
    v0[0] = v1
    var v2: Boolean = false
    v2 = true
    var v5: US0 = US0_Missing()
    if (v2) {
        v5 = US0_Held(v0)
    } else {
        v5 = US0_Missing()
    }
    when (v5.tag) {
        1 -> {
            var v6: Array<Double> = (v5 as US0_Held).f0
            var v7: Double = 0.0
            v7 = v6[0]
            var v8: Boolean = false
            v8 = (v7 == 1.5)
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
