import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: UInt32 = UInt32(1)
    let v1: Int32 = 0
    let v2: Int32 = 31
    let v3: UInt32 = (v0 << v2)
    let v4: UInt32 = (v3 >> v2)
    let v5: UInt32 = (v0 << v1)
    let v6: Bool = (v3 == UInt32(2147483648))
    var v8: Bool = false
    if (v6) {
        let v7: Bool = (v4 == UInt32(1))
        v8 = v7
    } else {
        v8 = false
    }
    var v10: Bool = false
    if (v8) {
        let v9: Bool = (v5 == UInt32(1))
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
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
