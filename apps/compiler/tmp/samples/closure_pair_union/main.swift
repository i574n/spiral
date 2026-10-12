import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 1 } }
func f_c0(_ v0: Int32) -> (Int32) -> (US0, US0) {
    return { (v1: Int32) -> (US0, US0) in
        var v2: Bool = false
        v2 = (v1 == 0)
        if (v2) {
            var v3: US0 = US0_None()
            v3 = US0_None()
            var v4: US0 = US0_None()
            v4 = US0_None()
            return (v3, v4)
        } else {
            var v5: US0 = US0_None()
            v5 = US0_Some(f0: v0)
            var v6: US0 = US0_None()
            v6 = US0_None()
            return (v5, v6)
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: (Int32) -> (US0, US0) = { (_: Int32) -> (US0, US0) in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: US0 = US0_None()
    var v3: US0 = US0_None()
    let spiral_tuple248 = v1(1)
    v2 = spiral_tuple248.0
    v3 = spiral_tuple248.1
    switch v2.tag {
        case 0:
            return 1
        case 1:
            var v4: Int32 = (v2 as! US0_Some).f0
            switch v3.tag {
                case 0:
                    var v5: Bool = false
                    v5 = (v4 == 7)
                    if (v5) {
                        return 0
                    } else {
                        return 1
                    }
                case 1:
                    var v7: Int32 = (v3 as! US0_Some).f0
                    return 1
                default:
                    fatalError("unreachable union case")
            }
        default:
            fatalError("unreachable union case")
    }
}
exit(spiral_main())
