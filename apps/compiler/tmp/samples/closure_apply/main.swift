import CRT
import WinSDK
func f_c0() -> (Int32) -> Int32 {
    return { (v0: Int32) -> Int32 in
        var v1: Int32 = 0
        v1 = (v0 &+ 1)
        return v1
    }
}
func spiral_main() -> Int32 {
    let v0: (Int32) -> Int32 = f_c0()
    var v1: Int32 = 0
    v1 = v0(6)
    let v2: Bool = (v1 == 7)
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
