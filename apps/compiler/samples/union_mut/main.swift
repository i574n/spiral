import CRT
import WinSDK
class Mut0 {
    var l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_Missing: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Mut0; var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    let v0: Mut0 = Mut0(l0: 1)
    let v1: Bool = true
    var v4: US0 = US0_Missing()
    if (v1) {
        v4 = US0_Held(f0: v0)
    } else {
        v4 = US0_Missing()
    }
    switch v4.tag {
        case 1:
            var v5: Mut0 = (v4 as! US0_Held).f0
            v5.l0 = 7
            let v6: Int32 = v5.l0
            let v7: Bool = (v6 == 7)
            if (v7) {
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
