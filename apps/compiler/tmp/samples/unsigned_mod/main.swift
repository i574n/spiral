import CRT
import WinSDK
func sp_method0(_ p0: UInt32) -> Bool {
    var v0: UInt32 = p0
    var v1: UInt32 = UInt32(0)
    v1 = (v0 &+ UInt32(5))
    var v2: UInt32 = UInt32(0)
    v2 = (v1 % UInt32(4))
    var v3: Bool = false
    v3 = (v2 == UInt32(0))
    return v3
}
func spiral_main() -> Int32 {
    var v0: UInt32 = UInt32(0)
    v0 = UInt32(7)
    var v1: Bool = false
    v1 = sp_method0(v0)
    if (v1) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
