sealed interface US0 { val tag: Int }
data class US0_Living(val f0: Int, val f1: Int) : US0 { override val tag: Int = 0 }
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Array<US0> = emptyArray<US0>()
    v1 = Array(v0) { US0_Living(0, 0) }
    return 0
}
fun main() {
    System.exit(spiral_main())
}
