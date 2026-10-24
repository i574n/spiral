import CRT
import WinSDK
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
    let v0: Int32 = 7
    let v1: Bool = true
    var v4: US0 = US0_None()
    if (v1) {
        v4 = US0_Some(f0: v0)
    } else {
        v4 = US0_None()
    }
    let v5: Heap0 = Heap0(l0: v4)
    let v6: US0 = v5.l0
    switch v6.tag {
        case 0:
            return 1
        case 1:
            var v7: Int32 = (v6 as! US0_Some).f0
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
