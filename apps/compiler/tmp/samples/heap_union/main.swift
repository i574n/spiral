import CRT
class Heap0 {
    let l0: US0
    init(l0: US0) {
        self.l0 = l0
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Bool = false
    v1 = true
    var v4: US0 = US0_None()
    if (v1) {
        v4 = US0_Some(f0: v0)
    } else {
        v4 = US0_None()
    }
    var v5: Heap0 = Heap0(l0: US0_None())
    v5 = Heap0(l0: v4)
    var v6: US0 = US0_None()
    v6 = v5.l0
    switch v6.tag {
        case 0:
            return 1
        case 1:
            var v7: Int32 = (v6 as! US0_Some).f0
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
