import CRT
import WinSDK
func f_c0(_ v0: Bool) -> (Int32) -> (Bool, Bool) {
    return { (v1: Int32) -> (Bool, Bool) in
        var v2: Bool = false
        v2 = (v1 == 0)
        if (v2) {
            return (false, false)
        } else {
            return (v0, true)
        }
    }
}
func spiral_main() -> Int32 {
    let v0: Bool = true
    let v1: (Int32) -> (Bool, Bool) = f_c0(v0)
    var v2: Bool = false
    var v3: Bool = false
    let spiral_tuple250 = v1(1)
    v2 = spiral_tuple250.0
    v3 = spiral_tuple250.1
    let v4: Bool = (v2 && v3)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
