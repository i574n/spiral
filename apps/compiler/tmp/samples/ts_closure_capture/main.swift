import CRT
func f_c0(_ v0: Int32, _ v1: Int32) -> (Int32) -> Int32 {
    return { (v2: Int32) -> Int32 in
        var v3: Int32 = 0
        v3 = (v0 &+ v1)
        var v4: Int32 = 0
        v4 = (v3 &+ v2)
        return v4
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1
    var v1: Int32 = 0
    v1 = 2
    var v2: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v2 = f_c0(v0, v1)
    return v2(39)
}
exit(spiral_main())
