import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Float = (-1.5 as Float)
    let v1: Float = (2.0 as Float)
    let v2: Float = (v0 / v1)
    let v3: Float = (-0.75 as Float)
    let v4: Float = (v0 * v1)
    let v5: Float = (v4 + (0.5 as Float))
    let v6: Float = (-2.5 as Float)
    let v7: Bool = (v2 == v3)
    if (v7) {
        let v8: Bool = (v5 == v6)
        if (v8) {
            return 0
        } else {
            return 2
        }
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
