class Heap0(val l0: Int, val l1: String)
class Mut1(var l0: Heap0, var l1: Heap0)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    var v1: String = ""
    v1 = "no"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    var v3: Int = 0
    v3 = 2
    var v4: String = ""
    v4 = "zz"
    var v5: Heap0 = Heap0(0, "")
    v5 = Heap0(v3, v4)
    var v6: Mut1 = Mut1(Heap0(0, ""), Heap0(0, ""))
    v6 = Mut1(v2, v5)
    var v7: Array<Mut1> = emptyArray<Mut1>()
    v7 = Array(1) { Mut1(Heap0(0, ""), Heap0(0, "")) }
    v7[0] = v6
    var v8: Int = 0
    v8 = 7
    var v9: String = ""
    v9 = "hi"
    var v10: Heap0 = Heap0(0, "")
    v10 = Heap0(v8, v9)
    var v11: Int = 0
    v11 = 4
    var v12: String = ""
    v12 = "yo"
    var v13: Heap0 = Heap0(0, "")
    v13 = Heap0(v11, v12)
    var v14: Mut1 = Mut1(Heap0(0, ""), Heap0(0, ""))
    v14 = v7[0]
    v14.l0 = v10
    v14.l1 = v13
    var v15: Heap0 = Heap0(0, "")
    var v16: Heap0 = Heap0(0, "")
    v15 = v14.l0
    v16 = v14.l1
    var v17: Int = 0
    var v18: String = ""
    v17 = v15.l0
    v18 = v15.l1
    var v19: Int = 0
    var v20: String = ""
    v19 = v16.l0
    v20 = v16.l1
    var v21: Boolean = false
    v21 = (v17 == 7)
    var v23: Boolean = false
    if (v21) {
        var v22: Boolean = false
        v22 = (v18 == "hi")
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        var v24: Boolean = false
        v24 = (v19 == 4)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Boolean = false
    if (v25) {
        var v26: Boolean = false
        v26 = (v20 == "yo")
        v27 = v26
    } else {
        v27 = false
    }
    if (v27) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
