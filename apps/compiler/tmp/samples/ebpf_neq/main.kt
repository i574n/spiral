fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Int = 0
    v1 = 4
    var v2: UInt = 0u
    v2 = 1u
    var v3: UInt = 0u
    v3 = 1u
    var v4: Float = 0.0f
    v4 = 1.5f
    var v5: Float = 0.0f
    v5 = (-(v4))
    var v6: Boolean = false
    v6 = (v0 == v1)
    var v7: Boolean = false
    v7 = (v6 != true)
    if (v7) {
        var v8: Boolean = false
        v8 = (v2 == v3)
        var v9: Boolean = false
        v9 = (v8 != true)
        if (v9) {
            return 2
        } else {
            var v10: Boolean = false
            v10 = (v5 == -1.5f)
            if (v10) {
                return 0
            } else {
                return 3
            }
        }
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
