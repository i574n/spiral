sealed interface US0 { val tag: Int }
data class US0_Done(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_More(val f0: Int) : US0 { override val tag: Int = 1 }
fun sp_layers_0(p0: Int): Int {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 >= 5)
    var v4: US0 = US0_Done(0)
    if (v1) {
        v4 = US0_Done(v0)
    } else {
        v4 = US0_More(v0)
    }
    when (v4.tag) {
        0 -> {
            var v8: Int = (v4 as US0_Done).f0
            var v9: Int = 0
            v9 = (v8 * 2)
            return v9
        }
        1 -> {
            var v5: Int = (v4 as US0_More).f0
            var v6: Int = 0
            v6 = (v5 + 1)
            return sp_layers_0(v6)
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 0
    return sp_layers_0(v0)
}
fun main() {
    System.exit(spiral_main())
}
