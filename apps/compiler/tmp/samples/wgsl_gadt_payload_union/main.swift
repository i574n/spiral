import CRT
import WinSDK
protocol US1 { var tag: Int32 { get } }
struct US1_Living: US1 { var f0: Int32; var f1: Int32; var tag: Int32 { 0 } }
protocol US2 { var tag: Int32 { get } }
struct US2_Fallen: US2 { var f0: Int32; var tag: Int32 { 1 } }
protocol US0 { var tag: Int32 { get } }
struct US0_Survived: US0 { var f0: US1; var tag: Int32 { 0 } }
struct US0_Slain: US0 { var f0: US2; var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 60
    var v1: Bool = false
    v1 = (v0 > 0)
    var v6: US0 = US0_Survived(f0: US1_Living(f0: 0, f1: 0))
    if (v1) {
        var v2: US1 = US1_Living(f0: 0, f1: 0)
        v2 = US1_Living(f0: v0, f1: 100)
        v6 = US0_Survived(f0: v2)
    } else {
        var v4: US2 = US2_Fallen(f0: 0)
        v4 = US2_Fallen(f0: 100)
        v6 = US0_Slain(f0: v4)
    }
    switch v6.tag {
        case 1:
            var v13: US2 = (v6 as! US0_Slain).f0
            return 2
        case 0:
            var v7: US1 = (v6 as! US0_Survived).f0
            switch v7.tag {
                case 0:
                    var v8: Int32 = (v7 as! US1_Living).f0
                    var v9: Int32 = (v7 as! US1_Living).f1
                    var v10: Bool = false
                    v10 = (v8 == 60)
                    if (v10) {
                        return 0
                    } else {
                        return 1
                    }
                default:
                    fatalError("unreachable union case")
            }
        default:
            fatalError("unreachable union case")
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
