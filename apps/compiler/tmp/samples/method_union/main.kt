sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 1 }
fun sp_method0(p0: Int): US0 {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        return US0_None
    } else {
        return US0_Some(v0)
    }
}
fun spiral_main(): Int {
    val v0: Int = 7
    var v1: US0 = US0_None
    v1 = sp_method0(v0)
    when (v1.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v2: Int = (v1 as US0_Some).f0
            val v3: Boolean = (v2 == 7)
            if (v3) {
                return 0
            } else {
                return 1
            }
        }
        else -> throw RuntimeException()
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
