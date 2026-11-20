import CRT
import WinSDK
func sp_method0(_ p0: Int32, _ p1: Int32) -> Bool {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    v2 = -v0 
    let v3: Bool = (v2 <= 0)
    if (v3) {
        let v4: Int32 = (v1 &* 2)
        let v5: Int32 = (v0 &+ v4)
        let v6: Bool = (v5 >= 9)
        if (v6) {
            return true
        } else {
            let v7: Bool = (v1 == 0)
            return v7
        }
    } else {
        return false
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: Int32 = 3
    var v2: Bool = false
    v2 = sp_method0(v0, v1)
    if (v2) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
