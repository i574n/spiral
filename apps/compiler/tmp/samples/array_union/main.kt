sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<US0> = emptyArray<US0>()
    v1 = Array(v0) { US0_None() }
    var v2: Int = 0
    v2 = 7
    var v3: US0 = US0_None()
    v3 = US0_Some(v2)
    v1[0] = v3
    var v4: US0 = US0_None()
    v4 = US0_None()
    v1[1] = v4
    var v5: US0 = US0_None()
    v5 = v1[0]
    when (v5.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v6: Int = (v5 as US0_Some).f0
            var v7: US0 = US0_None()
            v7 = v1[1]
            when (v7.tag) {
                0 -> {
                    var v8: Boolean = false
                    v8 = (v6 == 7)
                    if (v8) {
                        return 0
                    } else {
                        return 1
                    }
                }
                1 -> {
                    var v10: Int = (v7 as US0_Some).f0
                    return 1
                }
                else -> throw RuntimeException()
            }
        }
        else -> throw RuntimeException()
    }
}
fun main() {
    System.exit(spiral_main())
}
