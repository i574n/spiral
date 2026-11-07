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
    let v0: Int32 = 7
    let v1: Heap0 = Heap0(l0: v0)
    let v2: Bool = true
    var v5: US0 = US0_Missing()
    if (v2) {
        v5 = US0_Box(f0: v1)
    } else {
        v5 = US0_Missing()
    }
    switch v5.tag {
        case 1:
            var v6: Heap0 = (v5 as! US0_Box).f0
            let v7: Int32 = v6.l0
            let v8: Bool = (v7 == 7)
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
