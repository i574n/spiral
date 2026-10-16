sealed interface US0 { val tag: Int }
data class US0_Circle(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_Square(val f0: Int) : US0 { override val tag: Int = 1 }
data class US0_Tri(val f0: Int) : US0 { override val tag: Int = 2 }
class US0_Dot : US0 { override val tag: Int = 3 }
fun sp_pick_0(p0: Int): US0 {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        return US0_Circle(5)
    } else {
        var v3: Boolean = false
        v3 = (v0 == 1)
        if (v3) {
            return US0_Square(4)
        } else {
            var v5: Boolean = false
            v5 = (v0 == 2)
            if (v5) {
                return US0_Tri(7)
            } else {
                return US0_Dot()
            }
        }
    }
}
fun sp_measure_1(p0: US0, p1: Int): Int {
    var v0: US0 = p0
    var v1: Int = p1
    when (v0.tag) {
        0 -> {
            var v2: Int = (v0 as US0_Circle).f0
            var v3: Int = 0
            v3 = (v2 * 3)
            return v3
        }
        else -> {
            var v4: Int = 0
            v4 = (v1 * v1)
            var v5: Boolean = false
            v5 = (v4 > 3)
            when (v0.tag) {
                3 -> {
                    return v4
                }
                1 -> {
                    var v6: Int = (v0 as US0_Square).f0
                    if (v5) {
                        var v7: Int = 0
                        v7 = (v6 * v6)
                        return v7
                    } else {
                        return v6
                    }
                }
                2 -> {
                    var v9: Int = (v0 as US0_Tri).f0
                    if (v5) {
                        var v10: Int = 0
                        v10 = (v9 * 2)
                        return v10
                    } else {
                        return v9
                    }
                }
                else -> throw RuntimeException()
            }
        }
    }
}
fun sp_measure_tri_2(p0: US0, p1: Int): Int {
    var v0: US0 = p0
    var v1: Int = p1
    when (v0.tag) {
        0 -> {
            var v2: Int = (v0 as US0_Circle).f0
            return v2
        }
        3 -> {
            return 0
        }
        1 -> {
            var v3: Int = (v0 as US0_Square).f0
            return v3
        }
        else -> {
            var v4: Int = 0
            v4 = (v1 + 2)
            when (v0.tag) {
                2 -> {
                    var v5: Int = (v0 as US0_Tri).f0
                    var v6: Int = 0
                    v6 = (v5 * v4)
                    return v6
                }
                else -> throw RuntimeException()
            }
        }
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 0
    var v1: US0 = US0_Circle(0)
    v1 = sp_pick_0(v0)
    var v2: Int = 0
    v2 = sp_measure_1(v1, v0)
    var v3: Int = 0
    v3 = (v0 + 1)
    var v4: US0 = US0_Circle(0)
    v4 = sp_pick_0(v3)
    var v5: Int = 0
    v5 = sp_measure_1(v4, v3)
    var v6: Int = 0
    v6 = (v2 + v5)
    var v7: Int = 0
    v7 = (v0 + 2)
    var v8: US0 = US0_Circle(0)
    v8 = sp_pick_0(v7)
    var v9: Int = 0
    v9 = sp_measure_1(v8, v7)
    var v10: Int = 0
    v10 = (v6 + v9)
    var v11: Int = 0
    v11 = (v0 + 3)
    var v12: US0 = US0_Circle(0)
    v12 = sp_pick_0(v11)
    var v13: Int = 0
    v13 = sp_measure_1(v12, v11)
    var v14: Int = 0
    v14 = (v10 + v13)
    var v15: US0 = US0_Circle(0)
    v15 = sp_pick_0(v7)
    var v16: Int = 0
    v16 = sp_measure_tri_2(v15, v0)
    var v17: Int = 0
    v17 = (v14 + v16)
    var v18: US0 = US0_Circle(0)
    v18 = sp_pick_0(v0)
    var v19: Int = 0
    v19 = sp_measure_tri_2(v18, v0)
    var v20: Int = 0
    v20 = (v17 + v19)
    return v20
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
