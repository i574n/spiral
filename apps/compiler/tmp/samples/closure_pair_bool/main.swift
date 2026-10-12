import CRT
func f_c0(_ v0: Bool) -> (Int32) -> (Bool, Bool) {
    return { (v1: Int32) -> (Bool, Bool) in
        var v2: Bool = false
        v2 = (v1 == 0)
        if (v2) {
            return (false, false)
        } else {
            return (v0, true)
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v1: (Int32) -> (Bool, Bool) = { (_: Int32) -> (Bool, Bool) in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: Bool = false
    var v3: Bool = false
    let spiral_tuple250 = v1(1)
    v2 = spiral_tuple250.0
    v3 = spiral_tuple250.1
    var v4: Bool = false
    v4 = (v2 && v3)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
