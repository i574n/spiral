class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0, val l2: Heap0)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    var v3: Int = 0
    v3 = 4
    var v4: String = ""
    v4 = "yo"
    var v5: Heap0 = Heap0(0, "")
    v5 = Heap0(v3, v4)
    var v6: Int = 0
    v6 = 9
    var v7: String = ""
    v7 = "ok"
    var v8: Heap0 = Heap0(0, "")
    v8 = Heap0(v6, v7)
    var v9: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""), Heap0(0, ""))
    v9 = Heap1(v2, v5, v8)
    var v10: Array<Heap1> = emptyArray<Heap1>()
    v10 = Array(1) { Heap1(Heap0(0, ""), Heap0(0, ""), Heap0(0, "")) }
    v10[0] = v9
    var v11: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""), Heap0(0, ""))
    v11 = v10[0]
    var v12: Heap0 = Heap0(0, "")
    var v13: Heap0 = Heap0(0, "")
    var v14: Heap0 = Heap0(0, "")
    v12 = v11.l0
    v13 = v11.l1
    v14 = v11.l2
    var v15: Int = 0
    var v16: String = ""
    v15 = v12.l0
    v16 = v12.l1
    var v17: Int = 0
    var v18: String = ""
    v17 = v13.l0
    v18 = v13.l1
    var v19: Int = 0
    var v20: String = ""
    v19 = v14.l0
    v20 = v14.l1
    var v21: Boolean = false
    v21 = (v15 == 7)
    var v23: Boolean = false
    if (v21) {
        var v22: Boolean = false
        v22 = (v16 == "hi")
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        var v24: Boolean = false
        v24 = (v17 == 4)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Boolean = false
    if (v25) {
        var v26: Boolean = false
        v26 = (v18 == "yo")
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Boolean = false
    if (v27) {
        var v28: Boolean = false
        v28 = (v19 == 9)
        v29 = v28
    } else {
        v29 = false
    }
    var v31: Boolean = false
    if (v29) {
        var v30: Boolean = false
        v30 = (v20 == "ok")
        v31 = v30
    } else {
        v31 = false
    }
    if (v31) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
