class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
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
    var v6: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    v6 = Heap1(v2, v5)
    var v7: Array<Heap1> = emptyArray<Heap1>()
    v7 = Array(1) { Heap1(Heap0(0, ""), Heap0(0, "")) }
    v7[0] = v6
    var v8: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    v8 = v7[0]
    var v9: Heap0 = Heap0(0, "")
    var v10: Heap0 = Heap0(0, "")
    v9 = v8.l0
    v10 = v8.l1
    var v11: Int = 0
    var v12: String = ""
    v11 = v9.l0
    v12 = v9.l1
    var v13: Int = 0
    var v14: String = ""
    v13 = v10.l0
    v14 = v10.l1
    var v15: Boolean = false
    v15 = (v11 == 7)
    var v17: Boolean = false
    if (v15) {
        var v16: Boolean = false
        v16 = (v12 == "hi")
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Boolean = false
    if (v17) {
        var v18: Boolean = false
        v18 = (v13 == 4)
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Boolean = false
    if (v19) {
        var v20: Boolean = false
        v20 = (v14 == "yo")
        v21 = v20
    } else {
        v21 = false
    }
    if (v21) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
