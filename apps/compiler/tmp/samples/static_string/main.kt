fun sp_method0(p0: String): Boolean {
    var v0: String = p0
    return true
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "spiral"
    var v1: Boolean = false
    v1 = sp_method0(v0)
    if (v1) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
