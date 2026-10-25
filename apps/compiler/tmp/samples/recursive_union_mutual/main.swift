import CRT
import WinSDK
protocol UH1 { var tag: Int32 { get } }
struct UH1_B: UH1 { var f0: UH0; var tag: Int32 { 0 } }
struct UH1_StopB: UH1 { var tag: Int32 { 1 } }
protocol UH0 { var tag: Int32 { get } }
struct UH0_A: UH0 { var f0: UH1; var tag: Int32 { 0 } }
struct UH0_StopA: UH0 { var tag: Int32 { 1 } }
struct UH0_Zero: UH0 { var tag: Int32 { -1 } }
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v5: UH0 = UH0_A(f0: UH1_B(f0: UH0_Zero()))
    if (v0) {
        var v1: UH0 = UH0_A(f0: UH1_B(f0: UH0_Zero()))
        v1 = UH0_StopA()
        var v2: UH1 = UH1_B(f0: UH0_Zero())
        v2 = UH1_B(f0: v1)
        v5 = UH0_A(f0: v2)
    } else {
        v5 = UH0_StopA()
    }
    switch v5.tag {
        case 0:
            var v6: UH1 = (v5 as! UH0_A).f0
            return 0
        case 1:
            return 0
        default:
            fatalError("unreachable union case")
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
