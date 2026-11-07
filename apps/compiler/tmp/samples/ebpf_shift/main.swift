import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = -8
    let v1: Int32 = 3
    let v2: Int32 = 1
    let v3: UInt32 = UInt32(4294967295)
    let v4: Int32 = 4
    let v5: Int32 = (v0 >> v2)
    let v6: Int32 = (v1 << v2)
    let v7: UInt32 = (v3 >> v4)
    let v8: UInt32 = (v3 << v2)
    let v9: Bool = (v5 == -4)
    if (v9) {
        let v10: Bool = (v6 == 6)
        if (v10) {
            let v11: Bool = (v7 == UInt32(268435455))
            if (v11) {
                let v12: Bool = (v8 == UInt32(4294967294))
                if (v12) {
                    return 0
                } else {
                    return 4
                }
            } else {
                return 3
            }
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
