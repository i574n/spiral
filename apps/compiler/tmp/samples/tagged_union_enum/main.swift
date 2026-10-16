import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_Cold: US0 { var tag: Int32 { 0 } }
struct US0_Warm: US0 { var tag: Int32 { 1 } }
struct US0_Hot: US0 { var tag: Int32 { 2 } }
struct US0_Done: US0 { var tag: Int32 { 3 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 0:
            return 1
        case 3:
            return 4
        case 2:
            return 3
        case 1:
            return 2
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Bool = false
    v1 = (v0 == 0)
    var v10: US0 = US0_Cold()
    if (v1) {
        v10 = US0_Cold()
    } else {
        var v3: Bool = false
        v3 = (v0 == 1)
        if (v3) {
            v10 = US0_Warm()
        } else {
            var v5: Bool = false
            v5 = (v0 == 2)
            if (v5) {
                v10 = US0_Hot()
            } else {
                v10 = US0_Done()
            }
        }
    }
    var v11: Int32 = 0
    v11 = sp_score_0(v10)
    var v12: Int32 = 0
    v12 = (v11 &- 4)
    return v12
}
exit(spiral_main())
