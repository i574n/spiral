import CRT
func sp_method0(_ p0: Int32) -> (String, String) {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: String = ""
        v2 = "no"
        return (v2, v2)
    } else {
        var v3: String = ""
        v3 = "hi"
        var v4: String = ""
        v4 = "yo"
        return (v3, v4)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: String = ""
    var v2: String = ""
    let spiral_tuple116 = sp_method0(v0)
    v1 = spiral_tuple116.0
    v2 = spiral_tuple116.1
    var v3: Bool = false
    v3 = (v1 == "hi")
    var v5: Bool = false
    if (v3) {
        var v4: Bool = false
        v4 = (v2 == "yo")
        v5 = v4
    } else {
        v5 = false
    }
    if (v5) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
