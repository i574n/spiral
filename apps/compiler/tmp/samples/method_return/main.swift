import CRT
import WinSDK
func g_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Bool = false
        v2 = (v0 == 0)
        if (v2) {
            return 0
        } else {
            var v3: Int32 = 0
            v3 = (v1 &+ v0)
            return v3
        }
    }
}
func sp_method0(_ p0: Int32) -> (Int32) -> Int32 {
    var v0: Int32 = p0
    return g_c0(v0)
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v1 = sp_method0(v0)
    var v2: Int32 = 0
    v2 = v1(0)
    var v3: Bool = false
    v3 = (v2 == 7)
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
