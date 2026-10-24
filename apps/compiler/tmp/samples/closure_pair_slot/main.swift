import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 1 } }
func f_c0(_ v0: Int32) -> (Int32) -> (US0, Int32) {
    return { (v1: Int32) -> (US0, Int32) in
        var v2: Bool = false
        v2 = (v1 == 0)
        if (v2) {
            var v3: US0 = US0_None()
            v3 = US0_None()
            return (v3, 0)
        } else {
            let v4: US0 = US0_Some(f0: v0)
            return (v4, v0)
        }
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    let v1: (Int32) -> (US0, Int32) = f_c0(v0)
    var v2: US0 = US0_None()
    var v3: Int32 = 0
    let spiral_tuple245 = v1(1)
    v2 = spiral_tuple245.0
    v3 = spiral_tuple245.1
    switch v2.tag {
        case 0:
            return 1
        case 1:
            var v4: Int32 = (v2 as! US0_Some).f0
            let v5: Bool = (v4 == 7)
            var v7: Bool = false
            if (v5) {
                let v6: Bool = (v3 == 7)
                v7 = v6
            } else {
                v7 = false
            }
            if (v7) {
                return 0
            } else {
                return 1
            }
        default:
            fatalError("unreachable union case")
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
