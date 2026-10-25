import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    let v1: Int32 = -2
    let v2: Int32 = -7
    let v3: UInt32 = UInt32(100)
    let v4: UInt32 = UInt32(7)
    let v5: Int32 = (v0 / v1)
    let v6: Int32 = (v0 % v1)
    let v7: Int32 = (v2 / v1)
    let v8: Int32 = (v2 % v1)
    let v9: UInt32 = (v3 / v4)
    let v10: UInt32 = (v3 % v4)
    let v11: Bool = (v5 == -3)
    var v13: Bool = false
    if (v11) {
        let v12: Bool = (v6 == 1)
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Bool = false
    if (v13) {
        let v14: Bool = (v7 == 3)
        v15 = v14
    } else {
        v15 = false
    }
    var v17: Bool = false
    if (v15) {
        let v16: Bool = (v8 == -1)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Bool = false
    if (v17) {
        let v18: Bool = (v9 == UInt32(14))
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Bool = false
    if (v19) {
        let v20: Bool = (v10 == UInt32(2))
        v21 = v20
    } else {
        v21 = false
    }
    if (v21) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
