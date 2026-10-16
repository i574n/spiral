import CRT
func sp_method2(_ p0: Int32, _ p1: Int32, _ p2: Int32) -> (Int32, Int32) {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    while true {
        var v3: Int32 = 0
        v3 = (v0 &- 1)
        var v4: Int32 = 0
        v4 = (v1 &+ 1)
        var v5: Int32 = 0
        v5 = (v2 &+ 2)
        var v6: Bool = false
        v6 = (v3 == 0)
        if (v6) {
            return (v4, v5)
        } else {
            let t439_3: Int32 = v3
            let t475_4: Int32 = v4
            let t511_5: Int32 = v5
            v0 = t439_3
            v1 = t475_4
            v2 = t511_5
            continue
        }
    }
    return (0, 0)
}
func sp_method1(_ p0: Int32) -> (Int32, Int32) {
    var v0: Int32 = p0
    var v1: Int32 = 0
    v1 = 0
    var v2: Int32 = 0
    v2 = 0
    var v3: Bool = false
    v3 = (v0 == 0)
    if (v3) {
        return (v1, v2)
    } else {
        return sp_method2(v0, v1, v2)
    }
}
func sp_method0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = 0
    var v2: Int32 = 0
    let spiral_tuple111 = sp_method1(v0)
    v1 = spiral_tuple111.0
    v2 = spiral_tuple111.1
    var v3: Bool = false
    v3 = (v1 == 4)
    var v5: Bool = false
    if (v3) {
        var v4: Bool = false
        v4 = (v2 == 8)
        v5 = v4
    } else {
        v5 = false
    }
    if (v5) {
        return 0
    } else {
        return 1
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 4
    return sp_method0(v0)
}
exit(spiral_main())
