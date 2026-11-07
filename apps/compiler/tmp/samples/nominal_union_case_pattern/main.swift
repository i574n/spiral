import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Zero: US0 { var tag: Int32 { 0 } }
struct US0_One: US0 { var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    let v0: US0 = US0_Zero()
    var v2: Bool = false
    switch v0.tag {
        case 1:
            v2 = false
        case 0:
            v2 = true
        default:
            fatalError("unreachable union case")
    }
    if (v2) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
