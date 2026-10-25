sealed interface US0 { val tag: Int }
class US0_Empty : US0 { override val tag: Int = 0 }
data class US0_Full(val f0: Int) : US0 { override val tag: Int = 1 }
fun sp_pick_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            return 0
        }
        1 -> {
            var v1: Int = (v0 as US0_Full).f0
            return v1
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v3: US0 = US0_Empty()
    if (v0) {
        v3 = US0_Full(7)
    } else {
        v3 = US0_Empty()
    }
    var v6: US0 = US0_Empty()
    if (v0) {
        v6 = US0_Empty()
    } else {
        v6 = US0_Full(1)
    }
    var v7: Int = 0
    v7 = sp_pick_0(v3)
    var v8: Boolean = false
    v8 = (v7 == 7)
    var v11: Boolean = false
    if (v8) {
        var v9: Int = 0
        v9 = sp_pick_0(v6)
        var v10: Boolean = false
        v10 = (v9 == 0)
        v11 = v10
    } else {
        v11 = false
    }
    if (v11) {
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
