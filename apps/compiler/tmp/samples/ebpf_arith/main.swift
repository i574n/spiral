import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Int32 = 0
    v1 = 2
    var v2: UInt32 = UInt32(0)
    v2 = UInt32(4294967295)
    var v3: Int32 = 0
    v3 = (-(v0))
    var v4: Int32 = 0
    v4 = -3
    var v5: Int32 = 0
    v5 = -12
    var v6: Int32 = 0
    v6 = -4
    var v7: Int32 = 0
    v7 = -1
    var v8: Int32 = 0
    v8 = (v3 / v1)
    var v9: Bool = false
    v9 = (v8 == v4)
    if (v9) {
        var v10: Int32 = 0
        v10 = (v3 % v1)
        var v11: Bool = false
        v11 = (v10 == v7)
        if (v11) {
            var v12: Int32 = 0
            v12 = (v3 >> 1)
            var v13: Bool = false
            v13 = (v12 == v6)
            if (v13) {
                var v14: Int32 = 0
                v14 = (v4 << 2)
                var v15: Bool = false
                v15 = (v14 == v5)
                if (v15) {
                    var v16: UInt32 = UInt32(0)
                    v16 = (v2 &+ UInt32(1))
                    var v17: Bool = false
                    v17 = (v16 == UInt32(0))
                    if (v17) {
                        var v18: UInt32 = UInt32(0)
                        v18 = (v2 &* v2)
                        var v19: Bool = false
                        v19 = (v18 == UInt32(1))
                        if (v19) {
                            var v20: UInt32 = UInt32(0)
                            v20 = (v2 >> 28)
                            var v21: Bool = false
                            v21 = (v20 == UInt32(15))
                            if (v21) {
                                return 0
                            } else {
                                return 7
                            }
                        } else {
                            return 6
                        }
                    } else {
                        return 5
                    }
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
