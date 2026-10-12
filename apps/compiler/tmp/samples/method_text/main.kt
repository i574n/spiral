fun sp_method0(p0: Int): String {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: String = ""
        v2 = "no"
        return v2
    } else {
        var v3: String = ""
        v3 = "hi"
        return v3
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: String = ""
    v1 = sp_method0(v0)
    var v2: Boolean = false
    v2 = (v1 == "hi")
    if (v2) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
