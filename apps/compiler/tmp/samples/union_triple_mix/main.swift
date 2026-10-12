import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_One: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_All: US0 { var f0: Int32; var f1: String; var f2: Bool; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v2: Int32 = (v0 as! US0_All).f0
            var v3: String = (v0 as! US0_All).f1
            var v4: Bool = (v0 as! US0_All).f2
            var v5: Bool = false
            v5 = (v2 == 7)
            var v7: Bool = false
            if (v5) {
                var v6: Bool = false
                v6 = (v3 == "hi")
                v7 = v6
            } else {
                v7 = false
            }
            var v8: Bool = false
            v8 = (v7 && v4)
            if (v8) {
                return 0
            } else {
                return 1
            }
        case 0:
            var v1: Int32 = (v0 as! US0_One).f0
            return v1
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v1: Int32 = 0
    v1 = 7
    var v2: String = ""
    v2 = "hi"
    var v3: Bool = false
    v3 = true
    var v6: US0 = US0_One(f0: 0)
    if (v0) {
        v6 = US0_All(f0: v1, f1: v2, f2: v3)
    } else {
        v6 = US0_One(f0: 1)
    }
    return sp_score_0(v6)
}
exit(spiral_main())
