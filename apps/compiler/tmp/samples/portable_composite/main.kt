class SpiralTuple0(val v0: Boolean, val v1: Float, val v2: Int)
class SpiralTuple1(val v0: Int, val v1: Int, val v2: Boolean)
fun sp_method5(p0: Int, p1: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = (v0 * v1)
    var v3: Int = 0
    v3 = (v2 + 5)
    var v4: Int = 0
    v4 = (v3 / 3)
    return v4
}
fun sp_method4(p0: Int): Int {
    var v0: Int = p0
    var v1: Int = 0
    v1 = 4
    var v2: Int = 0
    v2 = 4
    var v3: Int = 0
    v3 = sp_method5(v1, v2)
    var v4: Int = 0
    v4 = (v0 + v3)
    var v5: Int = 0
    v5 = (v4 - 7)
    return v5
}
fun sp_method6(p0: UInt): Boolean {
    var v0: UInt = p0
    var v1: UInt = 0u
    v1 = (v0 + 5u)
    var v2: UInt = 0u
    v2 = (v1 % 4u)
    var v3: Boolean = false
    v3 = (v2 == 0u)
    return v3
}
fun sp_method3(p0: Int): Int {
    var v0: Int = p0
    var v1: UInt = 0u
    v1 = 7u
    var v2: Boolean = false
    v2 = sp_method6(v1)
    if (v2) {
        return sp_method4(v0)
    } else {
        return 1
    }
}
fun sp_method7(p0: String, p1: String): Boolean {
    var v0: String = p0
    var v1: String = p1
    var v2: Boolean = false
    v2 = (v0 == v1)
    return v2
}
fun sp_method2(p0: Int): Int {
    var v0: Int = p0
    var v1: String = ""
    v1 = "spiral"
    var v2: Boolean = false
    v2 = sp_method7(v1, v1)
    if (v2) {
        return sp_method3(v0)
    } else {
        return 1
    }
}
fun sp_method8(p0: Float): SpiralTuple0 {
    var v0: Float = p0
    var v1: Boolean = false
    v1 = (v0 >= 3.5f)
    return SpiralTuple0(v1, v0, 7)
}
fun sp_method9(p0: Boolean, p1: Float, p2: Int): Int {
    var v0: Boolean = p0
    var v1: Float = p1
    var v2: Int = p2
    if (v0) {
        var v3: Boolean = false
        v3 = (v1 >= 3.5f)
        if (v3) {
            var v4: Int = 0
            v4 = (v2 - 7)
            return v4
        } else {
            return 1
        }
    } else {
        return 2
    }
}
fun sp_method1(p0: Int): Int {
    var v0: Int = p0
    var v1: Float = 0.0f
    v1 = 4.0f
    var v2: Boolean = false
    var v3: Float = 0.0f
    var v4: Int = 0
    val spiral_tuple171 = sp_method8(v1)
    v2 = spiral_tuple171.v0
    v3 = spiral_tuple171.v1
    v4 = spiral_tuple171.v2
    var v5: Int = 0
    v5 = sp_method9(v2, v3, v4)
    var v6: Int = 0
    v6 = (v0 + v5)
    return sp_method2(v6)
}
fun sp_method10(p0: Int): SpiralTuple1 {
    var v0: Int = p0
    var v1: Int = 0
    v1 = (v0 + 2)
    var v2: Boolean = false
    v2 = (v0 > 0)
    return SpiralTuple1(v0, v1, v2)
}
fun sp_method11(p0: Int, p1: Int, p2: Boolean): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Boolean = p2
    if (v2) {
        var v3: Int = 0
        v3 = (v0 + v1)
        var v4: Int = 0
        v4 = (v3 - 4)
        return v4
    } else {
        return 1
    }
}
fun sp_method0(p0: Int): Int {
    var v0: Int = p0
    var v1: Int = 0
    v1 = 1
    var v2: Int = 0
    var v3: Int = 0
    var v4: Boolean = false
    val spiral_tuple158 = sp_method10(v1)
    v2 = spiral_tuple158.v0
    v3 = spiral_tuple158.v1
    v4 = spiral_tuple158.v2
    var v5: Int = 0
    v5 = sp_method11(v2, v3, v4)
    var v6: Int = 0
    v6 = (v0 + v5)
    return sp_method1(v6)
}
fun spiral_main(): Int {
    val v0: Int = 0
    return sp_method0(v0)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
