import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_Empty: US0 { var tag: Int32 { 0 } }
struct US0_Full: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_pick_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 0:
            return 0
        case 1:
            var v1: Int32 = (v0 as! US0_Full).f0
            return v1
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v3: US0 = US0_Empty()
    if (v0) {
        v3 = US0_Full(f0: 7)
    } else {
        v3 = US0_Empty()
    }
    var v6: US0 = US0_Empty()
    if (v0) {
        v6 = US0_Empty()
    } else {
        v6 = US0_Full(f0: 1)
    }
    var v7: Int32 = 0
    v7 = sp_pick_0(v3)
    var v8: Bool = false
    v8 = (v7 == 7)
    var v11: Bool = false
    if (v8) {
        var v9: Int32 = 0
        v9 = sp_pick_0(v6)
        var v10: Bool = false
        v10 = (v9 == 0)
        v11 = v10
    } else {
        v11 = false
    }
    if (v11) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
