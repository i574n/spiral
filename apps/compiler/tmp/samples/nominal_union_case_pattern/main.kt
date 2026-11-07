sealed interface US0 { val tag: Int }
object US0_Zero : US0 { override val tag: Int = 0 }
object US0_One : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    val v0: US0 = US0_Zero
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
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
