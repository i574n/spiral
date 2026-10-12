class Heap0(val l0: Float, val l1: String)
fun f_c0(v0: Heap0): (Int) -> Heap0 {
    fun body(v1: Int): Heap0 {
        return v0
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = 1.5f
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(0.0f, "")
    v2 = Heap0(v0, v1)
    var v3: (Int) -> Heap0 = { _: Int -> throw RuntimeException() }
    v3 = f_c0(v2)
    var v4: Heap0 = Heap0(0.0f, "")
    v4 = v3(1)
    var v5: Float = 0.0f
    var v6: String = ""
    v5 = v4.l0
    v6 = v4.l1
    var v7: Boolean = false
    v7 = (v5 == 1.5f)
    var v9: Boolean = false
    if (v7) {
        var v8: Boolean = false
        v8 = (v6 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    if (v9) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
