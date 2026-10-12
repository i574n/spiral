import CRT
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_method0(_ p0: Int32, _ p1: Heap0) -> (US0, Heap0) {
    var v0: Int32 = p0
    var v1: Heap0 = p1
    var v2: US0 = US0_None()
    v2 = US0_Some(f0: v0)
    return (v2, v1)
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: Heap0 = Heap0(l0: 0)
    v2 = Heap0(l0: v1)
    var v3: US0 = US0_None()
    var v4: Heap0 = Heap0(l0: 0)
    let spiral_tuple223 = sp_method0(v0, v2)
    v3 = spiral_tuple223.0
    v4 = spiral_tuple223.1
    switch v3.tag {
        case 0:
            return 1
        case 1:
            var v5: Int32 = (v3 as! US0_Some).f0
            var v6: Int32 = 0
            v6 = v4.l0
            var v7: Int32 = 0
            v7 = (v5 &+ v6)
            var v8: Bool = false
            v8 = (v7 == 7)
            if (v8) {
                return 0
            } else {
                return 1
            }
        default:
            fatalError("unreachable union case")
    }
}
exit(spiral_main())
