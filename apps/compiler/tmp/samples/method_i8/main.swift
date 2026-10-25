import CRT
import WinSDK
func sp_method0(_ p0: Int8) -> Int8 {
    var v0: Int8 = p0
    var v1: Bool = false
    v1 = (v0 == Int8(0))
    if (v1) {
        return Int8(1)
    } else {
        return v0
    }
}
func spiral_main() -> Int32 {
    let v0: Int8 = Int8(100)
    var v1: Int8 = Int8(0)
    v1 = sp_method0(v0)
    let v2: Bool = (v1 == Int8(100))
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
