import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_method0(_ p0: Int32) -> US0 {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        return US0_None()
    } else {
        return US0_Some(f0: v0)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: US0 = US0_None()
    v1 = sp_method0(v0)
    switch v1.tag {
        case 0:
            return 1
        case 1:
            var v2: Int32 = (v1 as! US0_Some).f0
            var v3: Bool = false
            v3 = (v2 == 7)
            if (v3) {
                return 0
            } else {
                return 1
            }
        default:
            fatalError("unreachable union case")
    }
}
exit(spiral_main())
