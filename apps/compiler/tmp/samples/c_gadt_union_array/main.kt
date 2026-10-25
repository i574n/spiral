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
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
