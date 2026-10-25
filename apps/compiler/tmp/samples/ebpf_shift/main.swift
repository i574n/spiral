import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = -8
    var v1: Int32 = 0
    v1 = 3
    var v2: Int32 = 0
    v2 = 1
    var v3: UInt32 = UInt32(0)
    v3 = UInt32(4294967295)
    var v4: Int32 = 0
    v4 = 4
    var v5: Int32 = 0
    v5 = (v0 >> v2)
    var v6: Int32 = 0
    v6 = (v1 << v2)
    var v7: UInt32 = UInt32(0)
    v7 = (v3 >> v4)
    var v8: UInt32 = UInt32(0)
    v8 = (v3 << v2)
    var v9: Bool = false
    v9 = (v5 == -4)
    if (v9) {
        var v10: Bool = false
        v10 = (v6 == 6)
        if (v10) {
            var v11: Bool = false
            v11 = (v7 == UInt32(268435455))
            if (v11) {
                var v12: Bool = false
                v12 = (v8 == UInt32(4294967294))
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
