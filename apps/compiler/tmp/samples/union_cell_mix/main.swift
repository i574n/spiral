import CRT
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Heap0; var f1: Int32; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: Heap0 = (v0 as! US0_Held).f0
            var v2: Int32 = (v0 as! US0_Held).f1
            var v3: Int32 = 0
            v3 = v1.l0
            var v4: Int32 = 0
            v4 = (v3 &+ v2)
            var v5: Bool = false
            v5 = (v4 == 7)
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
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: Heap0 = Heap0(l0: 0)
    v2 = Heap0(l0: v0)
    var v3: Bool = false
    v3 = true
    var v6: US0 = US0_None()
    if (v3) {
        v6 = US0_Held(f0: v2, f1: v1)
    } else {
        v6 = US0_None()
    }
    return sp_score_0(v6)
}
exit(spiral_main())
