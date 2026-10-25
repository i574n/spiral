import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 1 } }
func f_c0(_ v0: Int32, _ v1: Heap0) -> (Int32) -> (US0, Heap0) {
    return { (v2: Int32) -> (US0, Heap0) in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: US0 = US0_None()
            v4 = US0_None()
            return (v4, v1)
        } else {
            var v5: US0 = US0_None()
            v5 = US0_Some(f0: v0)
            return (v5, v1)
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: Heap0 = Heap0(l0: 0)
    v2 = Heap0(l0: v1)
    var v3: (Int32) -> (US0, Heap0) = { (_: Int32) -> (US0, Heap0) in fatalError("unreachable closure") }
    v3 = f_c0(v0, v2)
    var v4: US0 = US0_None()
    var v5: Heap0 = Heap0(l0: 0)
    let spiral_tuple353 = v3(1)
    v4 = spiral_tuple353.0
    v5 = spiral_tuple353.1
    switch v4.tag {
        case 0:
            return 1
        case 1:
            var v6: Int32 = (v4 as! US0_Some).f0
            var v7: Int32 = 0
            v7 = v5.l0
            var v8: Int32 = 0
            v8 = (v6 &+ v7)
            var v9: Bool = false
            v9 = (v8 == 7)
            if (v9) {
                return 0
            } else {
                return 1
            }
        default:
            fatalError("unreachable union case")
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
