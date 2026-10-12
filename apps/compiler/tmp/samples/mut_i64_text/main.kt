class Mut0(var l0: Long, var l1: String)
fun spiral_main(): Int {
    var v0: Long = 0L
    v0 = 3L
    var v1: String = ""
    v1 = "no"
    var v2: Mut0 = Mut0(0L, "")
    v2 = Mut0(v0, v1)
    var v3: Long = 0L
    v3 = 5000000000L
    var v4: String = ""
    v4 = "hi"
    v2.l0 = v3
    v2.l1 = v4
    var v5: Long = 0L
    var v6: String = ""
    v5 = v2.l0
    v6 = v2.l1
    var v7: Boolean = false
    v7 = (v5 == 5000000000L)
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
