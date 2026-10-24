import CRT
import WinSDK
func sp_method0() -> Bool {
    return true
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 0
    var v1: Int32 = 0
    v1 = 0
    while true {
        if !(sp_method0()) { break }
        let v3: Int32 = (v0 &+ 1)
        v0 = v3
        let v4: Bool = (v0 < 3)
        if (v4) {
            continue
        } else {
            let v5: Bool = (v0 >= 6)
            if (v5) {
                break
            } else {
                let v6: Int32 = (v1 &+ v0)
                v1 = v6
            }
        }
    }
    let v7: Int32 = (v1 &- 12)
    return v7
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
