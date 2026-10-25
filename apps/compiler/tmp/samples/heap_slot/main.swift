import CRT
import WinSDK
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
    let v0: Int32 = 3
    let v1: Int32 = 4
    let v2: US0 = US0_Some(f0: v0)
    let v3: Heap0 = Heap0(l0: v2, l1: v1)
    var v4: US0 = US0_None()
    var v5: Int32 = 0
    v4 = v3.l0
    v5 = v3.l1
    switch v4.tag {
        case 0:
            return 1
        case 1:
            var v6: Int32 = (v4 as! US0_Some).f0
            let v7: Int32 = (v6 &+ v5)
            let v8: Bool = (v7 == 7)
            if (v8) {
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
