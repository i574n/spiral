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
    let l1: Heap0
    init(l0: Heap0, l1: Heap0) {
        self.l0 = l0
        self.l1 = l1
    }
}
class Heap2 {
    let l0: Heap1
    let l1: Int32
    init(l0: Heap1, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Heap2; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: Heap2 = (v0 as! US0_Held).f0
            var v2: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
            var v3: Int32 = 0
            v2 = v1.l0
            v3 = v1.l1
            var v4: Heap0 = Heap0(l0: 0, l1: "")
            var v5: Heap0 = Heap0(l0: 0, l1: "")
            v4 = v2.l0
            v5 = v2.l1
            var v6: Int32 = 0
            var v7: String = ""
            v6 = v4.l0
            v7 = v4.l1
            var v8: Int32 = 0
            var v9: String = ""
            v8 = v5.l0
            v9 = v5.l1
            let v10: Bool = (v6 == 7)
            var v12: Bool = false
            if (v10) {
                let v11: Bool = (v7 == "hi")
                v12 = v11
            } else {
                v12 = false
            }
            var v14: Bool = false
            if (v12) {
                let v13: Bool = (v8 == 4)
                v14 = v13
            } else {
                v14 = false
            }
            var v16: Bool = false
            if (v14) {
                let v15: Bool = (v9 == "yo")
                v16 = v15
            } else {
                v16 = false
            }
            var v18: Bool = false
            if (v16) {
                let v17: Bool = (v3 == 2)
                v18 = v17
            } else {
                v18 = false
            }
            if (v18) {
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
    v3 = 4
    var v4: String = ""
    v4 = "yo"
    var v5: Heap0 = Heap0(l0: 0, l1: "")
    v5 = Heap0(l0: v3, l1: v4)
    var v6: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    v6 = Heap1(l0: v2, l1: v5)
    var v7: Int32 = 0
    v7 = 2
    var v8: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)
    v8 = Heap2(l0: v6, l1: v7)
    var v9: Bool = false
    v9 = true
    var v12: US0 = US0_None()
    if (v9) {
        v12 = US0_Held(f0: v8)
    } else {
        v12 = US0_None()
    }
    return sp_score_0(v12)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
