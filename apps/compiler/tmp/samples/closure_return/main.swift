import CRT
func g_c1(_ v0: Int32, _ v1: Int32) -> (Int32) -> Int32 {
    return { (v2: Int32) -> Int32 in
        var v3: Bool = false
        v3 = (v1 == 0)
        if (v3) {
            return 0
        } else {
            var v4: Int32 = 0
            v4 = (v2 &+ v0)
            return v4
        }
    }
}
func f_c0(_ v0: Int32) -> (Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> (Int32) -> Int32 in
        return g_c1(v0, v1)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: (Int32) -> (Int32) -> Int32 = { (_: Int32) -> (Int32) -> Int32 in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v2 = v1(1)
    var v3: Int32 = 0
    v3 = v2(0)
    var v4: Bool = false
    v4 = (v3 == 7)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
