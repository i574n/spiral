import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_Idle: US0 { var tag: Int32 { 0 } }
struct US0_Hit: US0 { var f0: Int32; var tag: Int32 { 1 } }
struct US0_Flag: US0 { var f0: Bool; var tag: Int32 { 2 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 2:
            var v2: Bool = (v0 as! US0_Flag).f0
            if (v2) {
                return 11
            } else {
                return 5
            }
        case 1:
            var v1: Int32 = (v0 as! US0_Hit).f0
            return v1
        case 0:
            return 3
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: Bool = false
    v1 = (v0 == 0)
    var v7: US0 = US0_Idle()
    if (v1) {
        v7 = US0_Idle()
    } else {
        var v3: Bool = false
        v3 = (v0 == 1)
        if (v3) {
            v7 = US0_Hit(f0: 7)
        } else {
            v7 = US0_Flag(f0: true)
        }
    }
    var v8: Int32 = 0
    v8 = sp_score_0(v7)
    var v9: Int32 = 0
    v9 = (v8 &- 11)
    return v9
}
exit(spiral_main())
