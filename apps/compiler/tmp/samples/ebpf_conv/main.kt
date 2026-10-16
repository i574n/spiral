fun spiral_main(): Int {
    var v0: Int = 0
    v0 = Int.MIN_VALUE
    var v1: UInt = 0u
    v1 = 4294967295u
    var v2: Int = 0
    v2 = -1
    var v3: Float = 0.0f
    v3 = 0.0f
    var v4: Float = 0.0f
    v4 = 1.9f
    var v5: Float = 0.0f
    v5 = 2.9f
    var v6: UInt = 0u
    v6 = 4294967294u
    var v7: UInt = 0u
    v7 = 5u
    var v8: UInt = 0u
    v8 = 0u
    var v9: Float = 0.0f
    v9 = (v3 - v4)
    var v10: UInt = 0u
    v10 = (v0).toUInt()
    var v11: Int = 0
    v11 = (v10).toInt()
    var v12: Int = 0
    v12 = (v1).toInt()
    var v13: UInt = 0u
    v13 = (v2).toUInt()
    var v14: Int = 0
    v14 = (v9).toInt()
    var v15: Int = 0
    v15 = (v5).toInt()
    var v16: UInt = 0u
    v16 = (v10 / 2u)
    var v17: UInt = 0u
    v17 = (v6 / 2u)
    var v18: UInt = 0u
    v18 = (v7 % 3u)
    var v19: UInt = 0u
    v19 = (v8.inv())
    var v20: UInt = 0u
    v20 = (v1 shr 31)
    var v21: Boolean = false
    v21 = (v0 < -1)
    var v23: Boolean = false
    if (v21) {
        var v22: Boolean = false
        v22 = (v0 <= v0)
        v23 = v22
    } else {
        v23 = false
    }
    var v26: Boolean = false
    if (v23) {
        var v24: Boolean = false
        v24 = (v0 > 0)
        var v25: Boolean = false
        v25 = (v24 == false)
        v26 = v25
    } else {
        v26 = false
    }
    if (v26) {
        var v27: Boolean = false
        v27 = (v10 > 1u)
        var v29: Boolean = false
        if (v27) {
            var v28: Boolean = false
            v28 = (v11 == v0)
            v29 = v28
        } else {
            v29 = false
        }
        var v31: Boolean = false
        if (v29) {
            var v30: Boolean = false
            v30 = (v12 == v2)
            v31 = v30
        } else {
            v31 = false
        }
        var v33: Boolean = false
        if (v31) {
            var v32: Boolean = false
            v32 = (v13 == v1)
            v33 = v32
        } else {
            v33 = false
        }
        if (v33) {
            var v34: Boolean = false
            v34 = (v14 == v2)
            var v36: Boolean = false
            if (v34) {
                var v35: Boolean = false
                v35 = (v15 == 2)
                v36 = v35
            } else {
                v36 = false
            }
            if (v36) {
                var v37: Boolean = false
                v37 = (v16 == 1073741824u)
                var v39: Boolean = false
                if (v37) {
                    var v38: Boolean = false
                    v38 = (v17 == 2147483647u)
                    v39 = v38
                } else {
                    v39 = false
                }
                var v41: Boolean = false
                if (v39) {
                    var v40: Boolean = false
                    v40 = (v18 == 2u)
                    v41 = v40
                } else {
                    v41 = false
                }
                if (v41) {
                    var v42: Boolean = false
                    v42 = (v19 == v1)
                    var v44: Boolean = false
                    if (v42) {
                        var v43: Boolean = false
                        v43 = (v20 == 1u)
                        v44 = v43
                    } else {
                        v44 = false
                    }
                    if (v44) {
                        return 0
                    } else {
                        return 5
                    }
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
