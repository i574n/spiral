import CRT
class Heap0 {
    let l0: US0
    let l1: Int32
    init(l0: US0, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: US0 = US0_None()
    v2 = US0_Some(f0: v0)
    var v3: Heap0 = Heap0(l0: US0_None(), l1: 0)
    v3 = Heap0(l0: v2, l1: v1)
    var v4: US0 = US0_None()
    var v5: Int32 = 0
    v4 = v3.l0
    v5 = v3.l1
    switch v4.tag {
        case 0:
            return 1
        case 1:
            var v6: Int32 = (v4 as! US0_Some).f0
            var v7: Int32 = 0
            v7 = (v6 &+ v5)
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
