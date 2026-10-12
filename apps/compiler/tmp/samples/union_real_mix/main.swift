import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Both: US0 { var f0: Double; var f1: Int32; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: Double = (v0 as! US0_Both).f0
            var v2: Int32 = (v0 as! US0_Both).f1
            var v3: Bool = false
            v3 = (v1 == (1.5 as Double))
            var v5: Bool = false
            if (v3) {
                var v4: Bool = false
                v4 = (v2 == 7)
                v5 = v4
            } else {
                v5 = false
            }
            if (v5) {
                return 0
            } else {
                return 1
            }
        case 0:
            return 1
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Double = (0.0 as Double)
    v0 = (1.5 as Double)
    var v1: Int32 = 0
    v1 = 7
    var v2: Bool = false
    v2 = true
    var v5: US0 = US0_None()
    if (v2) {
        v5 = US0_Both(f0: v0, f1: v1)
    } else {
        v5 = US0_None()
    }
    return sp_score_0(v5)
}
exit(spiral_main())
