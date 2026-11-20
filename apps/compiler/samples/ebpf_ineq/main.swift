import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = -3
    let v1: Int32 = -4
    let v2: Int32 = -3
    let v3: UInt32 = UInt32(4294967295)
    let v4: UInt32 = UInt32(0)
    let v5: UInt32 = UInt32(4294967295)
    let v6: Float = (-1.5 as Float)
    let v7: Float = (-0.5 as Float)
    let v8: Float = (-1.5 as Float)
    let v9: Bool = (v0 != v1)
    let v10: Bool = (v0 != v2)
    let v11: Bool = (v3 != v4)
    let v12: Bool = (v3 != v5)
    let v13: Bool = (v6 != v7)
    let v14: Bool = (v6 != v8)
    let v15: Bool = (v9 && v11)
    let v16: Bool = (v15 && v13)
    if (v16) {
        if (v10) {
            return 1
        } else {
            if (v12) {
                return 2
            } else {
                if (v14) {
                    return 3
                } else {
                    return 0
                }
            }
        }
    } else {
        return 4
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
