import CRT
import WinSDK
protocol UH0 { var tag: Int32 { get } }
struct UH0_Empty: UH0 { var tag: Int32 { 0 } }
struct UH0_Box: UH0 { var f0: Int32; var f1: UH0; var tag: Int32 { 1 } }
func sp_method2(_ p0: Int32) -> UH0 {
    var v0: Int32 = p0
    var v1: Int32 = 0
    v1 = (v0 &- 1)
    var v2: Bool = false
    v2 = (v1 == 0)
    if (v2) {
        var v3: UH0 = UH0_Empty()
        v3 = UH0_Empty()
        return UH0_Box(f0: 7, f1: v3)
    } else {
        return sp_method1(v1)
    }
}
func sp_method1(_ p0: Int32) -> UH0 {
    var v0: Int32 = p0
    var v1: Int32 = 0
    v1 = (v0 &- 1)
    var v2: Bool = false
    v2 = (v1 == 0)
    if (v2) {
        var v3: UH0 = UH0_Empty()
        v3 = UH0_Empty()
        return UH0_Box(f0: 11, f1: v3)
    } else {
        return sp_method2(v1)
    }
}
func sp_method0() -> UH0 {
    var v0: Int32 = 0
    v0 = 1000000
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: UH0 = UH0_Empty()
        v2 = UH0_Empty()
        return UH0_Box(f0: 7, f1: v2)
    } else {
        return sp_method1(v0)
    }
}
func spiral_main() -> Int32 {
    var v0: UH0 = UH0_Empty()
    v0 = sp_method0()
    switch v0.tag {
        case 1:
            var v1: Int32 = (v0 as! UH0_Box).f0
            var v2: UH0 = (v0 as! UH0_Box).f1
            var v3: Bool = false
            v3 = (v1 == 7)
            if (v3) {
                return 0
            } else {
                return 3
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
