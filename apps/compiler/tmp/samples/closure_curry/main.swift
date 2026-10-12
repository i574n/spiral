import CRT
func closure1(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v0 &* 10)
        var v3: Int32 = 0
        v3 = (v2 &+ v1)
        return v3
    }
}
func f_c0() -> (Int32) -> (Int32) -> Int32 {
    return { (v0: Int32) -> (Int32) -> Int32 in
        return closure1(v0)
    }
}
func spiral_main() -> Int32 {
    var v0: (Int32) -> (Int32) -> Int32 = { (_: Int32) -> (Int32) -> Int32 in fatalError("unreachable closure") }
    v0 = f_c0()
    var v1: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v1 = v0(3)
    var v2: Int32 = 0
    v2 = v1(4)
    var v3: Bool = false
    v3 = (v2 == 34)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
