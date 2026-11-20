sealed interface US0 { val tag: Int }
object US0_First : US0 { override val tag: Int = 1 }
object US0_Second : US0 { override val tag: Int = 2 }
fun spiral_main(): Int {
    val v0: US0 = US0_Second
    val v1: Int = (v0).tag
    val v2: Int = (v1 * 10)
    val v3: Int = (v2 + 2)
    return v3
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
