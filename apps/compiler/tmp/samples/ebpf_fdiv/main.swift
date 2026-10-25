import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Float = (1.5 as Float)
    let v1: Float = (-2.0 as Float)
    let v2: Float = (-0.5 as Float)
    let v3: Float = (v0 / v1)
    let v4: Float = (v2 / v1)
    let v5: Bool = (v3 == (-0.75 as Float))
    var v7: Bool = false
    if (v5) {
        let v6: Bool = (v4 == (0.25 as Float))
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
