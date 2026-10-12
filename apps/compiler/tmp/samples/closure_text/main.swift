import CRT
func f_c0(_ v0: String) -> (Int32) -> String {
    return { (v1: Int32) -> String in
        var v2: Bool = false
        v2 = (v1 == 0)
        if (v2) {
            var v3: String = ""
            v3 = "no"
            return v3
        } else {
            return v0
        }
    }
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "hi"
    var v1: (Int32) -> String = { (_: Int32) -> String in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: String = ""
    v2 = v1(1)
    var v3: Bool = false
    v3 = (v2 == "hi")
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
