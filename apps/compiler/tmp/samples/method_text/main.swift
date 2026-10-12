import CRT
func sp_method0(_ p0: Int32) -> String {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: String = ""
        v2 = "no"
        return v2
    } else {
        var v3: String = ""
        v3 = "hi"
        return v3
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: String = ""
    v1 = sp_method0(v0)
    var v2: Bool = false
    v2 = (v1 == "hi")
    if (v2) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
