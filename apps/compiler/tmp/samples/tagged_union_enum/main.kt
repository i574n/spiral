sealed interface US0 { val tag: Int }
class US0_Cold : US0 { override val tag: Int = 0 }
class US0_Warm : US0 { override val tag: Int = 1 }
class US0_Hot : US0 { override val tag: Int = 2 }
class US0_Done : US0 { override val tag: Int = 3 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            return 1
        }
        3 -> {
            return 4
        }
        2 -> {
            return 3
        }
        1 -> {
            return 2
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Boolean = false
    v1 = (v0 == 0)
    var v10: US0 = US0_Cold()
    if (v1) {
        v10 = US0_Cold()
    } else {
        var v3: Boolean = false
        v3 = (v0 == 1)
        if (v3) {
            v10 = US0_Warm()
        } else {
            var v5: Boolean = false
            v5 = (v0 == 2)
            if (v5) {
                v10 = US0_Hot()
            } else {
                v10 = US0_Done()
            }
        }
    }
    var v11: Int = 0
    v11 = sp_score_0(v10)
    var v12: Int = 0
    v12 = (v11 - 4)
    return v12
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
