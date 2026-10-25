import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Missing: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Int8; var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    var v0: Int8 = Int8(0)
    v0 = Int8(100)
    var v1: Bool = false
    v1 = true
    var v4: US0 = US0_Missing()
    if (v1) {
        v4 = US0_Held(f0: v0)
    } else {
        v4 = US0_Missing()
    }
    switch v4.tag {
        case 1:
            var v5: Int8 = (v4 as! US0_Held).f0
            var v6: Bool = false
            v6 = (v5 == Int8(100))
            if (v6) {
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
