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
struct US0_Held: US0 { var f0: Heap0; var f1: Heap0; var f2: Heap0; var tag: Int32 { 1 } }
func f_c0(_ v0: Heap0, _ v1: Heap0, _ v2: Heap0) -> (Int32) -> US0 {
    return { (v3: Int32) -> US0 in
        var v4: Bool = false
        v4 = (v3 == 0)
        if (v4) {
            return US0_None()
        } else {
            return US0_Held(f0: v0, f1: v1, f2: v2)
        }
    }
}
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: Heap0 = (v0 as! US0_Held).f0
            var v2: Heap0 = (v0 as! US0_Held).f1
            var v3: Heap0 = (v0 as! US0_Held).f2
            var v4: Int32 = 0
            var v5: String = ""
            v4 = v1.l0
            v5 = v1.l1
            var v6: Int32 = 0
            var v7: String = ""
            v6 = v2.l0
            v7 = v2.l1
            var v8: Int32 = 0
            var v9: String = ""
            v8 = v3.l0
            v9 = v3.l1
            var v10: Bool = false
            v10 = (v4 == 7)
            var v12: Bool = false
            if (v10) {
                var v11: Bool = false
                v11 = (v5 == "hi")
                v12 = v11
            } else {
                v12 = false
            }
            var v14: Bool = false
            if (v12) {
                var v13: Bool = false
                v13 = (v6 == 4)
                v14 = v13
            } else {
                v14 = false
            }
            var v16: Bool = false
            if (v14) {
                var v15: Bool = false
                v15 = (v7 == "yo")
                v16 = v15
            } else {
                v16 = false
            }
            var v18: Bool = false
            if (v16) {
                var v17: Bool = false
                v17 = (v8 == 9)
                v18 = v17
            } else {
                v18 = false
            }
            var v20: Bool = false
            if (v18) {
                var v19: Bool = false
                v19 = (v9 == "ok")
                v20 = v19
            } else {
                v20 = false
            }
            if (v20) {
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
    var v6: Int32 = 0
    v6 = 9
    var v7: String = ""
    v7 = "ok"
    var v8: Heap0 = Heap0(l0: 0, l1: "")
    v8 = Heap0(l0: v6, l1: v7)
    var v9: (Int32) -> US0 = { (_: Int32) -> US0 in fatalError("unreachable closure") }
    v9 = f_c0(v2, v5, v8)
    var v10: US0 = US0_None()
    v10 = v9(1)
    return sp_score_0(v10)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
