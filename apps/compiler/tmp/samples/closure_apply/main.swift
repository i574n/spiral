import CRT
func f_c0() -> (Int32) -> Int32 {
    return { (v0: Int32) -> Int32 in
        var v1: Int32 = 0
        v1 = (v0 &+ 1)
        return v1
    }
}
func spiral_main() -> Int32 {
    var v0: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v0 = f_c0()
    var v1: Int32 = 0
    v1 = v0(6)
    var v2: Bool = false
    v2 = (v1 == 7)
    if (v2) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
