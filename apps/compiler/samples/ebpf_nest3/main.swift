import CRT
import WinSDK
func sp_method1(_ p0: Int32, _ p1: UInt32, _ p2: Float) -> (Int32, UInt32, Float) {
    var v0: Int32 = p0
    var v1: UInt32 = p1
    var v2: Float = p2
    return (v0, v1, v2)
}
func sp_method0(_ p0: Int32, _ p1: UInt32, _ p2: Float) -> Int32 {
    var v0: Int32 = p0
    var v1: UInt32 = p1
    var v2: Float = p2
    var v3: Int32 = 0
    var v4: UInt32 = UInt32(0)
    var v5: Float = (0.0 as Float)
    let spiral_tuple225 = sp_method1(v0, v1, v2)
    v3 = spiral_tuple225.0
    v4 = spiral_tuple225.1
    v5 = spiral_tuple225.2
    let v6: Bool = (v3 == 2)
    var v8: Bool = false
    if (v6) {
        let v7: Bool = (v4 == UInt32(3))
        v8 = v7
    } else {
        v8 = false
    }
    var v10: Bool = false
    if (v8) {
        let v9: Bool = (v5 == (1.5 as Float))
        v10 = v9
    } else {
        v10 = false
    }
    if (v10) {
        return 0
    } else {
        return 1
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 2
    let v1: UInt32 = UInt32(3)
    let v2: Float = (1.5 as Float)
    return sp_method0(v0, v1, v2)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
