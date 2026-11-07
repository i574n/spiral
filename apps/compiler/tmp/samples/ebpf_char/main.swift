import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = 65
    let v1: Int32 = 66
    let v2: Bool = (v0 == 65)
    if (v2) {
        let v3: Bool = (v1 == 66)
        if (v3) {
            let v4: Bool = (v0 == v1)
            if (v4) {
                return 2
            } else {
                return 0
            }
        } else {
            return 3
        }
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
