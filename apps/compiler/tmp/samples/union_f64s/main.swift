import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_Missing: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Array<Double>; var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    var v0: Array<Double> = Array<Double>()
    v0 = Array<Double>(repeating: (0.0 as Double), count: Int(1))
    var v1: Double = (0.0 as Double)
    v1 = (1.5 as Double)
    v0[Int(0)] = v1
    var v2: Bool = false
    v2 = true
    var v5: US0 = US0_Missing()
    if (v2) {
        v5 = US0_Held(f0: v0)
    } else {
        v5 = US0_Missing()
    }
    switch v5.tag {
        case 1:
            var v6: Array<Double> = (v5 as! US0_Held).f0
            var v7: Double = (0.0 as Double)
            v7 = v6[Int(0)]
            var v8: Bool = false
            v8 = (v7 == (1.5 as Double))
            if (v8) {
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
exit(spiral_main())
