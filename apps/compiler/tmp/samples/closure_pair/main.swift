import CRT
func f_c0() -> (Int32) -> (Int32, Int32) {
    return { (v0: Int32) -> (Int32, Int32) in
        var v1: Int32 = 0
        v1 = (v0 &+ 1)
        return (v0, v1)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: (Int32) -> (Int32, Int32) = { (_: Int32) -> (Int32, Int32) in fatalError("unreachable closure") }
    v1 = f_c0()
    var v2: Int32 = 0
    var v3: Int32 = 0
    let spiral_tuple240 = v1(v0)
    v2 = spiral_tuple240.0
    v3 = spiral_tuple240.1
    var v4: Bool = false
    v4 = (v2 == 3)
    var v6: Bool = false
    if (v4) {
        var v5: Bool = false
        v5 = (v3 == 4)
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
