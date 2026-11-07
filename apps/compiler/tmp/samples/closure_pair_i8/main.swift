import CRT
import WinSDK
func f_c0(_ v0: Int8) -> (Int32) -> (Int8, Int8) {
    return { (v1: Int32) -> (Int8, Int8) in
        var v2: Bool = false
        v2 = (v1 == 0)
        if (v2) {
            return (Int8(0), Int8(0))
        } else {
            return (v0, Int8(7))
        }
    }
}
func spiral_main() -> Int32 {
    let v0: Int8 = Int8(100)
    let v1: (Int32) -> (Int8, Int8) = f_c0(v0)
    var v2: Int8 = Int8(0)
    var v3: Int8 = Int8(0)
    let spiral_tuple254 = v1(1)
    v2 = spiral_tuple254.0
    v3 = spiral_tuple254.1
    let v4: Bool = (v2 == Int8(100))
    var v6: Bool = false
    if (v4) {
        let v5: Bool = (v3 == Int8(7))
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
