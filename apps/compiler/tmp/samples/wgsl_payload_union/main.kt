sealed interface US0 { val tag: Int }
data class US0_Circle(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_Rect(val f0: Int, val f1: Int) : US0 { override val tag: Int = 1 }
object US0_Empty : US0 { override val tag: Int = 2 }
fun spiral_main(): Int {
    val v0: Int = 2
    val v1: US0 = US0_Circle(v0)
    val v2: Int = 3
    val v3: Int = 4
    val v4: US0 = US0_Rect(v2, v3)
    val v5: US0 = US0_Empty
    val v6: Int = 2
    val v7: US0 = US0_Circle(v6)
    var v18: Boolean = false
    when (if (v1.tag == v7.tag) v1.tag else -1) {
        0 -> {
            var v8: Int = (v1 as US0_Circle).f0
            var v9: Int = (v7 as US0_Circle).f0
            val v10: Boolean = (v8 == v9)
            v18 = v10
        }
        2 -> {
            v18 = true
        }
        1 -> {
            var v11: Int = (v1 as US0_Rect).f0
            var v12: Int = (v1 as US0_Rect).f1
            var v13: Int = (v7 as US0_Rect).f0
            var v14: Int = (v7 as US0_Rect).f1
            val v15: Boolean = (v11 == v13)
            if (v15) {
                val v16: Boolean = (v12 == v14)
                v18 = v16
            } else {
                v18 = false
            }
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
    var v28: Int = 0
    when (v1.tag) {
        0 -> {
            var v20: Int = (v1 as US0_Circle).f0
            val v21: Int = (3 * v20)
            val v22: Int = (v21 * v20)
            v28 = v22
        }
        2 -> {
            v28 = 0
        }
        1 -> {
            var v23: Int = (v1 as US0_Rect).f0
            var v24: Int = (v1 as US0_Rect).f1
            val v25: Int = (v23 * v24)
            v28 = v25
        }
        else -> throw RuntimeException()
    }
    var v37: Int = 0
    when (v4.tag) {
        0 -> {
            var v29: Int = (v4 as US0_Circle).f0
            val v30: Int = (3 * v29)
            val v31: Int = (v30 * v29)
            v37 = v31
        }
        2 -> {
            v37 = 0
        }
        1 -> {
            var v32: Int = (v4 as US0_Rect).f0
            var v33: Int = (v4 as US0_Rect).f1
            val v34: Int = (v32 * v33)
            v37 = v34
        }
        else -> throw RuntimeException()
    }
    val v38: Int = (v28 + v37)
    var v47: Int = 0
    when (v5.tag) {
        0 -> {
            var v39: Int = (v5 as US0_Circle).f0
            val v40: Int = (3 * v39)
            val v41: Int = (v40 * v39)
            v47 = v41
        }
        2 -> {
            v47 = 0
        }
        1 -> {
            var v42: Int = (v5 as US0_Rect).f0
            var v43: Int = (v5 as US0_Rect).f1
            val v44: Int = (v42 * v43)
            v47 = v44
        }
        else -> throw RuntimeException()
    }
    val v48: Int = (v38 + v47)
    val v49: Int = (v48 + v19)
    return v49
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
