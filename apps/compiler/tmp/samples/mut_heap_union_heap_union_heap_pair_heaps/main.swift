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
class Heap4 {
    let l0: US1
    init(l0: US1) {
        self.l0 = l0
    }
}
class Mut5 {
    var l0: Heap4
    init(l0: Heap4) {
        self.l0 = l0
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Heap2; var tag: Int32 { 1 } }
protocol US1 { var tag: Int32 { get } }
struct US1_Absent: US1 { var tag: Int32 { 0 } }
struct US1_Box: US1 { var f0: Heap3; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US1) -> Int32 {
    var v0: US1 = p0
    switch v0.tag {
        case 0:
            return 1
        case 1:
            var v1: Heap3 = (v0 as! US1_Box).f0
            var v2: US0 = US0_None()
            v2 = v1.l0
            switch v2.tag {
                case 1:
                    var v3: Heap2 = (v2 as! US0_Held).f0
                    var v4: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
                    var v5: Int32 = 0
                    v4 = v3.l0
                    v5 = v3.l1
                    var v6: Heap0 = Heap0(l0: 0, l1: "")
                    var v7: Heap0 = Heap0(l0: 0, l1: "")
                    v6 = v4.l0
                    v7 = v4.l1
                    var v8: Int32 = 0
                    var v9: String = ""
                    v8 = v6.l0
                    v9 = v6.l1
                    var v10: Int32 = 0
                    var v11: String = ""
                    v10 = v7.l0
                    v11 = v7.l1
                    var v12: Bool = false
                    v12 = (v8 == 7)
                    var v14: Bool = false
                    if (v12) {
                        var v13: Bool = false
                        v13 = (v9 == "hi")
                        v14 = v13
                    } else {
                        v14 = false
                    }
                    var v16: Bool = false
                    if (v14) {
                        let v15: Bool = (v10 == 4)
                        v16 = v15
                    } else {
                        v16 = false
                    }
                    var v18: Bool = false
                    if (v16) {
                        var v17: Bool = false
                        v17 = (v11 == "yo")
                        v18 = v17
                    } else {
                        v18 = false
                    }
                    var v20: Bool = false
                    if (v18) {
                        var v19: Bool = false
                        v19 = (v5 == 2)
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
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 1
    let v1: String = "no"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 2
    var v4: String = ""
    v4 = "zz"
    var v5: Heap0 = Heap0(l0: 0, l1: "")
    v5 = Heap0(l0: v3, l1: v4)
    var v6: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    v6 = Heap1(l0: v2, l1: v5)
    var v7: Int32 = 0
    v7 = 3
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
        v17 = US1_Absent()
    }
    var v18: Heap4 = Heap4(l0: US1_Absent())
    v18 = Heap4(l0: v17)
    var v19: Mut5 = Mut5(l0: Heap4(l0: US1_Absent()))
    v19 = Mut5(l0: v18)
    var v20: Int32 = 0
    v20 = 7
    let v21: String = "hi"
    let v22: Heap0 = Heap0(l0: v20, l1: v21)
    let v23: Int32 = 4
    let v24: String = "yo"
    let v25: Heap0 = Heap0(l0: v23, l1: v24)
    let v26: Heap1 = Heap1(l0: v22, l1: v25)
    let v27: Int32 = 2
    let v28: Heap2 = Heap2(l0: v26, l1: v27)
    let v29: Bool = true
    var v32: US0 = US0_None()
    if (v29) {
        v32 = US0_Held(f0: v28)
    } else {
        v32 = US0_None()
    }
    let v33: Heap3 = Heap3(l0: v32)
    let v34: Bool = true
    var v37: US1 = US1_Absent()
    if (v34) {
        v37 = US1_Box(f0: v33)
    } else {
        v37 = US1_Absent()
    }
    let v38: Heap4 = Heap4(l0: v37)
    v19.l0 = v38
    let v39: Heap4 = v19.l0
    let v40: US1 = v39.l0
    return sp_score_0(v40)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
