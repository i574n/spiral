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
class Heap3 {
    let l0: US0
    init(l0: US0) {
        self.l0 = l0
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Heap2; var tag: Int32 { 1 } }
protocol US1 { var tag: Int32 { get } }
struct US1_Absent: US1 { var tag: Int32 { 0 } }
struct US1_Box: US1 { var f0: Heap3; var tag: Int32 { 1 } }
struct US1_Mark: US1 { var f0: Int32; var tag: Int32 { 2 } }
func sp_score_0(_ p0: US1) -> Int32 {
    var v0: US1 = p0
    switch v0.tag {
        case 0:
            return 1
        case 1:
            var v3: Heap3 = (v0 as! US1_Box).f0
            var v4: US0 = US0_None()
            v4 = v3.l0
            switch v4.tag {
                case 1:
                    var v5: Heap2 = (v4 as! US0_Held).f0
                    var v6: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
                    var v7: Int32 = 0
                    v6 = v5.l0
                    v7 = v5.l1
                    var v8: Heap0 = Heap0(l0: 0, l1: "")
                    var v9: Heap0 = Heap0(l0: 0, l1: "")
                    v8 = v6.l0
                    v9 = v6.l1
                    var v10: Int32 = 0
                    var v11: String = ""
                    v10 = v8.l0
                    v11 = v8.l1
                    var v12: Int32 = 0
                    var v13: String = ""
                    v12 = v9.l0
                    v13 = v9.l1
                    var v14: Bool = false
                    v14 = (v10 == 7)
                    var v16: Bool = false
                    if (v14) {
                        let v15: Bool = (v11 == "hi")
                        v16 = v15
                    } else {
                        v16 = false
                    }
                    var v18: Bool = false
                    if (v16) {
                        var v17: Bool = false
                        v17 = (v12 == 4)
                        v18 = v17
                    } else {
                        v18 = false
                    }
                    var v20: Bool = false
                    if (v18) {
                        var v19: Bool = false
                        v19 = (v13 == "yo")
                        v20 = v19
                    } else {
                        v20 = false
                    }
                    var v22: Bool = false
                    if (v20) {
                        var v21: Bool = false
                        v21 = (v7 == 2)
                        v22 = v21
                    } else {
                        v22 = false
                    }
                    if (v22) {
                        return 0
                    } else {
                        return 1
                    }
                case 0:
                    return 1
                default:
                    fatalError("unreachable union case")
            }
        case 2:
            var v1: Int32 = (v0 as! US1_Mark).f0
            return 1
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    let v1: String = "hi"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 4
    var v4: String = ""
    v4 = "yo"
    let v5: Heap0 = Heap0(l0: v3, l1: v4)
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
    var v13: Heap3 = Heap3(l0: US0_None())
    v13 = Heap3(l0: v12)
    var v14: Bool = false
    v14 = true
    var v17: US1 = US1_Absent()
    if (v14) {
        v17 = US1_Box(f0: v13)
    } else {
        v17 = US1_Mark(f0: 1)
    }
    var v18: Int32 = 0
    v18 = 3
    var v19: Int32 = 0
    v19 = sp_score_0(v17)
    var v20: US1 = US1_Absent()
    v20 = US1_Mark(f0: v18)
    var v21: Int32 = 0
    v21 = sp_score_0(v20)
    var v22: US1 = US1_Absent()
    v22 = US1_Absent()
    let v23: Int32 = sp_score_0(v22)
    let v24: Bool = (v19 == 0)
    var v26: Bool = false
    if (v24) {
        let v25: Bool = (v21 == 1)
        v26 = v25
    } else {
        v26 = false
    }
    var v28: Bool = false
    if (v26) {
        let v27: Bool = (v23 == 1)
        v28 = v27
    } else {
        v28 = false
    }
    if (v28) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
