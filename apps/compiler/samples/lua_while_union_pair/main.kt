class Mut0(var l0: Int)
class Mut1(var l0: Int)
class Mut2(var l0: UH0)
sealed interface UH0 { val tag: Int }
object UH0_Nil : UH0 { override val tag: Int = 0 }
data class UH0_Cons(val f0: Int, val f1: UH0) : UH0 { override val tag: Int = 1 }
fun sp_method0(p0: Mut0): Boolean {
    var v0: Mut0 = p0
    var v1: Int = 0
    v1 = v0.l0
    var v2: Boolean = false
    v2 = (v1 < 3)
    return v2
}
fun sp_method1(p0: Mut1): Boolean {
    var v0: Mut1 = p0
    var v1: Int = 0
    v1 = v0.l0
    var v2: Boolean = false
    v2 = (v1 < 4)
    return v2
}
fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    v0 = Array(3) { 0 }
    var v1: Mut0 = Mut0(0)
    v1 = Mut0(0)
    while (true) {
        if (!(sp_method0(v1))) break
        val v3: Int = v1.l0
        val v4: Int = (v3 * 5)
        v0[v3] = v4
        val v5: Int = (v3 + 1)
        v1.l0 = v5
    }
    var v6: Mut1 = Mut1(0)
    v6 = Mut1(0)
    var v7: Mut1 = Mut1(0)
    v7 = Mut1(0)
    val v8: UH0 = UH0_Nil
    var v9: Mut2 = Mut2(UH0_Nil)
    v9 = Mut2(v8)
    while (true) {
        if (!(sp_method1(v6))) break
        val v11: Int = v6.l0
        val v12: Int = (v11 % 2)
        val v13: Boolean = (v12 == 1)
        if (v13) {
            val v14: Int = v7.l0
            val v15: Int = (v14 + 1)
            v7.l0 = v15
        } else {
        }
        val v16: UH0 = v9.l0
        val v17: UH0 = UH0_Cons(v11, v16)
        v9.l0 = v17
        val v18: Int = (v11 + 1)
        v6.l0 = v18
    }
    val v19: UH0 = v9.l0
    var v38: Int = 0
    when (v19.tag) {
        1 -> {
            var v20: Int = (v19 as UH0_Cons).f0
            var v21: UH0 = (v19 as UH0_Cons).f1
            when (v21.tag) {
                1 -> {
                    var v22: Int = (v21 as UH0_Cons).f0
                    var v23: UH0 = (v21 as UH0_Cons).f1
                    when (v23.tag) {
                        1 -> {
                            var v24: Int = (v23 as UH0_Cons).f0
                            var v25: UH0 = (v23 as UH0_Cons).f1
                            when (v25.tag) {
                                1 -> {
                                    var v26: Int = (v25 as UH0_Cons).f0
                                    var v27: UH0 = (v25 as UH0_Cons).f1
                                    when (v27.tag) {
                                        0 -> {
                                            val v28: Int = (v20 * 64)
                                            val v29: Int = (v22 * 16)
                                            val v30: Int = (v28 + v29)
                                            val v31: Int = (v24 * 4)
                                            val v32: Int = (v30 + v31)
                                            val v33: Int = (v32 + v26)
                                            v38 = v33
                                        }
                                        else -> {
                                            v38 = -1
                                        }
                                    }
                                }
                                else -> {
                                    v38 = -1
                                }
                            }
                        }
                        else -> {
                            v38 = -1
                        }
                    }
                }
                else -> {
                    v38 = -1
                }
            }
        }
        else -> {
            v38 = -1
        }
    }
    val v39: Int = v7.l0
    val v40: Int = (v38 + v39)
    val v41: Int = v0[2]
    val v42: Int = (v40 + v41)
    val v43: Int = v0[1]
    val v44: Int = (v42 - v43)
    return v44
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
