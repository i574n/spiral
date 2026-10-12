import CRT
func sp_method0(_ p0: String, _ p1: String) -> (String, String) {
    var v0: String = p0
    var v1: String = p1
    var v2: Bool = false
    v2 = (v0 == "")
    if (v2) {
        var v3: String = ""
        v3 = "no"
        var v4: String = ""
        v4 = "nay"
        return (v3, v4)
    } else {
        return (v0, v1)
    }
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "hi"
    var v1: String = ""
    v1 = "yo"
    var v2: String = ""
    var v3: String = ""
    let spiral_tuple161 = sp_method0(v0, v1)
    v2 = spiral_tuple161.0
    v3 = spiral_tuple161.1
    var v4: Bool = false
    v4 = (v2 == "hi")
    var v6: Bool = false
    if (v4) {
        var v5: Bool = false
        v5 = (v3 == "yo")
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
