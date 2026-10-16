import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_One: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_Both: US0 { var f0: Int32; var f1: String; var tag: Int32 { 1 } }
func f_c0(_ v0: Int32, _ v1: String) -> (Int32) -> US0 {
    return { (v2: Int32) -> US0 in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            return US0_One(f0: 0)
        } else {
            return US0_Both(f0: v0, f1: v1)
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: String = ""
    v1 = "hi"
    var v2: (Int32) -> US0 = { (_: Int32) -> US0 in fatalError("unreachable closure") }
    v2 = f_c0(v0, v1)
    var v3: US0 = US0_One(f0: 0)
    v3 = v2(1)
    switch v3.tag {
        case 1:
            var v5: Int32 = (v3 as! US0_Both).f0
            var v6: String = (v3 as! US0_Both).f1
            var v7: Bool = false
            v7 = (v5 == 3)
            var v9: Bool = false
            if (v7) {
                var v8: Bool = false
                v8 = (v6 == "hi")
                v9 = v8
            } else {
                v9 = false
            }
            if (v9) {
                return 0
            } else {
                return 1
            }
        case 0:
            var v4: Int32 = (v3 as! US0_One).f0
            return 1
        default:
            fatalError("unreachable union case")
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
