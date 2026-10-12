class Mut0(var l0: String, var l1: String)
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "no"
    var v1: String = ""
    v1 = "nay"
    var v2: Mut0 = Mut0("", "")
    v2 = Mut0(v0, v1)
    var v3: String = ""
    v3 = "hi"
    var v4: String = ""
    v4 = "yo"
    v2.l0 = v3
    v2.l1 = v4
    var v5: String = ""
    var v6: String = ""
    v5 = v2.l0
    v6 = v2.l1
    var v7: Boolean = false
    v7 = (v5 == "hi")
    var v9: Boolean = false
    if (v7) {
        var v8: Boolean = false
        v8 = (v6 == "yo")
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
