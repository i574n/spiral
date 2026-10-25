import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Missing: US0 { var tag: Int32 { 0 } }
struct US0_Call: US0 { var f0: (Int32) -> Int32; var tag: Int32 { 1 } }
func f_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v1 &+ v0)
        return v2
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: Bool = false
    v2 = true
    var v5: US0 = US0_Missing()
    if (v2) {
        v5 = US0_Call(f0: v1)
    } else {
        v5 = US0_Missing()
    }
    switch v5.tag {
        case 1:
            var v6: (Int32) -> Int32 = (v5 as! US0_Call).f0
            var v7: Int32 = 0
            v7 = v6(4)
            var v8: Bool = false
            v8 = (v7 == 7)
            if (v8) {
                return 0
            } else {
                return 1
            }
        case 0:
            return 1
        default:
            fatalError("unreachable union case")
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
