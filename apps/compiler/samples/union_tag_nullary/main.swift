import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Red: US0 { var tag: Int32 { 0 } }
struct US0_Amber: US0 { var tag: Int32 { 1 } }
struct US0_Green: US0 { var tag: Int32 { 2 } }
func spiral_main() -> Int32 {
    let v0: US0 = US0_Amber()
    let v1: Int32 = (v0).tag
    return v1
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
