sealed interface US0 { val tag: Int }
object US0_North : US0 { override val tag: Int = 0 }
object US0_East : US0 { override val tag: Int = 1 }
object US0_South : US0 { override val tag: Int = 2 }
object US0_West : US0 { override val tag: Int = 3 }
fun spiral_main(): Int {
    val v0: US0 = US0_North
    var v8: US0 = US0_North
    when (v0.tag) {
        1 -> {
            v8 = US0_South
        }
        0 -> {
            v8 = US0_East
        }
        2 -> {
            v8 = US0_West
        }
        3 -> {
            v8 = US0_North
        }
        else -> throw RuntimeException()
    }
    var v16: US0 = US0_North
    when (v8.tag) {
        1 -> {
            v16 = US0_South
        }
        0 -> {
            v16 = US0_East
        }
        2 -> {
            v16 = US0_West
        }
        3 -> {
            v16 = US0_North
        }
        else -> throw RuntimeException()
    }
    val v17: US0 = US0_South
    var v18: Boolean = false
    when (if (v16.tag == v17.tag) v16.tag else -1) {
        1 -> {
            v18 = true
        }
        0 -> {
            v18 = true
        }
        2 -> {
            v18 = true
        }
        3 -> {
            v18 = true
        }
        else -> {
            v18 = false
        }
    }
    var v19: Int = 0
    if (v18) {
        v19 = 100
    } else {
        v19 = 0
    }
    var v21: Int = 0
    when (v0.tag) {
        1 -> {
            v21 = 2
        }
        0 -> {
            v21 = 1
        }
        else -> {
            v21 = 7
        }
    }
    var v23: Int = 0
    when (v8.tag) {
        1 -> {
            v23 = 2
        }
        0 -> {
            v23 = 1
        }
        else -> {
            v23 = 7
        }
    }
    val v24: Int = (v23 * 3)
    val v25: Int = (v21 + v24)
    var v27: Int = 0
    when (v16.tag) {
        1 -> {
            v27 = 2
        }
        0 -> {
            v27 = 1
        }
        else -> {
            v27 = 7
        }
    }
    val v28: Int = (v27 * 9)
    val v29: Int = (v25 + v28)
    val v30: Int = (v29 + v19)
    return v30
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
