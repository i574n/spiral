import CRT
import WinSDK
func sp_method0(_ p0: Int32) -> Bool {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 < 10)
    return v1
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 0
    var v1: Int32 = 0
    v1 = 0
    while true {
        if !(sp_method0(v0)) { break }
        let v3: Int32 = (v1 &+ v0)
        v1 = v3
        let v4: Int32 = (v0 &+ 1)
        v0 = v4
    }
    let v5: Int32 = (v1 &- 45)
    return v5
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
