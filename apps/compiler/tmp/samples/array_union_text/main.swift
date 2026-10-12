import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Both: US0 { var f0: String; var f1: String; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: String = (v0 as! US0_Both).f0
            var v2: String = (v0 as! US0_Both).f1
            var v3: Bool = false
            v3 = (v1 == "hi")
            var v5: Bool = false
            if (v3) {
                var v4: Bool = false
                v4 = (v2 == "yo")
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
    var v0: Array<US0> = Array<US0>()
    v0 = Array<US0>(repeating: US0_None(), count: Int(1))
    var v1: String = ""
    v1 = "hi"
    var v2: String = ""
    v2 = "yo"
    var v3: Bool = false
    v3 = true
    var v6: US0 = US0_None()
    if (v3) {
        v6 = US0_Both(f0: v1, f1: v2)
    } else {
        v6 = US0_None()
    }
    v0[Int(0)] = v6
    var v7: US0 = US0_None()
    v7 = v0[Int(0)]
    return sp_score_0(v7)
}
exit(spiral_main())
