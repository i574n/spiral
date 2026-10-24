import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: UInt32 = UInt32(2147483647)
    let v1: UInt32 = UInt32(2)
    let v2: UInt32 = UInt32(1)
    let v3: UInt32 = (v0 &+ v1)
    let v4: UInt32 = (v0 &+ v2)
    let v5: Bool = (v3 == UInt32(2147483649))
    var v7: Bool = false
    if (v5) {
        let v6: Bool = (v4 == UInt32(2147483648))
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
