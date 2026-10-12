fun sp_method0(p0: Float, p1: Float): Float {
    var v0: Float = p0
    var v1: Float = p1
    var v2: Float = 0.0f
    v2 = (v0 * v1)
    var v3: Float = 0.0f
    v3 = (v2 + 0.5f)
    return v3
}
fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = 1.5f
    var v1: Float = 0.0f
    v1 = 2.0f
    var v2: Float = 0.0f
    v2 = sp_method0(v0, v1)
    var v3: Boolean = false
    v3 = (v2 >= 3.5f)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
