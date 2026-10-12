import CRT
func sp_method0(_ p0: Int32, _ p1: Int32) -> Bool {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    v2 = -v0 
    var v3: Bool = false
    v3 = (v2 <= 0)
    if (v3) {
        var v4: Int32 = 0
        v4 = (v1 &* 2)
        var v5: Int32 = 0
        v5 = (v0 &+ v4)
        var v6: Bool = false
        v6 = (v5 >= 9)
        if (v6) {
            return true
        } else {
            var v7: Bool = false
            v7 = (v1 == 0)
            return v7
        }
    } else {
        return false
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 3
    var v2: Bool = false
    v2 = sp_method0(v0, v1)
    if (v2) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
