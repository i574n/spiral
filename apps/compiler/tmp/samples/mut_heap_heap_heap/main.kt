class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
class Heap2(val l0: Heap1, val l1: Int)
class Mut3(var l0: Heap2)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: String = ""
    v1 = "no"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    var v3: Int = 0
    v3 = 1
    var v4: Heap1 = Heap1(Heap0(0, ""), 0)
    v4 = Heap1(v2, v3)
    var v5: Int = 0
    v5 = 2
    var v6: Heap2 = Heap2(Heap1(Heap0(0, ""), 0), 0)
    v6 = Heap2(v4, v5)
    var v7: Mut3 = Mut3(Heap2(Heap1(Heap0(0, ""), 0), 0))
    v7 = Mut3(v6)
    var v8: Int = 0
    v8 = 7
    var v9: String = ""
    v9 = "hi"
    var v10: Heap0 = Heap0(0, "")
    v10 = Heap0(v8, v9)
    var v11: Int = 0
    v11 = 4
    var v12: Heap1 = Heap1(Heap0(0, ""), 0)
    v12 = Heap1(v10, v11)
    var v13: Int = 0
    v13 = 5
    var v14: Heap2 = Heap2(Heap1(Heap0(0, ""), 0), 0)
    v14 = Heap2(v12, v13)
    v7.l0 = v14
    var v15: Heap2 = Heap2(Heap1(Heap0(0, ""), 0), 0)
    v15 = v7.l0
    var v16: Heap1 = Heap1(Heap0(0, ""), 0)
    var v17: Int = 0
    v16 = v15.l0
    v17 = v15.l1
    var v18: Heap0 = Heap0(0, "")
    var v19: Int = 0
    v18 = v16.l0
    v19 = v16.l1
    var v20: Int = 0
    var v21: String = ""
    v20 = v18.l0
    v21 = v18.l1
    var v22: Boolean = false
    v22 = (v20 == 7)
    var v24: Boolean = false
    if (v22) {
        var v23: Boolean = false
        v23 = (v21 == "hi")
        v24 = v23
    } else {
        v24 = false
    }
    var v26: Boolean = false
    if (v24) {
        var v25: Boolean = false
        v25 = (v19 == 4)
        v26 = v25
    } else {
        v26 = false
    }
    var v28: Boolean = false
    if (v26) {
        var v27: Boolean = false
        v27 = (v17 == 5)
        v28 = v27
    } else {
        v28 = false
    }
    if (v28) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
