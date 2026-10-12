import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_Circle: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_Square: US0 { var f0: Int32; var tag: Int32 { 1 } }
struct US0_Tri: US0 { var f0: Int32; var tag: Int32 { 2 } }
struct US0_Dot: US0 { var tag: Int32 { 3 } }
func sp_pick_0(_ p0: Int32) -> US0 {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        return US0_Circle(f0: 5)
    } else {
        var v3: Bool = false
        v3 = (v0 == 1)
        if (v3) {
            return US0_Square(f0: 4)
        } else {
            var v5: Bool = false
            v5 = (v0 == 2)
            if (v5) {
                return US0_Tri(f0: 7)
            } else {
                return US0_Dot()
            }
        }
    }
}
func sp_measure_1(_ p0: US0, _ p1: Int32) -> Int32 {
    var v0: US0 = p0
    var v1: Int32 = p1
    switch v0.tag {
        case 0:
            var v2: Int32 = (v0 as! US0_Circle).f0
            var v3: Int32 = 0
            v3 = (v2 &* 3)
            return v3
        default:
            var v4: Int32 = 0
            v4 = (v1 &* v1)
            var v5: Bool = false
            v5 = (v4 > 3)
            switch v0.tag {
                case 3:
                    return v4
                case 1:
                    var v6: Int32 = (v0 as! US0_Square).f0
                    if (v5) {
                        var v7: Int32 = 0
                        v7 = (v6 &* v6)
                        return v7
                    } else {
                        return v6
                    }
                case 2:
                    var v9: Int32 = (v0 as! US0_Tri).f0
                    if (v5) {
                        var v10: Int32 = 0
                        v10 = (v9 &* 2)
                        return v10
                    } else {
                        return v9
                    }
                default:
                    fatalError("unreachable union case")
            }
    }
}
func sp_measure_tri_2(_ p0: US0, _ p1: Int32) -> Int32 {
    var v0: US0 = p0
    var v1: Int32 = p1
    switch v0.tag {
        case 0:
            var v2: Int32 = (v0 as! US0_Circle).f0
            return v2
        case 3:
            return 0
        case 1:
            var v3: Int32 = (v0 as! US0_Square).f0
            return v3
        default:
            var v4: Int32 = 0
            v4 = (v1 &+ 2)
            switch v0.tag {
                case 2:
                    var v5: Int32 = (v0 as! US0_Tri).f0
                    var v6: Int32 = 0
                    v6 = (v5 &* v4)
                    return v6
                default:
                    fatalError("unreachable union case")
            }
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 0
    var v1: US0 = US0_Circle(f0: 0)
    v1 = sp_pick_0(v0)
    var v2: Int32 = 0
    v2 = sp_measure_1(v1, v0)
    var v3: Int32 = 0
    v3 = (v0 &+ 1)
    var v4: US0 = US0_Circle(f0: 0)
    v4 = sp_pick_0(v3)
    var v5: Int32 = 0
    v5 = sp_measure_1(v4, v3)
    var v6: Int32 = 0
    v6 = (v2 &+ v5)
    var v7: Int32 = 0
    v7 = (v0 &+ 2)
    var v8: US0 = US0_Circle(f0: 0)
    v8 = sp_pick_0(v7)
    var v9: Int32 = 0
    v9 = sp_measure_1(v8, v7)
    var v10: Int32 = 0
    v10 = (v6 &+ v9)
    var v11: Int32 = 0
    v11 = (v0 &+ 3)
    var v12: US0 = US0_Circle(f0: 0)
    v12 = sp_pick_0(v11)
    var v13: Int32 = 0
    v13 = sp_measure_1(v12, v11)
    var v14: Int32 = 0
    v14 = (v10 &+ v13)
    var v15: US0 = US0_Circle(f0: 0)
    v15 = sp_pick_0(v7)
    var v16: Int32 = 0
    v16 = sp_measure_tri_2(v15, v0)
    var v17: Int32 = 0
    v17 = (v14 &+ v16)
    var v18: US0 = US0_Circle(f0: 0)
    v18 = sp_pick_0(v0)
    var v19: Int32 = 0
    v19 = sp_measure_tri_2(v18, v0)
    var v20: Int32 = 0
    v20 = (v17 &+ v19)
    return v20
}
exit(spiral_main())
