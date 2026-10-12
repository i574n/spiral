sealed interface US0 { val tag: Int }
class US0_Missing : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Array<Int>) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    var v2: Int = 0
    v2 = 7
    v1[0] = v2
    var v3: Boolean = false
    v3 = true
    var v6: US0 = US0_Missing()
    if (v3) {
        v6 = US0_Held(v1)
    } else {
        v6 = US0_Missing()
    }
    when (v6.tag) {
        1 -> {
            var v7: Array<Int> = (v6 as US0_Held).f0
            var v8: Int = 0
            v8 = v7[0]
            var v9: Boolean = false
            v9 = (v8 == 7)
            if (v9) {
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
