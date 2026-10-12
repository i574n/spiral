import CRT
func sp_method0(_ p0: Int32, _ p1: String) -> (Int32, String) {
    var v0: Int32 = p0
    var v1: String = p1
    var v2: Bool = false
    v2 = (v0 == 0)
    if (v2) {
        var v3: String = ""
        v3 = "no"
        return (0, v3)
    } else {
        return (v0, v1)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Int32 = 0
    var v3: String = ""
    let spiral_tuple154 = sp_method0(v0, v1)
    v2 = spiral_tuple154.0
    v3 = spiral_tuple154.1
    var v4: Bool = false
    v4 = (v2 == 7)
    var v6: Bool = false
    if (v4) {
        var v5: Bool = false
        v5 = (v3 == "hi")
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
