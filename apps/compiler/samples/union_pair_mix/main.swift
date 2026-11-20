import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_One: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_Both: US0 { var f0: Int32; var f1: String; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v2: Int32 = (v0 as! US0_Both).f0
            var v3: String = (v0 as! US0_Both).f1
            let v4: Bool = (v2 == 3)
            var v6: Bool = false
            if (v4) {
                var v5: Bool = false
                v5 = (v3 == "hi")
                v6 = v5
            } else {
                v6 = false
            }
            if (v6) {
                return 0
            } else {
                return 1
            }
        case 0:
            var v1: Int32 = (v0 as! US0_One).f0
            return v1
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    let v0: Bool = true
    let v1: Int32 = 3
    let v2: String = "hi"
    var v5: US0 = US0_One(f0: 0)
    if (v0) {
        v5 = US0_Both(f0: v1, f1: v2)
    } else {
        v5 = US0_One(f0: 1)
    }
    return sp_score_0(v5)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
