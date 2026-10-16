import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_Missing: US0 { var tag: Int32 { 0 } }
struct US0_Box: US0 { var f0: Heap0; var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Heap0 = Heap0(l0: 0)
    v1 = Heap0(l0: v0)
    var v2: Bool = false
    v2 = true
    var v5: US0 = US0_Missing()
    if (v2) {
        v5 = US0_Box(f0: v1)
    } else {
        v5 = US0_Missing()
    }
    switch v5.tag {
        case 1:
            var v6: Heap0 = (v5 as! US0_Box).f0
            var v7: Int32 = 0
            v7 = v6.l0
            var v8: Bool = false
            v8 = (v7 == 7)
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
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
