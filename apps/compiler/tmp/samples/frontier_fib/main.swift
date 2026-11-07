import CRT
import WinSDK
func sp_fib_0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 <= 1)
    if (v1) {
        return v0
    } else {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        let v3: Int32 = sp_fib_0(v2)
        let v4: Int32 = (v0 &- 2)
        let v5: Int32 = sp_fib_0(v4)
        let v6: Int32 = (v3 &+ v5)
        return v6
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 10
    var v1: Int32 = 0
    v1 = sp_fib_0(v0)
    var v2: Int32 = 0
    v2 = (v1 &- 55)
    return v2
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
