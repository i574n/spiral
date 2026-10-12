import CRT
func f_c0(_ v0: Float, _ v1: String) -> (Int32) -> (Float, String) {
    return { (v2: Int32) -> (Float, String) in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: String = ""
            v4 = "no"
            return ((0.0 as Float), v4)
        } else {
            return (v0, v1)
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (1.5 as Float)
    var v1: String = ""
    v1 = "hi"
    var v2: (Int32) -> (Float, String) = { (_: Int32) -> (Float, String) in fatalError("unreachable closure") }
    v2 = f_c0(v0, v1)
    var v3: Float = (0.0 as Float)
    var v4: String = ""
    let spiral_tuple329 = v2(1)
    v3 = spiral_tuple329.0
    v4 = spiral_tuple329.1
    var v5: Bool = false
    v5 = (v3 == (1.5 as Float))
    var v7: Bool = false
    if (v5) {
        var v6: Bool = false
        v6 = (v4 == "hi")
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
