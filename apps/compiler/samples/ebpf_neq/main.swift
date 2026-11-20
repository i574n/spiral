import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: Int32 = 4
    let v2: UInt32 = UInt32(1)
    let v3: UInt32 = UInt32(1)
    let v4: Float = (1.5 as Float)
    let v5: Float = (-(v4))
    let v6: Bool = (v0 != v1)
    if (v6) {
        let v7: Bool = (v2 != v3)
        if (v7) {
            return 2
        } else {
            let v8: Bool = (v5 == (-1.5 as Float))
            if (v8) {
                return 0
            } else {
                return 3
            }
        }
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
