import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: UInt32 = UInt32(4294967295)
    let v1: UInt32 = UInt32(15)
    let v2: UInt32 = (v0 & v1)
    let v3: UInt32 = (v0 | v1)
    let v4: UInt32 = (v0 ^ v1)
    let v5: UInt32 = (~(v1))
    let v6: Bool = (v2 == UInt32(15))
    var v8: Bool = false
    if (v6) {
        let v7: Bool = (v3 == v0)
        v8 = v7
    } else {
        v8 = false
    }
    var v10: Bool = false
    if (v8) {
        let v9: Bool = (v4 == v5)
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Bool = false
    if (v10) {
        let v11: Bool = (v5 == UInt32(4294967280))
        v12 = v11
    } else {
        v12 = false
    }
    if (v12) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
