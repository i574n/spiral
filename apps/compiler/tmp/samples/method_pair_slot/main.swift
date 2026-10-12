import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_method0(_ p0: Int32) -> (US0, Int32) {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: US0 = US0_None()
        v2 = US0_None()
        return (v2, 0)
    } else {
        var v3: US0 = US0_None()
        v3 = US0_Some(f0: v0)
        return (v3, v0)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: US0 = US0_None()
    var v2: Int32 = 0
    let spiral_tuple119 = sp_method0(v0)
    v1 = spiral_tuple119.0
    v2 = spiral_tuple119.1
    switch v1.tag {
        case 0:
            return 1
        case 1:
            var v3: Int32 = (v1 as! US0_Some).f0
            var v4: Bool = false
            v4 = (v3 == 7)
            var v6: Bool = false
            if (v4) {
                var v5: Bool = false
                v5 = (v2 == 7)
                v6 = v5
            } else {
                v6 = false
            }
            if (v6) {
                return 0
            } else {
                return 1
            }
        default:
            fatalError("unreachable union case")
    }
}
exit(spiral_main())
