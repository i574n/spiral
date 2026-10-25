import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_One: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_Both: US0 { var f0: Int32; var f1: Int32; var tag: Int32 { 1 } }
func sp_sum_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v2: Int32 = (v0 as! US0_Both).f0
            var v3: Int32 = (v0 as! US0_Both).f1
            var v4: Int32 = 0
            v4 = (v2 &* 10)
            var v5: Int32 = 0
            v5 = (v4 &+ v3)
            return v5
        case 0:
            var v1: Int32 = (v0 as! US0_One).f0
            return v1
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v3: US0 = US0_One(f0: 0)
    if (v0) {
        v3 = US0_Both(f0: 3, f1: 4)
    } else {
        v3 = US0_One(f0: 1)
    }
    var v6: US0 = US0_One(f0: 0)
    if (v0) {
        v6 = US0_One(f0: 5)
    } else {
        v6 = US0_Both(f0: 1, f1: 1)
    }
    var v7: Int32 = 0
    v7 = sp_sum_0(v3)
    var v8: Bool = false
    v8 = (v7 == 34)
    var v11: Bool = false
    if (v8) {
        var v9: Int32 = 0
        v9 = sp_sum_0(v6)
        var v10: Bool = false
        v10 = (v9 == 5)
        v11 = v10
    } else {
        v11 = false
    }
    if (v11) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
