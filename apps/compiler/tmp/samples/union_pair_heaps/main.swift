import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    let l1: String
    init(l0: Int32, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Heap0; var f1: Heap0; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: Heap0 = (v0 as! US0_Held).f0
            var v2: Heap0 = (v0 as! US0_Held).f1
            var v3: Int32 = 0
            var v4: String = ""
            v3 = v1.l0
            v4 = v1.l1
            var v5: Int32 = 0
            var v6: String = ""
            v5 = v2.l0
            v6 = v2.l1
            var v7: Bool = false
            v7 = (v3 == 7)
            var v9: Bool = false
            if (v7) {
                var v8: Bool = false
                v8 = (v4 == "hi")
                v9 = v8
            } else {
                v9 = false
            }
            var v11: Bool = false
            if (v9) {
                var v10: Bool = false
                v10 = (v5 == 4)
                v11 = v10
            } else {
                v11 = false
            }
            var v13: Bool = false
            if (v11) {
                var v12: Bool = false
                v12 = (v6 == "yo")
                v13 = v12
            } else {
                v13 = false
            }
            if (v13) {
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
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    v3 = 4
    var v4: String = ""
    v4 = "yo"
    var v5: Heap0 = Heap0(l0: 0, l1: "")
    v5 = Heap0(l0: v3, l1: v4)
    var v6: Bool = false
    v6 = true
    var v9: US0 = US0_None()
    if (v6) {
        v9 = US0_Held(f0: v2, f1: v5)
    } else {
        v9 = US0_None()
    }
    return sp_score_0(v9)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
