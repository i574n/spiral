import CRT
func f_c0(_ v0: Int32, _ v1: String) -> (Int32) -> (Int32, String) {
    return { (v2: Int32) -> (Int32, String) in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: String = ""
            v4 = "no"
            return (0, v4)
        } else {
            return (v0, v1)
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: (Int32) -> (Int32, String) = { (_: Int32) -> (Int32, String) in fatalError("unreachable closure") }
    v2 = f_c0(v0, v1)
    var v3: Int32 = 0
    var v4: String = ""
    let spiral_tuple290 = v2(1)
    v3 = spiral_tuple290.0
    v4 = spiral_tuple290.1
    var v5: Bool = false
    v5 = (v3 == 7)
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
