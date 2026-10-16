class Mut0(var l0: Int)
class Mut1(var l0: Int)
class Mut2(var l0: UH0)
sealed interface UH0 { val tag: Int }
class UH0_Nil : UH0 { override val tag: Int = 0 }
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
        var v3: Int = 0
        v3 = v1.l0
        var v4: Int = 0
        v4 = (v3 * 5)
        v0[v3] = v4
        var v5: Int = 0
        v5 = (v3 + 1)
        v1.l0 = v5
    }
    var v6: Mut1 = Mut1(0)
    v6 = Mut1(0)
    var v7: Mut1 = Mut1(0)
    v7 = Mut1(0)
    var v8: UH0 = UH0_Nil()
    v8 = UH0_Nil()
    var v9: Mut2 = Mut2(UH0_Nil())
    v9 = Mut2(v8)
    while (true) {
        if (!(sp_method1(v6))) break
        var v11: Int = 0
        v11 = v6.l0
        var v12: Int = 0
        v12 = (v11 % 2)
        var v13: Boolean = false
        v13 = (v12 == 1)
        if (v13) {
            var v14: Int = 0
            v14 = v7.l0
            var v15: Int = 0
            v15 = (v14 + 1)
            v7.l0 = v15
        } else {
        }
        var v16: UH0 = UH0_Nil()
        v16 = v9.l0
        var v17: UH0 = UH0_Nil()
        v17 = UH0_Cons(v11, v16)
        v9.l0 = v17
        var v18: Int = 0
        v18 = (v11 + 1)
        v6.l0 = v18
    }
    var v19: UH0 = UH0_Nil()
    v19 = v9.l0
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
                                            var v28: Int = 0
                                            v28 = (v20 * 64)
                                            var v29: Int = 0
                                            v29 = (v22 * 16)
                                            var v30: Int = 0
                                            v30 = (v28 + v29)
                                            var v31: Int = 0
                                            v31 = (v24 * 4)
                                            var v32: Int = 0
                                            v32 = (v30 + v31)
                                            var v33: Int = 0
                                            v33 = (v32 + v26)
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
    var v39: Int = 0
    v39 = v7.l0
    var v40: Int = 0
    v40 = (v38 + v39)
    var v41: Int = 0
    v41 = v0[2]
    var v42: Int = 0
    v42 = (v40 + v41)
    var v43: Int = 0
    v43 = v0[1]
    var v44: Int = 0
    v44 = (v42 - v43)
    return v44
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
