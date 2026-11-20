sealed interface US0 { val tag: Int }
data class US0_Vowel(val f0: Int) : US0 { override val tag: Int = 1 }
sealed interface UH1 { val tag: Int }
object UH1_Nil : UH1 { override val tag: Int = 0 }
data class UH1_Cons(val f0: US0, val f1: UH1) : UH1 { override val tag: Int = 1 }
fun sp_method0(p0: UH1, p1: UH1): Boolean {
    var v0: UH1 = p0
    var v1: UH1 = p1
    when (if (v1.tag == v0.tag) v1.tag else -1) {
        1 -> {
            var v2: US0 = (v1 as UH1_Cons).f0
            var v3: UH1 = (v1 as UH1_Cons).f1
            var v4: US0 = (v0 as UH1_Cons).f0
            var v5: UH1 = (v0 as UH1_Cons).f1
            var v9: Boolean = false
            when (if (v2.tag == v4.tag) v2.tag else -1) {
                1 -> {
                    var v6: Int = (v2 as US0_Vowel).f0
                    var v7: Int = (v4 as US0_Vowel).f0
                    var v8: Boolean = false
                    v8 = (v6 == v7)
                    v9 = v8
                }
                else -> {
                    v9 = false
                }
            }
            if (v9) {
                return sp_method0(v5, v3)
            } else {
                return false
            }
        }
        0 -> {
            return true
        }
        else -> {
            return false
        }
    }
}
fun spiral_main(): Int {
    val v0: Int = 1
    val v1: US0 = US0_Vowel(v0)
    val v2: Int = 1
    val v3: US0 = US0_Vowel(v2)
    val v4: Int = 2
    val v5: US0 = US0_Vowel(v4)
    val v6: UH1 = UH1_Nil
    val v7: UH1 = UH1_Cons(v5, v6)
    var v8: UH1 = UH1_Nil
    v8 = UH1_Cons(v1, v7)
    var v9: UH1 = UH1_Nil
    v9 = UH1_Nil
    val v10: UH1 = UH1_Cons(v5, v9)
    val v11: UH1 = UH1_Cons(v3, v10)
    val v12: UH1 = UH1_Nil
    val v13: UH1 = UH1_Cons(v1, v12)
    var v17: Boolean = false
    when (if (v1.tag == v3.tag) v1.tag else -1) {
        1 -> {
            var v14: Int = (v1 as US0_Vowel).f0
            var v15: Int = (v3 as US0_Vowel).f0
            val v16: Boolean = (v14 == v15)
            v17 = v16
        }
        else -> {
            v17 = false
        }
    }
    var v23: Boolean = false
    if (v17) {
        var v21: Boolean = false
        when (if (v1.tag == v5.tag) v1.tag else -1) {
            1 -> {
                var v18: Int = (v1 as US0_Vowel).f0
                var v19: Int = (v5 as US0_Vowel).f0
                val v20: Boolean = (v18 == v19)
                v21 = v20
            }
            else -> {
                v21 = false
            }
        }
        val v22: Boolean = (v21 == false)
        v23 = v22
    } else {
        v23 = false
    }
    var v30: Boolean = false
    if (v23) {
        var v27: Boolean = false
        when (if (v1.tag == v3.tag) v1.tag else -1) {
            1 -> {
                var v24: Int = (v1 as US0_Vowel).f0
                var v25: Int = (v3 as US0_Vowel).f0
                val v26: Boolean = (v24 == v25)
                v27 = v26
            }
            else -> {
                v27 = false
            }
        }
        if (v27) {
            v30 = sp_method0(v11, v8)
        } else {
            v30 = false
        }
    } else {
        v30 = false
    }
    var v38: Boolean = false
    if (v30) {
        var v34: Boolean = false
        when (if (v1.tag == v5.tag) v1.tag else -1) {
            1 -> {
                var v31: Int = (v1 as US0_Vowel).f0
                var v32: Int = (v5 as US0_Vowel).f0
                val v33: Boolean = (v31 == v32)
                v34 = v33
            }
            else -> {
                v34 = false
            }
        }
        var v36: Boolean = false
        if (v34) {
            v36 = sp_method0(v13, v8)
        } else {
            v36 = false
        }
        val v37: Boolean = (v36 == false)
        v38 = v37
    } else {
        v38 = false
    }
    if (v38) {
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
