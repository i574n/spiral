fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = -1.5f
    var v1: Float = 0.0f
    v1 = 2.0f
    var v2: Float = 0.0f
    v2 = (v0 / v1)
    var v3: Float = 0.0f
    v3 = -0.75f
    var v4: Float = 0.0f
    v4 = (v0 * v1)
    var v5: Float = 0.0f
    v5 = (v4 + 0.5f)
    var v6: Float = 0.0f
    v6 = -2.5f
    var v7: Boolean = false
    v7 = (v2 == v3)
    if (v7) {
        var v8: Boolean = false
        v8 = (v5 == v6)
        if (v8) {
            return 0
        } else {
            return 2
        }
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
