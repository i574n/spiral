sealed interface US0 { val tag: Int }
data class US0_Done(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_More(val f0: Int) : US0 { override val tag: Int = 1 }
fun sp_layers_0(p0: Int): Int {
    var v0: Int = p0
    val v1: Boolean = (v0 >= 5)
    var v4: US0 = US0_Done(0)
    if (v1) {
        v4 = US0_Done(v0)
    } else {
        v4 = US0_More(v0)
    }
    when (v4.tag) {
        0 -> {
            var v8: Int = (v4 as US0_Done).f0
            val v9: Int = (v8 * 2)
            return v9
        }
        1 -> {
            var v5: Int = (v4 as US0_More).f0
            val v6: Int = (v5 + 1)
            return sp_layers_0(v6)
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Int = 0
    return sp_layers_0(v0)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
