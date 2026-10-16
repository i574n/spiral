sealed interface US0 { val tag: Int }
class US0_Zero : US0 { override val tag: Int = 0 }
class US0_One : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    var v0: US0 = US0_Zero()
    v0 = US0_Zero()
    var v2: Boolean = false
    when (v0.tag) {
        1 -> {
            v2 = false
        }
        0 -> {
            v2 = true
        }
        else -> throw RuntimeException()
    }
    if (v2) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
