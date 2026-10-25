import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_One: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_Both: US0 { var f0: Int32; var f1: String; var tag: Int32 { 1 } }
func sp_method0(_ p0: Int32, _ p1: String) -> US0 {
    var v0: Int32 = p0
    var v1: String = p1
    var v2: Bool = false
    v2 = (v0 == 0)
    if (v2) {
        return US0_One(f0: 0)
    } else {
        return US0_Both(f0: v0, f1: v1)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: String = ""
    v1 = "hi"
    var v2: US0 = US0_One(f0: 0)
    v2 = sp_method0(v0, v1)
    switch v2.tag {
        case 1:
            var v4: Int32 = (v2 as! US0_Both).f0
            var v5: String = (v2 as! US0_Both).f1
            var v6: Bool = false
            v6 = (v4 == 3)
            var v8: Bool = false
            if (v6) {
                var v7: Bool = false
                v7 = (v5 == "hi")
                v8 = v7
            } else {
                v8 = false
            }
            if (v8) {
                return 0
            } else {
                return 1
            }
        case 0:
            var v3: Int32 = (v2 as! US0_One).f0
            return 1
        default:
            fatalError("unreachable union case")
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
