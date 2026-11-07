import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: UInt32 = UInt32(65536)
    let v1: UInt32 = UInt32(65536)
    let v2: UInt32 = UInt32(4294967295)
    let v3: UInt32 = UInt32(3)
    let v4: UInt32 = (v0 &* v1)
    let v5: UInt32 = (v2 &* v3)
    let v6: Bool = (v4 == UInt32(0))
    var v8: Bool = false
    if (v6) {
        let v7: Bool = (v5 == UInt32(4294967293))
        v8 = v7
    } else {
        v8 = false
    }
    if (v8) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
