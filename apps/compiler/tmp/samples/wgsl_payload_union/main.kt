sealed interface US0 { val tag: Int }
data class US0_Circle(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_Rect(val f0: Int, val f1: Int) : US0 { override val tag: Int = 1 }
class US0_Empty : US0 { override val tag: Int = 2 }
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: US0 = US0_Circle(0)
    v1 = US0_Circle(v0)
    var v2: Int = 0
    v2 = 3
    var v3: Int = 0
    v3 = 4
    var v4: US0 = US0_Circle(0)
    v4 = US0_Rect(v2, v3)
    var v5: US0 = US0_Circle(0)
    v5 = US0_Empty()
    var v6: Int = 0
    v6 = 2
    var v7: US0 = US0_Circle(0)
    v7 = US0_Circle(v6)
    var v18: Boolean = false
    when (if (v1.tag == v7.tag) v1.tag else -1) {
        0 -> {
            var v8: Int = (v1 as US0_Circle).f0
            var v9: Int = (v7 as US0_Circle).f0
            var v10: Boolean = false
            v10 = (v8 == v9)
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
            var v15: Boolean = false
            v15 = (v11 == v13)
            if (v15) {
                var v16: Boolean = false
                v16 = (v12 == v14)
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
            var v21: Int = 0
            v21 = (3 * v20)
            var v22: Int = 0
            v22 = (v21 * v20)
            v28 = v22
        }
        2 -> {
            v28 = 0
        }
        1 -> {
            var v23: Int = (v1 as US0_Rect).f0
            var v24: Int = (v1 as US0_Rect).f1
            var v25: Int = 0
            v25 = (v23 * v24)
            v28 = v25
        }
        else -> throw RuntimeException()
    }
    var v37: Int = 0
    when (v4.tag) {
        0 -> {
            var v29: Int = (v4 as US0_Circle).f0
            var v30: Int = 0
            v30 = (3 * v29)
            var v31: Int = 0
            v31 = (v30 * v29)
            v37 = v31
        }
        2 -> {
            v37 = 0
        }
        1 -> {
            var v32: Int = (v4 as US0_Rect).f0
            var v33: Int = (v4 as US0_Rect).f1
            var v34: Int = 0
            v34 = (v32 * v33)
            v37 = v34
        }
        else -> throw RuntimeException()
    }
    var v38: Int = 0
    v38 = (v28 + v37)
    var v47: Int = 0
    when (v5.tag) {
        0 -> {
            var v39: Int = (v5 as US0_Circle).f0
            var v40: Int = 0
            v40 = (3 * v39)
            var v41: Int = 0
            v41 = (v40 * v39)
            v47 = v41
        }
        2 -> {
            v47 = 0
        }
        1 -> {
            var v42: Int = (v5 as US0_Rect).f0
            var v43: Int = (v5 as US0_Rect).f1
            var v44: Int = 0
            v44 = (v42 * v43)
            v47 = v44
        }
        else -> throw RuntimeException()
    }
    var v48: Int = 0
    v48 = (v38 + v47)
    var v49: Int = 0
    v49 = (v48 + v19)
    return v49
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
