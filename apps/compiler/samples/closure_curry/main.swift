import CRT
import WinSDK
func closure1(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v0 &* 10)
        var v3: Int32 = 0
        v3 = (v2 &+ v1)
        return v3
    }
}
func f_c0() -> (Int32) -> (Int32) -> Int32 {
    return { (v0: Int32) -> (Int32) -> Int32 in
        return closure1(v0)
    }
}
func spiral_main() -> Int32 {
    let v0: (Int32) -> (Int32) -> Int32 = f_c0()
    let v1: (Int32) -> Int32 = v0(3)
    var v2: Int32 = 0
    v2 = v1(4)
    var v3: Bool = false
    v3 = (v2 == 34)
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
