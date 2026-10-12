import CRT
func sp_sum_0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 < 1)
    if (v1) {
        return 0
    } else {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        var v3: Int32 = 0
        v3 = sp_sum_0(v2)
        var v4: Int32 = 0
        v4 = (v0 &+ v3)
        return v4
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 4
    var v1: Int32 = 0
    v1 = sp_sum_0(v0)
    var v2: Bool = false
    v2 = (v1 == 10)
    if (v2) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
