import CRT
func f_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v1 &+ v0)
        return v2
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: Int32 = 0
    v2 = 1
    var v3: Array<(Int32) -> Int32> = Array<(Int32) -> Int32>()
    v3 = Array<(Int32) -> Int32>(repeating: { (_: Int32) -> Int32 in fatalError("unreachable closure") }, count: Int(v2))
    v3[Int(0)] = v1
    var v4: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v4 = v3[Int(0)]
    var v5: Int32 = 0
    v5 = v4(4)
    var v6: Bool = false
    v6 = (v5 == 7)
    if (v6) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
