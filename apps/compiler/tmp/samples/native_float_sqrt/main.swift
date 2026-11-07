import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Float = (144.0 as Float)
    let v1: Double = (81.0 as Double)
    let v2: Float = sqrtf(v0)
    let v3: Double = sqrt(v1)
    let v4: Bool = (v2 == (12.0 as Float))
    var v6: Bool = false
    if (v4) {
        let v5: Bool = (v3 == (9.0 as Double))
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
