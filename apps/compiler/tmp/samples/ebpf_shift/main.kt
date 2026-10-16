fun spiral_main(): Int {
    var v0: Int = 0
    v0 = -8
    var v1: Int = 0
    v1 = 3
    var v2: Int = 0
    v2 = 1
    var v3: UInt = 0u
    v3 = 4294967295u
    var v4: Int = 0
    v4 = 4
    var v5: Int = 0
    v5 = (v0 shr v2)
    var v6: Int = 0
    v6 = (v1 shl v2)
    var v7: UInt = 0u
    v7 = (v3 shr v4)
    var v8: UInt = 0u
    v8 = (v3 shl v2)
    var v9: Boolean = false
    v9 = (v5 == -4)
    if (v9) {
        var v10: Boolean = false
        v10 = (v6 == 6)
        if (v10) {
            var v11: Boolean = false
            v11 = (v7 == 268435455u)
            if (v11) {
                var v12: Boolean = false
                v12 = (v8 == 4294967294u)
                if (v12) {
                    return 0
                } else {
                    return 4
                }
            } else {
                return 3
            }
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
