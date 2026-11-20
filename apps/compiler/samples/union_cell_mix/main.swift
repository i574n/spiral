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
struct US0_Held: US0 { var f0: Heap0; var f1: Int32; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: Heap0 = (v0 as! US0_Held).f0
            var v2: Int32 = (v0 as! US0_Held).f1
            var v3: Int32 = 0
            v3 = v1.l0
            let v4: Int32 = (v3 &+ v2)
            let v5: Bool = (v4 == 7)
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
    let v0: Int32 = 3
    let v1: Int32 = 4
    let v2: Heap0 = Heap0(l0: v0)
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
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
