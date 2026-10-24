import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    let v1: Int32 = 2
    let v2: UInt32 = UInt32(4294967295)
    let v3: Int32 = (-(v0))
    let v4: Int32 = -3
    let v5: Int32 = -12
    let v6: Int32 = -4
    let v7: Int32 = -1
    let v8: Int32 = (v3 / v1)
    let v9: Bool = (v8 == v4)
    if (v9) {
        let v10: Int32 = (v3 % v1)
        let v11: Bool = (v10 == v7)
        if (v11) {
            let v12: Int32 = (v3 >> 1)
            let v13: Bool = (v12 == v6)
            if (v13) {
                let v14: Int32 = (v4 << 2)
                let v15: Bool = (v14 == v5)
                if (v15) {
                    let v16: UInt32 = (v2 &+ UInt32(1))
                    let v17: Bool = (v16 == UInt32(0))
                    if (v17) {
                        let v18: UInt32 = (v2 &* v2)
                        let v19: Bool = (v18 == UInt32(1))
                        if (v19) {
                            let v20: UInt32 = (v2 >> 28)
                            let v21: Bool = (v20 == UInt32(15))
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
