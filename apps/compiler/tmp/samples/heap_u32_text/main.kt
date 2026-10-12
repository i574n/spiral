class Heap0(val l0: UInt, val l1: String)
fun spiral_main(): Int {
    var v0: UInt = 0u
    v0 = 4000000000u
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(0u, "")
    v2 = Heap0(v0, v1)
    var v3: UInt = 0u
    var v4: String = ""
    v3 = v2.l0
    v4 = v2.l1
    var v5: Boolean = false
    v5 = (v3 == 4000000000u)
    var v7: Boolean = false
    if (v5) {
        var v6: Boolean = false
        v6 = (v4 == "hi")
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
