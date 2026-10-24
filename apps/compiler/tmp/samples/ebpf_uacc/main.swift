import CRT
import WinSDK
func sp_method1(_ p0: Int32, _ p1: UInt32) -> UInt32 {
    var v0: Int32 = p0
    var v1: UInt32 = p1
    while true {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        var v3: UInt32 = UInt32(0)
        v3 = (v1 &+ UInt32(3000000000))
        let v4: Bool = (v2 == 0)
        if (v4) {
            return v3
        } else {
            v0 = v2
            v1 = v3
            continue
        }
    }
    return UInt32(0)
}
func sp_method0(_ p0: Int32, _ p1: UInt32) -> UInt32 {
    var v0: Int32 = p0
    var v1: UInt32 = p1
    var v2: Bool = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method1(v0, v1)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: UInt32 = UInt32(0)
    v1 = UInt32(0)
    var v2: UInt32 = UInt32(0)
    v2 = sp_method0(v0, v1)
    var v3: Bool = false
    v3 = (v2 == UInt32(1705032704))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
