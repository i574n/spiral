import CRT
func left_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Bool = false
        v2 = (v0 == 0)
        if (v2) {
            return 0
        } else {
            var v3: Int32 = 0
            v3 = (v1 &+ v0)
            return v3
        }
    }
}
func right_c1(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Bool = false
        v2 = (v0 == 0)
        if (v2) {
            return 0
        } else {
            var v3: Int32 = 0
            v3 = (v1 &+ v0)
            return v3
        }
    }
}
func sp_method0(_ p0: Int32, _ p1: Int32) -> ((Int32) -> Int32, (Int32) -> Int32) {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v2 = left_c0(v0)
    var v3: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v3 = right_c1(v1)
    return (v2, v3)
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    var v3: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    let spiral_tuple287 = sp_method0(v0, v1)
    v2 = spiral_tuple287.0
    v3 = spiral_tuple287.1
    var v4: Int32 = 0
    v4 = v2(0)
    var v5: Int32 = 0
    v5 = v3(0)
    var v6: Int32 = 0
    v6 = (v4 &+ v5)
    var v7: Bool = false
    v7 = (v6 == 7)
    if (v7) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
