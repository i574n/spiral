import CRT
import WinSDK
func sp_count_0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    while true {
        let v1: Bool = (v0 <= 0)
        if (v1) {
            return 0
        } else {
            let v2: Int32 = (v0 &- 1)
            v0 = v2
            continue
        }
    }
    return 0
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 5
    return sp_count_0(v0)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
