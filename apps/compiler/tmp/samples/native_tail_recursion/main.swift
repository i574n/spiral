import CRT
func sp_method1(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    while true {
        var v1: Int32 = 0
        v1 = (v0 &- 1)
        var v2: Bool = false
        v2 = (v1 == 0)
        if (v2) {
            return 0
        } else {
            let t247_1: Int32 = v1
            v0 = t247_1
            continue
        }
    }
    return 0
}
func sp_method0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        return 0
    } else {
        return sp_method1(v0)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1000000
    return sp_method0(v0)
}
exit(spiral_main())
