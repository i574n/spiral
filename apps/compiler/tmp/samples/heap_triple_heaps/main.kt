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
    var v10: Heap0 = Heap0(0, "")
    var v11: Heap0 = Heap0(0, "")
    var v12: Heap0 = Heap0(0, "")
    v10 = v9.l0
    v11 = v9.l1
    v12 = v9.l2
    var v13: Int = 0
    var v14: String = ""
    v13 = v10.l0
    v14 = v10.l1
    var v15: Int = 0
    var v16: String = ""
    v15 = v11.l0
    v16 = v11.l1
    var v17: Int = 0
    var v18: String = ""
    v17 = v12.l0
    v18 = v12.l1
    var v19: Boolean = false
    v19 = (v13 == 7)
    var v21: Boolean = false
    if (v19) {
        var v20: Boolean = false
        v20 = (v14 == "hi")
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Boolean = false
    if (v21) {
        var v22: Boolean = false
        v22 = (v15 == 4)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        var v24: Boolean = false
        v24 = (v16 == "yo")
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Boolean = false
    if (v25) {
        var v26: Boolean = false
        v26 = (v17 == 9)
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Boolean = false
    if (v27) {
        var v28: Boolean = false
        v28 = (v18 == "ok")
        v29 = v28
    } else {
        v29 = false
    }
    if (v29) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
