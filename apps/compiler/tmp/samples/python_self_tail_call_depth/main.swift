import CRT
import WinSDK
func sp_count_down_0(_ p0: Int32, _ p1: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    while true {
        var v2: Bool = false
        v2 = (0 < v0)
        if (v2) {
            var v3: Int32 = 0
            v3 = (v0 &- 1)
            var v4: Int32 = 0
            v4 = (v1 &+ 1)
            let t315_3: Int32 = v3
            let t351_4: Int32 = v4
            v0 = t315_3
            v1 = t351_4
            continue
        } else {
            return v1
        }
    }
    return 0
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 5000
    var v1: Int32 = 0
    v1 = 0
    var v2: Int32 = 0
    v2 = sp_count_down_0(v0, v1)
    var v3: Bool = false
    v3 = (v2 == 5000)
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
