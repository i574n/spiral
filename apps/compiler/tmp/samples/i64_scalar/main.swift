import CRT
func spiral_main() -> Int32 {
    var v0: Int64 = (0 as Int64)
    v0 = (5000000000 as Int64)
    var v1: Int64 = (0 as Int64)
    v1 = (-4 as Int64)
    var v2: Int64 = (0 as Int64)
    v2 = (v0 / v1)
    var v3: Int64 = (0 as Int64)
    v3 = (1000000 as Int64)
    var v4: Int64 = (0 as Int64)
    v4 = (v3 &* v3)
    var v5: Int64 = (0 as Int64)
    v5 = (-8 as Int64)
    var v6: Int64 = (0 as Int64)
    v6 = (v5 >> 1)
    var v7: Int32 = 0
    v7 = 7
    var v8: Int64 = (0 as Int64)
    v8 = Int64(v7)
    var v9: Int64 = (0 as Int64)
    v9 = (9 as Int64)
    var v10: Int32 = 0
    v10 = Int32(v9)
    var v11: UInt64 = (0 as UInt64)
    v11 = (4294967296 as UInt64)
    var v12: UInt64 = (0 as UInt64)
    v12 = (v11 &+ (1 as UInt64))
    var v13: UInt64 = (0 as UInt64)
    v13 = (v11 >> 1)
    var v14: UInt64 = (0 as UInt64)
    v14 = UInt64(v7)
    var v15: Bool = false
    v15 = (v2 == (-1250000000 as Int64))
    var v17: Bool = false
    if (v15) {
        var v16: Bool = false
        v16 = (v4 == (1000000000000 as Int64))
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Bool = false
    if (v17) {
        var v18: Bool = false
        v18 = (v6 == (-4 as Int64))
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Bool = false
    if (v19) {
        var v20: Bool = false
        v20 = (v8 == (7 as Int64))
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Bool = false
    if (v21) {
        var v22: Bool = false
        v22 = (v10 == 9)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Bool = false
    if (v23) {
        var v24: Bool = false
        v24 = (v12 == (4294967297 as UInt64))
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Bool = false
    if (v25) {
        var v26: Bool = false
        v26 = (v13 == (2147483648 as UInt64))
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Bool = false
    if (v27) {
        var v28: Bool = false
        v28 = (v14 == (7 as UInt64))
        v29 = v28
    } else {
        v29 = false
    }
    if (v29) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
