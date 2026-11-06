import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_First: US0 { var tag: Int32 { 1 } }
struct US0_Second: US0 { var tag: Int32 { 2 } }
func spiral_main() -> Int32 {
    let v0: US0 = US0_Second()
    let v1: Int32 = (v0).tag
    let v2: Int32 = (v1 &* 10)
    let v3: Int32 = (v2 &+ 2)
    return v3
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
