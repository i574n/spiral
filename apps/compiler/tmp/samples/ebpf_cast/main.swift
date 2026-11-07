import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: Int32 = -2
    let v2: UInt32 = UInt32(7)
    let v3: Float = (2.9 as Float)
    let v4: Float = Float(v0)
    let v5: Float = Float(v1)
    let v6: Float = Float(v2)
    let v7: UInt32 = UInt32(v3)
    let v8: Bool = (v4 == (3.0 as Float))
    var v10: Bool = false
    if (v8) {
        let v9: Bool = (v5 == (-2.0 as Float))
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Bool = false
    if (v10) {
        let v11: Bool = (v6 == (7.0 as Float))
        v12 = v11
    } else {
        v12 = false
    }
    var v14: Bool = false
    if (v12) {
        let v13: Bool = (v7 == UInt32(2))
        v14 = v13
    } else {
        v14 = false
    }
    if (v14) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
