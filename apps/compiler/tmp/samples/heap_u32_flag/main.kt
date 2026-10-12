class Heap0(val l0: UInt, val l1: String, val l2: Boolean)
fun spiral_main(): Int {
    var v0: UInt = 0u
    v0 = 4000000000u
    var v1: String = ""
    v1 = "hi"
    var v2: Boolean = false
    v2 = true
    var v3: Heap0 = Heap0(0u, "", false)
    v3 = Heap0(v0, v1, v2)
    var v4: UInt = 0u
    var v5: String = ""
    var v6: Boolean = false
    v4 = v3.l0
    v5 = v3.l1
    v6 = v3.l2
    var v7: Boolean = false
    v7 = (v4 == 4000000000u)
    var v9: Boolean = false
    if (v7) {
        var v8: Boolean = false
        v8 = (v5 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    var v10: Boolean = false
    v10 = (v9 && v6)
    if (v10) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
