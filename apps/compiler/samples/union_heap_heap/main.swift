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
class Heap1 {
    let l0: Heap0
    let l1: Int32
    init(l0: Heap0, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Heap1; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: Heap1 = (v0 as! US0_Held).f0
            var v2: Heap0 = Heap0(l0: 0, l1: "")
            var v3: Int32 = 0
            v2 = v1.l0
            v3 = v1.l1
            var v4: Int32 = 0
            var v5: String = ""
            v4 = v2.l0
            v5 = v2.l1
            let v6: Bool = (v4 == 7)
            var v8: Bool = false
            if (v6) {
                let v7: Bool = (v5 == "hi")
                v8 = v7
            } else {
                v8 = false
            }
            var v10: Bool = false
            if (v8) {
                let v9: Bool = (v3 == 1)
                v10 = v9
            } else {
                v10 = false
            }
            if (v10) {
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
    let v0: Int32 = 7
    let v1: String = "hi"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    v3 = 1
    var v4: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    v4 = Heap1(l0: v2, l1: v3)
    var v5: Bool = false
    v5 = true
    var v8: US0 = US0_None()
    if (v5) {
        v8 = US0_Held(f0: v4)
    } else {
        v8 = US0_None()
    }
    return sp_score_0(v8)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
