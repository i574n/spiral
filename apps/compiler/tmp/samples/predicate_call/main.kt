fun sp_is_answer_1(p0: Int): Boolean {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 42)
    return v1
}
fun sp_method0(p0: Int): Boolean {
    var v0: Int = p0
    return sp_is_answer_1(v0)
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 42
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
