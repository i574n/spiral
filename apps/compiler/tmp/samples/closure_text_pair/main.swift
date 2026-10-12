import CRT
func f_c0(_ v0: String, _ v1: String) -> (Int32) -> (String, String) {
    return { (v2: Int32) -> (String, String) in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: String = ""
            v4 = "no"
            var v5: String = ""
            v5 = "nay"
            return (v4, v5)
        } else {
            return (v0, v1)
        }
    }
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "hi"
    var v1: String = ""
    v1 = "yo"
    var v2: (Int32) -> (String, String) = { (_: Int32) -> (String, String) in fatalError("unreachable closure") }
    v2 = f_c0(v0, v1)
    var v3: String = ""
    var v4: String = ""
    let spiral_tuple299 = v2(1)
    v3 = spiral_tuple299.0
    v4 = spiral_tuple299.1
    var v5: Bool = false
    v5 = (v3 == "hi")
    var v7: Bool = false
    if (v5) {
        var v6: Bool = false
        v6 = (v4 == "yo")
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
